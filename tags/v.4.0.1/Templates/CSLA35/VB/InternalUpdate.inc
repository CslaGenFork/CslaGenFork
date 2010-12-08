		
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
		''' Delete <see cref="<%=Info.ObjectName%>" /> object from database with or without transaction.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %><Transactional()> _ 
		<% End If %>Private Sub Child_DeleteSelf(<% If parentType.Length > 0 Then %>ByVal parent As <%= parentType %><% End If %>)
			If Me.IsNew Then Return
			<% If Info.TransactionType = TransactionType.ADO Then  %>
			Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% Else %>
			Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% End If %>
				Using cmd As New SqlCommand("<%= Info.DeleteProcedureName %>", ctx.Connection)
					<%  If Info.TransactionType = TransactionType.ADO Then %>
					cmd.Transaction = ctx.Transaction
					<%  End If %>
					cmd.CommandType = CommandType.StoredProcedure
					<% For Each prop As ValueProperty In Info.ValueProperties %>
						<% If prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.Default Then %>
					cmd.Parameters.AddWithValue("@<%= prop.ParameterName %>", <%=GetParameterSet(prop)%>)
						<% End If
					Next %>
					<% If parentType.Length > 0 And Not Info.ParentInsertOnly Then 
						For Each prop As Metadata.Property In Info.ParentProperties %>
						<% If prop.PropertyType = Metadata.TypeCodeEx.SmartDate Then %>
					Dim l<%=prop.Name%> As New SmartDate(parent.<%=prop.Name%>)
					cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", l<%=prop.Name%>.DBValue)	
						<% Else %>
					cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", parent.<%=prop.Name%>)
						<% End If %>
					<%	Next
					   End If %>
					Dim args As New DataPortalHookArgs(cmd, Nothing<% If parentType.Length > 0 Then %>, parent<% End If %>)
					OnDeletePre(args)
					cmd.ExecuteNonQuery()
					OnDeletePost(args)
				End Using
			End Using
		End Sub
		
		<% If Info.GenerateDataPortalUpdate Then %>
		''' <summary>
		''' Save <see cref="<%=Info.ObjectName%>" /> object to database with or without transaction.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %><Transactional()> _ 
		<% End If %>Private Sub Child_Update(<% If parentType.Length > 0 Then %>ByVal parent As <%= parentType %><% End If %>)
			If MyBase.IsDirty Then 
				<% If Info.TransactionType = TransactionType.ADO Then  %>
				Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.<%= Info.DbName %>Connection, False)
				<% Else %>
				Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.<%= Info.DbName %>Connection, False)
				<% End If %>
					Using cmd As New SqlCommand("<%= Info.UpdateProcedureName %>", ctx.Connection)
						<%  If Info.TransactionType = TransactionType.ADO Then %>
						cmd.Transaction = ctx.Transaction
						<%  End If %>
						cmd.CommandType = CommandType.StoredProcedure
						<% If parentType.Length > 0 And Not Info.ParentInsertOnly Then 
							For Each prop As Metadata.Property In Info.ParentProperties %>
							<% If prop.PropertyType = Metadata.TypeCodeEx.SmartDate Then %>
						Dim l<%=prop.Name%> As New SmartDate(parent.<%=prop.Name%>)
						cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", l<%=prop.Name%>.DBValue)	
							<% Else %>
						cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", parent.<%=prop.Name%>)
							<% End If %>
						<%	Next
						   End If %>
						<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Or _
								prop.DataAccess = ValueProperty.DataAccessBehaviour.UpdateOnly Or _
								prop.DbBindColumn.NativeType = "timestamp" Then  %>
						cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>)
						<%	End If
						   Next %>
						DoInsertUpdate(cmd)
						Dim args As New DataPortalHookArgs(cmd, Nothing<% If parentType.Length > 0 Then %>, parent<% End If %>)
						OnUpdatePre(args)
						cmd.ExecuteNonQuery()
						<% For Each prop As ValueProperty In Info.GetAllValueProperties()
							If prop.DbBindColumn.NativeType = "timestamp" Then %>
						<%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@New<%=prop.ParameterName%>").Value, Byte())
						<% 	End If
							Next %>
						OnUpdatePost(args)
						MarkOld()
					End Using
				End Using
			End If
			<!-- #include file="UpdateChildProperties.inc" -->
		End Sub
		
		<% End If %>
		
		<% If Info.GenerateDataPortalInsert Then %>
		
		''' <summary>
		''' Insert <see cref="<%=Info.ObjectName%>" /> object to database with or without transaction.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %><Transactional()> _ 
		<% End If %>Private Sub Child_Insert(<%If parentType.Length > 0 Then %>ByVal parent As <%= parentType %><% End If %>)
			<% If Info.TransactionType = TransactionType.ADO Then  %>
			Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% Else %>
			Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% End If %>
				Using cmd As New SqlCommand("<%= Info.InsertProcedureName %>", ctx.Connection)
					<%  If Info.TransactionType = TransactionType.ADO Then %>
					cmd.Transaction = ctx.Transaction
					<%  End If %>
					cmd.CommandType = CommandType.StoredProcedure
					<% If parentType.Length > 0 Then 
						For Each prop As Metadata.Property In Info.ParentProperties %>
						<% If prop.PropertyType = Metadata.TypeCodeEx.SmartDate Then %>
					Dim l<%=prop.Name%> As New SmartDate(parent.<%=prop.Name%>)
					cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", l<%=prop.Name%>.DBValue)	
						<% Else %>
					cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", parent.<%=prop.Name%>)
						<% End If %>
					<%	Next
					   End If %>
					<% For Each prop As ValueProperty In Info.GetAllValueProperties()
						If prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Or _
							prop.DataAccess = ValueProperty.DataAccessBehaviour.CreateOnly Then %>
					cmd.Parameters.AddWithValue("@<%=prop.ParameterName%>", <%=GetParameterSet(prop)%>)<%
					If prop.PrimaryKey = ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK Then
					%>.Direction = ParameterDirection.Output<%
						End If %>
					<%End If
					   Next %>
					Dim args As New DataPortalHookArgs(cmd, Nothing<% If parentType.Length > 0 Then %>, parent<% End If %>)
					DoInsertUpdate(cmd)
					OnInsertPre(args)
					cmd.ExecuteNonQuery()
					<% For Each prop As ValueProperty In Info.GetAllValueProperties()
						If prop.DbBindColumn.NativeType = "timestamp" Then %>
					<%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@New<%=prop.ParameterName%>").Value, Byte())
					<% 	End If
						Next %>
					<% For Each prop As ValueProperty In Info.GetAllValueProperties()
	      If prop.DbBindColumn.IsPrimaryKey() Or prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.Default Then %>
					<%=LoadProperty(prop, "DirectCast(cmd.Parameters(""@" & prop.ParameterName & """).Value, " & GetLanguageVariableType(prop.DbBindColumn.DataType) & ")") %>
					<% 	End If
					   Next %>
					OnInsertPost(args)
					MarkOld()
				End Using
			End Using
			<!-- #include file="UpdateChildProperties.inc" -->
		End Sub
		
		<% End If %>