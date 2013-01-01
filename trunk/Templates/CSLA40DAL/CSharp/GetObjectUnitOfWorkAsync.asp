<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous || CurrentUnit.GenerationParams.GenerateSilverlight4)
{
    foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaGetter)
    {
        string strGetParams = string.Empty;
        string strGetCritParams = string.Empty;
        string strGetComment = string.Empty;
        int elementCriteriaCount = 0;
        int parameterCount = 0;
        foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList)
        {
            if (string.IsNullOrEmpty(c.Name))
                continue;

            if (!string.IsNullOrEmpty(c.Parameter))
            {
                if (elementCriteriaCount > 0)
                    strGetCritParams += ", ";
                strGetCritParams += c.Parameter;
                elementCriteriaCount++;
            }

            if (elementCriteriaCount > 0)
                strGetCritParams += ", ";
            if (parameterCount > 0)
                strGetParams += ", ";
            strGetParams += string.Concat(c.Type, " ", FormatCamel(c.Name));
            strGetCritParams += FormatCamel(c.Name);
            strGetComment += "/// <param name=\"" + FormatCamel(c.Name) + "\">The " + FormatProperty(c.Name) + " parameter of the " + Info.ObjectName + " to fetch.</param>" + System.Environment.NewLine + new string(' ', 8);
            elementCriteriaCount++;
            parameterCount++;
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

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
        <%= strGetComment %>/// <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static void Get<%= Info.ObjectName %>(<%= strGetParams %>)
        {
            <%
        if (elementCriteriaCount > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && elementCriteriaCount == 1))
        {
            %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(new <%= uowCrit.CriteriaName %>(<%= strGetCritParams %>), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
<%= strGetCache %>                callback(o, e);
            });
            <%
        }
        else if (elementCriteriaCount > 0)
        {
            %>
            DataPortal.BeginFetch<<%= Info.ObjectName %>>(<%= strGetCritParams %>, (o, e) =>
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
%>
