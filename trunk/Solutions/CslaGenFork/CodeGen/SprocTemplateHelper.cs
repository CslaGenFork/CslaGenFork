using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CodeSmith.Engine;
using CslaGenerator.Metadata;
using DBSchemaInfo.Base;

namespace CslaGenerator.CodeGen
{
    /// <summary>
    /// Summary description for SprocTemplateHelper.
    /// </summary>
    public class SprocTemplateHelper : CodeTemplate
    {
        #region Private fields

        private readonly ICatalog _catalog = GeneratorController.Catalog;
        private CslaObjectInfo _info;
        private Criteria _criteria = new Criteria();
        private bool _criteriaDefined;
        private CslaObjectInfo _topLevelObject;
        private bool _topLevelCollectiontHasNoGetParams;
        private readonly List<DuplicateTables> _correlationNames = new List<DuplicateTables>();
        private int _innerJoins;

        #endregion

        #region Private struct

        protected struct DuplicateTables
        {
            internal string PropertyName;
            internal string TableName;
            internal string ColumnName;
            internal int Order;
        }

        #endregion

        #region Public Properties

        [Browsable(false)]
        public ICatalog Catalog
        {
            get { return _catalog; }
        }

        public CslaObjectInfo Info
        {
            get { return _info; }
            set { _info = value; }
        }

        /*public bool IncludeParentProperties
        {
            get { return _includeParentProperties; }
            set { _includeParentProperties = value; }
        }*/

        protected bool CriteriaDefined
        {
            get { return _criteriaDefined; }
        }

        public Criteria Criteria
        {
            get { return _criteria; }
            set
            {
                _criteria = value;
                _criteriaDefined = true;
            }
        }

        #endregion

        public void Init(CslaObjectInfo info)
        {
            _topLevelObject = info;
            if (IsCollectionType(_topLevelObject.ObjectType))
            {
                _topLevelCollectiontHasNoGetParams = true;
                foreach (var crit in info.CriteriaObjects)
                {
                    if ((crit.GetOptions.DataPortal || crit.GetOptions.Factory || crit.GetOptions.Procedure) &&
                        crit.Properties.Count > 0)
                    {
                        _topLevelCollectiontHasNoGetParams = false;
                        break;
                    }
                }
            }
        }

        #region Accessories

        public string GetSchema(IResultObject table, bool fullSchema)
        {
            if (!Info.Parent.GenerationParams.GenerateQueriesWithSchema)
                return "";

            if (fullSchema)
                return "[" + table.ObjectSchema + "].";

            return table.ObjectSchema + ".";
        }

        private void StoreCorrelationNames(CslaObjectInfo info)
        {
            _correlationNames.Clear();
            var writeCorr = new DuplicateTables();
            var vpc = new ValuePropertyCollection();
            /*if (IncludeParentProperties)
                vpc.AddRange(info.GetParentValueProperties());*/

            vpc.AddRange(info.GetAllValueProperties());
            for (var vp = 0; vp < vpc.Count; vp++)
            {
                var count = 1;
                for (var prop = 0; prop < vp; prop++)
                {
                    var readCorr = _correlationNames[prop];
                    if (readCorr.PropertyName != vpc[vp].Name)
                    {
                        if (readCorr.TableName == vpc[vp].DbBindColumn.ObjectName &&
                            readCorr.ColumnName == vpc[vp].DbBindColumn.ColumnName)
                        {
                            if (readCorr.Order >= count)
                                count = readCorr.Order + 1;
                        }
                    }
                }
                writeCorr.PropertyName = vpc[vp].Name;
                writeCorr.TableName = vpc[vp].DbBindColumn.ObjectName;
                writeCorr.ColumnName = vpc[vp].DbBindColumn.ColumnName;
                writeCorr.Order = count;
                _correlationNames.Add(writeCorr);
            }
        }

        private string GetCorrelationName(ValueProperty prop)
        {
            foreach (var correlationName in _correlationNames)
            {
                if (correlationName.PropertyName == prop.Name)
                {
                    if (correlationName.Order > 1)
                        return correlationName.TableName + correlationName.Order;

                    return correlationName.TableName;
                }
            }

            MessageBox.Show(@"Property " + prop.Name + @" not found.", @"Error!");
            return "";
        }

        public string GetDataTypeString(CslaObjectInfo info, string propName)
        {
            var prop = GetValuePropertyByName(info,propName);
            if (prop == null)
                throw new Exception("Parameter '" + propName + "' does not have a corresponding ValueProperty. Make sure a ValueProperty with the same name exists");

            if (prop.DbBindColumn == null)
                throw new Exception("Property '" + propName + "' does not have it's DbBindColumn initialized.");

            return GetDataTypeString(prop.DbBindColumn);
        }

        public string GetDataTypeString(CriteriaProperty col)
        {
            if (col.DbBindColumn.Column != null)
                return GetDataTypeString(col.DbBindColumn);

            var prop = Info.ValueProperties.Find(col.Name);
            if (prop != null)
                return GetDataTypeString(prop.DbBindColumn);

            throw new ApplicationException("No column information for this criteria property: " + col.Name);
        }

        public string GetDataTypeString(DbBindColumn col)
        {
            var nativeType = col.NativeType.ToLower();
            var sb = new StringBuilder();
            if (nativeType == "varchar" ||
                nativeType == "nvarchar" ||
                nativeType == "char" ||
                nativeType == "nchar" ||
                nativeType == "binary" ||
                nativeType == "varbinary")
            {
                sb.Append(col.NativeType);
                sb.Append("(");
                sb.Append(col.Column.ColumnLength >= 0 ? col.Column.ColumnLength.ToString() : "MAX");
                sb.Append(")");
            }
            else if (nativeType == "decimal" ||
                nativeType == "numeric")
            {
                sb.Append(col.NativeType);
                sb.Append("(");
                sb.Append(col.Column.ColumnLength.ToString());
                sb.Append(", ");
                sb.Append(col.Column.ColumnScale.ToString());
                sb.Append(")");
            }
            else
                sb.Append(col.NativeType);

            return sb.ToString();
        }

