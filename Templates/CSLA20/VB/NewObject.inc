
		<% 
For Each c As Criteria In Info.CriteriaObjects 
	If c.CreateOptions.Factory Then 
		Dim strNewParams as String = String.Empty
		Dim strNewCritParams as String = String.Empty
		For i As Integer = 0 To c.Properties.Count - 1
			If i > 0 Then
				strNewParams &= ", "
				strNewCritParams &= ", "
			End If
			strNewParams &= String.Concat("ByVal ", FormatCamel(c.Properties(i).Name), " As ", GetDataType(c.Properties(i)))
			strNewCritParams &= FormatCamel(c.Properties(i).Name)
		Next %>
		''' <summary>
		''' Factory method. New <see cref="<%=Info.ObjectName%>" /> object is created, based on given parameters.
		''' </summary>
<%If Info.ObjectType = CslaObjectType.EditableChild Then 
		%>	
		Friend <% Else %>		Public<% End If %> Shared Function New<%=Info.ObjectName%><%=c.CreateOptions.FactorySuffix.Trim()%>(<%= strNewParams %>) As <%=Info.ObjectName%>
			<% If Info.NewRoles <> String.Empty Then %>
			If Not CanAddObject() Then
				Throw New System.Security.SecurityException( _
					"User not authorized to add a <%= Info.ObjectName %>")
			End If
			<% End If %>
			<% If Info.ObjectType = CslaObjectType.EditableSwitchable Then
					If strNewCritParams.Length > 0 Then
						strNewCritParams = "False, " & strNewCritParams
					Else
						strNewCritParams = "False" 
					End If
				End If
			%>
			Return <% If ActiveObjects Then %>ActiveObjects.<% End If %>DataPortal.Create(Of <%= Info.ObjectName %>)(New <%= c.Name %>(<%= strNewCritParams %>))
		End Function
<% 	End If 
Next %>
