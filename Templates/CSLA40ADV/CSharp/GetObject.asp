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
            bool firstParam = true;
            bool isCriteriaClassNeeded = IsCriteriaClassNeeded(Info);
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                {
                    %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %>.</param>
        <%
                    if (firstParam)
                    {
                        firstParam = false;
                    }
                    else
                    {
                        strGetParams += ", ";
                        strGetCritParams += ", ";
                    }
                    strGetParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                    strGetCritParams += FormatCamel(c.Properties[i].Name);
                }
                else
                {
                    if (!isCriteriaClassNeeded)
                        strGetCritParams += c.Properties[i].ParameterValue;
                }
            }
            %>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static <%= Info.ObjectName %> Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(<%= strGetParams %>)
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                strGetCritParams = "false, " + strGetCritParams;
            }
            if (c.Properties.Count > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && c.Properties.Count == 1))
            {
                %>
            return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Fetch<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strGetCritParams %>));
            <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Fetch<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strGetCritParams) %>);
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
