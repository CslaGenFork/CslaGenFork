using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CslaGenerator.Metadata;
//using SchemaExplorer;
using DBSchemaInfo.Base;
using CodeSmith.Engine;
namespace CslaGenerator.Util
{
    /// <summary>
    /// Summary description for SprocTemplateHelper.
    /// </summary>
    public class SprocTemplateHelper : CodeTemplate
    {
        public SprocTemplateHelper()
        {
        }
        private ICatalog _catalog = GeneratorController.Catalog;
        [Browsable(false)]
        public ICatalog Catalog
        {
            get
            {
                return _catalog;
            }
        }
        private CslaObjectInfo _Info;
        public CslaObjectInfo Info
        {
            get
            {
                return _Info;
            }
            set
            {
                _Info = value;
            }
        }
        private bool _IncludeParentProperties=false;
        public bool IncludeParentProperties
        {
            get
            {
                return _IncludeParentProperties;
            }
            set
            {
                _IncludeParentProperties = value;
            }
        }

        private Criteria _Criteria=new Criteria();
        private bool _CriteriaDefined = false;
        protected bool CriteriaDefined
        {
            get
            {
                return _CriteriaDefined;
            }

        }
        public Criteria Criteria
        {
            get
            {
                return _Criteria;
            }
            set
            {
                _Criteria = value;
                _CriteriaDefined = true;
            }
        }

        //private DatabaseSchema _schema1 = null;
        private CslaObjectInfo _topLevelObject = null;

        public struct duplicateTables
        {
            public string PropertyName;
            public string TableName;
            public string ColumnName;
            public int Order;
        }

        public List<duplicateTables> correlationNames = new List<duplicateTables>();

        //[Browsable(false)]
        //public DatabaseSchema Schema1
        //{
        //    get        //    {
        //        return _schema1;
        //    }
        //}

        public void Init(CslaObjectInfo info)

        {
            //_schema = GetSchema(info);
                       _topLevelObject = info;
        }

