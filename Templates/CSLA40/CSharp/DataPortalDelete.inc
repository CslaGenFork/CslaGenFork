<%
int deleteCount = 0;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.DeleteOptions.DataPortal)
    {
        deleteCount++;
        //This is kind of weak, because this will generate only for the first delete criteria,
        //but it's unlikely anyone will have more than one delete criteria.
        if (deleteCount == 1)
        {
            %>

        /// <summary>
        /// Self delete the <see cref="<%=Info.ObjectName%>"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<<%= GetDataTypeGeneric(c.Properties[0], c.Properties[0].PropertyType) %>>(<%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                Response.Write("false, ");
            }
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (i > 0)
                {
                        %>, <%
                }
                    %><%= GetFieldReaderStatement(Info, c.Properties[0].Name) %><%
            }
            %>));
        }
        <%
        }
        if (Info.ObjectType != CslaObjectType.DynamicEditableRoot)
        {
            %>

        /// <summary>
        /// Delete the <see cref="<%=Info.ObjectName%>"/> object from database immediately.
        /// </summary>
        /// <param name="crit">The delete criteria.</param>
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
        %>protected void DataPortal_Delete(SingleCriteria<<%= GetDataTypeGeneric(c.Properties[0], c.Properties[0].PropertyType) %>> crit)<%
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
            if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared)
            {
                %>
                    cn.Open();
                    <%
            }
            foreach (Property p in c.Properties)
            {
                %>
                    <%
                if (c.Properties.Count > 1)
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p,true) %>);<%
                }
                else
                {
                    %>cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", crit.Value);<%
                }
            }
            %>
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
                <%
            if (CurrentUnit.GenerationParams.UseChildDataPortal)
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
%>

