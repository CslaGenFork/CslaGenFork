<%
if (Info.GenerateDataPortalInsert)
{
    %>

        /// <summary>
        /// Insert the new <see cref="<%= Info.ObjectName %>"/> object in the database.
        /// </summary>
        <%
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope || Info.TransactionType == TransactionType.TransactionScope)
    {
        %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
    }
    if (Info.InsertUpdateRunLocal)
    {
        %>[Csla.RunLocal]
        <%
    }
        %>protected override void DataPortal_Insert()
        {
            <%
    if (UseSimpleAuditTrail(Info))
    {
            %>SimpleAuditTrail();
            <%
    }
            %><%= GetConnection(Info, false) %>
            {
                <%
    if (string.IsNullOrEmpty(Info.InsertProcedureName))
    {
        Errors.Append("Object " + Info.ObjectName + " missing insert procedure name." + Environment.NewLine);
    }
    %>
                <%= GetCommand(Info, Info.InsertProcedureName) %>
                {
                    <%
    if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
    {
        %>cmd.Transaction = ctx.Transaction;
                    <%
    }
    if (Info.CommandTimeout != string.Empty)
    {
        %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
    }
    %>cmd.CommandType = CommandType.StoredProcedure;
                    <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
            prop.DataAccess == ValueProperty.DataAccessBehaviour.CreateOnly)
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetFieldReaderStatement(prop) %>)<%
            }
            else
            {
                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>)<%
            }
            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
            {
                %>.Direction = ParameterDirection.Output;<%
            }
            else
            {
                %>.DbType = DbType.<%=prop.DbBindColumn.DataType.ToString()%>;<%
            }
            %>
                    <%
        }
    }
    if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
    {
        %>cn.Open();
                    <%
    }
    %>var args = new DataPortalHookArgs(cmd);
                    OnInsertStart(args);
                    DoInsertUpdate(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                %>LoadProperty(<%= FormatPropertyInfoName(prop.Name) %>, (Byte[]) cmd.Parameters["@New<%= prop.ParameterName %>"].Value);
                    <%
            }
            else
            {
                %><%= FormatFieldName(prop.Name) %> = (Byte[]) cmd.Parameters["@New<%= prop.ParameterName %>"].Value;
                    <%
            }
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.IsPrimaryKey || prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                %>LoadProperty(<%= FormatPropertyInfoName(prop.Name) %>, (<%= GetLanguageVariableType(prop.DbBindColumn.DataType) %>) cmd.Parameters["@<%= prop.ParameterName %>"].Value);<%
            }
            else
            {
                %><%= FormatFieldName(prop.Name) %> = (<%= GetLanguageVariableType(prop.DbBindColumn.DataType) %>) cmd.Parameters["@<%= prop.ParameterName %>"].Value;<%
            }
        }
    }
    string indent = "";
    %>
                }
                <!-- #include file="UpdateChildProperties.asp" -->
                <%
    if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
    {
        %>

                ctx.Commit();
            <%
    }
    %>
            }
        }
    <%
}
%>
