<%
if (Info.GenerateDataPortalUpdate && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update", "Partial Sub Service_Update()"));
    %>

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        ''' <param name="handler">The asynchronous handler.</param>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public <%= isChildNotLazyLoaded ? "Sub Child_Update" : "Overrides Sub DataPortal_Update" %>(handler As Csla.DataPortalClient.LocalProxy(Of <%= Info.ObjectName %>).CompletedHandler)
            Try
                Service_Update()
                handler(Me, Nothing)
            
            Catch ex As Exception
                handler(Nothing, ex)
            End Try
        End Sub

        ''' <summary>
        ''' Implements <%= isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        Partial Sub Service_Update()
        End Sub
    <%
}
%>
