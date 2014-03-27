<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaCreator)
    {
        string strNewParams = string.Empty;
        string strNewCritParams = string.Empty;
        string strNewComment = string.Empty;
        int elementCriteriaCount = 0;
        int parameterCount = 0;
        foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList)
        {
            if (string.IsNullOrEmpty(c.Name))
                continue;

            if (!string.IsNullOrEmpty(c.Parameter))
            {
                if (elementCriteriaCount > 0)
                    strNewCritParams += ", ";
                strNewCritParams += c.Parameter;
                elementCriteriaCount++;
                elementCriteriaCount++;
                continue;
            }

            if (elementCriteriaCount > 0)
                strNewCritParams += ", ";
            if (parameterCount > 0)
                strNewParams += ", ";
            strNewParams += string.Concat(FormatCamel(c.Name), " As ", c.Type);
            strNewCritParams += FormatCamel(c.Name);
            strNewComment += "''' <param name=\"" + FormatCamel(c.Name) + "\">The " + FormatProperty(c.Name) + " of the " + Info.ObjectName + " to create.</param>" + System.Environment.NewLine + new string(' ', 8);
            elementCriteriaCount++;
            parameterCount++;
        }
        if (Info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter && elementCriteriaCount == 0)
        {
            strNewCritParams = "True";
        }
        %>

        ''' <summary>
        ''' Factory method. Creates a new <see cref="<%= Info.ObjectName %>"/> unit of objects<%= parameterCount > 0 ? ", based on given parameters" : "" %>.
        ''' </summary>
        <%= strNewComment %>''' <returns>A reference to the created <see cref="<%= Info.ObjectName %>"/> <%= Info.ObjectType == CslaObjectType.UnitOfWork ? "unit of objects" : "object" %>.</returns>
        Public Shared Function New<%= Info.ObjectName %>(<%= strNewParams %>) As <%= Info.ObjectName %>
        {
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            <%
        if (elementCriteriaCount > 1)
        {
            %>
            Return DataPortal.Fetch(Of <%= Info.ObjectName %>)(New <%= uowCrit.CriteriaName %>(<%= strNewCritParams %>))
                <%
        }
        else if (elementCriteriaCount > 0)
        {
            %>
            Return DataPortal.Fetch(Of <%= Info.ObjectName %>)(<%= strNewCritParams %>)
                    <%
        }
        else
        {
            %>
            Return DataPortal.Fetch(Of <%= Info.ObjectName %>)(<%= strNewCritParams %>)
                    <%
        }
        %>
        End Function
        <%
    }
}
%>
