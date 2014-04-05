<%
if (Info.GenerateDataPortalInsert && CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert", "Partial Sub Service_Insert()"));
    %>

        ''' <summary>
        ''' Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        ''' </summary>
        ''' <param name="handler">The asynchronous handler.</param>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public <%= (isChildNotLazyLoaded ? "Sub Child_Insert" : "Overrides Sub DataPortal_Insert") %>(handler As Csla.DataPortalClient.LocalProxy(Of <%= Info.ObjectName %>).CompletedHandler)
            Try
                Service_Insert()
                handler(Me, Nothing)

            Catch ex As Exception
                handler(Nothing, ex)
            End Try
        End Sub

        ''' <summary>
        ''' Implements <%= isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert" %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        Partial Sub Service_Insert()
        End Sub
    <%
}
%>
