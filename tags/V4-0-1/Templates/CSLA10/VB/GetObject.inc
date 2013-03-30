		
		''' <summary>
		''' Factory method. New <see cref="<%=Info.ObjectName%>" /> object is loaded from the database, based on given parameters.
		''' </summary>
		Public Shared Function Get<%=Info.ObjectName%>(<%
		first = True
		For Each param As Parameter In Info.GetObjectParameters
			If Not first Then
				writer.Write(", ")
			Else 
				first = False
			End If
		%>ByVal <%=FormatCamel(param.Property.Name)%> As <%=param.Property.PropertyType.ToString()%><% 
		Next %>) As <%=Info.ObjectName%>

			<% If Info.GetRoles <> String.Empty Then 
				Dim getRoles() As String = System.Text.RegularExpressions.Regex.Split(Info.GetRoles, ";")
				first = True %>
			If <% For Each role As String In getRoles 
					If Not first Then %> AndAlso _
			   <% 	Else
						first = False 
					End If %>Not System.Threading.Thread.CurrentPrincipal.IsInRole("<%=role%>")<%
				   Next %> Then
					Throw New System.Security.SecurityException("User not authorized to load a <%=Info.ObjectName%>")
			End If
			
			<% End If %>
			<% If Info.GetObjectParameters.Count > 0 Then
				Dim crit As Criteria = Info.GetObjectParameters(0).Criteria
				Dim critVar As string = FormatCamel(crit.Name)
			%>
			Dim <%=critVar%> As New <%=crit.Name%>(<% 
			If Info.ObjectType = CslaObjectType.EditableSwitchable Then
			%>False<%
			End If%>)
			<% For Each param As Parameter In Info.GetObjectParameters %>
			<%=critVar%>.<%=param.Property.Name%> = <%=FormatCamel(param.Property.Name)%>
			<% Next %>
			
			Return DirectCast(DataPortal.Fetch(<%=critVar%>), <%=Info.ObjectName%>)
			<% ElseIf Info.GetObjectCriteriaType Is Nothing = False Then %>
			Return DirectCast(DataPortal.Fetch(New <%=Info.GetObjectCriteriaType.Name%>), <%=Info.ObjectName%>)
			<% Else %>
			Return DataPortal.Fetch()
			<% End If %>
			
		End Function
