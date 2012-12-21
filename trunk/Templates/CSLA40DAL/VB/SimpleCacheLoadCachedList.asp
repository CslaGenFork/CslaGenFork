<%
if (c.Properties.Count == 0 && Info.SimpleCacheOptions == SimpleCacheResults.DataPortal)
{
    %>

        private void LoadCachedList()
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AddRange(_list);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }
        <%
}
%>
