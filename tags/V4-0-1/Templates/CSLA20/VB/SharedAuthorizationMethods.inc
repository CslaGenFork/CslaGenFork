
#Region " Authorization "


		Public Shared Function CanGetObject() As Boolean
		<% If Info.GetRoles.Trim() <> String.Empty Then %>
			<% Dim getRoles() As String = System.Text.RegularExpressions.Regex.Split(Info.GetRoles, ";")
			For Each role As String In getRoles %>
			If Csla.ApplicationContext.User.IsInRole("<%=role.Trim()%>") Then
				Return True
			End If
			<% Next %>
			Return False
		<% Else %>
			Return True
		<% End If %>
		End Function
		
	<% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection AndAlso _
			Info.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso _ 
			Info.ObjectType <> CslaObjectType.NameValueList Then %>
		Public Shared Function CanDeleteObject() As Boolean
		<% If Info.DeleteRoles.Trim() <> String.Empty Then %>
		<% Dim DeleteRoles() As String = System.Text.RegularExpressions.Regex.Split(Info.DeleteRoles, ";")
			For Each role As String In DeleteRoles %>
			If Csla.ApplicationContext.User.IsInRole("<%=role.Trim()%>") Then
				Return True
			End If
			<% Next %>
			Return False
		<% Else %>
			Return True
		<% End If %>
		End Function
		
		
		Public Shared Function CanAddObject() As Boolean
		<% If Info.NewRoles.Trim() <> String.Empty Then %>
		<% 	Dim NewRoles() As String = System.Text.RegularExpressions.Regex.Split(Info.NewRoles, ";")
				For Each role As String In NewRoles %>
			If Csla.ApplicationContext.User.IsInRole("<%=role.Trim()%>") Then
				Return True
			End If
			<% Next %>
			Return False
		<% Else %>
			Return True
		<% End If %>
		End Function
		
		
		Public Shared Function CanEditObject() As Boolean
		<% If Info.UpdateRoles.Trim() <> String.Empty Then %>
		<% 	Dim UpdateRoles() As String = System.Text.RegularExpressions.Regex.Split(Info.UpdateRoles, ";")
				For Each role As String In UpdateRoles %>
			If Csla.ApplicationContext.User.IsInRole("<%=role.Trim()%>") Then
				Return True
			End If
			<% Next %>
			Return False
		<% Else %>
			Return True
		<% End If %>
		End Function
		
	<% End If %>
#End Region

