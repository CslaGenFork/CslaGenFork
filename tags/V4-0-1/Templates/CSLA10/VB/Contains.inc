		
#Region " Contains (Evaluate if the Object exists in Collection) "
		    

		''' <summary>
		''' Determines whether an <see cref="<%=Info.ItemType%>" /> object is in the <see cref="<%=Info.ObjectName%>" /> collection.
		''' </summary>
		Public Overloads Function Contains(ByVal item As <% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %><%= "Info" %><% Else %><%= Info.ItemType %><% End If %>) As Boolean
			For Each obj As <% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %><%= "Info" %><% Else %><%= Info.ItemType %><% End If %> In List
				If obj.Equals(item)
					Return True
				End If
			Next
			Return False
		End Function
		<% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>
		
		''' <summary>
		''' Determines whether an <see cref="<%=Info.ItemType%>" /> object is in the <see cref="<%=Info.ObjectName%>" /> collection, but it's been deleted.
		''' </summary>
		Public Overloads Function ContainsDeleted(ByVal item As <%=Info.ItemType %>) As Boolean
			For Each obj As <%=Info.ItemType %> In deletedList
				If obj.Equals(item)
					Return True
				End If
			Next
			Return False
		End Function
		<% End If %>
		
#End Region
