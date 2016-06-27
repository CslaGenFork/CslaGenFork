<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
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
    if (createCriteriaCount == 0 &&
        (Info.IsEditableRootCollection() ||
        Info.IsDynamicEditableRootCollection() ||
        Info.IsEditableChildCollection()))
    {
        if (runLocal == createGenerateLocal || CurrentUnit.GenerationParams.SilverlightUsingServices)
        {
            %>

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static void New<%= Info.ObjectName %>(EventHandler<DataPortalResult<<%= Info.ObjectName %>>> callback)
        {
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(callback);
        }
        <%
        }
    }
    else
    {
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (forceGeneration != null)
            {
                if (forceGeneration.Value)
                    createGenerateLocal = c.CreateOptions.RunLocal;
                else
                    createGenerateLocal = !c.CreateOptions.RunLocal;
            }
            if (c.CreateOptions.Factory && (createGenerateLocal == c.CreateOptions.RunLocal || useUnitOfWorkCreator))
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
                if (!useUnitOfWorkCreator)
                {
                    strNewCallback = (strNewCritParams.Length > 0 ? ", " : "") + "callback";
                }
                else
                {
                    strNewCallback = (strNewCritParams.Length > 0 ? ", " : "");
                }
                strNewParams += (strNewParams.Length > 0 ? ", " : "") + "EventHandler<DataPortalResult<" + Info.ObjectName + ">> callback";
                if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.IsNotEditableSwitchable())
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
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(crit, callback);
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
                if (Info.IsEditableSwitchable())
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
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strNewCritParams %>)<%= strNewCallback %>);
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
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strNewCritParams) %><%= strNewCallback %>);
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
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(<%= strNewCallback %>);
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