        public string GetColumnString(CriteriaProperty param)
        {
            if (param.DbBindColumn.Column != null)
                return GetColumnString(param.DbBindColumn);

            var prop = Info.ValueProperties.Find(param.Name);
            if (prop != null)
                return GetColumnString(prop.DbBindColumn);

            throw new ApplicationException("No column information for this criteria property: " + param.Name);
        }

        public string GetColumnString(DbBindColumn col)
        {
            return col.ColumnName;
        }

        public string GetTableString(CriteriaProperty param)
        {
            if (param.DbBindColumn.Column != null)
                return GetTableString(param.DbBindColumn);

            var prop = Info.ValueProperties.Find(param.Name);
            if (prop != null)
                return GetTableString(prop.DbBindColumn);

            throw new ApplicationException("No table information for this criteria property: " + param.Name);
        }

        public string GetTableString(DbBindColumn col)
        {
            return col.ObjectName;
        }

        #endregion

        #region SELECT core

        public string GetSelect(CslaObjectInfo info, Criteria crit, bool includeParentObjects, bool isCollectionSearchWhereClause, int level, bool dontInnerJoinUp)
        {
            var collType = IsCollectionType(info.ObjectType);
            if (collType)
                info = FindChildInfo(info, info.ItemType);

            var dataOrigin = "table";
            // find out where the data come from
            foreach (var prop in info.GetAllValueProperties())
            {
                if (prop.DbBindColumn.Column == null)
                    continue;

                if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.View)
                {
                    dataOrigin = "view";
                    break;
                }
            }

            StoreCorrelationNames(info);
            var sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append(Indent(2) + "/* Get " + info.ObjectName + " from " + dataOrigin + " */" + Environment.NewLine);
            sb.Append(GetSelectFields(info, level));

            if (dontInnerJoinUp)
                sb.Append(GetFromClause(crit, info, false));
            else
                sb.Append(isCollectionSearchWhereClause
                              ? GetFromClause(crit, info, true)
                              : GetFromClause(crit, info, includeParentObjects));

            sb.Append(isCollectionSearchWhereClause
                          ? GetSearchWhereClause(_topLevelObject, info, crit)
                          : GetWhereClause(info, crit, includeParentObjects));

            return NormalizeNewLineAtEndOfFile(sb.ToString());
        }

        private static string NormalizeNewLineAtEndOfFile(string statement)
        {
            var uni = Environment.NewLine.ToCharArray();
            statement = statement.TrimEnd(uni);
            statement = statement.TrimEnd(uni);
            statement = statement.TrimEnd(uni);
            statement = statement.Replace(Environment.NewLine + Environment.NewLine + Environment.NewLine,
                                          Environment.NewLine + Environment.NewLine);

            return statement;
        }

        public string GetChildSelects(CslaObjectInfo info, Criteria crit, bool isCollectionSearchWhereClause, int level, bool dontInnerJoinUp)
        {
            level++;
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            var sb = new StringBuilder();
            var first = true;
            foreach (var childProp in info.GetAllChildProperties())
            {
                var childInfo = FindChildInfo(info, childProp.TypeName);
                if (childInfo != null && childProp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    if (!first)
                        sb.Append(Environment.NewLine);
                    else
                        first = false;

                    if (level > 2)
                        sb.Append(Environment.NewLine);
                    sb.Append(GetSelect(childInfo, crit, true, isCollectionSearchWhereClause, level, dontInnerJoinUp));
                    sb.Append(GetChildSelects(childInfo, crit, isCollectionSearchWhereClause, level, dontInnerJoinUp));
                }
            }

            return NormalizeNewLineAtEndOfFile(sb.ToString());
        }

        public string MissingForeignKeys(Criteria crit, CslaObjectInfo info, int level, bool dontInnerJoinUp)
        {
            var result = string.Empty;
            level++;
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            foreach (var childProp in info.GetAllChildProperties())
            {
                var childInfo = FindChildInfo(info, childProp.TypeName);
                if (childInfo != null && childProp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    var temp = MissingForeignKeys(crit, childInfo, level, dontInnerJoinUp);
                    if (temp != string.Empty)
                    {
                        if (result != string.Empty)
                            result += ", ";
                        result += temp;
                    }
                }
            }

            if (level > 2)
            {
                var tables = GetTables(crit, info, true);
                if (tables.Count > 1)
                {
                    var problemTables = new List<IResultObject>();
                    var parentTables = GetTablesParent(crit, info);
                    foreach (var table in tables)
                    {
                        if (parentTables.Contains(table))
                            continue;
                        var fkFound = false;
                        var fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(table);
                        SortKeys(fKeys, parentTables);
                        fKeys = FilterDuplicateConstraintTables(fKeys, info.GetDatabaseBoundValueProperties());
                        foreach (var key in fKeys)
                        {
                            if (tables.IndexOf(key.PKTable) >= 0)
                            {
                                fkFound = true;
                                break;
                            }
                        }
                        if (!fkFound)
                        {
                            problemTables.Add(table);
                        }
                    }

                    foreach (var table in tables)
                    {
                        if (parentTables.Contains(table))
                            continue;
                        var fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(table);
                        SortKeys(fKeys, parentTables);
                        fKeys = FilterDuplicateConstraintTables(fKeys, info.GetDatabaseBoundValueProperties());
                        foreach (var key in fKeys)
                        {
                            for (var index = 0; index < problemTables.Count; index++)
                            {
                                var problemTable = problemTables[index];
                                if (table == problemTable)
                                    continue;
                                if (key.PKTable.ObjectName == problemTable.ObjectName)
                                {
                                    problemTables.Remove(problemTable);
                                    if (problemTables.Count == 0)
                                        break;
                                }
                            }
                            if (problemTables.Count == 0)
                                break;
                        }
                        if (problemTables.Count == 0)
                            break;
                    }

                    foreach (var problemTable in problemTables)
                    {
                        if (result != string.Empty)
                            result += ", ";
                        result += problemTable.ObjectName;
                    }
                }
            }

            return result;
        }

