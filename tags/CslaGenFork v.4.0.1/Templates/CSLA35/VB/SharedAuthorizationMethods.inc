
#Region " Authorization "

		Public Shared Sub AddObjectAuthorizationRules()
		<% If Info.GetRoles.Trim() <> String.Empty Then %>
			Csla.Security.AuthorizationRules.AllowGet(GetType(<%= Info.ObjectName %>)<% 
			Dim roles() As String = System.Text.RegularExpressions.Regex.Split(Info.GetRoles, ";")
			For Each role As String In roles %>, "<%= role %>"<% Next %>)
		<% End If %>
		<% If Info.NewRoles.Trim() <> String.Empty Then %>
			Csla.Security.AuthorizationRules.AllowCreate(GetType(<%= Info.ObjectName %>)<% 
			Dim roles() As String = System.Text.RegularExpressions.Regex.Split(Info.NewRoles, ";")
			For Each role As String In roles %>, "<%= role %>"<% Next %>)
		<% End If %>
		<% If Info.DeleteRoles.Trim() <> String.Empty Then %>
			Csla.Security.AuthorizationRules.AllowDelete(GetType(<%= Info.ObjectName %>)<% 
			Dim roles() As String = System.Text.RegularExpressions.Regex.Split(Info.DeleteRoles, ";")
			For Each role As String In roles %>, "<%= role %>"<% Next %>)
		<% End If %>
		<% If Info.UpdateRoles.Trim() <> String.Empty Then %>
			Csla.Security.AuthorizationRules.AllowEdit(GetType(<%= Info.ObjectName %>)<% 
			Dim roles() As String = System.Text.RegularExpressions.Regex.Split(Info.UpdateRoles, ";")
			For Each role As String In roles %>, "<%= role %>"<% Next %>)
		<% End If %>
		End Sub
		
#End Region

