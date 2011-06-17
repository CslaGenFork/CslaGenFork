<%
if (UseSilverlight())
{
    if (Info.ObjectType == CslaObjectType.EditableRootCollection ||
        Info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
        Info.ObjectType == CslaObjectType.EditableChildCollection)
    {
        %>

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static void New<%= Info.ObjectName %>(EventHandler<DataPortalResult<<%= Info.ObjectName %>>> callback)
        {
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(callback, DataPortal.ProxyModes.LocalOnly);
        }
        <%
    }
    else
    {
        foreach (Criteria c in GetCriteriaObjects(Info))
        {
            if (c.CreateOptions.Factory &&
                (c.CreateOptions.RunLocal ||
                CurrentUnit.GenerationParams.SilverlightUsingServices))
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
                if (c.CreateOptions.RunLocal ||
                    CurrentUnit.GenerationParams.SilverlightUsingServices)
                {
                    strNewCallback += ", DataPortal.ProxyModes.LocalOnly";
                }
                else
                {
                    strNewCallback += ", DataPortal.ProxyModes.Auto";
                }
                strNewParams += (strNewParams.Length > 0 ? ", " : "") + "EventHandler<DataPortalResult<" + Info.ObjectName + ">> callback";
                %>

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> object<%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
        <%= strNewComment %>/// <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static void New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>(<%= strNewParams %>)
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
