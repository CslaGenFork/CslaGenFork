
<% 
Dim deleteCount as Integer = 0
For Each c As Criteria In Info.CriteriaObjects 
	If c.DeleteOptions.DataPortal Then 
		deleteCount +=1 
		''This is kind of weak, because this will generate only for the first delete criteria,
		''but it's unlikely anyone will have more than one delete criteria.
		If deleteCount = 1 Then %>
		Protected Overrides Sub DataPortal_DeleteSelf()
			DataPortal_Delete(New <%=c.Name %>(<% 
				If Info.ObjectType = CslaObjectType.EditableSwitchable Then
					%>False, <%
				End If
				For i As Integer = 0 To c.Properties.Count - 1
					If i > 0 Then
						%>, <%
					End If
					If PropertyMode = CslaPropertyMode.Managed Then
					%>ReadProperty(<%=FormatManaged(c.Properties(i).Name)%>)<%
					Else
					%><%=FormatFieldName(c.Properties(i).Name)%><%
					End If
				Next
			%>))
		End Sub
		<% End If %>

		''' <summary>
		''' Delete the <see cref="<%=Info.ObjectName%>" /> object from database immediately.
		''' </summary>
		<% If Info.TransactionType = TransactionType.EnterpriseServices Then %><Transactional()> _ 
		<% ElseIf Info.TransactionType = TransactionType.TransactionalAttribute Then %><Transactional(TransactionalTypes.TransactionScope)> _
		<% End If
		   If c.DeleteOptions.RunLocal Then %><CSLA.RunLocal()> _
		<% End If %>Protected Overloads Sub DataPortal_Delete(ByVal crit As <%=c.Name%>)
		
			<% If Info.TransactionType = TransactionType.ADO Then  %>
			Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% Else %>
			Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.<%= Info.DbName %>Connection, False)
			<% End If %>
				Using cmd As New SqlCommand("<%=c.DeleteOptions.ProcedureName%>", ctx.Connection)
				<% If Info.TransactionType = TransactionType.ADO Then  %>
					cmd.Transaction = ctx.Transaction
				<% End If %>	  
					cmd.CommandType = CommandType.StoredProcedure
					<% 
					For Each p As Metadata.Property In c.Properties %>
					cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p,true) %>)
					<% Next %>
					Dim args As New DataPortalHookArgs(cmd, crit)
					OnDeletePre(args)
					cmd.ExecuteNonQuery()
					OnDeletePost(args)
				End Using
				<% If Info.TransactionType = TransactionType.ADO Then %>
				ctx.Transaction.Commit()
				<% End If 
				If ActiveObjects Then 
					If Info.PublishToChannel.Length > 0 Then %>
				SafePublish("<%= Info.PublishToChannel %>", BusinessEvents.Deleted, Me)
				<% 	End If 
				End If %>
			End Using
		End Sub
<% 	End If 
Next%>
		