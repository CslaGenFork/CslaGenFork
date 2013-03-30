		
		''' <summary>
		''' Delete the <see cref="<%=Info.ObjectName%>" /> object from database immediately.
		''' </summary>
		Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)
		
			Dim crit As <%=Info.DeleteObjectCriteriaType.Name%> = DirectCast(criteria, <%=Info.DeleteObjectCriteriaType.Name%>)
	
			' delete from DB
			Dim cn As New SqlConnection(DB("<%=Info.DbName%>"))
			Dim cmd As New SqlCommand()
			<% If Info.TransactionType = TransactionType.ADO Then 
			%>Dim tr As SqlTransaction <%
			   End If %>	  
			cn.Open()
			
			Try 
				<% If Info.TransactionType = TransactionType.ADO Then %>
				tr = cn.BeginTransaction()
				Try
				<% End If %>
					
					cmd.Connection = cn<% If Info.TransactionType = TransactionType.ADO Then %>
					cmd.Transaction = tr<% End If %>
					cmd.CommandType = CommandType.StoredProcedure
					cmd.CommandText = "<%=Info.DeleteProcedureName%>"
					<% 
					Dim UpdateEventString_Delete as String = ""
					For Each p As Parameter In Info.DeleteObjectParameters %>
					cmd.Parameters.Add("@<%= p.Property.ParameterName %>", <%= GetParameterSet(p.Property,true) %>)
					<% UpdateEventString_Delete &= ", " & GetParameterSet(p.Property,true)
					Next 
          UpdateEventString_Delete = UpdateEventString_Delete.Substring(2)
					If (Info.DeleteObjectParameters.Count > 1) then
						UpdateEventString_Delete = "new object() {" & UpdateEventString_Delete & "}"
					End If
					%>
					cmd.ExecuteNonQuery()
					
					' Update any necessary Child Objects 
					<%  For Each child As ChildProperty In Info.GetAllChildProperties()%>
					If <%=child.Name%> Is Nothing = False Then 
						<%=FormatFieldName(child.Name)%>.Update(<% 
								If Info.TransactionType = TransactionType.ADO Then 
									%>tr, <% 
								End If %>DirectCast(Me, <%=Info.ObjectName%>))
					End If 
					<%	Next
						
						If Info.TransactionType = TransactionType.ADO Then %>
						
					tr.Commit()
					PublishEvent(BusinessEvents.Deleted, <%= UpdateEventString_Delete %>)
				Catch ex As Exception
					tr.Rollback()
					Throw New Exception(ex.Message, ex.InnerException)
				End Try
				<% End If%>
				
			Finally
				cn.Close()
			End Try
			
		End Sub
