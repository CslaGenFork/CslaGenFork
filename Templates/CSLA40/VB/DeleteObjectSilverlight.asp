<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.DeleteOptions.Factory)
        {
            %>

        /// <summary>
        /// Asynchronously marks the <see cref="<%= Info.ObjectName %>"/> object for deletion.
        /// The object will be deleted as part of the next save operation.
        /// </summary>
<%
            string strDelParams = string.Empty;
            string strDelCritParams = string.Empty;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the <%= Info.ObjectName %> to delete.</param>
        <%
                if (i > 0)
                {
                    strDelParams += ", ";
                    strDelCritParams += ", ";
                }
                strDelParams += string.Concat(GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType), " ", FormatCamel(c.Properties[i].Name));
                strDelCritParams += FormatCamel(c.Properties[i].Name);
            }
            strDelParams += (strDelParams.Length > 0 ? ", " : "") + "EventHandler<DataPortalResult<" + Info.ObjectName + ">> callback";
            //strDelCritParams += (strDelCritParams.Length > 0 ? ", " : "") + "callback";
            %>
        /// <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static void Delete<%= Info.ObjectName %><%= c.DeleteOptions.FactorySuffix %>(<%= strDelParams %>)
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
                %>DataPortal.BeginDelete<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strDelCritParams %>), callback, DataPortal.ProxyModes.LocalOnly);<%
            }
            else if (c.Properties.Count > 0)
            {
                %>DataPortal.BeginDelete<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strDelCritParams) %>, callback, DataPortal.ProxyModes.LocalOnly);<%
            }
            else
            {
                %>DataPortal.BeginDelete(new <%= c.Name %>(callback, DataPortal.ProxyModes.LocalOnly);<%
            }
            %>
        }
<%
        }
    }
}
%>
