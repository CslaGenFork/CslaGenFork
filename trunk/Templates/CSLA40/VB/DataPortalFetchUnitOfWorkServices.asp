<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
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
            fetchUowCrit = FormatCamel(c.Name) + " As " + c.Type ;
        }
        if (elementCriteriaCount > 1)
        {
            fetchUowParam = "crit";
            fetchUowCrit = "crit As " + uowCrit.CriteriaName;
        }
        if (elementCriteriaCount != 0)
            fetchUowComment = "''' <param name=\"" + fetchUowParam + "\">The fetch criteria.</param>" + System.Environment.NewLine + new string(' ', 8);

        fetchPartialMethods.Add("Partial Sub Service_Fetch(" + fetchUowCrit + ")");
        fetchPartialParams.Add(fetchUowComment);
        if (fetchUowCrit != string.Empty)
            fetchUowCrit += ", ";
        fetchUowCrit += "handler As Csla.DataPortalClient.LocalProxy(Of " + Info.ObjectName + ").CompletedHandler";
        %>

        ''' <summary>
        ''' Loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given criteria" : "" %>.
        ''' </summary>
        <%= fetchUowComment %>''' <param name="handler">The asynchronous handler.</param>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub DataPortal_Fetch(<%= fetchUowCrit %>)
            Try
                Service_Fetch(<%= fetchUowParam %>)
                handler(Me, Nothing)
            Catch (ex As Exception)
                handler(Nothing, ex)
            End Try
        End Sub
<%
    }
    for (int index = 0; index < fetchPartialMethods.Count ; index++)
    {
        string header = fetchPartialParams[index];
        header += fetchPartialMethods[index];
        MethodList.Add(new AdvancedGenerator.ServiceMethod("DataPortal_Fetch", header));
        %>

        ''' <summary>
        ''' Implements DataPortal_Fetch for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%= header %>
        End Sub
<%
    }
}
%>
