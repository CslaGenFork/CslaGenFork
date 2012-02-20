<%
if (Info.GenerateDataPortalUpdate)
{
    %>

        /// <summary>
        /// Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
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
    %>
                <%= GetConnection(Info, false) %>
                {
                    <%= GetCommand(Info, Info.UpdateProcedureName) %>
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
            prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly ||
            prop.DbBindColumn.NativeType == "timestamp")
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", ReadProperty(<%= FormatPropertyInfoName(prop.Name) %>)).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                        <%
            }
            else
            {
                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                        <%
            }
        }
    }
    %>var args = new DataPortalHookArgs(cmd);
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
                %>LoadProperty(<%= FormatPropertyInfoName(prop.Name) %>, (byte[]) cmd.Parameters["@New<%= prop.ParameterName %>"].Value);<%
            }
            else
            {
                %><%= FormatFieldName(prop.Name) %> = (byte[]) cmd.Parameters["@New<%= prop.ParameterName %>"].Value;<%
            }
        }
    }
    %>
                    }
                    <%
    if (Info.GetMyChildProperties().Count > 0)
    {
        %>
<!-- #include file="UpdateChildProperties.asp" -->
                    <%
    }
    if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
    {
        %>
                    ctx.Commit();
                <%
    }
    %>
                }
            }
        }
    <%
}
%>
