<%
string parentType = Info.ParentType;
///CslaObjectInfo parentInfo = FindChildInfo(Info, parentType);/// DEPRECATED
if (parentInfo == null)
    parentType = "";
else if (parentInfo.ObjectType == CslaObjectType.EditableChildCollection)
    parentType = parentInfo.ParentType;
else if (parentInfo.ObjectType == CslaObjectType.EditableRootCollection)
    parentType = "";
else if (parentInfo.ObjectType == CslaObjectType.DynamicEditableRootCollection)
    parentType = "";

if (Info.GenerateDataPortalInsert)
{
    string strInsertPK = string.Empty;
    string strInsertComment = string.Empty;
    string strInsertCommentResult = string.Empty;
    string strInsertParams = string.Empty;
    bool hasInsertTimestamp = false;
    bool insertIsFirst = true;

    if (parentType.Length > 0)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (!insertIsFirst)
                strInsertParams += ", ";
            else
                insertIsFirst = false;

            TypeCodeEx propType = prop.PropertyType;

            strInsertComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strInsertParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
            strInsertPK = FormatCamel(prop.Name) + " = -1;" + Environment.NewLine + new string(' ', 12);

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
    if (parentType.Length > 0)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %><%= (prop.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                    <%
        }
    }
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
                    %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %>.Equals(Guid.Empty) ? (object)DBNull.Value : <%= FormatCamel(prop.Name) %>)<%= postfix %>;
                    <%
                }
                else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
                {
                    %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %> == null ? (object)DBNull.Value : <%= FormatCamel(prop.Name) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>)<%= postfix %>;
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
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            (prop.DbBindColumn.IsPrimaryKey &&
            prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK))
        {
            %><%= FormatCamel(prop.Name) %> = (<%= GetLanguageVariableType(prop.DbBindColumn.DataType) %>)cmd.Parameters["@<%= prop.ParameterName %>"].Value;
                    <%
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DbBindColumn.NativeType == "timestamp")
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

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalUpdate)
{
    string strUpdateComment = string.Empty;
    string strUpdateCommentResult = string.Empty;
    string strUpdateParams = string.Empty;
    bool hasUpdateTimestamp = false;
    bool updateIsFirst = true;

    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (!updateIsFirst)
                strUpdateParams += ", ";
            else
                updateIsFirst = false;

            TypeCodeEx propType = prop.PropertyType;

            strUpdateComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strUpdateParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            hasUpdateTimestamp = true;
            strUpdateCommentResult = "/// <returns>The updated " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</returns>";
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

            strUpdateComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strUpdateParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
    %>

        /// <summary>
        /// Updates in the database all changes made to the <%= Info.ObjectName %> object.
        /// </summary>
        <%= strUpdateComment %><%= strUpdateCommentResult %>
        public <%= hasUpdateTimestamp ? "byte[]" : "void" %> Update(<%= strUpdateParams %>)
        {
            <%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, Info.UpdateProcedureName) %>
                {
                    <%
            if (Info.CommandTimeout != string.Empty)
            {
                %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
            }
            %>cmd.CommandType = CommandType.StoredProcedure;
                    <%
                    if (parentType.Length > 0 && !Info.ParentInsertOnly)
                    {
                        foreach (Property prop in Info.ParentProperties)
                        {
                            %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %><%= (prop.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                    <%
                        }
                    }

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
                                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %>.Equals(Guid.Empty) ? (object)DBNull.Value : <%= FormatCamel(prop.Name) %>)<%= postfix %>;
                    <%
                            }
                            else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
                            {
                                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %> == null ? (object)DBNull.Value : <%= FormatCamel(prop.Name) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>)<%= postfix %>;
                    <%
                            }
                            else
                            {
                                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %><%= (propType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>)<%= postfix %>;
                    <%
                            }
                            if (prop.DbBindColumn.NativeType == "timestamp")
                            {
                                %>cmd.Parameters.Add("@New<%= prop.ParameterName %>", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    <%
                            }
                        }
                    }
                    %>var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("<%= Info.ObjectName %>");

                    <%
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

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalDelete)
{
    string strDeleteCritParams = string.Empty;
    string strDeleteComment = string.Empty;
    bool deleteIsFirst = true;

    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (!deleteIsFirst)
                strDeleteCritParams += ", ";
            else
                deleteIsFirst = false;

            TypeCodeEx propType = prop.PropertyType;

            strDeleteComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
        }
    }
    foreach (ValueProperty prop in Info.ValueProperties)
    {
        if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            if (!deleteIsFirst)
                strDeleteCritParams += ", ";
            else
                deleteIsFirst = false;

            TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);

            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, propType), " ", FormatCamel(prop.Name));
            strDeleteComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
        }
    }
    %>

        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        <%= strDeleteComment %>public void Delete(<%= strDeleteCritParams %>)
        {
            <%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, Info.DeleteProcedureName) %>
                {
                    <%
    if (Info.CommandTimeout != string.Empty)
    {
        %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
            <%
    }
    %>cmd.CommandType = CommandType.StoredProcedure;
                    <%
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (Property prop in Info.ParentProperties)
        {
    %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                    <%
        }
    }
    foreach (ValueProperty prop in Info.ValueProperties)
    {
        if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                    <%
        }
    }
    %>cmd.ExecuteNonQuery();
                }
            }
        }
    <%
}
%>
