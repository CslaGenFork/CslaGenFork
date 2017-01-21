        #Region " Private Fields "

        Private Shared _list As <%= Info.ObjectName %>

        #End Region

        #Region " Cache Management Methods "

        ''' <summary>
        ''' Clears the in-memory <%= Info.ObjectName %> cache so it is reloaded on the next request.
        ''' </summary>
        Public Shared Sub InvalidateCache()
            <%
    if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
        CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
        Info.GetRoles.Trim() != String.Empty)
    {
        %>If Not CanGetObject() Then
                Throw New System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.")
          End If
            <%
    }
        %>_list = Nothing
        End Sub

        ''' <summary>
        ''' Used by async loaders to load the cache.
        ''' </summary>
        ''' <param name="lst">The list to cache.</param>
        Friend Shared Sub SetCache(lst As <%= Info.ObjectName %>)
            _list = lst
        End Sub

        Friend Shared ReadOnly Property IsCached As Boolean
            Get
                Return _list IsNot Nothing
            End Get
        End Property

        #End Region
