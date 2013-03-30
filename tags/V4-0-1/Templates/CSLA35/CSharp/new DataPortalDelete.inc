<% 
int deleteCount = 0;
foreach (Criteria c in Info.CriteriaObjects) {
	if (c.DeleteOptions.DataPortal) {
		deleteCount++;
		//This is kind of weak, because this will generate only for the first delete criteria,
		//but it's unlikely anyone will have more than one delete criteria.
		if (deleteCount == 1) { %>
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new <%=c.Name %>(<% 
				if (Info.ObjectType == CslaObjectType.EditableSwitchable) {
					Response.Write("false, ");
				}
				for (int i = 0; i < c.Properties.Count; i++) {
					if (i > 0) {
						%>, <%
					}
					Response.Write(FormatFieldName(c.Properties[i].Name));
				}
			%>));
		}
		<% } %>
		
		/// <summary>
		/// Delete the <see cref="<%=Info.ObjectName%>" /> Object from database immediately.
		/// </summary>
		<% if (Info.TransactionType == TransactionType.EnterpriseServices) { %>[Transactional()]
		<% } else if (Info.TransactionType == TransactionType.TransactionalAttribute) { %>[Transactional(TransactionalTypes.TransactionScope)]
		<% }
		   if (c.DeleteOptions.RunLocal) { %>[Csla.RunLocal()]
		<% } %>protected void DataPortal_Delete(<%=c.Name%> crit)
		{
			using (SqlConnection cn  = new SqlConnection(DataBase.<%= Info.DbName %>Connection))
			{
				cn.Open();
				using (SqlCommand cmd  = new SqlCommand("<%=c.DeleteOptions.ProcedureName%>", cn))
				{
				<% if (Info.TransactionType == TransactionType.ADO) {  %>
					using (SqlTransaction tr = cn.BeginTransaction())
					{
					cmd.Transaction = tr;
					ApplicationContext.LocalContext["dpTransaction"] = tr;
				<% } %>	  
					ApplicationContext.LocalContext["dpConnection"] = cn;
					ApplicationContext.LocalContext["dpCommand"] = cmd;
					cmd.CommandType = CommandType.StoredProcedure;
					<% 
					foreach (CslaGenerator.Metadata.Property p in c.Properties) { %>
					cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%= GetParameterSet(p,true) %>);
					<% } %>
					onDeletePre(cmd, EventArgs.Empty);
					cmd.ExecuteNonQuery();
					onDeletePost(cmd, EventArgs.Empty);
					<% if ( Info.TransactionType == TransactionType.ADO ) { %>
					tr.Commit();
					}
					<% } %>
				}
			}
		}

<%	}
} %>
