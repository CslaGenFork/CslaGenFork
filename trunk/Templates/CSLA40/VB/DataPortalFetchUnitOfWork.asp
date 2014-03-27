<%
foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaGetter)
{
    string createUowParam = string.Empty;
    string createUowCrit = string.Empty;
    string createUowComment = string.Empty;
    int elementCriteriaCount = 0;
    foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList)
    {
        if (string.IsNullOrEmpty(c.Name))
            continue;

        if (!string.IsNullOrEmpty(c.Parameter))
            elementCriteriaCount++;

        elementCriteriaCount++;
        createUowParam = FormatCamel(c.Name);
        createUowCrit = FormatCamel(c.Name) + " As " + c.Type;
    }
    if (elementCriteriaCount > 1)
    {
        createUowParam = "crit";
        createUowCrit = "crit As " + uowCrit.CriteriaName;
    }
    if (elementCriteriaCount != 0)
        createUowComment = "''' <param name=\"" + createUowParam + "\">The fetch criteria.</param>" + System.Environment.NewLine + new string(' ', 8);
    %>

        ''' <summary>
        ''' Loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given criteria" : "" %>.
        ''' </summary>
        <%= createUowComment %>Protected Sub DataPortal_Fetch(<%= createUowCrit %>)
            <%
    foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList)
    {
        string strFetch = string.Empty;
        if (CurrentUnit.GenerationParams.GenerateSynchronous)
            strFetch = c.ParentObject + ".Get" + c.ParentObject;
        else
            strFetch = "DataPortal.Fetch(Of " + c.ParentObject + ")";
        string uowParam = string.Empty;
        if (c.Name != string.Empty)
        {
            if (c.Type != string.Empty && elementCriteriaCount < 2)
                uowParam = FormatCamel(c.Name);
            else
                uowParam = "crit." + FormatPascal(c.Name);
        }
        if (uowParam.Length != 0)
        {
            %>
            <%= GetFieldLoaderStatement(c.DeclarationMode, c.ParentObject, strFetch + "(" + uowParam + ")") %>
            <%
        }
        else
        {
            %>
            <%= GetFieldLoaderStatement(c.DeclarationMode, c.ParentObject, strFetch + "()") %>
            <%
        }
    }
    %>
        End Sub
<%
}
%>
