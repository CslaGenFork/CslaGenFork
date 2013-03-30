
<% If Info.DeleteRoles.Trim() <> String.Empty OrElse _
		Info.UpdateRoles.Trim() <> String.Empty OrElse _
		Info.NewRoles.Trim() <> String.Empty Then %>
		
		''' <summary>
		''' Saves the <%=Info.ObjectName%> to the database.
		''' </summary>
		Public Overrides Function Save() As <%=Info.ObjectName%>
			<% If Info.ObjectType <> CslaObjectType.EditableRootCollection
      %>If IsDeleted AndAlso Not CanDeleteObject() Then
				Throw New System.Security.SecurityException( _
					"User not authorized to remove a <%= Info.ObjectName %>")
			ElseIf IsNew AndAlso Not CanAddObject() Then
				Throw New System.Security.SecurityException( _
					"User not authorized to add a <%=Info.ObjectName%>")
			Else<%
      End If %>If Not CanEditObject() Then
				Throw New System.Security.SecurityException( _
					"User not authorized to update a <%=Info.ObjectName%>")
			End If
			Return MyBase.Save()
		End Function
		
<% End If %>
