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
        /// Self deletes the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
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
        /// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override void DataPortal_DeleteSelf(Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                strDeleteCritParams = "false, " + strDeleteCritParams;
            }
            if (c.Properties.Count > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && c.Properties.Count == 1))
            {
                %>
            DataPortal_Delete(new <%= c.Name %>(<%= strDeleteCritParams %>), handler);
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            DataPortal_Delete(<%= SendSingleCriteria(c, strDeleteCritParams) %>, handler);
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

        /// <summary>
        /// Deletes the <see cref="<%= Info.ObjectName %>"/> object immediately.
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
                deletePartialMethods.Add("partial void Service_Delete(" + c.Name + " crit)");
                %>public void DataPortal_Delete(<%= c.Name %> crit, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
            }
            else
            {
                deletePartialMethods.Add("partial void Service_Delete(" + ReceiveSingleCriteria(c, "crit") + ")");
                %>public void DataPortal_Delete(<%= ReceiveSingleCriteria(c, "crit") %>, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
            }
            %>
        {
            <%
            if (Info.GetMyChildProperties().Count > 0)
            {
                %>
<!-- #include file="UpdateChildProperties.asp" -->
            <%
            }
            %>
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
        }
        <%
        }
    }
    for (int index = 0; index < deletePartialMethods.Count ; index++)
    {
        string header = deletePartialParams[index] + (string.IsNullOrEmpty(deletePartialParams[index]) ? "" : "\r\n        ");
        header += deletePartialMethods[index];
        MethodList.Add(header);
        %>

        /// <summary>
        /// Implements <%= isChild ? "Child_Delete" : "DataPortal_Delete" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%= header %>;
<%
    }
}
%>
