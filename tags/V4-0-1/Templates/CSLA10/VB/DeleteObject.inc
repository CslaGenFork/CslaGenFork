
		''' <summary>
		''' Marks the <see cref="<%=Info.ObjectName%>" /> object for deletion. The object will be deleted as part of the next save operation.
		''' </summary>
		Public Shared Sub Delete<%=Info.ObjectName%>(<%
		first = True
		For Each param As Parameter In Info.DeleteObjectParameters
			If Not first Then
				writer.Write(", ")
			Else
				first = false
			End If
		%>ByVal <%=FormatCamel(param.Property.Name)%> As <%=param.Property.PropertyType.ToString()%><%
		Next %>)

			<% If Info.DeleteRoles <> String.Empty Then 
				Dim deleteRoles() As String = System.Text.RegularExpressions.Regex.Split(Info.DeleteRoles, ";")
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
			<% If Info.DeleteObjectParameters.Count > 0 Then
				Dim crit As Criteria = Info.DeleteObjectParameters(0).Criteria
				Dim critVar As string = FormatCamel(crit.Name)
			%>
			
			Dim <%=critVar%> As New <%=crit.Name%>(<% 
			If Info.ObjectType = CslaObjectType.EditableSwitchable Then
				%>False<%
			End If %>)
			<% For Each param As Parameter In Info.DeleteObjectParameters %>
			<%=critVar%>.<%=param.Property.Name%> = <%=FormatCamel(param.Property.Name)%>
			<% Next %>
			DataPortal.Delete(<%=critVar%>)
			<% Else %>
			'
			<% End If %>
			
		End Sub 
