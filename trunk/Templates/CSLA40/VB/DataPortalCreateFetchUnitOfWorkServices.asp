<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    List<string> createPartialMethods = new List<string>();
    List<string> createPartialParams = new List<string>();
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
            createUowCrit = FormatCamel(c.Name) + " As " + c.Type ;
        }
        if (elementCriteriaCount > 1)
        {
            createUowParam = "crit";
            createUowCrit = "crit As " + uowCrit.CriteriaName;
        }
        if (elementCriteriaCount != 0)
            createUowComment = "''' <param name=\"" + createUowParam + "\">The create/fetch criteria.</param>" + System.Environment.NewLine + new string(' ', 8);
        else
        {
            createUowParam = "create" + singleUoWProperty;
            createUowComment = "''' <param name=\"" + createUowParam + "\">if set to <c>true</c> creates a " + singleUoWProperty + "; otherwise fetches a " + singleUoWProperty + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            createUowCrit = createUowParam + "As Boolean";
        }
        createPartialMethods.Add("Partial Sub Service_CreateFetch(" + createUowCrit + ")");
        createPartialParams.Add(createUowComment);
        if (createUowCrit != string.Empty)
            createUowCrit += ", ";
        createUowCrit += "handler As Csla.DataPortalClient.LocalProxy(Of " + Info.ObjectName + ").CompletedHandler";
        %>

        ''' <summary>
        ''' Creates or loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given criteria" : "" %>.
        ''' </summary>
        <%= createUowComment %>''' <param name="handler">The asynchronous handler.</param>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub DataPortal_Fetch(<%= createUowCrit %>)
            Try
                Service_CreateFetch(<%= createUowParam %>)
                handler(Me, Nothing)
            Catch (ex As Exception)
                handler(Nothing, ex)
            End Try
        End Sub
<%
    }
    for (int index = 0; index < createPartialMethods.Count ; index++)
    {
        string header = createPartialParams[index];
        header += createPartialMethods[index];
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
