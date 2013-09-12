<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices && UseNoSilverlight())
{
    List<string> fetchPartialMethods = new List<string>();
    List<string> fetchPartialParams = new List<string>();
    foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaGetter)
    {
        string fetchUowParam = string.Empty;
        string fetchUowCrit = string.Empty;
        string fetchUowComment = string.Empty;
        int elementCriteriaCount = 0;
        foreach (UnitOfWorkCriteriaManager.ElementCriteria c in uowCrit.ElementCriteriaList)
        {
            if (string.IsNullOrEmpty(c.Name))
                continue;

            if (!string.IsNullOrEmpty(c.Parameter))
                elementCriteriaCount++;

            elementCriteriaCount++;
            fetchUowParam = FormatCamel(c.Name);
            fetchUowCrit = c.Type + " " + FormatCamel(c.Name);
        }
        if (elementCriteriaCount > 1)
        {
            fetchUowParam = "crit";
            fetchUowCrit = uowCrit.CriteriaName + " crit";
        }
        if (elementCriteriaCount != 0)
            fetchUowComment = "/// <param name=\"" + fetchUowParam + "\">The fetch criteria.</param>" + System.Environment.NewLine + new string(' ', 8);

        fetchPartialMethods.Add("partial void Service_Fetch(" + fetchUowCrit + ")");
        fetchPartialParams.Add(fetchUowComment);
        %>

        /// <summary>
        /// Loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%= fetchUowComment %>[Csla.RunLocal]
        protected void DataPortal_Fetch(<%= fetchUowCrit %>)
        {
            Service_Fetch(<%= fetchUowParam %>);
        }
<%
    }
    for (int index = 0; index < fetchPartialMethods.Count ; index++)
    {
        string header = fetchPartialParams[index];
        header += fetchPartialMethods[index];
        MethodList.Add(new AdvancedGenerator.ServiceMethod("DataPortal_Fetch", header));
        %>

        /// <summary>
        /// Implements DataPortal_Fetch for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%= header %>;
<%
    }
}
%>
