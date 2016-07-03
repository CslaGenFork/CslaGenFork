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

namespace CslaGenerator.CodeGen
{
    /// <summary>
    /// Summary description for CslaTemplateHelper.
    /// </summary>
    public class CslaTemplateHelperCS : CodeTemplate
    {
        protected int ResultSetCount;
        private bool? _hasAnySilverlightLocalDataPortalCreate;

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

        public bool UseChildFactoryHelper { get; set; }

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

            return string.Empty;
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
                return string.Empty;

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

            return string.Empty;
        }

        public string FormatManaged(string name)
        {
            if (name.Length > 0)
            {
                return FormatPascal(name) + "Property";
            }

            return string.Empty;
        }

        public virtual string GetNowValue(TypeCodeEx typeCode)
        {
            var now = "Now";
            if (CurrentUnit.Params.LogInUtc)
                now = "UtcNow";

            if (typeCode == TypeCodeEx.SmartDate ||
                typeCode == TypeCodeEx.DateTime)
                return "DateTime." + now;

            if (typeCode == TypeCodeEx.DateTimeOffset)
                return "DateTimeOffset." + now;

            if (typeCode == TypeCodeEx.TimeSpan)
                return "DateTime." + now + ".TimeOfDay";

            return GetInitValue(typeCode);
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
                return GetNowValue(typeCode);

            if (typeCode == TypeCodeEx.DateTimeOffset)
                return GetNowValue(typeCode);

            if (typeCode == TypeCodeEx.TimeSpan)
                return GetNowValue(typeCode);

            if (typeCode == TypeCodeEx.Char)
                return "char.MinValue";

            if (typeCode == TypeCodeEx.ByteArray)
                return "new byte[] {}";

            return string.Empty;
        }

        public virtual string GetInitValue(ValueProperty prop)
        {
            if (AllowNull(prop) && prop.PropertyType.IsNullableType())
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

                if (CurrentUnit.GenerationParams.TargetIsCsla4DAL && CurrentUnit.GenerationParams.GenerateDTO)
                    return GetDtoLoaderStatement(prop);

                return GetDataReaderLoaderStatement(prop);
            }

            string statement;
            if (structure)
                statement = "nfo." + prop.Name + " = ";
            else
                statement = FormatFieldName(prop.Name) + " = ";

            if (info.DataSetLoadingScheme)
                statement += GetDataSetStatement(prop);
            else if (CurrentUnit.GenerationParams.GenerateDTO)
                statement += GetDtoStatement(prop);
            else
                statement += GetDataReaderStatement(prop);

