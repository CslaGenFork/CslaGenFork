
		<% If Info.FindMethodsParameters.Count > 0 Then %>
		
#Region " Find Methods "

		<% For Each prop As Metadata.Property In Info.FindMethodsParameters %>
		''' <summary>
		''' Find a <see cref="<%=Info.ItemType%>" /> object in the <see cref="<%=Info.ObjectName%>" /> collection, based on given <%=prop.Name%>.
		''' </summary>
		Public Function Find<%=Info.ItemType%>By<%=prop.Name%>(ByVal <%=FormatCamel(prop.Name)%> As <%=GetDataType(prop)%>) As <%=Info.ItemType%>
			For i as Integer = 0 To Me.Count - 1
				If Me(i).<%=prop.Name%>.Equals(<%=FormatCamel(prop.Name)%>) Then
					Return Me(i)
				End If
			Next
			Return Nothing
		End Function
		
		<% Next %>
#End Region

		<% End If %>

