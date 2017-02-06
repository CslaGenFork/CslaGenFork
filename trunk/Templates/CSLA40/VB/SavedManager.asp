<%
// Check if we are supposed to use the Updater or else skip over
if (Info.UpdaterType != string.Empty)
{
    %>
        #Region " <%= Info.UpdaterType %>Saved nested class "
<%
    if (CurrentUnit.GenerationParams.WriteTodo)
    {
        %>

        'TODO: edit "<%= Info.ObjectName %>.vb", uncomment the "OnDeserialized" method and add the following line:
        'TODO:     <%= Info.UpdaterType %>Saved.Register(Me)
<%
    }
    %>

        ''' <summary>
        ''' Nested class to manage the Saved events of <see cref="<%= Info.UpdaterType %>"/>
        ''' to update the list of <see cref="<%= Info.ItemType %>"/> objects.
        ''' </summary>
        Private NotInheritable Class <%= Info.UpdaterType %>Saved
            Private Shared _references As List(Of WeakReference)

            Private Sub New()
            End Sub

            Private Shared Function Found(ByVal obj As Object) As Boolean
                Return _references.Any(Function(reference) Equals(reference.Target, obj))
            End Function

            ''' <summary>
            ''' Registers a <%= Info.ObjectName %> instance to handle Saved events.
            ''' to update the list of <see cref="<%= Info.ItemType %>"/> objects.
            ''' </summary>
            ''' <param name="obj">The <%= Info.ObjectName %> instance.</param>
            Public Shared Sub Register(ByVal obj As <%= Info.ObjectName %>)
                Dim mustRegister As Boolean = _references Is Nothing

                If mustRegister Then
                    _references = New List(Of WeakReference)()
                End If

                If <%= Info.ObjectName %>.SingleInstanceSavedHandler Then
                    _references.Clear()
                End If

                If Not Found(obj) Then
                    _references.Add(New WeakReference(obj))
                End If

                If mustRegister Then
                    AddHandler <%= Info.UpdaterType %>.<%= Info.UpdaterType %>Saved, AddressOf <%= Info.UpdaterType %>SavedHandler
                End If
            End Sub

            ''' <summary>
            ''' Handles Saved events of <see cref="<%= Info.UpdaterType %>"/>.
            ''' </summary>
            ''' <param name="sender">The sender of the event.</param>
            ''' <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            Public Shared Sub <%= Info.UpdaterType %>SavedHandler(ByVal sender As Object, ByVal e As Csla.Core.SavedEventArgs)
                For Each reference As WeakReference In _references
                    If reference.IsAlive Then
                        CType(reference.Target, <%= Info.ObjectName %>).<%= Info.UpdaterType %>SavedHandler(sender, e)
                    End If
                Next reference
            End Sub

            ''' <summary>
            ''' Removes event handling and clears all registered <%= Info.ObjectName %> instances.
            ''' </summary>
            Public Shared Sub Unregister()
                RemoveHandler <%= Info.UpdaterType %>.<%= Info.UpdaterType %>Saved, AddressOf <%= Info.UpdaterType %>SavedHandler
                _references = Nothing
            End Sub
        End Class

        #End Region

    <%
}
%>
