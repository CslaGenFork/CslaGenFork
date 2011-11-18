<%
if (UseSimpleAuditTrail(Info))
{
    %>

        private void SimpleAuditTrail()
        {
    <%
    ValueProperty changedDateProperty = new ValueProperty();
    if (GetValuePropertyByName(Info, Info.Parent.Params.ChangedDateColumn, ref changedDateProperty))
    {
        %>
            <%= GetFieldLoaderStatement(changedDateProperty, "DateTime.Now") %>;
        <%
    }
    ValueProperty changedUserProperty = new ValueProperty();
    if (GetValuePropertyByName(Info, Info.Parent.Params.ChangedUserColumn, ref changedUserProperty))
    {
        %>
            <%= GetFieldLoaderStatement(changedUserProperty, Info.Parent.Params.GetUserMethod) %>;
        <%
    }
    if (IsCreationDateColumnPresent(Info) || IsCreationUserColumnPresent(Info))
    {
        %>
            if (IsNew)
            {
                <%
        ValueProperty creationDateProperty = new ValueProperty();
        if (GetValuePropertyByName(Info, Info.Parent.Params.CreationDateColumn, ref creationDateProperty))
        {
            if (IsChangedDateColumnPresent(Info))
            {
                %>
                <%= GetFieldLoaderStatement(creationDateProperty, GetFieldReaderStatement(changedDateProperty)) %>;
                        <%
            }
            else
            {
                %>
                <%= GetFieldLoaderStatement(creationDateProperty, "DateTime.Now") %>;
                        <%
            }
        }
        ValueProperty creationUserProperty = new ValueProperty();
        if (GetValuePropertyByName(Info, Info.Parent.Params.CreationUserColumn, ref creationUserProperty))
        {
            if (IsChangedUserColumnPresent(Info))
            {
                %>
                <%= GetFieldLoaderStatement(creationUserProperty, GetFieldReaderStatement(changedUserProperty)) %>;
                        <%
            }
            else
            {
                %>
                <%= GetFieldLoaderStatement(creationUserProperty, Info.Parent.Params.GetUserMethod) %>;
                        <%
            }
        }
        %>
            }
        <%
    }
    if (auditConvertProperties.Count > 0)
    {
        %>
            ConvertAuditPropertiesOnUpdate();
        <%
    }
    %>
        }
<%
}
%>
