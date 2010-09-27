		
#Region " Business Properties and Methods "
		<% Dim ItemType as string = Info.ItemType %>
    <% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>
      <% ItemType = "Info" %>
    <%End If%>
    
		''' <summary>
		''' Gets the <see cref="<%=ItemType%>" /> from the specified index.
		''' </summary>
		Default Public ReadOnly Property Item(ByVal index As Integer) As <%= ItemType %>
			Get
				Return DirectCast(MyBase.List(index), <%=ItemType%>)
			End Get
		End Property
		<% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>
		
		''' <summary>
		''' Removes the <see cref="<%=ItemType%>" /> object from the <see cref="<%=Info.ObjectName%>" /> collection.
		''' </summary>
		Public Sub Remove(ByVal <%=FormatCamel(ItemType)%> As <%=ItemType %>)
		
			List.Remove(<%=FormatCamel(ItemType)%>)
			
		End Sub

		''' <summary>
		''' Add an <see cref="<%=ItemType%>" /> object to the <see cref="<%=Info.ObjectName%>" /> collection.
		''' </summary>
		Public Overridable Function Add(ByVal <%=FormatCamel(ItemType)%> As <%=ItemType%>) As <%=ItemType%>
		
			If Contains(<%=FormatCamel(ItemType)%>) OrElse ContainsDeleted(<%=ItemType%>) Then
				Throw New Exception("Object already exists in collection.")
			Else
				List.Add(<%=FormatCamel(ItemType)%>)
				Return <%=FormatCamel(ItemType)%>
			End If
		
		End Function
		<% Dim childInfo2 As CslaObjectInfo = FindChildInfo(Info, ItemType)
			If childInfo2.NewObjectParameters.Count > 0 Then %>
		''' <summary>
		''' Add new <see cref="<%=ItemType%>"/> object to the <%=Info.ObjectName%> collection.
		''' </summary>
		Public Overridable Function Add(<%
			first = True

			For Each param As Parameter In childInfo2.NewObjectParameters
				If Not first Then
					%>, <%
				Else
					first = False
				End If
				%>ByVal <%=FormatCamel(param.Property.Name)%> As <%=param.Property.PropertyType.ToString()%><%
			Next			
			%>) As <%=ItemType%>
			Dim <%=FormatCamel(ItemType)%> As <%=ItemType%> = <%=ItemType%>.New<%=ItemType%>(<%
			first = True
			For Each param As Parameter In childInfo2.NewObjectParameters
				If Not first Then
					%>, <%
				Else
					first = False
				End If
				%><%=FormatCamel(param.Property.Name)%><%
			Next						
			%>)
			Return Add(<%=FormatCamel(ItemType)%>)
			
		End Function
		<% End If %>
		<% End If %>
		
#End Region
