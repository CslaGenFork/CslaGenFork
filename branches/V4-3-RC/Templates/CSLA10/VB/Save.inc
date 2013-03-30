		<% If Info.DeleteRoles <> String.Empty OrElse Info.UpdateRoles <> String.Empty Then 
			Dim deleteRoles() As String = System.Text.RegularExpressions.Regex.Split(Info.DeleteRoles, ";")
			Dim updateRoles() As String = System.Text.RegularExpressions.Regex.Split(Info.UpdateRoles, ";")
		%>
		
		''' <summary>
		''' Saves the <%=Info.ObjectName%> to the database.
		''' <summary>
		Public Overrides Function Save() As BusinessBase
			
			If IsDeleted Then
				<% If Info.DeleteRoles <> String.Empty Then 
					first = True %>
				If <% For Each role As String In deleteRoles 
						If Not first Then %> AndAlso _
				   <% 	Else
							first = False 
						End If %>Not System.Threading.Thread.CurrentPrincipal.IsInRole("<%=role%>")<%
					   Next %> Then
						Throw New System.Security.SecurityException("User not authorized to remove a <%=Info.ObjectName%>")
				End If
				<% End If %>
				
			Else
				' No deletion - we're adding or updating
				<% If Info.UpdateRoles <> String.Empty Then 
					first = True %>
				If <% For Each role As String In updateRoles 
						If Not first Then %> AndAlso _
				   <% 	Else
							first = False
						End If %>Not System.Threading.Thread.CurrentPrincipal.IsInRole("<%=role%>")<%
					   Next %> Then
						Throw New System.Security.SecurityException("User not authorized to update a <%=Info.ObjectName%>")
				End If
				<% End If %>
				
			End If
			
			Return MyBase.Save
			
		End Function
		<% End If %>