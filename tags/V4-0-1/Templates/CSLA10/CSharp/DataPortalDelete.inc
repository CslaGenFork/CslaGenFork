		
		/// <summary>
		/// Delete the <see cref="<%=Info.ObjectName%>" /> object from database immediately.
		/// </summary>
		protected override void DataPortal_Delete(object criteria)
		{
			<%=Info.DeleteObjectCriteriaType.Name%> crit = (<%=Info.DeleteObjectCriteriaType.Name%>) criteria;
			
			// delete from DB
			SqlConnection cn = new SqlConnection(DB("<%=Info.DbName%>"));
			SqlCommand cmd = new SqlCommand();
			<% if(Info.TransactionType == TransactionType.ADO) {%>SqlTransaction tr;<%}%>	  
			cn.Open();
			
			try
			{
				<%if(Info.TransactionType == TransactionType.ADO) {%>
				tr = cn.BeginTransaction();
				try
				{
				<%}%>
					cmd.Connection = cn;<%if(Info.TransactionType == TransactionType.ADO) {%>
					cmd.Transaction = tr;<% } %>
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "<%=Info.DeleteProcedureName%>";
					<%foreach(Parameter p in Info.DeleteObjectParameters) {%>
					cmd.Parameters.Add("@<%= p.Property.Name %>", crit.<%= p.Property.Name %>);
					<%}%>
					ExtraCommandProcessing(cmd, crit, Command.Delete);
					cmd.ExecuteNonQuery();
					
					// Update any necessary Child Objects 
					<% foreach(ChildProperty child in Info.GetAllChildProperties()) { 
					%>if (<%=child.Name%> != null) {
						<%=FormatFieldName(child.Name)%>.Update(<% 
							if (Info.TransactionType == TransactionType.ADO) {%>tr,<% 
							} %>(<%=Info.ObjectName%>)this);
					}<% } %>
					<%if(Info.TransactionType == TransactionType.ADO) {%>
					
					tr.Commit();
				}					
				catch(Exception ex)
				{
					tr.Rollback();
					throw new Exception(ex.Message, ex.InnerException);
				}
				<%}%>
			}
			finally
			{
				cn.Close();
			}
		}
