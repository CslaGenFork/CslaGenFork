using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CodeSmith.Engine;
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
                return string.Empty;

            return "[" + string.Join(", ", attributes) + "]";
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
            if (typeCode == TypeCodeEx.Int16 || typeCode == TypeCodeEx.Int32 || typeCode == TypeCodeEx.Int64 || typeCode == TypeCodeEx.Double
                || typeCode == TypeCodeEx.Decimal || typeCode == TypeCodeEx.Single) { return "0"; }
            else if (typeCode == TypeCodeEx.String) { return "String.Empty"; }
            else if (typeCode == TypeCodeEx.Boolean) { return "false"; }
            else if (typeCode == TypeCodeEx.Byte) { return "0"; }
            else if (typeCode == TypeCodeEx.Object) { return "null"; }
            else if (typeCode == TypeCodeEx.Guid) { return "Guid.Empty"; }
            else if (typeCode == TypeCodeEx.SmartDate) { return "new SmartDate(true)"; }
            else if (typeCode == TypeCodeEx.DateTime) { return "DateTime.Now"; }
            else if (typeCode == TypeCodeEx.Char) { return "Char.MinValue"; }
            else if (typeCode == TypeCodeEx.ByteArray) { return "new Byte[] {}"; }
            else { return String.Empty; }
        }

        public virtual string GetInitValue(ValueProperty prop)
        {
            if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetReaderAssignmentStatement(ValueProperty prop)
        {
            return GetReaderAssignmentStatement(prop, false);
        }

        public virtual string GetReaderAssignmentStatement(ValueProperty prop, bool structure)
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                    prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                    prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                return GetDataLoaderStatement(prop);

            string statement;
            if (structure)
                statement = "nfo." + prop.Name + " = ";
            else
                statement = FormatFieldName(prop.Name) + " = ";

            statement += GetDataReaderStatement(prop);

            return statement;
        }

        public virtual string GetDataReaderStatement(ValueProperty prop)
        {
            bool nullable = AllowNull(prop);
            string statement = string.Empty;

            if (nullable)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    statement += string.Format("!dr.IsDBNull(\"{0}\") ? new {1}(({2}) ",
                        prop.ParameterName,
                        GetDataType(prop),
                        GetDataType(prop.PropertyType));
                else
                    statement += string.Format("!dr.IsDBNull(\"{0}\") ? ({1}) ",
                        prop.ParameterName,
                        GetDataType(prop));
            }
            statement += "dr.";

            if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
                statement += GetReaderMethod(prop.PropertyType);
            else
            {
                //statement += GetReaderMethod(GetDbType(prop.DbBindColumn), prop.PropertyType);
                statement += GetReaderMethod(GetDbType(prop.DbBindColumn), prop);
            }

            statement += "(\"" + prop.ParameterName + "\"";

            if (prop.PropertyType == TypeCodeEx.SmartDate)
                statement += ", true";

            statement += ")";
            if (nullable)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    statement += ")";
                statement += " : null";
            }
            if (prop.PropertyType == TypeCodeEx.ByteArray)
                statement = "(" + statement + ") as Byte[]";
            return statement;
        }

        public bool AllowNull(Property prop)
        {
            return (GeneratorController.Current.CurrentUnit.GenerationParams.NullableSupport && prop.Nullable && prop.PropertyType != TypeCodeEx.SmartDate);
        }

        public virtual string GetParameterSet(Property prop, bool criteria)
        {
            return GetParameterSet(prop, criteria, false);
        }

        public virtual string GetParameterSet(Property prop, bool criteria, bool singleCriteria)
        {
            bool nullable = AllowNull(prop);
            string propName;
            if (singleCriteria)
                propName = "crit.Value";
            else if (criteria)
                propName = "crit." + FormatPascal(prop.Name);
            else
                propName = FormatFieldName(prop.Name);

            //propName = (criteria) ? "crit." + FormatPascal(prop.Name) : FormatFieldName(prop.Name);

            if (nullable && prop.PropertyType != TypeCodeEx.SmartDate)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    return string.Format("{0} == null ? (object) DBNull.Value : {0}.Value", propName);

                return string.Format("{0} == null ? (object) DBNull.Value : {0}", propName);
            }
            switch (prop.PropertyType)
            {
                case TypeCodeEx.SmartDate:
                    return propName + ".DBValue";
                case TypeCodeEx.Guid:
                    return propName + ".Equals(Guid.Empty) ? (object) DBNull.Value : " + propName;
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

        public virtual string GetDataType(Property prop)
        {
            string type = GetDataType(prop.PropertyType);
            if (AllowNull(prop))
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    type += "?";
            }
            return type;
        }

        public virtual string GetDataType(TypeCodeEx type)
        {
            if (type == TypeCodeEx.ByteArray)
                return "Byte[]";

            if (type == TypeCodeEx.String)
                return "string";

            if (type == TypeCodeEx.Int32)
                return "int";

            if (type == TypeCodeEx.Boolean)
                return "bool";

            return type.ToString();
        }

        protected internal string GetReaderMethod(DbType dataType, Property prop)
        {
            if (prop.Nullable && (TypeHelper.IsNullableType(prop.PropertyType) ||
                prop.PropertyType == TypeCodeEx.String))
                return "GetValue";

            return GetReaderMethod(dataType, prop.PropertyType);
        }

        protected internal string GetReaderMethod(DbType dataType, TypeCodeEx propertyType)
        {
            switch (dataType)
            {
                case DbType.Byte: return "GetByte";
                case DbType.Int16: return "GetInt16";
                case DbType.Int32: return "GetInt32";
                case DbType.Int64: return "GetInt64";
                case DbType.AnsiStringFixedLength: return "GetChar";
                case DbType.AnsiString: return "GetString";
                case DbType.String: return "GetString";
                case DbType.StringFixedLength: return "GetString";
                case DbType.Boolean: return "GetBoolean";
                case DbType.Guid: return "GetGuid";
                case DbType.Currency: return "GetDecimal";
                case DbType.Decimal: return "GetDecimal";
                case DbType.DateTime:
                case DbType.Date: return (propertyType == TypeCodeEx.SmartDate) ? "GetSmartDate" : "GetDateTime";
                case DbType.Binary: return "GetValue";
                case DbType.Single: return "GetFloat";
                case DbType.Double: return "GetDouble";
                default: return "GetValue";
            }
        }

        public string GetReaderMethod(TypeCodeEx dataType)
        {
            switch (dataType)
            {
                case TypeCodeEx.Byte: return "GetByte";
                case TypeCodeEx.Int16: return "GetInt16";
                case TypeCodeEx.Int32: return "GetInt32";
                case TypeCodeEx.Int64: return "GetInt64";
                case TypeCodeEx.String: return "GetString";
                case TypeCodeEx.Boolean: return "GetBoolean";
                case TypeCodeEx.Guid: return "GetGuid";
                case TypeCodeEx.Decimal: return "GetDecimal";
                case TypeCodeEx.SmartDate: return "GetSmartDate";
                case TypeCodeEx.DateTime: return "GetDateTime";
                case TypeCodeEx.ByteArray: return "GetValue";
                case TypeCodeEx.Single: return "GetFloat";
                case TypeCodeEx.Double: return "GetDouble";
                case TypeCodeEx.Char: return "GetChar";
                default: return "GetValue";
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
                case DbType.AnsiString: return "string";
                case DbType.AnsiStringFixedLength: return "string";
                case DbType.Binary: return "byte[]";
                case DbType.Boolean: return "bool";
                case DbType.Byte: return "byte";
                case DbType.Currency: return "decimal";
                case DbType.Date:
                case DbType.DateTime: return "DateTime";
                case DbType.Decimal: return "decimal";
                case DbType.Double: return "double";
                case DbType.Guid: return "Guid";
                case DbType.Int16: return "short";
                case DbType.Int32: return "int";
                case DbType.Int64: return "long";
                case DbType.Object: return "object";
                case DbType.SByte: return "sbyte";
                case DbType.Single: return "float";
                case DbType.String: return "string";
                case DbType.StringFixedLength: return "string";
                case DbType.Time: return "TimeSpan";
                case DbType.UInt16: return "ushort";
                case DbType.UInt32: return "uint";
                case DbType.UInt64: return "ulong";
                case DbType.VarNumeric: return "decimal";
                default: return "__UNKNOWN__" + dataType;
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
                    var grandchildInfo = FindChildInfo(info, child.Name);
                    if (grandchildInfo != null)
                        sb.Append(GetRelationStrings(grandchildInfo));
                }

            foreach (var child in info.InheritedChildProperties)
                if (!child.LazyLoad)
                {
                    sb.Append(GetRelationString(info, child));
                    sb.Append(Environment.NewLine);
                    var grandchildInfo = FindChildInfo(info, child.Name);
                    if (grandchildInfo != null)
                        sb.Append(GetRelationStrings(grandchildInfo));
                }

            foreach (var child in info.ChildCollectionProperties)
                if (!child.LazyLoad)
                {
                    sb.Append(GetRelationString(info, child));
                    sb.Append(Environment.NewLine);
                    var grandchildInfo = FindChildInfo(info, child.Name);
                    if (grandchildInfo != null)
                        sb.Append(GetRelationStrings(grandchildInfo));
                }

            foreach (var child in info.InheritedChildCollectionProperties)
                if (!child.LazyLoad)
                {
                    sb.Append(GetRelationString(info, child));
                    sb.Append(Environment.NewLine);
                    var grandchildInfo = FindChildInfo(info, child.Name);
                    if (grandchildInfo != null)
                        sb.Append(GetRelationStrings(grandchildInfo));
                }

            return sb.ToString();
        }

        public virtual string GetRelationString(CslaObjectInfo info, ChildProperty child)
        {
            var indent = new string(' ', IndentLevel * 4);

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
            var indent = new string(' ', IndentLevel * 4);

            // add leading indent and comment sign
            xmlComment = indent + "/// " + xmlComment;

            return Regex.Replace(xmlComment, Environment.NewLine, Environment.NewLine + indent + "/// ", RegexOptions.Multiline);
        }

        public virtual string GetUsingStatementsString(CslaObjectInfo info)
        {
            var usingNamespaces = GetNamespaces(info);

            var result = String.Empty;
            var silverlightLevel = 0;
            foreach (var namespaceName in usingNamespaces)
            {
                if (namespaceName == CurrentUnit.GenerationParams.UtilitiesNamespace &&
                    UseSilverlight())
                {
                    result += IfSilverlight(Conditional.NotSilverlight, 0, ref silverlightLevel, false, true);
                    result += "using " + namespaceName + ";";
                    result += IfSilverlight(Conditional.End, 0, ref silverlightLevel, true, true);

                }
                else if (namespaceName == "Csla.Serialization")
                {
                    result += IfSilverlight(Conditional.Silverlight, 0, ref silverlightLevel, false, true);
                    result += "using " + namespaceName + ";";
                    result += IfSilverlight(Conditional.End, 0, ref silverlightLevel, true, true);

                }
                else
                    result += "using " + namespaceName + ";" + Environment.NewLine;
            }

            foreach (var p in info.GetAllValueProperties())
            {
                if (p.PropertyType == TypeCodeEx.ByteArray && AllowNull(p))
                    result += "using System.Linq; //Added for byte[] helpers" + Environment.NewLine;

            }

            return (result);
        }

        protected string[] GetNamespaces(CslaObjectInfo info)
        {
            var usingList = new List<string>();

            if ((CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
                CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel))
            {
                CslaObjectInfo authzInfo = info;
                if (IsCollectionType(info.ObjectType))
                {
                    authzInfo = FindChildInfo(info, info.ItemType);
                }

                if (authzInfo != null &&
                    ((authzInfo.NewRoles.Trim() != String.Empty) ||
                     (authzInfo.GetRoles.Trim() != String.Empty) ||
                     (authzInfo.UpdateRoles.Trim() != String.Empty) ||
                     (authzInfo.DeleteRoles.Trim() != String.Empty)))
                {
                    usingList.Add("Csla.Rules");
                    usingList.Add("Csla.Rules.CommonRules");
                }
            }

            if (info.ObjectNamespace.IndexOf(CurrentUnit.GenerationParams.UtilitiesNamespace) != 0 &&
                info.ObjectType != CslaObjectType.UnitOfWork)
                usingList.Add(CurrentUnit.GenerationParams.UtilitiesNamespace);

            if (UseSilverlight())
                usingList.Add("Csla.Serialization");

            foreach (var name in info.Namespaces)
                if (!usingList.Contains(name))
                    usingList.Add(name);

            foreach (var prop in info.ChildProperties)
                if (prop.TypeName != info.ObjectName)
                {
                    var childInfo = FindChildInfo(info, prop.TypeName);
                    if (childInfo != null)
                        if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace)
                            usingList.Add(childInfo.ObjectNamespace);
                }

            foreach (var prop in info.InheritedChildProperties)
                if (prop.TypeName != info.ObjectName)
                {
                    var childInfo = FindChildInfo(info, prop.TypeName);
                    if (childInfo != null)
                        if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace)
                            usingList.Add(childInfo.ObjectNamespace);
                }

            foreach (var prop in info.ChildCollectionProperties)
                if (prop.TypeName != info.ObjectName)
                {
                    var childInfo = FindChildInfo(info, prop.TypeName);
                    if (childInfo != null)
                        if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace)
                            usingList.Add(childInfo.ObjectNamespace);
                }

            foreach (var prop in info.InheritedChildCollectionProperties)
                if (prop.TypeName != info.ObjectName)
                {
                    var childInfo = FindChildInfo(info, prop.TypeName);
                    if (childInfo != null)
                        if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace)
                            usingList.Add(childInfo.ObjectNamespace);
                }

            if (info.ItemType != String.Empty)
            {
                var childInfo = FindChildInfo(info, info.ItemType);
                if (childInfo != null)
                    if (!usingList.Contains(childInfo.ObjectNamespace) && childInfo.ObjectNamespace != info.ObjectNamespace)
                        usingList.Add(childInfo.ObjectNamespace);
            }

            if (info.ParentType != String.Empty)
            {
                var parentInfo = FindChildInfo(info, info.ParentType);
                if (parentInfo != null)
                    if (!usingList.Contains(parentInfo.ObjectNamespace) && parentInfo.ObjectNamespace != info.ObjectNamespace)
                        usingList.Add(parentInfo.ObjectNamespace);
            }

            //string[] usingNamespaces = new string[usingList.Count];
            //usingList.CopyTo(0, usingNamespaces, 0, usingList.Count);
            //Array.Sort(usingNamespaces, new CaseInsensitiveComparer());
            if (usingList.Contains(string.Empty))
                usingList.Remove(string.Empty);
            usingList.Sort(string.Compare);

            return usingList.ToArray();
        }

        #endregion

        #region Query Object Metadata

        public bool LoadsChildren(CslaObjectInfo info)
        {
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            foreach (var child in info.ChildProperties)
                if (child.LoadingScheme == LoadingScheme.ParentLoad) { return true; }

            foreach (var child in info.ChildCollectionProperties)
                if (child.LoadingScheme == LoadingScheme.ParentLoad) { return true; }

            foreach (var child in info.InheritedChildProperties)
                if (child.LoadingScheme == LoadingScheme.ParentLoad) { return true; }

            foreach (var child in info.InheritedChildCollectionProperties)
                if (child.LoadingScheme == LoadingScheme.ParentLoad) { return true; }

            return false;
        }

        public bool SelfLoadsChildren(CslaObjectInfo info)
        {
            if (IsCollectionType(info.ObjectType))
                info = FindChildInfo(info, info.ItemType);

            foreach (var child in info.ChildProperties)
                if (!child.LazyLoad && child.LoadingScheme != LoadingScheme.ParentLoad) { return true; }

            foreach (var child in info.ChildCollectionProperties)
                if (!child.LazyLoad && child.LoadingScheme != LoadingScheme.ParentLoad) { return true; }

            foreach (var child in info.InheritedChildProperties)
                if (!child.LazyLoad && child.LoadingScheme != LoadingScheme.ParentLoad) { return true; }

            foreach (var child in info.InheritedChildCollectionProperties)
                if (!child.LazyLoad && child.LoadingScheme != LoadingScheme.ParentLoad) { return true; }

            return false;
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

        public static bool IsRootType(CslaObjectType cslaType)
        {
            if (cslaType == CslaObjectType.EditableRoot ||
                cslaType == CslaObjectType.EditableRootCollection ||
                cslaType == CslaObjectType.DynamicEditableRoot ||
                cslaType == CslaObjectType.DynamicEditableRootCollection ||
                cslaType == CslaObjectType.EditableSwitchable)
                return true;

            return false;
        }

        public static bool IsNotRootType(CslaObjectInfo info)
        {
            if (info.ObjectType == CslaObjectType.EditableChild ||
                (info.ObjectType == CslaObjectType.ReadOnlyObject &&
                info.ParentType != string.Empty))
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

        public static bool HasParentProperties(CslaObjectInfo info)
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
                    (parent.ObjectType == CslaObjectType.ReadOnlyCollection && parent.ParentType == string.Empty))
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

            return string.Empty;
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

            return string.Empty;
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
        /// <returns></returns>
        public CslaObjectInfo FindChildInfo(CslaObjectInfo info, string name)
        {
            return info.Parent.CslaObjects.Find(name);
        }

        public CslaObjectInfo[] GetChildItems(CslaObjectInfo info)
        {
            var list = new List<CslaObjectInfo>();
            foreach (var cp in info.GetAllChildProperties())
            {
                var ci = FindChildInfo(info, cp.TypeName);
                if (ci != null)
                {
                    if (IsCollectionType(ci.ObjectType))
                    {
                        ci = FindChildInfo(info, ci.ItemType);
                    }
                    if (ci != null)
                        list.Add(ci);
                }
            }
            return list.ToArray();
        }

        public string[] GetAllChildItemsInHierarchy(CslaObjectInfo info)
        {
            var list = new List<String>();
            foreach (var obj in GetChildItems(info))
            {
                list.Add(obj.ObjectName);
                list.AddRange(GetAllChildItemsInHierarchy(obj));
            }
            return list.ToArray();
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
            if (!string.IsNullOrEmpty(prop.DbBindColumn.NativeType))
                nativeType = ParseNativeType(prop.DbBindColumn.NativeType);
            if (string.IsNullOrEmpty(nativeType))
            {
                CslaGenerator.Controls.OutputWindow.Current.AddOutputInfo(string.Format("{0}: Unable to parse database native type from DbBindColumn, infering type from property type.", prop.PropertyType));
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

        public virtual string GetParameterSet(CslaObjectInfo info, Property prop, bool criteria, bool param)
        {
            bool nullable = AllowNull(prop);
            string propName;
            //propName = (criteria) ? "crit." + FormatPascal(prop.Name) : FormatFieldForPropertyType(info, prop);
            if (criteria)
            {
                propName = "crit." + FormatPascal(prop.Name);
            }
            else if (param)
            {
                propName = FormatCamel(prop.Name);
            }
            else
            {
                propName = FormatFieldForPropertyType(info, prop);
            }

            if (nullable && prop.PropertyType != TypeCodeEx.SmartDate)
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    return string.Format("{0} == null ? (object) DBNull.Value : {0}.Value", propName);

                return string.Format("{0} == null ? (object) DBNull.Value : {0}", propName);
            }
            switch (prop.PropertyType)
            {
                case TypeCodeEx.SmartDate:
                    return propName + ".DBValue";
                case TypeCodeEx.Guid:
                    return propName + ".Equals(Guid.Empty) ? (object) DBNull.Value : " + propName;
                default:
                    return propName;
            }
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
        /// <param name="criteria">if set to <c>true</c> [criteria].</param>
        /// <returns></returns>
        public virtual string GetParameterSet(CslaObjectInfo info, Property prop, bool criteria)
        {
            return GetParameterSet(info, prop, criteria, false);
        }

        #endregion

        #region Basic Formats

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

        #region State Field parts

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

        public string ListBaseHelper(string rootStereotype, bool isFirstPass)
        {
            var response = string.Empty;

            if (isFirstPass)
            {
                if (CurrentUnit.GenerationParams.GenerateWinForms)
                    response += rootStereotype + "BindingListBase";
                else
                    response += rootStereotype + "ListBase";
            }
            else
            {
                if (CurrentUnit.GenerationParams.GenerateWinForms &&
                    (CurrentUnit.GenerationParams.GenerateWPF ||
                     UseSilverlight()))
                    response += rootStereotype + "ListBase";
            }

            return response;
        }

        // TODO: On ReadOnly objects, forbid Managed and Unmanaged with TypeConversion

        public virtual string GetInitValue(CslaObjectInfo info, ValueProperty prop, TypeCodeEx typeCode)
        {
            if (!HasCreateCriteriaDataPortal(info))
            {
                if (prop.DefaultValue != string.Empty)
                    return prop.DefaultValue;
            }

            if (AllowNull(prop) && typeCode != TypeCodeEx.SmartDate)
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
            var response = string.Empty;
            if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.NoProperty)
            {
                response = CheckNotUndoable(prop);
                response += string.Format("private {0} {1} = {2};",
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
            var response =
                string.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => p.{3}, \"{4}\"{5}{6});",
                    (isSilverlight || CurrentUnit.GenerationParams.UsePublicPropertyInfo) ? "public" : "private",
                    (prop.DeclarationMode == PropertyDeclaration.Managed ||
                     prop.DeclarationMode == PropertyDeclaration.Unmanaged)
                        ? GetDataTypeGeneric(prop, prop.PropertyType)
                        : GetDataTypeGeneric(prop, prop.BackingFieldType),
                    FormatPropertyInfoName(prop.Name),
                    prop.Name,
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

            if (!prop.Nullable || prop.PropertyType != TypeCodeEx.String)
                return string.Empty;

            return ", null";
        }

        private static bool HasCreateCriteriaDataPortal(CslaObjectInfo info)
        {
            foreach (var crit in info.CriteriaObjects)
            {
                if (crit.CreateOptions.DataPortal)
                    return true;
            }

            return false;
        }

        private string GetRelationhipType(CslaObjectInfo info, ValueProperty prop)
        {
            if (IsReadOnlyType(info.ObjectType))
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
            var response =
                string.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => p.{3}, \"{4}\"{5});",
                    (isSilverlight || CurrentUnit.GenerationParams.UsePublicPropertyInfo) ? "public" : "private",
                    prop.TypeName,
                    FormatPropertyInfoName(prop.Name),
                    prop.Name,
                    prop.FriendlyName,
                    GetRelationhipType(info, prop));

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
                string.Format(
                    "{0} static readonly PropertyInfo<{1}> {2} = RegisterProperty<{1}>(p => p.{3});",
                    (isSilverlight || CurrentUnit.GenerationParams.UsePublicPropertyInfo) ? "public" : "private",
                    prop.TypeName,
                    FormatPropertyInfoName(prop.Name),
                    prop.Name);

            return response;
        }

        private string GetRelationhipType(CslaObjectInfo info, ChildProperty prop)
        {
            if (IsReadOnlyType(info.ObjectType))
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
            var isReadOnly = false;

            if (info.ObjectType == CslaObjectType.ReadOnlyObject)
            {
                if (prop.DeclarationMode == PropertyDeclaration.AutoProperty ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                    prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
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

            if (prop.ReadOnly)
            {
                isReadOnly = true;
            }

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response = string.Format("{0} {1} {2}" + Environment.NewLine,
                                         GetPropertyAccess(prop),
                                         GetDataTypeGeneric(prop, prop.PropertyType),
                                         prop.Name);
                response += "        {" + Environment.NewLine;
                response += PropertyDeclareGetter(prop);

                response += PropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                     prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += string.Format("{0} {1} {2}" + Environment.NewLine,
                                          GetPropertyAccess(prop),
                                          GetDataTypeGeneric(prop, prop.PropertyType),
                                          FormatPascal(prop.Name));
                response += "        {" + Environment.NewLine;
                response += PropertyDeclareGetter(prop);

                response += PropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += string.Format("{0} {1} {2} {{ get; {3}set; }}",
                                          GetPropertyAccess(prop),
                                          GetDataTypeGeneric(prop, prop.PropertyType),
                                          FormatPascal(prop.Name),
                                          PropertyDeclareSetter(isReadOnly, prop));
            }

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
                response += string.Format("            get {{ return {0}{1}({2}); }}{3}",
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
                response += string.Format("            get {{ return {0}; }}{1}",
                    FormatFieldName(prop.Name),
                    Environment.NewLine);
            }

            return response;
        }

        private string PropertyDeclareSetter(bool isReadOnly, ValueProperty prop)
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

            var response = string.Empty;
            var isConversion = (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                                prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion);

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response += string.Format("            {0}set {{ {1}{2}({3}, value); }}{4}",
                                          PropertyDeclareSetterVisibility(isReadOnly, prop),
                                          PropertyDeclareSetterMethod(isReadOnly, isConversion),
                                          isConversion
                                              ? "<" + prop.BackingFieldType + ", " + prop.PropertyType + ">"
                                              : "",
                                          (!isReadOnly && (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                                                           prop.DeclarationMode ==
                                                           PropertyDeclaration.UnmanagedWithTypeConversion))
                                              ? FormatPropertyInfoName(prop.Name) + ", ref " +
                                                FormatFieldName(prop.Name)
                                              : FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                     prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
            {
                response += string.Format("            {0}set {{ {1} = value; }}{2}",
                                          PropertyDeclareSetterVisibility(isReadOnly, prop),
                                          FormatFieldName(prop.Name) + ConvertTextToSmartDate(prop),
                                          Environment.NewLine);
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

        private static string PropertyDeclareSetterMethod(bool isReadOnly, bool isConversion)
        {
            if (isConversion)
                if (isReadOnly)
                    return "LoadPropertyConvert";
                else
                    return "SetPropertyConvert";

            if (isReadOnly)
                return "LoadProperty";

            return "SetProperty";
        }

        public string CheckNotUndoable(ValueProperty prop)
        {
            var response = string.Empty;
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

        public virtual string GetDataLoaderStatement(ValueProperty prop)
        {
            var statement = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                statement += String.Format("{0} = {1} dr.{2}(\"{3}\"{4})",
                                           FormatProperty(prop.Name),
                                           "(" + prop.PropertyType + ")",
                    //GetReaderMethod(GetDbType(prop.DbBindColumn), prop.PropertyType),
                                           GetReaderMethod(GetDbType(prop.DbBindColumn), prop),
                                           prop.ParameterName,
                                           (prop.PropertyType == TypeCodeEx.SmartDate)
                                               ? ", true"
                                               : "");
            }
            else
            {
                statement += String.Format("LoadProperty({0}, dr.{1}(\"{2}\"{3}))",
                                           FormatPropertyInfoName(prop.Name),
                    //GetReaderMethod(GetDbType(prop.DbBindColumn), prop.PropertyType),
                                           GetReaderMethod(GetDbType(prop.DbBindColumn), prop),
                                           prop.ParameterName,
                                           (prop.PropertyType == TypeCodeEx.SmartDate)
                                               ? ", true"
                                               : "");
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

        #region Child handling

        public static bool GetSelfLoad(CslaObjectInfo info)
        {
            var selfLoad = false;
            var parent = info.Parent.CslaObjects.Find(info.ParentType);
            if (parent != null)
            {
                foreach (var childProp in parent.ChildCollectionProperties)
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

        public static bool GetLoadNone(CslaObjectInfo info)
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

        public static bool GetLazyLoad(CslaObjectInfo info)
        {
            var lazyLoad = info.LazyLoad;
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

            if (isDataPortalCreate && prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                return "";

            if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);

            if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                return String.Format("{0} = {1}", FormatProperty(prop.Name), value);

            value = string.Format("DataPortal.CreateChild<{0}>()", prop.TypeName);
            return GetFieldLoaderStatement(prop, value);
        }

        public virtual string GetExistingChildLoadStatement(ChildProperty prop)
        {
            var value = prop.TypeName + ".Get" + prop.TypeName + "()";

            if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
                return String.Format("{0} = {1}", FormatFieldName(prop.Name), value);

            if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
                return String.Format("{0} = {1}", FormatProperty(prop.Name), value);

            value = string.Format("DataPortal.FetchChild<{0}>()", prop.TypeName);
            return GetFieldLoaderStatement(prop, value);
        }

        public string ChildPropertyDeclare(CslaObjectInfo info, ChildProperty prop)
        {
            var response = string.Empty;

            var isReadOnly = false;

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

            if (prop.ReadOnly)
            {
                isReadOnly = true;
            }

            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                response += string.Format("{0} {1} {2}" + Environment.NewLine,
                                          GetPropertyAccess(prop),
                                          prop.TypeName,
                                          prop.Name);
                response += "        {" + Environment.NewLine;
                response += ChildPropertyDeclareGetter(info, prop);

                response += ChildPropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += string.Format("{0} {1} {2}" + Environment.NewLine,
                                          GetPropertyAccess(prop),
                                          prop.TypeName,
                                          FormatPascal(prop.Name));
                response += "        {" + Environment.NewLine;
                response += ChildPropertyDeclareGetter(info, prop);

                response += ChildPropertyDeclareSetter(isReadOnly, prop);
                response += "        }";
            }
            else  //if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += string.Format("{0} {1} {2} {{ get; {3}set; }}",
                          GetPropertyAccess(prop),
                          prop.TypeName,
                          FormatPascal(prop.Name),
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
                response = string.Format("            get {{ return GetProperty({0}); }}" + Environment.NewLine,
                                          FormatPropertyInfoName(prop.Name));
            }
            else //if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response = string.Format("            get {{ return {0}; }}" + Environment.NewLine,
                                          FormatFieldName(prop.Name));
            }

            return response;
        }

        private string ChildPropertyDeclareGetterLazyLoad(CslaObjectInfo info, ChildProperty prop)
        {
            var isReadOnly = false;

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

            if (prop.ReadOnly)
            {
                isReadOnly = true;
            }

            var response = string.Empty;

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += "            get" + Environment.NewLine;
                response += "            {" + Environment.NewLine;
                response += ChildPropertyDeclareGetLazyLoad(info, prop);
                response += "            }" + Environment.NewLine;
                response += string.Format("            {0}set{1}",
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
                response += string.Format("            {0}set {{ {1}({2}, value); }}{3}",
                                          ChildPropertyDeclareSetterVisibility(isReadOnly, prop),
                                          ChildPropertyDeclareSetterMethod(isReadOnly),
                                          FormatPropertyInfoName(prop.Name),
                                          Environment.NewLine);
            }
            else //if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += string.Format("            {0}set {{ {1} = value; }}{2}",
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
            var response = string.Empty;
            if (!prop.Undoable)
                response = "[NotUndoable]" + Environment.NewLine + "        ";

            return response;
        }

        private string ChildPropertyDeclareSetLazyLoad(ChildProperty prop)
        {
            var response = string.Empty;
            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
            {
                response += string.Format("                LoadProperty({0}, value);{1}", FormatPropertyInfoName(prop.Name), Environment.NewLine);
                response += string.Format("                OnPropertyChanged({0});{1}", FormatPropertyInfoName(prop.Name), Environment.NewLine);
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response += string.Format("                {0} = value;{1}", FormatFieldName(prop.Name), Environment.NewLine);
                response += string.Format("                OnPropertyChanged(\"{0}\");{1}", FormatPascal(prop.Name), Environment.NewLine);
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
            var response = string.Empty;

            if (UseSilverlight() &&
                (CurrentUnit.GenerationParams.GenerateSynchronous ||
                !CurrentUnit.GenerationParams.GenerateAsynchronous))
            {
                /* Editable Silverlight using services

                if (!FieldManager.FieldExists(ChildrenProperty))
                {
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
                            }, DataPortal.ProxyModes.LocalOnly);
                        return null;
                    }
                }
                else
                {
                    return GetProperty(ChildrenProperty);
                }*/

                response += (UseNoSilverlight() ? "#if SILVERLIGHT" + Environment.NewLine : "");
                response += string.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                {" + Environment.NewLine;
                response += "                    if (this.IsNew)" + Environment.NewLine;
                response += "                    {" + Environment.NewLine;
                /*response += string.Format("                        DataPortal.BeginCreate<{0}>((o, e) =>" + Environment.NewLine,
                    prop.TypeName);*/
                response += string.Format("                        {0}.New{0}((o, e) =>" + Environment.NewLine,
                    prop.TypeName);
                response += "                            {" + Environment.NewLine;
                response += "                                if (e.Error != null)" + Environment.NewLine;
                response += "                                    throw e.Error;" + Environment.NewLine;
                response += "                                else" + Environment.NewLine;
                response += "                                {" + Environment.NewLine;
                response += "                                    // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += string.Format("                                    {0} = e.Object;" + Environment.NewLine,
                    FormatPascal(prop.Name));
                response += "                                }" + Environment.NewLine;
                /*response += "                            }, DataPortal.ProxyModes.LocalOnly);" + Environment.NewLine;*/
                response += "                            });" + Environment.NewLine;
                response += "                        return null;" + Environment.NewLine;
                response += "                    }" + Environment.NewLine;
                response += "                    else" + Environment.NewLine;
                response += "                    {" + Environment.NewLine;
                /*response += string.Format("                        DataPortal.BeginFetch<{0}>({1}, (o, e) =>" +
                    Environment.NewLine, prop.TypeName, GetFieldReaderStatementList(info, prop));*/
                response += string.Format("                        {0}.Get{0}({1}, (o, e) =>" +
                    Environment.NewLine, prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += "                            {" + Environment.NewLine;
                response += "                                if (e.Error != null)" + Environment.NewLine;
                response += "                                    throw e.Error;" + Environment.NewLine;
                response += "                                else" + Environment.NewLine;
                response += "                                {" + Environment.NewLine;
                response += "                                    // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += string.Format("                                    {0} = e.Object;" + Environment.NewLine,
                    FormatPascal(prop.Name));
                response += "                                }" + Environment.NewLine;
                /*response += "                            }, DataPortal.ProxyModes.LocalOnly);" + Environment.NewLine;*/
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

                response += string.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                    if (this.IsNew)" + Environment.NewLine;
                response += string.Format("                        {0} = {1}.New{1}();" + Environment.NewLine,
                    FormatPascal(prop.Name), prop.TypeName);
                response += "                    else" + Environment.NewLine;
                response += string.Format("                        {0} = {1}.Get{1}({2});" + Environment.NewLine,
                    FormatPascal(prop.Name), prop.TypeName, GetFieldReaderStatementList(info, prop));
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

                response += string.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                {" + Environment.NewLine;
                response += "                    if (this.IsNew)" + Environment.NewLine;
                response += "                    {" + Environment.NewLine;
                /*response += string.Format("                        DataPortal.BeginCreate<{0}>((o, e) =>" + Environment.NewLine,
                    prop.TypeName);*/
                response += string.Format("                        {0}.New{0}((o, e) =>" + Environment.NewLine, prop.TypeName);
                response += "                            {" + Environment.NewLine;
                response += "                                if (e.Error != null)" + Environment.NewLine;
                response += "                                    throw e.Error;" + Environment.NewLine;
                response += "                                else" + Environment.NewLine;
                response += "                                {" + Environment.NewLine;
                response += "                                    // set the property so OnPropertyChanged is raised" + 
                    Environment.NewLine;
                response += string.Format("                                    {0} = e.Object;" + Environment.NewLine,
                    FormatPascal(prop.Name));
                response += "                                }" + Environment.NewLine;
                response += "                            });" + Environment.NewLine;
                response += "                        return null;" + Environment.NewLine;
                response += "                    }" + Environment.NewLine;
                response += "                    else" + Environment.NewLine;
                response += "                    {" + Environment.NewLine;
                /*response += string.Format("                        DataPortal.BeginFetch<{0}>({1}, (o, e) =>" +
                    Environment.NewLine, prop.TypeName, GetFieldReaderStatementList(info, prop));*/
                response += string.Format("                        {0}.Get{0}({1}, (o, e) =>" +
                    Environment.NewLine, prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += "                            {" + Environment.NewLine;
                response += "                                if (e.Error != null)" + Environment.NewLine;
                response += "                                    throw e.Error;" + Environment.NewLine;
                response += "                                else" + Environment.NewLine;
                response += "                                {" + Environment.NewLine;
                response += "                                    // set the property so OnPropertyChanged is raised" + 
                    Environment.NewLine;
                response += string.Format("                                    {0} = e.Object;" + Environment.NewLine,
                    FormatPascal(prop.Name));
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
            var response = string.Empty;

            if (CurrentUnit.GenerationParams.SilverlightUsingServices)
            {
                /* ReadOnly Silverlight using services

                if (!FieldManager.FieldExists(ChildrenProperty))
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
                        }, DataPortal.ProxyModes.LocalOnly);
                    return null;
                }
                else
                {
                    return GetProperty(ChildrenProperty);
                }*/

                response += (UseNoSilverlight() ? "#if SILVERLIGHT" + Environment.NewLine : "");
                response += string.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                {" + Environment.NewLine;
                /*response += string.Format("                    DataPortal.BeginFetch<{0}>({1}, (o, e) =>" + Environment.NewLine,
                    prop.TypeName, GetFieldReaderStatementList(info, prop));*/
                response += string.Format("                    {0}.Get{0}({1}, (o, e) =>" + Environment.NewLine,
                    prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += "                        {" + Environment.NewLine;
                response += "                            if (e.Error != null)" + Environment.NewLine;
                response += "                                throw e.Error;" + Environment.NewLine;
                response += "                            else" + Environment.NewLine;
                response += "                            {" + Environment.NewLine;
                response += "                                // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += string.Format("                                {0} = e.Object;" + Environment.NewLine,
                    FormatPascal(prop.Name));
                response += "                            }" + Environment.NewLine;
                /*response += "                        }, DataPortal.ProxyModes.LocalOnly);" + Environment.NewLine;*/
                response += "                        });" + Environment.NewLine;
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

                response += string.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += "                {" + Environment.NewLine;
                /*response += string.Format("                    DataPortal.BeginFetch<{0}>({1}, (o, e) =>" + Environment.NewLine,
                    prop.TypeName, GetFieldReaderStatementList(info, prop));*/
                response += string.Format("                    {0}.Get{0}({1}, (o, e) =>" + Environment.NewLine,
                    prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += "                        {" + Environment.NewLine;
                response += "                            if (e.Error != null)" + Environment.NewLine;
                response += "                                throw e.Error;" + Environment.NewLine;
                response += "                            else" + Environment.NewLine;
                response += "                            {" + Environment.NewLine;
                response += "                                // set the property so OnPropertyChanged is raised" +
                    Environment.NewLine;
                response += string.Format("                                {0} = e.Object;" + Environment.NewLine,
                    FormatPascal(prop.Name));
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

                response += string.Format("                if (!FieldManager.FieldExists({0}))" + Environment.NewLine,
                    FormatPropertyInfoName(prop.Name));
                response += string.Format("                    {0} = {1}.Get{1}({2});" + Environment.NewLine,
                    FormatPascal(prop.Name), prop.TypeName, GetFieldReaderStatementList(info, prop));
                response += Environment.NewLine;
                response += ChildPropertyDeclareGetReturner(prop);
                response += (CurrentUnit.GenerationParams.SilverlightUsingServices ? "#endif" + Environment.NewLine : "");
            }

            return response;
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

            response += string.Format("                if (!{0})" + Environment.NewLine,
                                      FormatFieldName(prop.Name + "Loaded"));
            response += "                {" + Environment.NewLine;
            response += string.Format("                    {0} = {1}.Get{1}({2});" + Environment.NewLine,
                                      FormatPascal(prop.Name),
                                      prop.TypeName,
                                      GetFieldReaderStatementList(info, prop));
            response += string.Format("                    {0} = true;" + Environment.NewLine,
                                      FormatFieldName(prop.Name + "Loaded"));
            response += "                }" + Environment.NewLine;
            response += Environment.NewLine;
            response += ChildPropertyDeclareGetReturner(prop);
            return response;
        }

        private string GetFieldReaderStatementList(CslaObjectInfo info, ChildProperty prop)
        {
            var response = string.Empty;

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
                response = string.Format("                return GetProperty({0});" + Environment.NewLine,
                                          FormatPropertyInfoName(prop.Name));
            }
            else if (prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
            {
                response = string.Format("                return {0};" + Environment.NewLine,
                                          FormatFieldName(prop.Name));
            }
            else //if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response = string.Format("                return {0};" + Environment.NewLine,
                                          FormatProperty(prop.Name));
            }

            return response;
        }

        #endregion

        #region Unit of Work handling

        public string UnitOfWorkPropertyDeclare(CslaObjectInfo info, UnitOfWorkProperty uowProp)
        {
            var response = string.Empty;

            var isReadOnly = false;

            if (uowProp.ReadOnly)
            {
                isReadOnly = true;
            }

            if (uowProp.DeclarationMode == PropertyDeclaration.Managed)
            {
                response += string.Format("public {0} {1}" + Environment.NewLine,
                                          uowProp.TypeName,
                                          uowProp.Name);
                response += "        {" + Environment.NewLine;
                response += string.Format("            get {{ return GetProperty({0}); }}" + Environment.NewLine,
                                          FormatPropertyInfoName(uowProp.Name));

                response += string.Format("            {0}set {{ LoadProperty({1}, value); }}{2}",
                                          isReadOnly ? "private " : "",
                                          FormatPropertyInfoName(uowProp.Name),
                                          Environment.NewLine);
                response += "        }";
            }
            else  //if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            {
                response += string.Format("public {0} {1} {{ get; {2}set; }}",
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
        public static CriteriaCollection FilterAndMergeUnitOfWorkCriteriacollection(CslaObjectInfo info)
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
            if (uowProp.TargetCriteria == string.Empty)
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
                (info.IsGetter && uowCrit.IsGetter) ||
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
            if (uowProp.TargetCriteria == string.Empty)
                return false;

            var targetInfo = info.Parent.CslaObjects.Find(uowProp.TypeName);
            var targetCrit = GetCriteriaObjects(targetInfo).Find(uowProp.TargetCriteria);

            var isGetter = ForceIsGetter(info, uowProp);

            /*if ((!isGetter && uowCrit.IsCreator) ||
                (isGetter && uowCrit.IsGetter) ||
                (info.IsDeleter && uowCrit.IsDeleter))*/
            if ((info.IsCreator && uowCrit.IsCreator) ||
                (info.IsGetter && uowCrit.IsGetter) ||
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

        #endregion

        #region Context Connection Manager

        public string GetConnection(CslaObjectInfo info, bool isFetch)
        {
            var response = "using (var ctx = ";

            if (info.PersistenceType == PersistenceType.LinqContext)
            {
                response += "ContextManager<" + info.DbContextObject + ">.GetManager(Database." + info.DbName +
                            "Connection, false))";
            }
            else if (info.PersistenceType == PersistenceType.EFContext)
            {
                response += "ObjectContextManager<" + info.DbContextObject + ">.GetManager(Database." + info.DbName +
                            "Connection, false))";
            }
            else if (info.PersistenceType == PersistenceType.SqlConnectionUnshared)
            {
                response = "using (var cn = new SqlConnection(Database." + info.DbName + "Connection))";
            }
            else if (info.TransactionType == TransactionType.ADO && !isFetch)
            {
                response += "TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database." + info.DbName +
                            "Connection, false))";
            }
            else
            {
                response += "ConnectionManager<SqlConnection>.GetManager(Database." + info.DbName +
                            "Connection, false))";
            }
            return response;
        }

        public string GetCommand(CslaObjectInfo info, string commandText)
        {
            return "using (var cmd = new SqlCommand(\"" + commandText + "\", " + LocalContextConnection(info) + "))";
        }

        public string LocalContextConnection(CslaObjectInfo info)
        {
            if (info.PersistenceType == PersistenceType.SqlConnectionUnshared)
                return "cn";

            return "ctx.Connection";
        }

        #endregion

        public string[] CslaObjectPrimaryKeys(string infoName)
        {
            return CslaObjectPrimaryKeys(CurrentUnit.CslaObjects.Find(infoName));
        }

        public string[] CslaObjectPrimaryKeys(CslaObjectInfo info)
        {
            var pkList = new List<string>();
            foreach (var prop in info.AllValueProperties)
            {
                if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                    pkList.Add(prop.Name);
            }
            pkList.Sort();

            return pkList.ToArray();
        }

        public virtual string GetInitValue(Property prop)
        {
            if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetInitValue(ConvertValueProperty prop)
        {
            if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
                return "null";

            return GetInitValue(prop.PropertyType);
        }

        public virtual string GetInitValue(UpdateValueProperty prop)
        {
            if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
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
            // presume only one pair of Associated entities an a "N to N" relation

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
            var lazyLoad = GetLazyLoad(info);

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
                info.ParentType != string.Empty &&
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
                eventList.AddRange(new[] { "UpdateStart", "UpdatePre", "UpdatePost" });
            }

            if (IsEditableType(info.ObjectType) &&
                !IsCollectionType(info.ObjectType) &&
                info.GenerateDataPortalInsert)
            {
                eventList.AddRange(new[] { "InsertStart", "InsertPre", "InsertPost" });
            }

            return eventList;
        }

        public string FormatEventDocumentation(string name)
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
                case "InsertStart":
                    response += "in DataPortal_Insert, after setting row identifiers (ID) and before setting other query parameters.";
                    break;
                case "InsertPre":
                    response += "in DataPortal_Insert, after setting query parameters and before the insert operation.";
                    break;
                case "InsertPost":
                    response += "in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().";
                    break;
                case "UpdateStart":
                    response += "after setting row identifiers (ID and RowVersion) and before setting other query parameters.";
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
            foreach (Criteria crit in GetCriteriaObjects(info))
            {
                if (crit.Properties.Count > 1)
                {
                    return FactoryOrDataPortal(crit);
                }
            }

            return false;
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

        public string IfSilverlight(Conditional step, int indent, ref int silverlightLevel, bool formFeedBefore, bool formFeedAfter)
        {
            var result = string.Empty;
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
