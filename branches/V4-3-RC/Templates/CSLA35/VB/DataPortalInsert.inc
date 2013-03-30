	
	<% If Info.GenerateDataPortalInsert Then %>
	
		''' <summary>
		''' Insert the new <see cref="<%=Info.ObjectName%>" /> object to underlying database.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %><Transactional()> _ 
		<% ElseIf Info.TransactionType = TransactionType.TransactionalAttribute Then %><Transactional(TransactionalTypes.TransactionScope)> _
		<% End If %>Protected Overrides Sub DataPortal_Insert()
			<% If Info.TransactionType = TransactionType.ADO Then  %>
			Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% Else %>
			Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% End If %>
				Using cmd As New SqlCommand("<%= Info.InsertProcedureName %>", ctx.Connection)
					<% If Info.TransactionType = TransactionType.ADO Then  %>
					cmd.Transaction = ctx.Transaction
					<% End If %>
					cmd.CommandType = CommandType.StoredProcedure
					<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Or _
								prop.DataAccess = ValueProperty.DataAccessBehaviour.CreateOnly Then  %>
					cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>)<%
								If prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Then
					%>.Direction = ParameterDirection.Output<%
								End If %>
					<% 		End If
					   Next %>
					DoInsertUpdate(cmd)
					Dim args As New DataPortalHookArgs(cmd)
					OnInsertPre(args)
					cmd.ExecuteNonQuery()
					<% For Each prop As ValueProperty In Info.GetAllValueProperties()
						If prop.DbBindColumn.NativeType = "timestamp" Then %>
					<%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@New<%=prop.ParameterName%>").Value, Byte())
					<% 	End If
						Next %>
					<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Then %>
					<%=LoadProperty(prop, "DirectCast(cmd.Parameters(""@" & prop.ParameterName & """).Value, " & GetLanguageVariableType(prop.DbBindColumn.DataType) & ")") %>
					<% 	End If
						Next %>
					OnInsertPost(args)
				End Using
				<!-- #include file="UpdateChildProperties.inc" -->
				<% If Info.TransactionType = TransactionType.ADO Then %>
				ctx.Commit()
				<% End If 
				If ActiveObjects Then 
					If Info.PublishToChannel.Length > 0 Then %>
				SafePublish("<%= Info.PublishToChannel %>", BusinessEvents.Added, Me)
				<% 	End If 
				End If %>
			End Using
		End Sub

	<% End If %>
	