            return statement;
        }

        public virtual string GetDataSetStatement(ValueProperty prop)
        {
            // this is a quick hack
            var nullable = AllowNull(prop);
            var statement = string.Empty;

            if (nullable)
            {
                if (prop.PropertyType.IsNullableType())
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
                if (prop.PropertyType.IsNullableType())
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
            var statement = string.Empty;

            if (nullable)
            {
                if (assignDataType.IsNullableType())
                    statement += String.Format("({0})", GetDataType(prop));
                //else
                //    statement += String.Format("!dr.IsDBNull(\"{0}\") ? ",
                //                               prop.ParameterName);
            }
            statement += "dr.";

            if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
                statement += GetReaderMethod(assignDataType);
            else
                statement += GetReaderMethod(prop.DbBindColumn.GetDbType(), prop);

            statement += "(\"" + prop.ParameterName + "\"";

            if (assignDataType == TypeCodeEx.SmartDate)
                statement += ", true";

            statement += ")";
            /*if (nullable && !GeneralTemplatesHelper.IsNullableType(assignDataType))
            {
                if (GeneralTemplatesHelper.IsNullableType(assignDataType))
                    statement += ")";
                statement += " : null";
            }*/

            if (assignDataType == TypeCodeEx.ByteArray)
                statement = statement + " as byte[]";

            return statement;
        }

        public virtual string GetDtoStatement(ValueProperty prop)
        {
            return "data." + FormatPascal(prop.Name);
        }

        public static bool AllowNull(Property prop)
        {
            return prop.Nullable;
        }

        public virtual string GetParameterSet(Property prop)
        {
            return GetParameterSet(prop, false);
        }

        public virtual string GetParameterSet(Property prop, bool useCrit)
        {
            return GetParameterSet(prop, useCrit, false);
        }

        public virtual string GetParameterSet(Property prop, bool useCrit, bool singleCriteria)
        {
            return GetParameterSet(prop, useCrit, singleCriteria, true);
        }

        public virtual string GetParameterSet(Property prop, bool useCrit, bool singleCriteria, bool useField)
        {
            TypeCodeEx propType = prop.PropertyType;
            try
            {
                propType = (prop as ValueProperty).GetBackingFieldType();
            }
            catch (Exception)
            {
            }

            bool nullable = AllowNull(prop);
            string propName;
            if (singleCriteria)
                propName = "crit.Value";
            else if (useCrit)
                propName = "crit." + FormatPascal(prop.Name);
            else if (useField)
                propName = FormatFieldName(prop.Name);
            else
                propName = FormatCamel(prop.Name);

            if (nullable)
            {
                if (propType.IsNullableType())
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

        public virtual string GetDataType(ValueProperty prop)
        {
            var type = GetDataType(prop.PropertyType);
            if (AllowNull(prop))
            {
                if (prop.PropertyType.IsNullableType())
                    type += "?";
            }
            return type;
        }

        public virtual string GetBackingDataType(ValueProperty prop)
        {
            var type = GetDataType(prop.BackingFieldType);
            if (AllowNull(prop))
            {
                if (prop.BackingFieldType.IsNullableType())
                    type += "?";
            }
            return type;
        }

        public static string GetDataType(TypeCodeEx type)
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
            if (prop.Nullable && prop.PropertyType.IsNullableType())
                return "GetValue";

            if (prop.BackingFieldType == TypeCodeEx.Empty)
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
                case DbType.Time:
                    return "GetValue";
                // waiting for SafeDatareader support for "GetTime"
                case DbType.DateTimeOffset:
                    return (propertyType == TypeCodeEx.SmartDate) ? "GetSmartDate" : "GetDateTimeOffset";
                case DbType.Date:
                case DbType.DateTime2:
                case DbType.DateTime:
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
                case TypeCodeEx.TimeSpan:
                    return "GetValue";
                // waiting for SafeDatareader support for "GetTime"
                case TypeCodeEx.DateTimeOffset:
                    return "GetDateTimeOffset";
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
                case DbType.Time:
                    return "TimeSpan";
                case DbType.DateTimeOffset:
                    return "DateTimeOffset";
                case DbType.Date:
                case DbType.DateTime2:
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
            if (info.ObjectType.IsCollectionType())
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
            var joinColumn = string.Empty;
            if (child.LoadParameters.Count > 0)
            {
                if (childInfo.ObjectType.IsCollectionType())
                {
                    joinColumn = child.LoadParameters[0].Property.Name;
                    childInfo = FindChildInfo(info, childInfo.ItemType);
                }
                if (joinColumn == string.Empty)
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

        public string GetUsingStatementsStringDalInterface(CslaObjectInfo info, CslaGeneratorUnit unit)
        {
            var result = string.Empty;

            var allNamespaces = new List<string>();
            allNamespaces.Add("System");

            if (CurrentUnit.GenerationParams.GenerateDTO)
                allNamespaces.Add("System.Collections.Generic");
            else
                allNamespaces.Add("System.Data");

            allNamespaces.Add("Csla");

            var dependencyNamespaces = new List<string>();
            if (unit.GenerationParams.GenerateDTO)
            {
                dependencyNamespaces.AddRange(GetDependencyNamespaces(info));
                foreach (var namespaceName in dependencyNamespaces)
                {
                    allNamespaces.Add(unit.GenerationParams.DalInterfaceNamespace +
                                      namespaceName.Substring(unit.GenerationParams.BaseNamespace.Length));
                }
            }

            foreach (var namespaceName in allNamespaces)
            {
                result += "using " + namespaceName + ";" + Environment.NewLine;
            }

            return result;
        }

        public string GetUsingStatementsStringDalObject(CslaObjectInfo info, CslaGeneratorUnit unit)
        {
            var result = string.Empty;

            var allNamespaces = new List<string>();
            allNamespaces.Add("System");

            if (CurrentUnit.GenerationParams.GenerateDTO)
                allNamespaces.Add("System.Collections.Generic");

            allNamespaces.Add("System.Data");
            allNamespaces.Add("System.Data.SqlClient");
            allNamespaces.Add("Csla");
            allNamespaces.Add("Csla.Data");

            var dependencyNamespaces = new List<string>();
            if (unit.GenerationParams.GenerateDTO)
            {
                dependencyNamespaces.AddRange(GetDependencyNamespaces(info));
                foreach (var namespaceName in dependencyNamespaces)
                {
                    allNamespaces.Add(unit.GenerationParams.DalInterfaceNamespace +
                                      namespaceName.Substring(unit.GenerationParams.BaseNamespace.Length));
                }
            }

            allNamespaces.AddRange(GetDalInterfaceNamespaces(info, unit));

            foreach (var namespaceName in allNamespaces)
            {
                result += "using " + namespaceName + ";" + Environment.NewLine;
            }

            return result;
        }

        private List<string> GetDependencyNamespaces(CslaObjectInfo info)
        {
            var result = new List<string>();

            foreach (var prop in info.GetAllChildProperties())
                if (prop.TypeName != info.ObjectName)
                {
                    var childInfo = FindChildInfo(info, prop.TypeName);
                    if (childInfo != null)
                        if (!result.Contains(childInfo.ObjectNamespace) &&
                            !IsNamespaceInScope(info.ObjectNamespace, childInfo.ObjectNamespace))
                            result.Add(childInfo.ObjectNamespace);
                }

            if (info.ItemType != string.Empty)
            {
                var childInfo = FindChildInfo(info, info.ItemType);
                if (childInfo != null)
                    if (!result.Contains(childInfo.ObjectNamespace) &&
                        !IsNamespaceInScope(info.ObjectNamespace, childInfo.ObjectNamespace))
                        result.Add(childInfo.ObjectNamespace);
            }

            if (info.ParentType != string.Empty)
            {
                var parentInfo = FindChildInfo(info, info.ParentType);
                if (parentInfo != null)
                    if (!result.Contains(parentInfo.ObjectNamespace) &&
                        !IsNamespaceInScope(info.ObjectNamespace, parentInfo.ObjectNamespace))
                        result.Add(parentInfo.ObjectNamespace);
            }

            if (result.Contains(string.Empty))
                result.Remove(string.Empty);

            return result;
        }

        public string GetUsingStatementsStringBusiness(CslaObjectInfo info, CslaGeneratorUnit unit)
        {
            const GenerationStep step = GenerationStep.Business;

            var result = string.Empty;
            var silverlightLevel = 0;
            var isUnitOfWork = info.IsUnitOfWork();

            var cachedContextUtilitiesNamespace = GetContextUtilitiesNamespace(unit, step);

            // show unconditionally, before everything else
            var commonNamespaces = new List<string>();
            commonNamespaces.AddRange(GetBaseCommonNamespaces(info, unit, cachedContextUtilitiesNamespace));
            commonNamespaces.AddRange(GetCommonNamespaces(info, cachedContextUtilitiesNamespace));

            // show only for Silverlight
            var silverlightNamespaces = new List<string>();
            if (UseSilverlight())
                silverlightNamespaces.Add("Csla.Serialization");

            // show only for framework (non Silverlight)
            var frameworkNamespaces = new List<string>();
            if (UseSilverlight())
                frameworkNamespaces.AddRange(GetFrameworkNamespaces(info, unit, cachedContextUtilitiesNamespace));

            // ignore if not usign DAL
            var dalInterfaceNamespaces = new List<string>();
            if (unit.GenerationParams.TargetIsCsla4DAL && !isUnitOfWork)
            {
                dalInterfaceNamespaces.AddRange(GetDalInterfaceNamespaces(info, unit));
                if (UseSilverlight())
                    frameworkNamespaces.AddRange(dalInterfaceNamespaces);
                else
                    commonNamespaces.AddRange(dalInterfaceNamespaces);
            }

            foreach (var namespaceName in commonNamespaces)
            {
                result += "using " + namespaceName + ";" + Environment.NewLine;
            }

            if (UseSilverlight())
            {
                if (UseBoth())
                {
                    result += IfSilverlight(Conditional.Silverlight, 0, ref silverlightLevel, false, true);
                    // #if SILVERLIGHT
                }
                foreach (var namespaceName in silverlightNamespaces)
                {
                    result += "using " + namespaceName + ";" + Environment.NewLine;
                }

                if (!isUnitOfWork)
                {
                    if (UseBoth())
                    {
                        result += IfSilverlight(Conditional.Else, 0, ref silverlightLevel, false, true);
                        // #else
                    }
                    if (UseNoSilverlight())
                    {
                        foreach (var namespaceName in frameworkNamespaces)
                        {
                            result += "using " + namespaceName + ";" + Environment.NewLine;
                        }
                    }
                    if (UseBoth())
                    {
                        result += IfSilverlight(Conditional.End, 0, ref silverlightLevel, false, true);
                        // #endif
                    }
                }
                else if (UseBoth())
                {
                    result += IfSilverlight(Conditional.End, 0, ref silverlightLevel, false, true);
                    // #endif
                }
            }

            result = info.GetAllValueProperties()
                .Where(p => p.PropertyType == TypeCodeEx.ByteArray && AllowNull(p))
                .Aggregate(result,
                    (current, p) =>
                        current + ("using System.Linq; //Added for byte[] helpers" + Environment.NewLine));

            return result;
        }

        private List<string> GetBaseCommonNamespaces(CslaObjectInfo info, CslaGeneratorUnit unit,
            string contextUtilitiesnamespace)
        {
            var result = new List<string>();

            var isUnitOfWork = info.IsUnitOfWork();

            result.Add("System");

            if (!string.IsNullOrEmpty(info.UpdaterType) ||
                (!UseSilverlight() &&
                 !isUnitOfWork &&
                 CurrentUnit.GenerationParams.TargetIsCsla4DAL &&
                 CurrentUnit.GenerationParams.GenerateDTO &&
                 !info.ObjectType.IsObjectType()))
            {
                result.Add("System.Collections.Generic");
            }

            if (!string.IsNullOrEmpty(info.UpdaterType))
            {
                result.Add("System.Collections.Specialized");
                result.Add("System.ComponentModel");
            }

            if (!UseSilverlight() && !isUnitOfWork)
            {
                if (!unit.GenerationParams.TargetIsCsla4DAL || !unit.GenerationParams.GenerateDTO)
                    result.Add("System.Data");
                if (!unit.GenerationParams.TargetIsCsla4DAL)
                    result.Add("System.Data.SqlClient");
            }

            if (!string.IsNullOrEmpty(info.UpdaterType))
            {
                result.Add("System.Linq");
            }

            if (!UseSilverlight() && !isUnitOfWork)
            {
                result.Add("Csla");
                if (!unit.GenerationParams.TargetIsCsla4DAL || !unit.GenerationParams.GenerateDTO)
                    result.Add("Csla.Data");
                if (contextUtilitiesnamespace != string.Empty)
                    result.Add(contextUtilitiesnamespace);
            }
            else
            {
                result.Add("Csla");
            }

            if (result.Contains(string.Empty))
                result.Remove(string.Empty);

            return result;
        }

        private List<string> GetCommonNamespaces(CslaObjectInfo info, string contextUtilitiesnamespace)
        {
            var result = new List<string>();

            var addRules = false;
            var addCommonRules = false;

            if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None)
            {
                if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
                {
                    CslaObjectInfo authzInfo = info;
                    if (info.ObjectType.IsCollectionType())
                    {
                        authzInfo = FindChildInfo(info, info.ItemType);
                    }

                    if (authzInfo != null)
                    {
                        if (authzInfo.AuthzProvider != AuthorizationProvider.Custom)
                        {
                            if ((authzInfo.NewRoles.Trim() != string.Empty) ||
                                (authzInfo.GetRoles.Trim() != string.Empty) ||
                                (authzInfo.UpdateRoles.Trim() != string.Empty) ||
                                (authzInfo.DeleteRoles.Trim() != string.Empty))
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
                            if ((property.ReadRoles.Trim() != string.Empty) ||
                                (property.WriteRoles.Trim() != string.Empty))
                            {
                                addRules = true;
                                addCommonRules = true;
                            }
                        }
                    }
                }
            }

            if (addRules)
                result.Add("Csla.Rules");
            if (addCommonRules)
                result.Add("Csla.Rules.CommonRules");

            foreach (var name in info.Namespaces)
                if (!result.Contains(name))
                    result.Add(name);

            foreach (var prop in info.GetAllChildProperties())
                if (prop.TypeName != info.ObjectName)
                {
                    var childInfo = FindChildInfo(info, prop.TypeName);
                    if (childInfo != null)
                        if (!result.Contains(childInfo.ObjectNamespace) &&
                            !IsNamespaceInScope(info.ObjectNamespace, childInfo.ObjectNamespace))
                            result.Add(childInfo.ObjectNamespace);
                }

            foreach (var prop in info.ConvertValueProperties)
            {
                var converterClass = prop.NVLConverter.Substring(0, prop.NVLConverter.LastIndexOf('.'));
                if (converterClass.Count(s => s == '.') > 0)
                    continue;
                if (converterClass != info.ObjectName)
                {
                    var converterInfo = FindChildInfo(info, converterClass);
                    if (converterInfo != null)
                        if (!result.Contains(converterInfo.ObjectNamespace) &&
                            !IsNamespaceInScope(info.ObjectNamespace, converterInfo.ObjectNamespace))
                            result.Add(converterInfo.ObjectNamespace);
                }
            }

            if (info.ItemType != string.Empty)
            {
                var childInfo = FindChildInfo(info, info.ItemType);
                if (childInfo != null)
                    if (!result.Contains(childInfo.ObjectNamespace) &&
                        !IsNamespaceInScope(info.ObjectNamespace, childInfo.ObjectNamespace))
                        result.Add(childInfo.ObjectNamespace);
            }

            if (info.ParentType != string.Empty)
            {
                var parentInfo = FindChildInfo(info, info.ParentType);
                if (parentInfo != null)
                    if (!result.Contains(parentInfo.ObjectNamespace) &&
                        !IsNamespaceInScope(info.ObjectNamespace, parentInfo.ObjectNamespace))
                        result.Add(parentInfo.ObjectNamespace);
            }

            if (contextUtilitiesnamespace != string.Empty && HasSilverlightLocalDataPortalCreate(info))
                result.Add(contextUtilitiesnamespace);

            if (result.Contains(string.Empty))
                result.Remove(string.Empty);
            result.Sort(String.Compare);

            return result;
        }

        private List<string> GetFrameworkNamespaces(CslaObjectInfo info, CslaGeneratorUnit unit,
            string contextUtilitiesnamespace)
        {
            var result = new List<string>();

            if (!unit.GenerationParams.TargetIsCsla4DAL || !unit.GenerationParams.GenerateDTO)
                result.Add("System.Data");

            if (!unit.GenerationParams.TargetIsCsla4DAL)
                result.Add("System.Data.SqlClient");

            if (CurrentUnit.GenerationParams.GenerateDTO && !info.ObjectType.IsObjectType())
                result.Add("System.Collections.Generic");

            if (!unit.GenerationParams.TargetIsCsla4DAL || !unit.GenerationParams.GenerateDTO)
                result.Add("Csla.Data");
            if (contextUtilitiesnamespace != string.Empty && !HasSilverlightLocalDataPortalCreate(info))
                result.Add(contextUtilitiesnamespace);

            if (result.Contains(string.Empty))
                result.Remove(string.Empty);

            return result;
        }

        private List<string> GetDalInterfaceNamespaces(CslaObjectInfo info, CslaGeneratorUnit unit)
        {
            var result = new List<string>();
            var usesDb = false;

            if (info.ObjectType.IsReadOnlyType() && info.ParentType != string.Empty)
            {
                if (info.CriteriaObjects.Any(criteria => criteria.Properties.Count > 0))
                    usesDb = true;

                if (!usesDb)
                {
                    if (CurrentUnit.GenerationParams.TargetIsCsla4DAL && CurrentUnit.GenerationParams.GenerateDTO)
                        result.Add(GetContextObjectNamespace(info, unit, GenerationStep.DalInterface));

                    return result;
                }
            }

            result.Add(GetContextObjectNamespace(info, unit, GenerationStep.DalInterface));

            if (info.IsNotUnitOfWork() &&
                info.ObjectNamespace != CurrentUnit.GenerationParams.UtilitiesNamespace)
            {
                result.Add(GetDalInterfaceUtilitiesNamespace(unit));
            }

            if (result.Contains(string.Empty))
                result.Remove(string.Empty);
            result.Sort(String.Compare);

            return result;
        }

        public static bool IsNamespaceInScope(string infoNamespace, string candidate)
        {
            if (infoNamespace.IndexOf(candidate, StringComparison.InvariantCulture) != 0)
                return false;

            if (infoNamespace.Length < candidate.Length)
                return false;

            if (infoNamespace.Length == candidate.Length ||
                infoNamespace[candidate.Length] == '.')
                return true;

            return false;
        }

        public static string GetContextUtilitiesNamespace(CslaGeneratorUnit unit, GenerationStep step)
        {
            var result = AdvancedGenerator.GetContextBaseNamespace(unit, step);
            if (unit.GenerationParams.UtilitiesNamespace == unit.GenerationParams.BaseNamespace)
                if (result == unit.GenerationParams.BaseNamespace)
                    return string.Empty;
                else
                    return result;

            return result +
                   unit.GenerationParams.UtilitiesNamespace.Substring(unit.GenerationParams.BaseNamespace.Length);
        }

        private static string GetDalInterfaceUtilitiesNamespace(CslaGeneratorUnit unit)
        {
            var result = AdvancedGenerator.GetContextBaseNamespace(unit, GenerationStep.DalInterface);
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
                return string.Empty;

            parameter = parameter.Replace("\"", "");
            string[] resultSplit = parameter.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            string result = string.Empty;
            foreach (var part in resultSplit)
            {
                result += ", \"" + part.Trim() + "\"";
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
            if (parameter.Type == "String" && result != string.Empty)
                result = "\"" + result.Trim('\"') + "\"";
            else if (parameter.Type == "String[]" && result != string.Empty)
            {
                result = result.Replace("\"", "");
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = string.Empty;
                var isFirst = true;
                foreach (var part in resultSplit)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += "\"" + part.Trim() + "\"";
                }
                result = BuildArrayOrParams(parameter, result);
            }
            else if (parameter.Type.LastIndexOf("[]", StringComparison.InvariantCulture) > -1 &&
                     parameter.Type.LastIndexOf("[]", StringComparison.InvariantCulture) == parameter.Type.Length - 2 && result != string.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = string.Empty;
                var isFirst = true;
                foreach (var part in resultSplit)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += part.Trim();
                }
                result = BuildArrayOrParams(parameter, result);
            }
            else if (parameter.Type == "List<String>" && result != string.Empty)
            {
                result = result.Replace("\"", "");
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = string.Empty;
                var isFirst = true;
                foreach (var part in resultSplit)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += "\"" + part.Trim() + "\"";
                }
                result = "new List<string> {" + result + "}";
            }
            else if (parameter.Type == "List<Int32>" && result != string.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = string.Empty;
                var isFirst = true;
                foreach (var part in resultSplit)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += part.Trim();
                }
                result = "new List<int> {" + result + "}";
            }
            else if (parameter.Type.IndexOf("List<", StringComparison.InvariantCulture) == 0 && result != string.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = string.Empty;
                var isFirst = true;
                foreach (var part in resultSplit)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += part.Trim();
                    result = "new " + parameter.Type + " {" + result + "}";
                }
            }
            return result.Trim();
        }

        public string ReturnRawParameterValue(BusinessRuleConstructorParameter parameter)
        {
            if (parameter.Value == null)
                return string.Empty;

            return parameter.Value.ToString();
        }

        public string ReturnPropertyValue(BusinessRuleProperty property)
        {
            var result = ReturnRawPropertyValue(property);
            if (property.Type == "String" && result != string.Empty)
                result = "\"" + result.Trim('\"') + "\"";
            else if (property.Type == "String[]" && result != string.Empty)
            {
                result = result.Replace("\"", "");
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = string.Empty;
                var isFirst = true;
                foreach (var part in resultSplit)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += "\"" + part.Trim() + "\"";
                }
            }
            else if (property.Type == "List<String>" && result != string.Empty)
            {
                result = result.Replace("\"", "");
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = string.Empty;
                var isFirst = true;
                foreach (var part in resultSplit)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += "\"" + part.Trim() + "\"";
                }
                result = "new List<string> {" + result + "}";
            }
            else if (property.Type == "List<Int32>" && result != string.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = string.Empty;
                var isFirst = true;
                foreach (var part in resultSplit)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += part.Trim();
                    result = "new List<int> {" + result + "}";
                }
            }
            else if (property.Type.Contains("List<") && result != string.Empty)
            {
                var resultSplit = result.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                result = string.Empty;
                var isFirst = true;
                foreach (var part in resultSplit)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        result += ", ";
                    result += part.Trim();
                    result = "new " + property.Type + " {" + result + "}";
                }
            }

            return result.Trim();
        }

        public string ReturnRawPropertyValue(BusinessRuleProperty property)
        {
            if (property.Value == null)
                return string.Empty;

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
            else if (property.Name == "MessageText" && result != string.Empty)
            {
                if (result.IndexOf("*", StringComparison.InvariantCulture) == 0)
                    result = result.Substring(1);
                else
                    result = "\"" + result.Trim('\"') + "\"";
            }

            return result;
        }

        public string ReturnRawPropertyValue(IBusinessRule rule, PropertyInfo property)
        {
            var value = property.GetValue(rule, null);
            if (value == null)
                return string.Empty;
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
                if (Info.IsNotUnitOfWork() &&
                    Info.IsNotNameValueList() &&
                    !TypeHelper.IsCollectionType(Info.ObjectType) &&
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

            if (Info.IsNotUnitOfWork() &&
                Info.IsNotNameValueList() &&
                !TypeHelper.IsCollectionType(Info.ObjectType))
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
                if (Info.IsNotUnitOfWork() &&
                    Info.IsNotNameValueList() &&
                    !TypeHelper.IsCollectionType(Info.ObjectType) &&
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
            if (info.ObjectType.IsCollectionType())
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
            if (info.ObjectType.IsCollectionType())
                info = FindChildInfo(info, info.ItemType);

            foreach (var child in info.GetAllChildProperties())
            {
                if (child.LoadingScheme == LoadingScheme.ParentLoad)
                {
                    var childInfo = FindChildInfo(info, child.TypeName);
                    if (childInfo.ObjectType.IsReadOnlyType())
                        return true;
                }
            }

            return false;
        }

        public bool ParentLoadsCollectionChildren(CslaObjectInfo info)
        {
            if (info.ObjectType.IsCollectionType())
                info = FindChildInfo(info, info.ItemType);

            return info.GetCollectionChildProperties().Any(child => child.LoadingScheme == LoadingScheme.ParentLoad);
        }

        public bool SelfLoadsChildren(CslaObjectInfo info)
        {
            if (info.ObjectType.IsCollectionType())
                info = FindChildInfo(info, info.ItemType);

            /*foreach (var child in info.GetAllChildProperties())
                if (!child.LazyLoad && child.LoadingScheme == LoadingScheme.SelfLoad)
                {
                    return true;
                }

            return false;*/

            return info.GetAllChildProperties()
                .Any(child => !child.LazyLoad && child.LoadingScheme == LoadingScheme.SelfLoad);
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
                return string.Empty;
            }
        }

        public string GetNativeType(ValueProperty prop)
        {
            string nativeType = null;
            if (!String.IsNullOrEmpty(prop.DbBindColumn.NativeType))
                nativeType = ParseNativeType(prop.DbBindColumn.NativeType);
            if (String.IsNullOrEmpty(nativeType))
            {
                OutputWindow.Current.AddOutputInfo(String.Format(
                    "{0}: Unable to parse database native type from DbBindColumn, infering type from property type.",
                    prop.PropertyType));
                nativeType = prop.PropertyType.GetSqlDbType().ToString();
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

            return string.Empty;
        }

        #endregion

        #region ParameterSet

        /// <summary>
        /// Gets the parameter set - for plain properties.
        /// </summary>
        /// <param name="info">The CslaObjectInfo.</param>
        /// <param name="prop">The prop.</param>
        /// <returns></returns>
        public virtual string GetParameterSet(CslaObjectInfo info, Property prop)
        {
            return GetParameterSet(info, prop, false, false);
        }

        /// <summary>
        /// Gets the parameter set - for criteria properties.
        /// </summary>
        /// <param name="info">The CslaObjectInfo.</param>
        /// <param name="prop">The prop.</param>
        /// <param name="isCriteria">if set to <c>true</c> [criteria].</param>
        /// <returns></returns>
        public virtual string GetParameterSet(CslaObjectInfo info, Property prop, bool isCriteria)
        {
            return GetParameterSet(info, prop, isCriteria, false);
        }

        public virtual string GetParameterSet(CslaObjectInfo info, Property prop, bool isCriteria, bool isParameter)
        {
            TypeCodeEx propType = prop.PropertyType;
            try
            {
                propType = (prop as ValueProperty).GetBackingFieldType();
            }
            catch (Exception)
            {
            }

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
                if (propType.IsNullableType())
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

        #endregion

        #region Basic Formats

        public virtual string FormatGeneralParameter(CslaObjectInfo info, Property prop, bool isCriteria,
            bool isParameter, bool isCaller)
        {
            if (isCriteria)
            {
                return "crit." + FormatPascal(prop.Name);
            }

            string result;
            var propType = prop.PropertyType;
            try
            {
                propType = (prop as ValueProperty).GetBackingFieldType();
            }
            catch (Exception)
            {
            }

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
            var response = string.Empty;

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
            var response = string.Empty;

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
            var response = string.Empty;

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

        // TODO: on ReadOnly objects, forbid Managed and Unmanaged with TypeConversion. Why not TypeConversion?

        public virtual string GetInitValue(CslaObjectInfo info, ValueProperty prop, TypeCodeEx typeCode)
        {
            if (!HasCreateCriteriaDataPortal(info))
            {
                if (prop.DefaultValue != string.Empty)
                    return prop.DefaultValue;
            }

            //if (AllowNull(prop) && typeCode != TypeCodeEx.SmartDate)
            if (AllowNull(prop))
                return "null";

            return GetInitValue(typeCode);
        }

        public static string GetDataTypeGeneric(Property prop, TypeCodeEx field)
        {
            var type = GetDataType(field);
            if (AllowNull(prop))
            {
                if (field.IsNullableType())
                    type += "?";
            }
            return type;
        }

        public static string GetDataTypeInitExpression(Property prop, TypeCodeEx field)
        {
            var type = GetDataType(field);
            if (field.IsNullableType())
            {
                if (AllowNull(prop))
                    return "null";

                return string.Format("new {0}()", type);
            }
            return "null";
        }

        public string FieldDeclare(CslaObjectInfo info, ValueProperty prop)
        {
            var response = string.Empty;
            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.NoProperty)
            {
                response = CheckNotUndoable(prop, info);
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
            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                var noSilverlightStatement = string.Empty;
                var silverlightStatement = string.Empty;
                if (UseNoSilverlight())
                    noSilverlightStatement = PropertyInfoDeclare(info, prop, false);
                if (UseSilverlight())
                    silverlightStatement = PropertyInfoDeclare(info, prop, true);
                if (UseBoth() && noSilverlightStatement != silverlightStatement)
                {
                    response += "#if SILVERLIGHT" + Environment.NewLine;
                    response += new string(' ', 8) +
                                "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" +
                                Environment.NewLine;
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

        private string PropertyInfoDeclare(CslaObjectInfo info, ValueProperty prop, bool isSilverlight)
        {
            // "private static readonly PropertyInfo<{0}> {1} = RegisterProperty<{0}>(p => p.{2}, \"{3}\"{4});",
            var response = string.Empty;

            if (!prop.Undoable && info.ObjectType.IsEditableType() &&
                prop.DeclarationMode != PropertyDeclaration.AutoProperty &&
                prop.DeclarationMode != PropertyDeclaration.ClassicProperty &&
                prop.DeclarationMode != PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += "[NotUndoable]" + Environment.NewLine + new string(' ', 8);
            }
            response +=
                String.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => {3}, \"{4}\"{5}{6});",
                    PropertyInfoVisibility(),
                    (prop.DeclarationMode == PropertyDeclaration.Managed ||
                     prop.DeclarationMode == PropertyDeclaration.Unmanaged)
                        ? GetDataTypeGeneric(prop, prop.PropertyType)
                        : GetDataTypeGeneric(prop, prop.BackingFieldType),
                    FormatPropertyInfoName(prop.Name),
                    (String.IsNullOrEmpty(prop.Interfaces)
                        ? "p." + FormatPascal(prop.Name)
                        : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) + ") p)." +
                          FormatPascal(prop.Name)),
                    prop.FriendlyName,
                    GetDefault(info, prop),
                    GetRelationhipType(info, prop));

            return response;
        }

        private static string GetDefault(CslaObjectInfo info, ValueProperty prop)
        {
            if (HasCreateCriteriaDataPortal(info))
                return string.Empty;

            if (prop.DefaultValue != string.Empty)
                return ", " + prop.DefaultValue;

            if (!prop.Nullable)
                return string.Empty;

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
            if (info.ObjectType.IsReadOnlyType())
                return "";

            var response = string.Empty;

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
            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                var noSilverlightStatement = string.Empty;
                var silverlightStatement = string.Empty;
                if (UseNoSilverlight())
                    noSilverlightStatement = PropertyInfoChildDeclare(info, prop, false);
                if (UseSilverlight())
                    silverlightStatement = PropertyInfoChildDeclare(info, prop, true);
                if (UseBoth() && noSilverlightStatement != silverlightStatement)
                {
                    response += "#if SILVERLIGHT" + Environment.NewLine;
                    response += new string(' ', 8) +
                                "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" +
                                Environment.NewLine;
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

            if (!prop.Undoable && info.ObjectType.IsEditableType() &&
                prop.DeclarationMode != PropertyDeclaration.AutoProperty &&
                prop.DeclarationMode != PropertyDeclaration.ClassicProperty &&
                prop.DeclarationMode != PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += "[NotUndoable]" + Environment.NewLine + new string(' ', 8);
            }
            response +=
                String.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => {3}, \"{4}\"{5});",
                    PropertyInfoVisibility(),
                    prop.TypeName,
                    FormatPropertyInfoName(prop.Name),
                    (String.IsNullOrEmpty(prop.Interfaces)
                        ? "p." + FormatPascal(prop.Name)
                        : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) + ") p)." +
                          FormatPascal(prop.Name)),
                    prop.FriendlyName,
                    GetRelationhipType(info, prop));

            return response;
        }

        public string PropertyInfoParentListDeclare(CslaObjectInfo info)
        {
            var response = string.Empty;

            var noSilverlightStatement = string.Empty;
            var silverlightStatement = string.Empty;
            if (UseNoSilverlight())
                noSilverlightStatement = PropertyInfoParentListDeclare(info, false);
            if (UseSilverlight())
                silverlightStatement = PropertyInfoParentListDeclare(info, true);
            if (UseBoth() && noSilverlightStatement != silverlightStatement)
            {
                response += "#if SILVERLIGHT" + Environment.NewLine;
                response += new string(' ', 8) +
                            "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" +
                            Environment.NewLine;
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

            return response;
        }

        private string PropertyInfoParentListDeclare(CslaObjectInfo info, bool isSilverlight)
        {
            // "private static readonly PropertyInfo<{1]> ParentListProperty = RegisterProperty<{1}>(p => p.ParentList);",
            var response = string.Empty;

            response +=
                String.Format(
                    "{0} static readonly PropertyInfo<{1}> ParentListProperty = RegisterProperty<{1}>(p => p.ParentList);",
                    PropertyInfoVisibility(),
                    info.ParentType);

            return response;
        }

        public string PropertyInfoUoWDeclare(CslaObjectInfo info, UnitOfWorkProperty prop)
        {
            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                var noSilverlightStatement = string.Empty;
                var silverlightStatement = string.Empty;
                if (UseNoSilverlight())
                    noSilverlightStatement = PropertyInfoUoWDeclare(info, prop, false);
                if (UseSilverlight())
                    silverlightStatement = PropertyInfoUoWDeclare(info, prop, true);
                if (UseBoth() && noSilverlightStatement != silverlightStatement)
                {
                    response += "#if SILVERLIGHT" + Environment.NewLine;
                    response += new string(' ', 8) +
                                "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" +
                                Environment.NewLine;
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

        private string PropertyInfoUoWDeclare(CslaObjectInfo info, UnitOfWorkProperty prop, bool isSilverlight)
        {
            // "private static readonly PropertyInfo<{0}> {1} = RegisterProperty<{0}>(p => p.{2}, \"{3}\"{4});",
            var response =
                String.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => p.{3});",
                    PropertyInfoVisibility(),
                    prop.TypeName,
                    FormatPropertyInfoName(prop.Name),
                    FormatPascal(prop.Name));

            return response;
        }

        public string PropertyInfoCriteriaDeclare(CslaObjectInfo info, CriteriaProperty prop)
        {
            var response = string.Empty;

            var noSilverlightStatement = string.Empty;
            var silverlightStatement = string.Empty;
            if (UseNoSilverlight())
                noSilverlightStatement = PropertyInfoCriteriaDeclare(info, prop, false);
            if (UseSilverlight())
                silverlightStatement = PropertyInfoCriteriaDeclare(info, prop, true);
            if (UseBoth() && noSilverlightStatement != silverlightStatement)
            {
                response += "#if SILVERLIGHT" + Environment.NewLine;
                response += new string(' ', 8) +
                            "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" +
                            Environment.NewLine;
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

            return response;
        }

        private string PropertyInfoCriteriaDeclare(CslaObjectInfo info, CriteriaProperty prop, bool isSilverlight)
        {
            // "private static readonly PropertyInfo<{0}> {1} = RegisterProperty<{0}>(p => p.{2});",
            var response = string.Empty;

            response +=
                String.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => p.{3});",
                    PropertyInfoVisibility(),
                    GetDataTypeGeneric(prop, prop.PropertyType),
                    FormatPropertyInfoName(prop.Name),
                    FormatPascal(prop.Name));

            return response;
        }

        public string PropertyInfoUoWCriteriaDeclare(CslaObjectInfo info, UnitOfWorkCriteriaManager.ElementCriteria prop)
        {
            var response = string.Empty;

            var noSilverlightStatement = string.Empty;
            var silverlightStatement = string.Empty;
            if (UseNoSilverlight())
                noSilverlightStatement = PropertyInfoUoWCriteriaDeclare(info, prop, false);
            if (UseSilverlight())
                silverlightStatement = PropertyInfoUoWCriteriaDeclare(info, prop, true);
            if (UseBoth() && noSilverlightStatement != silverlightStatement)
            {
                response += "#if SILVERLIGHT" + Environment.NewLine;
                response += new string(' ', 8) +
                            "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" +
                            Environment.NewLine;
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

            return response;
        }

        private string PropertyInfoUoWCriteriaDeclare(CslaObjectInfo info,
            UnitOfWorkCriteriaManager.ElementCriteria prop, bool isSilverlight)
        {
            // "private static readonly PropertyInfo<{0}> {1} = RegisterProperty<{0}>(p => p.{2});",
            var response = string.Empty;

            response +=
                String.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => p.{3});",
                    PropertyInfoVisibility(),
                    prop.Type,
                    FormatPropertyInfoName(prop.Name),
                    FormatPascal(prop.Name));

            return response;
        }

        private string PropertyInfoVisibility()
        {
            return (CurrentUnit.GenerationParams.UsePublicPropertyInfo) ? "public" : "private";
        }

        private string GetRelationhipType(CslaObjectInfo info, ChildProperty prop)
        {
            if (info.ObjectType.IsReadOnlyType())
                return "";

            var response = string.Empty;

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
            var response = string.Empty;
            bool isReadOnly = prop.ReadOnly;

            if (info.IsReadOnlyObject() && CurrentUnit.GenerationParams.ForceReadOnlyProperties)
            {
                isReadOnly = true;
            }
            else if (!String.IsNullOrEmpty(prop.Interfaces))
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
                    (String.IsNullOrEmpty(prop.Interfaces) ? GetPropertyAccess(prop) + " " : ""),
                    GetDataTypeGeneric(prop, prop.PropertyType),
                    (String.IsNullOrEmpty(prop.Interfaces) ? FormatPascal(prop.Name) : prop.Interfaces));
                response += "        {" + Environment.NewLine;
                response += PropertyDeclareGetter(prop);

                response += PropertyDeclareSetter(isReadOnly, info.IsReadOnlyObject(), prop,
                    convertPropertyName);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                     prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += String.Format("{0}{1} {2}" + Environment.NewLine,
                    (String.IsNullOrEmpty(prop.Interfaces) ? GetPropertyAccess(prop) + " " : ""),
                    GetDataTypeGeneric(prop, prop.PropertyType),
                    (String.IsNullOrEmpty(prop.Interfaces) ? FormatPascal(prop.Name) : prop.Interfaces));
                response += "        {" + Environment.NewLine;
                response += PropertyDeclareGetter(prop);

                response += PropertyDeclareSetter(isReadOnly, info.IsReadOnlyObject(), prop,
                    convertPropertyName);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += String.Format("{0}{1} {2} {{ get; {3}set; }}",
                    (String.IsNullOrEmpty(prop.Interfaces) ? GetPropertyAccess(prop) + " " : ""),
                    GetDataTypeGeneric(prop, prop.PropertyType),
                    (String.IsNullOrEmpty(prop.Interfaces) ? FormatPascal(prop.Name) : prop.Interfaces),
                    PropertyDeclareSetter(isReadOnly, info.IsReadOnlyObject(), prop,
                        string.Empty));
            }

            return response;
        }

        public string PropertyConvertDeclare(CslaObjectInfo info, ConvertValueProperty prop)
        {
            var sourceProperty = info.ValueProperties.Find(prop.SourcePropertyName);
            //var sourceDeclarationMode = sourceProperty.DeclarationMode;
            var response = string.Empty;
            var isReadOnly = prop.ReadOnly;

            if (info.IsReadOnlyObject() && CurrentUnit.GenerationParams.ForceReadOnlyProperties)
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
            response += "                if (" +
                        (sourceProperty.Nullable ? sourceProperty.Name + ".HasValue && " : string.Empty) +
                        prop.NVLConverter + "().ContainsKey(" + prop.SourcePropertyName +
                        (sourceProperty.Nullable ? ".Value" : string.Empty) + "))" + Environment.NewLine;
            response += "                    result = " + prop.NVLConverter + "().GetItemByKey(" +
                        prop.SourcePropertyName + (sourceProperty.Nullable ? ".Value" : string.Empty) + ").Value;" +
                        Environment.NewLine;
            //response += "                if (" + prop.NVLConverter + "().ContainsKey(ReadProperty(" + prop.SourcePropertyName + "Property)))" + Environment.NewLine;
            //response += "                    result = " + prop.NVLConverter + "().GetItemByKey(ReadProperty(" + prop.SourcePropertyName + "Property)).Value;" + Environment.NewLine;
            response += "                return result;" + Environment.NewLine;
            response += "            }" + Environment.NewLine;

            if (!isReadOnly)
            {
                response += "            set" + Environment.NewLine;
                response += "            {" + Environment.NewLine;
                response += "                if (" + prop.NVLConverter + "().ContainsValue(value))" +
                            Environment.NewLine;
                response += "                {" + Environment.NewLine;
                response += "                    var result = " + prop.NVLConverter + "().GetItemByValue(value).Key;" +
                            Environment.NewLine;
                response += "                    if (result != " + prop.SourcePropertyName + ")" + Environment.NewLine;
                response += "                        " + prop.SourcePropertyName + " = result;" + Environment.NewLine;
                //response += "                    if (result != ReadProperty(" + prop.SourcePropertyName + "Property))" + Environment.NewLine;
                //response += "                        SetProperty(" + prop.SourcePropertyName + "Property, result);" + Environment.NewLine;
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

            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response +=
                    String.Format("            get {{ return {0}{1}({2}); }}{3}",
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

        private string PropertyDeclareSetter(bool isReadOnly, bool isReadOnlyObject, ValueProperty prop,
            string convertPropertyName)
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
                convertSnippet = Environment.NewLine + "                OnPropertyChanged(\"" + convertPropertyName +
                                 "\");";
                convertSnippetPost = Environment.NewLine + "            }" + Environment.NewLine;
            }

            var response = string.Empty;
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

        private string CheckNotUndoable(ValueProperty prop, CslaObjectInfo info)
        {
            var response = string.Empty;
            if (!prop.Undoable && info.ObjectType.IsEditableType())
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
            var statement = string.Empty;

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
            var statement = string.Empty;

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

        public virtual string GetDtoLoaderStatement(ValueProperty prop)
        {
            var statement = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                statement += String.Format("{0} = {1}",
                    FormatProperty(prop.Name),
                    GetDtoStatement(prop));
            }
            else
            {
                statement += String.Format("LoadProperty({0}, {1})",
                    FormatPropertyInfoName(prop.Name),
                    GetDtoStatement(prop));
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
            if (value.IndexOf("$", StringComparison.InvariantCulture) != 0)
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
                if (prop.Name == valueProp.Name)
                    return GetFieldLoaderStatement(valueProp.DeclarationMode,
                        prop.Name + ConvertTextToSmartDate(valueProp), value);
            }
            foreach (var childProp in info.GetAllChildProperties())
            {
                if (prop.Name == childProp.Name)
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
                    /*if (TypeHelper.IsCollectionType(ci.ObjectType))
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
                        /*if (TypeHelper.IsCollectionType(ci.ObjectType))
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
            if (info.ObjectType.IsCollectionType())
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

        public ChildPropertyCollection GetParentLoadAllGrandChildPropertiesInHierarchy(CslaObjectInfo info,
            bool firstRun)
        {
            if (info.ObjectType.IsCollectionType())
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

        public static bool IsChildParentLoaded(CslaObjectInfo info)
        {
            var selfLoadNone = false;
            var parent = info.Parent.CslaObjects.Find(info.ParentType);
            if (parent != null)
            {
                foreach (var childProp in parent.ChildCollectionProperties)
                {
                    if (childProp.TypeName == info.ObjectName)
                    {
                        selfLoadNone = childProp.LoadingScheme == LoadingScheme.ParentLoad;
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
            if (info.ObjectType.IsCollectionType())
                ancestorIsCollection = true;
            else
                ancestorIsCollection = false;

            if (info.ParentType == string.Empty) // no parent specified; this is the last ancestor
                return level;

            var parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
            if (parentInfo == null) // there is no ancestor object; for all purposes, this is the last ancestor
                return level;

            level++;
            if (parentInfo.ObjectType.IsCollectionType()) // is a collection; so find the next ancestor
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
            var response = string.Empty;

            bool isReadOnly = prop.ReadOnly;

            if (info.IsReadOnlyObject())
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
                if (!String.IsNullOrEmpty(prop.Interfaces))
                {
                    isReadOnly = false;
                }
            }

            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                response += String.Format("{0}{1} {2}" + Environment.NewLine,
                    (String.IsNullOrEmpty(prop.Interfaces) ? GetPropertyAccess(prop) + " " : ""),
                    prop.TypeName,
                    (String.IsNullOrEmpty(prop.Interfaces) ? FormatPascal(prop.Name) : prop.Interfaces));
                response += "        {" + Environment.NewLine;
                response += ChildPropertyDeclareGetter(info, prop);

                response += ChildPropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += String.Format("{0}{1} {2}" + Environment.NewLine,
                    (String.IsNullOrEmpty(prop.Interfaces) ? GetPropertyAccess(prop) + " " : ""),
                    prop.TypeName,
                    (String.IsNullOrEmpty(prop.Interfaces) ? FormatPascal(prop.Name) : prop.Interfaces));
                response += "        {" + Environment.NewLine;
                response += ChildPropertyDeclareGetter(info, prop);

                response += ChildPropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else //if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += String.Format("{0}{1} {2} {{ get; {3}set; }}",
                    (String.IsNullOrEmpty(prop.Interfaces) ? GetPropertyAccess(prop) + " " : ""),
                    prop.TypeName,
                    (String.IsNullOrEmpty(prop.Interfaces) ? FormatPascal(prop.Name) : prop.Interfaces),
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
            bool isReadOnly = prop.ReadOnly;

            if (info.IsReadOnlyObject())
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
                if (!String.IsNullOrEmpty(prop.Interfaces))
                {
                    isReadOnly = false;
                }
            }

            var response = string.Empty;

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

            var response = string.Empty;

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

        /*private string CheckNotUndoable(ChildProperty prop, CslaObjectInfo info)
        {
            var response = string.Empty;
            if (!prop.Undoable && TypeHelper.IsEditableType(info.ObjectType))
                response = "[NotUndoable]" + Environment.NewLine + "        ";

            return response;
        }*/

        private string ChildPropertyDeclareSetLazyLoad(ChildProperty prop)
        {
            var response = string.Empty;
            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response += String.Format("                LoadProperty({0}, value);{1}",
                    FormatPropertyInfoName(prop.Name), Environment.NewLine);
                response += String.Format("                OnPropertyChanged({0});{1}",
                    FormatPropertyInfoName(prop.Name), Environment.NewLine);
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += String.Format("                {0} = value;{1}", FormatFieldName(prop.Name),
                    Environment.NewLine);
                response += String.Format("                OnPropertyChanged(\"{0}\");{1}", FormatPascal(prop.Name),
                    Environment.NewLine);
            }

            return response;
        }

        private string ChildLazyLoadManaged(CslaObjectInfo info, ChildProperty prop)
        {
            var childInfo = info.Parent.CslaObjects.Find(prop.TypeName);

            if (info.ObjectType.IsEditableType() && childInfo.ObjectType.IsEditableType())
                return ChildLazyLoadManagedEditable(info, prop);

            return ChildLazyLoadManagedReadOnly(info, prop);
        }

        private string ChildLazyLoadManagedEditable(CslaObjectInfo info, ChildProperty prop)
        {
            var result = string.Empty;
            var conditionalDirective = false;
            var asyncWasGenerated = false;

            if (UseSilverlight())
            {
                if (UseNoSilverlight())
                {
                    if (CurrentUnit.GenerationParams.GenerateAsynchronous &&
                        (CurrentUnit.GenerationParams.GenerateSilverlight4 || UseChildFactoryHelper))
                    {
                        asyncWasGenerated = true;
                        if (CurrentUnit.GenerationParams.GenerateSynchronous)
                        {
                            conditionalDirective = true;
                            result += "#if SILVERLIGHT || ASYNC" + Environment.NewLine;
                        }
                    }
                    else if (CurrentUnit.GenerationParams.GenerateAsynchronous ||
                             CurrentUnit.GenerationParams.GenerateSynchronous)
                    {
                        conditionalDirective = true;
                        result += "#if SILVERLIGHT" + Environment.NewLine;
                    }
                }
                result += EditableChildLazyLoadAsync(info, prop, CurrentUnit.GenerationParams.SilverlightUsingServices);
            }

            if (!asyncWasGenerated && CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                if (conditionalDirective && CurrentUnit.GenerationParams.GenerateSynchronous)
                    result += "#elif ASYNC" + Environment.NewLine;
                else if (conditionalDirective)
                    result += "#else" + Environment.NewLine;
                else if (CurrentUnit.GenerationParams.GenerateSynchronous)
                {
                    conditionalDirective = true;
                    result += "#if ASYNC" + Environment.NewLine;
                }
                result += EditableChildLazyLoadAsync(info, prop, false);
            }

            if (CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                if (conditionalDirective)
                    result += "#else" + Environment.NewLine;
                result += EditableChildLazyLoadSync(info, prop);
            }

            if (conditionalDirective)
                result += "#endif" + Environment.NewLine;

            return result;
        }

        private string EditableChildLazyLoadAsync(CslaObjectInfo info, ChildProperty prop, bool isLocal)
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

            var result = string.Empty;
            result += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                FormatPropertyInfoName(prop.Name));
            result += "                {" + Environment.NewLine;
            result += String.Format("                    LoadProperty({0}, null);" + Environment.NewLine,
                FormatPropertyInfoName(prop.Name));
            result += "                    if (this.IsNew)" + Environment.NewLine;
            result += "                    {" + Environment.NewLine;
            if (UseChildFactoryHelper)
                result += String.Format("                        {0}.New{0}((o, e) =>" + Environment.NewLine,
                    prop.TypeName);
            else
                result +=
                    string.Format(
                        "                        DataPortal.BeginCreate<{0}>((o, e) =>" + Environment.NewLine,
                        prop.TypeName);
            result += "                            {" + Environment.NewLine;
            result += "                                if (e.Error != null)" + Environment.NewLine;
            result += "                                    throw e.Error;" + Environment.NewLine;
            result += "                                else" + Environment.NewLine;
            result += "                                {" + Environment.NewLine;
            result += "                                    // set the property so OnPropertyChanged is raised" +
                      Environment.NewLine;
            result += String.Format("                                    {0} = e.Object;" + Environment.NewLine,
                (String.IsNullOrEmpty(prop.Interfaces)
                    ? FormatPascal(prop.Name)
                    : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) + ") this)." +
                      FormatPascal(prop.Name)));
            result += "                                }" + Environment.NewLine;
            if (!UseChildFactoryHelper && isLocal)
                result += "                            }, DataPortal.ProxyModes.LocalOnly);" + Environment.NewLine;
            else
                result += "                            });" + Environment.NewLine;
            result += "                        return null;" + Environment.NewLine;
            result += "                    }" + Environment.NewLine;
            result += "                    else" + Environment.NewLine;
            result += "                    {" + Environment.NewLine;
            if (UseChildFactoryHelper)
            {
                result += String.Format("                        {0}.Get{0}({1}, (o, e) =>" +
                                        Environment.NewLine, prop.TypeName,
                    GetFieldReaderStatementList(info, prop));
            }
            else
            {
                result += string.Format("                        DataPortal.BeginFetch<{0}>({1}, (o, e) =>" +
                                        Environment.NewLine, prop.TypeName,
                    GetFieldReaderStatementList(info, prop));
            }
            result += "                            {" + Environment.NewLine;
            result += "                                if (e.Error != null)" + Environment.NewLine;
            result += "                                    throw e.Error;" + Environment.NewLine;
            result += "                                else" + Environment.NewLine;
            result += "                                {" + Environment.NewLine;
            result += "                                    // set the property so OnPropertyChanged is raised" +
                      Environment.NewLine;
            result += String.Format("                                    {0} = e.Object;" + Environment.NewLine,
                (String.IsNullOrEmpty(prop.Interfaces)
                    ? FormatPascal(prop.Name)
                    : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) + ") this)." +
                      FormatPascal(prop.Name)));
            result += "                                }" + Environment.NewLine;
            if (!UseChildFactoryHelper && isLocal)
                result += "                            }, DataPortal.ProxyModes.LocalOnly);" + Environment.NewLine;
            else
                result += "                            });" + Environment.NewLine;
            result += "                        return null;" + Environment.NewLine;
            result += "                    }" + Environment.NewLine;
            result += "                }" + Environment.NewLine;
            result += "                else" + Environment.NewLine;
            result += "                {" + Environment.NewLine;
            result += "    " + ChildPropertyDeclareGetReturner(prop);
            result += "                }" + Environment.NewLine;

            return result;
        }

        private string EditableChildLazyLoadSync(CslaObjectInfo info, ChildProperty prop)
        {
            /* Editable Synchronous

            if (!FieldManager.FieldExists(ChildrenProperty))
                if (this.IsNew)
                    Children = ChildType.NewChildType();
                else
                    Children = ChildType.GetChildType(this);

            return GetProperty(ChildrenProperty);*/

            var result = string.Empty;
            result += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                FormatPropertyInfoName(prop.Name));
            result += "                    if (this.IsNew)" + Environment.NewLine;
            if (UseChildFactoryHelper)
            {
                result += String.Format("                        {0} = {1}.New{1}();" + Environment.NewLine,
                    (String.IsNullOrEmpty(prop.Interfaces)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) +
                          ") this)." + FormatPascal(prop.Name)), prop.TypeName);
            }
            else
            {
                result +=
                    String.Format("                        {0} = DataPortal.Create<{1}>();" + Environment.NewLine,
                        (String.IsNullOrEmpty(prop.Interfaces)
                            ? FormatPascal(prop.Name)
                            : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) +
                              ") this)." + FormatPascal(prop.Name)), prop.TypeName);
            }
            result += "                    else" + Environment.NewLine;
            if (UseChildFactoryHelper)
            {
                result += String.Format("                        {0} = {1}.Get{1}({2});" + Environment.NewLine,
                    (String.IsNullOrEmpty(prop.Interfaces)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) +
                          ") this)." + FormatPascal(prop.Name)), prop.TypeName, GetFieldReaderStatementList(info, prop));
            }
            else
            {
                result +=
                    String.Format("                        {0} = DataPortal.Fetch<{1}>({2});" + Environment.NewLine,
                        (String.IsNullOrEmpty(prop.Interfaces)
                            ? FormatPascal(prop.Name)
                            : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) +
                              ") this)." + FormatPascal(prop.Name)), prop.TypeName,
                        GetFieldReaderStatementList(info, prop));
            }
            result += Environment.NewLine;
            result += ChildPropertyDeclareGetReturner(prop);

            return result;
        }

        private string ChildLazyLoadManagedReadOnly(CslaObjectInfo info, ChildProperty prop)
        {
            var result = string.Empty;
            var conditionalDirective = false;
            var asyncWasGenerated = false;

            if (UseSilverlight())
            {
                if (UseNoSilverlight())
                {
                    if (CurrentUnit.GenerationParams.GenerateAsynchronous &&
                        (CurrentUnit.GenerationParams.GenerateSilverlight4 || UseChildFactoryHelper))
                    {
                        asyncWasGenerated = true;
                        if (CurrentUnit.GenerationParams.GenerateSynchronous)
                        {
                            conditionalDirective = true;
                            result += "#if SILVERLIGHT || ASYNC" + Environment.NewLine;
                        }
                    }
                    else if (CurrentUnit.GenerationParams.GenerateAsynchronous ||
                             CurrentUnit.GenerationParams.GenerateSynchronous)
                    {
                        conditionalDirective = true;
                        result += "#if SILVERLIGHT" + Environment.NewLine;
                    }
                }
                result += ReadOnlyChildLazyLoadAsync(info, prop, CurrentUnit.GenerationParams.SilverlightUsingServices);
            }

            if (!asyncWasGenerated && CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                if (conditionalDirective && CurrentUnit.GenerationParams.GenerateSynchronous)
                    result += "#elif ASYNC" + Environment.NewLine;
                else if (conditionalDirective)
                    result += "#else" + Environment.NewLine;
                else if (CurrentUnit.GenerationParams.GenerateSynchronous)
                {
                    conditionalDirective = true;
                    result += "#if ASYNC" + Environment.NewLine;
                }
                result += ReadOnlyChildLazyLoadAsync(info, prop, false);
            }

            if (CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                if (conditionalDirective)
                    result += "#else" + Environment.NewLine;
                result += ReadOnlyChildLazyLoadSync(info, prop);
            }

            if (conditionalDirective)
                result += "#endif" + Environment.NewLine;

            return result;
        }

        private string ReadOnlyChildLazyLoadAsync(CslaObjectInfo info, ChildProperty prop, bool isLocal)
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

            var result = string.Empty;
            result += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                FormatPropertyInfoName(prop.Name));
            result += "                {" + Environment.NewLine;
            result += String.Format("                    LoadProperty({0}, null);" + Environment.NewLine,
                FormatPropertyInfoName(prop.Name));
            if (UseChildFactoryHelper)
            {
                result += String.Format("                    {0}.Get{0}({1}, (o, e) =>" + Environment.NewLine,
                    prop.TypeName, GetFieldReaderStatementList(info, prop));
            }
            else
            {
                result +=
                    string.Format("                    DataPortal.BeginFetch<{0}>({1}, (o, e) =>" + Environment.NewLine,
                        prop.TypeName, GetFieldReaderStatementList(info, prop));
            }
            result += "                        {" + Environment.NewLine;
            result += "                            if (e.Error != null)" + Environment.NewLine;
            result += "                                throw e.Error;" + Environment.NewLine;
            result += "                            else" + Environment.NewLine;
            result += "                            {" + Environment.NewLine;
            result += "                                // set the property so OnPropertyChanged is raised" +
                      Environment.NewLine;
            result += String.Format("                                {0} = e.Object;" + Environment.NewLine,
                (String.IsNullOrEmpty(prop.Interfaces)
                    ? FormatPascal(prop.Name)
                    : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) + ") this)." +
                      FormatPascal(prop.Name)));
            result += "                            }" + Environment.NewLine;
            if (!UseChildFactoryHelper && isLocal)
                result += "                        }, DataPortal.ProxyModes.LocalOnly);" + Environment.NewLine;
            else
                result += "                        });" + Environment.NewLine;
            result += "                    return null;" + Environment.NewLine;
            result += "                }" + Environment.NewLine;
            result += "                else" + Environment.NewLine;
            result += "                {" + Environment.NewLine;
            result += "    " + ChildPropertyDeclareGetReturner(prop);
            result += "                }" + Environment.NewLine;

            return result;
        }

        private string ReadOnlyChildLazyLoadSync(CslaObjectInfo info, ChildProperty prop)
        {
            /* ReadOnly Synchronous

            if (!FieldManager.FieldExists(ChildrenProperty))
                Children = ChildType.GetChildType(this);

            return GetProperty(ChildrenProperty);*/

            var result = string.Empty;
            result += String.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                FormatPropertyInfoName(prop.Name));
            if (UseChildFactoryHelper)
            {
                result += String.Format("                    {0} = {1}.Get{1}({2});" + Environment.NewLine,
                    (String.IsNullOrEmpty(prop.Interfaces)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) +
                          ") this)." + FormatPascal(prop.Name)), prop.TypeName, GetFieldReaderStatementList(info, prop));
            }
            else
            {
                result += String.Format("                    {0} = DataPortal.Fetch<{1}>({2});" + Environment.NewLine,
                    (String.IsNullOrEmpty(prop.Interfaces)
                        ? FormatPascal(prop.Name)
                        : "((" + prop.Interfaces.Substring(0, prop.Interfaces.LastIndexOf('.')) +
                          ") this)." + FormatPascal(prop.Name)), prop.TypeName, GetFieldReaderStatementList(info, prop));
            }
            result += Environment.NewLine;
            result += ChildPropertyDeclareGetReturner(prop);

            return result;
        }

        private string ChildLazyLoadClassic(CslaObjectInfo info, ChildProperty prop)
        {
            var response = string.Empty;

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
                FormatFieldName(prop.Name), prop.TypeName, GetFieldReaderStatementList(info, prop));
            response += String.Format("                    {0} = true;" + Environment.NewLine,
                FormatFieldName(prop.Name + "Loaded"));
            response += "                }" + Environment.NewLine;
            response += Environment.NewLine;
            response += ChildPropertyDeclareGetReturner(prop);

            return response;
        }

        private string GetFieldReaderStatementList(CslaObjectInfo info, ChildProperty prop)
        {
            var response = string.Empty;

            var isParentCollection = false;
            var parentInfo = info.Parent.CslaObjects.Find(info.ParentType);
            if (parentInfo != null)
                isParentCollection = parentInfo.ObjectType.IsCollectionType();

            if (isParentCollection)
            {
                for (var parentLoadProperties = 0;
                    parentLoadProperties < prop.ParentLoadProperties.Count;
                    parentLoadProperties++)
                {
                    response += FormatFieldForPropertyName(info, prop.ParentLoadProperties[parentLoadProperties].Name);
                    if (parentLoadProperties + 1 != prop.ParentLoadProperties.Count)
                        response += ", ";
                }
            }
            else
            {
                for (var loadParameter = 0; loadParameter < prop.LoadParameters.Count; loadParameter++)
                {
                    response += FormatFieldForPropertyName(info, prop.LoadParameters[loadParameter].Property.Name);
                    if (loadParameter + 1 != prop.LoadParameters.Count)
                        response += ", ";
                }
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
            var response = string.Empty;

            bool isReadOnly = uowProp.ReadOnly;

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
            else //if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += String.Format("public {0} {1} {{ get; {2}set; }}",
                    uowProp.TypeName,
                    FormatPascal(uowProp.Name),
                    isReadOnly ? "private " : "");
            }

            return response;
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
            if (!targetInfo.ObjectType.IsEditableType())
                isGetter = true;

            return isGetter;
        }

        #endregion

        #region Context Connection Manager

        public string GetConnection(CslaObjectInfo info, bool isFetch)
        {
            var database = "\"" + CurrentUnit.GenerationParams.DatabaseConnection + "\"";
            if (CurrentUnit.GenerationParams.GenerateDatabaseClass)
                database = "Database." + CurrentUnit.GenerationParams.DatabaseConnection + "Connection, false";

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

        public string GetCommand(CslaObjectInfo info, string commandText, bool useInlineQueries, string criteria)
        {
            if (useInlineQueries)
                return "using (var cmd = new SqlCommand(" + commandText +
                       "InlineQuery(" + criteria + "), " + LocalContextConnection(info) + "))";

            return GetCommand(info, commandText);
        }

        public string GetCommand(CslaObjectInfo info, string commandText)
        {
            var sprocTemplateHelper = new SprocTemplateHelper();
            var tables = sprocTemplateHelper.GetTablesSelect(info);
            sprocTemplateHelper.SortTables(tables);

            var plainTableSchema = string.Empty;
            if (info.Parent.GenerationParams.GenerateQueriesWithSchema)
            {
                if (tables.Count > 0)
                    plainTableSchema = tables[0].ObjectSchema;
                else
                {
                    // presume SProc
                    plainTableSchema = sprocTemplateHelper.GetSprocSchemaSelect(info);
                }
            }
            if (!string.IsNullOrEmpty(plainTableSchema))
                plainTableSchema += ".";

            return "using (var cmd = new SqlCommand(\"" + plainTableSchema + commandText + "\", " +
                   LocalContextConnection(info) + "))";
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
            var pkList = (from prop in info.AllValueProperties
                where prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default
                select prop.Name).ToList();
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
            return "null";
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
                    return "public";
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

            var allCslaObjects = CurrentUnit.CslaObjects.GetAllObjectNames();
            PrimaryKeys.BuildCache(allCslaObjects, info);

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
                foreach (var property in trialPK.Info.ChildCollectionProperties)
                {
                    var trialChildCollection = FindChildInfo(trialPK.Info,
                        property.TypeName);
                    var trialChildCollectionItem =
                        trialChildCollection.Parent.CslaObjects.Find(trialChildCollection.ItemType);
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
                        Cache.Add(new ObjectPK {Info = info, Property = prop});
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

            public static void BuildCache(List<string> allCslaObjects, CslaObjectInfo cslaObjectInfo)
            {
                // Use 'Lazy initialization'
                if (_instance == null)
                {
                    _allCslaObjects = allCslaObjects;
                    _cslaObjectInfo = cslaObjectInfo;
                    _instance = new PrimaryKeys();
                }
            }

            public static void ClearCache()
            {
                Cache.Clear();
                _instance = null;
            }
        }

        #endregion

        #endregion

        #region DataPortal Hooks

        public List<string> GetHookList(CslaObjectInfo info)
        {
            var lazyLoad = IsChildLazyLoaded(info);

            var hookList = new List<string>();

            if (HasDataPortalCreate(info) &&
                ((info.ObjectType.IsEditableType() &&
                  info.ObjectType.IsChildType()) ||
                 info.IsEditableRoot() ||
                 info.IsDynamicEditableRoot()))
            {
                hookList.Add("Create");
            }

            if ((HasDataPortalDelete(info) &&
                 ((info.ObjectType.IsEditableType() &&
                   info.ObjectType.IsChildType()) ||
                  info.IsEditableRoot() ||
                  info.IsDynamicEditableRoot()))
                ||
                (info.GenerateDataPortalDelete &&
                 (info.IsEditableRoot() ||
                  info.IsDynamicEditableRoot() ||
                  info.IsEditableChild() ||
                  info.IsEditableSwitchable()))
                )
            {
                hookList.AddRange(new[] {"DeletePre", "DeletePost"});
            }

            if (HasDataPortalGet(info) ||
                (info.IsNotReadOnlyObject() &&
                 info.ParentType != string.Empty &&
                 !lazyLoad))
            {
                hookList.AddRange(new[] {"FetchPre", "FetchPost"});
            }

            if (!info.ObjectType.IsCollectionType() &&
                info.IsNotNameValueList())
            {
                hookList.Add("FetchRead");
            }

            if (info.ObjectType.IsEditableType() &&
                !info.ObjectType.IsCollectionType() &&
                info.GenerateDataPortalUpdate)
            {
                hookList.AddRange(new[] {"UpdatePre", "UpdatePost"});
            }

            if (info.ObjectType.IsEditableType() &&
                !info.ObjectType.IsCollectionType() &&
                info.GenerateDataPortalInsert)
            {
                hookList.AddRange(new[] {"InsertPre", "InsertPost"});
            }

            return hookList;
        }

        public string FormatHookDocumentation(string name)
        {
            var response = string.Empty;

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
                    response +=
                        "in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().";
                    break;
                case "UpdatePre":
                    response += "after setting query parameters and before the update operation.";
                    break;
                case "UpdatePost":
                    response +=
                        "in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().";
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
            return (from crit in info.CriteriaObjects
                where crit.Properties.Count > 1
                select FactoryOrDataPortal(crit)).FirstOrDefault();
        }

        public bool IsCriteriaNestedClassNeeded(CslaObjectInfo info)
        {
            return (from crit in info.CriteriaObjects
                where crit.Properties.Count > 1 && crit.NestedClass
                select FactoryOrDataPortal(crit)).FirstOrDefault();
        }

        public bool IsCriteriaObjectNeeded(CslaObjectInfo info)
        {
            return (from crit in info.CriteriaObjects
                where crit.Properties.Count > 1 && !crit.NestedClass
                select FactoryOrDataPortal(crit)).FirstOrDefault();
        }

        public bool IsCriteriaExtendedClassNeeded(CslaObjectInfo info)
        {
            return (from crit in info.CriteriaObjects
                where crit.Properties.Count > 1 && crit.CriteriaClassMode == CriteriaMode.BusinessBase
                select FactoryOrDataPortal(crit)).FirstOrDefault();
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

        public string SendMultipleCriteria(Criteria crit, string prefix)
        {
            var sb = new StringBuilder();
            var firstParam = true;

            foreach (var prop in crit.Properties)
            {
                if (firstParam)
                    firstParam = false;
                else
                    sb.Append(", ");
                sb.AppendFormat("{0}.{1}", prefix, prop.Name);
            }
            return sb.ToString();
        }

        public string AddRefOrOut(CriteriaProperty prop)
        {
            if (prop.InlineQueryParameter == InlineQueryParameterType.AsRef)
                return "ref ";
            if (prop.InlineQueryParameter == InlineQueryParameterType.AsOut)
                return "out ";
            return "";
        }

        public string ReceiveSingleCriteria(Criteria crit, string paramName)
        {
            return ReceiveSingleCriteria(crit, paramName, false);
        }

        public string ReceiveSingleCriteria(Criteria crit, string paramName, bool usesRefOrOut)
        {
            var sb = new StringBuilder();

            var paramType = GetDataTypeGeneric(crit.Properties[0], crit.Properties[0].PropertyType);
            if (paramType == "Object" || paramType == "Empty" || CurrentUnit.GenerationParams.UseSingleCriteria)
                sb.AppendFormat("SingleCriteria<{0}> {1}", paramType, paramName);
            else
            {
                if (usesRefOrOut)
                    paramType = AddRefOrOut(crit.Properties[0]) + paramType;
                paramName = FormatCamel(crit.Properties[0].Name);
                sb.AppendFormat("{0} {1}", paramType, paramName);
            }

            return sb.ToString();
        }

        public string ReceiveSingleCriteriaTypeless(Criteria crit, string paramName)
        {
            return ReceiveSingleCriteriaTypeless(crit, paramName, false);
        }

        public string ReceiveSingleCriteriaTypeless(Criteria crit, string paramName, bool usesRefOrOut)
        {
            var sb = new StringBuilder();

            var paramType = GetDataTypeGeneric(crit.Properties[0], crit.Properties[0].PropertyType);
            if (paramType == "Object" || paramType == "Empty" || CurrentUnit.GenerationParams.UseSingleCriteria)
                sb.AppendFormat("{0}", paramName);
            else
            {
                paramName = FormatCamel(crit.Properties[0].Name);
                if (usesRefOrOut)
                    paramName = AddRefOrOut(crit.Properties[0]) + paramName;
                sb.AppendFormat("{0}", paramName);
            }

            return sb.ToString();
        }

        public string ReceiveMultipleCriteria(Criteria crit)
        {
            return ReceiveMultipleCriteria(crit, false);
        }

        public string ReceiveMultipleCriteria(Criteria crit, bool usesRefOrOut)
        {
            var sb = new StringBuilder();
            var firstParam = true;

            foreach (var prop in crit.Properties)
            {
                if (firstParam)
                    firstParam = false;
                else
                    sb.Append(", ");
                var paramType = GetDataTypeGeneric(prop, prop.PropertyType);
                if (usesRefOrOut)
                    paramType = AddRefOrOut(prop) + paramType;
                var paramName = FormatCamel(prop.Name);
                sb.AppendFormat("{0} {1}", paramType, paramName);
            }
            return sb.ToString();
        }

        public string ReceiveMultipleCriteriaTypeless(Criteria crit)
        {
            return ReceiveMultipleCriteriaTypeless(crit, false);
        }

        public string ReceiveMultipleCriteriaTypeless(Criteria crit, bool usesRefOrOut)
        {
            var sb = new StringBuilder();
            var firstParam = true;

            foreach (var prop in crit.Properties)
            {
                if (firstParam)
                    firstParam = false;
                else
                    sb.Append(", ");
                var paramName = FormatCamel(prop.Name);
                if (usesRefOrOut)
                    paramName = AddRefOrOut(prop) + paramName;
                sb.AppendFormat("{0}", paramName);
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

        public bool HasAnySilverlightLocalDataPortalCreate()
        {
            if (_hasAnySilverlightLocalDataPortalCreate == null)
            {
                _hasAnySilverlightLocalDataPortalCreate = false;
                foreach (var info in CurrentUnit.CslaObjects)
                {
                    _hasAnySilverlightLocalDataPortalCreate |= HasSilverlightLocalDataPortalCreate(info);
                }
            }

            return _hasAnySilverlightLocalDataPortalCreate.Value;
        }

        public bool HasSilverlightLocalDataPortalCreate(CslaObjectInfo info)
        {
            var result = false;
            if (CurrentUnit.GenerationParams.GenerateSilverlight4 &&
                info.ObjectType.IsObjectType() &&
                !info.ObjectType.IsReadOnlyType())
            {
                foreach (var crit in info.CriteriaObjects)
                {
                    if (crit.CreateOptions.DataPortal && crit.CreateOptions.RunLocal)
                        result = true;
                }
            }

            return result;
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
            return CurrentUnit.GenerationParams.GenerateSilverlight4 ||
                   CurrentUnit.GenerationParams.SilverlightUsingServices;
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

        public string IfNewSilverlight(Conditional step, int indent, ref int silverlightLevel, bool formFeedBefore,
            bool formFeedAfter)
        {
            var result = string.Empty;
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

        public string IfSilverlight(Conditional step, int indent, ref int silverlightLevel, bool formFeedBefore,
            bool formFeedAfter)
        {
            var result = string.Empty;
            var outputValue = silverlightLevel;
            if (UseSilverlight())
            {
                switch (step)
                {
                    case Conditional.Silverlight:
                        result = (formFeedBefore ? Environment.NewLine : "") + "#if SILVERLIGHT" +
                                 (formFeedAfter ? Environment.NewLine : "") + new string(' ', indent*4);
                        outputValue = silverlightLevel + 1;
                        break;
                    case Conditional.NotSilverlight:
                        result = (formFeedBefore ? Environment.NewLine : "") + "#if !SILVERLIGHT" +
                                 (formFeedAfter ? Environment.NewLine : "") + new string(' ', indent*4);
                        outputValue = silverlightLevel + 1;
                        break;
                    case Conditional.Else:
                        result = (formFeedBefore ? Environment.NewLine : "") + "#else" +
                                 (formFeedAfter ? Environment.NewLine : "") + new string(' ', indent*4);
                        outputValue = silverlightLevel;
                        break;
                    case Conditional.End:
                        result = (formFeedBefore ? Environment.NewLine : "") + "#endif" +
                                 (formFeedAfter ? Environment.NewLine : "");
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
                result = "[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]" +
                         Environment.NewLine +
                         new string(' ', indent*4) +
                         "public";
            }
            return result;
        }

        #endregion

        #region Class Declaration (inheritance and interfaces)

        public static string GetClassDeclaration(CslaObjectInfo info)
        {
            return GetClassDeclarationCore(info, null, false);
        }

        public static string GetClassDeclaration(CslaObjectInfo info, bool isBindingList)
        {
            return GetClassDeclarationCore(info, null, isBindingList);
        }

        public static string GetClassDeclarationInheritedType(CslaObjectInfo info)
        {
            return GetClassDeclarationCore(info, info.InheritedType, false);
        }

        public static string GetClassDeclarationInheritedTypeWinForms(CslaObjectInfo info)
        {
            return GetClassDeclarationCore(info, info.InheritedTypeWinForms, true);
        }

        private static string GetClassDeclarationCore(CslaObjectInfo info, TypeInfo inheritedType, bool isBindingList)
        {
            var result = GetInitialClassDeclaration(info);

            var paramsNumber = info.NumberOfGenericArguments();

            if (inheritedType != null && inheritedType.FinalName != string.Empty)
            {
                var finalName = inheritedType.FinalName;
                var firstParameter = inheritedType.FirstParameter;

                if (paramsNumber == 1)
                {
                    var search = string.Format("<{0}>", firstParameter);
                    if (finalName.Contains(search))
                        finalName = finalName.Replace(search,
                            string.Format("<{0}>",
                                info.IsDynamicEditableRootCollection()
                                    ? info.ItemType
                                    : info.ObjectName));

                }
                else
                {
                    var secondParameter = inheritedType.SecondParameter;

                    var search = string.Format("<{0},{1}>", firstParameter, secondParameter);
                    if (finalName.Contains(search))
                        if (info.IsNameValueList())
                        {
                            finalName = GetNameValueListClassDeclaration(info, finalName, search);
                        }
                        else
                        {
                            finalName = finalName.Replace(search,
                                string.Format("<{0}, {1}>", info.ObjectName, info.ItemType));
                        }
                }
                result += finalName;
            }
            else
            {
                if (paramsNumber == 1)
                {
                    result += string.Format("{0}<{1}>",
                        info.CslaBaseClass(isBindingList),
                        info.IsDynamicEditableRootCollection()
                            ? info.ItemType
                            : info.ObjectName);

                }
                else
                {
                    if (info.IsNameValueList())
                    {
                        result += GetNameValueListClassDeclaration(info);
                    }
                    else
                    {
                        result += string.Format("{0}<{1}, {2}>",
                            info.CslaBaseClass(isBindingList),
                            info.ObjectName,
                            info.ItemType);
                    }
                }
            }

            return result;
        }

        private static string GetInitialClassDeclaration(CslaObjectInfo info)
        {
            return string.Format("{0} partial class {1} : ",
                info.ClassVisibility == ClassVisibility.Public ? "public" : "internal",
                info.ObjectName);
        }

        private static string GetNameValueListClassDeclaration(CslaObjectInfo info)
        {
            var result = string.Empty;

            ValueProperty valueProperty = null;
            ValueProperty nameProperty = null;
            foreach (var property in info.ValueProperties)
            {
                if (property.Name.Equals(info.NameColumn))
                {
                    nameProperty = property;
                    continue;
                }
                if (property.Name.Equals(info.ValueColumn))
                {
                    valueProperty = property;
                }
            }
            if (nameProperty != null && valueProperty != null)
            {
                var valueParameter = GetDataTypeGeneric(valueProperty, valueProperty.PropertyType);
                var nameParameter = GetDataTypeGeneric(nameProperty, nameProperty.PropertyType);

                result = string.Format("{0}<{1}, {2}>",
                    info.CslaBaseClass(),
                    valueParameter,
                    nameParameter);
            }

            return result;
        }

        private static string GetNameValueListClassDeclaration(CslaObjectInfo info, string finalName, string search)
        {
            ValueProperty valueProperty = null;
            ValueProperty nameProperty = null;
            foreach (var property in info.ValueProperties)
            {
                if (property.Name.Equals(info.NameColumn))
                {
                    nameProperty = property;
                    continue;
                }
                if (property.Name.Equals(info.ValueColumn))
                {
                    valueProperty = property;
                }
            }
            if (nameProperty != null && valueProperty != null)
            {
                var valueParameter = GetDataTypeGeneric(valueProperty, valueProperty.PropertyType);
                var nameParameter = GetDataTypeGeneric(nameProperty, nameProperty.PropertyType);

                finalName = finalName.Replace(search,
                    string.Format("<{0}, {1}>", valueParameter, nameParameter));
            }

            return finalName;
        }

        public static string GetInterfaceDeclaration(CslaObjectInfo info)
        {
            var result = string.Empty;

            if (info.Interfaces.Length > 0)
            {
                foreach (var item in info.Interfaces)
                {
                    if (!item.Contains(','))
                        result += ", ";
                    if (item.Contains("<T>"))
                        result += item.Replace("<T>", "<" + info.ObjectName + ">");
                    else
                        result += item;
                }
            }

            return result;
        }

        #endregion
    }
}