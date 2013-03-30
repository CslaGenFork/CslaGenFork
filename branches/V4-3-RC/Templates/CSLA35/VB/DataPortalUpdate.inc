
	<% If Info.GenerateDataPortalUpdate Then %>

		''' <summary>
		''' Update all changes made on <see cref="<%=Info.ObjectName%>" /> object to underlying database.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %><Transactional()> _ 
		<% ElseIf Info.TransactionType = TransactionType.TransactionalAttribute Then %><Transactional(TransactionalTypes.TransactionScope)> _
		<% End If %>Protected Overrides Sub DataPortal_Update()
			<% If Info.TransactionType = TransactionType.ADO Then  %>
			Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% Else %>
			Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% End If %>
				Using cmd As New SqlCommand("<%= Info.UpdateProcedureName %>", ctx.Connection)
					<% If Info.TransactionType = TransactionType.ADO Then  %>
					cmd.Transaction = ctx.Transaction
					<% End If %>
					If MyBase.IsDirty Then
						cmd.CommandType = CommandType.StoredProcedure
						<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Or _
								prop.DataAccess = ValueProperty.DataAccessBehaviour.UpdateOnly Or _
								prop.DbBindColumn.NativeType = "timestamp" Then  %>
						cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>)
						<%	End If
						   Next %>
						DoInsertUpdate(cmd)
						Dim args As New DataPortalHookArgs(cmd)
						OnUpdatePre(args)
						cmd.ExecuteNonQuery()
						<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If prop.DbBindColumn.NativeType = "timestamp" Then %>
						<%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@New<%=prop.ParameterName%>").Value, Byte())
						<% 	End If
							Next %>
						OnUpdatePost(args)
					End If
				End Using
				<!-- #include file="UpdateChildProperties.inc" -->
				<% If Info.TransactionType = TransactionType.ADO Then %>
				ctx.Commit()
				<% End If 
				If ActiveObjects Then 
					If Info.PublishToChannel.Length > 0 Then %>
				SafePublish("<%= Info.PublishToChannel %>", BusinessEvents.Updated, Me)
					<% End If 
				End If %>

			End Using
		End Sub

	<% End If %>
	