<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.Factory)
        {
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                {
                    Errors.Append("Property: " + c.Properties[i].Name + " on criteria: " + c.Name + " must have a ParameterValue. Add it or remove the Criteria Property." + Environment.NewLine);
                    return;
                }
                else
                {
                    c.Properties[i].ReadOnly = true;
                }
            }
            %>

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
            string critSilverlight = string.Empty;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                {
                    Errors.Append("Property: " + c.Properties[i].Name + " on criteria: " + c.Name + " must have a ParameterValue. Add it or remove the Criteria Property." + Environment.NewLine);
                    return;
                }
                else
                {
                    c.Properties[i].ReadOnly = true;
                }
            }
            if (c.Properties.Count > 1)
                critSilverlight = "New " + c.Name + "()";
            else if (c.Properties.Count > 0)
                critSilverlight = SendSingleCriteria(c, c.Properties[0].ParameterValue);
            if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                critSilverlight += (critSilverlight.Length > 0 ? ", " : "") + "Sub(o, e)";
            else
                critSilverlight += (critSilverlight.Length > 0 ? ", " : "");
            %>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(callback As <%= "EventHandler(Of DataPortalResult(Of " + Info.ObjectName + "))" %>)
            <%
            if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
                Info.GetRoles.Trim() != String.Empty)
            {
                %>If  Not CanGetObject() Then
                Throw New System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.")
            End If

            <%
            }
            if (Info.SimpleCacheOptions != SimpleCacheResults.None)
            {
                %>If _list Is Nothing Then
                DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(<%= critSilverlight %>
                        _list = e.Object
                        callback(o, e)
                    End Sub,
                    DataPortal.ProxyModes.LocalOnly)
            Else
                callback(Nothing, New DataPortalResult(Of <%= Info.ObjectName %>)(_list, Nothing, Nothing))
            End If<%
            }
            else
            {
                %>DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(<%= critSilverlight %>callback, DataPortal.ProxyModes.LocalOnly)<%
            }
            %>
        End Sub
<%
        }
    }
}
%>