        public void StoreCorrelationNames(CslaObjectInfo info)
        {
            correlationNames.Clear();
            duplicateTables readCorr;
            duplicateTables writeCorr = new duplicateTables();
            ValuePropertyCollection vpc = new ValuePropertyCollection();
            vpc.AddRange(info.GetAllValueProperties());
            for (int vp = 0; vp < vpc.Count; vp++)
            {
                int count = 1;
                for (int prop = 0; prop < vp; prop++)
                {
                    readCorr = correlationNames[prop];
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
                correlationNames.Add(writeCorr);
            }
        }

        public string GetCorrelationName(ValueProperty prop)
        {
            foreach (duplicateTables correlationName in correlationNames)
            {
                if (correlationName.PropertyName == prop.Name)
                {
                    if (correlationName.Order > 1)
                        return correlationName.TableName + correlationName.Order;
                    else
                        return correlationName.TableName;
                }
            }
            MessageBox.Show("Property " + prop.Name + " not found.", "Error!");
            return "";
        }

        public string GetDataTypeString(CslaObjectInfo info, string propName)
        {
            ValueProperty prop = GetValuePropertyByName(info,propName);
            if (prop == null) { throw new Exception("Parameter '" + propName + "' does not have a corresponding ValueProperty. Make sure a ValueProperty with the same name exists"); }

            if (prop.DbBindColumn == null) { throw new Exception("Property '" + propName + "' does not have it's DbBindColumn initialized."); }

            return GetDataTypeString(prop.DbBindColumn);
        }

        public string GetDataTypeString(CriteriaProperty col)
        {
            if (col.DbBindColumn.Column != null)
                return GetDataTypeString(col.DbBindColumn);
            ValueProperty prop = Info.ValueProperties.Find(col.Name);
            if (prop != null)
                return GetDataTypeString(prop.DbBindColumn);
            throw new ApplicationException("No column information for this criteria property: " + col.Name);
        }

        public string GetDataTypeString(DbBindColumn col)
        {
            string nativeType = col.NativeType.ToLower();
            StringBuilder sb = new StringBuilder();
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
            {
                sb.Append(col.NativeType);
            }
            return sb.ToString();
        }

        public string GetColumnString(CriteriaProperty col)
        {
            if (col.DbBindColumn.Column != null)
                return GetColumnString(col.DbBindColumn);
            ValueProperty prop = Info.ValueProperties.Find(col.Name);
            if (prop != null)
                return GetColumnString(prop.DbBindColumn);
            throw new ApplicationException("No column information for this criteria property: " + col.Name);

        }
        public string GetColumnString(DbBindColumn col)
        {
            return col.ColumnName;
            //if (col.ColumnOriginType == ColumnOriginType.Table)
            //{
            //    return col.TableColumn.Name;
            //}
            //else if (col.ColumnOriginType == ColumnOriginType.View)
            //{
            //    return col.ViewColumn.Name;
            //}
            //else
            //{
            //    throw new Exception("Column value not set.");
            //}
        }

        public string GetSelect(CslaObjectInfo info, Criteria crit, bool childSelect, bool searchWhereClause)
        {
            bool collType = IsCollectionType(info.ObjectType);
            if (collType)
            {
                info = FindChildInfo(info, info.ItemType);
            }
            StoreCorrelationNames(info);
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append(Indent(2) + "/* Get " + info.ObjectName + " from table */" + Environment.NewLine);
            sb.Append(GetSelectFields(info));

            sb.Append(searchWhereClause
                          ? GetFromClause(crit, info, true)
                          : GetFromClause(crit, info, childSelect));

            sb.Append(searchWhereClause
                          ? GetSearchWhereClause(_topLevelObject, info, crit)
                          : GetWhereClause(info, crit, childSelect));

            return NormalizeNewLineAtEndOfFile(sb.ToString());
        }

        private string NormalizeNewLineAtEndOfFile(string stat)
        {
            var uni = Environment.NewLine.ToCharArray();
            stat = stat.TrimEnd(uni);
            stat = stat.TrimEnd(uni);

            return stat;
        }

        public string GetChildSelects(CslaObjectInfo info, Criteria crit, bool searchWhereClause)
        {
            bool collType = IsCollectionType(info.ObjectType);
            if (collType)
            {
                info = FindChildInfo(info, info.ItemType);
            }

            StringBuilder sb = new StringBuilder();
            var first = true;
            foreach (ChildProperty childProp in info.GetAllChildProperties())
            {
                CslaObjectInfo childInfo = FindChildInfo(info, childProp.TypeName);
                if (childInfo != null && childInfo.LazyLoad == false)
                {
                    if (!first)
                        sb.Append(Environment.NewLine);
                    else
                        first = false;

                    sb.Append(GetSelect(childInfo, crit, true, searchWhereClause));
                    sb.Append(GetChildSelects(childInfo, crit, searchWhereClause));
                }
            }

            return NormalizeNewLineAtEndOfFile(sb.ToString());
        }

        public string GetFromClause(Criteria crit, CslaObjectInfo info, bool includeParentObjects)
        {
            // check object uses FKConstraint field
            bool FKField = false;
            ValuePropertyCollection valPropColl = new ValuePropertyCollection();
            valPropColl.AddRange(info.GetAllValueProperties());
            foreach (ValueProperty valProp in valPropColl)
            {
                //if (valProp.FKConstraint != "" && valProp.FKConstraint != string.Empty)
                if (valProp.FKConstraint != string.Empty)
                {
                    FKField = true;
                    break;
                }
            }

            if (FKField)
            {
                return GetFromClauseFK(crit, info, includeParentObjects);
            }
            else
            {
                return GetFromClauseClassic(crit, info, includeParentObjects);
            }
        }

        public string GetFromClauseClassic(Criteria crit, CslaObjectInfo info, bool includeParentObjects)
        {
            List<IResultObject> tables = GetTables(crit, info, includeParentObjects);
            SortTables(tables);
            CheckTableJoins(tables);

            StringBuilder sb = new StringBuilder();
            sb.Append(Indent(2) + "FROM ");
            if (tables.Count == 1)
            {
                sb.AppendFormat("[{0}].[{1}]", tables[0].ObjectSchema, tables[0].ObjectName);
                sb.Append(Environment.NewLine);
                return sb.ToString();
            }
            else if (tables.Count > 1)
            {
                List<IResultObject> usedTables = new List<IResultObject>();
                bool first = true;
                var parentTables = GetTablesParent(crit, info);
                foreach (IResultObject table in tables)
                {
                    List<IForeignKeyConstraint> fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(table);

                    // sort key.PKTable so key.PKTable that reference the parent table come before other keys
                    // and
                    // Primary keys come before other constraint references to the parent object
                    SortKeys(fKeys, parentTables);
                    fKeys = FilterDuplicateConstraintTables(fKeys);

                    foreach (IForeignKeyConstraint key in fKeys)
                    {
                        // check if this key is needed in the join
                        if (tables.IndexOf(key.PKTable) >= 0)
                        {
                            if (key.PKTable != key.ConstraintTable)
                            {
                                if (first)
                                {
                                    sb.AppendFormat("[{0}].[{1}]", key.PKTable.ObjectSchema, key.PKTable.ObjectName);
                                    sb.Append(Environment.NewLine + Indent(3));
                                    sb.Append(" INNER JOIN ");
                                    sb.AppendFormat("[{0}].[{1}]", key.ConstraintTable.ObjectSchema, key.ConstraintTable.ObjectName);
                                    sb.Append(" ON ");
                                    bool firstCol = true;
                                    for (int i = 0; i < key.Columns.Count; i++)
                                    {
                                        if (!firstCol) { sb.Append(" AND "); }
                                        else { firstCol = false; }
                                        sb.Append(GetAliasedFieldString(key.PKTable, key.Columns[i].PKColumn));
                                        sb.Append(" = ");
                                        sb.Append(GetAliasedFieldString(key.ConstraintTable, key.Columns[i].FKColumn));
                                    }
                                    usedTables.Add(key.PKTable);
                                    usedTables.Add(key.ConstraintTable);
                                    first = false;
                                }
                                else
                                {
                                    IResultObject curTable;
                                    if (usedTables.Contains(key.ConstraintTable))
                                        curTable = key.PKTable;
                                    else
                                        curTable = key.ConstraintTable;
                                    usedTables.Add(curTable);
                                    sb.Append(Environment.NewLine + Indent(3));
                                    sb.Append(" INNER JOIN ");
                                    sb.AppendFormat("[{0}].[{1}]", curTable.ObjectSchema, curTable.ObjectName);
                                    sb.Append(" ON ");
                                    bool firstCol = true;
                                    for (int i = 0; i < key.Columns.Count; i++)
                                    {
                                        if (!firstCol) { sb.Append(" AND "); }
                                        else { firstCol = false; }
                                        sb.Append(GetAliasedFieldString(key.PKTable, key.Columns[i].PKColumn));
                                        sb.Append(" = ");
                                        sb.Append(GetAliasedFieldString(key.ConstraintTable, key.Columns[i].FKColumn));
                                    }
                                }
                            }
                        }
                    }
                }
                sb.Append(Environment.NewLine);
                return sb.ToString();
            }
            else { return String.Empty; }
        }

        public string GetFromClauseFK(Criteria crit, CslaObjectInfo info, bool includeParentObjects)
        {
            List<IResultObject> tables = GetTables(crit, info, includeParentObjects);
            SortTables(tables);
            CheckTableJoins(tables);
            IResultObject curTable = tables[0];

            StringBuilder sb = new StringBuilder();
            sb.Append(Indent(2) + "FROM ");
            if (tables.Count == 1)
            {
                sb.AppendFormat("[{0}].[{1}]", tables[0].ObjectSchema, curTable.ObjectName);
                sb.Append(Environment.NewLine);
                return sb.ToString();
            }
            else if (tables.Count > 1)
            {
                sb.AppendFormat("[{0}].[{1}]", curTable.ObjectSchema, curTable.ObjectName);
                ValuePropertyCollection vpc = new ValuePropertyCollection();
                vpc.AddRange(info.GetAllValueProperties());
                foreach (ValueProperty vp in vpc)
                {
                    if (vp.DbBindColumn.ObjectName != curTable.ObjectName)
                    {
                        List<IForeignKeyConstraint> fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(curTable);
                        foreach (IForeignKeyConstraint fKey in fKeys)
                        {
                            if (fKey.ConstraintName == vp.FKConstraint)
                            {
                                sb.Append(Environment.NewLine + Indent(3));
                                sb.Append(" INNER JOIN ");
                                sb.AppendFormat("[{0}].[{1}]", curTable.ObjectSchema, fKey.PKTable.ObjectName);
                                string corrName = GetCorrelationName(vp);
                                if (corrName != vp.DbBindColumn.ObjectName)
                                    sb.AppendFormat(" AS [{0}]", corrName);
                                sb.Append(" ON ");
                                bool firstCol = true;
                                for (int i = 0; i < fKey.Columns.Count; i++)
                                {
                                    if (!firstCol)
                                    {
                                        sb.Append(" AND ");
                                    }
                                    else
                                    {
                                        firstCol = false;
                                    }
                                    sb.AppendFormat("[{0}].[{1}]", corrName, fKey.Columns[i].PKColumn.ColumnName);
                                    sb.Append(" = ");
                                    sb.Append(GetAliasedFieldString(fKey.ConstraintTable, fKey.Columns[i].FKColumn));
                                }
                                break;
                            }
                        }
                    }
                }
                sb.Append(Environment.NewLine);
                return sb.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        public string GetSelectFields(CslaObjectInfo info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Indent(2) + "SELECT" + Environment.NewLine);
            bool first = true;
            ValuePropertyCollection vpc = new ValuePropertyCollection();
            if (IncludeParentProperties)
                vpc.AddRange(info.GetParentValueProperties());
            vpc.AddRange(info.GetAllValueProperties());
            foreach (ValueProperty prop in vpc)
            {
                if (prop.DataAccess != ValueProperty.DataAccessBehaviour.WriteOnly)
                {
                    if (!first) { sb.Append("," + Environment.NewLine); }                    else { first = false; }
                    sb.Append(Indent(3) + " ");
                    if (prop.DbBindColumn.DataType.ToString() == "StringFixedLength")
                    {
                        sb.Append("RTRIM(");
                        sb.Append("[" + GetCorrelationName(prop) + "].[" + prop.DbBindColumn.ColumnName + "]" + ")");
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

        public string GetAliasedFieldString(DbBindColumn col)
        {
            return "[" + col.ObjectName + "].[" + col.ColumnName + "]";

        }

        public string GetAliasedFieldString(IResultObject table, IColumnInfo col)
        {
            return "[" + table.ObjectName + "].[" + col.ColumnName + "]";
        }

        public string GetAliasedFieldString(ValueProperty prop)
        {
            return "[" + prop.ParameterName + "].[" + prop.DbBindColumn.ColumnName + "]";
        }

        public ValueProperty GetValuePropertyByName(CslaObjectInfo info, string propName)
        {
            ValueProperty prop = info.ValueProperties.Find(propName);
            if (prop == null)
            {
                prop = info.InheritedValueProperties.Find(propName);
            }

            // check itemType to see if this is collection
            if (prop == null && info.ItemType != String.Empty)
            {
                CslaObjectInfo itemInfo = info.Parent.CslaObjects.Find(info.ItemType);
                if (itemInfo != null)
                {
                    prop = GetValuePropertyByName(itemInfo,propName);
                }
            }
            return prop;
        }

        public string GetWhereClause(CslaObjectInfo info, Criteria crit, bool onlyChildObjects)
        {
            CslaObjectInfo originalInfo = info;

            CslaObjectInfo parentInfo = FindParent(info);
            if (parentInfo != null)
            {
                CslaObjectInfo temp = parentInfo;
                while (temp != null)
                {
                    temp = FindParent(temp);
                    if (temp != null) { parentInfo = temp; }
                }
                info = parentInfo;
            }

            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (CriteriaProperty parm in crit.Properties)
            {
                DbBindColumn dbc = parm.DbBindColumn;
                if (dbc == null || dbc.Column == null)
                {
                    ValueProperty prop = GetValuePropertyByName(info, parm.Name);
                    if (prop != null)
                    {
                        dbc = prop.DbBindColumn;
                    }
                }
                if (dbc != null && dbc.Column != null)
                {
                    if (!first) { sb.Append(" AND" + Environment.NewLine); }
                    else
                    {
                        sb.Append(Indent(2) + "WHERE" + Environment.NewLine);
                        first = false;
                    }
                    sb.Append(Indent(3) + " " + GetAliasedFieldString(dbc));
                    sb.Append(" = @");
                    sb.Append(parm.ParameterName);
                }

            }

            sb.Append(SoftDeleteWhereClause(info, originalInfo, crit, onlyChildObjects, first));
            return sb.ToString();
        }

        public string GetSearchWhereClause(CslaObjectInfo info, CslaObjectInfo originalInfo, Criteria crit)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (CriteriaProperty parm in crit.Properties)
            {
                DbBindColumn dbc = parm.DbBindColumn;
                if (dbc == null)
                {
                    ValueProperty prop = GetValuePropertyByName(info, parm.Name);
                    dbc = prop.DbBindColumn;
                }
                if (dbc != null)
                {
                    if (!first) { sb.Append(" AND" + Environment.NewLine); }
                    else
                    {
                        sb.Append(Indent(2) + "WHERE" + Environment.NewLine);
                        first = false;
                    }
                    sb.Append(Indent(3) + " ");

                    if (IsStringType(dbc.DataType))
                    {
                        sb.Append("ISNULL(");
                        sb.Append(GetAliasedFieldString(dbc));
                        sb.Append(", '')");
//                        ValueProperty prop = GetValuePropertyByName(info, parm.Name);
//                        if (prop.DbBindColumn.DataType.ToString() == "StringFixedLength")
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
            sb.Append(SoftDeleteWhereClause(info, originalInfo, crit, false, first));

            sb.Append(Environment.NewLine);
            return sb.ToString();
        }

        //public string GetOrderByClause(CslaObjectInfo topInfo, Criteria crit, string currentObjName)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(Indent(2) + "ORDER BY"  + Environment.NewLine);
        //    CslaObjectInfo info = null;
        //    if (IsCollectionType(topInfo.ObjectType))
        //    {
        //        info = FindChildInfo(info,topInfo.ItemType);
        //    }
        //    else { info = topInfo; }
        //    bool first = true;
        //    foreach (Property parm in crit.Properties)
        //    {
        //        ValueProperty prop = GetValuePropertyByName(info, parm.Name);
        //        if (prop != null)
        //        {
        //            if (!first) { sb.Append("," + Environment.NewLine); }
        //            else { first = false; }
        //            sb.Append(Indent(3) + " ");
        //            sb.Append(GetAliasedFieldString(prop.DbBindColumn));
        //        }
        //    }
        //    if (topInfo.ObjectName != currentObjName)
        //    {
        //        CslaObjectInfo childInfo = FindChildInfo(info,currentObjName);
        //        if (IsCollectionType(childInfo.ObjectType))
        //        {
        //            childInfo = FindChildInfo(info,childInfo.ItemType);
        //        }
        //        foreach (Parameter parm in childInfo.GetObjectParameters)
        //        {
        //            ValueProperty prop = GetValuePropertyByName(childInfo, parm.Property.Name);
        //            if (prop != null)
        //            {
        //                if (!first) { sb.Append("," + Environment.NewLine); }
        //                else { first = false; }
        //                sb.Append(Indent(3) + " ");
        //                sb.Append(GetAliasedFieldString(prop.DbBindColumn));
        //            }
        //        }
        //    }
        //    return sb.ToString();

        //}

        public List<IResultObject> GetTablesInsert(CslaObjectInfo info)
        {
            List<IResultObject> tables = new List<IResultObject>();
            foreach (ValueProperty prop in info.GetAllValueProperties())
            {
                if (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
                    prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly &&
                    prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table)
                {
                    IResultObject table = (IResultObject)prop.DbBindColumn.DatabaseObject;
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
            List<IResultObject> tables = new List<IResultObject>();
            foreach (ValueProperty prop in info.GetAllValueProperties())
            {
                if (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
                    prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly &&
                    prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table)
                {
                    IResultObject table = (IResultObject)prop.DbBindColumn.DatabaseObject;
                    if (!tables.Contains(table))
                    {
                        tables.Add(table);
                    }
                }
            }
            return tables;
        }

        public List<IResultObject> GetTables(Criteria crit)
        {
            List<IResultObject> tablesCol = new List<IResultObject>();
            foreach (CriteriaProperty p in crit.Properties)
            {
                if (p.DbBindColumn.ColumnOriginType == ColumnOriginType.Table ||
                    p.DbBindColumn.ColumnOriginType == ColumnOriginType.View)
                {
                    IResultObject table = (IResultObject)p.DbBindColumn.DatabaseObject;
                    if (table != null && !tablesCol.Contains(table))
                    {
                        tablesCol.Add(table);
                    }
                }
            }
            return tablesCol;
        }

        public List<IResultObject> GetTablesParent(Criteria crit, CslaObjectInfo info)
        {
            List<IResultObject> tablesCol = new List<IResultObject>();
            CslaObjectInfo parent = FindParent(info);
            if (parent != null)
            {
                tablesCol.AddRange(GetTables(crit, parent, true));
            }
            return tablesCol;
        }

        public List<IResultObject> GetTables(Criteria crit, CslaObjectInfo info, bool includeParentObjects)
        {
            List<IResultObject> tablesCol = new List<IResultObject>();
            if (includeParentObjects)
            {
                CslaObjectInfo parent = FindParent(info);
                if (parent != null)
                {
                    tablesCol.AddRange(GetTables(crit, parent, true));
                }
            }

            foreach (ValueProperty prop in info.GetAllValueProperties())
            {
                if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table ||
                    prop.DbBindColumn.ColumnOriginType == ColumnOriginType.View)
                {
                    IResultObject table = (IResultObject)prop.DbBindColumn.DatabaseObject;
                    if (!tablesCol.Contains(table))
                    {
                        tablesCol.Add(table);
                    }
                }
            }
            foreach (IResultObject table in GetTables(crit))
            {
                if (!tablesCol.Contains(table))
                    tablesCol.Add(table);
            }
            return tablesCol;
        }

        public List<IResultObject> GetTablesDelete(CslaObjectInfo info)
        {
            List<IResultObject> tablesCol = new List<IResultObject>();

            foreach (ValueProperty prop in info.GetAllValueProperties())
            {
                if (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly && prop.DbBindColumn.ColumnOriginType == ColumnOriginType.Table)
                {
                    IResultObject table = (IResultObject)prop.DbBindColumn.DatabaseObject;
                    if (!tablesCol.Contains(table))
                    {
                        tablesCol.Add(table);
                    }
                }
            }
            return tablesCol;
        }

        public void SortTables(List<IResultObject> tables)
        {
            IResultObject[] tArray = tables.ToArray();

            //Sort collection so that tables that reference others come after reference tables
            for (int i = 0; i < tArray.Length - 1; i++)
            {
                List<IForeignKeyConstraint> fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(tArray[i]);
                if (fKeys.Count > 0)
                {
                    for (int j = i + 1; j < tArray.Length; j++)
                    {
                        IResultObject table = tArray[i];
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

        public void SortKeys(List<IForeignKeyConstraint> fKeys, List<IResultObject> parentTables)
        {
            var sorted = false;

            var parentTable = parentTables[0].ObjectName;

            IForeignKeyConstraint[] fkArray = fKeys.ToArray();

            // sort collection so that keys that reference the parent table come before other keys
            for (int i = 0; i < fkArray.Length; i++)
            {
                if (parentTable == fkArray[i].PKTable.ObjectName)
                {
                    IForeignKeyConstraint fkey = fkArray[i];

                    for (int j = i; j > 0; j--)
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
            for (int i = 0; i < fkArray.Length; i++)
            {
                if (parentTable == fkArray[i].PKTable.ObjectName && fkArray[i].Columns[0].PKColumn.IsPrimaryKey)
                {
                    IForeignKeyConstraint fkey = fkArray[i];

                    for (int j = i; j > 0; j--)
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

        // The big plan is to filter everything except for:
        // - constraints that reference parent table
        // - constraints for merged tables (main object table is DocFolder, merged table is Doc for some object properties)
        // - explicit constraints sepcified in FKConstraint
        // The later constraints will be added after all the filtering
        // That's the plan...
        public List<IForeignKeyConstraint> FilterDuplicateConstraintTables(List<IForeignKeyConstraint> fKeys)
        {
            bool exists;
            var filteredKeys = new List<IForeignKeyConstraint>();
            var fkArray = fKeys.ToArray();

            filteredKeys.Add(fkArray[0]);

            // filter duplicate references to the same constraint table
            for (var i = 0; i < fkArray.Length; i++)
            {
                exists = false;
                foreach (var key in filteredKeys)
                {
                    if (fkArray[i].ConstraintTable.ObjectName == key.ConstraintTable.ObjectName &&
                        fkArray[i].PKTable.ObjectName == key.PKTable.ObjectName)
                    {
                        exists = true;
                    }
                }
                if (!exists)
                    filteredKeys.Add(fkArray[i]);
            }

            return filteredKeys;
        }

        private bool ReferencesTable(List<IForeignKeyConstraint> constraints, IResultObject pkTable)
        {
            foreach (IForeignKeyConstraint fkc in constraints)
            {
                if (fkc.PKTable == pkTable)
                    return true;
            }
            return false;
        }

        //public void SortTables(TableSchemaCollection tables)
        //{
        //    //Sort collection so that tables that reference others come after reference tables
        //    TableSchema table;
        //    bool swapped = false;
        //    int refIndex;
        //    int tableIndex;
        //    for (int i = 0; i < tables.Count; i++)
        //    {
        //        table = tables[i];
        //        if (table.ForeignKeys.Count > 0)
        //        {
        //            for (int j = 0; j < table.ForeignKeys.Count; j++)
        //            {
        //                tableIndex = i;
        //                refIndex = tables.IndexOf(table.ForeignKeys[j].ForeignKeyTable.Name);
        //                if (refIndex > tableIndex)
        //                {
        //                    RemoveInsert( tables, refIndex, tableIndex);
        //                    tableIndex++;
        //                    swapped = true;
        //                }
        //            }
        //        }
        //    }
        //    if (swapped) { SortTables(tables); }
        //}

        public void CheckTableJoins(List<IResultObject> tables)
        {
            if (tables.Count < 2) { return; }

            List<IResultObject> tablesMissingJoins = new List<IResultObject>();
            foreach (IResultObject t in tables)
            {
                if (!HasJoin(t, tables))
                {
                    tablesMissingJoins.Add(t);
                }
            }


            if (tablesMissingJoins.Count > 0)
            {
                AddJoinTables(tables, tablesMissingJoins);
            }
        }

        //public void CheckTableJoins(TableSchemaCollection tables)
        //{
        //    if (tables.Count < 2) { return; }
        //    TableSchemaCollection tablesMissingJoins = new TableSchemaCollection();
        //    foreach (TableSchema t in tables)
        //    {
        //        if (!HasJoin(t, tables))
        //        {
        //            ((IList)tablesMissingJoins).Add(t);
        //        }
        //    }
        //    if (tablesMissingJoins.Count > 0)
        //    {
        //        AddJoinTables(tables, tablesMissingJoins);
        //    }
        //}


        public void AddJoinTables(List<IResultObject> tables, List<IResultObject> tablesMissingJoins)
        {
            List<IResultObject> JoinTables = FindJoinTables(tables, tablesMissingJoins);

            foreach (IResultObject t in JoinTables)
            {
                if (!tables.Contains(t))
                {
                    tables.Add(t);
                }
            }
        }

        //public void AddJoinTables(TableSchemaCollection tables, TableSchemaCollection tablesMissingJoins)
        //{
        //    TableSchemaCollection JoinTables = FindJoinTables(tables, tablesMissingJoins);

        //    foreach(TableSchema t in JoinTables)
        //    {
        //        if (!tables.Contains(t.Name))
        //        {
        //            ((IList)tables).Add(t);
        //        }
        //    }
        //}

        public List<IResultObject> FindJoinTables(List<IResultObject> tables, List<IResultObject> missingTables)
        {
            List<IResultObject> JoinTables = new List<IResultObject>();
            foreach(IResultObject t in Catalog.Tables)
            {
                List<IForeignKeyConstraint> fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(t);
                if (fKeys.Count > 1)
                {
                    int tableCount = 0;
                    int missingTableCount = 0;
                    foreach(IForeignKeyConstraint key in  fKeys)
                    {
                        if (missingTables.Contains(key.PKTable))
                        {
                            missingTableCount++;
                        }
                        else if (tables.Contains(key.PKTable))
                        {
                            tableCount++;
                        }
                    }
                    if (missingTableCount > 1 || (tableCount > 0 && missingTableCount > 0))
                    {
                        JoinTables.Add(t);
                    }
                }
            }
            return JoinTables;
        }

        //public TableSchemaCollection FindJoinTables(TableSchemaCollection tables, TableSchemaCollection missingTables)
        //{
        //    TableSchemaCollection JoinTables = new TableSchemaCollection();
        //    foreach(TableSchema t in Schema.Tables)
        //    {
        //        if (t.ForeignKeys.Count > 1)
        //        {
        //            int tableCount = 0;
        //            int missingTableCount = 0;
        //            foreach(TableKeySchema key in  t.ForeignKeys)
        //            {
        //                if (missingTables.Contains(key.PrimaryKeyTable))
        //                {
        //                    missingTableCount++;
        //                }
        //                else if (tables.Contains(key.PrimaryKeyTable))
        //                {
        //                    tableCount++;
        //                }
        //            }
        //            if (missingTableCount > 1 || (tableCount > 0 && missingTableCount > 0))
        //            {
        //                ((IList)JoinTables).Add(t);
        //            }
        //        }
        //    }
        //    return JoinTables;
        //}

        public bool HasJoin(IResultObject table, List<IResultObject> tables)
        {
            foreach (IForeignKeyConstraint key in Catalog.ForeignKeyConstraints.GetConstraintsFor(table))
            {
                if (tables.Contains(key.PKTable))
                {
                    return true;
                }
            }
            foreach (IResultObject t in tables)
            {
                if (t != table)
                {
                    foreach (IForeignKeyConstraint key in Catalog.ForeignKeyConstraints.GetConstraintsFor(t))
                    {
                        if (key.PKTable == table)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //public bool HasJoin(TableSchema table, TableSchemaCollection tables)
        //{
        //    foreach (TableKeySchema key in table.ForeignKeys)
        //    {
        //        if (tables.Contains(key.ForeignKeyTable.Name))
        //        {
        //            return true;
        //        }
        //    }

        //    foreach (TableSchema t in tables)
        //    {
        //        if (t.Name != table.Name)
        //        {
        //            foreach (TableKeySchema key in t.ForeignKeys)
        //            {
        //                if (key.PrimaryKeyTable.Name == table.Name)
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}

        //public DatabaseSchema GetSchema(CslaObjectInfo info)
        //{
        //    return new DatabaseSchema(new SqlSchemaProvider(), info.Parent.ConnectionString);
        //}

        //public void RemoveInsert(TableSchemaCollection tables, int outOf, int into)
        //{
        //    TableSchema temp;
        //    temp = tables[outOf];
        //    if (outOf > into)
        //    {
        //        ((IList)tables).RemoveAt(outOf);
        //        ((IList)tables).Insert(into,temp);
        //    }
        //    else if (outOf < into)
        //    {
        //        ((IList)tables).Insert(into,temp);
        //        ((IList)tables).RemoveAt(outOf);
        //    }
        //}

        public CslaObjectInfo FindChildInfo(CslaObjectInfo info, string name)
        {
            return info.Parent.CslaObjects.Find(name);
        }

        public CslaObjectInfo FindParent(CslaObjectInfo childInfo)
        {
            CslaObjectInfo info = null;
            if (String.IsNullOrEmpty(childInfo.ParentType))
            {
                foreach (CslaObjectInfo o in childInfo.Parent.CslaObjects)
                {
                    foreach (ChildProperty p in o.GetAllChildProperties())
                    {
                        if (p.TypeName == childInfo.ObjectName)
                            info = o;
                    }
                    if (info != null)
                        break;
                }
            }
            else
            {
                info = childInfo.Parent.CslaObjects.Find(childInfo.ParentType);
            }
            if (info != null)
            {
                if (info.ItemType == childInfo.ObjectName)
                {
                    return FindParent(info);
                }
                else if (info.GetAllChildProperties().FindType(childInfo.ObjectName) != null)
                {
                    return info;
                }
                else if (info.GetCollectionChildProperties().FindType(childInfo.ObjectName) != null)
                {
                    return info;
                }
            }
            return null;
        }

        public bool IsStringType(DbType dbType)
        {
            if (dbType == DbType.String || dbType == DbType.StringFixedLength ||
                dbType == DbType.AnsiString || dbType == DbType.AnsiStringFixedLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCollectionType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRootCollection ||
                cslaType == CslaObjectType.EditableChildCollection ||
                cslaType == CslaObjectType.DynamicEditableRootCollection ||
                cslaType == CslaObjectType.ReadOnlyCollection )
            {
                return true;
            }
            return false;
        }

        public void Message(string msg)
        {
            MessageBox.Show(msg);
        }


        public string Indent(int len)
        {
            return new string(' ', len * 4);
        }

        public string CheckParentRelationName(ValueProperty parentProp, IResultObject childTable)
        {
            if (parentProp.DbBindColumn.ColumnOriginType != ColumnOriginType.Table)
                return parentProp.ParameterName;
            List<IForeignKeyConstraint> fKeys = Catalog.ForeignKeyConstraints.GetConstraintsFor(childTable);
            foreach (IForeignKeyConstraint tks in fKeys)
            {
                if (tks.PKTable == parentProp.DbBindColumn.DatabaseObject)// .FullName.Equals(parentProp.DbBindColumn.TableSchema.FullName))
                {
                    foreach (IForeignKeyColumnPair colPair in tks.Columns)
                    {
                        if (colPair.PKColumn == parentProp.DbBindColumn.Column)
                            return colPair.FKColumn.ColumnName;
                    }
                }
            }
            return string.Empty;
        }

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

        private string SoftDeleteWhereClause(CslaObjectInfo info, CslaObjectInfo originalInfo, Criteria crit, bool onlyChildObjects, bool first)
        {
            if (IgnoreFilterCriteria(crit))
                return "";

            var sb = new StringBuilder();
            var tables = GetTables(crit, info, false);

            // On child collections fetch, drop the check on the parent
            if (onlyChildObjects)
            {
                var originalTables = GetTables(crit, originalInfo, false);
                foreach (var originalTable in originalTables)
                {
                    var found = false;
                    foreach (var table in tables)
                    {
                        if (originalTable == table)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        sb.Append(SoftDeleteWhereClause(originalInfo, originalTable, first));
                    }
                }
            }
            else
            {
                if (tables.Count > 0)
                {
                    foreach (var table in tables)
                    {
                        sb.Append(SoftDeleteWhereClause(originalInfo, table, first));
                    }
                }
                else
                {
                    // this Select Criteria has no criteria properties
                    var childInfo = FindChildInfo(info, info.ItemType);
                    var childTables = GetTables(crit, childInfo, false);
                    foreach (var originalTable in childTables)
                    {
                        sb.Append(SoftDeleteWhereClause(originalInfo, originalTable, first));
                    }
                }
            }

            return sb.ToString();
        }

        private string SoftDeleteWhereClause(CslaObjectInfo originalInfo, IResultObject table, bool first)
        {
            var sb = new StringBuilder();
            if (UseBoolSoftDelete(table, IgnoreFilter(originalInfo)))
            {
                if (!first)
                {
                    sb.Append(" AND" + Environment.NewLine);
                }
                else
                {
                    sb.Append(Indent(2) + "WHERE" + Environment.NewLine);
                    first = false;
                }
                sb.Append(Indent(3) + " ");
                sb.Append("[" + table.ObjectName + "].[" +
                    Info.Parent.Params.SpBoolSoftDeleteColumn +
                    "] = 'true'");
            }

            return sb.ToString();
        }

        public bool IgnoreFilter(CslaObjectInfo originalInfo)
        {
            if (Info.Parent.Params.SpIgnoreFilterWhenSoftDeleteIsParam)
            {
                foreach (var prop in originalInfo.GetAllValueProperties())
                {
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
        /// <remarks>Used by templates.
        /// IgnoreFilter(originalInfo)</remarks>
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

        public bool UseBoolSoftDelete(IResultObject table, bool ignoreFilterEnabled)
        {
            if (!string.IsNullOrEmpty(Info.Parent.Params.SpBoolSoftDeleteColumn)
                && !ignoreFilterEnabled)
            {
                for (var col = 0; col < table.Columns.Count - 1; col++)
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

        public bool UseIntSoftDelete(IResultObject table)
        {
            for (var col = 0; col < table.Columns.Count - 1; col++)
            {
                if (table.Columns[col].ColumnName == Info.Parent.Params.SpIntSoftDeleteColumn &&
                    (table.Columns[col].DbType == DbType.Int16 ||
                     table.Columns[col].DbType == DbType.Int32 ||
                     table.Columns[col].DbType == DbType.Int64))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
