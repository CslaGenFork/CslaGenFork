<%
List<ChildProperty> children = (List<ChildProperty>)Info.GetMyChildProperties();
children = SortChildren(children);
if (IgnoreSortOrder(children))
{
    %>
                FieldManager.UpdateChildren(this);
                <%
}
else
{
    foreach (ChildProperty child in children)
    {
        %>
                DataPortal.UpdateChild(<%= child.Name %>, this);
                <%
    }
}
%>
