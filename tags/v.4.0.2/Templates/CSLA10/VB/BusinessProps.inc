      
#Region " Business Properties and Methods "
		<% If Info.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso (Info.ChildProperties.Count > 0 OrElse Info.ChildCollectionProperties.Count > 0) AndAlso Info.ObjectType <> CslaObjectType.ReadOnlyCollection  Then %>
		
		''' <summary>
		''' Returns True if the object is currently valid, False if the object or its children has broken rules.
		''' </summary>
		Public Overrides ReadOnly Property IsValid As Boolean
			Get
				' If the Business Object has Children, We Need to check it 
				' with an AndAlso Child.IsValid clause with the Base As well
				Return MyBase.IsValid<%
				For Each prop As ChildProperty In Info.ChildProperties 
				%> AndAlso <%=FormatPascal(prop.Name) %>.IsValid<% 
				Next
				For Each prop As ChildProperty In Info.ChildCollectionProperties 
				%> AndAlso <%=FormatPascal(prop.Name) %>.IsValid<% 
				Next %>
			End Get
		End Property

		''' <summary>
		''' Returns True if this object's data has been changed.
		''' </summary>
		Public Overrides ReadOnly Property IsDirty As Boolean
			Get
				' If the Business Object has Children, We Need to check it 
				' with an OrElse Child.IsDirty clause with the Base As well
				Return MyBase.IsDirty<%
				For Each prop As ChildProperty In Info.ChildProperties
				%> OrElse <%=FormatPascal(prop.Name) %>.IsDirty<% 
				Next
				For Each prop As ChildProperty In Info.ChildCollectionProperties 
				%> OrElse <%=FormatPascal(prop.Name) %>.IsDirty<% 
				Next%>
			End Get
		End Property
		<% End If %>
		
		<% IndentLevel = 2 %>
		<% For Each prop As ValueProperty In Info.ValueProperties %>
		<% If prop.Summary <> String.Empty Then %>
		''' <summary>
<%= GetXmlCommentString(prop.Summary) %>
		''' </summary>
		<% End If %>
		<% If prop.Remarks <> String.Empty Then %>
		''' <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
		''' </remarks>
		<% End If %>
		Public<% If Info.ObjectType = CslaObjectType.ReadOnlyObject OrElse prop.ReadOnly Then %> ReadOnly<% End If %> Property <%=FormatPascal(prop.Name)%> As <% If prop.PropertyType = TypeCodeEx.SmartDate And Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>String<% Else %><%=prop.PropertyType.ToString()%><% End If %>
			Get 
				Return <%=FormatFieldName(prop.Name)%><% If prop.PropertyType = TypeCodeEx.SmartDate AndAlso Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>.Text<% End If %>
			End Get
			<% If Info.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso prop.ReadOnly = False Then %>
			Set (ByVal value As <% If prop.PropertyType = TypeCodeEx.SmartDate And Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>String<% Else %><%=prop.PropertyType.ToString()%><% End If %>)
				<% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>If <%=FormatFieldName(prop.Name)%><% If prop.PropertyType = TypeCodeEx.SmartDate AndAlso Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>.Text<% End If %> <> value Then<% End If %>
					<%=FormatFieldName(prop.Name)%><% If prop.PropertyType = TypeCodeEx.SmartDate AndAlso Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>.Text<% End If %> = value
					<% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then 
						If ActiveObjects = False Then %>
					<% If prop.Rules.Count > 0 Then %>CheckRules("<%=prop.Name%>")<% End If %>
					  MarkDirty()
					<% else %>
					PropertyChange("<%=FormatPascal(prop.Name)%>",<%=FormatFieldName(prop.Name)%>)
					<% 	End If 
					End If %>
				<% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>End If<% End If%>
			End Set
			<% End If %>
		End Property
      
		<% Next %>
		<% For Each prop As ChildProperty In Info.GetMyChildProperties() %>
		<% If prop.Summary <> String.Empty Then %>
		''' <summary>
<%= GetXmlCommentString(prop.Summary) %>
		''' </summary>
		<% End If %>
		<% If prop.Remarks <> String.Empty Then %>
		''' <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
		''' </remarks>
		<% End If %>
		Public<% If Info.ObjectType = CslaObjectType.ReadOnlyObject OrElse prop.ReadOnly Then %> ReadOnly<% End If %> Property <%=FormatPascal(prop.Name)%> As <%=prop.TypeName%>
			Get  
				<% If prop.LazyLoad Then %>
				If Not <%=FormatFieldName(prop.Name + "Loaded")%> Then
					<%=FormatFieldName(prop.Name)%> = <%=prop.Name%>.Get<%=prop.TypeName%>(<%
					first = True
					For Each p As Parameter In prop.LoadParameters
						If Not first Then
							%>, <%
						Else 
							first = False 
						End If 
					%><%=p.Property.Name%><% 
					Next %>)
					<%=FormatFieldName(prop.Name + "Loaded")%> = True
				End If
				<% End If %>
				Return <%=FormatFieldName(prop.Name)%>
			End Get
			<% If Info.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso prop.ReadOnly = False Then %>
			Set (value As <%=prop.TypeName%>)
				<%=FormatFieldName(prop.Name)%> = value
			End Set
			<% End If %>
		End Property
		
		<% Next %>
#End Region
