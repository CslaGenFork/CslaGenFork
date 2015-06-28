<%
foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaCreator)
{
    string createUowParam = string.Empty;
    string createUowCrit = string.Empty;
    string createUowComment = string.Empty;
    string singleUoWProperty = string.Empty;
    int elementCriteriaCount = 0;
    foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList)
    {
        if (!c.IsGetter)
            singleUoWProperty = c.ParentObject;
        if (string.IsNullOrEmpty(c.Name))
            continue;

        if (!string.IsNullOrEmpty(c.Parameter))
            elementCriteriaCount++;

        elementCriteriaCount++;
        createUowParam = FormatCamel(c.Name);
        createUowCrit = c.Type + " " + FormatCamel(c.Name);
    }
    if (elementCriteriaCount > 1)
    {
        createUowParam = "crit";
        createUowCrit = uowCrit.CriteriaName + " crit";
    }
    if (elementCriteriaCount != 0)
        createUowComment = "/// <param name=\"" + createUowParam + "\">The create/fetch criteria.</param>" + System.Environment.NewLine + new string(' ', 8);
    else
    {
        createUowParam = "create" + singleUoWProperty;
        createUowComment = "/// <param name=\"" + createUowParam + "\">if set to <c>true</c> creates a " + singleUoWProperty + "; otherwise fetches a " + singleUoWProperty + ".</param>" + System.Environment.NewLine + new string(' ', 8);
        createUowCrit = "bool " + createUowParam;
    }
    %>

        /// <summary>
        /// Creates or loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%= createUowComment %>protected void DataPortal_Fetch(<%= createUowCrit %>)
        {
            <%
    foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList)
    {
        string strCreate = string.Empty;
        string strFetch = string.Empty;
        if (CurrentUnit.GenerationParams.GenerateSynchronous)
        {
            strCreate = c.ParentObject + ".New" + c.ParentObject;
            strFetch = c.ParentObject + ".Get" + c.ParentObject;
        }
        else
        {
            strCreate = "DataPortal.Create<" + c.ParentObject + ">";
            strFetch = "DataPortal.Fetch<" + c.ParentObject + ">";
        }
        string uowParam = string.Empty;
        if (c.Name != string.Empty)
        {
            if (c.Type != string.Empty && elementCriteriaCount < 2)
                uowParam = FormatCamel(c.Name);
            else
                uowParam = "crit." + FormatPascal(c.Name);
        }
        if (c.Parameter != string.Empty)
        {
            %>
            if (crit.Create<%= c.ParentObject %>)
                <%= GetFieldLoaderStatement(c.DeclarationMode, c.PropertyName, strCreate + "()") %>;
            else
                <%= GetFieldLoaderStatement(c.DeclarationMode, c.PropertyName, strFetch + "(" + uowParam + ")") %>;
            <%
            continue;
        }
        else if (!c.IsGetter && elementCriteriaCount == 0)
        {
            %>
            if (<%= createUowParam %>)
                <%= GetFieldLoaderStatement(c.DeclarationMode, c.PropertyName, strCreate + "()") %>;
            else
                <%= GetFieldLoaderStatement(c.DeclarationMode, c.PropertyName, strFetch + "(" + uowParam + ")") %>;
            <%
            continue;
        }
        if (uowParam.Length != 0)
        {
            %>
            <%= GetFieldLoaderStatement(c.DeclarationMode, c.PropertyName, (c.IsGetter ? strFetch : strCreate) + "(" + uowParam + ")") %>;
            <%
        }
        else
        {
            %>
            <%= GetFieldLoaderStatement(c.DeclarationMode, c.PropertyName, (c.IsGetter ? strFetch : strCreate) + "()") %>;
            <%
        }
    }
    %>
        }
<%
}
%>
