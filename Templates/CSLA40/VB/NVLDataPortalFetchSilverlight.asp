<%
if (!Info.UseCustomLoading &&
    CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    List<string> fetchPartialMethods = new List<string>();
    List<string> fetchPartialParams = new List<string>();
    string cacheRemarks = string.Empty;
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.GetOptions.DataPortal)
        {
            if (c.Properties.Count == 0 && Info.SimpleCacheOptions == SimpleCacheResults.DataPortal)
            {
                cacheRemarks += "/// <remarks>" + Environment.NewLine + new string(' ', 8);
                cacheRemarks += "/// DataPortal cache will be used whenever possible." + Environment.NewLine + new string(' ', 8);
                cacheRemarks += "/// </remarks>" + Environment.NewLine + new string(' ', 8);
            }
            %>

        /// <summary>
        /// Loads an existing <see cref="<%= Info.ObjectName %>"/> collection<%= c.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
                fetchPartialParams.Add("/// <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The fetch criteria.</param>");
                %>/// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The fetch criteria.</param>
        <%
            }
            else
            {
                fetchPartialParams.Add("");
            }
        %>/// <param name="handler">The asynchronous handler.</param>
        <%= cacheRemarks %>[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        <%
            if (c.Properties.Count > 1)
            {
                fetchPartialMethods.Add("partial void Service_Fetch(" + c.Name + " crit);");
                %>public void DataPortal_Fetch(<%= c.Name %> crit, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
            }
            else if (c.Properties.Count > 0)
            {
                fetchPartialMethods.Add("partial void Service_Fetch(" + ReceiveSingleCriteria(c, "crit") + ");");
                %>public void DataPortal_Fetch(<%= ReceiveSingleCriteria(c, "crit") %>, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
            }
            else
            {
                fetchPartialMethods.Add("partial void Service_Fetch();");
                %>public void DataPortal_Fetch(Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
            }
        %>
        {
            <%
            if (Info.SimpleCacheOptions == SimpleCacheResults.DataPortal && c.Properties.Count == 0)
            {
                %>
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            <%
            }
            %>
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
        }
<!-- #include file="SimpleCacheLoadCachedList.asp" -->
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
        /// Implements <%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child_Fetch()" : "DataPortal_Fetch" %> for <see cref="<%= Info.ObjectName %>"/> collection.
        /// </summary>
        <%= header %>
<%
    }
}
%>