        private string GetFromClause(Criteria crit, CslaObjectInfo info, bool includeParentObjects)
        {
            _innerJoins = 0;
            var tables = GetTables(crit, info, includeParentObjects);
            SortTables(tables);
            CheckTableJoins(tables);

            var sb = new StringBuilder();
            sb.Append(Indent(2) + "FROM ");
            if (tables.Count == 1)
            {
                sb.AppendFormat("{0}[{1}]", GetSchema(tables[0], true), tables[0].ObjectName);
                sb.Append(Environment.NewLine);
                return sb.ToString();
            }
            if (tables.Count > 1)
            {
                var usedTables = new List<IResultObject>();
                var firstJoin = true;
                var parentTables = GetTablesParent(crit, info);
                foreach (var table in tables)
                {
                    var fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(table);

                    // sort key.PKTable so key.PKTable that reference the parent table come before other keys
                    // and
                    // Primary keys come before other constraint references to the parent object
                    SortKeys(fKeys, parentTables);
                    fKeys = FilterDuplicateConstraintTables(fKeys, info.GetDatabaseBoundValueProperties());

                    foreach (var key in fKeys)
                    {
                        // check if this key is needed in the join
                        if (tables.IndexOf(key.PKTable) >= 0)
                        {
                            if (firstJoin)
                            {
                                sb.AppendFormat("{0}[{1}]", GetSchema(key.ConstraintTable, true), key.ConstraintTable.ObjectName);
                                sb.Append(Environment.NewLine + Indent(3));
                                sb.Append("INNER JOIN ");
                                sb.AppendFormat("{0}[{1}]", GetSchema(key.PKTable, true), key.PKTable.ObjectName);
                                sb.Append(" ON ");
                                var firstKeyColl = true;
                                foreach (var kcPair in key.Columns)
                                {
                                    if (firstKeyColl)
                                        firstKeyColl = false;
                                    else
                                    {
                                        sb.Append(" AND");
                                        sb.Append(Environment.NewLine + Indent(6));
                                    }

                                    sb.Append(GetAliasedFieldString(key.ConstraintTable, kcPair.FKColumn));
                                    sb.Append(" = ");
                                    sb.Append(GetAliasedFieldString(key.PKTable, kcPair.PKColumn));
                                    _innerJoins++;
                                }
                                usedTables.Add(key.PKTable);
                                usedTables.Add(key.ConstraintTable);
                                firstJoin = false;
                            }
                            else
                            {
                                if (usedTables.Contains(key.PKTable) &&
                                    usedTables.Contains(key.ConstraintTable))
                                {
                                    sb.Append(" AND");
                                    sb.Append(Environment.NewLine + Indent(6));
                                }
                                else
                                {
                                    sb.Append(Environment.NewLine + Indent(3));
                                    sb.Append("INNER JOIN ");
                                    sb.AppendFormat("{0}[{1}]", GetSchema(key.PKTable, true), key.PKTable.ObjectName);
                                    sb.Append(" ON ");
                                    usedTables.Add(key.PKTable);
                                }

                                var firstKeyColl = true;
                                foreach (var kcPair in key.Columns)
                                {
                                    if (firstKeyColl)
                                        firstKeyColl = false;
                                    else
                                    {
                                        sb.Append(" AND");
                                        sb.Append(Environment.NewLine + Indent(6));
                                    }

                                    sb.Append(GetAliasedFieldString(key.ConstraintTable, kcPair.FKColumn));
                                    sb.Append(" = ");
                                    sb.Append(GetAliasedFieldString(key.PKTable, kcPair.PKColumn));
                                    _innerJoins++;
                                }
                            }
                        }
                    }
                }
                sb.Append(Environment.NewLine);
                return sb.ToString();
            }

            return String.Empty;
        }

