<%
if (hasFactoryCache || hasDataPortalCache)
{
    Infos.Append("To do list: edit \"" + Info.ObjectName + ".cs\", uncomment the \"OnDeserialized\" method and add the following line:" + Environment.NewLine);
    Infos.Append("      Saved += On" + Info.ObjectName + "Saved;" + Environment.NewLine);
    %>

        #region Cache Invalidation
<%
        if (CurrentUnit.GenerationParams.WriteTodo)
        {
            %>

        // TODO: edit "<%= Info.ObjectName %>.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     Saved += On<%= Info.ObjectName %>Saved;
<%
        }
        %>

        private void On<%= Info.ObjectName %>Saved(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            <%
    foreach (string objectName in invalidatorInfo.InvalidateCache)
    {
        %>
            <%= objectName %>.InvalidateCache();
            <%
    }
    %>
        }
<%
    if (hasDataPortalCache && UseNoSilverlight())
    {
        if (UseSilverlight())
        {
            %>

#if !SILVERLIGHT
        <%
        }
        %>

        /// <summary>
        /// Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        /// </summary>
        /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        protected override void DataPortal_OnDataPortalInvokeComplete(Csla.DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server &&
                e.Operation == DataPortalOperations.Update)
            {
                // this runs on the server
            <%
        foreach (string objectName in invalidatorInfo.InvalidateCache)
        {
            CslaObjectInfo cachedInfo = Info.Parent.CslaObjects.Find(objectName);
            if (cachedInfo.SimpleCacheOptions == SimpleCacheResults.DataPortal)
            {
                %>
                <%= objectName %>.InvalidateCache();
                <%
            }
        }
    %>
            }
        }
<%
        if (UseSilverlight())
        {
            %>

#endif
        <%
        }
    }
%>

        #endregion
<%
}
%>
