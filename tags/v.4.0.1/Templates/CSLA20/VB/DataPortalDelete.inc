
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
					%><%=FormatFieldName(c.Properties(i).Name)%><%
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
			Using cn As New SqlConnection(DataBase.<%= Info.DbName %>Connection)
				cn.Open()
				Using cmd As New SqlCommand("<%=c.DeleteOptions.ProcedureName%>", cn)
				<% If Info.TransactionType = TransactionType.ADO Then  %>
					Using tr As SqlTransaction = cn.BeginTransaction()
					cmd.Transaction = tr
					LocalContext("dpTransaction") = tr
				<% End If %>	  
					LocalContext("dpConnection") = cn
					LocalContext("dpCommand") = cmd
					cmd.CommandType = CommandType.StoredProcedure
					<% 
					For Each p As Metadata.Property In c.Properties %>
					cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p,true) %>)
					<% Next %>
					RaiseEvent DeletePre(Me, EventArgs.Empty)
					cmd.ExecuteNonQuery()
					RaiseEvent DeletePost(Me, EventArgs.Empty)
					<% If Info.TransactionType = TransactionType.ADO Then %>
					tr.Commit()
					End Using
					<% End If %>
				End Using
			End Using
		End Sub
<% 	End If 
Next%>
		