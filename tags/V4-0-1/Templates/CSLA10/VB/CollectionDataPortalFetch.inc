		
		<% Dim isSwitchable As Boolean = False
    
		If Info.ObjectType <> CslaObjectType.ReadOnlyCollection Then
		   Dim childInfo As CslaObjectInfo = FindChildInfo(Info, Info.ItemType)
		   If childInfo.ObjectType = CslaObjectType.EditableSwitchable Then isSwitchable = True
		End If %>
		''' <summary>
		''' Load <see cref="<%=Info.ObjectName%>" /> collection from the database, based on given parameters.
		''' </summary>
		Protected Overrides Sub DataPortal_Fetch(ByVal criteria As Object)

			<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>Locked = False
			<% End If %>Dim crit As <%=Info.GetObjectCriteriaType.Name%> = DirectCast(criteria, <%=Info.GetObjectCriteriaType.Name%>)
			' Retrieve all child data objects via the safe data reader
			Dim cn As New SqlConnection(DB("<%= Info.DbName %>"))
			Dim cmd As New SqlCommand()
			cn.Open()

			Try
				cmd.Connection = cn
				cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandText = "<%= Info.SelectProcedureName %>"
				<% If Not Info.GetObjectParameters Is Nothing then
					For Each p As Parameter In Info.GetObjectParameters %>
				cmd.Parameters.Add("@<%= p.Property.Name %>", <%=GetParameterSet(p.Property,true)%>)
				<%	Next
				End If %>
				
				Dim dr As New SafeDataReader(cmd.ExecuteReader())
				Try
					While dr.Read()
						<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection AndAlso Not(LoadsChildren(Info)) Then %>
						Dim nfo as New Info
						<% For Each prop As ValueProperty In Info.ValueProperties()
							If prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None Then %>
						<%= GetReaderAssignmentStatement(prop,true) %>
						<%	End If
						   Next %>
						List.Add(nfo)
						<% Else %>
							<% If isSwitchable Then %>
						Dim <%= FormatCamel(Info.ItemType) %> As <%= Info.ItemType %> = <%= Info.ItemType %>.Get<%= Info.ItemType %>Child(dr)
							<% Else %>
						Dim <%= FormatCamel(Info.ItemType) %> As <%= Info.ItemType %> = <%= Info.ItemType %>.New<%= Info.ItemType %>()
						<%= FormatCamel(Info.ItemType) %>.Fetch(dr)
							<% End If %>
						List.Add(<%= FormatCamel(Info.ItemType) %>)
						<% End If %>
					End While
				Finally
					dr.Close()
				End Try
				
			Finally
				cn.Close()
				<% If Info.ObjectType = CslaObjectType.ReadOnlyCollection Then %>Locked = True
			<% End If %>End Try
			
		End Sub
