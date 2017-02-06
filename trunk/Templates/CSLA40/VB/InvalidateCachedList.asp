<%
if (hasFactoryCache || hasDataPortalCache)
{
    string eventName = "Saved";
    string handlerName = "On" + Info.ObjectName + "Saved";
    if (Info.SupportUpdateProperties)
    {
        eventName = Info.ObjectName + "Saved";
        handlerName = Info.ObjectName + "SavedHandler";
    }
    Infos.Append("To do list: edit \"" + Info.ObjectName + ".vb\", uncomment the \"OnDeserialized\" method and add the following line:" + Environment.NewLine);
    Infos.Append("      AddHandler " + eventName + ", AddressOf " + handlerName + Environment.NewLine);
    %>

        #Region " Cache Invalidation "
<%
        if (CurrentUnit.GenerationParams.WriteTodo)
        {
            %>

        'TODO: edit "<%= Info.ObjectName %>.vb", uncomment the "OnDeserialized" method and add the following line:
        'TODO:     AddHandler <%= eventName %>, AddressOf <%= handlerName %>
<%
        }
        %>

        Private Sub <%= handlerName %>(sender As Object, e As Csla.Core.SavedEventArgs)
            '' this runs on the client
            <%
    foreach (string objectName in invalidatorInfo.InvalidateCache)
    {
        %>
            <%= objectName %>.InvalidateCache()
            <%
    }
    %>
        End Sub
<%
    if (hasDataPortalCache && UseNoSilverlight())
    {
        if (UseSilverlight())
        {
            %>

#If Not SILVERLIGHT Then
        <%
        }
        %>

        ''' <summary>
        ''' Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        ''' </summary>
        ''' <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        Protected Overrides Sub DataPortal_OnDataPortalInvokeComplete(e As Csla.DataPortalEventArgs)
            If ApplicationContext.ExecutionLocation = ApplicationContext.ExecutionLocations.Server AndAlso
               e.Operation = DataPortalOperations.Update Then
                '' this runs on the server
            <%
        foreach (string objectName in invalidatorInfo.InvalidateCache)
        {
            CslaObjectInfo cachedInfo = Info.Parent.CslaObjects.Find(objectName);
            if (cachedInfo.SimpleCacheOptions == SimpleCacheResults.DataPortal)
            {
                %>
                <%= objectName %>.InvalidateCache()
                <%
            }
        }
    %>
            End If
        End Sub
<%
        if (UseSilverlight())
        {
            %>

#End If
        <%
        }
    }
%>

        #End Region
<%
}
%>
