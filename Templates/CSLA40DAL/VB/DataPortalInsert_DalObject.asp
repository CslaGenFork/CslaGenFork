<%
if (Info.GenerateDataPortalInsert)
{
    string strInsertPK = string.Empty;
    string strInsertComment = string.Empty;
    string strInsertCommentResult = string.Empty;
    string strInsertParams = string.Empty;
    bool hasInsertTimestamp = false;
    bool insertIsFirst = true;

    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
            strInsertPK += FormatCamel(prop.Name) + " = -1;" + Environment.NewLine + new string(' ', 12);

        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            hasInsertTimestamp = true;
            strInsertCommentResult = "/// <returns>The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + " of the new " + Info.ObjectName + ".</returns>";
        }
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DbBindColumn.NativeType != "timestamp" &&
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly || prop.DbBindColumn.NativeType == "timestamp"))
        {
            if (!insertIsFirst)
                strInsertParams += ", ";
            else
                insertIsFirst = false;

            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

            strInsertComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
                strInsertParams += "out ";

            strInsertParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
    %>

        /// <summary>
        /// Inserts a new <%= Info.ObjectName %> object in the database.
        /// </summary>
        <%= strInsertComment %><%= strInsertCommentResult %>
        public <%= hasInsertTimestamp ? "byte[]" : "void" %> Insert(<%= strInsertParams %>)
        {
            <%= strInsertPK %><%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, Info.InsertProcedureName) %>
                {
                    <%
    if (Info.CommandTimeout != string.Empty)
    {
        %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
    }
    %>cmd.CommandType = CommandType.StoredProcedure;
                    <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default ||
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly)))
        {
            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                %>cmd.Parameters.Add("@New<%= prop.ParameterName %>", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    <%
            }
            else
            {
                TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);
                string postfix = string.Empty;
                if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
                    postfix = ".Direction = ParameterDirection.Output";
                else
                    postfix = ".DbType = DbType." + TypeHelper.GetDbType(propType);

                if (AllowNull(prop) && propType == TypeCodeEx.Guid)
                {
                    %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %>.Equals(Guid.Empty) ? (object)DBNull.Value : <%= FormatCamel(prop.Name) %>).DbType = DbType.<%= TypeHelper.GetDbType(propType) %>;
                    <%
                }
                else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
                {
                    %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %> == null ? (object)DBNull.Value : <%= FormatCamel(prop.Name) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>).DbType = DbType.<%= TypeHelper.GetDbType(propType) %>;
                    <%
                }
                else
                {
                    %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %><%= (propType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>)<%= postfix %>;
                    <%
                }
            }
        }
    }
    %>cmd.ExecuteNonQuery();
                    <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.IsPrimaryKey || prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            %><%= FormatCamel(prop.Name) %> = (<%= GetLanguageVariableType(prop.DbBindColumn.DataType) %>)cmd.Parameters["@<%= prop.ParameterName %>"].Value;
                    <%
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            %>return (byte[])cmd.Parameters["@New<%= prop.ParameterName %>"].Value;
                    <%
        }
    }
    %>
                }
            }
        }
    <%
}
%>
