<%
if (Info.GenerateDataPortalDelete)
{
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.DeleteOptions.DataPortal)
        {
            %>

        /// <summary>
        /// Self delete the <see cref="<%=Info.ObjectName%>"/> object.
        /// </summary>
        <%
            string strGetCritParams = string.Empty;
            bool firstParam = true;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (firstParam)
                {
                    firstParam = false;
                }
                else
                {
                    strGetCritParams += ", ";
                }
                strGetCritParams += c.Properties[i].Name;
            }
            %>
        protected override void DataPortal_DeleteSelf()
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                strGetCritParams = "false, " + strGetCritParams;
            }
            if (c.Properties.Count > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && c.Properties.Count == 1))
            {
                %>
            DataPortal_Delete(new <%= c.Name %>(<%= strGetCritParams %>));
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            DataPortal_Delete(<%= SendSingleCriteria(c, strGetCritParams) %>);
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
        /// Delete the <see cref="<%=Info.ObjectName%>"/> object from database immediately.
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
                %><%= GetConnection(Info, false) %>
            {
                <%
                if (string.IsNullOrEmpty(c.DeleteOptions.ProcedureName))
                {
                    Errors.Append("Criteria " + c.Name + " missing delete procedure name." + Environment.NewLine);
                }
                %>
                <%= GetCommand(Info, c.DeleteOptions.ProcedureName) %>
                {
                <%
                if (Info.TransactionType == TransactionType.ADO && Info.PersistenceType == PersistenceType.SqlConnectionManager)
                {
                    %>
                    cmd.Transaction = ctx.Transaction;

                    <%
                }
                %>
                    cmd.CommandType = CommandType.StoredProcedure;
                    <%
                foreach (Property p in c.Properties)
                {
                    %>
                    <%
                    if (c.Properties.Count > 1)
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p, true) %>);<%
                    }
                    else
                    {
                        %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= AssignSingleCriteria(c, "crit") %>);
                    <%
                    }
                }
                if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
                {
                    %>
                    cn.Open();
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
                    var args = new DataPortalHookArgs(cmd<%= hookArgs %>);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
                <%
                //if (CurrentUnit.GenerationParams.UseChildDataPortal)
                if (true)
                {
                    if (Info.GetCollectionChildProperties().Count > 0 || Info.GetNonCollectionChildProperties().Count > 0)
                    {
                        %>

                FieldManager.UpdateChildren(this);
                <%
                    }
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
