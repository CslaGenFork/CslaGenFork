<% 
For Each c As Criteria In Info.CriteriaObjects 
	If c.DeleteOptions.Factory Then%>
		''' <summary>
		''' Marks the <see cref="<%=Info.ObjectName%>" /> object for deletion. The object will be deleted as part of the next save operation.
		''' </summary><%
				Dim strDelParams as String = String.Empty
				Dim strDelCritParams as String = String.Empty
				Dim UpdateEventString_Delete as String = String.Empty
				For i As Integer = 0 To c.Properties.Count - 1
					If i > 0 Then
						strDelParams &= ", "
						strDelCritParams &= ", "
					End If
					strDelParams &= String.Concat("ByVal ", FormatCamel(c.Properties(i).Name), " As ", GetDataType(c.Properties(i)))
					strDelCritParams &= FormatCamel(c.Properties(i).Name)
				Next
				If (c.Properties.Count > 1) then
					UpdateEventString_Delete = "new object() {" & strDelCritParams & "}"
				else
					UpdateEventString_Delete = strDelCritParams
				End If
    %>
		Public Shared Sub Delete<%=Info.ObjectName%><%=c.DeleteOptions.FactorySuffix.Trim()%>(<%=strDelParams %>)
			<% If Info.DeleteRoles <> String.Empty Then %>
				If Not CanDeleteObject() Then
					Throw New System.Security.SecurityException( _
						"User not authorized to remove a <%= Info.ObjectName %>")
				End If
			<% End If %>
			<% 	If Info.ObjectType = CslaObjectType.EditableSwitchable Then
						If Not strDelCritParams.Equals(String.Empty) Then
							strDelCritParams = ", " & strDelCritParams
						End If
						strDelCritParams = "False" & strDelCritParams
					End If
				%>
			<% If ActiveObjects Then %>ActiveObjects.<% End If %>DataPortal.Delete(New <%=c.Name %>(<%=strDelCritParams %>))
			<% If ActiveObjects Then
				If Info.PublishToChannel.Length > 0 Then %>
			Observer.EventChannels.Publish("<%= Info.PublishToChannel %>", Nothing, BusinessEvents.Deleted, <%= UpdateEventString_Delete %>)
			<% 	End If
			   End If %>
		End Sub
<% 	End If
Next %>
 
