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
if (string.IsNullOrEmpty(Info.UpdateProcedureName))
{
    Errors.Append("Object " + Info.ObjectName + " missing Update procedure name." + Environment.NewLine);
}
%>

        /// <summary>
        /// Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
if (Info.TransactionType == TransactionType.EnterpriseServices)
{
    %>
        [Transactional(TransactionalTypes.EnterpriseServices)]
        <%
}
else if (Info.TransactionType == TransactionType.TransactionScope || Info.TransactionType == TransactionType.TransactionScope)
{
    %>
        [Transactional(TransactionalTypes.TransactionScope)]
        <%
}
%>
        protected override void DataPortal_Update()
        {
            <%
if (useInlineQuery)
   InlineQueryList.Add(new AdvancedGenerator.InlineQuery(Info.UpdateProcedureName, ""));
if (TemplateHelper.UseSimpleAuditTrail(Info))
{
    %>
            SimpleAuditTrail();
            <%
}
%>
            <%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, Info.UpdateProcedureName, useInlineQuery, "") %>
                {
                    <%
if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
{
    %>
                    cmd.Transaction = ctx.Transaction;
                    <%
}
if (Info.CommandTimeout != string.Empty)
{
    %>
                    cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
}
%>
                    cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>;
                    <%
foreach (ValueProperty prop in Info.GetAllValueProperties())
{
    if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
        (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default ||
        prop.DbBindColumn.NativeType == "timestamp" ||
        (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
        prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly)))
    {
        TypeCodeEx propType = TemplateHelper.GetBackingFieldType(prop);
        string postfix = ".DbType = DbType." + TemplateHelper.GetDbType(prop);

        if (prop.DeclarationMode == PropertyDeclaration.Managed || prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
        {
            if (AllowNull(prop) && propType == TypeCodeEx.Guid)
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetFieldReaderStatement(prop) %>.Equals(Guid.Empty) ? (object)DBNull.Value : <%= GetFieldReaderStatement(prop) %>).DbType = DbType.<%= TemplateHelper.GetDbType(prop) %>;
                    <%
            }
            else if (AllowNull(prop) && propType == TypeCodeEx.CustomType)
            {
                %>// For nullable PropertyConvert, null is persisted if the backing field is zero
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetFieldReaderStatement(prop) %> == 0 ? (object)DBNull.Value : <%= GetFieldReaderStatement(prop) %>).DbType = DbType.<%= TemplateHelper.GetDbType(prop) %>;
                    <%
            }
            else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetFieldReaderStatement(prop) %> == null ? (object)DBNull.Value : <%= GetFieldReaderStatement(prop) %><%= TemplateHelper.IsNullableType(propType) ? ".Value" :"" %>).DbType = DbType.<%= TemplateHelper.GetDbType(prop) %>;
                    <%
            }
            else
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetFieldReaderStatement(prop) %><%= (propType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>)<%= postfix %>;
                    <%
            }
        }
        else
        {
            if (AllowNull(prop) && propType == TypeCodeEx.Guid)
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>.Equals(Guid.Empty) ? (object)DBNull.Value : <%= GetFieldReaderStatement(prop) %>).DbType = DbType.<%= TemplateHelper.GetDbType(prop) %>;
                    <%
            }
            else if (AllowNull(prop) && propType == TypeCodeEx.CustomType)
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>) == 0 ? (object)DBNull.Value : <%= GetFieldReaderStatement(prop) %>).DbType = DbType.<%= TemplateHelper.GetDbType(prop) %>;
                    <%
            }
            else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>) == null ? (object)DBNull.Value : <%= GetFieldReaderStatement(prop) %><%= TemplateHelper.IsNullableType(propType) ? ".Value" :"" %>).DbType = DbType.<%= TemplateHelper.GetDbType(prop) %>;
                    <%
            }
            else
            {
                %>
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %><%= (propType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>)<%= postfix %>;
                    <%
            }
        }
        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            %>
                    cmd.Parameters.Add("@New<%= prop.ParameterName %>", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    <%
        }
    }
}
if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
{
    %>
                    cn.Open();
                    <%
}
%>
                    var args = new DataPortalHookArgs(cmd);
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
            %>
                    LoadProperty(<%= FormatPropertyInfoName(prop.Name) %>, (byte[]) cmd.Parameters["@New<%= prop.ParameterName %>"].Value);
                    <%
        }
        else
        {
            %>
                    <%= FormatFieldName(prop.Name) %> = (byte[]) cmd.Parameters["@New<%= prop.ParameterName %>"].Value;
                    <%
        }
    }
}
%>
                }
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
                ctx.Commit();
            <%
}
%>
            }
        }
