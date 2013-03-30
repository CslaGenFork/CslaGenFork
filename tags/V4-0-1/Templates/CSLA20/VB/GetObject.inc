
<% 
If Not Info.UseCustomLoading Then
	For Each c As Criteria In Info.CriteriaObjects
	If c.GetOptions.Factory Then
%>
		''' <summary>
		''' Factory method. New <see cref="<%=Info.ObjectName%>" /> object is loaded from the database, based on given parameters.
		''' </summary>
		<%
				Dim strGetParams as String = String.Empty
				Dim strGetCritParams as String = String.Empty
				For i As Integer = 0 To c.Properties.Count - 1
					If i > 0 Then
						strGetParams &= ", "
						strGetCritParams &= ", "
					End If
					strGetParams &= String.Concat("ByVal ", FormatCamel(c.Properties(i).Name), " As ", GetDataType(c.Properties(i)))
					strGetCritParams &= FormatCamel(c.Properties(i).Name)
				Next
		%>
		Public Shared Function Get<%=Info.ObjectName%><%=c.GetOptions.FactorySuffix.Trim()%>(<%=strGetParams%>) As <%=Info.ObjectName%>
			<% If Info.GetRoles.Trim() <> String.Empty Then %>
			If Not CanGetObject() Then
				Throw New System.Security.SecurityException( _
					"User not authorized to load a <%= Info.ObjectName %>")
			End If
			<% End If %>
			<% 	If Info.ObjectType = CslaObjectType.EditableSwitchable Then
					strGetCritParams = "False, " & strGetCritParams
				End If
				%>
			Return <% If ActiveObjects Then %>ActiveObjects.<% End If %>DataPortal.Fetch(Of <%=Info.ObjectName %>)(New <%=c.Name%>(<%=strGetCritParams %>))
		End Function
<%
	End If
	Next
End If %>
