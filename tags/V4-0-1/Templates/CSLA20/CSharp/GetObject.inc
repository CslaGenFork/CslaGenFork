<% if (!Info.UseCustomLoading) {
    foreach (Criteria c in Info.CriteriaObjects) {
        if (c.GetOptions.Factory) { %>

        /// <summary>
        /// Factory method. New <see cref="<%=Info.ObjectName%>" /> Object is loaded from the database, based on given parameters.
        /// </summary>
        <%
        string strGetParams = string.Empty;
        string strGetCritParams = string.Empty;
        for (int i = 0; i < c.Properties.Count; i++)
        {
            if (i > 0) {
                strGetParams += ", ";
                strGetCritParams += ", ";
            }
            strGetParams += string.Concat(GetDataType(c.Properties[i]), " ", FormatCamel(c.Properties[i].Name));
            strGetCritParams += FormatCamel(c.Properties[i].Name);
        }
        %>
        public static <%=Info.ObjectName%> Get<%=Info.ObjectName%><%=c.GetOptions.FactorySuffix.Trim()%>(<%=strGetParams%>)
        {
            <% if (Info.GetRoles.Trim() != string.Empty) { %>
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>");
            <% } %>
            <% if (Info.ObjectType == CslaObjectType.EditableSwitchable) {
                strGetCritParams = "false, " + strGetCritParams;
            } %>
            return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Fetch<<%=Info.ObjectName %>>(new <%=c.Name%>(<%=strGetCritParams %>));
        }
<%        }
    }
} %>
