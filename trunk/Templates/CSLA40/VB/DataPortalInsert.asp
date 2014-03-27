<%
if (Info.GenerateDataPortalInsert)
{
    %>

        ''' <summary>
        ''' Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        ''' </summary>
        <%
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %><Transactional(TransactionalTypes.EnterpriseServices)>
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope || Info.TransactionType == TransactionType.TransactionScope)
    {
        %><Transactional(TransactionalTypes.TransactionScope)>
        <%
    }
    if (Info.InsertUpdateRunLocal)
    {
        %><Csla.RunLocal()>
        <%
    }
        %>Protected Overrides Sub DataPortal_Insert()
            <%
    if (UseSimpleAuditTrail(Info))
    {
        %>SimpleAuditTrail()
            <%
    }
    %><%= GetConnection(Info, false) %>
                <%= GetCommand(Info, Info.InsertProcedureName) %>
                    <%
    if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
    {
        %>cmd.Transaction = ctx.Transaction
                    <%
    }
    if (Info.CommandTimeout != string.Empty)
    {
        %>cmd.CommandTimeout = <%= Info.CommandTimeout %>
                    <%
    }
    %>cmd.CommandType = CommandType.StoredProcedure
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
                %>cmd.Parameters.Add("@New<%= prop.ParameterName %>", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    <%
            }
            else
            {
                TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);
                string postfix = string.Empty;
                if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
                    postfix = ".Direction = ParameterDirection.Output";
                else
                    postfix = ".DbType = DbType." + GetDbType(prop);

                if (prop.DeclarationMode == PropertyDeclaration.Managed || prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                {
                    if (AllowNull(prop) && propType == TypeCodeEx.Guid)
                    {
                        %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", If(<%= GetFieldReaderStatement(prop) %>.Equals(Guid.Empty), DBNull.Value, <%= GetFieldReaderStatement(prop) %>)).DbType = DbType.<%= GetDbType(prop) %>
                    <%
                    }
                    else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
                    {
                        %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", If(<%= GetFieldReaderStatement(prop) %><%= TypeHelper.IsNullableType(propType) ? ".HasValue" : " IsNot Nothing " %>, <%= GetFieldReaderStatement(prop) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>, DBNull.Value)).DbType = DbType.<%= GetDbType(prop) %>
                    <%
                    }
                    else
                    {
                        %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetFieldReaderStatement(prop) %><%= (propType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>)<%= postfix %>
                    <%
                    }
                }
                else
                {
                    if (AllowNull(prop) && propType == TypeCodeEx.Guid)
                    {
                        %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", If(<%= GetParameterSet(Info, prop) %>.Equals(Guid.Empty),  DBNull.Value, <%= GetFieldReaderStatement(prop) %>)).DbType = DbType.<%= GetDbType(prop) %>
                    <%
                    }
                    else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
                    {
                        %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", If(<%= GetParameterSet(Info, prop) %><%= TypeHelper.IsNullableType(propType) ? ".HasValue" : " IsNot Nothing " %>, <%= GetFieldReaderStatement(prop) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>, DBNull.Value)).DbType = DbType.<%= GetDbType(prop) %>
                    <%
                    }
                    else
                    {
                        %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %><%= (propType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>)<%= postfix %>
                    <%
                    }
                }
            }
        }
    }
    if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
    {
        %>cn.Open()
                    <%
    }
    %>Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            (prop.DbBindColumn.IsPrimaryKey &&
            prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK))
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                %>
                    LoadProperty(<%= FormatPropertyInfoName(prop.Name) %>, DirectCast(cmd.Parameters("@<%= prop.ParameterName %>").Value, <%= GetLanguageVariableType(prop.DbBindColumn.DataType) %>))
                    <%
            }
            else
            {
                %>
                    <%= FormatFieldName(prop.Name) %> = DirectCast(cmd.Parameters("@<%= prop.ParameterName %>").Value, <%= GetLanguageVariableType(prop.DbBindColumn.DataType) %>) 
                    <%
            }
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DbBindColumn.NativeType == "timestamp")
        {
            if (prop.DeclarationMode == PropertyDeclaration.Managed)
            {
                %>
                    LoadProperty(<%= FormatPropertyInfoName(prop.Name) %>, DirectCast(cmd.Parameters("@New<%= prop.ParameterName %>").Value, Byte()))
                    <%
            }
            else
            {
                %>
                    <%= FormatFieldName(prop.Name) %> = DirectCast(cmd.Parameters("@New<%= prop.ParameterName %>").Value, Byte())
                    <%
            }
        }
    }
    %>
                End Using
                <%
    if (Info.GetMyChildProperties().Count > 0)
    {
        string ucpSpacer = new string(' ', 4);
        %>
<!-- #include file="UpdateChildProperties.asp" -->
                <%
    }
    if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
    {
        %>
                ctx.Commit()
            <%
    }
    %>
            End Using
        End Sub
    <%
}
%>
