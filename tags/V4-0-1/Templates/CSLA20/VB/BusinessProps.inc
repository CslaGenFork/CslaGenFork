      
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
				For Each prop As ChildProperty In Info.GetAllChildProperties()
					Dim _child as CslaObjectInfo = FindChildInfo(Info, prop.TypeName)
					If _child IsNot Nothing AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyCollection Then
					%> AndAlso <%=FormatPascal(prop.Name) %>.IsValid<% 
					End If
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
				For Each prop As ChildProperty In Info.GetAllChildProperties()
				Dim _child as CslaObjectInfo = FindChildInfo(Info, prop.TypeName)
					If _child IsNot Nothing AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso _child.ObjectType <> CslaObjectType.ReadOnlyCollection Then
				%> OrElse <%=FormatPascal(prop.Name) %>.IsDirty<% 
					End If
				Next %>
			End Get
		End Property
		<% End If %>
		
		<% IndentLevel = 2 %>
		<% For Each prop As ValueProperty In Info.ValueProperties 
		 If prop.Summary <> String.Empty Then %>
		''' <summary>
<%= GetXmlCommentString(prop.Summary) %>
		''' </summary>
		<% End If %>
		<% If prop.Remarks <> String.Empty Then %>
		''' <remarks>
<%= GetXmlCommentString(prop.Remarks) %>
		''' </remarks>
		<% End If %>
		<%= GetAttributesString(prop.Attributes) %>
		<% If prop.Access = Metadata.PropertyAccess.IsProtected Then %>Protected<%
		ElseIf prop.Access = Metadata.PropertyAccess.IsInternal Then %>Friend<% 
		ElseIf prop.Access = Metadata.PropertyAccess.IsProtectedInternal Then %>Protected Friend<%
		Else %>Public<%
		End If %><% If Info.ObjectType = CslaObjectType.ReadOnlyObject OrElse prop.ReadOnly Then %> ReadOnly<% End If %> Property <%=FormatPascal(prop.Name)%> As <% If prop.PropertyType = TypeCodeEx.SmartDate And Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>String<% Else %><%=GetDataType(prop)%><% End If %><% If Not prop.Implements.Trim().Equals(String.Empty) Then %> Implements <%= prop.Implements %><% End If %>
			Get 
				<% If Info.ObjectType <> CslaObjectType.ReadOnlyObject %>CanReadProperty("<%=FormatPascal(prop.Name)%>", True)
				<% End If %>Return <%=FormatFieldName(prop.Name)%><% If prop.PropertyType = TypeCodeEx.SmartDate AndAlso Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>.Text<% End If %>
			End Get
			<% If Info.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso prop.ReadOnly = False Then %>
			Set (ByVal value As <% If prop.PropertyType = TypeCodeEx.SmartDate And Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>String<% Else %><%=GetDataType(prop)%><% End If %>)
				CanWriteProperty("<%=FormatPascal(prop.Name)%>", True)
				<% If AllowNull(prop) Then %>
				<% If TypeHelper.IsNullableType(prop.PropertyType) Then %>
				If <%=FormatFieldName(prop.Name)%>.HasValue <> value.HasValue OrElse _
					(<%=FormatFieldName(prop.Name)%>.HasValue AndAlso value.HasValue AndAlso <%=FormatFieldName(prop.Name)%>.Value <> value.Value) Then
				<% Else %>
				If (<%=FormatFieldName(prop.Name)%> Is Nothing) <> (value Is Nothing) OrElse _
					(<%=FormatFieldName(prop.Name)%> IsNot Nothing AndAlso value IsNot Nothing AndAlso <% If prop.PropertyType = TypeCodeEx.ByteArray Then %>Not <%=FormatFieldName(prop.Name)%>.SequenceEqual(Value)<% Else %><%=FormatFieldName(prop.Name)%> <> value<% End If %>) Then
				<% End If %>
				<% ElseIf prop.PropertyType <> TypeCodeEx.ByteArray Then %>
				If <%=FormatFieldName(prop.Name)%><% If prop.PropertyType = TypeCodeEx.SmartDate Then %>.Text<% End If %> <> value Then
				<% Else %>
				Dim SetNewValue As Boolean = False
				If value IsNot Nothing And <%=FormatFieldName(prop.Name)%> Is Nothing Then
					SetNewValue = True
				End If
				If Not SetNewValue AndAlso value IsNot Nothing AndAlso <%=FormatFieldName(prop.Name)%> IsNot Nothing Then
					If <%=FormatFieldName(prop.Name)%>.Length <> value.Length Then
						SetNewValue=True
					Else
						Dim i As Integer = 0
						While i < value.Length
							If value(i) <> <%=FormatFieldName(prop.Name)%>(i) Then
								SetNewValue = True
								Exit While
							End If
							i += 1
						End While
					End If
				End If
				If SetNewValue Then
				<% End If %>
					<%=FormatFieldName(prop.Name)%><% If prop.PropertyType = TypeCodeEx.SmartDate Then %>.Text<% End If %> = value
					<% If prop.MarkDirtyOnChange Then %>
					PropertyHasChanged("<%=FormatPascal(prop.Name)%>")<% End If%>
				End If
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
				<% If prop.LazyLoad And prop.LoadingScheme <> LoadingScheme.None Then %>
				If Not <%=FormatFieldName(prop.Name + "Loaded")%> Then
					<%=FormatFieldName(prop.Name)%> = <%=prop.TypeName%>.Get<%=prop.TypeName%>(<%
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
		
     <% 	Dim strGetIdValue As String = String.Empty
			Dim SingleProperty As Boolean = True
		For Each prop As ValueProperty In Info.ValueProperties
			If prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.Default Then
				If strGetIdValue.Length > 0 Then
					strGetIdValue &= ".ToString() & ""!"" & "
					SingleProperty = False
				End If
				strGetIdValue &= FormatFieldName(prop.Name)
			End If
			If Not SingleProperty Then
				strGetIdValue &= ".ToString()"
			End If
		Next
		If strGetIdValue.Length > 0 Then %>	
		Protected Overrides Function GetIdValue() As Object
			Return <%= strGetIdValue %>
		End Function
		<% End If %>
		
		<% If info.HasNullableProperties Then %>
		Public Function GetNullableParameter(Of t As {Structure})(ByVal nullableValue As Nullable(Of t)) As Object
			If nullableValue.HasValue = False Then Return DBNull.Value
			Return nullableValue.Value
		End Function
		<% End If %>
		
		
#End Region
