		
#Region " State Fields "
		<% 
			' Value Properties
			For Each prop As ValueProperty In Info.ValueProperties %><% If Not prop.Undoable Then%>
		<NotUndoable()> _<% End If %>
		Protected <%=FormatFieldName(prop.Name)%> As <%=prop.PropertyType.ToString()%> = <%=GetInitValue(prop.PropertyType)%><%
			Next 
			
			' If object has Child properties, then add new line
			If Info.ChildProperties.Count > 0 OrElse Info.ChildCollectionProperties.Count > 0 Then %><%= vbLf %><% End If
			
			' Child Properties
			For Each prop As ChildProperty In Info.GetMyChildProperties() %>
    
		<% If ActiveObjects Then %><RegisterNotify("IsValid, IsDirty")>  <% End If %>Protected <%=FormatFieldName(prop.Name)%> As <%=prop.TypeName%> = New <%=prop.TypeName%>()<% 
			If prop.LazyLoad Then %>
		Private <%=FormatFieldName(prop.Name + "Loaded")%> As Boolean = False<% End If 
			Next %>
		
#End Region
