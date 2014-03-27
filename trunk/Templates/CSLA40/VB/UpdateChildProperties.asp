<%
List<ChildProperty> children = (List<ChildProperty>)Info.GetMyChildProperties();
children = SortChildren(children);
if (IgnoreSortOrder(children))
{
    %>
            <%= ucpSpacer %>' flushes all pending data operations
            <%= ucpSpacer %>FieldManager.UpdateChildren(Me)
<%
}
else
{
    foreach (ChildProperty child in children)
    {
        %>
            <%= ucpSpacer %>DataPortal.UpdateChild(<%= child.Name %>, Me)
<%
    }
}
%>
