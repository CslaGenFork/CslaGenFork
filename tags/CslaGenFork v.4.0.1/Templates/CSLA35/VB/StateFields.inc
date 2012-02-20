		
#Region " State Fields "
		<% 
			' Value Properties
			For Each prop As ValueProperty In Info.ValueProperties 
				If PropertyMode <> CslaPropertyMode.Managed OrElse prop.DbBindColumn.NativeType = "timestamp" Then 
					If Not prop.Undoable Then %>
		<NotUndoable()> _
		<% End If %>
		Protected <%=FormatFieldName(prop.Name)%> As <%=GetDataType(prop)%> = <%=GetInitValue(prop)%>
		<%
				End If
				If PropertyMode <> CslaPropertyMode.Standard Then %>
		Protected Shared <%=FormatManaged(prop.Name)%> As PropertyInfo(Of <%=GetDataType(prop)%>) = RegisterProperty(Of <%=GetDataType(prop)%>)(Function(o) o.<%=FormatPascal(prop.Name)%>, "<%=prop.FriendlyName%>")
<%
				End If
			Next 
			
			' If object has Child properties, then add new line
			If Info.ChildProperties.Count > 0 OrElse Info.ChildCollectionProperties.Count > 0 Then %><%= vbCrLf %><% End If
			
			' Child Properties
			For Each prop As ChildProperty In Info.GetMyChildProperties() %>
		
		<%
		Dim _child as CslaObjectInfo = FindChildInfo(Info, prop.TypeName)
		Dim _fieldParentReference as Boolean = False
		If _child Is Nothing Then
			Errors.Append("	Warning: TypeName '" & prop.TypeName & "' doesn't exist in this project")
			Errors.Append(vbCrLf)
		Else
			_fieldParentReference = _child.AddParentReference
		
		End If
		If ActiveObjects Then %>
		<RegisterNotify("IsValid, IsDirty, BrokenRulesChanged")> _
		<% End If 
		If Not prop.Undoable Then %>
		<NotUndoable()> _
		<% End If %>
		Private Shared <%=FormatManaged(prop.Name)%> As PropertyInfo(Of <%=prop.TypeName%>) = RegisterProperty(New PropertyInfo(Of <%=prop.TypeName%>)("<%=FormatPascal(prop.Name)%>"))
		<% Next %>
		
#End Region
