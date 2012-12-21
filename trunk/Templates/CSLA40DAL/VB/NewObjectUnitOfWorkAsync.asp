<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
{
    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.CreateOptions.Factory)
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
            strNewParams += (strNewParams.Length > 0 ? ", " : "") + "EventHandler<DataPortalResult<" + Info.ObjectName + ">> callback";
            string strNewCache = string.Empty;
            foreach (UnitOfWorkProperty prop in Info.UnitOfWorkProperties)
            {
                CslaObjectInfo objectInfo = Info.Parent.CslaObjects.Find(prop.TypeName);
                if (objectInfo.SimpleCacheOptions != SimpleCacheResults.None)
                {
                    strNewCache += "                if (!" + prop.TypeName + ".IsCached)" + Environment.NewLine;
                    strNewCache += "                    " + prop.TypeName + ".SetCache(e.Object." + prop.TypeName + ");" + Environment.NewLine;
                }
            }
                %>

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> unit of objects<%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
        <%= strNewComment %>/// <param name="callback">The completion callback method.</param>
        public static void New<%= Info.ObjectName %><%= c.CreateOptions.FactorySuffix %>(<%= strNewParams %>)
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
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
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strNewCritParams %>), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
<%= strNewCache %>                callback(o, e);
            });
        <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= SendSingleCriteria(c, strNewCritParams) %>, (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
<%= strNewCache %>                callback(o, e);
            });
        <%
            }
            else
            {
                %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= Info.IsCreatorGetter ? "-1, " : "" %>(o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
<%= strNewCache %>                callback(o, e);
            });
        <%
            }
            %>
        }
        <%
        }
    }
}
%>
