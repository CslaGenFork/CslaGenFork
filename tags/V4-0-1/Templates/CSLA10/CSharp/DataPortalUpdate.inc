		
		/// <summary>
		/// Update all changes made on <see cref="<%=Info.ObjectName%>" /> object to the underlying database.
		/// </summary>
		<% if(Info.TransactionType == TransactionType.EnterpriseServices) {%>[Transactional] 
		<%}%>protected override void DataPortal_Update()
		{
			//Save data to DB
			SqlConnection cn = new SqlConnection(DB("<%= Info.DbName %>"));
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
					if(this.IsDeleted)
					{
						if(!this.IsNew)
						{
							cmd.CommandText = "<%= Info.DeleteProcedureName %>";
							<%foreach(Parameter p in Info.DeleteObjectParameters) {%>
							cmd.Parameters.Add("@<%= p.Property.Name %>", <%= FormatFieldName(p.Property.Name) %>);
							<%}%>
							ExtraCommandProcessing(cmd, null, Command.Delete);
							cmd.ExecuteNonQuery();
						}   
						
						//Reset our status to be a new object
						this.MarkNew();
					}
					else
					{
						Command action = Command.Insert;
						<%bool bNeedOutput; bNeedOutput=false; string sValue; %>
						if(this.IsNew)
						{
							//Perform an insert, object has not yet been persisted
							cmd.CommandText = "<%= Info.InsertProcedureName %>";
							<% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
								if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None && prop.DbBindColumn.IsPrimaryKey() && prop.DefaultValue.Length <= 0) {
									if (GetLanguageVariableType(prop.DbBindColumn.DataType) == "Guid")
										sValue = FormatFieldName(prop.Name) + " == Guid.Empty ? (object) DBNull.Value : " + FormatFieldName(prop.Name);
									else
										sValue = FormatFieldName(prop.Name);
									
									bNeedOutput = true; %>
							cmd.Parameters.Add("@<%=prop.Name%>", <%=sValue%>).Direction = ParameterDirection.Output;
							<%	} } %>
							action = Command.Insert;
						}
						else
						{
							cmd.CommandText = "<%= Info.UpdateProcedureName %>";
							<% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
								if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None && prop.DbBindColumn.IsPrimaryKey() && prop.DefaultValue.Length <= 0) {
									if (GetLanguageVariableType(prop.DbBindColumn.DataType) == "Guid")
										sValue = FormatFieldName(prop.Name) + " == Guid.Empty ? (object) DBNull.Value : " + FormatFieldName(prop.Name);
									else
										sValue = FormatFieldName(prop.Name);
									
									bNeedOutput = true; %>
							cmd.Parameters.Add("@<%=prop.Name%>", <%=sValue%>);
							<%	} } %>
							action = Command.Update;
						}
						
						<% foreach(ValueProperty prop in Info.GetAllValueProperties())
						{
							if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None && !(prop.DbBindColumn.IsPrimaryKey() && prop.DefaultValue.Length <= 0)) {
								if (GetLanguageVariableType(prop.DbBindColumn.DataType) == "SmartDate")
									sValue = FormatFieldName(prop.Name) + ".DBValue";
								else if (GetLanguageVariableType(prop.DbBindColumn.DataType) == "Guid")
									sValue = FormatFieldName(prop.Name) + " == Guid.Empty ? (object) DBNull.Value : " + FormatFieldName(prop.Name);
								else
									sValue = FormatFieldName(prop.Name);
								
								if (prop.DbBindColumn.NativeType == "timestamp")						
								{
									bNeedOutput = true; %>
						cmd.Parameters.Add("@New<%=prop.Name%>", null).Direction = ParameterDirection.Output;
								<% } %>
						cmd.Parameters.Add("@<%= prop.Name %>", <%=sValue%>);
							<% } %>
						<% } %>
						ExtraCommandProcessing(cmd, null, action);
						
						cmd.ExecuteNonQuery();
						<% 	if (bNeedOutput) { %>
						
						if(this.IsNew)
						{
							<%foreach(ValueProperty prop in Info.GetAllValueProperties()) {
								if (prop.DbBindColumn.IsPrimaryKey()) {%>
							<%=FormatFieldName(prop.Name)%> = (<%=GetLanguageVariableType(prop.DbBindColumn.DataType)%>)cmd.Parameters["@<%=prop.Name%>"].Value;
							<%} }%>
						}
						<% foreach(ValueProperty prop in Info.GetAllValueProperties()) {
						if (prop.DbBindColumn.NativeType == "timestamp") { %>
						<% // Replace next lines if there is an error %>
						<% // <%=FormatFieldName(prop.Name)%> = (<%=GetLanguageVariableType(prop.DbBindColumn.DataType)%>)cmd.Parameters["@New<%=prop.Name%>"].Value; %>
						<%=FormatFieldName(prop.Name)%> = cmd.Parameters["@New<%=prop.Name%>"].Value;
						<% } } %>
						<% } %>

						//Mark the object as Old (Persisted)
						MarkOld();
					}

					//Update any necessary Child Objects 
					<% foreach(ChildProperty child in Info.GetMyChildProperties()) { 
					%>if (<%=FormatFieldName(child.Name)%> != null) {
						<%=FormatFieldName(child.Name)%>.Update(<% 
							if (Info.TransactionType == TransactionType.ADO) {%>tr, <%
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
