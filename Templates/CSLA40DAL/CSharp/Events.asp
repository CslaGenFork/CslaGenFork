
        #region Pseudo Events
<%
System.Collections.Generic.List<string> eventList = GetEventList(Info);
foreach (string strEvent in eventList)
{
    %>

        /// <summary>
        /// Occurs <%= FormatEventDocumentation(strEvent) %>
        /// </summary>
        partial void On<%= strEvent %>(DataPortalHookArgs args);
        <%
}
%>

        #endregion
