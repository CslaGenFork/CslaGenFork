<%
if (Info.GenerateDataPortalDelete &&
    CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    List<string> deletePartialMethods = new List<string>();
    List<string> deletePartialParams = new List<string>();
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.DeleteOptions.DataPortal)
        {
            %>

        /// <summary>
        /// Self delete the <see cref="<%= Info.ObjectName %>"/> object.
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
        /// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override void DataPortal_DeleteSelf(Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                strGetCritParams = "false, " + strGetCritParams;
            }
            if (c.Properties.Count > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && c.Properties.Count == 1))
            {
                %>
            DataPortal_Delete(new <%= c.Name %>(<%= strGetCritParams %>), handler);
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            DataPortal_Delete(<%= SendSingleCriteria(c, strGetCritParams) %>, handler);
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
        /// Delete the <see cref="<%= Info.ObjectName %>"/> object immediately.
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
            %>[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        <%
                deletePartialParams.Add("/// <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The delete criteria.</param>");
                if (c.Properties.Count > 1)
                {
                    deletePartialMethods.Add("partial void Service_Delete(" + c.Name + " crit);");
                    %>public void DataPortal_Delete(<%= c.Name %> crit, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
                }
                else
                {
                    deletePartialMethods.Add("partial void Service_Delete(" + ReceiveSingleCriteria(c, "crit") + ");");
                    %>public void DataPortal_Delete(<%= ReceiveSingleCriteria(c, "crit") %>, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
                }
                %>
        {
            try
            {
                <%
            if (c.Properties.Count > 1)
            {
                %>Service_Delete(crit);<%
            }
            else if (c.Properties.Count > 0)
            {
                %>Service_Delete(<%= HookSingleCriteria(c, "crit") %>);<%
            }
            else
            {
                %>Service_Delete();<%
            }
    %>
                handler(this, null);
            }
            catch (Exception ex)
            {
                handler(null, ex);
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

                %>
        }
            <%
            }
        }
    }
    for (int index = 0; index < deletePartialMethods.Count ; index++)
    {
        string header = deletePartialParams[index] + (string.IsNullOrEmpty(deletePartialParams[index]) ? "" : "\r\n        ");
        header += deletePartialMethods[index];
        Response.Write(Environment.NewLine);
        %>
        /// <summary>
        /// Implements <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_Delete()" : "DataPortal_Delete" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%= header %>
<%
    }
}
%>
