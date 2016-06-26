<%
if (TemplateHelper.UseSimpleAuditTrail(Info))
{
    %>

        Private Sub SimpleAuditTrail()
    <%
    ValueProperty changedDateProperty = new ValueProperty();
    if (GetValuePropertyByName(Info, Info.Parent.Params.ChangedDateColumn, ref changedDateProperty))
    {
        %>
            <%= GetFieldLoaderStatement(changedDateProperty, GetNowValue(changedDateProperty.PropertyType)) %>
        <%
        var convertedPropertyName = TemplateHelper.ConvertedPropertyName(Info, changedDateProperty);
        if (convertedPropertyName != string.Empty)
        {
            %>
            OnPropertyChanged("<%= convertedPropertyName %>")
        <%
        }
    }
    ValueProperty changedUserProperty = new ValueProperty();
    if (GetValuePropertyByName(Info, Info.Parent.Params.ChangedUserColumn, ref changedUserProperty))
    {
        %>
            <%= GetFieldLoaderStatement(changedUserProperty, Info.Parent.Params.GetUserMethod) %>
        <%
        var convertedPropertyName = TemplateHelper.ConvertedPropertyName(Info, changedUserProperty);
        if (convertedPropertyName != string.Empty)
        {
            %>
            OnPropertyChanged("<%= convertedPropertyName %>")
        <%
        }
    }
    if (TemplateHelper.IsCreationDateColumnPresent(Info) || TemplateHelper.IsCreationUserColumnPresent(Info))
    {
        %>
            If IsNew Then
                <%
        ValueProperty creationDateProperty = new ValueProperty();
        if (GetValuePropertyByName(Info, Info.Parent.Params.CreationDateColumn, ref creationDateProperty))
        {
            if (TemplateHelper.IsChangedDateColumnPresent(Info))
            {
                %>
                <%= GetFieldLoaderStatement(creationDateProperty, GetFieldReaderStatement(changedDateProperty)) %>
                        <%
            }
            else
            {
                %>
                <%= GetFieldLoaderStatement(creationDateProperty, GetNowValue(creationDateProperty.PropertyType)) %>
                        <%
            }
            var convertedPropertyName = TemplateHelper.ConvertedPropertyName(Info, creationDateProperty);
            if (convertedPropertyName != string.Empty)
            {
                %>
                OnPropertyChanged("<%= convertedPropertyName %>")
                        <%
            }
        }
        ValueProperty creationUserProperty = new ValueProperty();
        if (GetValuePropertyByName(Info, Info.Parent.Params.CreationUserColumn, ref creationUserProperty))
        {
            if (TemplateHelper.IsChangedUserColumnPresent(Info))
            {
                %>
                <%= GetFieldLoaderStatement(creationUserProperty, GetFieldReaderStatement(changedUserProperty)) %>
                        <%
            }
            else
            {
                %>
                <%= GetFieldLoaderStatement(creationUserProperty, Info.Parent.Params.GetUserMethod) %>
                        <%
            }
            var convertedPropertyName = TemplateHelper.ConvertedPropertyName(Info, creationUserProperty);
            if (convertedPropertyName != string.Empty)
            {
                %>
                OnPropertyChanged("<%= convertedPropertyName %>")
                        <%
            }
        }
        %>
            End If
        <%
    }
    %>
        End Sub
<%
}
%>
