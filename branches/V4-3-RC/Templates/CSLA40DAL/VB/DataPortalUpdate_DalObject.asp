<%
if (Info.GenerateDataPortalUpdate)
{
    string strUpdateComment = string.Empty;
    string strUpdateCommentResult = string.Empty;
    string strUpdateResult = string.Empty;
    string strUpdateParams = string.Empty;
    bool hasUpdateTimestamp = false;
    bool updateIsFirst = true;

    if (usesDTO)
    {
        strUpdateResult = Info.ObjectName + "Dto";
        strUpdateParams = strUpdateResult + " " + FormatCamel(Info.ObjectName);
        strUpdateComment = System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(Info.ObjectName) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(Info.ObjectName) + " DTO.</param>";
        strUpdateCommentResult = System.Environment.NewLine + new string(' ', 8) + "/// <returns>The updated <see cref=\"" + strUpdateResult + "\"/>.</returns>";
    }
    else
    {
        foreach (ValueProperty prop in Info.GetAllValueProperties())
        {
            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                hasUpdateTimestamp = true;
                strUpdateCommentResult = System.Environment.NewLine + new string(' ', 8) + "/// <returns>The updated " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</returns>";
            }
            if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
                (prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly ||
                (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly)) ||
                prop.DbBindColumn.NativeType == "timestamp")
            {
                if (!updateIsFirst)
                    strUpdateParams += ", ";
                else
                    updateIsFirst = false;

                TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

                strUpdateComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>";
                strUpdateParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
            }
        }
        if (hasUpdateTimestamp)
            strUpdateResult = "byte[]";
        else
            strUpdateResult = "void";
    }
    if (isFirstMethod)
        isFirstMethod = false;
    else
        Response.Write(Environment.NewLine);

    %>
        /// <summary>
        /// Updates in the database all changes made to the <%= Info.ObjectName %> object.
        /// </summary><%= strUpdateComment %><%= strUpdateCommentResult %>
        public <%= strUpdateResult %> Update(<%= strUpdateParams %>)
        {
            <%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, Info.UpdateProcedureName) %>
                {
                    <%
    if (Info.CommandTimeout != string.Empty)
    {
        %>
                    cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
    }
    %>
                    cmd.CommandType = CommandType.StoredProcedure;
                    <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default ||
            prop.DbBindColumn.NativeType == "timestamp" ||
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly)))
        {
            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);
            string postfix = ".DbType = DbType." + TypeHelper.GetDbType(propType);

            if (AllowNull(prop) && propType == TypeCodeEx.Guid)
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %>.Equals(Guid.Empty) ? (object)DBNull.Value : <%= FormatCamel(prop.Name) %>).DbType = DbType.<%= TypeHelper.GetDbType(propType) %>;
                    <%
            }
            else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %> == null ? (object)DBNull.Value : <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>).DbType = DbType.<%= TypeHelper.GetDbType(propType) %>;
                    <%
            }
            else
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %><%= (propType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>)<%= postfix %>;
                    <%
            }
            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                %>
                    cmd.Parameters.Add("@New<%= prop.ParameterName %>", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    <%
            }
        }
    }
    %>
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("<%= Info.ObjectName %>");
                    <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            Response.Write(Environment.NewLine);
            %>
                    <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) + " = ": "return ") %>(byte[])cmd.Parameters["@New<%= prop.ParameterName %>"].Value;
                    <%
        }
    }
    %>
                }
            }
            <%
    if (usesDTO)
    {
        %>
            return <%= FormatCamel(Info.ObjectName) %>;
        <%
    }
    %>
        }
    <%
}
%>
