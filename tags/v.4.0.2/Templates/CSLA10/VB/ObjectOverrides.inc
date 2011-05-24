      
#Region " System.Object Overrides "
		<% If Info.ToStringProperty Is Nothing = False AndAlso Info.ToStringProperty.Count > 0 Then %>
		
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
		<% End If 
		   If Info.EqualsProperty Is Nothing = False AndAlso Info.EqualsProperty.Count > 0 Then %>
		
		''' <summary>
		''' Determines whether two <see cref="<%=Info.ObjectName%>" /> instances are equal.
		''' </summary>
		Public Overloads Function Equals(ByVal obj As <%= Info.ObjectName %>) As Boolean
			' Implement Equals Method Needed
			If obj Is Nothing Then
				Return False
			End If
				
			Return <% 
			Dim firstLine As Boolean = True
			For Each prop As Metadata.Property In Info.EqualsProperty
				If Not firstLine Then
					%> AndAlso <%
				Else 
					firstLine = False
				End If
				%><%=prop.Name%> = obj.<%=prop.Name%><%
			Next%>
		End Function
		
		''' <summary>
		''' Shared method. Determines whether two <see cref="<%=Info.ObjectName%>" /> instances are equal.
		''' </summary>
		Public Overloads Shared Function Equals(ByVal objA As Object, ByVal objB As Object) As Boolean
			If TypeOf objA Is <%=Info.ObjectName%> AndAlso TypeOf objB Is <%=Info.ObjectName%> Then
				Return DirectCast(objA, <%=Info.ObjectName%>).Equals(DirectCast(objB, <%=Info.ObjectName%>))
			Else
				Return False
			End If
		End Function
		
		''' <summary>
		''' Object.Equals override. Determines whether two <see cref="<%=Info.ObjectName%>" /> instances are equal.
		''' </summary>
		Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
			If TypeOf obj Is <%=Info.ObjectName%> Then
				Return Me.Equals(DirectCast(obj, <%=Info.ObjectName%>))
			Else
				Return False
			End If
		End Function
		<% End If 
		   If Info.HashcodeProperty Is Nothing = False AndAlso Info.HashcodeProperty.Count > 0 Then %>
		
		''' <summary>
		''' Serves as a hash function for a <see cref="<%=Info.ObjectName%>" />, suitable for use in hashing algorithms and data structures like a hash table.
		''' </summary>
		Public Overrides Function GetHashCode() As Integer
			' Get Hashcode
			Return <% 
			Dim firstLine As Boolean = True
			For Each prop As Metadata.Property In Info.HashcodeProperty
				If Not firstLine Then
					%> Xor <%
				Else 
					firstLine = False
				End If
				%><%= prop.Name %>.GetHashCode()<%
			Next%>
		End Function
		<% End If %>
		
#End Region ' System.Object Overrides
