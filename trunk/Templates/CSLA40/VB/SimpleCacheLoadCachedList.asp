<%
if (c.Properties.Count == 0 && Info.SimpleCacheOptions == SimpleCacheResults.DataPortal)
{
    %>

        Private Sub LoadCachedList()
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AddRange(_list)
            RaiseListChangedEvents = rlce
            IsReadOnly = True
        End Sub
        <%
}
%>
