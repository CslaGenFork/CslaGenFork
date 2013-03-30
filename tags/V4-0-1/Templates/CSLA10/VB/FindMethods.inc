		
		<% If Info.FindMethodsParameters.Count > 0 Then %>
#Region " Find Methods "

		<% For Each prop As Metadata.Property In Info.FindMethodsParameters %>
		''' <summary>
		''' Find a <see cref="<%=Info.ItemType%>" /> object in the <see cref="<%=Info.ObjectName%>" /> collection, based on given <%=prop.Name%>.
		''' </summary>
		Public Function Find<%=Info.ItemType%>By<%=prop.Name%>(ByVal <%=FormatCamel(prop.Name)%> As <%=prop.PropertyType.ToString()%>) As <%=Info.ItemType%>
			For Each obj As <%=Info.ItemType%> In MyBase.List
				If obj.<%=prop.Name%><% If prop.PropertyType = CslaGenerator.Metadata.TypeCodeEx.Guid or prop.PropertyType = CslaGenerator.Metadata.TypeCodeEx.SmartDate Then %>.Equals(<%=FormatCamel(prop.Name)%>)<% Else %> = <%= FormatCamel(prop.Name)%><% End If %> Then
					Return obj
				End If
			Next
			Return Nothing
		End Function
		
		<% Next %>
#End Region
		<% End If %>
