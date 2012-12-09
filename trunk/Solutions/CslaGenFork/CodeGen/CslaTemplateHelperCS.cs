using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CodeSmith.Engine;
using CslaGenerator.Controls;
using CslaGenerator.Metadata;
using CslaGenerator.Util;
using DBSchemaInfo.Base;

namespace CslaGenerator.CodeGen
{
    /// <summary>
    /// Summary description for CslaTemplateHelper.
    /// </summary>
    public class CslaTemplateHelperCS : CodeTemplate
    {
        protected int ResultSetCount;

        #region Public Properties

        public CslaGeneratorUnit CurrentUnit { get; set; }

        public CslaPropertyMode PropertyMode
        {
            get
            {
                var pm = CurrentUnit.GenerationParams.PropertyMode;
                if (pm == CslaPropertyMode.Default)
                    return CslaPropertyMode.Managed;

                return pm;
            }
        }

        [Browsable(false)]
        public int IndentLevel { get; set; }

        public bool DataSetLoadingScheme { get; set; }

        #endregion

        #region Basic Format and other basic stuff

        public string FormatFieldName(string name)
        {
            return CurrentUnit.Params.FieldNamePrefix + FormatCamel(name);
        }

        public string FormatDelegateName(string name)
        {
            return CurrentUnit.Params.DelegateNamePrefix + FormatCamel(name);
        }

        /// <summary>
        /// Convert a name to Camel casing (initial to lower case).
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The converted name.</returns>
        public string FormatCamel(string name)
        {
            if (name.Length == 2)
                return name.ToLower();
            if (name.Length > 0)
            {
                var sb = new StringBuilder();
                sb.Append(Char.ToLower(name[0]));
                if (name.Length > 1)
                    sb.Append(name.Substring(1));
                return sb.ToString();
            }

            return String.Empty;
        }

        public virtual string LoadProperty(ValueProperty prop, string value)
        {
            if (PropertyMode == CslaPropertyMode.Managed)
                return String.Format("LoadProperty({0}, {1});", FormatManaged(prop.Name), value);

            return String.Format("{0} = {1};", FormatFieldName(prop.Name), value);
        }

        public virtual string ReadProperty(ValueProperty prop)
        {
            if (PropertyMode == CslaPropertyMode.Managed)
                return String.Format("ReadProperty({0})", FormatManaged(prop.Name));

            return FormatFieldName(prop.Name);
        }

        public virtual string GetAttributesString(string[] attributes)
        {
            if (attributes == null || attributes.Length == 0)
                return String.Empty;

            return "[" + String.Join(", ", attributes) + "]";
        }

        /// <summary>
        /// Convert a name to Pascal casing (initial to upper case).
        /// </summary>
        /// <param name="name">The name to convert.</param>
        /// <returns>The converted name.</returns>
        public string FormatPascal(string name)
        {
            if (name.Length > 0)
            {
                var sb = new StringBuilder();
                sb.Append(Char.ToUpper(name[0]));
                if (name.Length > 1)
                    sb.Append(name.Substring(1));
                return sb.ToString();
            }

            return String.Empty;
        }

        public string FormatManaged(string name)
        {
            if (name.Length > 0)
            {
                return FormatPascal(name) + "Property";
            }

            return String.Empty;
        }

        public virtual string GetInitValue(TypeCodeEx typeCode)
        {
            if (typeCode == TypeCodeEx.Byte ||
                typeCode == TypeCodeEx.Int16 ||
                typeCode == TypeCodeEx.Int32 ||
                typeCode == TypeCodeEx.Int64 ||
                typeCode == TypeCodeEx.Double ||
                typeCode == TypeCodeEx.Decimal ||
                typeCode == TypeCodeEx.Single)
                return "0";

            if (typeCode == TypeCodeEx.String)
                return "string.Empty";

            if (typeCode == TypeCodeEx.Boolean)
                return "false";

            if (typeCode == TypeCodeEx.Object)
                return "null";

            if (typeCode == TypeCodeEx.Guid)
                return "Guid.Empty";

            if (typeCode == TypeCodeEx.SmartDate)
                return "new SmartDate(true)";

            if (typeCode == TypeCodeEx.DateTime)
                return "DateTime.Now";

            if (typeCode == TypeCodeEx.Char)
                return "char.MinValue";

            if (typeCode == TypeCodeEx.ByteArray)
                return "new byte[] {}";

            return String.Empty;
        }

        public virtual string GetInitValue(ValueProperty prop)
        {
            if (AllowNull(prop) && TypeHelper.IsNullableType(prop.PropertyType))
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetReaderAssignmentStatement(CslaObjectInfo info, ValueProperty prop)
        {
            return GetReaderAssignmentStatement(info, prop, false);
        }

        public virtual string GetReaderAssignmentStatement(CslaObjectInfo info, ValueProperty prop, bool structure)
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                if (info.DataSetLoadingScheme)
                    return GetDataSetLoaderStatement(prop);
                
                return GetDataReaderLoaderStatement(prop);
            }

            string statement;
            if (structure)
                statement = "nfo." + prop.Name + " = ";
            else
                statement = FormatFieldName(prop.Name) + " = ";

            if (info.DataSetLoadingScheme)
                statement += GetDataSetStatement(prop);
            else
                statement += GetDataReaderStatement(prop);

            return statement;
        }

        public virtual string GetDataSetStatement(ValueProperty prop)
        {
            // this is a quick hack
            var nullable = AllowNull(prop);
            var statement = String.Empty;

            if (nullable)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    statement += String.Format("!dr.IsDBNull(\"{0}\") ? new {1}(({2}) ",
                                               prop.ParameterName,
                                               GetDataType(prop),
                                               GetDataType(prop.PropertyType));
                else
                    statement += String.Format("!dr.IsDBNull(\"{0}\") ? ({1})",
                                               prop.ParameterName,
                                               GetDataType(prop));
            }

            if (prop.PropertyType == TypeCodeEx.SmartDate)
                statement += "new SmartDate((DateTime) dr";
            else
                statement += "(" + GetDataTypeGeneric(prop, prop.PropertyType) + ") dr";

            if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
                statement += GetReaderMethod(prop.PropertyType);

            statement += "[\"" + prop.ParameterName + "\"]";

