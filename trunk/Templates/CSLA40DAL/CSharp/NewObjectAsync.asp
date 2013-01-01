<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
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
            DataPortal.BeginCreate<<%= Info.ObjectName %>>(callback);
        }
        <%
    }
    else
    {
        foreach (Criteria c in Info.CriteriaObjects)
        {
            if (c.CreateOptions.Factory)
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
                if (Info.UseUnitOfWorkType == string.Empty)
                {
                    strNewCallback = (strNewCritParams.Length > 0 ? ", " : "") + "callback";
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
        /// Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        /// </summary>
        /// <param name="crit">The fetch criteria.</param>
        /// <param name="callback">The completion callback method.</param>
        public static <%= Info.ObjectName %> New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>(<%= c.Name %> crit, EventHandler<DataPortalResult<<%= Info.ObjectName %>>> callback)
        {
            <%
                    if (Info.UseUnitOfWorkType == string.Empty)
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
                    if (Info.UseUnitOfWorkType == string.Empty)
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
                    if (Info.UseUnitOfWorkType == string.Empty)
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
                    if (Info.UseUnitOfWorkType == string.Empty)
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