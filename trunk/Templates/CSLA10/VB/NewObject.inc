
		''' <summary>
		''' Factory method. New <see cref="<%=Info.ObjectName%>" /> object is created, based on given parameters.
		''' </summary>
		<% If Info.ObjectType = CslaObjectType.EditableChild Then %>Friend<% Else %>Public<% End If %> Shared Function New<%=Info.ObjectName%>(<%
		first = True
		For Each param As Parameter In Info.NewObjectParameters
			If Not first Then
				writer.Write(", ")
			Else
				first = False
			End If
		%>ByVal <%=FormatCamel(param.Property.Name)%> As <%=param.Property.PropertyType.ToString()%><%
		Next %>) As <%=Info.ObjectName%>
			
			<% If Info.NewRoles <> String.Empty Then 
				Dim newRoles() As String = System.Text.RegularExpressions.Regex.Split(Info.NewRoles, ";")
				first = True %>
			If <% For Each role As String In newRoles 
					If Not first Then %> AndAlso _
			   <% 	Else
						first = False 
					End If %>Not System.Threading.Thread.CurrentPrincipal.IsInRole("<%=role%>")<%
				   Next %> Then
					Throw New System.Security.SecurityException("User not authorized to create a <%=Info.ObjectName%>")
			End If
			
			<% End If %>
			Dim <%=FormatCamel(Info.ObjectName)%> As New <%=Info.ObjectName%>
			<%
			For Each param As Parameter In Info.NewObjectParameters%>
			<%=FormatCamel(Info.ObjectName)%>.<%=FormatFieldName(param.Property.Name)%> = <%=FormatCamel(param.Property.Name)%>
			<% Next %>
			Return <%=FormatCamel(Info.ObjectName)%>
			
		End Function
