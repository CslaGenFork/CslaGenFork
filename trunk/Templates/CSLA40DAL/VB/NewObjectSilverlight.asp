<%
if (UseSilverlight())
{
    int createCriteriaCount = 0;
    bool runLocal = true;
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.CreateOptions.Factory)
        {
            runLocal = c.CreateOptions.RunLocal;
            createCriteriaCount ++;
        }
    }
    if (createCriteriaCount == 0 && runLocal &&
        (Info.ObjectType == CslaObjectType.EditableRootCollection ||
        Info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
        Info.ObjectType == CslaObjectType.EditableChildCollection))
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
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.CreateOptions.Factory &&
                (CurrentUnit.GenerationParams.SilverlightUsingServices ||
                (CurrentUnit.GenerationParams.GenerateSilverlight4 && c.CreateOptions.RunLocal)))
            {
                string strNewParams = string.Empty;
                string strNewCritParams = string.Empty;
                string strNewComment = string.Empty;
                string strNewCallback = string.Empty;
                /*string strNewProxyMode = string.Empty;*/
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
                if (!useUnitOfWorkCreator)
                {
                    strNewCallback = (strNewCritParams.Length > 0 ? ", " : "") + "callback";
                    /*if (c.CreateOptions.RunLocal ||
                        CurrentUnit.GenerationParams.SilverlightUsingServices)
                    {
                        strNewProxyMode = "DataPortal.ProxyModes.LocalOnly";
                    }
                    else
                    {
                        strNewProxyMode = "DataPortal.ProxyModes.Auto";
                    }*/
                }
                else
                {
                    strNewCallback = (strNewCritParams.Length > 0 ? ", " : "");
                }
                strNewParams += (strNewParams.Length > 0 ? ", " : "") + "EventHandler<DataPortalResult<" + Info.ObjectName + ">> callback";
                if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.ObjectType != CslaObjectType.EditableSwitchable)
                {
                    %>

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %>, based on given parameters.
        /// </summary>
        /// <param name="crit">The create criteria.</param>
        /// <param name="callback">The completion callback method.</param>
        public static <%= Info.ObjectName %> New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>(<%= c.Name %> crit, EventHandler<DataPortalResult<<%= Info.ObjectName %>>> callback)
        {
            <%
                    if (!useUnitOfWorkCreator)
                    {
                        %>
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(crit, callback, DataPortal.ProxyModes.LocalOnly);
        <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.New<%= Info.UseUnitOfWorkType %>(crit, (o, e) =>
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
        /// Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
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
                    if (!useUnitOfWorkCreator)
                    {
                        %>
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strNewCritParams %>)<%= strNewCallback %>, DataPortal.ProxyModes.LocalOnly);
                <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.New<%= Info.UseUnitOfWorkType %>(<%= strNewCritParams %><%= strNewCallback %>(o, e) =>
            {
                callback(o, new DataPortalResult<<%= Info.ObjectName %>>(e.Object.<%= Info.ObjectName %>, e.Error, null));
            });
            <%
                    }
                }
                else if (c.Properties.Count > 0)
                {
                    if (!useUnitOfWorkCreator)
                    {
                        %>
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strNewCritParams) %><%= strNewCallback %>, DataPortal.ProxyModes.LocalOnly);
                    <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.New<%= Info.UseUnitOfWorkType %>(<%= SendSingleCriteria(c, strNewCritParams) %><%= strNewCallback %>(o, e) =>
            {
                callback(o, new DataPortalResult<<%= Info.ObjectName %>>(e.Object.<%= Info.ObjectName %>, e.Error, null));
            });
            <%
                    }
                }
                else
                {
                    if (!useUnitOfWorkCreator)
                    {
                        %>
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(<%= strNewCallback %>, DataPortal.ProxyModes.LocalOnly);
                    <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.New<%= Info.UseUnitOfWorkType %>(<%= strNewCallback %>(o, e) =>
            {
                callback(o, new DataPortalResult<<%= Info.ObjectName %>>(e.Object.<%= Info.ObjectName %>, e.Error, null));
            });
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
