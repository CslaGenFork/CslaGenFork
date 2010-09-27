using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using CslaGenerator.Metadata;

namespace CslaGenerator.Util
{
	/// <summary>
	/// Summary description for VbCslaTemplateHelper.
	/// </summary>
	public class VbCslaTemplateHelper : CslaTemplateHelper
	{
        public override string GetInitValue(TypeCodeEx typeCode)
		{
			if (typeCode == TypeCodeEx.Int16 || typeCode == TypeCodeEx.Int32 || typeCode == TypeCodeEx.Int64 || typeCode == TypeCodeEx.Double
				|| typeCode == TypeCodeEx.Decimal || typeCode == TypeCodeEx.Single) { return "0"; }
			else if (typeCode == TypeCodeEx.String) { return "String.Empty"; }
			else if (typeCode == TypeCodeEx.Boolean) { return "False"; }
			else if (typeCode == TypeCodeEx.Byte) { return "0"; }
			else if (typeCode == TypeCodeEx.Object) { return "Nothing"; }
			else if (typeCode == TypeCodeEx.Guid) { return "Guid.Empty"; }
			else if (typeCode == TypeCodeEx.SmartDate) { return "New SmartDate(True)"; }
            else if (typeCode == TypeCodeEx.DateTime) { return "DateTime.Now"; }
			else if (typeCode == TypeCodeEx.Char) { return "Char.MinValue"; }
            else if (typeCode == TypeCodeEx.ByteArray) { return "new Byte() {}"; }
			else { return String.Empty; }
		}
        public override string GetInitValue(ValueProperty prop)
        {
            if (AllowNull(prop) && prop.PropertyType != TypeCodeEx.SmartDate)
                return "Nothing";
            else
                return GetInitValue(prop.PropertyType);
        }
		public override string GetReaderAssignmentStatement(ValueProperty prop)
		{
			return GetReaderAssignmentStatement(prop,false);
		}
        public override string GetReaderAssignmentStatement(ValueProperty prop, bool Structure)
        {
            string statement;
            if (Structure)
                statement = "nfo." + prop.Name;
            else
                statement = FormatFieldName(prop.Name);
            if (PropertyMode == CslaPropertyMode.Managed)
                if (AllowNull(prop))
                {
                    string formatString;
                    if (TypeHelper.IsNullableType(prop.PropertyType))
                        formatString = "LoadProperty({0}, If(Not dr.IsDBNull(\"{2}\"), New {3}(dr.{1}(\"{2}\")), Nothing))";
                    else
                        formatString = "LoadProperty({0}, If(Not dr.IsDBNull(\"{2}\"), dr.{1}(\"{2}\"), Nothing))";
                    return String.Format(formatString,
                        FormatManaged(prop.Name),
                        GetReaderMethod(prop.PropertyType),
                        prop.ParameterName,
                        GetDataType(prop));
                }
                else
                    return String.Format("LoadProperty({0}, dr.{1}(\"{2}\"))", FormatManaged(prop.Name), GetReaderMethod(prop.PropertyType), prop.ParameterName);
            else
                return string.Format(GetDataReaderStatement(prop), statement);
        }
        public override string GetDataReaderStatement(ValueProperty prop)
        {
            bool ternarySupport = (GeneratorController.Current.CurrentUnit.GenerationParams.TargetFramework != TargetFramework.CSLA20 &&
                        GeneratorController.Current.CurrentUnit.GenerationParams.TargetFramework != TargetFramework.CSLA10);
            bool nullable = AllowNull(prop);
            StringBuilder st = new StringBuilder();

            if (nullable && prop.PropertyType != TypeCodeEx.ByteArray)
            {
                if (ternarySupport)
                    st.AppendFormat("If(Not dr.IsDBNull(\"{0}\"), ", prop.ParameterName);
                else
                    st.AppendFormat("If Not dr.IsDBNull(\"{0}\") Then ", prop.ParameterName);
            }
            if (ternarySupport)
                st.Insert(0, "{0} = ");
            else
                st.Append("{0} = ");

            if (nullable && TypeHelper.IsNullableType(prop.PropertyType))
                st.AppendFormat("New {0}(", GetDataType(prop));
            
            st.Append("dr.");

            if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
                st.Append(GetReaderMethod(prop.PropertyType));
            else
                st.Append(GetReaderMethod(GetDbType(prop.DbBindColumn), prop.PropertyType));


            st.Append("(\"" + prop.ParameterName + "\"");

            if (prop.PropertyType == TypeCodeEx.SmartDate)
                st.Append(", true");

            st.Append(")");
            if (nullable && TypeHelper.IsNullableType(prop.PropertyType))
                st.Append(")");
            if (nullable && ternarySupport && prop.PropertyType != TypeCodeEx.ByteArray)
                st.Append(", Nothing)");

            if (prop.PropertyType == TypeCodeEx.ByteArray)
            {
                st.Remove(0, 6);
                return "{0} = TryCast(" + st.ToString() + ", Byte())";
            }

            return st.ToString();
        }

