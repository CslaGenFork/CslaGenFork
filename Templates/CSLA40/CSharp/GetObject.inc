<%
if (!Info.UseCustomLoading)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.Factory)
        {
            %>

        /// <summary>
        /// Factory method. New <see cref="<%=Info.ObjectName%>"/> object is loaded from the database, based on given parameters.
        /// </summary>
        <%
            string strGetParams = string.Empty;
            string strGetCritParams = string.Empty;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                {
                    %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %>.</param>
        <%
                    if (i > 0)
                    {
                        strGetParams += ", ";
                        strGetCritParams += ", ";
                    }
                    strGetParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                    strGetCritParams += FormatCamel(c.Properties[i].Name);
                }
            }
            %>
        /// <returns>A reference to the fetched <see cref="<%=Info.ObjectName%>"/> object.</returns>
        public static <%= Info.ObjectName %> Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(<%= strGetParams %>)
        {
            <%
            if ((CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
                CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel) &&
                (Info.GetRoles.Trim() != String.Empty) ||
                (Info.DenyGetRoles.Trim() != String.Empty))
            {
                %>
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
            }
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                strGetCritParams = "false, " + strGetCritParams;
            }
            if (c.Properties.Count > 1)
            {
                %>
            return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Fetch<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strGetCritParams %>));
            <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Fetch<<%= Info.ObjectName %>>(new SingleCriteria<<%= GetDataTypeGeneric(c.Properties[0], c.Properties[0].PropertyType) %>>(<%= strGetCritParams %>));
            <%
            }
            else
            {
                %>
            return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Fetch<<%= Info.ObjectName %>>();
        <%
            }
            %>
        }
    <%
        }
    }
}
%>
