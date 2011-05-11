<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
foreach (Criteria c in GetCriteriaObjects(Info))
{
    if (c.CreateOptions.Factory ||
        Info.ObjectType == CslaObjectType.EditableRootCollection ||
        Info.ObjectType == CslaObjectType.EditableChildCollection)
    {
        string strNewParams = string.Empty;
        string strNewCritParams = string.Empty;
        string strNewComment = string.Empty;
        for (int i = 0; i < c.Properties.Count; i++)
        {
            if (i > 0)
            {
                strNewParams += ", ";
                strNewCritParams += ", ";
            }
            strNewParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
            strNewCritParams += FormatCamel(c.Properties[i].Name);
            strNewComment += "/// <param name=\"" + FormatCamel(c.Properties[i].Name) + "\">The " + FormatProperty(c.Properties[i].Name) + " of the " + Info.ObjectName + " to create.</param>" + System.Environment.NewLine + new string(' ', 8);
        }

        if (Info.ObjectType == CslaObjectType.EditableRootCollection ||
            Info.ObjectType == CslaObjectType.EditableChildCollection)
        {
            %>

        /// <summary>
        /// Factory method. Creates a new <see cref="<%=Info.ObjectName%>"/> collection.
        /// </summary>
        <%= strNewComment %>/// <returns>A reference to the created <see cref="<%=Info.ObjectName%>"/> collection.</returns>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static <%=Info.ObjectName%> New<%=Info.ObjectName%>()
        {
            return new <%=Info.ObjectName%>();
        }
        <%
        }
        else
        {
            %>

        /// <summary>
        /// Factory method. Creates a new <see cref="<%=Info.ObjectName%>"/> <%= Info.ObjectType == CslaObjectType.UnitOfWork ? "unit of objects" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
        <%= strNewComment %>/// <returns>A reference to the created <see cref="<%=Info.ObjectName%>"/> <%= Info.ObjectType == CslaObjectType.UnitOfWork ? "unit of objects" : "object" %>.</returns>
        <%
            if (Info.ObjectType == CslaObjectType.EditableChild)
            {
                %>internal<% } else { %>public<% } %> static <%=Info.ObjectName%> New<%=Info.ObjectName%><%=c.CreateOptions.FactorySuffix%>(<%= strNewParams %>)
        {
            <%
            if (Info.ObjectType == CslaObjectType.EditableSwitchable)
            {
                if (strNewCritParams.Length > 0)
                {
                    strNewCritParams = "false, " + strNewCritParams;
                }
                else
                {
                    strNewCritParams = "false" ;
                }
            }
            if (c.Properties.Count > 1)
            {
                %>
            return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Create<%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child" : "" %><<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strNewCritParams %>));
                <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Create<%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child" : "" %><<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strNewCritParams) %>);
                    <%
            }
            else
            {
                %>
            return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Create<%= (Info.ObjectType == CslaObjectType.EditableChild) ? "Child" : "" %><<%= Info.ObjectName %>>();
                    <%
            }
            %>
        }
        <%
        }
    }
}
}
%>
