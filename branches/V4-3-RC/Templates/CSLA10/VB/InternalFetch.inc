		
		''' <summary>
		''' Load a <see cref="<%=Info.ObjectName%>" /> object from given SafeDataReader.
		''' </summary>
		Friend Sub Fetch (ByVal dr As SafeDataReader)

			' Retrieve the data from the passed in data reader, which may or may not have
			' a transaction associated with it
			<% If Info.ObjectType = CslaObjectType.EditableSwitchable Then %>MarkAsChild()<% End If %>
			
			' Value properties
			<% For Each prop As ValueProperty In Info.GetAllValueProperties()
				If prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None Then %>
			<%= GetReaderAssignmentStatement(prop) %>
			<%	End If
			   Next %>
			
			' Child business object properties
			<% For Each childProp As ChildProperty In Info.GetAllChildProperties()
					If Not childProp.LazyLoad Then %>
			<%=FormatFieldName(childProp.Name)%> = <%=childProp.Name%>.Get<%=childProp.Name%>(dr)
			<% 		End If
			   Next %>
			
			MarkOld()
			Me.CheckRules()
			
		End Sub
