		
		<% 
		Dim parentType As String = Info.ParentType
		Dim parentInfo As CslaObjectInfo = FindChildInfo(Info, parentType)
		If parentInfo Is Nothing Then
			parentType = ""
		Else
			If parentInfo.ObjectType = CslaObjectType.EditableChildCollection Then
				parentType = parentInfo.ParentType
			ElseIf parentInfo.ObjectType = CslaObjectType.EditableRootCollection
				parentType = ""
			End If
		End If
		%>
		''' <summary>
		''' Save (delete, add, update) <see cref="<%=Info.ObjectName%>" /> object to database with or without transaction.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %><Transactional()> _ 
		<% End If %>Friend Sub Update(<% If Info.TransactionType = TransactionType.ADO Then %>ByVal tr As SqlTransaction<% End If 
			If parentType.Length > 0 Then %><% If Info.TransactionType = TransactionType.ADO Then %>, <% End If %>ByVal parent As <%= parentType %><% End If %>)
			If Not Me.IsDirty Then Exit Sub
			' Save data to DB
			<% If Info.TransactionType <> TransactionType.ADO Then %>
			Dim cn As New SqlConnection(DB("<%= Info.DbName %>"))
			cn.Open()
			<% End If %>
			Dim cmd As New SqlCommand()
			
			Try
				<%  If Info.TransactionType = TransactionType.ADO Then %>
				cmd.Connection = tr.Connection
				cmd.Transaction = tr
				<%	Else %>
				cmd.Connection = cn
				<%  End If %>
				cmd.CommandType = CommandType.StoredProcedure
				
				If Me.IsDeleted Then
				
					If Not Me.IsNew Then
						cmd.CommandText = "<%= Info.DeleteProcedureName %>"
						<% If Info.DeleteObjectParameters.Count > 0 Then %>
							<% For Each p As Parameter In Info.DeleteObjectParameters %>
						cmd.Parameters.Add("@<%= p.Property.ParameterName %>", <%= FormatFieldName(p.Property.Name) %>)
						<% 	Next
						Else
							For Each prop As ValueProperty In Info.ValueProperties %>
								<% If prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.Default Then %>
						cmd.Parameters.Add("@<%= prop.ParameterName %>", <%=FormatFieldName(prop.Name)%>)
								<% End If
							Next
						End If %>
						<% If parentType.Length > 0 And Not Info.ParentInsertOnly Then 
							For Each prop As Metadata.Property In Info.ParentProperties %>
						cmd.Parameters.Add("@<%=prop.ParameterName%>", parent.<%=prop.Name%>)
						<%	Next
						   End If %>
						cmd.ExecuteNonQuery()
					End If
					
				Else
					<% Dim bNeedOutput2 As Boolean = False
					%>
					
					If Me.IsNew Then
						' Perform an insert, object has not yet been persisted
						cmd.CommandText = "<%= Info.InsertProcedureName %>"
						<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If (prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK) OrElse (prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None AndAlso prop.DbBindColumn.IsPrimaryKey AndAlso prop.DefaultValue.Length <= 0) Then
								
								bNeedOutput2 = True %>
						cmd.Parameters.Add("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>).Direction = ParameterDirection.Output
						<%	End If
						   Next %>
						<% If parentType.Length > 0 And Info.ParentInsertOnly Then 
						For Each prop As Metadata.Property In Info.ParentProperties %>
						cmd.Parameters.Add("@<%=prop.ParameterName%>", parent.<%=prop.Name%>)
						<%	Next
						   End If %>
					Else
						cmd.CommandText = "<%= Info.UpdateProcedureName %>"
						<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If (prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK) OrElse (prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None AndAlso prop.DbBindColumn.IsPrimaryKey AndAlso prop.DefaultValue.Length <= 0) Then
								
								bNeedOutput2 = True %>
						cmd.Parameters.Add("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>)
						<%	End If
						   Next %>
					End If
					
					<%  For Each prop As ValueProperty In Info.GetAllValueProperties()
							If prop.DataAccess <> ValueProperty.DataAccessBehaviour.ReadOnly then
							If (prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK) AndAlso (prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None AndAlso Not (prop.DbBindColumn.IsPrimaryKey AndAlso prop.DefaultValue.Length <= 0)) Then

								
								If prop.DbBindColumn.NativeType = "timestamp" Then
									bNeedOutput2 = True %>
									'Why is this parameter created with "NEW"???
					cmd.Parameters.Add("@New<%=prop.ParameterName%>", Nothing).Direction = ParameterDirection.Output
							<%	End If %>
					cmd.Parameters.Add("@<%=prop.ParameterName%>", <%= GetParameterSet(prop)%>)
						<%	End If %>
						<%	End If %>
					<% 	Next %>
					<% If parentType.Length > 0 And Not Info.ParentInsertOnly Then 
						For Each prop As Metadata.Property In Info.ParentProperties %>
					cmd.Parameters.Add("@<%=prop.ParameterName%>", parent.<%=prop.Name%>)
					<%	Next
					   End If %>
					cmd.ExecuteNonQuery()
					<% If bNeedOutput2 Then %>
					
					If Me.IsNew Then
						<%	For Each prop As ValueProperty In Info.GetAllValueProperties()
								If prop.DbBindColumn.IsPrimaryKey or prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Then %>
						<%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@<%=prop.ParameterName%>").Value, <%=GetLanguageVariableType(prop.DbBindColumn.DataType)%>)
						<% 		End If
							Next %>
					End If
					<% For Each prop As ValueProperty In Info.GetAllValueProperties()
					If prop.DbBindColumn.NativeType = "timestamp" Then %>
					<% ' Replace next lines if there is an error %>
					<% ' <%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@New<%=prop.Name%>").Value, <%=GetLanguageVariableType(prop.DbBindColumn.DataType)%>) %>
					<%=FormatFieldName(prop.Name)%> = cmd.Parameters("@New<%=prop.ParameterName%>").Value
					<% End If
					   Next %>
					<% End If %>
					
					' Mark the object as Old (Persisted)
					MarkOld()
					
				End If
				
				' Update any necessary Child Objects 
				<% For Each child As ChildProperty In Info.GetMyChildProperties() %>
				If <%=FormatFieldName(child.Name)%> Is Nothing = False Then
					<%= FormatFieldName(child.Name)%>.Update(<% 
					If Info.TransactionType = TransactionType.ADO Then 
						%>tr, <% 
					End If %>DirectCast(Me, <%=Info.ObjectName%>))
				End If 
				<% Next %>
				
			Finally
				<% If Info.TransactionType <> TransactionType.ADO Then %>
				cn.Close()
				<% End If %>
			End Try
			
		End Sub
		