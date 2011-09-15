<%
string parentType = Info.ParentType;
CslaObjectInfo parentInfo = FindChildInfo(Info, parentType);
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
    %>

        /// <summary>
        /// Insert <see cref="<%= Info.ObjectName %>"/> object to database with or without transaction.
        /// </summary>
        <%
    if (parentType.Length > 0)
    {
        %>/// <param name="parent">The parent object.</param>
        <%
    }
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope)
    {
        %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
    }
    %>internal void <%= isChild ? "Child_" : "DataPortal_" %>Insert(<% if (parentType.Length > 0) { %><%= parentType %> parent<% } %>)
        {
            <%
    if (UseSimpleAuditTrail(Info))
    {
        %>
            SimpleAuditTrail();
            <%
    }
            %>
            <%= GetConnection(Info, false) %>
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
    if (parentType.Length > 0)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (prop.PropertyType == TypeCodeEx.SmartDate)
            {
                %>SmartDate l<%= prop.Name %> = new SmartDate(parent.<%= prop.Name %>);
                    cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", l<%= prop.Name %>).DbType = DbType.DateTime;
                    <%
            }
            else
            {
                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", parent.<%= prop.Name %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                    <%
            }
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        TypeCodeEx propType = TypeHelper.GetBackingFieldType(prop);
        if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
            prop.DataAccess == ValueProperty.DataAccessBehaviour.CreateOnly)
        {
            %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>)<%
            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
            {
                %>.Direction = ParameterDirection.Output;
                    <%
            }
            else
            {
                %>.DbType = DbType.<%= TypeHelper.GetDbType(propType) %>;
                    <%
            }
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
            %>
                    <%= GetFieldLoaderStatement(prop, "(Byte[]) cmd.Parameters[\"@New" + prop.ParameterName + "\"].Value") %>;
                    <%
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.DbBindColumn.IsPrimaryKey || prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            %>
                    <%= GetFieldLoaderStatement(prop, "(" + GetLanguageVariableType(prop.DbBindColumn.DataType) + ") cmd.Parameters[\"@" + prop.ParameterName + "\"].Value") %>;
                    <%
        }
    }
    string indent = "";
    %>
                    MarkOld();
                }
                <!-- #include file="UpdateChildProperties.asp" -->
            }
        }
    <%
}

if (Info.GenerateDataPortalUpdate)
{
%>

        /// <summary>
        /// Saves <see cref="<%= Info.ObjectName %>"/> object to database with or without transaction.
        /// </summary>
        <%
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        %>/// <param name="parent">The parent object.</param>
        <%
    }
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope)
    {
        %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
    }
    %>internal void <%= isChild ? "Child_" : "DataPortal_" %>Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>)
        {
            if (base.IsDirty)
            {<%
    if (UseSimpleAuditTrail(Info))
    {
        %>
                SimpleAuditTrail();
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
                            if (prop.PropertyType == TypeCodeEx.SmartDate)
                            {
                                %>SmartDate l<%=prop.Name%> = new SmartDate(parent.<%=prop.Name%>);
                        cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", l<%= prop.Name %>).DbType = DbType.DateTime;
                        <%
                            }
                            else
                            {
                                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", parent.<%= prop.Name %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                        <%
                            }
                        }
                    }
                    foreach (ValueProperty prop in Info.GetAllValueProperties())
                    {
                        if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                            prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly ||
                            prop.DbBindColumn.NativeType == "timestamp")
                        {
                            %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                        <%
                        }
                    }
                    if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
                    {
                        %>cn.Open();
                        <%
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
                            %>
                        <%= GetFieldLoaderStatement(prop, "(Byte[]) cmd.Parameters[\"@New" + prop.ParameterName + "\"].Value") %>;
                        <%
                        }
                    }
                    string indent = "";
                    %>
                        MarkOld();
                    }
                    <!-- #include file="UpdateChildProperties.asp" -->
                }
            }
        }
    <%
}

if (Info.GenerateDataPortalInsert || Info.GenerateDataPortalUpdate)
{
    %>
<!-- #include file="DoInsertUpdate.asp" -->
<%
}
if (Info.GenerateDataPortalDelete)
{
    // get the Delete Stored Procedure name from criteria
    string criteriaDeleteProcedureName = string.Empty;
    // This is kind of weak, because this will fetch the procedure name for the first delete criteria found,
    // but it's unlikely anyone will have more than one delete criteria.
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        // Try first the sproc criteria with status enabled for sprocs
        if (c.DeleteOptions.Procedure)
        {
            criteriaDeleteProcedureName = c.DeleteOptions.ProcedureName;
            break;
        }
    }
    if (criteriaDeleteProcedureName == string.Empty)
    {
        foreach (Criteria c in GetCriteriaObjects(Info))
        {
            // Try now just the procedure name disregarding the status (sprocs generation must be fixed)
            if (c.DeleteOptions.ProcedureName != string.Empty)
            {
                criteriaDeleteProcedureName = c.DeleteOptions.ProcedureName;
                break;
            }
        }
    }

    %>

        /// <summary>
        /// Self delete the <see cref="<%= Info.ObjectName %>"/> object from database with or without transaction.
        /// </summary>
        <%
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        %>/// <param name="parent">The parent object.</param>
        <%
    }
    if (Info.TransactionType == TransactionType.EnterpriseServices)
    {
        %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
    }
    else if (Info.TransactionType == TransactionType.TransactionScope)
    {
        %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
    }
        %>internal void <%= isChild ? "Child_" : "DataPortal_" %>DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>)
        {
            if (!IsNew)
            {
                <%
    if (UseSimpleAuditTrail(Info))
    {
        %>
                // audit the object, just in case soft delete is used on this object
                SimpleAuditTrail();
                <%
    }
                %><%= GetConnection(Info, false) %>
                {
                    <%
    if (string.IsNullOrEmpty(criteriaDeleteProcedureName))
    {
        Errors.Append("Criteria " + Info.ObjectName + " missing delete procedure name." + Environment.NewLine);
    }
    %>
                    <%= GetCommand(Info, criteriaDeleteProcedureName) %>
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
    foreach (ValueProperty prop in Info.ValueProperties)
    {
        if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%= GetParameterSet(Info, prop) %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                        <%
        }
    }
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            if (prop.PropertyType == TypeCodeEx.SmartDate)
            {
                %>SmartDate l<%= prop.Name %> = new SmartDate(parent.<%= prop.Name %>);
                        cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", l<%= prop.Name %>).DbType = DbType.DateTime;
                        <%
            }
            else
            {
                %>cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", parent.<%= prop.Name %>).DbType = DbType.<%= TypeHelper.GetDbType(prop.PropertyType) %>;
                        <%
            }
        }
    }
    if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
    {
        %>cn.Open();
                        <%
    }
    %>var args = new DataPortalHookArgs(cmd);
                        OnDeletePre(args);
                        cmd.ExecuteNonQuery();
                        OnDeletePost(args);
                    }
                }
            }
        }
<%
}
%>
