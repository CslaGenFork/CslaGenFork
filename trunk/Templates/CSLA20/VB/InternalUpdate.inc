		
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
		<% End If %>Friend Sub DeleteSelf(<% If parentType.Length > 0 And Not Info.ParentInsertOnly Then %>ByVal parent As <%= parentType %><% End If %>)
			Using cmd As New SqlCommand()
				Dim cn As SqlConnection = DirectCast(LocalContext("dpConnection"), SqlConnection)
				<%  If Info.TransactionType = TransactionType.ADO Then %>
				Dim tr as SqlTransaction = DirectCast(LocalContext("dpTransaction"), SqlTransaction)
				cmd.Transaction = tr
				<%  End If %>
				cmd.Connection = cn
				cmd.CommandType = CommandType.StoredProcedure
				If Not Me.IsNew Then
					cmd.CommandText = "<%= Info.DeleteProcedureName %>"
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
					LocalContext("dpCommand") = cmd 
					RaiseEvent DeletePre(Me, EventArgs.Empty)
					cmd.ExecuteNonQuery()
					LocalContext("dpCommand") = cmd
					LocalContext("dpConnection") = cn
					<%  If Info.TransactionType = TransactionType.ADO Then %>
					LocalContext("dpTransaction") = tr
					<%  End If %>
					RaiseEvent DeletePost(Me, EventArgs.Empty)
					LocalContext("dpCommand") = Nothing
				End If
			End Using
		End Sub
		
		<% If Info.GenerateDataPortalUpdate Then %>
		''' <summary>
		''' Save <see cref="<%=Info.ObjectName%>" /> object to database with or without transaction.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %><Transactional()> _ 
		<% End If %>Friend Sub Update(<% If parentType.Length > 0 And Not Info.ParentInsertOnly Then %>ByVal parent As <%= parentType %><% End If %>)
			If MyBase.IsDirty Then 
				Using cmd As New SqlCommand()
					Dim cn As SqlConnection = DirectCast(LocalContext("dpConnection"), SqlConnection)
					<%  If Info.TransactionType = TransactionType.ADO Then %>
					Dim tr as SqlTransaction = DirectCast(LocalContext("dpTransaction"), SqlTransaction)
					cmd.Transaction = tr
					<%  End If %>
					cmd.Connection = cn
					cmd.CommandType = CommandType.StoredProcedure
					cmd.CommandText = "<%= Info.UpdateProcedureName %>"
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
					LocalContext("dpCommand") = cmd 
					RaiseEvent UpdatePre(Me, EventArgs.Empty)
					cmd.ExecuteNonQuery()
					LocalContext("dpCommand") = cmd
					LocalContext("dpConnection") = cn
					<%  If Info.TransactionType = TransactionType.ADO Then %>
					LocalContext("dpTransaction") = tr
					<%  End If %>
					RaiseEvent UpdatePost(Me, EventArgs.Empty)
					LocalContext("dpCommand") = Nothing
					<% For Each prop As ValueProperty In Info.GetAllValueProperties()
						If prop.DbBindColumn.NativeType = "timestamp" Then %>
					<%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@New<%=prop.ParameterName%>").Value, Byte())
					<% 	End If
						Next %>
					MarkOld()
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
		<% End If %>Friend Sub Insert(<%If parentType.Length > 0 Then %>ByVal parent As <%= parentType %><% End If %>)
			Using cmd As New SqlCommand()
				Dim cn As SqlConnection = DirectCast(LocalContext("dpConnection"), SqlConnection)
				<%  If Info.TransactionType = TransactionType.ADO Then %>
				Dim tr as SqlTransaction = DirectCast(LocalContext("dpTransaction"), SqlTransaction)
				cmd.Transaction = tr
				<%  End If %>
				cmd.Connection = cn
				cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandText = "<%= Info.InsertProcedureName %>"
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
				DoInsertUpdate(cmd)
				LocalContext("dpCommand") = cmd
				RaiseEvent InsertPre(Me, EventArgs.Empty)
				cmd.ExecuteNonQuery()
				LocalContext("dpCommand") = cmd
				LocalContext("dpConnection") = cn
				<%  If Info.TransactionType = TransactionType.ADO Then %>
				LocalContext("dpTransaction") = tr
				<%  End If %>
				RaiseEvent InsertPost(Me, EventArgs.Empty)
				LocalContext("dpCommand") = Nothing
				<% For Each prop As ValueProperty In Info.GetAllValueProperties()
					If prop.DbBindColumn.NativeType = "timestamp" Then %>
				<%=FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@New<%=prop.ParameterName%>").Value, Byte())
				<% 	End If
					Next %>
				<% For Each prop As ValueProperty In Info.GetAllValueProperties()
      If prop.DbBindColumn.IsPrimaryKey() Or prop.PrimaryKey <> ValueProperty.UserDefinedKeyBehaviour.Default Then %>
				<%=		FormatFieldName(prop.Name)%> = DirectCast(cmd.Parameters("@<%=prop.ParameterName%>").Value, <%=GetLanguageVariableType(prop.DbBindColumn.DataType)%>)
				<% 	End If
				   Next %>
				MarkOld()
			End Using
			<!-- #include file="UpdateChildProperties.inc" -->
		End Sub
		
		<% End If %>