        private string InjectParentPropertiesOnResultSet(CslaObjectInfo info, ref bool first, ref List<IColumnInfo> usedByParentProperties)
        {
            var tables = GetTables(new Criteria(info), info, false);
            var fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(tables[0]);
            fKeys = FilterDuplicateConstraintTables(fKeys, info.GetDatabaseBoundValueProperties());
            var sb = new StringBuilder();
            var parentProperties = info.GetParentValueProperties();
            foreach (var key in fKeys)
            {
                if (key.PKTable != key.ConstraintTable)
                {
                    foreach (var prop in parentProperties)
                    {
                        if (prop.DbBindColumn.Column == null)
                            continue;

                        if (prop.DbBindColumn.ObjectName == key.PKTable.ObjectName)
                        {
                            foreach (var t in key.Columns)
                            {
                                if (prop.DbBindColumn.ColumnName == t.PKColumn.ColumnName)
                                {
                                    usedByParentProperties.Add(t.FKColumn);
                                    if (!first)
                                        sb.Append("," + Environment.NewLine);
                                    else
                                        first = false;

                                    sb.Append(Indent(3));
                                    if (t.FKColumn.DbType == DbType.StringFixedLength)
                                    {
                                        sb.Append("RTRIM(");
                                        sb.Append(GetAliasedFieldString(key.ConstraintTable, t.FKColumn) + ")");
                                    }
                                    else
                                    {
                                        sb.Append(GetAliasedFieldString(key.ConstraintTable, t.FKColumn));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return sb.ToString();
        }

        private string GetSelectFields(CslaObjectInfo info, int level)
        {
            var sb = new StringBuilder();
            sb.Append(Indent(2) + "SELECT" + Environment.NewLine);
            var first = true;
            var usedByParentProperties = new List<IColumnInfo>();
            if (level > 2 || (_topLevelCollectiontHasNoGetParams && level > 1))
                sb.Append(InjectParentPropertiesOnResultSet(info, ref first, ref usedByParentProperties));

            var vpc = new ValuePropertyCollection();
            /*if (IncludeParentProperties)
                vpc.AddRange(info.GetParentValueProperties());*/
//t.FKColumn
            vpc.AddRange(info.GetAllValueProperties());
            foreach (var prop in vpc)
            {
                if (prop.DbBindColumn.Column == null)
                    continue;

                if (prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly)
                {
                    var duplicatedColumn = false;
                    foreach (var parentProperty in usedByParentProperties)
                    {
                        if (parentProperty == prop.DbBindColumn.Column)
                        {
                            duplicatedColumn = true;
                            break;
                        }
                    }
                    if (duplicatedColumn)
                        continue;

                    if (!first)
                        sb.Append("," + Environment.NewLine);
                    else
                        first = false;

                    sb.Append(Indent(3));
                    if (prop.DbBindColumn.DataType.ToString() == "StringFixedLength")
                    {
                        sb.Append("RTRIM(");
                        sb.Append("[" + GetCorrelationName(prop) + "].[" + prop.DbBindColumn.ColumnName + "]" +
                                  ")");
                        sb.Append(String.Format(" AS [{0}]", prop.ParameterName));
                    }
                    else
                    {
                        sb.Append("[" + GetCorrelationName(prop) + "].[" + prop.DbBindColumn.ColumnName + "]");
                        if (prop.DbBindColumn.ColumnName != prop.ParameterName)
                        {
                            sb.Append(String.Format(" AS [{0}]", prop.ParameterName));
                        }
                    }

                }
            }
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }

        private static string GetAliasedFieldString(DbBindColumn col)
        {
            return "[" + col.ObjectName + "].[" + col.ColumnName + "]";
        }

        public static string GetAliasedFieldString(IResultObject table, IColumnInfo col)
        {
            return "[" + table.ObjectName + "].[" + col.ColumnName + "]";
        }

        public static ValueProperty GetValuePropertyByName(CslaObjectInfo info, string propName)
        {
            var prop = info.ValueProperties.Find(propName);
            if (prop == null)
                prop = info.InheritedValueProperties.Find(propName);

            // check itemType to see if this is collection
            if (prop == null && info.ItemType != String.Empty)
            {
                var itemInfo = info.Parent.CslaObjects.Find(info.ItemType);
                if (itemInfo != null)
                    prop = GetValuePropertyByName(itemInfo, propName);
            }

            return prop;
        }

        private string GetWhereClause(CslaObjectInfo info, Criteria crit, bool includeParentObjects)
        {
            var originalInfo = info;
            var parentInfo = FindParent(info);
            if (parentInfo != null)
            {
                var temp = parentInfo;
                while (temp != null)
                {
                    temp = FindParent(temp);
                    if (temp != null) { parentInfo = temp; }
                }
                info = parentInfo;
            }

            var chidParamDBC = new List<DbBindColumn>();
            if (includeParentObjects)
            {
                var collType = info.Parent.CslaObjects.Find(originalInfo.ParentType);
                foreach (var childCrit in collType.CriteriaObjects)
                {
                    if (crit.GetOptions.Procedure && crit.GetOptions.ProcedureName != string.Empty)
                    {
                        foreach (var param in childCrit.Properties)
                        {
                            chidParamDBC.Add(param.DbBindColumn);
                        }
                    }
                }
            }

            var sb = new StringBuilder();
            var first = true;
            var parmCounter = 0;
            foreach (var parm in crit.Properties)
            {
                parmCounter++;
                var dbc = parm.DbBindColumn;
                if (dbc == null || dbc.Column == null)
                {
                    var prop = GetValuePropertyByName(info, parm.Name);
                    if (prop != null)
                        dbc = prop.DbBindColumn;
                }
                if (dbc != null && dbc.Column != null)
                {
                    if (first)
                    {
                        sb.Append(Indent(2) + "WHERE" + Environment.NewLine);
                        first = false;
                    }
                    else
                        sb.Append(" AND" + Environment.NewLine);

                    if (includeParentObjects && chidParamDBC.Count >= parmCounter)
                        sb.Append(Indent(3) + GetAliasedFieldString(chidParamDBC[parmCounter - 1]));
                    else
                        sb.Append(Indent(3) + GetAliasedFieldString(dbc));

                    sb.Append(" = @");
                    sb.Append(parm.ParameterName);
                }
            }
            sb.Append(SoftDeleteWhereClause(originalInfo, crit, first));
            return sb.ToString();
        }

        private string GetSearchWhereClause(CslaObjectInfo info, CslaObjectInfo originalInfo, Criteria crit)
        {
            var sb = new StringBuilder();
            var first = true;
            foreach (CriteriaProperty parm in crit.Properties)
            {
                var dbc = parm.DbBindColumn;
                if (dbc == null)
                {
                    var prop = GetValuePropertyByName(info, parm.Name);
                    dbc = prop.DbBindColumn;
                }
                if (dbc != null)
                {
                    if (first)
                    {
                        sb.Append(Indent(2) + "WHERE" + Environment.NewLine);
                        first = false;
                    }
                    else
                        sb.Append(" AND" + Environment.NewLine);

                    sb.Append(Indent(3));

                    if (!parm.Nullable)
                    {
                        sb.Append(GetAliasedFieldString(dbc));
                        sb.Append(" = @");
                        sb.Append(parm.ParameterName);
                    }
                    else
                    {
                        if (IsStringType(dbc.DataType))
                        {
                            sb.Append("ISNULL(");
                            sb.Append(GetAliasedFieldString(dbc));
                            sb.Append(", '')");
                            if (dbc.DataType.ToString() == "StringFixedLength")
                            {
                                sb.Append(" LIKE RTRIM(@");
                                sb.Append(parm.ParameterName);
                                sb.Append(")");
                            }
                            else
                            {
                                sb.Append(" LIKE @");
                                sb.Append(parm.ParameterName);
                            }
                        }
                        else
                        {
                            sb.Append(GetAliasedFieldString(dbc));
                            sb.Append(" = ISNULL(@");
                            sb.Append(parm.ParameterName);
                            sb.Append(", ");
                            sb.Append(GetAliasedFieldString(dbc));
                            sb.Append(")");
                        }
                    }
                }
            }
            sb.Append(SoftDeleteWhereClause(originalInfo, crit, first));
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }

        #endregion

        #region Tables

        public List<IResultObject> GetTablesSelect(CslaObjectInfo info)
        {
            var tables = new List<IResultObject>();
            var allValueProps = new ValuePropertyCollection();

            if (!IsCollectionType(info.ObjectType))
                allValueProps = info.GetAllValueProperties();
            else
            {
                var item = info.Parent.CslaObjects.Find(info.ItemType);
                allValueProps = item.GetAllValueProperties();
            }

            foreach (var prop in allValueProps)
            {
                if (prop.DbBindColumn.Column == null)
                    continue;

                if ((prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly ||
                     prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default) &&
                    (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table ||
                    prop.DbBindColumn.ColumnOriginType == ColumnOriginType.View))
                {
                    var table = (IResultObject) prop.DbBindColumn.DatabaseObject;
                    if (!tables.Contains(table))
                        tables.Add(table);
                }
            }
            return tables;
        }

        // patch for using SProcs as source of RO/NVL
        public string GetSprocSchemaSelect(CslaObjectInfo info)
        {
            var result = string.Empty;

            var tables = new List<IResultObject>();
            var allValueProps = new ValuePropertyCollection();

            if (!IsCollectionType(info.ObjectType))
                allValueProps = info.GetAllValueProperties();
            else
            {
                var item = info.Parent.CslaObjects.Find(info.ItemType);
                allValueProps = item.GetAllValueProperties();
            }

            foreach (var prop in allValueProps)
            {
                if (prop.DbBindColumn.Column == null)
                    continue;

                result = prop.DbBindColumn.SchemaName;
                break;
            }
            return result;
        }

        public List<IResultObject> GetTablesInsert(CslaObjectInfo info)
        {
            var tables = new List<IResultObject>();
            foreach (var prop in info.GetAllValueProperties())
            {
                if (prop.DbBindColumn.Column == null)
                    continue;

                if (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
                    prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly &&
                    prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table)
                {
                    var table = (IResultObject)prop.DbBindColumn.DatabaseObject;
                    if (!tables.Contains(table))
                    {
                        tables.Add(table);
                    }
                }
            }
            return tables;
        }

        public List<IResultObject> GetTablesUpdate(CslaObjectInfo info)
        {
            var tables = new List<IResultObject>();
            foreach (var prop in info.GetAllValueProperties())
            {
                if (prop.DbBindColumn.Column == null)
                    continue;

                if (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
                    prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly &&
                    prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table)
                {
                    var table = (IResultObject)prop.DbBindColumn.DatabaseObject;
                    if (!tables.Contains(table))
                        tables.Add(table);
                }
            }
            return tables;
        }

        public List<IResultObject> GetTablesDelete(CslaObjectInfo info)
        {
            var tablesCol = new List<IResultObject>();
            foreach (var prop in info.GetAllValueProperties())
            {
                if (prop.DbBindColumn.Column == null)
                    continue;

                if (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
                    prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table)
                {
                    var table = (IResultObject)prop.DbBindColumn.DatabaseObject;
                    if (!tablesCol.Contains(table))
                        tablesCol.Add(table);
                }
            }
            return tablesCol;
        }

        private static List<IResultObject> GetTables(Criteria crit)
        {
            var tablesCol = new List<IResultObject>();
            foreach (var parm in crit.Properties)
            {
                if (parm.DbBindColumn.ColumnOriginType == ColumnOriginType.Table ||
                    parm.DbBindColumn.ColumnOriginType == ColumnOriginType.View)
                {
                    var table = (IResultObject)parm.DbBindColumn.DatabaseObject;
                    if (table != null && !tablesCol.Contains(table))
                        tablesCol.Add(table);
                }
            }
            return tablesCol;
        }

        public static List<IResultObject> GetTablesParent(Criteria crit, CslaObjectInfo info)
        {
            var tablesCol = new List<IResultObject>();
            var parent = FindParent(info);
            if (parent != null)
                tablesCol.AddRange(GetTables(crit, parent, true));

            return tablesCol;
        }

        public static List<IResultObject> GetTables(Criteria crit, CslaObjectInfo info, bool includeParentObjects)
        {
            return GetTables(crit, info, includeParentObjects, true);
        }

        public static List<IResultObject> GetTables(Criteria crit, CslaObjectInfo info, bool includeParentObjects, bool includeCriteria)
        {
            return GetTables(crit, info, includeParentObjects, includeCriteria, true);
        }

        public static List<IResultObject> GetTables(Criteria crit, CslaObjectInfo info, bool includeParentObjects, bool includeCriteria, bool includeAllValueProperties)
        {
            var tablesCol = new List<IResultObject>();
            if (includeParentObjects)
            {
                var parent = FindParent(info);
                if (parent != null)
                    tablesCol.AddRange(GetTables(crit, parent, true, includeCriteria, includeAllValueProperties));
            }

            foreach (var prop in info.GetAllValueProperties())
            {
                if (prop.DbBindColumn.Column == null)
                    continue;

                if (includeAllValueProperties)
                {
                    if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table ||
                        prop.DbBindColumn.ColumnOriginType == ColumnOriginType.View)
                    {
                        var table = (IResultObject) prop.DbBindColumn.DatabaseObject;
                        if (!tablesCol.Contains(table))
                            tablesCol.Add(table);
                    }
                }
                else
                {
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                    {
                        var table = (IResultObject) prop.DbBindColumn.DatabaseObject;
                        if (!tablesCol.Contains(table))
                            tablesCol.Add(table);
                    }
                }
            }

            if (includeCriteria)
            {
                foreach (var table in GetTables(crit))
                {
                    if (!tablesCol.Contains(table))
                        tablesCol.Add(table);
                }
            }
            return tablesCol;
        }

        public List<IResultObject> GetTablesParentProperties(Criteria crit, CslaObjectInfo childInfo, CslaObjectInfo topObjectInfo, bool parentFound)
        {
            return GetTablesParentProperties(crit, childInfo, topObjectInfo, parentFound, false);
        }

        public List<IResultObject> GetTablesParentProperties(Criteria crit, CslaObjectInfo childInfo, CslaObjectInfo topObjectInfo, bool parentFound, bool excludeCriteria)
        {
            var isRootOrRootItem = CslaTemplateHelperCS.IsRootOrRootItem(childInfo);
            var parentInsertOnly = false;
            if (CslaTemplateHelperCS.CanHaveParentProperties(childInfo))
                parentInsertOnly = childInfo.ParentInsertOnly;

            var tablesCol = new List<IResultObject>();

            if (!parentFound)
            {
                var parentInfo = FindParent(childInfo);
                if (parentInfo != null)
                {
                    tablesCol.AddRange(GetTablesParentProperties(crit, parentInfo, topObjectInfo, parentInfo == topObjectInfo));
                }

                if (!isRootOrRootItem)
                {
                    parentInfo = topObjectInfo.Parent.CslaObjects.Find(topObjectInfo.ParentType);
                    if (parentInfo != null)
                        isRootOrRootItem = CslaTemplateHelperCS.IsRootType(parentInfo);
                }
            }

            foreach (var prop in childInfo.GetAllValueProperties())
            {
                if (prop.DbBindColumn.Column == null)
                    continue;

                if (parentInsertOnly && prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.Default)
                    continue;

                if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table ||
                    prop.DbBindColumn.ColumnOriginType == ColumnOriginType.View)
                {
                    var table = (IResultObject) prop.DbBindColumn.DatabaseObject;
                    if (parentInsertOnly || isRootOrRootItem)
                    {
                        if (!tablesCol.Contains(table))
                            tablesCol.Add(table);
                    }
                    else
                    {
                        foreach (var parentProp in childInfo.GetParentValueProperties())
                        {
                            if (parentProp.DbBindColumn.Column == null)
                                continue;

                            if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table &&
                                parentProp.DbBindColumn.ColumnOriginType == ColumnOriginType.Table)
                            {
                                table = GetFKTableObjectForParentProperty(parentProp, table);
                                if (table != null)
                                    if (!tablesCol.Contains(table))
                                        tablesCol.Add(table);
                            }
                        }
                    }
                }
            }

            if (!excludeCriteria)
            {
                foreach (var table in GetTables(crit))
                {
                    if (!tablesCol.Contains(table))
                        tablesCol.Add(table);
                }
            }

            return tablesCol;
        }

        public void SortTables(List<IResultObject> tables)
        {
            var tArray = tables.ToArray();

            //Sort collection so that tables that reference others come after reference tables
            for (var i = 0; i < tArray.Length - 1; i++)
            {
                var fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(tArray[i]);
                if (fKeys.Count > 0)
                {
                    for (var j = i + 1; j < tArray.Length; j++)
                    {
                        var table = tArray[i];
                        if (!ReferencesTable(fKeys, tArray[j]))
                        {
                            tArray[i] = tArray[j];
                            tArray[j] = table;
                        }
                    }
                }
            }
            tables.Clear();
            tables.AddRange(tArray);
        }

        public static void SortKeys(List<IForeignKeyConstraint> fKeys, List<IResultObject> parentTables)
        {
            if (parentTables.Count == 0)
                return;

            var sorted = false;
            var parentTable = parentTables[0].ObjectName;
            var fkArray = fKeys.ToArray();

            // sort collection so that keys that reference the parent table come before other keys
            for (var i = 0; i < fkArray.Length; i++)
            {
                if (parentTable == fkArray[i].PKTable.ObjectName)
                {
                    var fkey = fkArray[i];

                    for (var j = i; j > 0; j--)
                    {
                        fkArray[j] = fkArray[j- 1];
                    }
                    fkArray[0] = fkey;
                    sorted = true;
                }
            }

            if (sorted)
            {
                fKeys.Clear();
                fKeys.AddRange(fkArray);
            }

            // sort collection so that Primary Keys that reference the parent table come before other non-primary keys
            sorted = false;
            for (var i = 0; i < fkArray.Length; i++)
            {
                if (parentTable == fkArray[i].PKTable.ObjectName && fkArray[i].Columns[0].PKColumn.IsPrimaryKey)
                {
                    var fkey = fkArray[i];
                    for (var j = i; j > 0; j--)
                    {
                        fkArray[j] = fkArray[j- 1];
                    }
                    fkArray[0] = fkey;
                    sorted = true;
                }
            }

            if (sorted)
            {
                fKeys.Clear();
                fKeys.AddRange(fkArray);
            }
        }

/*
        // debugging only
        private void ShowKeys(string header, List<IForeignKeyConstraint> fKeys1, List<IForeignKeyConstraint> fKeys2)
        {
            var msg = "Original\r\n";
            foreach (var fKey in fKeys1)
            {
                msg += fKey.ConstraintName + ": ";
                msg += fKey.ConstraintTable.ObjectName + " - ";
                msg += fKey.Columns[0].FKColumn.ColumnName+ " / ";
                msg += fKey.PKTable.ObjectName + " - ";
                msg += fKey.Columns[0].PKColumn.ColumnName + Environment.NewLine;
            }
            msg += "\r\nRefactored\r\n";
            foreach (var fKey in fKeys2)
            {
                msg += fKey.ConstraintName + ": ";
                msg += fKey.ConstraintTable.ObjectName + " - ";
                msg += fKey.Columns[0].FKColumn.ColumnName+ " / ";
                msg += fKey.PKTable.ObjectName + " - ";
                msg += fKey.Columns[0].PKColumn.ColumnName + Environment.NewLine;
            }
            MessageBox.Show(msg, header);
        }
*/

        public static List<IForeignKeyConstraint> FilterDuplicateConstraintTables(List<IForeignKeyConstraint> fKeys, ValuePropertyCollection vpc)
        {
            var filteredKeys = new List<IForeignKeyConstraint>();
            if (fKeys.Count == 0)
                return filteredKeys;

            var fkArray = fKeys.ToArray();

            // filter constraint table references not included by ValueProperty.FKConstraint
            foreach (var key in fkArray)
            {
                var match = false;
                foreach (var vp in vpc)
                {
                    if (vp.FKConstraint == key.ConstraintName)
                    {
                        match = true;
                        break;
                    }
                }
                if (match)
                    filteredKeys.Add(key);
            }

            // filter duplicate references to the same constraint table
            foreach (var t in fkArray)
            {
                var exists = false;
                foreach (var key in filteredKeys)
                {
                    if (t.ConstraintTable.ObjectName == key.ConstraintTable.ObjectName &&
                        t.PKTable.ObjectName == key.PKTable.ObjectName)
                        exists = true;
                }
                if (!exists)
                    filteredKeys.Add(t);
            }

            return filteredKeys;
        }

        private static bool ReferencesTable(List<IForeignKeyConstraint> constraints, IResultObject pkTable)
        {
            foreach (var fkc in constraints)
            {
                if (fkc.PKTable == pkTable)
                    return true;
            }
            return false;
        }

        public void CheckTableJoins(List<IResultObject> tables)
        {
            if (tables.Count < 2) { return; }

            var tablesMissingJoins = new List<IResultObject>();
            foreach (var t in tables)
            {
                if (!HasJoin(t, tables))
                    tablesMissingJoins.Add(t);
            }

            if (tablesMissingJoins.Count > 0)
                AddJoinTables(tables, tablesMissingJoins);
        }

        private void AddJoinTables(List<IResultObject> tables, List<IResultObject> tablesMissingJoins)
        {
            var joinTables = FindJoinTables(tables, tablesMissingJoins);
            foreach (var t in joinTables)
            {
                if (!tables.Contains(t))
                    tables.Add(t);
            }
        }

        private List<IResultObject> FindJoinTables(List<IResultObject> tables, List<IResultObject> missingTables)
        {
            var joinTables = new List<IResultObject>();
            foreach(var t in Catalog.Tables)
            {
                var fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(t);
                if (fKeys.Count > 1)
                {
                    var tableCount = 0;
                    var missingTableCount = 0;
                    foreach(var key in  fKeys)
                    {
                        if (missingTables.Contains(key.PKTable))
                            missingTableCount++;
                        else if (tables.Contains(key.PKTable))
                            tableCount++;
                    }
                    if (missingTableCount > 1 || (tableCount > 0 && missingTableCount > 0))
                    {
                        joinTables.Add(t);
                    }
                }
            }
            return joinTables;
        }

        private bool HasJoin(IResultObject table, List<IResultObject> tables)
        {
            foreach (var key in Catalog.ForeignKeyConstraints.GetConstraintsFor(table))
            {
                if (tables.Contains(key.PKTable))
                    return true;
            }

            foreach (var t in tables)
            {
                if (t != table)
                {
                    foreach (var key in Catalog.ForeignKeyConstraints.GetConstraintsFor(t))
                    {
                        if (key.PKTable == table)
                            return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region Helpers

        public bool IsCollectionType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRootCollection ||
                cslaType == CslaObjectType.EditableChildCollection ||
                cslaType == CslaObjectType.DynamicEditableRootCollection ||
                cslaType == CslaObjectType.ReadOnlyCollection)
                return true;

            return false;
        }

        public CslaObjectInfo FindChildInfo(CslaObjectInfo info, string name)
        {
            return info.Parent.CslaObjects.Find(name);
        }

        private static CslaObjectInfo FindParent(CslaObjectInfo info)
        {
            CslaObjectInfo parentInfo = null;
            if (string.IsNullOrEmpty(info.ParentType))
            {
                foreach (var cslaObject in info.Parent.CslaObjects)
                {
                    foreach (var childProperty in cslaObject.GetAllChildProperties())
                    {
                        if (childProperty.TypeName == info.ObjectName)
                            parentInfo = cslaObject;
                    }
                    if (parentInfo != null)
                        break;
                }
            }
            else
            {
                // no parent specified; find the object whose child is this object
                parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
            }

            if (parentInfo != null)
            {
                if (parentInfo.ItemType == info.ObjectName)
                    return FindParent(parentInfo);

                if (parentInfo.GetAllChildProperties().FindType(info.ObjectName) != null)
                    return parentInfo;

                /*if (parentInfo.GetCollectionChildProperties().FindType(info.ObjectName) != null)
                    return parentInfo;*/
            }

            return null;
        }

        /// <summary>
        /// Gets all child objects of a CslaObjectInfo.
        /// Gets all child properties: collection and non-collection, including inherited.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A CslaObjectInfo array holding the objects for all child properties.</returns>
        public CslaObjectInfo[] GetAllChildItems(CslaObjectInfo info)
        {
            var list = new List<CslaObjectInfo>();
            foreach (var cp in info.GetAllChildProperties())
            {
                var childInfo = FindChildInfo(info, cp.TypeName);
                if (IsCollectionType(childInfo.ObjectType))
                {
                    var ci = FindChildInfo(info, cp.TypeName);
                    if (ci != null)
                    {
                        ci = FindChildInfo(info, ci.ItemType);
                        if (ci != null)
                            list.Add(ci);
                    }
                }
                else
                {
                    list.Add(childInfo);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets the full hierarchy of all child object names of a CslaObjectInfo.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A string array holding the objects for the hierarchy of all child properties.</returns>
        public string[] GetAllChildItemsInHierarchy(CslaObjectInfo info)
        {
            var list = new List<string>();
            foreach (var obj in GetAllChildItems(info))
            {
                list.Add(obj.ObjectName);
                list.AddRange(GetAllChildItemsInHierarchy(obj));
            }
            return list.ToArray();
        }

        public bool IsStringType(DbType dbType)
        {
            if (dbType == DbType.String || dbType == DbType.StringFixedLength ||
                dbType == DbType.AnsiString || dbType == DbType.AnsiStringFixedLength)
                return true;

            return false;
        }

        public static string Indent(int len)
        {
            return new string(' ', len * 4);
        }

        public string GetFKColumnForParentProperty(ValueProperty parentProp, IResultObject childTable)
        {
            if (parentProp.DbBindColumn.ColumnOriginType != ColumnOriginType.Table)
                return parentProp.ParameterName;

            var fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(childTable);
            foreach (var tks in fKeys)
            {
                if (tks.PKTable == parentProp.DbBindColumn.DatabaseObject)
                {
                    foreach (var colPair in tks.Columns)
                    {
                        if (colPair.PKColumn == parentProp.DbBindColumn.Column)
                            return colPair.FKColumn.ColumnName;
                    }
                }
            }

            return string.Empty;
        }

        public string GetFKTableForParentProperty(ValueProperty parentProp, IResultObject childTable)
        {
            if (parentProp.DbBindColumn.ColumnOriginType != ColumnOriginType.Table)
                return parentProp.ParameterName;

            var fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(childTable);
            foreach (var fKey in fKeys)
            {
                if (fKey.PKTable == parentProp.DbBindColumn.DatabaseObject)
                {
                    foreach (var colPair in fKey.Columns)
                    {
                        if (colPair.PKColumn == parentProp.DbBindColumn.Column)
                            return colPair.FKColumn.FKConstraint.ConstraintTable.ObjectName;
                    }
                }
            }

            return string.Empty;
        }

        public IResultObject GetFKTableObjectForParentProperty(ValueProperty parentProp, IResultObject childTable)
        {
            if (parentProp.DbBindColumn.ColumnOriginType != ColumnOriginType.Table)
                return null;

            var fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(childTable);
            foreach (var fKey in fKeys)
            {
                if (fKey.PKTable == parentProp.DbBindColumn.DatabaseObject)
                {
                    foreach (var colPair in fKey.Columns)
                    {
                        if (colPair.PKColumn == parentProp.DbBindColumn.Column)
                            return colPair.FKColumn.FKConstraint.ConstraintTable;
                    }
                }
            }

            return null;
        }

        public static bool IsChildSelfLoaded(CslaObjectInfo info)
        {
            var selfLoad = false;
            var parent = info.Parent.CslaObjects.Find(info.ParentType);
            if (parent != null)
            {
                foreach (var childProp in parent.GetAllChildProperties())
                {
                    if (childProp.TypeName == info.ObjectName)
                    {
                        selfLoad = childProp.LoadingScheme == LoadingScheme.SelfLoad;
                        break;
                    }
                }
            }

            return selfLoad;
        }

        #endregion

        #region SoftDelete methods

        private bool IgnoreFilterCriteria(Criteria crit)
        {
            foreach (var prop in crit.Properties)
            {
                if(prop.DbBindColumn.ColumnName == Info.Parent.Params.SpBoolSoftDeleteColumn &&
                    prop.DbBindColumn.Column.DbType == DbType.Boolean)
                    return true;

                if(prop.DbBindColumn.ColumnName == Info.Parent.Params.SpIntSoftDeleteColumn &&
                    (prop.DbBindColumn.Column.DbType == DbType.Int16 ||
                     prop.DbBindColumn.Column.DbType == DbType.Int32 ||
                     prop.DbBindColumn.Column.DbType == DbType.Int64))
                    return true;
            }

            return false;
        }

        private string SoftDeleteWhereClause(CslaObjectInfo info, Criteria crit, bool first)
        {
            if (IgnoreFilterCriteria(crit))
                return "";

            var sb = new StringBuilder();
            List<IResultObject> tablesCol;

            if (CslaTemplateHelperCS.CanHaveParentProperties(info) && !info.ParentInsertOnly)
                tablesCol = GetTablesParentProperties(crit, info, info, true, true);
            else
                tablesCol = GetTables(crit, info, false, false, false);

            SortTables(tablesCol);
            CheckTableJoins(tablesCol);

            foreach (var table in tablesCol)
            {
                sb.Append(AppendSoftDeleteWhereClause(info, table, first));
                first = false;
            }

            return sb.ToString();
        }

        private string AppendSoftDeleteWhereClause(CslaObjectInfo info, IResultObject table, bool first)
        {
            var sb = new StringBuilder();
            if (UseBoolSoftDelete(table, IgnoreFilter(info)))
            {
                if (!first)
                    sb.Append(" AND" + Environment.NewLine);
                else
                {
                    sb.Append(Indent(2) + "WHERE" + Environment.NewLine);
                }
                sb.Append(Indent(3));
                sb.Append("[" + table.ObjectName + "].[" + Info.Parent.Params.SpBoolSoftDeleteColumn + "] = 'true'");
            }

            return sb.ToString();
        }

        public bool IgnoreFilter(CslaObjectInfo info)
        {
            if (Info.Parent.Params.SpIgnoreFilterWhenSoftDeleteIsParam)
            {
                foreach (var prop in info.GetAllValueProperties())
                {
                    if (prop.DbBindColumn.Column == null)
                        continue;

                    if (prop.Name == Info.Parent.Params.SpBoolSoftDeleteColumn)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Uses the bool soft delete.
        /// </summary>
        /// <param name="tables">The tables to check.</param>
        /// <param name="ignoreFilterEnabled">if set to <c>true</c> [ignore filter enabled].</param>
        /// <returns></returns>
        public bool UseBoolSoftDelete(List<IResultObject> tables, bool ignoreFilterEnabled)
        {
            if (!string.IsNullOrEmpty(Info.Parent.Params.SpBoolSoftDeleteColumn)
                && !ignoreFilterEnabled)
            {
                foreach (var table in tables)
                {
                    if (!UseBoolSoftDelete(table, ignoreFilterEnabled))
                        return false;
                }
                return true;
            }

            return false;
        }

        private bool UseBoolSoftDelete(IResultObject table, bool ignoreFilterEnabled)
        {
            if (!string.IsNullOrEmpty(Info.Parent.Params.SpBoolSoftDeleteColumn)
                && !ignoreFilterEnabled)
            {
                for (var col = 0; col < table.Columns.Count; col++)
                {
                    if (table.Columns[col].ColumnName == Info.Parent.Params.SpBoolSoftDeleteColumn &&
                        table.Columns[col].DbType == DbType.Boolean)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool UseIntSoftDelete(List<IResultObject> tables, bool ignoreFilterEnabled)
        {
            if (!string.IsNullOrEmpty(Info.Parent.Params.SpIntSoftDeleteColumn)
                && !ignoreFilterEnabled)
            {
                foreach (var table in tables)
                {
                    if (!UseIntSoftDelete(table))
                        return false;
                }
                return true;
            }

            return false;
        }

        private bool UseIntSoftDelete(IResultObject table)
        {
            for (var col = 0; col < table.Columns.Count; col++)
            {
                if (table.Columns[col].ColumnName == Info.Parent.Params.SpIntSoftDeleteColumn &&
                    (table.Columns[col].DbType == DbType.Int16 ||
                     table.Columns[col].DbType == DbType.Int32 ||
                     table.Columns[col].DbType == DbType.Int64))
                    return true;
            }

            return false;
        }

        #endregion
    }
}
