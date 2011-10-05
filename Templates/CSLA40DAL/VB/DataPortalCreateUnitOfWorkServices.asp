<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    List<string> createPartialMethods = new List<string>();
    List<string> createPartialParams = new List<string>();
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        Criteria crit = GetCriteriaObjects(Info)[0];
        if (c.CreateOptions.DataPortal)
        {
            %>

        /// <summary>
        /// Loads a new <see cref="<%= Info.ObjectName %>"/> unit of objects<%= crit.Properties.Count > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%
            if (c.Properties.Count > 0)
            {
                createPartialParams.Add("/// <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The create criteria.</param>");
                %>/// <param name="<%= c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit") %>">The create criteria.</param>
        <%
            }
            else
            {
                createPartialParams.Add("");
            }
        %>/// <param name="handler">The asynchronous handler.</param>
        /// <remarks>
        /// ReadOnlyBase&lt;T&gt; doesn't allow the use of DataPortal_Create and thus DataPortal_Fetch is used.
        /// </remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        <%
            if (c.Properties.Count > 1)
            {
                createPartialMethods.Add("partial void Service_Create(" + c.Name + " crit)");
                %>public void DataPortal_Fetch(<%= c.Name %> crit, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
            }
            else if (c.Properties.Count > 0)
            {
                createPartialMethods.Add("partial void Service_Create(" + ReceiveSingleCriteria(c, "crit") + ")");
                %>public void DataPortal_Fetch(<%= ReceiveSingleCriteria(c, "crit") %>, Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
            }
            else
            {
                createPartialMethods.Add("partial void Service_Create()");
                %>public void DataPortal_Fetch(Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)<%
            }
        %>
        {
            try
            {
                <%
            if (c.Properties.Count > 1)
            {
                %>Service_Create(crit);<%
            }
            else if (c.Properties.Count > 0)
            {
                %>Service_Create(<%= HookSingleCriteria(c, "crit") %>);<%
            }
            else
            {
                %>Service_Create();<%
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
    for (int index = 0; index < createPartialMethods.Count ; index++)
    {
        string header = createPartialParams[index] + (string.IsNullOrEmpty(createPartialParams[index]) ? "" : "\r\n        ");
        header += createPartialMethods[index];
        MethodList.Add(header);
        %>

        /// <summary>
        /// Implements DataPortal_Fetch for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        /// <remarks>
        /// ReadOnlyBase&lt;T&gt; doesn't allow the use of DataPortal_Create and thus DataPortal_Fetch is used.
        /// </remarks>
        <%= header %>;
<%
    }
}
%>
