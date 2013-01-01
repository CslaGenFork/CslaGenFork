<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.Factory)
        {
            %>

        /// <summary>
        /// Factory method. Asynchronously deletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
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
            if (isUndeletable == true)
            {
                %>

        /// <summary>
        /// Factory method. Asynchronously undeletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        /// </summary>
<%
                strDelParams = string.Empty;
                strDelCritParams = string.Empty;
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the <%= Info.ObjectName %> to undelete.</param>
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
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static void Undelete<%= Info.ObjectName %><%= c.DeleteOptions.FactorySuffix %>(<%= strDelParams %>)
        {
            var obj = new <%= Info.ObjectName %>();
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
                    %>DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= strDelCritParams %>, (o, e) =><%
                }
                else if (c.Properties.Count > 0)
                {
                    %>DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strDelCritParams) %>, (o, e) =><%
                }
            %>
                {
                    if (e.Error != null)
                        throw e.Error;
                    else
                        obj = e.Object;
                }, DataPortal.ProxyModes.LocalOnly);
            obj.<%= softDeleteProperty %> = true;
            obj.BeginSave(callback);
        }
<%
            }
        }
    }
}
%>
