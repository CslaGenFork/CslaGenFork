<%
if (Info.GenerateDataPortalDelete)
{
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.DeleteOptions.DataPortal)
        {
            if (string.IsNullOrEmpty(c.DeleteOptions.ProcedureName))
            {
                Errors.Append("Criteria " + c.Name + " missing delete procedure name." + Environment.NewLine);
            }
            %>

        /// <summary>
        /// Self deletes the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
            if (c.DeleteOptions.RunLocal)
            {
                %>[Csla.RunLocal]
        <%
            }
            string strDeleteCritParams = string.Empty;
            bool firstParam = true;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (firstParam)
                {
                    firstParam = false;
                }
                else
                {
                    strDeleteCritParams += ", ";
                }
                strDeleteCritParams += c.Properties[i].Name;
            }
            %>
        protected override void DataPortal_DeleteSelf()
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                strDeleteCritParams = "false, " + strDeleteCritParams;
            }
            if (c.Properties.Count > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && c.Properties.Count == 1))
            {
                %>
            DataPortal_Delete(new <%= c.Name %>(<%= strDeleteCritParams %>));
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            DataPortal_Delete(<%= SendSingleCriteria(c, strDeleteCritParams) %>);
        <%
            }
            else
            {
                %>
            DataPortal_Delete();
        <%
            }
            %>
        }
        <%
            if (Info.ObjectType != CslaObjectType.DynamicEditableRoot)
            {
                %>

        /// <summary>
        /// Deletes the <see cref="<%= Info.ObjectName %>"/> unit of objects from database.
        /// </summary>
        /// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The delete criteria.</param>
        <%
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
                if (c.DeleteOptions.RunLocal)
                {
        %>[Csla.RunLocal]<%
                }
                if (c.Properties.Count > 1)
                {
        %>protected void DataPortal_Delete(<%= c.Name %> crit)<%
                }
                else
                {
        %>protected void DataPortal_Delete(<%= ReceiveSingleCriteria(c, "crit") %>)<%
                }
            %>
        {
            <%
                if (UseSimpleAuditTrail(Info))
                {
                    %>// audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            <%
                }
                %>
            <%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, c.DeleteOptions.ProcedureName) %>
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
                foreach (Property p in c.Properties)
                {
                    %>
                    <%
                    if (c.Properties.Count > 1)
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;<%
                    }
                    else
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %><%= (p.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TypeHelper.GetDbType(p.PropertyType) %>;
                    <%
                    }
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
                    var args = new DataPortalHookArgs(cmd<%= hookArgs %>);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
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
            <%
            }
        }
    }
}
%>
