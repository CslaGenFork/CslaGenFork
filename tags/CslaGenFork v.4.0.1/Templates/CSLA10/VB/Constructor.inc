		
#Region " Constructors "
		
		Protected Sub New()
			' Prevent direct creation
			<% If ActiveObjects Then %>
				<% If Info.ObjectType.ToString.ToLower.IndexOf("collection") = -1 Then %>
			AddBusinessRules()
					<% If Info.ObjectType.ToString.ToLower.IndexOf("child") = -1 Then %>
			RegisterAndSubscribe()
					<% End If %>
				<% End If %>
			<% End If %>
			<%	If Info.ValueProperties.Count > 0 Then 
					first = True 
					For Each prop As ValueProperty In Info.ValueProperties
						If prop.DefaultValue.Length > 0 Then 
							If first Then %>
			
			' Set defaults for properties
			<% 					first = False 
			   				End If %>
			<%=prop.Name%> = <%=prop.DefaultValue%>
			<%			End If
			   		Next 
				End If %>
			<%	If Info.ObjectType = CslaObjectType.EditableChild OrElse Info.ObjectType = CslaObjectType.EditableChildCollection Then %>
			
			' Show the framework that this is a child object
			MarkAsChild()
			<%	End If %>
			<%	If Info.ObjectType = CslaObjectType.EditableRootCollection OrElse Info.ObjectType = CslaObjectType.EditableChildCollection OrElse Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>
			
			' Allow this collection to be sorted
			AllowSort = True
			<%	End If %>
		End Sub
		<% If Info.NewObjectParameters.Count > 0 Then %>
		
		Protected Sub New(<%
			first = True
			For Each param As Parameter In Info.NewObjectParameters
				If Not first Then
					%>, <%
				Else
					first = False
				End If
			%>ByVal <%=FormatCamel(param.Property.Name)%> As <%=param.Property.PropertyType.ToString()%><%
			Next %>)
			Me.New()
			
			<% For Each param As Parameter In Info.NewObjectParameters %>
			<%=FormatFieldName(param.Property.Name)%> = <%=FormatCamel(param.Property.Name)%>
			<% Next %>
		End Sub
		<% End If %>
		
#End Region
