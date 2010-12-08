    
<% If Info.ToStringProperty Is Nothing = False AndAlso Info.ToStringProperty.Count > 0 AndAlso _
		Info.ObjectType <> CslaObjectType.ReadOnlyObject Then %>      
#Region " System.Object Overrides "

		
		''' <summary>
		''' Returns a string that represents a current <see cref="<%=Info.ObjectName%>" />
		''' </summary>
		Public Overrides Function ToString() As String
			' Return the Primary Key As a String
			Return <% 
			Dim firstLine As Boolean = True 
			For Each prop As Metadata.Property In Info.ToStringProperty
				If Not firstLine Then
					%> & ", " & <%
				Else 
					firstLine = False
				End If
				%><%=prop.Name %>.ToString()<%
			 Next%>
		End Function
		
       
#End Region

	<% End If %>
