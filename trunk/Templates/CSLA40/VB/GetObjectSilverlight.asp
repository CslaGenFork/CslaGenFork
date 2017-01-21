<%
if (UseSilverlight())
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.Factory &&
            (CurrentUnit.GenerationParams.SilverlightUsingServices ||
            (CurrentUnit.GenerationParams.GenerateSilverlight4 && c.GetOptions.RunLocal)))
        {
            if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.IsNotEditableSwitchable())
            {
                %>

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %>, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The fetch criteria.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>( crit As <%= c.Name %>, callback As EventHandler(Of DataPortalResult(Of <%= Info.ObjectName %>)))
            <%
                if (!useUnitOfWorkGetter)
                {
                    %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(crit, callback, DataPortal.ProxyModes.LocalOnly)
        <%
                }
                else
                {
                    %>
            <%= Info.UseUnitOfWorkType %>.Get<%= Info.UseUnitOfWorkType %>(crit, Sub(o, e)
                callback(o, New DataPortalResult(Of <%= Info.ObjectName %>)(e.Object.<%= Info.ObjectName %>, e.Error, Nothing))
            End Sub)
            <%
                }
                %>
        End Sub
        <%
            }
            %>

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
        ''' </summary>
        <%
            string strGetParams = string.Empty;
            string strGetCritParams = string.Empty;
            bool firstParam = true;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                {
                    %>
        ''' <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> parameter of the <%= Info.ObjectName %> to fetch.</param>
        <%
                    if (firstParam)
                    {
                        firstParam = false;
                    }
                    else
                    {
                        strGetParams += ", ";
                        strGetCritParams += ", ";
                    }
                    strGetParams += string.Concat(FormatCamel(c.Properties[i].Name), " As ", GetDataTypeGeneric(c.Properties[i], c.Properties[i].PropertyType));
                    strGetCritParams += FormatCamel(c.Properties[i].Name);
                }
                else
                {
                    if (!isCriteriaClassNeeded)
                        strGetCritParams += c.Properties[i].ParameterValue;
                }
            }
            strGetParams += (strGetParams.Length > 0 ? ", " : "") + "callback As EventHandler(Of DataPortalResult(Of " + Info.ObjectName + "))";
            %>
        ''' <param name="callback">The completion callback method.</param>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Sub Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(<%= strGetParams %>)
            <%
            if (Info.IsEditableSwitchable())
            {
                strGetCritParams = "False, " + strGetCritParams;
            }
            if (c.Properties.Count > 1 || (Info.IsEditableSwitchable() && c.Properties.Count == 1))
            {
                if (!useUnitOfWorkGetter)
                {
                    %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(New <%= c.Name %>(<%= strGetCritParams %>), callback, DataPortal.ProxyModes.LocalOnly)
            <%
                }
                else
                {
                    %>
            <%= Info.UseUnitOfWorkType %>.Get<%= Info.UseUnitOfWorkType %>(New <%= c.Name %>(<%= strGetCritParams %>), Sub(o, e)
                callback(o, New DataPortalResult(Of <%= Info.ObjectName %>)(e.Object.<%= Info.ObjectName %>, e.Error, Nothing))
            End Sub)
            <%
                }
            }
            else if (c.Properties.Count > 0)
            {
                if (!useUnitOfWorkGetter)
                {
                    %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(<%= SendSingleCriteria(c, strGetCritParams) %>, callback, DataPortal.ProxyModes.LocalOnly)
            <%
                }
                else
                {
                    %>
            <%= Info.UseUnitOfWorkType %>.Get<%= Info.UseUnitOfWorkType %>(<%= SendSingleCriteria(c, strGetCritParams) %>, Sub(o, e)
                callback(o, New DataPortalResult(Of <%= Info.ObjectName %>)(e.Object.<%= Info.ObjectName %>, e.Error, Nothing))
            End Sub)
            <%
                }
            }
            else
            {
                if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                {
                    %>
            If _list Is Nothing Then
                DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(Sub(o, e)
                    _list = e.Object
                    callback(o, e)
                End Sub,
                DataPortal.ProxyModes.LocalOnly)
            Else
                callback(Nothing, New DataPortalResult(<%= Info.ObjectName %>)(_list, Nothing, Nothing))
            End If
        <%
                }
                else
                {
                    if (!useUnitOfWorkGetter)
                    {
                        %>
            DataPortal.BeginFetch(Of <%= Info.ObjectName %>)(callback, DataPortal.ProxyModes.LocalOnly)
        <%
                    }
                    else
                    {
                        %>
            <%= Info.UseUnitOfWorkType %>.Get<%= Info.UseUnitOfWorkType %>(Sub(o, e)
                callback(o, New DataPortalResult(Of <%= Info.ObjectName %>)(e.Object.<%= Info.ObjectName %>, e.Error, Nothing))
            End Sub)
            <%
                    }
                }
            }
            %>
        End Sub
<%
        }
    }
}
%>
