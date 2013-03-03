<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.Factory)
        {
            if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.ObjectType != CslaObjectType.EditableSwitchable)
            {
                %>

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> <%= IsCollectionType(Info.ObjectType) ? "collection" : "object" %>, based on given parameters.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(<%= c.Name %> crit, EventHandler<DataPortalResult<<%= Info.ObjectName %>>> callback)
        {
            <%
                if (Info.UseUnitOfWorkType == string.Empty)
                {
                    %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(crit, callback, DataPortal.ProxyModes.LocalOnly);
        <%
                }
                else
                {
                    %>
            <%= Info.UseUnitOfWorkType %>.Get<%= Info.UseUnitOfWorkType %>(crit, (o, e) =>
            {
                callback(o, new DataPortalResult<<%= Info.ObjectName %>>(e.Object.<%= Info.ObjectName %>, e.Error, null));
            });
            <%
                }
                %>
        }
        <%
            }
            %>

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> <%= IsCollectionType(Info.ObjectType) ? "collection" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
        <%
            string strGetParams = string.Empty;
            string strGetCritParams = string.Empty;
            bool firstParam = true;
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
                if (Info.UseUnitOfWorkType == string.Empty)
                {
                    %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strGetCritParams %>), callback, DataPortal.ProxyModes.LocalOnly);
            <%
                }
                else
                {
                    %>
            <%= Info.UseUnitOfWorkType %>.Get<%= Info.UseUnitOfWorkType %>(new <%= c.Name %>(<%= strGetCritParams %>), (o, e) =>
            {
                callback(o, new DataPortalResult<<%= Info.ObjectName %>>(e.Object.<%= Info.ObjectName %>, e.Error, null));
            });
            <%
                }
            }
            else if (c.Properties.Count > 0)
            {
                if (Info.UseUnitOfWorkType == string.Empty)
                {
                    %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strGetCritParams) %>, callback, DataPortal.ProxyModes.LocalOnly);
            <%
                }
                else
                {
                    %>
            <%= Info.UseUnitOfWorkType %>.Get<%= Info.UseUnitOfWorkType %>(<%= SendSingleCriteria(c, strGetCritParams) %>, (o, e) =>
            {
                callback(o, new DataPortalResult<<%= Info.ObjectName %>>(e.Object.<%= Info.ObjectName %>, e.Error, null));
            });
            <%
                }
            }
            else
            {
                if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                {
                    %>
            if (_list == null)
                DataPortal.BeginFetch<<%= Info.ObjectName %>>((o, e) =>
                {
                    _list = e.Object;
                    callback(o, e);
                }, DataPortal.ProxyModes.LocalOnly);
            else
                callback(null, new DataPortalResult<<%= Info.ObjectName %>>(_list, null, null));
        <%
                }
                else
                {
                    if (Info.UseUnitOfWorkType == string.Empty)
                    {
                        %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(callback, DataPortal.ProxyModes.LocalOnly);
        <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.Get<%= Info.UseUnitOfWorkType %>((o, e) =>
            {
                callback(o, new DataPortalResult<<%= Info.ObjectName %>>(e.Object.<%= Info.ObjectName %>, e.Error, null));
            });
            <%
                    }
                }
            }
            %>
        }
<%
        }
    }
}
%>