            if (nullable)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    statement += ")";
                statement += " : null";
            }
            else if (prop.PropertyType == TypeCodeEx.SmartDate)
            {
                statement += ")";
            }
            else if (prop.PropertyType == TypeCodeEx.ByteArray)
                statement = statement + " as byte[]";

            return statement;
        }

        public virtual string GetDataReaderStatement(ValueProperty prop)
        {
            TypeCodeEx assignDataType;
            if (prop.BackingFieldType == TypeCodeEx.Empty)
                assignDataType = prop.PropertyType;
            else
                assignDataType = prop.BackingFieldType;

            var nullable = AllowNull(prop);
            var statement = String.Empty;

            if (nullable)
            {
                if (TypeHelper.IsNullableType(assignDataType))
                    statement += String.Format("({0})", GetDataType(prop));
                else
                    statement += String.Format("!dr.IsDBNull(\"{0}\") ? ",
                                               prop.ParameterName);
            }
            statement += "dr.";

            if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
                statement += GetReaderMethod(assignDataType);
            else
                statement += GetReaderMethod(GetDbType(prop.DbBindColumn), prop);

            statement += "(\"" + prop.ParameterName + "\"";

            if (assignDataType == TypeCodeEx.SmartDate)
                statement += ", true";

            statement += ")";
            if (nullable && !TypeHelper.IsNullableType(assignDataType))
            {
                if (TypeHelper.IsNullableType(assignDataType))
                    statement += ")";
                statement += " : null";
            }
            if (assignDataType == TypeCodeEx.ByteArray)
                statement = statement + " as byte[]";
            return statement;
        }

        public bool AllowNull(Property prop)
        {
            /*return GeneratorController.Current.CurrentUnit.GenerationParams.NullableSupport &&
                prop.Nullable &&
                prop.PropertyType != TypeCodeEx.SmartDate;*/
            return GeneratorController.Current.CurrentUnit.GenerationParams.NullableSupport &&
                prop.Nullable;
        }

        public virtual string GetParameterSet(Property prop, bool criteria)
        {
            return GetParameterSet(prop, criteria, false);
        }

        public virtual string GetParameterSet(Property prop, bool criteria, bool singleCriteria)
        {
            TypeCodeEx propType = prop.PropertyType;
            try
            {
                propType = TypeHelper.GetBackingFieldType(prop as ValueProperty);
            }
            catch (Exception) { }

            bool nullable = AllowNull(prop);
            string propName;
            if (singleCriteria)
                propName = "crit.Value";
            else if (criteria)
                propName = "crit." + FormatPascal(prop.Name);
            else
                propName = FormatFieldName(prop.Name);

            if (nullable)
            {
                if (TypeHelper.IsNullableType(propType))
                    return String.Format("{0} == null ? (object)DBNull.Value : {0}.Value", propName);

                return String.Format("{0} == null ? (object)DBNull.Value : {0}", propName);
            }

            switch (propType)
            {
                case TypeCodeEx.Guid:
                    return propName + ".Equals(Guid.Empty) ? (object)DBNull.Value : " + propName;
                default:
                    return propName;
            }
        }

        public virtual string GetParameterSet(Property prop)
        {
            return GetParameterSet(prop, false);
        }

        protected DbType GetDbType(DbBindColumn prop)
        {
            if (prop.NativeType == "real")
                return DbType.Single;

            return prop.DataType;
        }

        public virtual string GetDataType(ValueProperty prop)
        {
            var type = GetDataType(prop.PropertyType);
            if (AllowNull(prop))
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    type += "?";
            }
            return type;
        }

        public virtual string GetBackingDataType(ValueProperty prop)
        {
            var type = GetDataType(prop.BackingFieldType);
            if (AllowNull(prop))
            {
                if (TypeHelper.IsNullableType(prop.BackingFieldType))
                    type += "?";
            }
            return type;
        }

        public virtual string GetDataType(TypeCodeEx type)
        {
            if (type == TypeCodeEx.Byte)
                return "byte";

            if (type == TypeCodeEx.ByteArray)
                return "byte[]";

            if (type == TypeCodeEx.String)
                return "string";

            if (type == TypeCodeEx.Int32)
                return "int";

            if (type == TypeCodeEx.Boolean)
                return "bool";

            return type.ToString();
        }

        protected internal string GetReaderMethod(DbType dataType, ValueProperty prop)
        {
            if (prop.Nullable && TypeHelper.IsNullableType(prop.PropertyType))
                return "GetValue";

            if(prop.BackingFieldType == TypeCodeEx.Empty)
                return GetReaderMethod(dataType, prop.PropertyType);

            return GetReaderMethod(dataType, prop.BackingFieldType);
        }

        protected internal string GetReaderMethod(DbType dataType, TypeCodeEx propertyType)
        {
            switch (dataType)
            {
                case DbType.Byte:
                    return "GetByte";
                case DbType.Int16:
                    return "GetInt16";
                case DbType.Int32:
                    return "GetInt32";
                case DbType.Int64:
                    return "GetInt64";
                case DbType.AnsiStringFixedLength:
                    return "GetChar";
                case DbType.AnsiString:
                    return "GetString";
                case DbType.String:
                    return "GetString";
                case DbType.StringFixedLength:
                    return "GetString";
                case DbType.Boolean:
                    return "GetBoolean";
                case DbType.Guid:
                    return "GetGuid";
                case DbType.Currency:
                    return "GetDecimal";
                case DbType.Decimal:
                    return "GetDecimal";
                case DbType.DateTime:
                case DbType.Date:
                    return (propertyType == TypeCodeEx.SmartDate) ? "GetSmartDate" : "GetDateTime";
                case DbType.Binary:
                    return "GetValue";
                case DbType.Single:
                    return "GetFloat";
                case DbType.Double:
                    return "GetDouble";
                default:
                    return "GetValue";
            }
        }

        public string GetReaderMethod(TypeCodeEx dataType)
        {
            switch (dataType)
            {
                case TypeCodeEx.Byte:
                    return "GetByte";
                case TypeCodeEx.Int16:
                    return "GetInt16";
                case TypeCodeEx.Int32:
                    return "GetInt32";
                case TypeCodeEx.Int64:
                    return "GetInt64";
                case TypeCodeEx.String:
                    return "GetString";
                case TypeCodeEx.Boolean:
                    return "GetBoolean";
                case TypeCodeEx.Guid:
                    return "GetGuid";
                case TypeCodeEx.Decimal:
                    return "GetDecimal";
                case TypeCodeEx.SmartDate:
                    return "GetSmartDate";
                case TypeCodeEx.DateTime:
                    return "GetDateTime";
                case TypeCodeEx.ByteArray:
                    return "GetValue";
                case TypeCodeEx.Single:
                    return "GetFloat";
                case TypeCodeEx.Double:
                    return "GetDouble";
                case TypeCodeEx.Char:
                    return "GetChar";
                default:
                    return "GetValue";
            }
        }

        /// <summary>
        /// This one is only used for casting values that coume OUT of db command parameters (commonly identity keys).
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public virtual string GetLanguageVariableType(DbType dataType)
        {
            switch (dataType)
            {
                case DbType.AnsiString:
                    return "string";
                case DbType.AnsiStringFixedLength:
                    return "string";
                case DbType.Binary:
                    return "byte[]";
                case DbType.Boolean:
                    return "bool";
                case DbType.Byte:
                    return "byte";
                case DbType.Currency:
                    return "decimal";
                case DbType.Date:
                case DbType.DateTime:
                    return "DateTime";
                case DbType.Decimal:
                    return "decimal";
                case DbType.Double:
                    return "double";
                case DbType.Guid:
                    return "Guid";
                case DbType.Int16:
                    return "short";
                case DbType.Int32:
                    return "int";
                case DbType.Int64:
                    return "long";
                case DbType.Object:
                    return "object";
                case DbType.SByte:
                    return "sbyte";
                case DbType.Single:
                    return "float";
                case DbType.String:
                    return "string";
                case DbType.StringFixedLength:
                    return "string";
                case DbType.Time:
                    return "TimeSpan";
                case DbType.UInt16:
                    return "ushort";
                case DbType.UInt32:
                    return "uint";
                case DbType.UInt64:
                    return "ulong";
                case DbType.VarNumeric:
                    return "decimal";
                default:
                    return "__UNKNOWN__" + dataType;
            }
        }

        public string GetRelationStrings(CslaObjectInfo info)
        {
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            var sb = new StringBuilder();

            foreach (var child in info.ChildProperties)
                if (!child.LazyLoad)
                {
                    sb.Append(GetRelationString(info, child));
                    sb.Append(Environment.NewLine);
                    var grandchildInfo = FindChildInfo(info, child.TypeName);
                    if (grandchildInfo != null)
                        sb.Append(GetRelationStrings(grandchildInfo));
                }

            foreach (var child in info.InheritedChildProperties)
                if (!child.LazyLoad)
                {
                    sb.Append(GetRelationString(info, child));
                    sb.Append(Environment.NewLine);
                    var grandchildInfo = FindChildInfo(info, child.TypeName);
                    if (grandchildInfo != null)
                        sb.Append(GetRelationStrings(grandchildInfo));
                }

            foreach (var child in info.ChildCollectionProperties)
                if (!child.LazyLoad)
                {
                    sb.Append(GetRelationString(info, child));
                    sb.Append(Environment.NewLine);
                    var grandchildInfo = FindChildInfo(info, child.TypeName);
                    if (grandchildInfo != null)
                        sb.Append(GetRelationStrings(grandchildInfo));
                }

            foreach (var child in info.InheritedChildCollectionProperties)
                if (!child.LazyLoad)
                {
                    sb.Append(GetRelationString(info, child));
                    sb.Append(Environment.NewLine);
                    var grandchildInfo = FindChildInfo(info, child.TypeName);
                    if (grandchildInfo != null)
                        sb.Append(GetRelationStrings(grandchildInfo));
                }

            return sb.ToString();
        }

        public virtual string GetRelationString(CslaObjectInfo info, ChildProperty child)
        {
            var indent = new string(' ', IndentLevel*4);

            var sb = new StringBuilder();
            var childInfo = FindChildInfo(info, child.TypeName);
            var joinColumn = String.Empty;
            if (child.LoadParameters.Count > 0)
            {
                if (IsCollectionType(childInfo.ObjectType))
                {
                    joinColumn = child.LoadParameters[0].Property.Name;
                    childInfo = FindChildInfo(info, childInfo.ItemType);
                }
                if (joinColumn == String.Empty)
                {
                    joinColumn = child.LoadParameters[0].Property.Name;
                }
            }

            sb.Append(indent);
            sb.Append("ds.Relations.Add(\"");
            sb.Append(info.ObjectName);
            sb.Append(childInfo.ObjectName);
            sb.Append("\", ds.Tables[");
            sb.Append(ResultSetCount.ToString());
            sb.Append("].Columns[\"");
            sb.Append(joinColumn);
            sb.Append("\"], ds.Tables[");
            sb.Append((ResultSetCount + 1).ToString());
            sb.Append("].Columns[\"");
            sb.Append(joinColumn);
            sb.Append("\"], false);");

            ResultSetCount++;
            return sb.ToString();
        }

        public virtual string GetXmlCommentString(string xmlComment)
        {
            var indent = new string(' ', IndentLevel*4);

            // add leading indent and comment sign
            xmlComment = indent + "/// " + xmlComment;

            return Regex.Replace(xmlComment, Environment.NewLine, Environment.NewLine + indent + "/// ",
                                 RegexOptions.Multiline);
        }

        public virtual string GetUsingStatementsString(CslaObjectInfo info, CslaGeneratorUnit unit)
        {
            const GenerationStep step = GenerationStep.Business;
            var usingNamespaces = GetNamespaces(info, unit, step);

            var result = String.Empty;
            var silverlightLevel = 0;
            if (usingNamespaces.Length != 0)
            {
                var cacheGetContextUtilitiesNamespace = GetContextUtilitiesNamespace(unit, step);
                foreach (var namespaceName in usingNamespaces)
                {
                    if (namespaceName == cacheGetContextUtilitiesNamespace)
                    {
                        if (UseSilverlight())
                        {
                            result += IfSilverlight(Conditional.NotSilverlight, 0, ref silverlightLevel, false, true);
                            result += "using " + namespaceName + ";" + Environment.NewLine;
                            result += IfSilverlight(Conditional.End, 0, ref silverlightLevel, false, true);
                        }
                        else
                        {
                            result += "using " + namespaceName + ";" + Environment.NewLine;
                        }
                    }
                    else if (namespaceName == "Csla.Serialization")
                    {
                        result += IfSilverlight(Conditional.Silverlight, 0, ref silverlightLevel, false, true);
                        result += "using " + namespaceName + ";" + Environment.NewLine;
                        result += IfSilverlight(Conditional.End, 0, ref silverlightLevel, false, true);

                    }
                    else
                        result += "using " + namespaceName + ";" + Environment.NewLine;
                }
            }

            if (UseSilverlight())
            {
                result += IfSilverlight(Conditional.NotSilverlight, 0, ref silverlightLevel, false, true);
                if (unit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
                    result += GetDalInterfaceNamespaces(info, unit);

                result += IfSilverlight(Conditional.End, 0, ref silverlightLevel, false, true);
            }
            else
            {
                if (unit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
                    result += GetDalInterfaceNamespaces(info, unit);
            }


            result = info.GetAllValueProperties().Where(p => p.PropertyType == TypeCodeEx.ByteArray && AllowNull(p)).Aggregate(result, (current, p) => current + ("using System.Linq; //Added for byte[] helpers" + Environment.NewLine));

            return result;
        }

        private string GetDalInterfaceNamespaces(CslaObjectInfo info, CslaGeneratorUnit unit)
        {
            var usesDb = false;

            if (IsReadOnlyType(info.ObjectType) && info.ParentType != string.Empty)
            {
                if (info.CriteriaObjects.Any(criteria => criteria.Properties.Count > 0))
                    usesDb = true;

                if (!usesDb)
                {
                    if(CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL && DalObjectUsesDTO(info))
                        return "using " + GetContextObjectNamespace(info, unit, GenerationStep.DalInterface) + ";" + Environment.NewLine;

                    return string.Empty;
                }
            }

            var result = "using " + GetContextObjectNamespace(info, unit, GenerationStep.DalInterface) + ";" + Environment.NewLine;

            if (CurrentUnit.GenerationParams.UtilitiesNamespace != CurrentUnit.GenerationParams.BaseNamespace &&
                info.ObjectType != CslaObjectType.UnitOfWork)
            {
                result += "using " + GetContextUtilitiesNamespace(unit, GenerationStep.DalInterface) + ";" + Environment.NewLine;
            }

            return result;
        }

        protected string[] GetNamespaces(CslaObjectInfo info, CslaGeneratorUnit unit, GenerationStep step)
        {
            var usingList = new List<string>();

            var addRules = false;
            var addCommonRules = false;

            if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None)
            {
                if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
                {
                    CslaObjectInfo authzInfo = info;
                    if (IsCollectionType(info.ObjectType))
                    {
                        authzInfo = FindChildInfo(info, info.ItemType);
                    }

                    if (authzInfo != null)
                    {
                        if (authzInfo.AuthzProvider != AuthorizationProvider.Custom)
                        {
                            if ((authzInfo.NewRoles.Trim() != String.Empty) ||
                                (authzInfo.GetRoles.Trim() != String.Empty) ||
                                (authzInfo.UpdateRoles.Trim() != String.Empty) ||
                                (authzInfo.DeleteRoles.Trim() != String.Empty))
                            {
                                addRules = true;
                                addCommonRules = true;
                            }
                        }
                        else
                        {
                            if (authzInfo.NewAuthzRuleType != null ||
                                authzInfo.GetAuthzRuleType != null ||
                                authzInfo.UpdateAuthzRuleType != null ||
                                authzInfo.DeleteAuthzRuleType != null)
                            {
                                addRules = true;
                            }
                        }
                    }
                }
            }

            if (!addRules || !addCommonRules)
            {
                if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.ObjectLevel)
                {
                    var rullableProperties = info.AllRulableProperties();
                    foreach (var property in rullableProperties)
                    {
                        if (property.AuthzProvider != AuthorizationProvider.Custom)
                        {
                            if ((property.ReadRoles.Trim() != String.Empty) ||
                                (property.WriteRoles.Trim() != String.Empty))
                            {
                                addRules = true;
                                addCommonRules = true;
                            }
                        }
                    }

                }
            }

            if (addRules)
                usingList.Add("Csla.Rules");
            if (addCommonRules)
                usingList.Add("Csla.Rules.CommonRules");

            if (CurrentUnit.GenerationParams.UtilitiesNamespace != CurrentUnit.GenerationParams.BaseNamespace &&
                info.ObjectType != CslaObjectType.UnitOfWork)
                usingList.Add(GetContextUtilitiesNamespace(unit, step));

            if (UseSilverlight())
                usingList.Add("Csla.Serialization");

            foreach (var name in info.Namespaces)
                if (!usingList.Contains(name))
                    usingList.Add(name);

            foreach (var prop in info.GetAllChildProperties())
                if (prop.TypeName != info.ObjectName)
                {
                    var childInfo = FindChildInfo(info, prop.TypeName);
                    if (childInfo != null)
                        if (!usingList.Contains(childInfo.ObjectNamespace) &&
                            childInfo.ObjectNamespace != info.ObjectNamespace)
                            usingList.Add(childInfo.ObjectNamespace);
                }

            foreach (var prop in info.ConvertValueProperties)
            {
                var converterClass = prop.NVLConverter.Substring(0, prop.NVLConverter.LastIndexOf('.'));
                if (converterClass.Count(s => s == '.') > 0)
                    converterClass = converterClass.Substring(converterClass.LastIndexOf('.') + 1);
                if (converterClass != info.ObjectName)
                {
                    var converterInfo = FindChildInfo(info, converterClass);
                    if (converterInfo != null)
                        if (!usingList.Contains(converterInfo.ObjectNamespace) &&
                            converterInfo.ObjectNamespace != info.ObjectNamespace)
                            usingList.Add(converterInfo.ObjectNamespace);
                }
            }

            if (info.ItemType != String.Empty)
            {
                var childInfo = FindChildInfo(info, info.ItemType);
                if (childInfo != null)
                    if (!usingList.Contains(childInfo.ObjectNamespace) &&
                        childInfo.ObjectNamespace != info.ObjectNamespace)
                        usingList.Add(childInfo.ObjectNamespace);
            }

            if (info.ParentType != String.Empty)
            {
                var parentInfo = FindChildInfo(info, info.ParentType);
                if (parentInfo != null)
                    if (!usingList.Contains(parentInfo.ObjectNamespace) &&
                        parentInfo.ObjectNamespace != info.ObjectNamespace)
                        usingList.Add(parentInfo.ObjectNamespace);
            }

            //string[] usingNamespaces = new string[usingList.Count];
            //usingList.CopyTo(0, usingNamespaces, 0, usingList.Count);
            //Array.Sort(usingNamespaces, new CaseInsensitiveComparer());
            if (usingList.Contains(String.Empty))
                usingList.Remove(String.Empty);
            usingList.Sort(String.Compare);

            return usingList.ToArray();
        }

        public static string GetContextUtilitiesNamespace(CslaGeneratorUnit unit, GenerationStep step)
        {
            var result = AdvancedGenerator.GetContextBaseNamespace(unit, step);
            if (unit.GenerationParams.UtilitiesNamespace == unit.GenerationParams.BaseNamespace)
                return result;

            return result +
                   unit.GenerationParams.UtilitiesNamespace.Substring(unit.GenerationParams.BaseNamespace.Length);
        }

        public static string GetContextObjectNamespace(CslaObjectInfo info, CslaGeneratorUnit unit, GenerationStep step)
        {
            var result = AdvancedGenerator.GetContextBaseNamespace(unit, step);
            if (info.ObjectNamespace == unit.GenerationParams.BaseNamespace)
                return result;

            return result + info.ObjectNamespace.Substring(unit.GenerationParams.BaseNamespace.Length);
        }

        public static string GetDalName(CslaGeneratorUnit unit)
        {
            return unit.GenerationParams.DalName;
        }

        public static string GetDalNameDot(CslaGeneratorUnit unit)
        {
            if (unit.GenerationParams.DalName == string.Empty)
                return string.Empty;

            return unit.GenerationParams.DalName + ".";
        }

        #endregion

        #region Business and Authorization Rules handling

        public string ReturnRoleList(string parameter)
        {
            if (String.IsNullOrWhiteSpace(parameter))
                return String.Empty;

            parameter = parameter.Replace("\"", "");
            string[] resultSplit = parameter.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            string result = String.Empty;
            for (var i = 0; i < resultSplit.Length; i++)
            {
                result += ", \"" + resultSplit[i].Trim() + "\"";
            }

            return result;
        }

        private string BuildArrayOrParams(BusinessRuleConstructorParameter parameter, string result)
        {
            if (parameter.IsParams)
                return result.Trim();

            if (parameter.Type == "String[]" || parameter.Type == "Int32[]")
                return "new[] {" + result.Trim() + "}";

            return "new " + parameter.Type + " {" + result.Trim() + "}";
        }

        public string ReturnParameterValue(BusinessRuleConstructorParameter parameter)
        {
            var result = ReturnRawParameterValue(parameter);
            if (parameter.Type == "String" && result != String.Empty)
                result = "\"" + result.Trim(new[] {'\"'}) + "\"";
            else if (parameter.Type == "String[]" && result != String.Empty)
            {
                result = result.Replace("\"", "");
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = String.Empty;
                var isFirst = true;
                for (var i = 0; i < resultSplit.Length; i++)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += "\"" + resultSplit[i].Trim() + "\"";
                }
                result = BuildArrayOrParams(parameter, result);
            }
            else if (parameter.Type.LastIndexOf("[]") > -1 && parameter.Type.LastIndexOf("[]") == parameter.Type.Length -2 && result != String.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = String.Empty;
                var isFirst = true;
                for (var i = 0; i < resultSplit.Length; i++)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += resultSplit[i].Trim();
                }
                result = BuildArrayOrParams(parameter, result);
            }
            else if (parameter.Type == "List<String>" && result != String.Empty)
            {
                result = result.Replace("\"", "");
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = String.Empty;
                var isFirst = true;
                for (var i = 0; i < resultSplit.Length; i++)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += "\"" + resultSplit[i].Trim() + "\"";
                }
                result = "new List<string> {" + result + "}";
            }
            else if (parameter.Type == "List<Int32>" && result != String.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = String.Empty;
                var isFirst = true;
                for (var i = 0; i < resultSplit.Length; i++)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += resultSplit[i].Trim();
                }
                result = "new List<int> {" + result + "}";
            }
            else if (parameter.Type.IndexOf("List<") == 0 && result != String.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = String.Empty;
                var isFirst = true;
                for (var i = 0; i < resultSplit.Length; i++)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += resultSplit[i].Trim();
                    result = "new " + parameter.Type + " {" + result + "}";
                }
            }
            return result.Trim();
        }

        public string ReturnRawParameterValue(BusinessRuleConstructorParameter parameter)
        {
            if (parameter.Value == null)
                return String.Empty;

            return parameter.Value.ToString();
        }

        public string ReturnPropertyValue(BusinessRuleProperty property)
        {
            var result = ReturnRawPropertyValue(property);
            if (property.Type == "String" && result != String.Empty)
                result = "\"" + result.Trim(new[] {'\"'}) + "\"";
            else if (property.Type == "String[]" && result != String.Empty)
            {
                result = result.Replace("\"", "");
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = String.Empty;
                var isFirst = true;
                for (var i = 0; i < resultSplit.Length; i++)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += "\"" + resultSplit[i].Trim() + "\"";
                }
            }
            else if (property.Type == "List<String>" && result != String.Empty)
            {
                result = result.Replace("\"", "");
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = String.Empty;
                var isFirst = true;
                for (var i = 0; i < resultSplit.Length; i++)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += "\"" + resultSplit[i].Trim() + "\"";
                }
                result = "new List<string> {" + result + "}";
            }
            else if (property.Type == "List<Int32>" && result != String.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = String.Empty;
                var isFirst = true;
                for (var i = 0; i < resultSplit.Length; i++)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += resultSplit[i].Trim();
                    result = "new List<int> {" + result + "}";
                }
            }
            else if (property.Type.Contains("List<") && result != String.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = String.Empty;
                var isFirst = true;
                for (var i = 0; i < resultSplit.Length; i++)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += resultSplit[i].Trim();
                    result = "new " + property.Type + " {" + result + "}";
                }
            }

            return result.Trim();
        }

        public string ReturnRawPropertyValue(BusinessRuleProperty property)
        {
            if (property.Value == null)
                return String.Empty;

            return property.Value.ToString();
        }

        public string ReturnPropertyValue(IBusinessRule rule, PropertyInfo property)
        {
            var result = ReturnRawPropertyValue(rule, property);
            if (property.Name == "Severity")
                result = "RuleSeverity." + result;
            else if (property.Name == "RunMode")
                result = "RunModes." + result;
            else if (property.Name == "RunMode")
                result = "RunModes." + result;
            else if (property.Name == "MessageText" && result != String.Empty)
                result = "\"" + result.Trim(new[] {'\"'}) + "\"";

            return result;
        }

        public string ReturnRawPropertyValue(IBusinessRule rule, PropertyInfo property)
        {
            var value = property.GetValue(rule, null);
            if (value == null)
                return String.Empty;
            string result = value.ToString();
            if (result == "False")
                return result.ToLower();
            if (result == "True")
                return result.ToLower();

            return result;
        }

        public bool IsBaseRulePropertyDefault(string property, string value)
        {
            if (value == "")
                return true;
            if (value == "0")
                return true;
            switch (property)
            {
                case "Severity":
                    if (value == "RuleSeverity.Error")
                        return true;
                    break;
                case "CanRunAsAffectedProperty":
                    if (value.ToLower() == "true")
                        return true;
                    break;
                case "CanRunOnServer":
                    if (value.ToLower() == "true")
                        return true;
                    break;
                case "CanRunInCheckRules":
                    if (value.ToLower() == "true")
                        return true;
                    break;
                case "RunMode":
                    if (value == "RunModes.Default")
                        return true;
                    break;
            }
            return false;
        }

        /*public void RulesValidate(CslaObjectInfo Info)
        {
            bool validateRuleRegion = false;
            bool validateAuthRegion = false;

            #region Is Property validation needed?

            HaveBusinessRulesCollection validateAllRulesProperties = Info.AllRulableProperties();
            foreach (IHaveBusinessRules rulableProperty in validateAllRulesProperties)
            {
                if (Info.ObjectType != CslaObjectType.UnitOfWork &&
                    Info.ObjectType != CslaObjectType.NameValueList &&
                    !IsCollectionType(Info.ObjectType) &&
                    rulableProperty.BusinessRules.Count > 0)
                {
                    validateRuleRegion = true;
                }

                if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                    CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.ObjectLevel)
                {
                    if (rulableProperty.AuthzProvider == AuthorizationProvider.Custom)
                    {
                        if (rulableProperty.ReadAuthzRuleType.Constructors.Count > 0 ||
                            rulableProperty.WriteAuthzRuleType.Constructors.Count > 0)
                        {
                            validateAuthRegion = true;
                        }
                    }
                }
                if (validateRuleRegion || validateAuthRegion)
                    break;
            }

            #endregion

            #region Validate Property Business Rules

            if (validateRuleRegion)
            {
                foreach (IHaveBusinessRules rulableProperty in validateAllRulesProperties)
                {
                    foreach (BusinessRule rule in rulableProperty.BusinessRules)
                    {
                        foreach (BusinessRuleConstructor constructor in rule.Constructors)
                        {
                            if (constructor.IsActive)
                            {
                                foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters
                                    )
                                {
                                    if (parameter.IsGenericType && parameter.GenericType == TypeCodeEx.Empty)
                                    {
                                        //Errors.Append(rulableProperty.Name + ": business rule " + rule.Name + ": generic parameter <" + parameter.Type + "> is Empty (undefined)." + Environment.NewLine);
                                    }
                                    if (string.IsNullOrEmpty(ReturnRawParameterValue(parameter)))
                                    {
                                        //Errors.Append(rulableProperty.Name + ": business rule " + rule.Name + ": parameter " + parameter.Name + " has no value." + Environment.NewLine);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            #endregion

            #region Validate Property Authorization Rules

            if (validateAuthRegion)
            {
                foreach (IHaveBusinessRules rulableProperty in validateAllRulesProperties)
                {
                    AuthorizationRuleCollection allAuthzRules = new AuthorizationRuleCollection();
                    allAuthzRules.Add(rulableProperty.ReadAuthzRuleType);
                    allAuthzRules.Add(rulableProperty.WriteAuthzRuleType);
                    foreach (AuthorizationRule rule in allAuthzRules)
                    {
                        foreach (BusinessRuleConstructor constructor in rule.Constructors)
                        {
                            if (constructor.IsActive)
                            {
                                foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters
                                    )
                                {
                                    if (parameter.IsGenericType && parameter.GenericType == TypeCodeEx.Empty)
                                    {
                                        //Errors.Append(rulableProperty.Name + ": authorization rule " + rule.Name + ": generic parameter <" + parameter.Type + "> is Empty (undefined)." + Environment.NewLine);
                                    }
                                    if (string.IsNullOrEmpty(ReturnRawParameterValue(parameter)))
                                    {
                                        //Errors.Append(rulableProperty.Name + ": authorization rule " + rule.Name + ": parameter " + parameter.Name + " has no value." + Environment.NewLine);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            #endregion

            #region Validate Object Business Rules

            if (Info.ObjectType != CslaObjectType.UnitOfWork &&
                Info.ObjectType != CslaObjectType.NameValueList &&
                !IsCollectionType(Info.ObjectType))
            {
                foreach (var rule in Info.BusinessRules)
                {
                    foreach (BusinessRuleConstructor constructor in rule.Constructors)
                    {
                        if (constructor.IsActive)
                        {
                            foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters)
                            {
                                if (parameter.IsGenericType && parameter.GenericType == TypeCodeEx.Empty)
                                {
                                    //Errors.Append(Info.ObjectName + ": business rule " + rule.Name + ": generic parameter <" + parameter.Type + "> is Empty (undefined)." + Environment.NewLine);
                                }
                                if (string.IsNullOrEmpty(ReturnRawParameterValue(parameter)))
                                {
                                    //Errors.Append(Info.ObjectName + ": business rule " + rule.Name + ": parameter " + parameter.Name + " has no value." + Environment.NewLine);
                                }
                            }
                        }
                    }
                }
            }

            #endregion

            #region Validate Object Authorization Rules

            if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
            {
                if (Info.AuthzProvider == AuthorizationProvider.Custom)
                {
                    AuthorizationRuleCollection objectAuthzRules = new AuthorizationRuleCollection();
                    objectAuthzRules.Add(Info.NewAuthzRuleType);
                    objectAuthzRules.Add(Info.GetAuthzRuleType);
                    objectAuthzRules.Add(Info.UpdateAuthzRuleType);
                    objectAuthzRules.Add(Info.DeleteAuthzRuleType);
                    foreach (AuthorizationRule rule in objectAuthzRules)
                    {
                        foreach (BusinessRuleConstructor constructor in rule.Constructors)
                        {
                            if (constructor.IsActive)
                            {
                                foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters
                                    )
                                {
                                    if (parameter.IsGenericType && parameter.GenericType == TypeCodeEx.Empty)
                                    {
                                        //Errors.Append(Info.ObjectName + ": authorization rule " + rule.Name + ": generic parameter <" + parameter.Type + "> is Empty (undefined)." + Environment.NewLine);
                                    }
                                    if (string.IsNullOrEmpty(ReturnRawParameterValue(parameter)))
                                    {
                                        //Errors.Append(Info.ObjectName + ": authorization rule " + rule.Name + ": parameter " + parameter.Name + " has no value." + Environment.NewLine);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            #endregion

        }*/

        /*public void TestRules(CslaObjectInfo Info)
        {
            bool generateRuleRegion = false;
            bool generateAuthRegion = false;

            string resultRule = string.Empty;
            string resultConstructor = string.Empty;
            string resultProperties = string.Empty;

            HaveBusinessRulesCollection allRulesProperties = Info.AllRulableProperties();
            foreach (IHaveBusinessRules rulableProperty in allRulesProperties)
            {
                if (Info.ObjectType != CslaObjectType.UnitOfWork &&
                    Info.ObjectType != CslaObjectType.NameValueList &&
                    !IsCollectionType(Info.ObjectType) &&
                    rulableProperty.BusinessRules.Count > 0)
                    generateRuleRegion = true;
                }
                if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                    CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.ObjectLevel)
                {
                    if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                        rulableProperty.AuthzProvider != AuthorizationProvider.Custom)
                    {
                        if (!String.IsNullOrWhiteSpace(rulableProperty.ReadRoles) ||
                            !String.IsNullOrWhiteSpace(rulableProperty.WriteRoles))
                        {
                            generateAuthRegion = true;
                        }
                    }
                    else if (rulableProperty.ReadAuthzRuleType.Constructors.Count > 0 ||
                             rulableProperty.WriteAuthzRuleType.Constructors.Count > 0)
                    {
                        generateAuthRegion = true;
                    }
                }
                if (generateRuleRegion || generateAuthRegion)
                    break;
            }

            #region Business Rules

            if (generateRuleRegion)
            {
                Response.WriteLine(Environment.NewLine + new string(' ', 12) + "// Business Rules" + Environment.NewLine);
                bool primaryOnCtor = false;
                foreach (IHaveBusinessRules rulableProperty in allRulesProperties)
                {
                    if (rulableProperty.BusinessRules.Count > 0)
                        Response.WriteLine(new string(' ', 12) + "//" + rulableProperty.Name);

                    foreach (BusinessRule rule in rulableProperty.BusinessRules)
                    {
                        string backupRuleType = rule.Type;
                        foreach (string ns in Info.Namespaces)
                        {
                            string nameSpace = ns + '.';
                            if (backupRuleType.IndexOf(nameSpace) == 0 &&
                                backupRuleType.Substring(nameSpace.Length).IndexOf('.') == -1)
                            {
                                backupRuleType = backupRuleType.Substring(nameSpace.Length);
                                break;
                            }
                        }
                        resultConstructor = string.Empty;
                        resultProperties = string.Empty;
                        primaryOnCtor = false;
                        bool isFirst = true;
                        bool isFirstGeneric = true;

                        // Constructors and ConstructorParameters
                        foreach (BusinessRuleConstructor constructor in rule.Constructors)
                        {
                            if (constructor.IsActive)
                            {
                                foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters
                                    )
                                {
                                    if (isFirst)
                                        isFirst = false;
                                    else
                                        resultConstructor += ", ";
                                    if (parameter.Type == "IPropertyInfo")
                                    {
                                        resultConstructor += FormatPropertyInfoName(ReturnRawParameterValue(parameter));
                                        primaryOnCtor = true;
                                    }
                                    else
                                    {
                                        if (parameter.IsGenericType)
                                        {
                                            backupRuleType = backupRuleType.Replace(parameter.Type, GetDataType(parameter.GenericType));
                                            if (isFirstGeneric)
                                                isFirstGeneric = false;
                                            else
                                                backupRuleType = backupRuleType.Replace(",", ", ");
                                        }
                                        resultConstructor += ReturnParameterValue(parameter);
                                    }
                                }
                            }
                        }

                        // RuleProperties
                        isFirst = true;
                        foreach (BusinessRuleProperty property in rule.RuleProperties)
                        {
                            if (property.Type == "IPropertyInfo")
                            {
                                if (primaryOnCtor)
                                    continue;
                                if (isFirst)
                                    isFirst = false;
                                else
                                    resultProperties += ", ";
                                resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(property));
                            }
                            else
                            {
                                string stringValue = ReturnPropertyValue(property);
                                if (stringValue == string.Empty)
                                    continue;

                                if (isFirst)
                                    isFirst = false;
                                else
                                    resultProperties += ", ";
                                resultProperties += property.Name + " = " + stringValue;
                            }
                        }

                        // BaseRuleProperties
                        if (rule.BaseRuleProperties.Count > 0)
                        {
                            PropertyInfo[] ruleProps = typeof (BusinessRule).GetProperties();
                            foreach (PropertyInfo property in ruleProps)
                            {
                                if (rule.BaseRuleProperties.Contains(property.Name))
                                {
                                    if (property.Name == "PrimaryProperty")
                                    {
                                        if (primaryOnCtor)
                                            continue;
                                        if (isFirst)
                                            isFirst = false;
                                        else
                                            resultProperties += ", ";

                                        resultProperties += property.Name + " = " +
                                                            FormatPropertyInfoName(ReturnRawPropertyValue(rule, property));
                                    }
                                    else
                                    {
                                        string stringValue = ReturnPropertyValue(rule, property);
                                        if (IsBaseRulePropertyDefault(property.Name, stringValue))
                                            continue;

                                        if (isFirst)
                                            isFirst = false;
                                        else
                                            resultProperties += ", ";
                                        resultProperties += property.Name + " = " + stringValue;
                                    }
                                }
                            }
                        }

                        if (resultProperties != string.Empty)
                            resultProperties = " { " + resultProperties + " }";

                        resultRule = "BusinessRules.AddRule(new " + backupRuleType + "(" + resultConstructor + ")" + resultProperties + ")" + ";";
                        Response.WriteLine(resultRule);
                    }
                }
            }

            #endregion

            #region Authorization Rules

            if (generateAuthRegion)
            {
                Response.WriteLine(Environment.NewLine + new string(' ', 12) + "// Authorization Rules" + Environment.NewLine);
                AuthorizationRule authzRule;
                foreach (IHaveBusinessRules rulableProperty in allRulesProperties)
                {
                    if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                        rulableProperty.AuthzProvider != AuthorizationProvider.Custom)
                    {
                        if (!String.IsNullOrWhiteSpace(rulableProperty.ReadRoles) ||
                            !String.IsNullOrWhiteSpace(rulableProperty.WriteRoles))
                        {
                            Response.WriteLine(new string(' ', 12) + "//" + rulableProperty.Name);
                            if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
                                rulableProperty.AuthzProvider == AuthorizationProvider.IsInRole)
                            {
                                resultRule = "BusinessRules.AddRule(typeof(" + Info.ObjectName + "), new IsInRole(AuthorizationActions.ReadProperty" + ReturnRoleList(rulableProperty.ReadRoles) +"));";
                                Response.Write(resultRule + Environment.NewLine);
                            }
                            else
                            {
                                resultRule = "BusinessRules.AddRule(typeof(" + Info.ObjectName + "), new IsNotInRole(AuthorizationActions.ReadProperty" + ReturnRoleList(rulableProperty.ReadRoles) + "));";
                                Response.Write(resultRule + Environment.NewLine);
                            }
                        }
                    }
                    else if (rulableProperty.ReadAuthzRuleType.Constructors.Count > 0 ||
                             rulableProperty.WriteAuthzRuleType.Constructors.Count > 0)
                    {
                        Response.WriteLine(new string(' ', 12) + "//" + rulableProperty.Name);
                        if (!string.IsNullOrWhiteSpace(rulableProperty.ReadAuthzRuleType.Type))
                        {
                            authzRule = rulableProperty.ReadAuthzRuleType;
                            //%><!-- #include file="AuthorizationRules.asp" --><%
                            BuildAuthzRule(Info, authzRule);
                        }
                        if (!string.IsNullOrWhiteSpace(rulableProperty.WriteAuthzRuleType.Type))
                        {
                            authzRule = rulableProperty.WriteAuthzRuleType;
                            //%><!-- #include file="AuthorizationRules.asp" --><%
                            BuildAuthzRule(Info, authzRule);
                        }
                    }
                }
            }

            #endregion

        }*/

        /*public void BuildAuthzRule(CslaObjectInfo Info, AuthorizationRule authzRule)
        {
            string backupRuleType = authzRule.Type;
            foreach (string ns in Info.Namespaces)
            {
                string nameSpace = ns + '.';
                if (backupRuleType.IndexOf(nameSpace) == 0)
                {
                    backupRuleType = backupRuleType.Substring(nameSpace.Length);
                    break;
                }
            }
            string resultRule = string.Empty;
            string resultConstructor = string.Empty;
            string resultProperties = string.Empty;
            bool isFirst = true;
            bool isFirstGeneric = true;
            bool actionOnCtor = false;
            bool elementOnCtor = false;

            // Constructors and ConstructorParameters
            foreach (BusinessRuleConstructor constructor in authzRule.Constructors)
            {
                if (constructor.IsActive)
                {
                    foreach (BusinessRuleConstructorParameter parameter in constructor.ConstructorParameters)
                    {
                        if (parameter.Type == "IMemberInfo")
                        {
                            if (isFirst)
                                isFirst = false;
                            else
                                resultConstructor += ", ";
                            resultConstructor += FormatPropertyInfoName(ReturnRawParameterValue(parameter));
                            elementOnCtor = true;
                        }
                        else if (parameter.Type == "AuthorizationActions")
                        {
                            if (isFirst)
                                isFirst = false;
                            else
                                resultConstructor += ", ";
                            resultConstructor += "AuthorizationActions." + ReturnRawParameterValue(parameter);
                            actionOnCtor = true;
                        }
                        else
                        {
                            if (parameter.IsGenericType)
                            {
                                backupRuleType = backupRuleType.Replace(parameter.Type, GetDataType(parameter.GenericType));
                                if (isFirstGeneric)
                                    isFirstGeneric = false;
                                else
                                    backupRuleType = backupRuleType.Replace(",", ", ");
                            }

                            string stringValue = ReturnParameterValue(parameter);
                            if (stringValue == string.Empty)
                                continue;
                            if (isFirst)
                                isFirst = false;
                            else
                                resultConstructor += ", ";

                            resultConstructor += stringValue;
                        }
                    }
                }
            }

            // RuleProperties
            isFirst = true;
            foreach (BusinessRuleProperty property in authzRule.RuleProperties)
            {
                if (property.Type == "IMemberInfo")
                {
                    if (elementOnCtor)
                        continue;
                    if (isFirst)
                        isFirst = false;
                    else
                        resultProperties += ", ";
                    resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(property));
                }
                else if (property.Type == "AuthorizationActions")
                {
                    if (actionOnCtor)
                        continue;
                    if (isFirst)
                        isFirst = false;
                    else
                        resultProperties += ", ";
                    resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(property));
                }
                else
                {
                    string stringValue = ReturnPropertyValue(property);
                    if (stringValue == string.Empty)
                        continue;

                    if (isFirst)
                        isFirst = false;
                    else
                        resultProperties += ", ";
                    resultProperties += property.Name + " = " + stringValue;
                }
            }

            // BaseRuleProperties
            if (authzRule.BaseRuleProperties.Count > 0)
            {
                PropertyInfo[] ruleProps = typeof (AuthorizationRule).GetProperties();
                foreach (PropertyInfo property in ruleProps)
                {
                    if (authzRule.BaseRuleProperties.Contains(property.Name))
                    {
                        if (property.Name == "Element")
                        {
                            if (elementOnCtor)
                                continue;
                            if (isFirst)
                                isFirst = false;
                            else
                                resultProperties += ", ";
                            resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(authzRule, property));
                        }
                        else if (property.Name == "Action")
                        {
                            if (actionOnCtor)
                                continue;
                            if (isFirst)
                                isFirst = false;
                            else
                                resultProperties += ", ";
                            resultProperties += property.Name + " = " + FormatPropertyInfoName(ReturnRawPropertyValue(authzRule, property));
                        }
                        else
                        {
                            string stringValue = ReturnPropertyValue(authzRule, property);
                            if (IsBaseRulePropertyDefault(property.Name, stringValue))
                                continue;

                            if (isFirst)
                                isFirst = false;
                            else
                                resultProperties += ", ";
                            resultProperties += property.Name + " = " + stringValue;
                        }
                    }
                }
            }

            if (resultProperties != string.Empty)
                resultProperties = " { " + resultProperties + " }";

            resultRule = "BusinessRules.AddRule(typeof(" + Info.ObjectName + "), new " + backupRuleType + "(" + resultConstructor + ")" + resultProperties + ")" + ";";
            Response.Write(resultRule + Environment.NewLine);
        }*/

        #endregion

        #region Query Object Metadata

        public bool ParentLoadsChildren(CslaObjectInfo info)
        {
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            /*foreach (var child in info.GetAllChildProperties())
                if (child.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    return true;
                }

            return false;*/

            return info.GetAllChildProperties().Any(child => child.LoadingScheme == LoadingScheme.ParentLoad);
        }

        public bool ParentLoadsROChildren(CslaObjectInfo info)
        {
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            foreach (var child in info.GetAllChildProperties())
            {
                if (child.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    var childInfo = FindChildInfo(info, child.TypeName);
                    if (IsReadOnlyType(childInfo.ObjectType))
                        return true;
                }
            }

            return false;
        }

        public bool ParentLoadsCollectionChildren(CslaObjectInfo info)
        {
            // todo: check if it's used on the templates and if not, remove this method

            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            /*foreach (var child in info.GetAllChildProperties())
                if (child.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    return true;
                }

            return false;*/

            return info.GetCollectionChildProperties().Any(child => child.LoadingScheme == LoadingScheme.ParentLoad);
        }

        public bool SelfLoadsChildren(CslaObjectInfo info)
        {
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            /*foreach (var child in info.GetAllChildProperties())
                if (!child.LazyLoad && child.LoadingScheme == LoadingScheme.SelfLoad)
                {
                    return true;
                }

            return false;*/

            return info.GetAllChildProperties().Any(child => !child.LazyLoad && child.LoadingScheme == LoadingScheme.SelfLoad);
        }

        public static bool IsCollectionType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRootCollection ||
                cslaType == CslaObjectType.EditableChildCollection ||
                cslaType == CslaObjectType.DynamicEditableRootCollection ||
                cslaType == CslaObjectType.ReadOnlyCollection)
                return true;

            return false;
        }

        public static bool IsObjectType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRoot ||
                cslaType == CslaObjectType.EditableChild ||
                cslaType == CslaObjectType.EditableSwitchable ||
                cslaType == CslaObjectType.DynamicEditableRoot ||
                cslaType == CslaObjectType.ReadOnlyObject)
                return true;

            return false;
        }

        public static bool IsEditableType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableChild ||
                cslaType == CslaObjectType.EditableChildCollection ||
                cslaType == CslaObjectType.EditableRoot ||
                cslaType == CslaObjectType.EditableRootCollection ||
                cslaType == CslaObjectType.EditableSwitchable ||
                cslaType == CslaObjectType.DynamicEditableRoot ||
                cslaType == CslaObjectType.DynamicEditableRootCollection)
                return true;

            return false;
        }

        public static bool IsReadOnlyType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.ReadOnlyCollection ||
                cslaType == CslaObjectType.ReadOnlyObject)
                return true;

            return false;
        }

        public static bool IsChildType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableChild ||
                cslaType == CslaObjectType.EditableChildCollection)
                return true;

            return false;
        }

        public static bool IsChildType(CslaObjectInfo info)
        {
            if (info.ObjectType == CslaObjectType.EditableSwitchable ||
                info.ObjectType == CslaObjectType.EditableChild ||
                info.ObjectType == CslaObjectType.EditableChildCollection ||
                ((info.ObjectType == CslaObjectType.ReadOnlyObject ||
                info.ObjectType == CslaObjectType.ReadOnlyCollection) &&
                info.ParentType != String.Empty))
                return true;

            return false;
        }

        public static bool IsRootType(CslaObjectInfo info)
        {
            if (info.ObjectType == CslaObjectType.EditableRoot ||
                info.ObjectType == CslaObjectType.EditableRootCollection ||
                info.ObjectType == CslaObjectType.DynamicEditableRoot ||
                info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
                info.ObjectType == CslaObjectType.EditableSwitchable ||
                ((info.ObjectType == CslaObjectType.ReadOnlyObject ||
                  info.ObjectType == CslaObjectType.ReadOnlyCollection) &&
                 info.ParentType == String.Empty))
                return true;

            return false;
        }

        public static bool IsNotRootType(CslaObjectInfo info)
        {
            if (info.ObjectType == CslaObjectType.EditableChild ||
                (info.ObjectType == CslaObjectType.ReadOnlyObject &&
                info.ParentType != String.Empty))
                return true;

            return false;
        }

        public static bool IsItemType(CslaObjectInfo info)
        {
            var cslaType = info.ObjectType;
            if (cslaType == CslaObjectType.EditableRoot ||
                cslaType == CslaObjectType.EditableChild ||
                cslaType == CslaObjectType.DynamicEditableRoot ||
                cslaType == CslaObjectType.ReadOnlyObject)
            {
                var parent = info.Parent.CslaObjects.Find(info.ParentType);
                if (IsCollectionType(parent.ObjectType))
                    return true;
            }

            return false;
        }

        public static bool IsRootOrRootItem(CslaObjectInfo info)
        {
            bool result = !IsChildType(info);
            if (!result)
            {
                var parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
                if (parentInfo != null)
                    result = !IsChildType(parentInfo);
            }
            return result;
        }

        public static bool CanHaveParentProperties(CslaObjectInfo info)
        {
            if (IsCollectionType(info.ObjectType))
                return false; // Object is a collection and thus has no Properties

            if (info.ObjectType == CslaObjectType.EditableRoot ||
                info.ObjectType == CslaObjectType.DynamicEditableRoot)
                return false; // Object is root and thus has no ParentType

            var parent = info.Parent.CslaObjects.Find(info.ParentType);
            if (parent == null)
                return info.ObjectType == CslaObjectType.ReadOnlyObject;// Object is ReadOnly and might have ParentProperties

            if (IsCollectionType(parent.ObjectType)) // ParentType is a collection and thus has no Properties
            {
                if (parent.ObjectType == CslaObjectType.EditableRootCollection ||
                    parent.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
                    (parent.ObjectType == CslaObjectType.ReadOnlyCollection && parent.ParentType == String.Empty))
                    return false; // ParentType is a root collection; end of line

                return true;// There should be a grand-parent with properties
            }

            if (IsObjectType(parent.ObjectType))
                return true; // ParentType exists and has properties

            return false;
        }

        public static string PropertyNameMatchesParentProperty(CslaObjectInfo parent, CslaObjectInfo info, ValueProperty prop)
        {
            return ColumnNameMatchesParentProperty(parent, info, prop.DbBindColumn.Column);
        }

        public static string ColumnNameMatchesParentProperty(CslaObjectInfo parent, CslaObjectInfo info, IColumnInfo validatingColumn)
        {
            foreach (var prop in info.ParentProperties)
            {
                // name and data type match for Views
                if (prop.Name == validatingColumn.ColumnName &&
                    prop.PropertyType == TypeHelper.GetTypeCodeEx(validatingColumn.ManagedType))
                    return info.ObjectName + "." + validatingColumn.ColumnName;
            }

            return String.Empty;
        }

        public static string PropertyFKMatchesParentProperty(CslaObjectInfo parent, CslaObjectInfo info, ValueProperty prop)
        {
            return ColumnFKMatchesParentProperty(parent, info, prop.DbBindColumn.Column);
        }

        public static string ColumnFKMatchesParentProperty(CslaObjectInfo parent, CslaObjectInfo info, IColumnInfo validatingColumn)
        {
            foreach (var prop in info.ParentProperties)
            {
                var parentPropertyFound = parent.GetAllValueProperties().Find(prop.Name);
                if (parentPropertyFound != null)
                {
                    var parentSchema = parentPropertyFound.DbBindColumn.SchemaName;
                    var parentTable = parentPropertyFound.DbBindColumn.ObjectName;
                    var parentColumn = parentPropertyFound.DbBindColumn.Column;
                    if (parentColumn != null)
                    {
                        if (validatingColumn.FKConstraint != null)
                        {
                            if (parentSchema == validatingColumn.FKConstraint.PKTable.ObjectSchema ||
                                parentTable == validatingColumn.FKConstraint.PKTable.ObjectName)
                            {
                                foreach (var pkColumn in validatingColumn.FKConstraint.Columns)
                                {
                                    if (pkColumn.PKColumn == parentColumn)
                                        return validatingColumn.FKConstraint.ConstraintTable.ObjectName + "." +
                                               validatingColumn.ColumnName;
                                }
                            }
                        }
                    }
                }
            }

            return String.Empty;
        }

        public static bool MultiplePropertyFKMatchesParent(CslaObjectInfo parent, CslaObjectInfo info, ValueProperty prop)
        {
            return MultipleColumnFKMatchesParent(parent, info, prop.DbBindColumn.Column);
        }

        public static bool MultipleColumnFKMatchesParent(CslaObjectInfo parent, CslaObjectInfo info, IColumnInfo validatingColumn)
        {
            foreach (var prop in info.ParentProperties)
            {
                var parentPropertyFound = parent.GetAllValueProperties().Find(prop.Name);
                if (parentPropertyFound != null)
                {
                    var parentSchema = parentPropertyFound.DbBindColumn.SchemaName;
                    var parentTable = parentPropertyFound.DbBindColumn.ObjectName;
                    var parentColumn = parentPropertyFound.DbBindColumn.Column;
                    if (parentColumn != null)
                    {
                        if (validatingColumn.FKConstraint != null)
                        {
                            if (parentSchema == validatingColumn.FKConstraint.PKTable.ObjectSchema ||
                                parentTable == validatingColumn.FKConstraint.PKTable.ObjectName)
                            {
                                foreach (var pkColumn in validatingColumn.FKConstraint.Columns)
                                {
                                    if (pkColumn.PKColumn == parentColumn)
                                    {
                                        var matchCounter =
                                            CountMatchingInfoColumns(validatingColumn.FKConstraint.ConstraintTable,
                                                                     parentSchema, parentTable, parentColumn);
                                        return matchCounter > 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        private static int CountMatchingInfoColumns(ITableInfo infoTable, string parentSchema, string parentTable, IColumnInfo parentColumn)
        {
            var matchCounter = 0;
            foreach (var infoColumn in infoTable.Columns)
            {
                if (infoColumn.FKConstraint != null)
                {
                    if (parentSchema == infoColumn.FKConstraint.PKTable.ObjectSchema ||
                        parentTable == infoColumn.FKConstraint.PKTable.ObjectName)
                    {
                        foreach (var columnPair in infoColumn.FKConstraint.Columns)
                        {
                            if (columnPair.PKColumn == parentColumn)
                                matchCounter++;
                        }
                    }
                }
            }

            return matchCounter;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Finds the child info.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="name">The child name to find.</param>
        /// <returns>A CslaObjectInfo with the found object or null</returns>
        public CslaObjectInfo FindChildInfo(CslaObjectInfo info, string name)
        {
            return info.Parent.CslaObjects.Find(name);
        }

        public bool GetValuePropertyByName(CslaObjectInfo info, string propertyName, ref ValueProperty prop)
        {
            foreach (var valueProperty in info.GetAllValueProperties())
            {
                if (valueProperty.Name == propertyName)
                {
                    prop = valueProperty;
                    return true;
                }
            }
            return false;
        }

        public bool GetChildPropertyByTypeName(CslaObjectInfo info, string propertyName, ref ChildProperty prop)
        {
            foreach (var childProperty in info.GetAllChildProperties())
            {
                if (childProperty.TypeName == propertyName)
                {
                    prop = childProperty;
                    return true;
                }
            }
            return false;
        }

        public void Message(string msg)
        {
            MessageBox.Show(msg, @"Csla Generator");
        }

        public void Message(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected internal string ParseNativeType(string nType)
        {
            try
            {
                object value = Enum.Parse(typeof(SqlDbType), nType, true);
                return value.ToString();
            }
            catch
            {
                return String.Empty;
            }
        }

        public string GetNativeType(ValueProperty prop)
        {
            string nativeType = null;
            if (!String.IsNullOrEmpty(prop.DbBindColumn.NativeType))
                nativeType = ParseNativeType(prop.DbBindColumn.NativeType);
            if (String.IsNullOrEmpty(nativeType))
            {
                OutputWindow.Current.AddOutputInfo(String.Format("{0}: Unable to parse database native type from DbBindColumn, infering type from property type.", prop.PropertyType));
                nativeType = TypeHelper.GetSqlDbType(prop.PropertyType).ToString();
            }
            return nativeType;
        }

        private string ConvertTextToSmartDate(ValueProperty prop)
        {
            if (prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                if (prop.PropertyType == TypeCodeEx.String && prop.BackingFieldType == TypeCodeEx.SmartDate)
                    return ".Text";
            }

            return String.Empty;
        }

        #endregion

        #region ParameterSet

        public virtual string GetParameterSet(CslaObjectInfo info, Property prop, bool isCriteria, bool isParameter)
        {
            TypeCodeEx propType = prop.PropertyType;
            try
            {
                propType = TypeHelper.GetBackingFieldType(prop as ValueProperty);
            }
            catch (Exception) { }

            bool nullable = AllowNull(prop);
            string propName;
            //propName = (isCriteria) ? "crit." + FormatPascal(prop.Name) : FormatFieldForPropertyType(info, prop);
            if (isCriteria)
            {
                propName = "crit." + FormatPascal(prop.Name);
            }
            else if (isParameter)
            {
                propName = FormatCamel(prop.Name);
            }
            else
            {
                propName = FormatFieldForPropertyType(info, prop);
            }

            //if (nullable && propType != TypeCodeEx.SmartDate)
            if (nullable)
            {
                if (TypeHelper.IsNullableType(propType))
                    return String.Format("{0} == null ? (object)DBNull.Value : {0}.Value", propName);

                return String.Format("{0} == null ? (object)DBNull.Value : {0}", propName);
            }

            /*switch (propType)
            {
                case TypeCodeEx.Guid:
                    return propName + ".Equals(Guid.Empty) ? (object)DBNull.Value : " + propName;
                default:
                    return propName;
            }*/
            return propName;
        }

        /// <summary>
        /// Gets the parameter set - for plain properties.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="prop">The prop.</param>
        /// <returns></returns>
        public virtual string GetParameterSet(CslaObjectInfo info, Property prop)
        {
            return GetParameterSet(info, prop, false, false);
        }

        /// <summary>
        /// Gets the parameter set - for criteria properties.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="prop">The prop.</param>
        /// <param name="isCriteria">if set to <c>true</c> [criteria].</param>
        /// <returns></returns>
        public virtual string GetParameterSet(CslaObjectInfo info, Property prop, bool isCriteria)
        {
            return GetParameterSet(info, prop, isCriteria, false);
        }

        #endregion

        #region Basic Formats

        public virtual string FormatGeneralParameter(CslaObjectInfo info, Property prop, bool isCriteria, bool isParameter, bool isCaller)
        {
            if (isCriteria)
            {
                return "crit." + FormatPascal(prop.Name);
            }

            string result;
            var propType = prop.PropertyType;
            try
            {
                propType = TypeHelper.GetBackingFieldType(prop as ValueProperty);
            }
            catch (Exception) { }

            if (isParameter)
                result = FormatCamel(prop.Name);
            else
                result = FormatFieldForBackingType(info, prop);

            if (!isCaller)
                result = GetDataTypeGeneric(prop, propType) + " " + result;

            return result;
        }

        private string FormatFieldForBackingType(CslaObjectInfo info, Property p)
        {
            var response = String.Empty;

            ValuePropertyCollection valProps = info.GetAllValueProperties();
            if (valProps.Contains(p.Name))
            {
                ValueProperty prop = valProps.Find(p.Name);

                var propDeclarationMode = prop.DeclarationMode;
                var propName = p.Name;

                if (propDeclarationMode == PropertyDeclaration.Managed ||
                    propDeclarationMode == PropertyDeclaration.AutoProperty)
                    return String.Format(FormatProperty(propName));

                if (propDeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                    return String.Format("ReadProperty({0})", FormatPropertyInfoName(propName));

                return FormatFieldName(propName);
            }
            return response;
        }

        public string FormatFieldForPropertyName(CslaObjectInfo info, string name)
        {
            var response = String.Empty;

            ValuePropertyCollection valProps = info.GetAllValueProperties();
            if (valProps.Contains(name))
            {
                ValueProperty prop = valProps.Find(name);
                response = GetFieldReaderStatement(prop.DeclarationMode, name);
            }
            return response;
        }

        public string FormatFieldForPropertyType(CslaObjectInfo info, Property p)
        {
            var response = String.Empty;

            ValuePropertyCollection valProps = info.GetAllValueProperties();
            if (valProps.Contains(p.Name))
            {
                ValueProperty prop = valProps.Find(p.Name);
                response = GetFieldReaderStatement(prop.DeclarationMode, p.Name);
            }
            return response;
        }

        public string FormatEvent(string name)
        {
            return FormatPascal(name);
        }

        public string FormatFieldName(ValueProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatFieldName(Property prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(ValueProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(ChildProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(UpdateValueProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(ConvertValueProperty prop)
        {
            return FormatPascal(prop.Name);
        }

        public string FormatProperty(string name)
        {
            return FormatPascal(name);
        }

        public string FormatPropertyInfoName(string name)
        {
            return FormatPascal(name) + "Property";
        }

        #endregion

        #region State Field

        public bool StateFieldsForAllValueProperties(CslaObjectInfo info)
        {
            foreach (var prop in info.AllValueProperties)
            {
                if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.NoProperty)
                {
                    return true;
                }
            }

            return false;
        }

        public bool StateFieldsForAllChildProperties(CslaObjectInfo info)
        {
            foreach (var prop in info.AllChildProperties)
            {
                if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                    prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.NoProperty)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Declarations

        public string ListBaseHelper(string rootStereotype, bool isWinForms)
        {
            var response = String.Empty;

            if (isWinForms)
            {
                response += rootStereotype + "BindingListBase";
            }
            else
            {
                response += rootStereotype + "ListBase";
            }

            return response;
        }

        // TODO: On ReadOnly objects, forbid Managed and Unmanaged with TypeConversion

        public virtual string GetInitValue(CslaObjectInfo info, ValueProperty prop, TypeCodeEx typeCode)
        {
            if (!HasCreateCriteriaDataPortal(info))
            {
                if (prop.DefaultValue != String.Empty)
                    return prop.DefaultValue;
            }

            //if (AllowNull(prop) && typeCode != TypeCodeEx.SmartDate)
            if (AllowNull(prop))
                return "null";

            return GetInitValue(typeCode);
        }

        public virtual string GetDataTypeGeneric(Property prop, TypeCodeEx field)
        {
            string type = GetDataType(field);
            if (AllowNull(prop))
            {
                if (TypeHelper.IsNullableType(field))
                    type += "?";
            }
            return type;
        }

        public string FieldDeclare(CslaObjectInfo info, ValueProperty prop)
        {
            var response = String.Empty;
            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.NoProperty)
            {
                response = CheckNotUndoable(prop);
                response += String.Format("private {0} {1} = {2};",
                                          (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                                           prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                                           prop.DeclarationMode == PropertyDeclaration.NoProperty)
                                              ? GetDataTypeGeneric(prop, prop.PropertyType)
                                              : GetDataTypeGeneric(prop, prop.BackingFieldType),
                                          FormatFieldName(prop.Name),
                                          GetFieldInitValue(info, prop));
            }

            return response;
        }

        private string GetFieldInitValue(CslaObjectInfo info, ValueProperty prop)
        {
            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                prop.DeclarationMode == PropertyDeclaration.NoProperty)
                return GetInitValue(info, prop, prop.PropertyType);

            return GetInitValue(info, prop, prop.BackingFieldType);
        }

        public string PropertyInfoDeclare(CslaObjectInfo info, ValueProperty prop)
        {
            var response = String.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                var noSilverlightStatement = String.Empty;
                var silverlightStatement = String.Empty;
                if (UseNoSilverlight())
                    noSilverlightStatement = PropertyInfoDeclare(info, prop, false);
                if (UseSilverlight())
                    silverlightStatement = PropertyInfoDeclare(info, prop, true);
                if (UseBoth() && noSilverlightStatement != silverlightStatement)
                {
                    response += "#if SILVERLIGHT" + Environment.NewLine;
                    response += new string(' ', 8) +
                                "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" + Environment.NewLine;
                    response += new string(' ', 8) + silverlightStatement + Environment.NewLine;
                    response += "#else" + Environment.NewLine;
                    response += new string(' ', 8) + noSilverlightStatement + Environment.NewLine;
                    response += "#endif";
                }
                else if(UseNoSilverlight())
                {
                    response += new string(' ', 8) + noSilverlightStatement;
                }
                else
                {
                    response += new string(' ', 8) + silverlightStatement;
                }
            }

            return response;
        }

        private string PropertyInfoDeclare(CslaObjectInfo info, ValueProperty prop, bool isSilverlight)
        {
            // "private static readonly PropertyInfo<{0}> {1} = RegisterProperty<{0}>(p => p.{2}, \"{3}\"{4});",
            var response = string.Empty;

            if (!prop.Undoable &&
                prop.DeclarationMode != PropertyDeclaration.AutoProperty &&
                prop.DeclarationMode != PropertyDeclaration.ClassicProperty &&
                prop.DeclarationMode != PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += "[NotUndoable]" + Environment.NewLine + new string(' ', 8);
                ;
            }
            response +=
                String.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => {3}, \"{4}\"{5}{6});",
                    (isSilverlight || CurrentUnit.GenerationParams.UsePublicPropertyInfo) ? "public" : "private",
                    (prop.DeclarationMode == PropertyDeclaration.Managed ||
                     prop.DeclarationMode == PropertyDeclaration.Unmanaged)
                        ? GetDataTypeGeneric(prop, prop.PropertyType)
                        : GetDataTypeGeneric(prop, prop.BackingFieldType),
                    FormatPropertyInfoName(prop.Name),
                    (String.IsNullOrEmpty(prop.Implements)
                         ? "p." + FormatPascal(prop.Name)
                         : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) + ") p)." + FormatPascal(prop.Name)),
                    prop.FriendlyName,
                    GetDefault(info, prop),
                    GetRelationhipType(info, prop));

            return response;
        }

        private static string GetDefault(CslaObjectInfo info, ValueProperty prop)
        {
            if (HasCreateCriteriaDataPortal(info))
                return String.Empty;

            if (prop.DefaultValue != String.Empty)
                return ", " + prop.DefaultValue;

            if (!prop.Nullable)
                return String.Empty;

            return ", null";
        }

        private static bool HasCreateCriteriaDataPortal(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.CreateOptions.DataPortal && crit.Name != "CreatedByCslaGenFork")
                    return true;
            }

            return false;
        }

        private string GetRelationhipType(CslaObjectInfo info, ValueProperty prop)
        {
            if (IsReadOnlyType(info.ObjectType))
                return "";

            var response = String.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response = ", RelationshipTypes.PrivateField";
            }

            return response;
        }

        // TODO: check child properties are PropertyDeclaration.Managed

        public string PropertyInfoChildDeclare(CslaObjectInfo info, ChildProperty prop)
        {
            var response = String.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                var noSilverlightStatement = String.Empty;
                var silverlightStatement = String.Empty;
                if (UseNoSilverlight())
                    noSilverlightStatement = PropertyInfoChildDeclare(info, prop, false);
                if (UseSilverlight())
                    silverlightStatement = PropertyInfoChildDeclare(info, prop, true);
                if (UseBoth() && noSilverlightStatement != silverlightStatement)
                {
                    response += "#if SILVERLIGHT" + Environment.NewLine;
                    response += new string(' ', 8) +
                                "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" + Environment.NewLine;
                    response += new string(' ', 8) + silverlightStatement + Environment.NewLine;
                    response += "#else" + Environment.NewLine;
                    response += new string(' ', 8) + noSilverlightStatement + Environment.NewLine;
                    response += "#endif";
                }
                else if (UseNoSilverlight())
                {
                    response += new string(' ', 8) + noSilverlightStatement;
                }
                else
                {
                    response += new string(' ', 8) + silverlightStatement;
                }
            }

            return response;
        }

        private string PropertyInfoChildDeclare(CslaObjectInfo info, ChildProperty prop, bool isSilverlight)
        {
            // "private static readonly PropertyInfo<{0}> {1} = RegisterProperty<{0}>(p => p.{2}, \"{3}\"{4});",
            var response = string.Empty;

            if (!prop.Undoable &&
                prop.DeclarationMode != PropertyDeclaration.AutoProperty &&
                prop.DeclarationMode != PropertyDeclaration.ClassicProperty &&
                prop.DeclarationMode != PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += "[NotUndoable]" + Environment.NewLine + new string(' ', 8);
                ;
            }
            response +=
                String.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => {3}, \"{4}\"{5});",
                    (isSilverlight || CurrentUnit.GenerationParams.UsePublicPropertyInfo) ? "public" : "private",
                    prop.TypeName,
                    FormatPropertyInfoName(prop.Name),
                    (String.IsNullOrEmpty(prop.Implements)
                         ? "p." + FormatPascal(prop.Name)
                         : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) + ") p)." + FormatPascal(prop.Name)),
                    prop.FriendlyName,
                    GetRelationhipType(info, prop));

            return response;
        }

        public string PropertyInfoUoWDeclare(CslaObjectInfo info, UnitOfWorkProperty prop)
        {
            var response = String.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                var noSilverlightStatement = String.Empty;
                var silverlightStatement = String.Empty;
                if (UseNoSilverlight())
                    noSilverlightStatement = PropertyInfoUoWDeclare(info, prop, false);
                if (UseSilverlight())
                    silverlightStatement = PropertyInfoUoWDeclare(info, prop, true);
                if (UseBoth() && noSilverlightStatement != silverlightStatement)
                {
                    response += "#if SILVERLIGHT" + Environment.NewLine;
                    response += new string(' ', 8) +
                                "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" + Environment.NewLine;
                    response += new string(' ', 8) + silverlightStatement + Environment.NewLine;
                    response += "#else" + Environment.NewLine;
                    response += new string(' ', 8) + noSilverlightStatement + Environment.NewLine;
                    response += "#endif";
                }
                else if (UseNoSilverlight())
                {
                    response += new string(' ', 8) + noSilverlightStatement;
                }
                else
                {
                    response += new string(' ', 8) + silverlightStatement;
                }
            }

            return response;
        }

        public string PropertyInfoUoWDeclare(CslaObjectInfo info, UnitOfWorkProperty prop, bool isSilverlight)
        {
            // "private static readonly PropertyInfo<{0}> {1} = RegisterProperty<{0}>(p => p.{2}, \"{3}\"{4});",
            var response =
                String.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => p.{3});",
                    (isSilverlight || CurrentUnit.GenerationParams.UsePublicPropertyInfo) ? "public" : "private",
                    prop.TypeName,
                    FormatPropertyInfoName(prop.Name),
                    FormatPascal(prop.Name));

            return response;
        }

        private string GetRelationhipType(CslaObjectInfo info, ChildProperty prop)
        {
            if (IsReadOnlyType(info.ObjectType))
                return "";

            var response = String.Empty;

            if (prop.LazyLoad)
            {
                response += ", RelationshipTypes.Child | RelationshipTypes.LazyLoad";
            }
            else
            {
                response += ", RelationshipTypes.Child";
            }

            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged)
            {
                response += " | RelationshipTypes.PrivateField";
            }

            return response;
        }

        public string PropertyDeclare(CslaObjectInfo info, ValueProperty prop)
        {
            var response = String.Empty;
            bool isReadOnly = prop.ReadOnly;

            if (info.ObjectType == CslaObjectType.ReadOnlyObject && CurrentUnit.GenerationParams.ForceReadOnlyProperties)
            {
                isReadOnly = true;
            }
            else if (!String.IsNullOrEmpty(prop.Implements))
            {
                isReadOnly = false;
            }

            var convertPropertyName = string.Empty;
            if (prop.DeclarationMode != PropertyDeclaration.AutoProperty)
            {
                foreach (var convertProperty in info.ConvertValueProperties)
                {
                    if (convertProperty.SourcePropertyName == prop.Name)
                    {
                        convertPropertyName = convertProperty.Name;
                        break;
                    }
                }
            }

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response = String.Format("{0}{1} {2}" + Environment.NewLine,
                                         (String.IsNullOrEmpty(prop.Implements) ? GetPropertyAccess(prop) + " " : ""),
                                         GetDataTypeGeneric(prop, prop.PropertyType),
                                         (String.IsNullOrEmpty(prop.Implements) ? FormatPascal(prop.Name) : prop.Implements));
                response += "        {" + Environment.NewLine;
                response += PropertyDeclareGetter(prop);

                response += PropertyDeclareSetter(isReadOnly, info.ObjectType == CslaObjectType.ReadOnlyObject, prop, convertPropertyName);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                     prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += String.Format("{0}{1} {2}" + Environment.NewLine,
                                          (String.IsNullOrEmpty(prop.Implements) ? GetPropertyAccess(prop) + " " : ""),
                                          GetDataTypeGeneric(prop, prop.PropertyType),
                                          (String.IsNullOrEmpty(prop.Implements) ? FormatPascal(prop.Name) : prop.Implements));
                response += "        {" + Environment.NewLine;
                response += PropertyDeclareGetter(prop);

                response += PropertyDeclareSetter(isReadOnly, info.ObjectType == CslaObjectType.ReadOnlyObject, prop, convertPropertyName);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += String.Format("{0}{1} {2} {{ get; {3}set; }}",
                                          (String.IsNullOrEmpty(prop.Implements) ? GetPropertyAccess(prop) + " " : ""),
                                          GetDataTypeGeneric(prop, prop.PropertyType),
                                          (String.IsNullOrEmpty(prop.Implements) ? FormatPascal(prop.Name) : prop.Implements),
                                          PropertyDeclareSetter(isReadOnly, info.ObjectType == CslaObjectType.ReadOnlyObject, prop, string.Empty));
            }

            return response;
        }

        public string PropertyConvertDeclare(CslaObjectInfo info, ConvertValueProperty prop)
        {
            var sourceProperty = info.ValueProperties.Find(prop.SourcePropertyName);
//            var sourceDeclarationMode = sourceProperty.DeclarationMode;
            var response = String.Empty;
            var isReadOnly = prop.ReadOnly;

            if (info.ObjectType == CslaObjectType.ReadOnlyObject && CurrentUnit.GenerationParams.ForceReadOnlyProperties)
            {
                isReadOnly = true;
            }

            response += String.Format("{0} {1} {2}" + Environment.NewLine,
                                      GetPropertyAccess(prop),
                                      GetDataTypeGeneric(prop, prop.PropertyType),
                                      FormatPascal(prop.Name));
            response += "        {" + Environment.NewLine;
            response += "            get" + Environment.NewLine;
            response += "            {" + Environment.NewLine;
            response += "                var result = " + GetInitValue(prop.PropertyType) + ";" + Environment.NewLine;
            response += "                if (" + (sourceProperty.Nullable ? sourceProperty.Name + ".HasValue && " : string.Empty) + prop.NVLConverter + "().ContainsKey(" + prop.SourcePropertyName + (sourceProperty.Nullable ? ".Value" : string.Empty) + "))" + Environment.NewLine;
            response += "                    result = " + prop.NVLConverter + "().GetItemByKey(" + prop.SourcePropertyName + (sourceProperty.Nullable ? ".Value" : string.Empty) + ").Value;" + Environment.NewLine;
//            response += "                if (" + prop.NVLConverter + "().ContainsKey(ReadProperty(" + prop.SourcePropertyName + "Property)))" + Environment.NewLine;
//            response += "                    result = " + prop.NVLConverter + "().GetItemByKey(ReadProperty(" + prop.SourcePropertyName + "Property)).Value;" + Environment.NewLine;
            response += "                return result;" + Environment.NewLine;
            response += "            }" + Environment.NewLine;

            if (!isReadOnly)
            {
                response += "            set" + Environment.NewLine;
                response += "            {" + Environment.NewLine;
                response += "                if (" + prop.NVLConverter + "().ContainsValue(value))" + Environment.NewLine;
                response += "                {" + Environment.NewLine;
                response += "                    var result = " + prop.NVLConverter + "().GetItemByValue(value).Key;" + Environment.NewLine;
                response += "                    if (result != " + prop.SourcePropertyName + ")" + Environment.NewLine;
                response += "                        " + prop.SourcePropertyName + " = result;" + Environment.NewLine;
//                response += "                    if (result != ReadProperty(" + prop.SourcePropertyName + "Property))" + Environment.NewLine;
//                response += "                        SetProperty(" + prop.SourcePropertyName + "Property, result);" + Environment.NewLine;
                response += "                }" + Environment.NewLine;
                response += "            }" + Environment.NewLine;
            }
            response += "        }";

            return response;
        }

        private string PropertyDeclareGetter(ValueProperty prop)
        {
            var isConversion = (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion);

            var response = String.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response += String.Format("            get {{ return {0}{1}({2}); }}{3}",
                                          isConversion
                                              ? "GetPropertyConvert"
                                              : "GetProperty",
                                          isConversion
                                              ? "<" + prop.BackingFieldType + ", " + prop.PropertyType + ">"
                                              : "",
                                          (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                                           prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
                                              ? FormatPropertyInfoName(prop.Name) + ", " + FormatFieldName(prop.Name)
                                              : FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
            }
            else
            {
                response += String.Format("            get {{ return {0}; }}{1}",
                    FormatFieldName(prop.Name),
                    Environment.NewLine);
            }

            return response;
        }

        private string PropertyDeclareSetter(bool isReadOnly, bool isReadOnlyObject, ValueProperty prop, string convertPropertyName)
        {
            if (isReadOnly &&
                (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                 prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                 prop.DeclarationMode == PropertyDeclaration.Managed ||
                 prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                 prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                 prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion))
            {
                return "";
            }

            var convertSnippetPre = " {";
            var convertSnippet = string.Empty;
            var convertSnippetPost = " }" + Environment.NewLine;
            if (convertPropertyName != string.Empty)
            {
                convertSnippetPre = Environment.NewLine + "            {" + Environment.NewLine + "               ";
                convertSnippet = Environment.NewLine + "                OnPropertyChanged(\"" + convertPropertyName + "\");";
                convertSnippetPost = Environment.NewLine + "            }" + Environment.NewLine;
            }

            var response = String.Empty;
            var isConversion = (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                                prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion);

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response += String.Format("            {0}set{1} {2}{3}({4}, value);{5}{6}",
                                          PropertyDeclareSetterVisibility(isReadOnly, prop),
                                          convertSnippetPre,
                                          PropertyDeclareSetterMethod(isReadOnly, isReadOnlyObject, isConversion),
                                          isConversion
                                              ? "<" + prop.BackingFieldType + ", " + prop.PropertyType + ">"
                                              : "",
                                          (!isReadOnly && (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                                                           prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion))
                                              ? FormatPropertyInfoName(prop.Name) + ", ref " +
                                                FormatFieldName(prop.Name)
                                              : FormatPropertyInfoName(prop.Name),
                                              convertSnippet,
                                              convertSnippetPost);
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                     prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += String.Format("            {0}set{1} {2} = value;{3}{4}",
                                          PropertyDeclareSetterVisibility(isReadOnly, prop),
                                          convertSnippetPre,
                                          FormatFieldName(prop.Name) + ConvertTextToSmartDate(prop),
                                          convertSnippet,
                                          convertSnippetPost);
            }
            else if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += PropertyDeclareSetterVisibility(isReadOnly, prop);
            }

            return response;
        }

        private string PropertyDeclareSetterVisibility(bool isReadOnly, ValueProperty prop)
        {
            if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                if (isReadOnly ||
                    prop.PropSetAccessibility == AccessorVisibility.Private ||
                    prop.PropSetAccessibility == AccessorVisibility.NoSetter)
                {
                    return "private ";
                }
            }
            else if (isReadOnly)
            {
                return prop.PropSetAccessibility == AccessorVisibility.Private
                           ? "private "
                           : "";
            }

            var response = GetAccessorVisibility(prop);

            if (response == GetPropertyAccess(prop))
                return "";

            return response + "";
        }

        private static string PropertyDeclareSetterMethod(bool isReadOnly, bool isReadOnlyObject, bool isConversion)
        {
            if (isConversion)
            {
                if (isReadOnly || isReadOnlyObject)
                    return "LoadPropertyConvert";
                
                return "SetPropertyConvert";
            }

            if (isReadOnly || isReadOnlyObject)
                return "LoadProperty";

            return "SetProperty";
        }

        public string CheckNotUndoable(ValueProperty prop)
        {
            var response = String.Empty;
            if (!prop.Undoable)
                response = "[NotUndoable]" + Environment.NewLine + "        ";

            return response;
        }

        #endregion

        #region Field Reader

        public string GetFieldReaderStatement(ValueProperty prop)
        {
            return GetFieldReaderStatement(prop.DeclarationMode, prop.Name);
        }

        public string GetFieldReaderStatement(ChildProperty prop)
        {
            return GetFieldReaderStatement(prop.DeclarationMode, prop.Name);
        }

        public string GetFieldReaderStatement(CslaObjectInfo info, UpdateValueProperty prop)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.Name == valueProp.Name)
                    return GetFieldReaderStatement(valueProp.DeclarationMode, valueProp.Name);
            }
            foreach (var childProp in info.GetCollectionChildProperties())
            {
                if (prop.Name == childProp.Name)
                    return GetFieldReaderStatement(childProp.DeclarationMode, childProp.Name);
            }

            return FormatFieldName(prop.Name);
        }

        public string GetFieldReaderStatement(CslaObjectInfo info, ConvertValueProperty prop)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.Name == valueProp.Name)
                    return GetFieldReaderStatement(valueProp.DeclarationMode, valueProp.Name);
            }
            foreach (var childProp in info.GetCollectionChildProperties())
            {
                if (prop.Name == childProp.Name)
                    return GetFieldReaderStatement(childProp.DeclarationMode, childProp.Name);
            }

            return FormatFieldName(prop.Name);
        }

        public string GetFieldReaderStatement(CslaObjectInfo info, string propName)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (propName == valueProp.Name)
                    return GetFieldReaderStatement(valueProp.DeclarationMode, valueProp.Name);
            }

            return FormatFieldName(propName);
        }

        public string GetFieldReaderStatement(PropertyDeclaration propDeclarationMode, string propName)
        {
            /*if (propDeclarationMode == PropertyDeclaration.AutoProperty ||
                CurrentUnit.GenerationParams.UseBypassPropertyChecks)*/

            if (propDeclarationMode == PropertyDeclaration.AutoProperty)
            {
                return String.Format(FormatProperty(propName));
            }

            if (propDeclarationMode == PropertyDeclaration.Managed ||
                propDeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
            {
                return String.Format("ReadProperty({0})", FormatPropertyInfoName(propName));
            }

            return FormatFieldName(propName);
        }

        public ValueProperty GetSourceValueProperty(CslaObjectInfo info, ConvertValueProperty prop)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.SourcePropertyName == valueProp.Name)
                    return valueProp;
            }
            /*foreach (var childProp in info.GetCollectionChildProperties())
            {
                if (prop.Name == childProp.Name)
                    return GetFieldReaderStatement(childProp.DeclarationMode, childProp.Name);
            }*/

            return null;
            //            return GetFieldReaderStatement(prop.SourceDeclarationMode, prop.SourcePropertyName);
        }

        #endregion

        #region Field Loader

        public virtual string GetDataSetLoaderStatement(ValueProperty prop)
        {
            var statement = String.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                statement += String.Format("{0} = {1} dr[\"{2}\"]{3}",
                                           FormatProperty(prop.Name),
                                           (prop.PropertyType == TypeCodeEx.SmartDate)
                                               ? "new SmartDate((DateTime)"
                                               : "(" + GetDataType(prop) + ")",
                                           prop.ParameterName,
                                           (prop.PropertyType == TypeCodeEx.SmartDate)
                                               ? ")"
                                               : "");
            }
            else
            {
                statement += String.Format("LoadProperty({0}, {1} dr[\"{2}\"]{3})",
                                           FormatPropertyInfoName(prop.Name),
                                           (prop.PropertyType == TypeCodeEx.SmartDate)
                                               ? "new SmartDate((DateTime)"
                                               : "(" + GetDataType(prop) + ")",
                                           prop.ParameterName,
                                           (prop.PropertyType == TypeCodeEx.SmartDate)
                                               ? ")"
                                               : "");
            }

            return statement;
        }

        public virtual string GetDataReaderLoaderStatement(ValueProperty prop)
        {
            var statement = String.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                statement += String.Format("{0} = {1}",
                                           FormatProperty(prop.Name),
                                           GetDataReaderStatement(prop));
            }
            else
            {
                statement += String.Format("LoadProperty({0}, {1})",
                                           FormatPropertyInfoName(prop.Name),
                                           GetDataReaderStatement(prop));
            }

            return statement;
        }

        public string GetFieldLoaderStatement(ValueProperty prop, string value)
        {
            return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, value);
        }

        public string GetFieldLoaderStatement(ChildProperty prop, string value)
        {
            return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, value);
        }

        public string GetFieldLoaderStatement(UnitOfWorkProperty prop, string value)
        {
            return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, value);
        }

        /// <summary>
        /// Gets the field loader statement evaluating <paramref name="value"/> parameter using the GetFieldLoaderStatement.
        /// </summary>
        /// <param name="info">The info object.</param>
        /// <param name="prop">The property to assign the <paramref name="value"/>.</param>
        /// <param name="value">If it starts with "$" it is evaluated as a property reference and the GetFieldLoaderStatement is used to get the final form of value.</param>
        /// <returns>The loader statemente on the form <code>_prop = value</code> or <code>LoadProperty(PropProperty, value)</code>.</returns>
        public string GetFieldLoaderStatement(CslaObjectInfo info, ValueProperty prop, string value)
        {
            if (value.IndexOf("$") != 0)
                return GetFieldLoaderStatement(prop, value);

            var propSource = value.Substring(1);

            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (propSource == valueProp.Name)
                    return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, GetFieldReaderStatement(valueProp));
            }
            foreach (var childProp in info.GetAllChildProperties())
            {
                if (propSource == childProp.Name)
                    return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, GetFieldReaderStatement(childProp));
            }

            return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);
        }

        public string GetFieldLoaderStatement(CslaObjectInfo info, UpdateValueProperty prop, string value)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.SourcePropertyName == valueProp.Name)
                    return GetFieldLoaderStatement(valueProp.DeclarationMode, prop.Name + ConvertTextToSmartDate(valueProp), value);
            }
            foreach (var childProp in info.GetAllChildProperties())
            {
                if (prop.SourcePropertyName == childProp.Name)
                    return GetFieldLoaderStatement(childProp.DeclarationMode, prop.Name, value);
            }

            return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);
        }

        public string GetFieldLoaderStatement(CslaObjectInfo info, ConvertValueProperty prop, string value)
        {
            foreach (var valueProp in info.GetAllValueProperties())
            {
                if (prop.SourcePropertyName == valueProp.Name)
                    return GetFieldLoaderStatement(prop.DeclarationMode, prop.Name, value);
            }
            foreach (var childProp in info.GetAllChildProperties())
            {
                if (prop.SourcePropertyName == childProp.Name)
                    return GetFieldLoaderStatement(childProp.DeclarationMode, prop.Name, value);
            }

            return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);
        }

        public string GetFieldLoaderStatement(PropertyDeclaration propDeclarationMode, string propName, string value)
        {
            /*if (propDeclarationMode == PropertyDeclaration.AutoProperty ||
                CurrentUnit.GenerationParams.UseBypassPropertyChecks)*/
            if (propDeclarationMode == PropertyDeclaration.AutoProperty)
            {
                return String.Format("{0} = {1}", FormatProperty(propName), value);
            }

            if (propDeclarationMode == PropertyDeclaration.Managed ||
                propDeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
            {
                return String.Format("LoadProperty({0}, {1})", FormatPropertyInfoName(propName), value);
            }

            return String.Format("{0} = {1}", FormatFieldName(propName), value);
        }

        #endregion

        #region Object's Collection Child listing

        /// <summary>
        /// Gets collection child objects of a CslaObjectInfo.
        /// Gets the collection child and inherited collection child properties.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A CslaObjectInfo array holding the objects for collection child properties.</returns>
        public CslaObjectInfo[] GetCollectionChildItems(CslaObjectInfo info)
        {
            var list = new List<CslaObjectInfo>();
            foreach (var cp in info.GetCollectionChildProperties())
            {
                var ci = FindChildInfo(info, cp.TypeName);
                if (ci != null)
                {
                    /*if (IsCollectionType(ci.ObjectType))
                    {
                        ci = FindChildInfo(info, ci.ItemType);
                    }*/
                    ci = FindChildInfo(info, ci.ItemType);
                    if (ci != null)
                        list.Add(ci);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets the parent load collection child objects of a CslaObjectInfo.
        /// Gets the collection child and inherited collection child properties.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A CslaObjectInfo array holding the objects for parent load collection child properties.</returns>
        public CslaObjectInfo[] GetParentLoadCollectionChildObjects(CslaObjectInfo info)
        {
            var list = new List<CslaObjectInfo>();
            foreach (var cp in info.GetCollectionChildProperties())
            {
                if (cp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    var ci = FindChildInfo(info, cp.TypeName);
                    if (ci != null)
                    {
                        /*if (IsCollectionType(ci.ObjectType))
                        {
                            ci = FindChildInfo(info, ci.ItemType);
                        }*/
                        ci = FindChildInfo(info, ci.ItemType);
                        if (ci != null)
                            list.Add(ci);
                    }
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets the parent load collection child properties of a CslaObjectInfo.
        /// Gets the collection child and inherited collection child properties.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A ChildPropertyCollection holding the objects for parent load collection child properties.</returns>
        public ChildPropertyCollection GetParentLoadCollectionChildProperties(CslaObjectInfo info)
        {
            var list = new ChildPropertyCollection();
            foreach (var cp in info.GetCollectionChildProperties())
            {
                if (cp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    list.Add(cp);
                }
            }
            return list;
        }

        /// <summary>
        /// Gets the full hierarchy of collection child object names of a CslaObjectInfo.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A string array holding the objects for the hierarchy of collection child properties.</returns>
        public string[] GetCollectionChildItemsInHierarchy(CslaObjectInfo info)
        {
            var list = new List<string>();
            foreach (var obj in GetCollectionChildItems(info))
            {
                list.Add(obj.ObjectName);
                list.AddRange(GetCollectionChildItemsInHierarchy(obj));
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets the full hierarchy of parent load collection child properties of a CslaObjectInfo.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A ChildPropertyCollection holding the hierarchy of parent load collection child objects.</returns>
        public ChildPropertyCollection GetParentLoadCollectionChildPropertiesInHierarchy(CslaObjectInfo info)
        {
            var list = new ChildPropertyCollection();
            foreach (var obj in GetParentLoadCollectionChildProperties(info))
            {
                list.Add(obj);
                var childObject = FindChildInfo(info, obj.TypeName);
                if (childObject != null)
                {
                    childObject = FindChildInfo(info, childObject.ItemType);
                    if (childObject != null)
                        list.AddRange(GetParentLoadCollectionChildPropertiesInHierarchy(childObject));
                }
            }
            return list;
        }

        #endregion

        #region Object's All Child listing

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
                var ci = FindChildInfo(info, cp.TypeName);
                if (ci != null)
                {
                    ci = FindChildInfo(info, ci.ItemType);
                    if (ci != null)
                        list.Add(ci);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets all parent load child objects of a CslaObjectInfo.
        /// Gets all child properties: collection and non-collection, including inherited.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A CslaObjectInfo array holding the objects for all parent load child properties.</returns>
        public CslaObjectInfo[] GetParentLoadAllChildObjects(CslaObjectInfo info)
        {
            var list = new List<CslaObjectInfo>();
            foreach (var cp in info.GetAllChildProperties())
            {
                if (cp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    var ci = FindChildInfo(info, cp.TypeName);
                    if (ci != null)
                    {
                        ci = FindChildInfo(info, ci.ItemType);
                        if (ci != null)
                            list.Add(ci);
                    }
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Gets all parent load child properties of a CslaObjectInfo.
        /// Gets all child properties: collection and non-collection, including inherited.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A ChildPropertyCollection holding the objects for all parent load child properties.</returns>
        public ChildPropertyCollection GetParentLoadAllChildProperties(CslaObjectInfo info)
        {
            var list = new ChildPropertyCollection();
            foreach (var cp in info.GetAllChildProperties())
            {
                if (cp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    list.Add(cp);
                }
            }
            return list;
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

        /*/// <summary>
        /// Gets the full hierarchy of parent load collection child properties of a CslaObjectInfo.
        /// </summary>
        /// <param name="info">The CslaOnjectInfo.</param>
        /// <returns>A ChildPropertyCollection holding for the hierarchy of parent load all child objects.</returns>
        public ChildPropertyCollection GetParentLoadAllChildPropertiesInHierarchy(CslaObjectInfo info)
        {
            var list = new ChildPropertyCollection();
            foreach (var obj in GetParentLoadAllChildProperties(info))
            {
                list.Add(obj);
                var childObject = FindChildInfo(info, obj.TypeName);
                if (childObject != null)
                {
                    childObject = FindChildInfo(info, childObject.ItemType);
                    if (childObject != null)
                        list.AddRange(GetParentLoadAllChildPropertiesInHierarchy(childObject));
                }
            }
            return list;
        }*/

        public ChildPropertyCollection GetParentLoadAllChildPropertiesInHierarchy(CslaObjectInfo info)
        {
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            var list = new ChildPropertyCollection();
            foreach (var childProp in info.GetAllChildProperties())
            {
                list.Add(childProp);
                var childInfo = FindChildInfo(info, childProp.TypeName);
                if (childInfo != null && childProp.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    list.AddRange(GetParentLoadAllChildPropertiesInHierarchy(childInfo));
                }
            }

            return list;
        }

        public ChildPropertyCollection GetParentLoadAllGrandChildPropertiesInHierarchy(CslaObjectInfo info, bool firstRun)
        {
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            var list = new ChildPropertyCollection();
            foreach (var childProp in info.GetAllChildProperties())
            {
                if (!firstRun)
                    list.Add(childProp);

                var childInfo = FindChildInfo(info, childProp.TypeName);
                if (childInfo != null && childProp.LoadingScheme == LoadingScheme.ParentLoad)
                {

                    list.AddRange(GetParentLoadAllGrandChildPropertiesInHierarchy(childInfo, false));
                }
            }

            return list;
        }

        #endregion

        #region Child handling

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

        public static bool IsChildSelfNotLoaded(CslaObjectInfo info)
        {
            var selfLoadNone = false;
            var parent = info.Parent.CslaObjects.Find(info.ParentType);
            if (parent != null)
            {
                foreach (var childProp in parent.ChildCollectionProperties)
                {
                    if (childProp.TypeName == info.ObjectName)
                    {
                        selfLoadNone = childProp.LoadingScheme == LoadingScheme.None;
                        break;
                    }
                }
            }

            return selfLoadNone;
        }

        public static bool IsChildLazyLoaded(CslaObjectInfo info)
        {
            var lazyLoad = false;
            var parent = info.Parent.CslaObjects.Find(info.ParentType);
            if (parent != null)
            {
                foreach (var childProp in parent.ChildCollectionProperties)
                {
                    if (childProp.TypeName == info.ObjectName)
                    {
                        lazyLoad = childProp.LazyLoad;
                        break;
                    }
                }
            }

            return lazyLoad;
        }

        public int AncestorLoaderLevel(CslaObjectInfo info, out bool ancestorIsCollection)
        {
            return FindAncestorLoaderLevel(info, 0, out ancestorIsCollection);
        }

        private static int FindAncestorLoaderLevel(CslaObjectInfo info, int level, out bool ancestorIsCollection)
        {
            if (IsCollectionType(info.ObjectType))
                ancestorIsCollection = true;
            else
                ancestorIsCollection = false;

            if (info.ParentType == string.Empty) // no parent specified; this is the last ancestor
                return level;

            var parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
            if (parentInfo == null) // there is no ancestor object; for all purposes, this is the last ancestor
                return level;

            level++;
            if (IsCollectionType(parentInfo.ObjectType)) // is a collection; so find the next ancestor
                return FindAncestorLoaderLevel(parentInfo, level, out ancestorIsCollection);

            ancestorIsCollection = false;

            if (info.ParentType == string.Empty) // no parent specified; this is the last ancestor
                return level;

            foreach (var childProperty in parentInfo.GetAllChildProperties())
            {
                if (childProperty.TypeName == info.ObjectName || childProperty.TypeName == info.ParentType)
                {
                    // no ParentLoad; this is the last ancestor
                    if (childProperty.LoadingScheme != LoadingScheme.ParentLoad)
                        return level;

                    // is ParentLoad; so find the next ancestor
                    if (childProperty.LoadingScheme == LoadingScheme.ParentLoad)
                        return FindAncestorLoaderLevel(parentInfo, level, out ancestorIsCollection);
                }
            }

            // strange enough, this object doesn't exist as a child of its parent
            return level;
        }

        public static PropertyDeclaration GetDeclarationMode(CslaObjectInfo info)
        {
            var declarationMode = PropertyDeclaration.NoProperty;

            var parent = info.Parent.CslaObjects.Find(info.ParentType);
            if (parent != null)
            {
                foreach (var childProp in parent.ChildCollectionProperties)
                {
                    if (childProp.TypeName == info.ObjectName)
                    {
                        declarationMode = childProp.DeclarationMode;
                        break;
                    }
                }
            }

            return declarationMode;
        }

        public virtual string GetNewChildLoadStatement(ChildProperty prop, bool isDataPortalCreate)
        {
            var value = prop.TypeName + ".New" + prop.TypeName + "()";

            if (!isDataPortalCreate && prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);

            if (!isDataPortalCreate && prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                return String.Format("{0} = {1}", FormatProperty(prop.Name), value);

            value = String.Format("DataPortal.CreateChild<{0}>()", prop.TypeName);

            if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);

            return GetFieldLoaderStatement(prop, value);
        }

        public virtual string GetExistingChildLoadStatement(ChildProperty prop)
        {
            var value = prop.TypeName + ".Get" + prop.TypeName + "()";

            if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);

            if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                return String.Format("{0} = {1}", FormatProperty(prop.Name), value);

            value = String.Format("DataPortal.FetchChild<{0}>()", prop.TypeName);
            return GetFieldLoaderStatement(prop, value);
        }

        public string ChildPropertyDeclare(CslaObjectInfo info, ChildProperty prop)
        {
            var response = String.Empty;

            var isReadOnly = false;

            if (prop.ReadOnly)
                isReadOnly = true;

            if (info.ObjectType == CslaObjectType.ReadOnlyObject)
            {
                if (prop.DeclarationMode == PropertyDeclaration.AutoProperty ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                {
                    if (CurrentUnit.GenerationParams.ForceReadOnlyProperties)
                    {
                        isReadOnly = true;
                    }
                }
                else
                {
                    isReadOnly = true;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(prop.Implements))
                {
                    isReadOnly = false;
                }
            }

            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                response += String.Format("{0}{1} {2}" + Environment.NewLine,
                                          (String.IsNullOrEmpty(prop.Implements) ? GetPropertyAccess(prop) + " " : ""),
                                          prop.TypeName,
                                          (String.IsNullOrEmpty(prop.Implements) ? FormatPascal(prop.Name) : prop.Implements));
                response += "        {" + Environment.NewLine;
                response += ChildPropertyDeclareGetter(info, prop);

                response += ChildPropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += String.Format("{0}{1} {2}" + Environment.NewLine,
                                          (String.IsNullOrEmpty(prop.Implements) ? GetPropertyAccess(prop) + " " : ""),
                                          prop.TypeName,
                                          (String.IsNullOrEmpty(prop.Implements) ? FormatPascal(prop.Name) : prop.Implements));
                response += "        {" + Environment.NewLine;
                response += ChildPropertyDeclareGetter(info, prop);

                response += ChildPropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else  //if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += String.Format("{0}{1} {2} {{ get; {3}set; }}",
                          (String.IsNullOrEmpty(prop.Implements) ? GetPropertyAccess(prop) + " " : ""),
                          prop.TypeName,
                          (String.IsNullOrEmpty(prop.Implements) ? FormatPascal(prop.Name) : prop.Implements),
                          isReadOnly ? "private " : "");
            }

            return response;
        }

        private string ChildPropertyDeclareGetter(CslaObjectInfo info, ChildProperty prop)
        {
            if (prop.LazyLoad)
            {
                return ChildPropertyDeclareGetterLazyLoad(info, prop);
            }

            // this is LoadingScheme.ParentLoad or LoadingScheme.SelfLoad
            string response;

            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                response = String.Format("            get {{ return GetProperty({0}); }}" + Environment.NewLine,
                                          FormatPropertyInfoName(prop.Name));
            }
            else //if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response = String.Format("            get {{ return {0}; }}" + Environment.NewLine,
                                          FormatFieldName(prop.Name));
            }

            return response;
        }

        private string ChildPropertyDeclareGetterLazyLoad(CslaObjectInfo info, ChildProperty prop)
        {
            var isReadOnly = false;

            if (prop.ReadOnly)
            {
                isReadOnly = true;
            }

            if (info.ObjectType == CslaObjectType.ReadOnlyObject)
            {
                if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                {
                    if (CurrentUnit.GenerationParams.ForceReadOnlyProperties)
                    {
                        isReadOnly = true;
                    }
                }
                else
                {
                    isReadOnly = true;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(prop.Implements))
                {
                    isReadOnly = false;
                }
            }

            var response = String.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += "            get" + Environment.NewLine;
                response += "            {" + Environment.NewLine;
                response += ChildPropertyDeclareGetLazyLoad(info, prop);
                response += "            }" + Environment.NewLine;
                response += String.Format("            {0}set{1}",
                    ChildPropertyDeclareSetterVisibility(isReadOnly, prop),
                    Environment.NewLine);
                response += "            {" + Environment.NewLine;
                response += ChildPropertyDeclareSetLazyLoad(prop);
                response += "            }" + Environment.NewLine;
            }

            return response;
        }

        private string ChildPropertyDeclareGetLazyLoad(CslaObjectInfo info, ChildProperty prop)
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                return ChildLazyLoadManaged(info, prop);
            }

            return ChildLazyLoadClassic(info, prop);
        }

        private string ChildPropertyDeclareSetter(bool isReadOnly, ChildProperty prop)
        {
            if (prop.LazyLoad)
            {
                return "";
            }

            var response = String.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                response += String.Format("            {0}set {{ {1}({2}, value); }}{3}",
                                          ChildPropertyDeclareSetterVisibility(isReadOnly, prop),
                                          ChildPropertyDeclareSetterMethod(isReadOnly),
                                          FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
            }
            else //if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += String.Format("            {0}set {{ {1} = value; }}{2}",
                                          ChildPropertyDeclareSetterVisibility(isReadOnly, prop),
                                          FormatFieldName(prop.Name),
                                          Environment.NewLine);
            }

            return response;
        }

        private string ChildPropertyDeclareSetterVisibility(bool isReadOnly, ChildProperty prop)
        {
            if (isReadOnly)
            {
                return prop.Access == PropertyAccess.IsPrivate
                           ? ""
                           : "private ";
            }

            return "";
        }

        private static string ChildPropertyDeclareSetterMethod(bool isReadOnly)
        {
            if (isReadOnly)
                return "LoadProperty";

            return "SetProperty";
        }

        public string CheckNotUndoable(ChildProperty prop)
        {
            var response = String.Empty;
            if (!prop.Undoable)
                response = "[NotUndoable]" + Environment.NewLine + "        ";

            return response;
        }

        private string ChildPropertyDeclareSetLazyLoad(ChildProperty prop)
        {
            var response = String.Empty;
            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response += String.Format("                LoadProperty({0}, value);{1}", FormatPropertyInfoName(prop.Name), Environment.NewLine);
                response += String.Format("                OnPropertyChanged({0});{1}", FormatPropertyInfoName(prop.Name), Environment.NewLine);
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += String.Format("                {0} = value;{1}", FormatFieldName(prop.Name), Environment.NewLine);
                response += String.Format("                OnPropertyChanged(\"{0}\");{1}", FormatPascal(prop.Name), Environment.NewLine);
            }

            return response;
        }

        private string ChildLazyLoadManaged(CslaObjectInfo info, ChildProperty prop)
        {
            if (IsEditableType(info.ObjectType))
                return ChildLazyLoadManagedEditable(info, prop);

            return ChildLazyLoadManagedReadOnly(info, prop);
        }

        private string ChildLazyLoadManagedEditable(CslaObjectInfo info, ChildProperty prop)
        {
            var response = String.Empty;

            if (UseSilverlight() &&
                (CurrentUnit.GenerationParams.GenerateSynchronous ||
                !CurrentUnit.GenerationParams.GenerateAsynchronous))
            {
                /* Editable Silverlight using services

                if (!FieldManager.FieldExists(ChildrenProperty))
                {
                    LoadProperty(ChildrenProperty, null);
                    if (this.IsNew)
                    {
                        DataPortal.BeginCreate<ChildType>((o, e) =>
                            {
                                if (e.Error != null)
                                    throw e.Error;
                                else
                                {
                                    // set the property so OnPropertyChanged is raised
                                    Children = e.Object;
                                }
                            }, DataPortal.ProxyModes.LocalOnly);
                        return null;
                    }
                    else
                    {
                        DataPortal.BeginFetch<ChildType>(this, (o, e) =>
                            {
                                if (e.Error != null)
                                    throw e.Error;
                                else
                                {
                                    // set the property so OnPropertyChanged is raised
                                    Children = e.Object;
                                }
                            });
                        return null;
                    }
                }
                else
                {
                    return GetProperty(ChildrenProperty);
                }*/

                response += (UseNoSilverlight() ? "#if SILVERLIGHT" + Environment.NewLine : "");
                response += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                {" + Environment.NewLine;
                response += String.Format("                    LoadProperty({0}, null);" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                    if (this.IsNew)" + Environment.NewLine;
                response += "                    {" + Environment.NewLine;
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += String.Format("                        {0}.New{0}((o, e) =>" + Environment.NewLine,
                    prop.TypeName);
                else
                    response += string.Format("                        DataPortal.BeginCreate<{0}>((o, e) =>" + Environment.NewLine,
                    prop.TypeName);
                response += "                            {" + Environment.NewLine;
                response += "                                if (e.Error != null)" + Environment.NewLine;
                response += "                                    throw e.Error;" + Environment.NewLine;
                response += "                                else" + Environment.NewLine;
                response += "                                {" + Environment.NewLine;
                response += "                                    // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += String.Format("                                    {0} = e.Object;" + Environment.NewLine,
                                          (String.IsNullOrEmpty(prop.Implements)
                                               ? FormatPascal(prop.Name)
                                               : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                                                 ") this)." + FormatPascal(prop.Name)));
                response += "                                }" + Environment.NewLine;
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += "                            });" + Environment.NewLine;
                else
                    response += "                            }, DataPortal.ProxyModes.LocalOnly);" + Environment.NewLine;
                response += "                        return null;" + Environment.NewLine;
                response += "                    }" + Environment.NewLine;
                response += "                    else" + Environment.NewLine;
                response += "                    {" + Environment.NewLine;
                if(CurrentUnit.GenerationParams.UseChildFactory)
                    response += String.Format("                        {0}.Get{0}({1}, (o, e) =>" +
                    Environment.NewLine, prop.TypeName, GetFieldReaderStatementList(info, prop));
                else
                    response += string.Format("                        DataPortal.BeginFetch<{0}>({1}, (o, e) =>" +
                    Environment.NewLine, prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += "                            {" + Environment.NewLine;
                response += "                                if (e.Error != null)" + Environment.NewLine;
                response += "                                    throw e.Error;" + Environment.NewLine;
                response += "                                else" + Environment.NewLine;
                response += "                                {" + Environment.NewLine;
                response += "                                    // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += String.Format("                                    {0} = e.Object;" + Environment.NewLine,
                                          (String.IsNullOrEmpty(prop.Implements)
                                               ? FormatPascal(prop.Name)
                                               : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                                                 ") this)." + FormatPascal(prop.Name)));
                response += "                                }" + Environment.NewLine;
                if (!CurrentUnit.GenerationParams.UseChildFactory && CurrentUnit.GenerationParams.SilverlightUsingServices)
                    response += "                            }, DataPortal.ProxyModes.LocalOnly);" + Environment.NewLine;
                else
                    response += "                            });" + Environment.NewLine;
                response += "                        return null;" + Environment.NewLine;
                response += "                    }" + Environment.NewLine;
                response += "                }" + Environment.NewLine;
                response += "                else" + Environment.NewLine;
                response += "                {" + Environment.NewLine;
                response += "    " + ChildPropertyDeclareGetReturner(prop);
                response += "                }" + Environment.NewLine;
                response += (UseNoSilverlight() ? "#else" + Environment.NewLine : "");
            }

            if (CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                /* Editable Synchronous

                if (!FieldManager.FieldExists(ChildrenProperty))
                    if (this.IsNew)
                        Children = ChildType.NewChildType();
                    else
                        Children = ChildType.GetChildType(this);

                return GetProperty(ChildrenProperty);*/

                response += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                    if (this.IsNew)" + Environment.NewLine;
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += String.Format("                        {0} = {1}.New{1}();" + Environment.NewLine,
                        (String.IsNullOrEmpty(prop.Implements)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                        ") this)." + FormatPascal(prop.Name)),
                        prop.TypeName);
                else
                    response += String.Format("                        {0} = DataPortal.CreateChild<{1}>();" + Environment.NewLine,
                        (String.IsNullOrEmpty(prop.Implements)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                        ") this)." + FormatPascal(prop.Name)),
                        prop.TypeName);
                response += "                    else" + Environment.NewLine;
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += String.Format("                        {0} = {1}.Get{1}({2});" + Environment.NewLine,
                        (String.IsNullOrEmpty(prop.Implements)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                        ") this)." + FormatPascal(prop.Name)),
                        prop.TypeName, GetFieldReaderStatementList(info, prop));
                else
                    response += String.Format("                        {0} = DataPortal.FetchChild<{1}>({2});" + Environment.NewLine,
                        (String.IsNullOrEmpty(prop.Implements)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                        ") this)." + FormatPascal(prop.Name)),
                        prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += Environment.NewLine;
                response += ChildPropertyDeclareGetReturner(prop);
                response += ((UseSilverlight() &&
                              (CurrentUnit.GenerationParams.GenerateSynchronous ||
                               !CurrentUnit.GenerationParams.GenerateAsynchronous))
                                 ? "#endif" + Environment.NewLine
                                 : "");
            }
            else if (CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                /* Editable Asynchronous

                if (!FieldManager.FieldExists(ChildrenProperty))
                {
                    LoadProperty(ChildrenProperty, null);
                    if (this.IsNew)
                    {
                        DataPortal.BeginCreate<ChildType>((o, e) =>
                            {
                                if (e.Error != null)
                                    throw e.Error;
                                else
                                {
                                    // set the property so OnPropertyChanged is raised
                                    Children = e.Object;
                                }
                            });
                        return null;
                    }
                    else
                    {
                        DataPortal.BeginFetch<ChildType>(this, (o, e) =>
                            {
                                if (e.Error != null)
                                    throw e.Error;
                                else
                                {
                                    // set the property so OnPropertyChanged is raised
                                    Children = e.Object;
                                }
                            });
                        return null;
                    }
                }
                else
                {
                    return GetProperty(ChildrenProperty);
                }*/

                response += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                {" + Environment.NewLine;
                response += String.Format("                    LoadProperty({0}, null);" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                    if (this.IsNew)" + Environment.NewLine;
                response += "                    {" + Environment.NewLine;
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += String.Format("                        {0}.New{0}((o, e) =>" + Environment.NewLine, prop.TypeName);
                else
                    response += string.Format("                        DataPortal.BeginCreate<{0}>((o, e) =>" + Environment.NewLine,
                        prop.TypeName);
                response += "                            {" + Environment.NewLine;
                response += "                                if (e.Error != null)" + Environment.NewLine;
                response += "                                    throw e.Error;" + Environment.NewLine;
                response += "                                else" + Environment.NewLine;
                response += "                                {" + Environment.NewLine;
                response += "                                    // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += String.Format("                                    {0} = e.Object;" + Environment.NewLine,
                                          (String.IsNullOrEmpty(prop.Implements)
                                               ? FormatPascal(prop.Name)
                                               : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                                                 ") this)." + FormatPascal(prop.Name)));
                response += "                                }" + Environment.NewLine;
                response += "                            });" + Environment.NewLine;
                response += "                        return null;" + Environment.NewLine;
                response += "                    }" + Environment.NewLine;
                response += "                    else" + Environment.NewLine;
                response += "                    {" + Environment.NewLine;
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += String.Format("                        {0}.Get{0}({1}, (o, e) =>" +
                        Environment.NewLine, prop.TypeName, GetFieldReaderStatementList(info, prop));
                else
                    response += string.Format("                        DataPortal.BeginFetch<{0}>({1}, (o, e) =>" +
                        Environment.NewLine, prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += "                            {" + Environment.NewLine;
                response += "                                if (e.Error != null)" + Environment.NewLine;
                response += "                                    throw e.Error;" + Environment.NewLine;
                response += "                                else" + Environment.NewLine;
                response += "                                {" + Environment.NewLine;
                response += "                                    // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += String.Format("                                    {0} = e.Object;" + Environment.NewLine,
                                          (String.IsNullOrEmpty(prop.Implements)
                                               ? FormatPascal(prop.Name)
                                               : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                                                 ") this)." + FormatPascal(prop.Name)));
                response += "                                }" + Environment.NewLine;
                response += "                            });" + Environment.NewLine;
                response += "                        return null;" + Environment.NewLine;
                response += "                    }" + Environment.NewLine;
                response += "                }" + Environment.NewLine;
                response += "                else" + Environment.NewLine;
                response += "                {" + Environment.NewLine;
                response += "    " + ChildPropertyDeclareGetReturner(prop);
                response += "                }" + Environment.NewLine;
                response += ((UseSilverlight() &&
                              (CurrentUnit.GenerationParams.GenerateSynchronous ||
                               !CurrentUnit.GenerationParams.GenerateAsynchronous))
                                 ? "#endif" + Environment.NewLine
                                 : "");
            }

            return response;
        }

        private string ChildLazyLoadManagedReadOnly(CslaObjectInfo info, ChildProperty prop)
        {
            var response = String.Empty;

            if (CurrentUnit.GenerationParams.SilverlightUsingServices)
            {
                /* ReadOnly Silverlight using services

                if (!FieldManager.FieldExists(ChildrenProperty))
                {
                    LoadProperty(ChildrenProperty, null);
                    DataPortal.BeginFetch<ChildType>(this, (o, e) =>
                        {
                            if (e.Error != null)
                                throw e.Error;
                            else
                            {
                                // set the property so OnPropertyChanged is raised
                                Children = e.Object;
                            }
                        }, DataPortal.ProxyModes.LocalOnly);
                    return null;
                }
                else
                {
                    return GetProperty(ChildrenProperty);
                }*/

                response += (UseNoSilverlight() ? "#if SILVERLIGHT" + Environment.NewLine : "");
                response += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                {" + Environment.NewLine;
                response += String.Format("                    LoadProperty({0}, null);" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += String.Format("                    {0}.Get{0}({1}, (o, e) =>" + Environment.NewLine,
                        prop.TypeName, GetFieldReaderStatementList(info, prop));
                else
                    response += string.Format("                    DataPortal.BeginFetch<{0}>({1}, (o, e) =>" + Environment.NewLine,
                        prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += "                        {" + Environment.NewLine;
                response += "                            if (e.Error != null)" + Environment.NewLine;
                response += "                                throw e.Error;" + Environment.NewLine;
                response += "                            else" + Environment.NewLine;
                response += "                            {" + Environment.NewLine;
                response += "                                // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += String.Format("                                {0} = e.Object;" + Environment.NewLine,
                                          (String.IsNullOrEmpty(prop.Implements)
                                               ? FormatPascal(prop.Name)
                                               : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                                                 ") this)." + FormatPascal(prop.Name)));
                response += "                            }" + Environment.NewLine;
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += "                        });" + Environment.NewLine;
                else
                    response += "                        }, DataPortal.ProxyModes.LocalOnly);" + Environment.NewLine;
                response += "                    return null;" + Environment.NewLine;
                response += "                }" + Environment.NewLine;
                response += "                else" + Environment.NewLine;
                response += "                {" + Environment.NewLine;
                response += "    " + ChildPropertyDeclareGetReturner(prop);
                response += "                }" + Environment.NewLine;
                response += (UseNoSilverlight() ? "#else" + Environment.NewLine : "");
            }

            if (CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                /* ReadOnly Asynchronous

                if (!FieldManager.FieldExists(ChildrenProperty))
                {
                    LoadProperty(ChildrenProperty, null);
                    DataPortal.BeginFetch<ChildType>(this, (o, e) =>
                        {
                            if (e.Error != null)
                                throw e.Error;
                            else
                            {
                                // set the property so OnPropertyChanged is raised
                                Children = e.Object;
                            }
                        });
                    return null;
                }
                else
                {
                    return GetProperty(ChildrenProperty);
                }*/

                response += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                {" + Environment.NewLine;
                response += String.Format("                    LoadProperty({0}, null);" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += String.Format("                    {0}.Get{0}({1}, (o, e) =>" + Environment.NewLine,
                        prop.TypeName, GetFieldReaderStatementList(info, prop));
                else
                    response += string.Format("                    DataPortal.BeginFetch<{0}>({1}, (o, e) =>" + Environment.NewLine,
                        prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += "                        {" + Environment.NewLine;
                response += "                            if (e.Error != null)" + Environment.NewLine;
                response += "                                throw e.Error;" + Environment.NewLine;
                response += "                            else" + Environment.NewLine;
                response += "                            {" + Environment.NewLine;
                response += "                                // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += String.Format("                                {0} = e.Object;" + Environment.NewLine,
                                          (String.IsNullOrEmpty(prop.Implements)
                                               ? FormatPascal(prop.Name)
                                               : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                                                 ") this)." + FormatPascal(prop.Name)));
                response += "                            }" + Environment.NewLine;
                response += "                        });" + Environment.NewLine;
                response += "                    return null;" + Environment.NewLine;
                response += "                }" + Environment.NewLine;
                response += "                else" + Environment.NewLine;
                response += "                {" + Environment.NewLine;
                response += "    " + ChildPropertyDeclareGetReturner(prop);
                response += "                }" + Environment.NewLine;
                response += (CurrentUnit.GenerationParams.SilverlightUsingServices ? "#endif" + Environment.NewLine : "");
            }
            else if (CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                /* ReadOnly Synchronous

                if (!FieldManager.FieldExists(ChildrenProperty))
                    Children = ChildType.GetChildType(this);

                return GetProperty(ChildrenProperty);*/

                response += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                if (CurrentUnit.GenerationParams.UseChildFactory)
                    response += String.Format("                    {0} = {1}.Get{1}({2});" + Environment.NewLine,
                        (String.IsNullOrEmpty(prop.Implements)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                        ") this)." + FormatPascal(prop.Name)),
                        prop.TypeName, GetFieldReaderStatementList(info, prop));
                else
                    response += String.Format("                    {0} = DataPortal.FetchChild<{1}>({2});" + Environment.NewLine,
                        (String.IsNullOrEmpty(prop.Implements)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Implements.Substring(0, prop.Implements.LastIndexOf('.')) +
                        ") this)." + FormatPascal(prop.Name)),
                        prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += Environment.NewLine;
                response += ChildPropertyDeclareGetReturner(prop);
                response += (CurrentUnit.GenerationParams.SilverlightUsingServices ? "#endif" + Environment.NewLine : "");
            }

            return response;
        }

        private string ChildLazyLoadClassic(CslaObjectInfo info, ChildProperty prop)
        {
            var response = String.Empty;

            /*
            if (!_childTypeLoaded)
            {
                _childType = ChildType.GetChild(_userID);
                _childTypeLoaded = true;
            }

            return _childType;
            */

            response += String.Format("                if (!{0})" + Environment.NewLine,
                                      FormatFieldName(prop.Name + "Loaded"));
            response += "                {" + Environment.NewLine;
            response += String.Format("                    {0} = {1}.Get{1}({2});" + Environment.NewLine,
                                      FormatFieldName(prop.Name),
                                      prop.TypeName,
                                      GetFieldReaderStatementList(info, prop));
            response += String.Format("                    {0} = true;" + Environment.NewLine,
                                      FormatFieldName(prop.Name + "Loaded"));
            response += "                }" + Environment.NewLine;
            response += Environment.NewLine;
            response += ChildPropertyDeclareGetReturner(prop);
            return response;
        }

        private string GetFieldReaderStatementList(CslaObjectInfo info, ChildProperty prop)
        {
            var response = String.Empty;

            for (var loadParameter = 0; loadParameter < prop.LoadParameters.Count; loadParameter++)
            {
                response += FormatFieldForPropertyName(info, prop.LoadParameters[loadParameter].Property.Name);
                if (loadParameter + 1 != prop.LoadParameters.Count)
                    response += ", ";
            }

            return response;
        }

        private string ChildPropertyDeclareGetReturner(ChildProperty prop)
        {
            string response;

            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                response = String.Format("                return GetProperty({0});" + Environment.NewLine,
                                          FormatPropertyInfoName(prop.Name));
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response = String.Format("                return {0};" + Environment.NewLine,
                                          FormatFieldName(prop.Name));
            }
            else //if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response = String.Format("                return {0};" + Environment.NewLine,
                                          FormatProperty(prop.Name));
            }

            return response;
        }

        #endregion

        #region Unit of Work handling

        public string UnitOfWorkPropertyDeclare(CslaObjectInfo info, UnitOfWorkProperty uowProp)
        {
            var response = String.Empty;

            var isReadOnly = false;

            if (uowProp.ReadOnly)
            {
                isReadOnly = true;
            }

            if (uowProp.DeclarationMode == PropertyDeclaration.Managed)
            {
                response += String.Format("public {0} {1}" + Environment.NewLine,
                                          uowProp.TypeName,
                                          uowProp.Name);
                response += "        {" + Environment.NewLine;
                response += String.Format("            get {{ return GetProperty({0}); }}" + Environment.NewLine,
                                          FormatPropertyInfoName(uowProp.Name));

                response += String.Format("            {0}set {{ LoadProperty({1}, value); }}{2}",
                                          isReadOnly ? "private " : "",
                                          FormatPropertyInfoName(uowProp.Name),
                                          Environment.NewLine);
                response += "        }";
            }
            else  //if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += String.Format("public {0} {1} {{ get; {2}set; }}",
                          uowProp.TypeName,
                          FormatPascal(uowProp.Name),
                          isReadOnly ? "private " : "");
            }

            return response;
        }

        /// <summary>
        /// Filters and merges the unit of work criteriacollection.
        /// Collection is filtered according to the type of the Unit of Work Type under processing.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns>A single filtered collection of properties.</returns>
        public static CriteriaCollection FilterAndMergeUnitOfWorkCriteriaCollection(CslaObjectInfo info)
        {
            if (info.IsUpdater)
                return null;

            var masterCrit = new Criteria();

            var criteriaCount = 0;
            foreach (var crit in info.CriteriaObjects)
            {
                /*if ((crit.IsCreator && info.IsCreator) ||
                    (crit.IsGetter && info.IsGetter) ||
                    (crit.IsDeleter && info.IsDeleter))*/
                if (crit.Properties.Count > 0)
                    criteriaCount++;
            }

            // TODO: must filter by type of Unit of Work
            // merge only if more than 1 criteria with properties
            if (criteriaCount < 2)
                return info.CriteriaObjects;

            foreach (var crit in info.CriteriaObjects)
            {
                /*if ((crit.IsCreator && info.IsCreator) ||
                    (crit.IsGetter && info.IsGetter) ||
                    (crit.IsDeleter && info.IsDeleter))*/
                masterCrit = Criteria.MergeUnitOfWorkCriteria(masterCrit, crit);
            }

            if (info.IsCreator)
            {
                masterCrit.CreateOptions.Factory = true;
                masterCrit.CreateOptions.DataPortal = true;
            }
            if (info.IsGetter)
            {
                masterCrit.GetOptions.Factory = true;
                masterCrit.GetOptions.DataPortal = true;
            }
            if (info.IsDeleter)
            {
                masterCrit.DeleteOptions.Factory = true;
                masterCrit.DeleteOptions.DataPortal = true;
            }

            var critCollection = new CriteriaCollection();
            critCollection.Add(masterCrit);
            return critCollection;
        }

        /// <summary>
        /// Returns whether the object associated to the UnitOfWork must be fethed.
        /// </summary>
        /// <param name="info">The Unit of Work under processing.</param>
        /// <param name="uowProp">The UnitOfWork property with target's object metadata.</param>
        /// <returns><c>true</c> if the UnitOfWork is of type <see cref="UnitOfWorkFunction.Getter"/> 
        /// or if the associated object type is not editable; <c>false</c> otherwise.</returns>
        public static bool ForceIsGetter(CslaObjectInfo info, UnitOfWorkProperty uowProp)
        {
            var targetInfo = info.Parent.CslaObjects.Find(uowProp.TypeName);
            var isGetter = info.IsGetter;
            if (!IsEditableType(targetInfo.ObjectType))
                isGetter = true;

            return isGetter;
        }

        /// <summary>
        /// Check if a subset of the criteria properties match the specifiyed target criteria properties.
        /// </summary>
        /// <param name="info">The Unit of Work under processing.</param>
        /// <param name="uowProp">The UnitOfWork property with target's object metadata.</param>
        /// <param name="uowCrit">The UnitOfWork criteria.</param>
        /// <returns><c>true</c> if there is a match; <c>false</c> otherwise.</returns>
        /// <remarks></remarks>
        public static bool CheckTargetPropertiesFound(CslaObjectInfo info, UnitOfWorkProperty uowProp, Criteria uowCrit)
        {
            // no target criteria to check
            if (uowProp.TargetCriteria == String.Empty)
                return false;

            var targetInfo = info.Parent.CslaObjects.Find(uowProp.TypeName);
            var targetCrit = GetCriteriaObjects(targetInfo).Find(uowProp.TargetCriteria);

            if (targetCrit.Properties.Count > uowCrit.Properties.Count)
                return false;

            if (uowCrit.Properties.Count == 0)
                return false;

            var criteriaCount = uowCrit.Properties.Count;

            /*if ((!isGetter && uowCrit.IsCreator) ||
                (isGetter && uowCrit.IsGetter) ||
                (info.IsDeleter && uowCrit.IsDeleter))*/
            if ((info.IsCreator && uowCrit.IsCreator) ||
                ((info.IsGetter || info.IsCreatorGetter) && uowCrit.IsGetter) ||
                (info.IsDeleter && uowCrit.IsDeleter))
            {
                var matchStart = false;
                var targetPropCounter = 0;
                for (var c = 0; c < criteriaCount; c++)
                {
                    if (uowCrit.Properties[c].Name == targetCrit.Properties[targetPropCounter].Name &&
                        uowCrit.Properties[c].PropertyType == targetCrit.Properties[targetPropCounter].PropertyType)
                    {
                        matchStart = true;
                        targetPropCounter++;
                        if (targetPropCounter == targetCrit.Properties.Count)
                            return true;
                    }
                    else
                    {
                        if (matchStart)
                        {
                            if (targetPropCounter == targetCrit.Properties.Count)
                                return true;

                            return false;
                        }
                    }
                }
                if (matchStart)
                    return true;

                return false;
            }

            return false;
        }

        /// <summary>
        /// Check if a given criteria property matches any of the specifiyed target criteria properties.
        /// </summary>
        /// <param name="info">The Unit of Work under processing.</param>
        /// <param name="uowProp">The UnitOfWork property with target's object metadata.</param>
        /// <param name="uowCrit">The UnitOfWork criteria.</param>
        /// <param name="critProp">The criteria property under test.</param>
        /// <returns><c>true</c> if there is a match; <c>false</c> otherwise.</returns>
        public static bool IsTargetProperty(CslaObjectInfo info, UnitOfWorkProperty uowProp, Criteria uowCrit, Property critProp)
        {
            // no target criteria to check
            if (uowProp.TargetCriteria == String.Empty)
                return false;

            var targetInfo = info.Parent.CslaObjects.Find(uowProp.TypeName);
            var targetCrit = GetCriteriaObjects(targetInfo).Find(uowProp.TargetCriteria);

            var isGetter = ForceIsGetter(info, uowProp);

            /*if ((!isGetter && uowCrit.IsCreator) ||
                (isGetter && uowCrit.IsGetter) ||
                (info.IsDeleter && uowCrit.IsDeleter))*/
            if ((info.IsCreator && uowCrit.IsCreator) ||
                ((info.IsGetter || info.IsCreatorGetter) && uowCrit.IsGetter) ||
                (info.IsDeleter && uowCrit.IsDeleter))
            {
                foreach (var targetProp in targetCrit.Properties)
                {
                    if (targetProp.Name == critProp.Name &&
                        targetProp.PropertyType == critProp.PropertyType)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region SimpleAudit

        public bool UseSimpleAuditTrail(CslaObjectInfo info)
        {
            if (!String.IsNullOrEmpty(info.Parent.Params.CreationDateColumn) ||
                !String.IsNullOrEmpty(info.Parent.Params.CreationUserColumn) ||
                !String.IsNullOrEmpty(info.Parent.Params.ChangedDateColumn) ||
                !String.IsNullOrEmpty(info.Parent.Params.ChangedUserColumn))
            {

                foreach (var valueProperty in info.GetAllValueProperties())
                {
                    if (valueProperty.Name == info.Parent.Params.CreationDateColumn ||
                        valueProperty.Name == info.Parent.Params.CreationUserColumn ||
                        valueProperty.Name == info.Parent.Params.ChangedDateColumn ||
                        valueProperty.Name == info.Parent.Params.ChangedUserColumn)
                        return true;
                }
            }
            return false;
        }

        public static bool IsCreationDateColumnPresent(CslaObjectInfo info)
        {
            foreach (var valueProperty in info.GetAllValueProperties())
            {
                if (valueProperty.Name == info.Parent.Params.CreationDateColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsCreationUserColumnPresent(CslaObjectInfo info)
        {
            foreach (var valueProperty in info.GetAllValueProperties())
            {
                if (valueProperty.Name == info.Parent.Params.CreationUserColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsChangedDateColumnPresent(CslaObjectInfo info)
        {
            foreach (var valueProperty in info.GetAllValueProperties())
            {
                if (valueProperty.Name == info.Parent.Params.ChangedDateColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsChangedUserColumnPresent(CslaObjectInfo info)
        {
            foreach (var valueProperty in info.GetAllValueProperties())
            {
                if (valueProperty.Name == info.Parent.Params.ChangedUserColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static string ConvertedPropertyName(CslaObjectInfo info, ValueProperty prop)
        {
            foreach (var convertProperty in info.ConvertValueProperties)
            {
                if (convertProperty.SourcePropertyName == prop.Name)
                    return convertProperty.Name;
            }

            return string.Empty;
        }

        #endregion

        #region Context Connection Manager

        public string GetConnection(CslaObjectInfo info, bool isFetch)
        {
            var database = "\"" + CurrentUnit.GenerationParams.DatabaseConnection + "\"";

            var response = "using (var ctx = ";

            if (info.PersistenceType == PersistenceType.LinqContext)
            {
                response += "ContextManager<" + info.DbContextObject + ">.GetManager(" + database + "))";
            }
            else if (info.PersistenceType == PersistenceType.EFContext)
            {
                response += "ObjectContextManager<" + info.DbContextObject + ">.GetManager(" + database + "))";
            }
            else if (info.PersistenceType == PersistenceType.SqlConnectionUnshared)
            {
                response = "using (var cn = new SqlConnection(Database." +
                           CurrentUnit.GenerationParams.DatabaseConnection + "Connection))";
            }
            else if (info.TransactionType == TransactionType.ADO && !isFetch)
            {
                response += "TransactionManager<SqlConnection, SqlTransaction>.GetManager(" + database + "))";
            }
            else
            {
                response += "ConnectionManager<SqlConnection>.GetManager(" + database + "))";
            }
            return response;
        }

        public string GetCommand(CslaObjectInfo info, string commandText)
        {
            var sprocTemplateHelper = new SprocTemplateHelper();
            List<IResultObject> tables = sprocTemplateHelper.GetTablesSelect(info);
            sprocTemplateHelper.SortTables(tables);

            var plainTableSchema = String.Empty;
            if (info.Parent.GenerationParams.GenerateQueriesWithSchema)
                plainTableSchema = tables[0].ObjectSchema + ".";

            return "using (var cmd = new SqlCommand(\"" + plainTableSchema + commandText + "\", " + LocalContextConnection(info) + "))";
        }

        public string LocalContextConnection(CslaObjectInfo info)
        {
            if (info.PersistenceType == PersistenceType.SqlConnectionUnshared)
                return "cn";

            return "ctx.Connection";
        }

        #endregion

        #region Misplaced

        public string GetFKColumn(CslaObjectInfo info, CslaObjectInfo parentInfo, Property parentProp)
        {
            var tableSchema = string.Empty;
            var tableName = string.Empty;
            foreach (var prop in info.GetDatabaseBoundValueProperties())
            {
                if (prop.DbBindColumn == null)
                    continue;

                if (prop.DbBindColumn.IsPrimaryKey)
                {
                    tableSchema = prop.DbBindColumn.SchemaName;
                    tableName = prop.DbBindColumn.ObjectName;
                    break;
                }
            }

            // no primary keys found; use the first column
            if (tableSchema == string.Empty && tableName == string.Empty)
            {
                foreach (var prop in info.GetDatabaseBoundValueProperties())
                {
                    if (prop.DbBindColumn == null)
                        continue;

                    tableSchema = prop.DbBindColumn.SchemaName;
                    tableName = prop.DbBindColumn.ObjectName;
                    break;
                }
            }

            if (tableSchema != string.Empty && tableName != string.Empty)
            {
                var parentValueProperty = new ValueProperty();
                if (GetValuePropertyByName(parentInfo, parentProp.Name, ref parentValueProperty))
                {
                    foreach (var constraint in GeneratorController.Catalog.ForeignKeyConstraints)
                    {
                        if (tableSchema == constraint.PKTable.ObjectSchema)
                        {
                            // get constraints with table match for PK or FK
                            if (parentValueProperty.DbBindColumn.ObjectName == constraint.PKTable.ObjectName &&
                                tableName == constraint.ConstraintTable.ObjectName)
                                return constraint.Columns[0].FKColumn.ColumnName;
                        }
                    }
                }
            }

            return "";
        }

        public List<ChildProperty> SortChildren(List<ChildProperty> children)
        {
            return children.OrderBy(c => c.ChildUpdateOrder).ToList();
        }

        public bool IgnoreSortOrder(List<ChildProperty> children)
        {
            return children.OrderBy(c => c.ChildUpdateOrder).ToList().Max().ChildUpdateOrder ==
                children.OrderBy(c => c.ChildUpdateOrder).ToList().Min().ChildUpdateOrder;
        }

        public bool DalObjectUsesDTO(CslaObjectInfo info)
        {
            /*return CurrentUnit.GenerationParams.UseDto == TargetDto.Always ||
                   (CurrentUnit.GenerationParams.UseDto == TargetDto.MoreThan &&
                    info.GetDatabaseBoundValueProperties().Count > CurrentUnit.GenerationParams.DtoLimit);*/
            return CurrentUnit.GenerationParams.UseDto == TargetDto.Always;
        }

        public bool DalObjectUsesCriteria(CslaObjectInfo info)
        {
            /*return CurrentUnit.GenerationParams.UseDto == TargetDto.Always ||
                   (CurrentUnit.GenerationParams.UseDto == TargetDto.MoreThan &&
                    info.GetDatabaseBoundValueProperties().Count > CurrentUnit.GenerationParams.DtoLimit);*/
            return CurrentUnit.GenerationParams.UseDto == TargetDto.Always;
        }

        public string[] CslaObjectPrimaryKeys(string infoName)
        {
            return CslaObjectPrimaryKeys(CurrentUnit.CslaObjects.Find(infoName));
        }

        public string[] CslaObjectPrimaryKeys(CslaObjectInfo info)
        {
            /*var pkList = new List<string>();
            foreach (var prop in info.AllValueProperties)
            {
                if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                    pkList.Add(prop.Name);
            }*/
            var pkList = (from prop in info.AllValueProperties where prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default select prop.Name).ToList();
            pkList.Sort();

            return pkList.ToArray();
        }

        public virtual string GetInitValue(Property prop)
        {
            //if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
            if (AllowNull(prop))
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetInitValue(ConvertValueProperty prop)
        {
            //if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
            if (AllowNull(prop))
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetInitValue(UpdateValueProperty prop)
        {
            //if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
            if (AllowNull(prop))
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetAccessorVisibility(ValueProperty prop)
        {
            switch (prop.PropSetAccessibility)
            {
                case AccessorVisibility.Private:
                    return "private ";
                case AccessorVisibility.Protected:
                    return "protected ";
                case AccessorVisibility.ProtectedInternal:
                    return "protected internal ";
                case AccessorVisibility.Internal:
                    return "internal ";
                default:
                    return "";
            }
        }

        public virtual string GetConstructorVisibility(CslaObjectInfo info)
        {
            switch (info.ConstructorVisibility)
            {
                case ConstructorVisibility.Private:
                    return "private";
                case ConstructorVisibility.Protected:
                    return "protected";
                case ConstructorVisibility.ProtectedInternal:
                    return "protected internal";
                case ConstructorVisibility.Internal:
                    return "internal";
                default:
                    return "private";
            }
        }

        public virtual string GetPropertyAccess(ValueProperty prop)
        {
            return Access.Convert(prop.Access);
        }

        public virtual string GetPropertyAccess(ChildProperty prop)
        {
            return Access.Convert(prop.Access);
        }

        #endregion

        #region <remarks> helpers

        public static string Ordinal(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 10:
                    return "ten";
                default:
                    return "more then ten";
            }
        }

        public static string CslaStereotype(CslaObjectInfo info)
        {
            var cslaGenObjectType = info.ObjectType;
            switch (cslaGenObjectType)
            {
                case CslaObjectType.EditableRoot:
                    return "editable root object";
                case CslaObjectType.EditableChild:
                    return "editable child object";
                case CslaObjectType.EditableSwitchable:
                    return "editable switchable object";
                case CslaObjectType.DynamicEditableRoot:
                    return "dynamic root object";
                case CslaObjectType.EditableRootCollection:
                    return "editable root list";
                case CslaObjectType.DynamicEditableRootCollection:
                    return "dynamic root list";
                case CslaObjectType.EditableChildCollection:
                    return "editable child list";
                case CslaObjectType.ReadOnlyObject:
                    return "read only object";
                case CslaObjectType.ReadOnlyCollection:
                    return "read only list";
                case CslaObjectType.NameValueList:
                    return "name value list";
                case CslaObjectType.UnitOfWork:
                    if (info.IsCreatorGetter)
                        return "creator and getter unit of work pattern";
                    if (info.IsCreator)
                        return "creator unit of work pattern";
                    if (info.IsGetter)
                        return "getter unit of work pattern";
                    if (info.IsUpdater)
                        return "transactional updater unit of work pattern";
                    //if (info.IsDeleter)
                    return "transactional deleter unit of work pattern";
                default:
                    return "new CSLA stereotype";
            }
        }

        public CslaObjectInfo FindAssociated(CslaObjectInfo info, CslaObjectInfo originalChild)
        {
            // presume only one primary key on Associated entities
            // presume only one pair of Associated entities an a "M:M" relation

            List<string> allCslaObjects = CurrentUnit.CslaObjects.GetAllObjectNames();
            var primaryKeys = PrimaryKeys.GetPrimaryKeys(allCslaObjects, info);

            var originalChildCollectionItem = originalChild.Parent.CslaObjects.Find(originalChild.ItemType);
            var originalChildCollectionItemPK = PrimaryKeys.FindPrimaryKey(originalChildCollectionItem);
            var infoPK = PrimaryKeys.FindPrimaryKey(info);

            foreach (PrimaryKeys.ObjectPK trialPK in PrimaryKeys.Cache)
            {
                // reject self matching (false positives)
                if (trialPK.Info != info && trialPK.Info != originalChildCollectionItem)
                {
                    if (MatchingProperties(originalChildCollectionItemPK, trialPK.Property))
                    {
                        if (FindMatchingChildCollectionItems(infoPK, trialPK))
                            return trialPK.Info;
                    }
                }
            }

            return null;
        }

        private bool FindMatchingChildCollectionItems(ValueProperty originalInfoPK, PrimaryKeys.ObjectPK trialPK)
        {
            if (trialPK.Info.ChildCollectionProperties.Count > 0)
            {
                for (int collection = 0; collection < trialPK.Info.ChildCollectionProperties.Count; collection++)
                {
                    var trialChildCollection = FindChildInfo(trialPK.Info, trialPK.Info.ChildCollectionProperties[collection].TypeName);
                    var trialChildCollectionItem = trialChildCollection.Parent.CslaObjects.Find(trialChildCollection.ItemType);
                    foreach (var trialChildCollectionItemProp in trialChildCollectionItem.ValueProperties)
                    {
                        if (MatchingProperties(originalInfoPK, trialChildCollectionItemProp))
                            return true;
                    }
                }
            }
            return false;
        }

        private static bool MatchingProperties(ValueProperty original, ValueProperty trial)
        {
            if (trial.Name == original.Name &&
                (trial.ParameterName == original.ParameterName ||
                 trial.DbBindColumn == original.DbBindColumn))
                return true;

            return false;
        }

        #region Singleton primary keyes

        public class PrimaryKeys
        {
            public class ObjectPK
            {
                public CslaObjectInfo Info { get; set; }

                public ValueProperty Property { get; set; }
            }

            private static PrimaryKeys _instance;
            private static CslaObjectInfo _cslaObjectInfo;
            private static List<string> _allCslaObjects;

            public static ArrayList Cache { get; private set; }

            /* force to use Factory methods */
            private PrimaryKeys()
            {
                foreach (var cslaObject in _allCslaObjects)
                {
                    var info = _cslaObjectInfo.Parent.CslaObjects.Find(cslaObject);
                    ValueProperty prop = FindPrimaryKey(info);
                    if (prop != null)
                    {
                        Cache.Add(new ObjectPK { Info = info, Property = prop });
                    }
                }
            }

            static PrimaryKeys()
            {
                Cache = new ArrayList();
            }

            public static ValueProperty FindPrimaryKey(CslaObjectInfo info)
            {
                foreach (var prop in info.GetAllValueProperties())
                {
                    // accept DBProvidedPK and also UserProvidedPK
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                    {
                        return prop;
                    }
                }
                return null;
            }

            public static PrimaryKeys GetPrimaryKeys(List<string> allCslaObjects, CslaObjectInfo cslaObjectInfo)
            {
                // Use 'Lazy initialization'
                if (_instance == null)
                {
                    _allCslaObjects = allCslaObjects;
                    _cslaObjectInfo = cslaObjectInfo;
                    _instance = new PrimaryKeys();
                }
                return _instance;
            }

            public static void ClearCache()
            {
                Cache.Clear();
                _instance = null;
            }

        }

        #endregion

        #endregion

        #region Pseudo events

        public List<string> GetEventList(CslaObjectInfo info)
        {
            var lazyLoad = IsChildLazyLoaded(info);

            var eventList = new List<string>();

            if (HasDataPortalCreate(info) &&
                ((IsEditableType(info.ObjectType) &&
                IsChildType(info.ObjectType)) ||
                info.ObjectType == CslaObjectType.EditableRoot ||
                info.ObjectType == CslaObjectType.DynamicEditableRoot))
            {
                eventList.Add("Create");
            }

            if (
                (HasDataPortalDelete(info) &&
                ((IsEditableType(info.ObjectType) &&
                IsChildType(info.ObjectType)) ||
                info.ObjectType == CslaObjectType.EditableRoot ||
                info.ObjectType == CslaObjectType.DynamicEditableRoot))
                ||
                (info.GenerateDataPortalDelete &&
                (info.ObjectType == CslaObjectType.EditableRoot ||
                info.ObjectType == CslaObjectType.DynamicEditableRoot ||
                info.ObjectType == CslaObjectType.EditableChild ||
                info.ObjectType == CslaObjectType.EditableSwitchable))
                )
            {
                eventList.AddRange(new[] { "DeletePre", "DeletePost" });
            }

            if (HasDataPortalGet(info) ||
                (info.ObjectType != CslaObjectType.ReadOnlyObject &&
                info.ParentType != String.Empty &&
                !lazyLoad))
            {
                eventList.AddRange(new[] { "FetchPre", "FetchPost" });
            }

            if (!IsCollectionType(info.ObjectType) &&
                info.ObjectType != CslaObjectType.NameValueList)
            {
                eventList.Add("FetchRead");
            }

            if (IsEditableType(info.ObjectType) &&
                !IsCollectionType(info.ObjectType) &&
                info.GenerateDataPortalUpdate)
            {
                eventList.AddRange(new[] { "UpdatePre", "UpdatePost" });
            }

            if (IsEditableType(info.ObjectType) &&
                !IsCollectionType(info.ObjectType) &&
                info.GenerateDataPortalInsert)
            {
                eventList.AddRange(new[] { "InsertPre", "InsertPost" });
            }

            return eventList;
        }

        public string FormatEventDocumentation(string name)
        {
            var response = String.Empty;

            switch (name)
            {
                case "Create":
                    response += "after setting all defaults for object creation.";
                    break;
                case "FetchPre":
                    response += "after setting query parameters and before the fetch operation.";
                    break;
                case "FetchPost":
                    response += "after the fetch operation (object or collection is fully loaded and set up).";
                    break;
                case "FetchRead":
                    response += "after the low level fetch operation, before the data reader is destroyed.";
                    break;
                case "InsertPre":
                    response += "in DataPortal_Insert, after setting query parameters and before the insert operation.";
                    break;
                case "InsertPost":
                    response += "in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().";
                    break;
                case "UpdatePre":
                    response += "after setting query parameters and before the update operation.";
                    break;
                case "UpdatePost":
                    response += "in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().";
                    break;
                case "DeletePre":
                    response += "in DataPortal_Delete, after setting query parameters and before the delete operation.";
                    break;
                case "DeletePost":
                    response += "in DataPortal_Delete, after the delete operation, before Commit().";
                    break;
                default:
                    response += "undescribed circumstances.";
                    break;
            }

            return response;
        }

        #endregion

        #region Criteria and SingleCriteria support

        public bool IsCriteriaClassNeeded(CslaObjectInfo info)
        {
            return (from crit in GetCriteriaObjects(info) 
                    where crit.Properties.Count > 1 
                    select FactoryOrDataPortal(crit)).FirstOrDefault();
        }

        public bool IsCriteriaNestedClassNeeded(CslaObjectInfo info)
        {
            return (from crit in GetCriteriaObjects(info) 
                    where crit.Properties.Count > 1 && crit.NestedClass 
                    select FactoryOrDataPortal(crit)).FirstOrDefault();
        }

        public bool IsCriteriaObjectNeeded(CslaObjectInfo info)
        {
            return (from crit in GetCriteriaObjects(info) 
                    where crit.Properties.Count > 1 && !crit.NestedClass 
                    select FactoryOrDataPortal(crit)).FirstOrDefault();
        }

        public bool IsCriteriaExtendedClassNeeded(CslaObjectInfo info)
        {
            return (from crit in GetCriteriaObjects(info) 
                    where crit.Properties.Count > 1 && crit.CriteriaClassMode == CriteriaMode.BusinessBase
                    select FactoryOrDataPortal(crit)).FirstOrDefault();
        }

        public static CriteriaCollection GetCriteriaObjects(CslaObjectInfo info)
        {
            if (info.ObjectType != CslaObjectType.UnitOfWork)
                return info.CriteriaObjects;

            return info.MyCriteriaObjects;
        }

        private static bool FactoryOrDataPortal(Criteria crit)
        {
            if (crit.CreateOptions.DataPortal ||
                crit.CreateOptions.Factory ||
                crit.GetOptions.DataPortal ||
                crit.GetOptions.Factory ||
                crit.DeleteOptions.DataPortal ||
                crit.DeleteOptions.Factory)
                return true;

            return false;
        }

        public string SendSingleCriteria(Criteria crit, string paramName)
        {
            var sb = new StringBuilder();

            var param = GetDataTypeGeneric(crit.Properties[0], crit.Properties[0].PropertyType);
            if (param == "Object" || param == "Empty" || CurrentUnit.GenerationParams.UseSingleCriteria)
                sb.AppendFormat("new SingleCriteria<{0}>({1})", param, paramName);
            else
                sb.AppendFormat(paramName);

            return sb.ToString();
        }

        public string ReceiveSingleCriteria(Criteria crit, string paramName)
        {
            var sb = new StringBuilder();

            var param = GetDataTypeGeneric(crit.Properties[0], crit.Properties[0].PropertyType);
            if (param == "Object" || param == "Empty" || CurrentUnit.GenerationParams.UseSingleCriteria)
                sb.AppendFormat("SingleCriteria<{0}> {1}", param, paramName);
            else
            {
                paramName = FormatCamel(crit.Properties[0].Name);
                sb.AppendFormat("{0} {1}", param, paramName);
            }

            return sb.ToString();
        }

        public string AssignSingleCriteria(Criteria crit, string paramName)
        {
            var sb = new StringBuilder();

            var param = GetDataTypeGeneric(crit.Properties[0], crit.Properties[0].PropertyType);
            if (param == "Object" || param == "Empty" || CurrentUnit.GenerationParams.UseSingleCriteria)
                sb.AppendFormat("{0}.Value", paramName);
            else
            {
                paramName = FormatCamel(crit.Properties[0].Name);
                sb.AppendFormat(paramName);
            }

            return sb.ToString();
        }

        public string HookSingleCriteria(Criteria crit, string paramName)
        {
            var sb = new StringBuilder();

            var param = GetDataTypeGeneric(crit.Properties[0], crit.Properties[0].PropertyType);
            if (param == "Object" || param == "Empty" || CurrentUnit.GenerationParams.UseSingleCriteria)
                sb.AppendFormat(paramName);
            else
            {
                paramName = FormatCamel(crit.Properties[0].Name);
                sb.AppendFormat(paramName);
            }

            return sb.ToString();
        }

        #endregion

        #region Conditional Compile Directives

        public bool HasFactoryCreate(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.CreateOptions.Factory)
                    return true;
            }

            return false;
        }

        public bool HasFactoryGet(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.GetOptions.Factory)
                    return true;
            }

            return false;
        }

        public bool HasFactoryDelete(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.DeleteOptions.Factory)
                    return true;
            }

            return false;
        }

        public bool HasFactoryCreateOrGet(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.CreateOptions.Factory)
                    return true;
                if (crit.GetOptions.Factory)
                    return true;
            }

            return false;
        }

        public bool HasFactoryGetOrDelete(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.GetOptions.Factory)
                    return true;
                if (crit.DeleteOptions.Factory)
                    return true;
            }

            return false;
        }

        public bool HasFactoryCreateOrGetOrDelete(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.CreateOptions.Factory)
                    return true;
                if (crit.GetOptions.Factory)
                    return true;
                if (crit.DeleteOptions.Factory)
                    return true;
            }

            return false;
        }

        public bool HasDataPortalCreate(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.CreateOptions.DataPortal)
                    return true;
            }

            return false;
        }

        public bool HasDataPortalGet(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.GetOptions.DataPortal)
                    return true;
            }

            return false;
        }

        public bool HasDataPortalDelete(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.DeleteOptions.DataPortal)
                    return true;
            }

            return false;
        }

        public bool HasDataPortalCreateOrGet(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.CreateOptions.DataPortal)
                    return true;
                if (crit.GetOptions.DataPortal)
                    return true;
            }

            return false;
        }

        public bool HasDataPortalGetOrDelete(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.GetOptions.DataPortal)
                    return true;
                if (crit.DeleteOptions.DataPortal)
                    return true;
            }

            return false;
        }

        public bool HasDataPortalCreateOrGetOrDelete(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.CreateOptions.DataPortal)
                    return true;
                if (crit.GetOptions.DataPortal)
                    return true;
                if (crit.DeleteOptions.DataPortal)
                    return true;
            }

            return false;
        }

        public bool UseBoth()
        {
            return UseNoSilverlight() && UseSilverlight();
        }

        public bool UseSilverlight()
        {
            return CurrentUnit.GenerationParams.GenerateSilverlight4 || CurrentUnit.GenerationParams.SilverlightUsingServices;
        }

        public bool UseNoSilverlight()
        {
            return CurrentUnit.GenerationParams.GenerateWinForms || CurrentUnit.GenerationParams.GenerateWPF;
        }

        public enum Conditional
        {
            Silverlight,
            NotSilverlight,
            Else,
            End
        }

        public string IfNewSilverlight(Conditional step, int indent, ref int silverlightLevel, bool formFeedBefore, bool formFeedAfter)
        {
            var result = String.Empty;
            var outerSilverlightLevel = silverlightLevel;
            if (step == Conditional.Else)
            {
                if (silverlightLevel > 0)
                    result = IfSilverlight(step, indent, ref outerSilverlightLevel, formFeedBefore, formFeedAfter);
            }
            else if (step == Conditional.End)
            {
                if (silverlightLevel == 1)
                    result = IfSilverlight(step, indent, ref outerSilverlightLevel, formFeedBefore, formFeedAfter);
                else
                    outerSilverlightLevel--;
            }
            else if (silverlightLevel == 0)
                result = IfSilverlight(step, indent, ref outerSilverlightLevel, formFeedBefore, formFeedAfter);
            else
                outerSilverlightLevel++;

            silverlightLevel = outerSilverlightLevel;
            return result;
        }

        public string IfSilverlight(Conditional step, int indent, ref int silverlightLevel, bool formFeedBefore, bool formFeedAfter)
        {
            var result = String.Empty;
            var outputValue = silverlightLevel;
            if (UseSilverlight())
            {
                switch (step)
                {
                    case Conditional.Silverlight:
                        result = (formFeedBefore ? Environment.NewLine : "") + "#if SILVERLIGHT" + (formFeedAfter ? Environment.NewLine : "") + new string(' ', indent * 4);
                        outputValue = silverlightLevel + 1;
                        break;
                    case Conditional.NotSilverlight:
                        result = (formFeedBefore ? Environment.NewLine : "") + "#if !SILVERLIGHT" + (formFeedAfter ? Environment.NewLine : "") + new string(' ', indent * 4);
                        outputValue = silverlightLevel + 1;
                        break;
                    case Conditional.Else:
                        result = (formFeedBefore ? Environment.NewLine : "") + "#else" + (formFeedAfter ? Environment.NewLine : "") + new string(' ', indent * 4);
                        outputValue = silverlightLevel;
                        break;
                    case Conditional.End:
                        result = (formFeedBefore ? Environment.NewLine : "") + "#endif" + (formFeedAfter ? Environment.NewLine : "");
                        outputValue = silverlightLevel - 1;
                        break;
                    default:
                        result = "";
                        break;
                }
            }
            silverlightLevel = outputValue;
            return result;
        }

        public string CommonVisibility(string desiredVisibity, int indent)
        {
            var result = desiredVisibity;
            if (UseSilverlight())
            {
                result = "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" + Environment.NewLine +
                         new string(' ', indent * 4) +
                         "public";
            }
            return result;
        }

        #endregion
    }
}
