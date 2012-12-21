
		''' <summary>
		''' Factory method. New <see cref="<%=Info.ObjectName%>" /> object is created and loaded from the given SafeDataReader.
		''' </summary>
		Friend Shared Function Get<%=Info.ObjectName%>(ByVal dr As SafeDataReader) As <%=Info.ObjectName%> 
		
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
			Dim <%=FormatCamel(Info.ObjectName)%> As New <%=Info.ObjectName%>
			<%=FormatCamel(Info.ObjectName)%>.Fetch(dr)
			Return <%=FormatCamel(Info.ObjectName)%>
			
		End Function
