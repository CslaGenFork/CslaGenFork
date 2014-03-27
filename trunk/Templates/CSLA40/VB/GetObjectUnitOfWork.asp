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
            strGetParams += string.Concat(FormatCamel(c.Name), " As ", c.Type);
            strGetCritParams += FormatCamel(c.Name);
            strGetComment += "''' <param name=\"" + FormatCamel(c.Name) + "\">The " + FormatProperty(c.Name) + " parameter of the " + Info.ObjectName + " to fetch.</param>" + System.Environment.NewLine + new string(' ', 8);
            elementCriteriaCount++;
            parameterCount++;
        }
        if (Info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter && elementCriteriaCount == 0)
        {
            strGetCritParams = "False";
        }
        %>

        ''' <summary>
        ''' Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given parameters" : "" %>.
        ''' </summary>
        <%= strGetComment %>''' <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> <%= Info.ObjectType == CslaObjectType.UnitOfWork ? "unit of objects" : "object" %>.</returns>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Function Get<%= Info.ObjectName %>(<%= strGetParams %>) As <%= Info.ObjectName %>
            <%
        if (elementCriteriaCount > 1 || (Info.ObjectType == CslaObjectType.EditableSwitchable && elementCriteriaCount == 1))
        {
            %>
            Return DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>(Of <%= Info.ObjectName %>)(New <%= uowCrit.CriteriaName %>(<%= strGetCritParams %>))
            <%
        }
        else if (elementCriteriaCount > 0)
        {
            %>
            Return DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>(Of <%= Info.ObjectName %>)(<%= strGetCritParams %>)
            <%
        }
        else
        {
            if (Info.SimpleCacheOptions != SimpleCacheResults.None)
            {
                %>
            If _list Is Nothing Then
                _list = DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>(Of <%= Info.ObjectName %>)(<%= strGetCritParams %>)
            End If

            Return _list
            <%
            }
            else
            {
                %>
            Return DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>(Of <%= Info.ObjectName %>)(<%= strGetCritParams %>)
        <%
            }
        }
                %>
        End Function
<%
    }
}
%>
