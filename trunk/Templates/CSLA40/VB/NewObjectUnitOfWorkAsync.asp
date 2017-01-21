<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous)
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
        strNewParams += (strNewParams.Length > 0 ? ", " : "") + "callback As EventHandler(Of DataPortalResult(Of " + Info.ObjectName + "))";
        string strNewCache = string.Empty;
        foreach (UnitOfWorkProperty prop in Info.UnitOfWorkProperties)
        {
            CslaObjectInfo objectInfo = Info.Parent.CslaObjects.Find(prop.TypeName);
            if (objectInfo.SimpleCacheOptions != SimpleCacheResults.None)
            {
                strNewCache += "                If Not " + prop.TypeName + ".IsCached Then" + Environment.NewLine;
                strNewCache += "                    " + prop.TypeName + ".SetCache(e.Object." + prop.TypeName + ")" + Environment.NewLine;
                strNewCache += "                End If" + Environment.NewLine;
            }
        }
        if (Info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter && elementCriteriaCount == 0)
        {
            strNewCritParams = "True, ";
        }
        %>

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="<%= Info.ObjectName %>"/> unit of objects<%= parameterCount > 0 ? ", based on given parameters" : "" %>.
        ''' </summary>
        <%= strNewComment %>''' <param name="callback">The completion callback method.</param>
        Public Shared Sub New<%= Info.ObjectName %>(<%= strNewParams %>)
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            <%
        if (elementCriteriaCount > 1)
        {
            %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(New <%= uowCrit.CriteriaName %>(<%= strNewCritParams %>), Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
<%= strNewCache %>                callback(o, e)
            End Sub)
        <%
        }
        else if (elementCriteriaCount > 0)
        {
            %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(<%= strNewCritParams %>, Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
<%= strNewCache %>                callback(o, e)
            End Sub)
        <%
        }
        else
        {
            %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(<%= strNewCritParams %>Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
<%= strNewCache %>                callback(o, e)
            End Sub)
        <%
        }
            %>
        End Sub
        <%
    }
}
%>
