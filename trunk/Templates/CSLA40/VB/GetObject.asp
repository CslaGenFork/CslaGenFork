<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (Info.IsUnitOfWork() && Info.IsCreatorGetter && c.Properties.Count == 0)
            continue;
        if (c.GetOptions.Factory)
        {
            if (!isChild && !c.NestedClass && c.Properties.Count > 1 && Info.IsNotEditableSwitchable())
            {
                %>

        ''' <summary>
        ''' Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %>, based on given parameters.
        ''' </summary>
        ''' <param name="crit">The fetch criteria.</param>
        ''' <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %>.</returns>
        Public Shared Function Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(crit As <%= c.Name %>) As <%= Info.ObjectName %>
            Return DataPortal.Fetch(Of <%= Info.ObjectName %>)(crit)
        End Function
        <%
            }
            %>

        ''' <summary>
        ''' Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %><%= c.Properties.Count > 0 ? ", based on given parameters" : "" %>.
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
            %>
        ''' <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> <%= TypeHelper.IsCollectionType(Info.ObjectType) ? "collection" : "object" %>.</returns>
        <%= Info.ParentType == string.Empty ? "Public" : "Friend" %> Shared Function Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>(<%= strGetParams %>) As <%= Info.ObjectName %>
            <%
            if (Info.IsEditableSwitchable())
            {
                strGetCritParams = "False, " + strGetCritParams;
            }
            if (c.Properties.Count > 1 || (Info.IsEditableSwitchable() && c.Properties.Count == 1))
            {
                %>
            Return DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>(Of <%= Info.ObjectName %>)(New <%= c.Name %>(<%= strGetCritParams %>))
            <%
            }
            else if (c.Properties.Count > 0)
            {
                %>
            Return DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>(Of <%= Info.ObjectName %>)(<%= SendSingleCriteria(c, strGetCritParams) %>)
            <%
            }
            else
            {
                if (Info.SimpleCacheOptions != SimpleCacheResults.None)
                {
                    %>
            If _list Is Nothing Then
                _list = DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>(Of <%= Info.ObjectName %>)()
            End If

            Return _list
            <%
                }
                else
                {
                    %>
            Return DataPortal.Fetch<%= isChildNotLazyLoaded ? "Child" : "" %>(Of <%= Info.ObjectName %>)()
        <%
                }
            }
            %>
        End Function
<%
        }
    }
}
%>
