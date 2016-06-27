<%
if (UseSilverlight())
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.Factory &&
            (CurrentUnit.GenerationParams.SilverlightUsingServices ||
            (CurrentUnit.GenerationParams.GenerateSilverlight4 && c.DeleteOptions.RunLocal)))
        {
            if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.IsNotEditableSwitchable())
            {
                %>

        ''' <summary>
        ''' Factory method. Asynchronously deletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The delete criteria.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub Delete<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(crit As <%= c.Name %>, callback As EventHandler(Of DataPortalResult(Of <%= Info.ObjectName %>)))
            DataPortal.BeginDelete(Of <%= Info.ObjectName %>)(crit, callback, DataPortal.ProxyModes.LocalOnly)
        End Sub
        <%
            }
            %>

        ''' <summary>
        ''' Factory method. Asynchronously deletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        ''' </summary>
<%
            string strDelParams = string.Empty;
            string strDelCritParams = string.Empty;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                %>
        ''' <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the <%= Info.ObjectName %> to delete.</param>
        <%
                if (i > 0)
                {
                    strDelParams += ", ";
                    strDelCritParams += ", ";
                }
                strDelParams += string.Concat(FormatCamel(c.Properties[i].Name), " As ", GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType));
                strDelCritParams += FormatCamel(c.Properties[i].Name);
            }
            strDelParams += (strDelParams.Length > 0 ? ", " : "") + "callback As EventHandler(Of DataPortalResult(Of " + Info.ObjectName + "))";
            //strDelCritParams += (strDelCritParams.Length > 0 ? ", " : "") + "callback";
            %>
        ''' <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Sub Delete<%= Info.ObjectName %><%= c.DeleteOptions.FactorySuffix %>(<%= strDelParams %>)
            <%
            if (Info.IsEditableSwitchable())
            {
                if (!strDelCritParams.Equals(String.Empty))
                {
                    strDelCritParams = ", " + strDelCritParams;
                }
                strDelCritParams = "False" + strDelCritParams;
            }
            if (c.Properties.Count > 1)
            {
                %>DataPortal.BeginDelete(Of <%= Info.ObjectName %>)(New <%= c.Name %>(<%= strDelCritParams %>), callback, DataPortal.ProxyModes.LocalOnly)<%
            }
            else if (c.Properties.Count > 0)
            {
                %>DataPortal.BeginDelete(Of <%= Info.ObjectName %>)(<%= SendSingleCriteria(c, strDelCritParams) %>, callback, DataPortal.ProxyModes.LocalOnly)<%
            }
            else
            {
                %>DataPortal.BeginDelete(New <%= c.Name %>(callback, DataPortal.ProxyModes.LocalOnly)<%
            }
            %>
        End Sub
<%
            if (isUndeletable == true)
            {
                %>

        ''' <summary>
        ''' Factory method. Asynchronously undeletes a <see cref="<%= Info.ObjectName %>"/> object, based on given parameters.
        ''' </summary>
<%
                strDelParams = string.Empty;
                strDelCritParams = string.Empty;
                for (int i = 0; i < c.Properties.Count; i++)
                {
                    %>
        ''' <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the <%= Info.ObjectName %> to undelete.</param>
        <%
                    if (i > 0)
                    {
                        strDelParams += ", ";
                        strDelCritParams += ", ";
                    }
                    strDelParams += string.Concat(FormatCamel(c.Properties[i].Name), " As ", GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType));
                    strDelCritParams += FormatCamel(c.Properties[i].Name);
                }
                strDelParams += (strDelParams.Length > 0 ? ", " : "") + "callback As EventHandler(Of DataPortalResult(Of " + Info.ObjectName + "))";
                //strDelCritParams += (strDelCritParams.Length > 0 ? ", " : "") + "callback";
                %>
        ''' <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Sub Undelete<%= Info.ObjectName %><%= c.DeleteOptions.FactorySuffix %>(<%= strDelParams %>)
            Dim obj = New <%= Info.ObjectName %>()
            <%
                if (Info.IsEditableSwitchable())
                {
                    if (!strDelCritParams.Equals(String.Empty))
                    {
                        strDelCritParams = ", " + strDelCritParams;
                    }
                    strDelCritParams = "False" + strDelCritParams;
                }
                if (c.Properties.Count > 1)
                {
                    %>DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(<%= strDelCritParams %>, Function(o, e)<%
                }
                else if (c.Properties.Count > 0)
                {
                    %>DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(<%= SendSingleCriteria(c, strDelCritParams) %>, Function(o, e)<%
                }
            %>
                    If e.Error IsNot Nothing Then
                        Throw e.Error
                    Else
                        obj = e.Object
                    End If
                End Function, DataPortal.ProxyModes.LocalOnly)
            obj.<%= softDeleteProperty %> = True
            obj.BeginSave(callback)
        End Sub
<%
            }
        }
    }
}
%>
