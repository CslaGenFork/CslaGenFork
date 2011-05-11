<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
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
        string strNewCallback = string.Empty;
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
        strNewCallback = (strNewCritParams.Length > 0 ? ", " : "") + "callback";
        strNewParams += (strNewParams.Length > 0 ? ", " : "") + "EventHandler<DataPortalResult<" + Info.ObjectName + ">> callback";
        if (Info.ObjectType == CslaObjectType.EditableRootCollection ||
            Info.ObjectType == CslaObjectType.EditableChildCollection)
        {
            %>

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="<%=Info.ObjectName%>"/> collection.
        /// </summary>
        <%= strNewComment %>/// <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static void New<%=Info.ObjectName%><%=c.CreateOptions.FactorySuffix%>(<%= strNewParams %>)
        {
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(<%= strNewCritParams %><%= strNewCallback %>);
        }
        <%
        }
        else
        {
            %>

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="<%=Info.ObjectName%>"/> <%= Info.ObjectType == CslaObjectType.UnitOfWork ? "unit of objects" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
        <%= strNewComment %>/// <param name="callback">The completion callback method.</param>
        <%
            if (Info.ObjectType == CslaObjectType.EditableChild)
            {
                %>internal<% } else { %>public<% } %> static void New<%=Info.ObjectName%><%=c.CreateOptions.FactorySuffix%>(<%= strNewParams %>)
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
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strNewCritParams %>)<%= strNewCallback %>);
                <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strNewCritParams) %><%= strNewCallback %>);
                    <%
            }
            else
            {
                %>
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(<%= strNewCallback %>);
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
