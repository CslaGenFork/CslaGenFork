<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
foreach (Criteria c in GetCriteriaObjects(Info))
{
    if (c.DeleteOptions.Factory)
    {
        %>

        /// <summary>
        /// Marks the <see cref="<%=Info.ObjectName%>"/> object for deletion.
        /// The object will be deleted as part of the next save operation.
        /// </summary>
<%
        string strDelParams = string.Empty;
        string strDelCritParams = string.Empty;
        string UpdateEventString_Delete = string.Empty;
        for (int i = 0; i < c.Properties.Count; i++)
        {
            %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the <%=Info.ObjectName%> to delete.</param>
        <%
            if (i > 0)
            {
                strDelParams += ", ";
                strDelCritParams += ", ";
            }
            strDelParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
            strDelCritParams += FormatCamel(c.Properties[i].Name);
        }
        if (c.Properties.Count > 1)
            UpdateEventString_Delete = "new object() {" + strDelCritParams + "}";
        else
            UpdateEventString_Delete = strDelCritParams;
        %>
        public static void Delete<%= Info.ObjectName %><%= c.DeleteOptions.FactorySuffix %>(<%= strDelParams %>)
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                if (!strDelCritParams.Equals(String.Empty))
                {
                    strDelCritParams = ", " + strDelCritParams;
                }
                strDelCritParams = "false" + strDelCritParams;
            }
            if (c.Properties.Count > 1)
            {
                if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Delete<<%= Info.ObjectName %>>(new <%= c.Name %>(<%=strDelCritParams %>));<%
            }
            else if (c.Properties.Count > 0)
            {
                if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Delete<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strDelCritParams) %>);<%
            }
            else
            {
                if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Delete(new <%= c.Name %>(<%=strDelCritParams %>));<%
            }
            if (ActiveObjects)
            {
                if (Info.PublishToChannel.Length > 0)
                {
                    %>
            Observer.EventChannels.Publish("<%= Info.PublishToChannel %>", null, BusinessEvents.Deleted, <%= UpdateEventString_Delete %>);<%
                }
            }
            %>
        }
<%
    }
}
}
%>
