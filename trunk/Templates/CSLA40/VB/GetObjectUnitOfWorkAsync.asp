<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous || CurrentUnit.GenerationParams.GenerateSilverlight4)
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
        strGetParams += (strGetParams.Length > 0 ? ", " : "") + "callback As EventHandler(Of DataPortalResult(Of " + Info.ObjectName + "))";
        string strGetCache = string.Empty;
        foreach (UnitOfWorkProperty prop in Info.UnitOfWorkProperties)
        {
            CslaObjectInfo objectInfo = Info.Parent.CslaObjects.Find(prop.TypeName);
            if (objectInfo.SimpleCacheOptions != SimpleCacheResults.None)
            {
                strGetCache += "                If Not " + prop.TypeName + ".IsCached Then" + Environment.NewLine;
                strGetCache += "                    " + prop.TypeName + ".SetCache(e.Object." + prop.TypeName + ")" + Environment.NewLine;
                strGetCache += "                End If" + Environment.NewLine;
            }
        }
        if (Info.UnitOfWorkType == UnitOfWorkFunction.CreatorGetter && elementCriteriaCount == 0)
        {
            strGetCritParams = "False, ";
        }
        %>

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> unit of objects<%= elementCriteriaCount > 0 ? ", based on given parameters" : "" %>.
        ''' </summary>
        <%= strGetComment %>''' <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Sub Get<%= Info.ObjectName %>(<%= strGetParams %>)
        {
            <%
        if (elementCriteriaCount > 1 || (Info.IsEditableSwitchable() && elementCriteriaCount == 1))
        {
            %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(New <%= uowCrit.CriteriaName %>(<%= strGetCritParams %>), Function(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
<%= strGetCache %>                callback(o, e)
            End Function)
            <%
        }
        else if (elementCriteriaCount > 0)
        {
            %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(<%= strGetCritParams %>, Function(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
<%= strGetCache %>                callback(o, e)
            End Function)
            <%
        }
        else
        {
            %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(<%= strGetCritParams %>Function(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
<%= strGetCache %>                callback(o, e)
            End Function)
        <%
        }
                %>
        End Sub
<%
    }
}
%>
