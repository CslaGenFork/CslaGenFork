
	<% If Info.GenerateDataPortalUpdate Then %>

		''' <summary>
		''' Update all changes made on <see cref="<%=Info.ObjectName%>" /> object to underlying database.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %><Transactional()> _ 
		<% ElseIf Info.TransactionType = TransactionType.TransactionalAttribute Then %><Transactional(TransactionalTypes.TransactionScope)> _
		<% End If %>Protected Overrides Sub DataPortal_Update()
			Using cn As New SqlConnection(DataBase.<%= Info.DbName %>Connection)
				cn.Open()
				Using cmd As New SqlCommand("<%= Info.UpdateProcedureName %>", cn)
					<% If Info.TransactionType = TransactionType.ADO Then %>
					Using tr As SqlTransaction = cn.BeginTransaction()
					cmd.Transaction = tr
					LocalContext("dpTransaction") = tr
					<% End If %>	  
					LocalContext("dpConnection") = cn
					LocalContext("dpCommand") = cmd    
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
						RaiseEvent UpdatePre(Me, EventArgs.Empty)
						cmd.ExecuteNonQuery()
						RaiseEvent UpdatePost(Me, EventArgs.Empty)
						<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If prop.DbBindColumn.NativeType = "timestamp" Then %>
						<%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@New<%=prop.ParameterName%>").Value, Byte())
						<% 	End If
							Next %>
					End If
					<!-- #include file="UpdateChildProperties.inc" -->
					<% If Info.TransactionType = TransactionType.ADO Then %>
					tr.Commit()
					End Using
					<% End If 
					If ActiveObjects Then 
            If Info.PublishToChannel.Length > 0 Then %>
					SafePublish("<%= Info.PublishToChannel %>", BusinessEvents.Updated, Me)
					<% End If 
          End If %>
				End Using
			End Using
		End Sub

	<% End If %>
	