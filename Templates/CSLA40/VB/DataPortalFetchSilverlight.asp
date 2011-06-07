<%
if (SilverlightUsingServices())
{
    List<string> fetchPartialMethods = new List<string>();
    List<string> fetchPartialParams = new List<string>();
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.GetOptions.DataPortal)
        {
            %>

        /// <summary>
        /// Loads an existing <see cref="<%=Info.ObjectName%>"/> object<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
                fetchPartialParams.Add("/// <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The fetch criteria.</param>");
                %>/// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        <%
            }
            if (c.Properties.Count > 1)
            {
                fetchPartialMethods.Add("partial void Service_Fetch(" + c.Name + " crit);");
                %>/// <param name="handler">The asynchronous handler.</param>
        public void <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit, Csla.DataPortalClient.LocalProxy<<%=Info.ObjectName%>>.CompletedHandler handler)<%
            }
            else if (c.Properties.Count > 0)
            {
                fetchPartialMethods.Add("partial void Service_Fetch(" + ReceiveSingleCriteria(c, "crit") + ");");
                %>/// <param name="handler">The asynchronous handler.</param>
        public void <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>, Csla.DataPortalClient.LocalProxy<<%=Info.ObjectName%>>.CompletedHandler handler)<%
            }
            else
            {
                fetchPartialMethods.Add("partial void Service_Fetch();");
                %>/// <param name="handler">The asynchronous handler.</param>
        public void <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_" : "DataPortal_" %>Fetch(Csla.DataPortalClient.LocalProxy<<%=Info.ObjectName%>>.CompletedHandler handler)<%
            }
        %>
        {
            try
            {
                <%
            if (c.Properties.Count > 1)
            {
                %>Service_Fetch(crit);<%
            }
            else if (c.Properties.Count > 0)
            {
                %>Service_Fetch(<%= HookSingleCriteria(c, "crit") %>);<%
            }
            else
            {
                %>Service_Fetch();<%
            }
    %>
                handler(this, null);
            }
            catch (Exception ex)
            {
                handler(null, ex);
            }
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                %>
            if (crit.IsChild)
                MarkAsChild();
            <%
            }
        %>
        }
        <%
        }
    }
    for (int index = 0; index < fetchPartialMethods.Count ; index++)
    {
        string header = fetchPartialParams[index] + (string.IsNullOrEmpty(fetchPartialParams[index]) ? "" : "\r\n        ");
        header += fetchPartialMethods[index];
        Response.Write(Environment.NewLine);
        %>
        /// <summary>
        /// Implements <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_Fetch()" : "DataPortal_Fetch" %> for <see cref="<%=Info.ObjectName%>"/> object.
        /// </summary>
        <%= header %>
<%
    }
}
%>
