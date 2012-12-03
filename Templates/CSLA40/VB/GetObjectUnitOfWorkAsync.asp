<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous || CurrentUnit.GenerationParams.GenerateSilverlight4)
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
        /// Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
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
                strGetParams += (strGetParams.Length > 0 ? ", " : "") + "EventHandler<DataPortalResult<" + Info.ObjectName + ">> callback";
                string strGetCache = string.Empty;
                foreach (UnitOfWorkProperty prop in Info.UnitOfWorkProperties)
                {
                    CslaObjectInfo objectInfo = Info.Parent.CslaObjects.Find(prop.TypeName);
                    if (objectInfo.SimpleCacheOptions != SimpleCacheResults.None)
                    {
                        strGetCache += "                if (!" + prop.TypeName + ".IsCached)" + Environment.NewLine;
                        strGetCache += "                    " + prop.TypeName + ".SetCache(e.Object." + prop.TypeName + ");" + Environment.NewLine;
                    }
                }
                %>
        /// <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static void Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(<%= strGetParams %>)
        {
            <%
                if (Info.ObjectType == CslaObjectType.EditableSwitchable)
                {
                    strGetCritParams = "false, " + strGetCritParams;
                }
                if (c.Properties.Count > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && c.Properties.Count == 1))
                {
                    %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strGetCritParams %>), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
<%= strGetCache %>                callback(o, e);
            });
            <%
                }
                else if (c.Properties.Count > 0)
                {
                    %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strGetCritParams) %>, (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
<%= strGetCache %>                callback(o, e);
            });
            <%
                }
                else
                {
                    %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>((o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
<%= strGetCache %>                callback(o, e);
            });
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
