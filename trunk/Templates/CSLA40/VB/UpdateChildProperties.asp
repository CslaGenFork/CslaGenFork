<%
string ucpSpacer = CurrentUnit.GenerationParams.SilverlightUsingServices ? ucpSpacer = string.Empty : new string(' ', 4);
List<ChildProperty> children = (List<ChildProperty>)Info.GetMyChildProperties();
children = SortChildren(children);
if (IgnoreSortOrder(children))
{
    %>
            <%= ucpSpacer %>// flushes all pending data operations
            <%= ucpSpacer %>FieldManager.UpdateChildren(this);
<%
}
else
{
    foreach (ChildProperty child in children)
    {
        %>
            <%= ucpSpacer %>DataPortal.UpdateChild(<%= child.Name %>, this);
<%
    }
}
%>
