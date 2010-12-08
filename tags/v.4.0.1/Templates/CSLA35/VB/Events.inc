
#Region " Events "

<%
    If Info.HasGetCriteria Then 
    %>
    Partial Private Sub OnFetchPre(ByVal args As DataPortalHookArgs)
    End Sub
    Partial Private Sub OnFetchPost(ByVal args As DataPortalHookArgs)
    End Sub
    <%
    End If
    If Info.ObjectType <> CslaObjectType.ReadOnlyObject And Info.ObjectType <> CslaObjectType.NameValueList And Info.ObjectType.ToString().IndexOf("Collection") = -1 Then 
    %>
	Partial Private Sub OnUpdatePre(ByVal args As DataPortalHookArgs)
	End Sub
	Partial Private Sub OnUpdatePost(ByVal args As DataPortalHookArgs)
	End Sub
	Partial Private Sub OnInsertPre(ByVal args As DataPortalHookArgs)
	End Sub
	Partial Private Sub OnInsertPost(ByVal args As DataPortalHookArgs)
	End Sub
	Partial Private Sub OnDeletePre(ByVal args As DataPortalHookArgs)
	End Sub
	Partial Private Sub OnDeletePost(ByVal args As DataPortalHookArgs)
	End Sub
	<%
    End If 
    If Info.ObjectType.ToString().IndexOf("Collection") = -1 And Info.ObjectType <> CslaObjectType.NameValueList Then %>
	Partial Private Sub OnFetchRead(ByVal args As DataPortalHookArgs)
	End Sub
	<%
    End If
    If Info.ObjectType = CslaObjectType.EditableRoot Or Info.ObjectType = CslaObjectType.EditableChild Or Info.ObjectType = CslaObjectType.EditableSwitchable Then %>
	Partial Private Sub OnCreate(ByVal args As DataPortalHookArgs)
	End Sub
	<%
    End If
    If Info.ObjectType = CslaObjectType.EditableChildCollection Then %>
	Partial Private Sub OnUpdatePre(ByVal args As DataPortalHookArgs)
	End Sub
	Partial Private Sub OnUpdatePost(ByVal args As DataPortalHookArgs)
	End Sub
	<%
    End If 
	%>
	
#End Region
