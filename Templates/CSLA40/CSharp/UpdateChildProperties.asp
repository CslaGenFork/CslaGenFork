<%
if (CurrentUnit.GenerationParams.UseChildDataPortal)
{
    if (Info.GetCollectionChildProperties().Count > 0 || Info.GetNonCollectionChildProperties().Count > 0)
    {
        %>

                <%= indent %>FieldManager.UpdateChildren(this);
                <%
    }
}
else
{
    foreach (ChildProperty child in Info.GetCollectionChildProperties())
    {
        CslaObjectInfo _child = FindChildInfo(Info, child.TypeName);
        if (_child != null && _child.ObjectType != CslaObjectType.ReadOnlyObject &&
            _child.ObjectType != CslaObjectType.ReadOnlyCollection)
        {
            %>

                <%= indent %>// Update child Properties
                <%= indent %>if (<%=FormatFieldName(child)%> != null)
                <%= indent %>    <%=FormatFieldName(child)%>.Update(this);
                <%
        }
    }
    foreach (ChildProperty child in Info.GetNonCollectionChildProperties())
    {
        CslaObjectInfo _child = FindChildInfo(Info, child.TypeName);
        if (_child != null && _child.ObjectType != CslaObjectType.ReadOnlyObject &&
            _child.ObjectType != CslaObjectType.ReadOnlyCollection)
        {
            %>

                    <%= indent %>// Insert/Update child Properties
                    <%= indent %>if (<%=FormatFieldName(child)%> != null)
                    <%= indent %>{
                    <%= indent %>    if (<%=FormatFieldName(child)%>.IsNew)
                    <%= indent %>        <%=FormatFieldName(child)%>.Insert(this);
                    <%= indent %>    else
                    <%= indent %>        <%=FormatFieldName(child)%>.Update(<% if (!_child.ParentInsertOnly) { %>this<% } %>);
                    <%= indent %>}
                                <%
        }
    }
}
%>
