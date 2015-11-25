<%
string parentType = Info.ParentType;
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
    lastCriteria = "";
    useInlineQuery = false;
    if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
        useInlineQuery = true;
    else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
    {
        foreach (string item in Info.GenerateInlineQueries)
        {
            if (item == "Create")
            {
                useInlineQuery = true;
                break;
            }
        }
    }
    %>

        ''' <summary>
        ''' Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        ''' </summary>
        <%
    if (parentType.Length > 0)
    {
        %>''' <param name="parent">The parent object.</param>
        <%
    }
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %><Transactional(TransactionalTypes.EnterpriseServices)>
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope)
    {
        %><Transactional(TransactionalTypes.TransactionScope)>
        <%
    }
    lastCriteria = parentType.Length > 0 ? "parent" : "";
    if (useInlineQuery)
        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(Info.InsertProcedureName, (parentType.Length > 0 ? parentType + " parent" : "")));
    %>Private Sub Child_Insert(<%= (parentType.Length > 0 ? "parent As " + parentType : "") %>)
            <%
    if (UseSimpleAuditTrail(Info))
    {
        %>
            SimpleAuditTrail()
            <%
    }
    %>
            <%= GetConnection(Info, false) %>
                <%= GetCommand(Info, Info.InsertProcedureName, useInlineQuery, lastCriteria) %>
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
    if (parentType.Length > 0)
    {
        foreach (ValueProperty parentProp in Info.GetParentValueProperties())
        {
            if (parentProp.PropertyType == TypeCodeEx.SmartDate)
            {
                %>Dim l<%= parentProp.Name %> As New SmartDate(parent.<%= parentProp.Name %>)
                    cmd.Parameters.AddWithValue("@<%= GetFkParameterNameForParentProperty(Info, parentProp) %>", l<%= parentProp.Name %>.DBValue).DbType = DbType.DateTime
                    <%
            }
            else
            {
                %>cmd.Parameters.AddWithValue("@<%= GetFkParameterNameForParentProperty(Info, parentProp) %>", parent.<%= parentProp.Name %>).DbType = DbType.<%= GetDbType(parentProp) %>
                    <%
            }
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
                        %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", If(<%= GetFieldReaderStatement(prop) %><%= TypeHelper.IsNullableType(propType) ? ".HasValue" : " IsNot Nothing" %>, <%= GetFieldReaderStatement(prop) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>, DBNull.Value)).DbType = DbType.<%= GetDbType(prop) %>
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
                        %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", If(<%= GetParameterSet(Info, prop) %><%= TypeHelper.IsNullableType(propType) ? ".HasValue" : " IsNot Nothing" %>, <%= GetFieldReaderStatement(prop) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>, DBNull.Value)).DbType = DbType.<%= GetDbType(prop) %>
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
            %>
                    <%= GetFieldLoaderStatement(prop, "DirectCast(cmd.Parameters(\"@" + prop.ParameterName + "\").Value, " + GetLanguageVariableType(prop.DbBindColumn.DataType) + ")") %>
                    <%
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DbBindColumn.NativeType == "timestamp")
        {
            %>
                    <%= GetFieldLoaderStatement(prop, "DirectCast(cmd.Parameters(\"@New" + prop.ParameterName + "\").Value, Byte())") %>
                    <%
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
                %>
            End Using
        End Sub
    <%
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalUpdate)
{
    lastCriteria = "";
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
    %>

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        %>''' <param name="parent">The parent object.</param>
        <%
    }
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %><Transactional(TransactionalTypes.EnterpriseServices)>
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope)
    {
        %><Transactional(TransactionalTypes.TransactionScope)>
        <%
    }
    lastCriteria = (parentType.Length > 0 && !Info.ParentInsertOnly) ? "parent" : "";
    if (useInlineQuery)
        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(Info.UpdateProcedureName, ((parentType.Length > 0 && !Info.ParentInsertOnly) ? parentType + " parent" : "")));
    %>Private Sub Child_Update(<%= ((parentType.Length > 0 && !Info.ParentInsertOnly) ? "parent As " + parentType : "") %>)
            <%
    if (CurrentUnit.GenerationParams.UpdateOnlyDirtyChildren)
    {
        %>
            If Not IsDirty
                return
            End If

            <%
    }
    if (UseSimpleAuditTrail(Info))
    {
        %>
            SimpleAuditTrail();
            <%
    }
    %>
            <%= GetConnection(Info, false) %>
                <%= GetCommand(Info, Info.UpdateProcedureName, useInlineQuery, lastCriteria) %>
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
                    if (parentType.Length > 0 && !Info.ParentInsertOnly)
                    {
                        foreach (ValueProperty parentProp in Info.GetParentValueProperties())
                        {
                            if (parentProp.PropertyType == TypeCodeEx.SmartDate)
                            {
                                %>Dim l<%= parentProp.Name %> As New SmartDate(parent.<%= parentProp.Name %>)
                    cmd.Parameters.AddWithValue("@<%= GetFkParameterNameForParentProperty(Info, parentProp) %>", l<%= parentProp.Name %>.DBValue).DbType = DbType.DateTime
                    <%
                            }
                            else
                            {
                                %>cmd.Parameters.AddWithValue("@<%= GetFkParameterNameForParentProperty(Info, parentProp) %>", parent.<%= parentProp.Name %>).DbType = DbType.<%= GetDbType(parentProp) %>
                    <%
                            }
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
                            string postfix = ".DbType = DbType." + GetDbType(prop);

                            if (prop.DeclarationMode == PropertyDeclaration.Managed || prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion)
                            {
                                if (AllowNull(prop) && propType == TypeCodeEx.Guid)
                                {
                                    %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", If(<%= GetFieldReaderStatement(prop) %>.Equals(Guid.Empty), DBNull.Value, <%= GetFieldReaderStatement(prop) %>)).DbType = DbType.<%= GetDbType(prop) %>
                    <%
                                }
                                else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
                                {
                                    %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", If(<%= GetFieldReaderStatement(prop) %><%= TypeHelper.IsNullableType(propType) ? ".HasValue" : " IsNot Nothing" %>, <%= GetFieldReaderStatement(prop) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>, DBNull.Value)).DbType = DbType.<%= GetDbType(prop) %>
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
                                    %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", If(<%= GetParameterSet(Info, prop) %><%= TypeHelper.IsNullableType(propType) ? ".HasValue" : " IsNot Nothing" %>, <%= GetFieldReaderStatement(prop) %><%= TypeHelper.IsNullableType(propType) ? ".Value" :"" %>, DBNull.Value)).DbType = DbType.<%= GetDbType(prop) %>
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
                            %>
                    <%= GetFieldLoaderStatement(prop, "DirectCast(cmd.Parameters(\"@New" + prop.ParameterName + "\").Value, Byte())") %>
                    <%
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
                    %>
            End Using
        End Sub
    <%
}

if (Info.GenerateDataPortalInsert || Info.GenerateDataPortalUpdate || Info.GenerateDataPortalDelete)
{
    %>
<!-- #include file="SimpleAuditTrail.asp" -->
<%
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalDelete)
{
    lastCriteria = "";
    useInlineQuery = false;
    if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
        useInlineQuery = true;
    else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
    {
        foreach (string item in Info.GenerateInlineQueries)
        {
            if (item == "Delete")
            {
                useInlineQuery = true;
                break;
            }
        }
    }
    %>

        ''' <summary>
        ''' Self deletes the <see cref="<%= Info.ObjectName %>"/> object from database.
        ''' </summary>
        <%
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        %>''' <param name="parent">The parent object.</param>
        <%
    }
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %><Transactional(TransactionalTypes.EnterpriseServices)>
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope)
    {
        %><Transactional(TransactionalTypes.TransactionScope)>
        <%
    }
    lastCriteria = (parentType.Length > 0 && !Info.ParentInsertOnly) ? "parent" : "";
    if (useInlineQuery)
        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(Info.DeleteProcedureName, ((parentType.Length > 0 && !Info.ParentInsertOnly) ? parentType + " parent" : "")));
    %>Private Sub Child_DeleteSelf(<%= ((parentType.Length > 0 && !Info.ParentInsertOnly) ? "parent As " + parentType : "") %>)
            <%
    if (UseSimpleAuditTrail(Info))
    {
        %>
            ' audit the object, just in case soft delete is used on this object
            SimpleAuditTrail()
            <%
    }
    %>
            <%= GetConnection(Info, false) %>
                <%
    if (Info.GetMyChildReadWriteProperties().Count > 0)
    {
        string ucpSpacer = new string(' ', 4);
        %>
<!-- #include file="UpdateChildProperties.asp" -->
                <%
    }
    %>
                <%= GetCommand(Info, Info.DeleteProcedureName, useInlineQuery, lastCriteria) %>
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
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (ValueProperty parentProp in Info.GetParentValueProperties())
        {
            if (parentProp.PropertyType == TypeCodeEx.SmartDate)
            {
                %>Dim l<%= parentProp.Name %> As New SmartDate(parent.<%= parentProp.Name %>);
                    cmd.Parameters.AddWithValue("@<%= GetFkParameterNameForParentProperty(Info, parentProp) %>", l<%= parentProp.Name %>.DBValue).DbType = DbType.DateTime
                    <%
            }
            else
            {
                %>cmd.Parameters.AddWithValue("@<%= GetFkParameterNameForParentProperty(Info, parentProp) %>", parent.<%= parentProp.Name %>).DbType = DbType.<%= GetDbType(parentProp) %>
                    <%
            }
        }
    }
    foreach (ValueProperty prop in Info.ValueProperties)
    {
        if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default ||
            (prop.DbBindColumn.NativeType == "timestamp" && Info.DeleteUseTimestamp)))
        {
            %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %><%= (prop.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= GetDbType(prop) %>
                    <%
        }
    }
    if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
    {
        %>cn.Open()
                    <%
    }
    %>Dim args As New DataPortalHookArgs(cmd)
                    OnDeletePre(args)
                    cmd.ExecuteNonQuery()
                    OnDeletePost(args)
                End Using
            End Using
            <%
    if (Info.GetMyChildProperties().Count > 0)
    {
        %>
            ' removes all previous references to children
            <%
    }
    foreach (ChildProperty collectionProperty in Info.GetMyChildProperties())
    {
        %>
            <%= GetFieldLoaderStatement(collectionProperty, "DataPortal.CreateChild(Of " + collectionProperty.TypeName + ")()") %>
            <%
    }
    %>
        End Sub
<%
}
%>
