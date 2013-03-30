      
#Region " Business Properties and Methods "

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
			<% If PropertyMode = CslaPropertyMode.Standard OrElse prop.DbBindColumn.NativeType = "timestamp" Then %>
				<% If Info.ObjectType <> CslaObjectType.ReadOnlyObject %>CanReadProperty("<%=FormatPascal(prop.Name)%>", True)
				<% End If %>Return <%=FormatFieldName(prop.Name)%><% If prop.PropertyType = TypeCodeEx.SmartDate AndAlso Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>.Text<% End If %>
			<% Else 
				If prop.PropertyType = TypeCodeEx.SmartDate Then %>
				Return GetPropertyConvert(Of SmartDate, String)(<%=FormatPascal(prop.Name)%>Property<% If PropertyMode = CslaPropertyMode.ManagedBackingField Then %>, <%=FormatFieldName(prop.Name)%><% End If %>)
				<% Else %>
				Return GetProperty(<%=FormatPascal(prop.Name)%>Property<% If PropertyMode = CslaPropertyMode.ManagedBackingField Then %>, <%=FormatFieldName(prop.Name)%><% End If %>)
				<% End If %>
			<% End If %>
			End Get
			<% If Info.ObjectType <> CslaObjectType.ReadOnlyObject AndAlso prop.ReadOnly = False Then %>
			Set(ByVal value As <% If prop.PropertyType = TypeCodeEx.SmartDate And Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>String<% Else %><%=GetDataType(prop)%><% End If %>)
			<% If PropertyMode = CslaPropertyMode.Standard OrElse prop.DbBindColumn.NativeType = "timestamp" Then %>
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
				<% Else 
					If prop.PropertyType = TypeCodeEx.SmartDate Then %>
				SetPropertyConvert(Of SmartDate, String)(<%=FormatPascal(prop.Name)%>Property<% If PropertyMode = CslaPropertyMode.ManagedBackingField Then %>, <%=FormatFieldName(prop.Name)%><% End If %>, value)	
				<% 	Else %>
				SetProperty(<%=FormatPascal(prop.Name)%>Property<% If PropertyMode = CslaPropertyMode.ManagedBackingField Then %>, <%=FormatFieldName(prop.Name)%><% End If %>, value)
				<%	End If
				End If %>
			End Set
			<% End If %>
		End Property
      
		<% Next %>
		<% For Each prop As ChildProperty In Info.GetMyChildProperties() 
			Dim _child as CslaObjectInfo = FindChildInfo(Info, prop.TypeName) %>
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
			<% If _child.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>
				If Not FieldManager.FieldExists(<%=FormatManaged(prop.Name)%>) Then
				<% If prop.LazyLoad And prop.LoadingScheme <> LoadingScheme.None Then %>
					If IsNew Then
						LoadProperty(<%=FormatManaged(prop.Name)%>, <%=prop.TypeName%>.New<%=prop.TypeName%>())
					Else
						LoadProperty(<%=FormatManaged(prop.Name)%>, <%=prop.TypeName%>.Get<%=prop.TypeName%>(<%
					first = True
					For Each p As Parameter In prop.LoadParameters
						If Not first Then
							%>, <%
						Else 
							first = False 
						End If 
						If PropertyMode = CslaPropertyMode.Managed Then
					%>ReadProperty(<%=FormatManaged(p.Property.Name)%>)<% 
						Else
					%><%=FormatFieldName(p.Property.Name)%><% 
						End If
					Next %>))
					End If
				<% Else %>
					LoadProperty(<%=FormatManaged(prop.Name)%>, <%=prop.TypeName%>.New<%=prop.TypeName%>())
				<% End If %>
				End If
			<% End If %>
				Return GetProperty(<%=FormatManaged(prop.Name)%>)
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
				strGetIdValue &= ReadProperty(prop)
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
