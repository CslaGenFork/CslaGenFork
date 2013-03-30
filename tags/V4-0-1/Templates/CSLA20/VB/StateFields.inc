		
#Region " State Fields "
		<% 
			' Value Properties
			For Each prop As ValueProperty In Info.ValueProperties %><% If Not prop.Undoable Then%>
		<NotUndoable()> _<% End If %>
		Private <%=FormatFieldName(prop.Name)%> As <%=GetDataType(prop)%> = <%=GetInitValue(prop)%><%
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
		
		
		If ActiveObjects Then %>
		<RegisterNotify("IsValid, IsDirty, BrokenRulesChanged")> _
		<% End If 
		If Not prop.Undoable Then %>
		<NotUndoable()> _
		<% End If %>
		Private <%=FormatFieldName(prop.Name)%> As <%=prop.TypeName%><% If _child.ObjectType <> CslaObjectType.ReadOnlyObject And _child.ObjectType <> CslaObjectType.ReadOnlyCollection Then 
			%> = <%=prop.TypeName%>.New<%=prop.TypeName%>(<% If _fieldParentReference Then %>Me<% End If %>)<% End If %><% 
			If prop.LazyLoad Then %>
		Private <%=FormatFieldName(prop.Name + "Loaded")%> As Boolean = False<% End If 
		End If
			Next %>
		
#End Region
