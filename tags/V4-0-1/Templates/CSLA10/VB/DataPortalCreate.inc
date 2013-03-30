   		
		''' <summary>
		''' Load default values for the <see cref="<%=Info.ObjectName%>" /> object's properties from the database.
		''' </summary>
		<RunLocal()> _
		Protected Overrides Sub DataPortal_Create(ByVal criteria As Object)
		
			<% If Info.ObjectType <> CslaObjectType.EditableRoot Then %>
			<% If Not Info.NewObjectCriteriaType Is Nothing AndAlso Info.NewObjectCriteriaType.Name <> "" Then %>
			Dim crit As <%=Info.NewObjectCriteriaType.Name%> = DirectCast(criteria, <%=Info.NewObjectCriteriaType.Name%>)
			<% 		If Info.ObjectType = CslaObjectType.EditableSwitchable Then %>
			If crit.IsChild Then MarkAsChild()
			<% 		End If %>
			<% End If %>
			<% End If %>
			<% If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then %>
			Me.CheckRules()
			<% End If %>
			
		End Sub
	