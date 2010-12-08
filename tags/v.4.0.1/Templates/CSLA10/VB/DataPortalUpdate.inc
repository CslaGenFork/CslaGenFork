
		''' <summary>
		''' Update all changes made on <see cref="<%=Info.ObjectName%>" /> object to underlying database.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %>
		<Transactional()> _ 
		<% End If %>		Protected Overrides Sub DataPortal_Update()
			If Not Me.IsDirty Then Exit Sub
			' Save data to DB
			Dim cn As New SqlConnection(DB("<%= Info.DbName %>"))
			Dim cmd As New SqlCommand()
			<% If Info.TransactionType = TransactionType.ADO Then %>
			Dim tr As SqlTransaction
			<% End If %>     
			cn.Open()
			
			Try
				<% If ActiveObjects Then %>
				Dim EventType as String
				'By default we set the event type for update.
				'This is mostly because we check Mybase.IsDirty to avoid a useless db call.
				EventType = BusinessEvents.Updated
				<% End If %>
				<% If Info.TransactionType = TransactionType.ADO Then %>
				tr = cn.BeginTransaction()
				Try
				<% End If %>
					
					cmd.Connection = cn
					<% If Info.TransactionType = TransactionType.ADO Then %>
					cmd.Transaction = tr
					<% End If 
					Dim UpdateEventString as String %>
					cmd.CommandType = CommandType.StoredProcedure
					
					If Me.IsDeleted Then
					
						If Not Me.IsNew Then
							cmd.CommandText = "<%= Info.DeleteProcedureName %>"
							<% 
							Dim UseArray as Boolean = False
							If Info.DeleteObjectParameters.Count > 0 Then %>
								<%
								UseArray = (Info.DeleteObjectParameters.Count > 1)
								For Each p As Parameter In Info.DeleteObjectParameters %>
							cmd.Parameters.Add("@<%= p.Property.ParameterName %>", <%= GetParameterSet(p.Property) %>)
						
								<% 
								If UseArray then
									UpdateEventString &= "," & FormatFieldName(p.Property.Name)
								Else
									UpdateEventString = FormatFieldName(p.Property.Name)
								End If
								
								Next 
								If UseArray then
									UpdateEventString = "new object() {" & UpdateEventString.Substring(1) & "}"
								End If
								
								%>
							<% Else 
								Dim count as Integer = 0
								For Each prop As ValueProperty In Info.ValueProperties %>
								<% 	If prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.Default Then 
										count += 1 %>
							cmd.Parameters.Add("@<%= prop.ParameterName %>", <%=FormatFieldName(prop.Name)%>)
								<% 
										UpdateEventString &= Iif(count>0,",","") & FormatFieldName(prop.Name)
									End If
								Next	
								if count > 1 then
									UpdateEventString = "new object() {" & UpdateEventString & "}"
								end if
								%>

							<% End If %>
							cmd.ExecuteNonQuery()
						End If
						
						' Reset our status to be a new object
						Me.MarkNew()
					Else
						<% Dim bNeedOutput As Boolean = False
						   Dim sEnding As String = String.Empty
						   Dim sValue As String = String.Empty
						%>
						If MyBase.IsDirty Then
						If Me.IsNew Then
							' Perform an insert, object has not yet been persisted
							cmd.CommandText = "<%= Info.InsertProcedureName %>"
							<% For Each prop As ValueProperty In Info.GetAllValueProperties()
								If (prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK) OrElse (prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None AndAlso prop.DbBindColumn.IsPrimaryKey AndAlso prop.DefaultValue.Length <= 0) Then
									bNeedOutput = True %>
							cmd.Parameters.Add("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>).Direction = ParameterDirection.Output
							<%	End If
							   Next %>
							<% If ActiveObjects Then %>   
							EventType = BusinessEvents.Added
							<% End If %>   
						Else 
							cmd.CommandText = "<%= Info.UpdateProcedureName %>"
							<% For Each prop As ValueProperty In Info.GetAllValueProperties()
								If (prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK) OrElse (prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None AndAlso prop.DbBindColumn.IsPrimaryKey AndAlso prop.DefaultValue.Length <= 0) Then
									bNeedOutput = True %>
							cmd.Parameters.Add("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>)
							<%	End If
							   Next %>
						End If
						
						<%  For Each prop As ValueProperty In Info.GetAllValueProperties()
								If prop.DbBindColumn.ColumnOriginType <> ColumnOriginType.None And prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Then
									sEnding = ""
									If prop.DbBindColumn.IsPrimaryKey() AndAlso prop.DefaultValue.Length <=0 Then
										bNeedOutput = True
										sEnding = ".Direction = ParameterDirection.InputOutput"
									ElseIf prop.DbBindColumn.NativeType = "timestamp" Then
										bNeedOutput = True %>
						cmd.Parameters.Add("@New<%=prop.ParameterName%>", Nothing).Direction = ParameterDirection.Output
								<% End If %>
						cmd.Parameters.Add("@<%= prop.ParameterName %>", <%=GetParameterSet(prop)%>)<%=sEnding%>
							<%	End If %>
						<% 	Next %>
						cmd.ExecuteNonQuery()
						<%	If bNeedOutput Then %>
							
						If Me.IsNew Then
							<% For Each prop As ValueProperty In Info.GetAllValueProperties()
									If prop.DbBindColumn.IsPrimaryKey() Or prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.Default Then %>
							<%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@<%=prop.ParameterName%>").Value, <%=GetLanguageVariableType(prop.DbBindColumn.DataType)%>)
							<% 		End If
							   Next %>
						End If
						<% 	For Each prop As ValueProperty In Info.GetAllValueProperties()
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
					End If 
					' Update any necessary Child Objects 
					<%  For Each child As ChildProperty In Info.GetMyChildProperties() %>
					If <%=child.Name%> Is Nothing = False Then
						<%=FormatFieldName(child.Name)%>.Update(<% 
						If Info.TransactionType = TransactionType.ADO Then 
							%>tr, <% 
						End If %>DirectCast(Me, <%=Info.ObjectName%>))
					End If 
					<%  Next %>
					<% If Info.TransactionType = TransactionType.ADO Then %>
					
					tr.Commit()
					<% If ActiveObjects Then %>
					'The publish event must be overwritten in the class that inherits from this one
					PublishEvent(EventType, iif(EventType = BusinessEvents.Deleted,<%= UpdateEventString %>,Me))
					<% End If %>
				Catch ex As Exception
					tr.Rollback()
					Throw New Exception(ex.Message, ex.InnerException)
				End Try
				<%  End If %>
			
			Finally
				cn.Close()
			End Try
			
		End Sub
