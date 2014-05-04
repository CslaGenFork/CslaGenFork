<%
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
if (Info.GenerateDataPortalDelete)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.DataPortal)
        {
            %>

        ''' <summary>
        ''' Self deletes the <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
            if (c.DeleteOptions.RunLocal)
            {
                %><Csla.RunLocal()>
        <%
            }
            string strDeleteCritParams = string.Empty;
            bool firstParam = true;
            foreach (CriteriaProperty p in c.Properties)
            {
                if (firstParam)
                {
                    firstParam = false;
                }
                else
                {
                    strDeleteCritParams += ", ";
                }
                strDeleteCritParams += FormatGeneralParameter(Info, p, false, false, true);
            }
            %>Protected Overrides Sub DataPortal_DeleteSelf()
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                strDeleteCritParams = "False, " + strDeleteCritParams;
            }
            if (c.Properties.Count > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && c.Properties.Count == 1))
            {
                %>
            DataPortal_Delete(New <%= c.Name %>(<%= strDeleteCritParams %>))
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            DataPortal_Delete(<%= SendSingleCriteria(c, strDeleteCritParams) %>)
        <%
            }
            else
            {
                %>
            DataPortal_Delete()
        <%
            }
            %>
        End Sub

        ''' <summary>
        ''' Deletes the <see cref="<%= Info.ObjectName %>"/> object from database.
        ''' </summary>
        ''' <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The delete criteria.</param>
        <%
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
            if (c.DeleteOptions.RunLocal)
            {
            %><Csla.RunLocal()>
        <%
            }
            if (c.Properties.Count > 1)
            {
                lastCriteria = "crit";
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.DeleteOptions.ProcedureName, c.Name + " crit"));
                %>Protected Sub DataPortal_Delete(crit As <%= c.Name %>)<%
            }
            else
            {
                lastCriteria = ReceiveSingleCriteriaTypeless(c, "crit");
                if (useInlineQuery)
                    InlineQueryList.Add(new AdvancedGenerator.InlineQuery(c.DeleteOptions.ProcedureName, ReceiveSingleCriteria(c, "crit")));
                %>Protected Sub DataPortal_Delete(<%= ReceiveSingleCriteria(c, "crit") %>)<%
            }
            %>
            <%
            if (UseSimpleAuditTrail(Info))
            {
                %>' audit the object, just in case soft delete is used on this object
            SimpleAuditTrail()
            <%
            }
            %><%= GetConnection(Info, false) %>
                <%
            if (Info.GetMyChildProperties().Count > 0)
            {
                string ucpSpacer = new string(' ', 4);
                %>
<!-- #include file="UpdateChildProperties.asp" -->
                <%
            }
            %>
                <%= GetCommand(Info, c.DeleteOptions.ProcedureName, useInlineQuery, lastCriteria) %>
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
            foreach (CriteriaProperty p in c.Properties)
            {
                if (c.Properties.Count > 1)
                {
                    %>
                    cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= GetDbType(p) %>
                    <%
                }
                else
                {
                    %>
                    cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= GetDbType(p) %>
                    <%
                }
            }
            if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
            {
                %>
                    cn.Open()
                    <%
            }
            string hookArgs = string.Empty;
            if (c.Properties.Count > 1)
            {
                hookArgs = ", crit";
            }
            else if (c.Properties.Count > 0)
            {
                hookArgs = ", " + HookSingleCriteria(c, "crit");
            }
            %>
                    Dim args As New DataPortalHookArgs(cmd<%= hookArgs %>)
                    OnDeletePre(args)
                    cmd.ExecuteNonQuery()
                    OnDeletePost(args)
                End Using
                <%
            if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
            {
                %>
                ctx.Commit()
                <%
            }
            %>
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
    }
}
%>
