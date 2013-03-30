<%
List<string> createPartialMethods = new List<string>();
List<string> createPartialParams = new List<string>();
foreach (UnitOfWorkCriteriaManager.UoWCriteria uowCrit in listUoWCriteriaCreator)
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
        createUowCrit = c.Type + " " + FormatCamel(c.Name);
    }
    if (elementCriteriaCount > 1)
    {
        createUowParam = "crit";
        createUowCrit = uowCrit.CriteriaName + " crit";
    }
    if (elementCriteriaCount != 0)
        createUowComment = "/// <param name=\"" + createUowParam + "\">The create criteria.</param>" + System.Environment.NewLine + new string(' ', 8);

    createPartialMethods.Add("partial void Service_Create(" + createUowCrit + ")");
    createPartialParams.Add(createUowComment);
    if (createUowCrit != string.Empty)
        createUowCrit += ", ";
    createUowCrit += "Csla.DataPortalClient.LocalProxy<" + Info.ObjectName + ">.CompletedHandler handler";
    %>

        /// <summary>
        /// Creates a new <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given criteria" : "" %>.
        /// </summary>
        <%= createUowComment %>/// <param name="handler">The asynchronous handler.</param>
        /// <remarks>
        /// ReadOnlyBase&lt;T&gt; doesn't allow the use of DataPortal_Create and thus DataPortal_Fetch is used.
        /// </remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void DataPortal_Fetch(<%= createUowCrit %>)
        {
            try
            {
                Service_Create(<%= createUowParam %>);
                handler(this, null);
            }
            catch (Exception ex)
            {
                handler(null, ex);
            }
        }
<%
}
for (int index = 0; index < createPartialMethods.Count ; index++)
{
    string header = createPartialParams[index];
    header += createPartialMethods[index];
    MethodList.Add(new AdvancedGenerator.ServiceMethod("DataPortal_Fetch", header));
    %>

        /// <summary>
        /// Implements DataPortal_Fetch for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%= header %>;
<%
}
%>
