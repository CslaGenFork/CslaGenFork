<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    if (!Info.UseCustomLoading)
    {
        foreach (Criteria c in GetCriteriaObjects(Info))
        {
            if (Info.ObjectType == CslaObjectType.UnitOfWork && Info.IsCreatorGetter && c.Properties.Count == 0)
                continue;
            if (c.GetOptions.Factory)
            {
                %>

        /// <summary>
        /// Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> <%= Info.ObjectType == CslaObjectType.UnitOfWork ? "unit of objects" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
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
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> parameter of the <%= Info.ObjectName %> to fetch.</param>
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
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> <%= Info.ObjectType == CslaObjectType.UnitOfWork ? "unit of objects" : "object" %>.</returns>
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
            return DataPortal.Fetch<%= isChild ? "Child" : "" %><<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strGetCritParams %>));
            <%
                }
                else if (c.Properties.Count > 0)
                {
                    %>
            return DataPortal.Fetch<%= isChild ? "Child" : "" %><<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strGetCritParams) %>);
            <%
                }
                else
                {
                    if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                    {
                        %>
            if (_list == null)
                _list = DataPortal.Fetch<%= isChild ? "Child" : "" %><<%= Info.ObjectName %>>();

            return _list;
            <%
                    }
                    else
                    {
                        %>
            return DataPortal.Fetch<%= isChild ? "Child" : "" %><<%= Info.ObjectName %>>();
        <%
                    }
                }
                %>
        }
<%
            }
        }
    }
}
%>
