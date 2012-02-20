   		
<% 
For Each c As Criteria In Info.CriteriaObjects
	If c.CreateOptions.DataPortal Then %>
		''' <summary>
		''' Load default values for the <see cref="<%=Info.ObjectName%>" /> object's properties from the database.
		''' </summary>
		<% If c.CreateOptions.RunLocal Then %><CSLA.RunLocal()> _
		<% End If %>Protected Overloads Sub <% If Info.ObjectType = CslaObjectType.EditableChild Then %>Child<% Else %>DataPortal<% End If %>_Create(ByVal crit as <%= c.Name %>)
			<% If Info.ObjectType = CslaObjectType.EditableSwitchable Then %>
			If crit.IsChild Then MarkAsChild()
			<% End If %>
			<% For Each prop As ValueProperty In Info.ValueProperties 
				If prop.DefaultValue <> String.Empty Then %>
			<%= LoadProperty(prop, prop.DefaultValue) %>
			<% 	End If
			   Next %>
			<% Dim valProps As ValuePropertyCollection = Info.GetAllValueProperties()
			For Each p as Metadata.Property in c.Properties
				If valProps.Contains(p.Name) Then 
					If PropertyMode = CslaPropertyMode.Managed Then%>
			LoadProperty(<%= FormatManaged(p.Name) %>, crit.<%= FormatPascal(p.Name) %>)
			<% 		Else %>
			<%= FormatFieldName(p.Name) %> = crit.<%= FormatPascal(p.Name) %>
			<% 		End If
				End If
			Next %>
			<% For Each childProp As ChildProperty In Info.GetCollectionChildProperties() 
			Dim _child as CslaObjectInfo = FindChildInfo(Info, childProp.TypeName)
			If Not _child Is Nothing AndAlso _child.AddParentReference Then %>
			<%=FormatFieldName(childProp.Name)%>.SetParent(Me)
			<% End If %>
			<% Next %>
			Dim args As New DataPortalHookArgs(crit)
			OnCreate(args)
			<% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>
			Me.ValidationRules.CheckRules()
			<% End If %>
			
		End Sub
<% 	End If
Next %>