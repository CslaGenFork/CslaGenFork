<%
if (!Info.UseCustomLoading && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    List<string> fetchPartialMethods = new List<string>();
    List<string> fetchPartialParams = new List<string>();
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.DataPortal)
        {
            string strGetComment = string.Empty;
            bool getIsFirst = true;

            foreach (CriteriaProperty p in c.Properties)
            {
                if (!getIsFirst)
                {
                    strGetComment += System.Environment.NewLine + new string(' ', 8);
                }
                else
                    getIsFirst = false;

                strGetComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
            }
            if (c.Properties.Count > 1)
                strGetComment = "/// <param name=\"crit\">The fetch criteria.</param>";
            %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> <%= IsCollectionType(Info.ObjectType) ? "collection" : "object" %><%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
                fetchPartialParams.Add("/// <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The fetch criteria.</param>");
        %>
        <%= strGetComment %>
        <%
            }
            else
            {
                fetchPartialParams.Add("");
            }
            %>
        /// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        <%
            if (c.Properties.Count > 1)
            {
                fetchPartialMethods.Add("partial void Service_Fetch(" + c.Name + " crit)");
                %>
        public void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= c.Name %> crit, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        <%
            }
            else if (c.Properties.Count > 0)
            {
                fetchPartialMethods.Add("partial void Service_Fetch(" + ReceiveSingleCriteria(c, "crit") + ")");
                %>
        public void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(<%= ReceiveSingleCriteria(c, "crit") %>, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        <%
            }
            else
            {
                fetchPartialMethods.Add("partial void Service_Fetch()");
                %>
        public void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Fetch(Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        <%
            }
        %>
        {
            try
            {
                <%
            if (c.Properties.Count > 1)
            {
                %>
                Service_Fetch(crit);
                <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
                Service_Fetch(<%= HookSingleCriteria(c, "crit") %>);
                <%
            }
            else
            {
                %>
                Service_Fetch();
                <%
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
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Fetch" : "DataPortal_Fetch", header));
        %>

        /// <summary>
        /// Implements <%= isChildNotLazyLoaded ? "Child_Fetch" : "DataPortal_Fetch" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%= header %>;
<%
    }
}
%>
