<%
useInlineQuery = false;
if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
    useInlineQuery = true;
else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
{
    foreach (string item in Info.GenerateInlineQueries)
    {
        if (item == "Update")
        {
            useInlineQuery = true;
            break;
        }
    }
}
if (Info.GenerateDataPortalUpdate)
{
    %>

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
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
        %>Protected Overrides Sub DataPortal_Update()
            <%
    if (useInlineQuery)
        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(Info.UpdateProcedureName, ""));
    if (UseSimpleAuditTrail(Info))
    {
        %>SimpleAuditTrail()
            <%
    }
    %><%= GetConnection(Info, false) %>
                <%= GetCommand(Info, Info.UpdateProcedureName, useInlineQuery, "") %>
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
    %>cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>
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
            string postfix = ".DbType = DbType." + GetDbType(prop);

            if (prop.DeclarationMode == PropertyDeclaration.Managed ||
                prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
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
            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                %>cmd.Parameters.Add("@New<%= prop.ParameterName %>", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    <%
            }
        }
    }
    if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
    {
        %>cn.Open()
                    <%
    }
    %>Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                    <%
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
    if (Info.GetMyChildReadWriteProperties().Count > 0)
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
