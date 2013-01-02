<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
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
        if (Info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter && elementCriteriaCount == 0)
        {
            strGetCritParams = "false";
        }
        %>

        /// <summary>
        /// Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given parameters" : "" %>.
        /// </summary>
        <%= strGetComment %>/// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> <%= Info.ObjectType == CslaObjectType.UnitOfWork ? "unit of objects" : "object" %>.</returns>
        <%= Info.ParentType == string.Empty ? "public" : "internal" %> static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(<%= strGetParams %>)
        {
            <%
        if (elementCriteriaCount > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && elementCriteriaCount == 1))
        {
            %>
            return DataPortal.Fetch<%= isChild ? "Child" : "" %><<%= Info.ObjectName %>>(new <%= uowCrit.CriteriaName %>(<%= strGetCritParams %>));
            <%
        }
        else if (elementCriteriaCount > 0)
        {
            %>
            return DataPortal.Fetch<%= isChild ? "Child" : "" %><<%= Info.ObjectName %>>(<%= strGetCritParams %>);
            <%
        }
        else
        {
            if (Info.SimpleCacheOptions != SimpleCacheResults.None)
            {
                %>
            if (_list == null)
                _list = DataPortal.Fetch<%= isChild ? "Child" : "" %><<%= Info.ObjectName %>>(<%= strGetCritParams %>);

            return _list;
            <%
            }
            else
            {
                %>
            return DataPortal.Fetch<%= isChild ? "Child" : "" %><<%= Info.ObjectName %>>(<%= strGetCritParams %>);
        <%
            }
        }
                %>
        }
<%
    }
}
%>
