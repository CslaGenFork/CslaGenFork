<%
if (Info.GenerateDataPortalUpdate)
{
    %>

        /// <summary>
        /// Update all changes made on <see cref="<%=Info.ObjectName%>"/> object in the database.
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
        %>protected override void DataPortal_Update()
        {
            if (base.IsDirty)
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
    if (string.IsNullOrEmpty(Info.UpdateProcedureName))
    {
        Errors.Append("Object " + Info.ObjectName + " missing update procedure name." + Environment.NewLine);
    }
    %>
                    <%= GetCommand(Info, Info.UpdateProcedureName) %>
                    {
                        <%
    if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
    {
        %>cmd.Transaction = ctx.Transaction;

                        <%
    }
    %>cmd.CommandType = CommandType.StoredProcedure;
                        <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
            prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly ||
            prop.DbBindColumn.NativeType == "timestamp")
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", ReadProperty(<%= FormatPropertyInfoName(prop.Name) %>)).DbType = DbType.<%=prop.DbBindColumn.DataType.ToString()%>;
                        <%
            }
            else
            {
                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>).DbType = DbType.<%=prop.DbBindColumn.DataType.ToString()%>;
                        <%
            }
        }
    }
    %>var args = new DataPortalHookArgs(cmd);
                        OnUpdateStart(args);
                        DoInsertUpdate(cmd);
                        OnUpdatePre(args);
                        cmd.ExecuteNonQuery();
                        OnUpdatePost(args);
                        <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                %>LoadProperty(<%= FormatPropertyInfoName(prop.Name) %>, (Byte[]) cmd.Parameters["@New<%= prop.ParameterName %>"].Value);<%
            }
            else
            {
                %><%=FormatFieldName(prop.Name)%> = (Byte[]) cmd.Parameters["@New<%= prop.ParameterName %>"].Value;<%
            }
        }
    }
    string indent = "    ";
    %>
                    }
                    <!-- #include file="UpdateChildProperties.inc" -->
                    <%
    if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
    {
        %>

                    ctx.Commit();
                <%
    }
    if (ActiveObjects)
    {
        if (Info.PublishToChannel.Length > 0)
        {
            %>
                        SafePublish("<%= Info.PublishToChannel %>", BusinessEvents.Updated, this);
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