        //protected override string GetDataType(TypeCodeEx type) // original
	    public override string GetDataType(TypeCodeEx type)
        {
            if (type == TypeCodeEx.ByteArray)
                return "Byte()";

            return type.ToString();
        }

        public override string GetDataType(Property prop)
        {
            string t = GetDataType(prop.PropertyType);
            if (AllowNull(prop))
            {
                if (TypeHelper.IsNullableType(prop.PropertyType))
                    if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA10 ||
                        CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA20)
                        t = string.Format("Nullable(Of {0})", t);
                    else
                        t += "?";
            }
            return t;
        }

        public override string GetParameterSet(Property prop, bool Criteria)
        {
            bool nullable = AllowNull(prop);
            string propName;
            if (Criteria)
                propName = "crit." + FormatPascal(prop.Name);
            else if (PropertyMode == CslaPropertyMode.Managed)
                propName = String.Format("ReadProperty({0})", FormatManaged(prop.Name));
            else
                propName = FormatFieldName(prop.Name);

            switch (prop.PropertyType)
            {
                case Metadata.TypeCodeEx.SmartDate:
                    return propName + ".DBValue";
                case Metadata.TypeCodeEx.Guid:
                    if (nullable)
                        return string.Format("GetNullableParameter(Of {0})({1})", prop.PropertyType.ToString(), propName);
                    else
                        return "IIf (" + propName + ".Equals(Guid.Empty), DBNull.Value, " + propName + ")";
                default:
                    if (nullable)
                    {
                        if (TypeHelper.IsNullableType(prop.PropertyType))
                            return string.Format("GetNullableParameter(Of {0})({1})", prop.PropertyType.ToString(), propName);
                        else
                            return "IIf (" + propName + " Is Nothing, DBNull.Value, " + propName + ")";
                    }
                    else
                        return propName;
            }
        }

		//protected internal override string GetLanguageVariableType(DbType dataType) // original
	    public override string GetLanguageVariableType(DbType dataType)
		{	
			switch (dataType)
			{
				case DbType.AnsiString: return "String";
				case DbType.AnsiStringFixedLength: return "String";
				case DbType.Binary: return "Byte()";
				case DbType.Boolean: return "Boolean";
				case DbType.Byte: return "Byte";
				case DbType.Currency: return "Decimal";
                case DbType.Date:
                case DbType.DateTime: return "DateTime";
				case DbType.Decimal: return "Decimal";
				case DbType.Double: return "Double";
				case DbType.Guid: return "Guid";
				case DbType.Int16: return "Short";
				case DbType.Int32: return "Integer";
				case DbType.Int64: return "Long";
				case DbType.Object: return "Object";
				case DbType.SByte: return "SByte";
				case DbType.Single: return "Single";
				case DbType.String: return "String";
				case DbType.StringFixedLength: return "String";
				case DbType.Time: return "TimeSpan";
				case DbType.UInt16: return "Short";
				case DbType.UInt32: return "Integer";
				case DbType.UInt64: return "Long";
				case DbType.VarNumeric: return "Decimal";
				default:
				{
					return "__UNKNOWN__" + dataType.ToString();
				}
			}
		}

		public override string GetRelationString(CslaObjectInfo info, ChildProperty child)
		{
            string indent = new string(' ', IndentLevel * 4);

			StringBuilder sb = new StringBuilder();
			CslaObjectInfo childInfo = FindChildInfo(info,child.TypeName);
			string joinColumn = String.Empty;
			if (child.LoadParameters.Count > 0)
			{
				if (IsCollectionType(childInfo.ObjectType))
				{
					joinColumn = child.LoadParameters[0].Property.Name;
					childInfo = FindChildInfo(info,childInfo.ItemType);
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
			sb.Append("\", ds.Tables(");
			sb.Append(_resultSetCount.ToString());
			sb.Append(").Columns(\"");
			sb.Append(joinColumn);
			sb.Append("\"), ds.Tables(");
			sb.Append((_resultSetCount + 1).ToString());
			sb.Append(").Columns(\"");
			sb.Append(joinColumn);
			sb.Append("\"), False)");
	
			_resultSetCount++;
			return sb.ToString();
		}

		public override string GetXmlCommentString(string xmlComment)
		{
            string indent = new string(' ', IndentLevel * 4);

			// add leading indent and comment sign 
			xmlComment = indent + "''' " + xmlComment;

			return Regex.Replace(xmlComment, "\r\n", "\r\n" + indent + "''' ", RegexOptions.Multiline);
		}

		public override string GetUsingStatementsString(CslaObjectInfo info)
		{
			string[] usingNamespaces = GetNamespaces(info);

			string result = String.Empty;
			foreach (string namespaceName in usingNamespaces)
			{
				result += "Imports " + namespaceName + "\n";
			}

			return(result);
		}

        public override string GetAttributesString(string[] attributes)
        {
            if (attributes == null || attributes.Length == 0)
                return string.Empty;

            return "<" + string.Join(", ", attributes) + "> _";
        }

        public override string LoadProperty(ValueProperty prop, string value)
        {
            string result = base.LoadProperty(prop, value);
            return result.Substring(0, result.Length - 1);
        }

	}
}
