      
		<% 
		string parentType = Info.ParentType;
		CslaObjectInfo parentInfo = FindChildInfo(Info, parentType);
		if (parentInfo.ObjectType == CslaObjectType.EditableChildCollection)
		{
			parentType = parentInfo.ParentType;
		}
		else if (parentInfo.ObjectType == CslaObjectType.EditableRootCollection)
		{
			parentType = "";
		}
		%>
		/// <summary>
		/// Save (delete, add, update) <see cref="<%=Info.ObjectName%>" /> object to database with or without transaction.
		/// </summary>
		<% if(Info.TransactionType == TransactionType.EnterpriseServices) {%>[Transactional] 
		<%}%>internal virtual void Update(<%if(Info.TransactionType == TransactionType.ADO) {%> SqlTransaction tr<% } if (parentType.Length > 0) {%><% if (Info.TransactionType == TransactionType.ADO) { %>, <% } %><%= parentType %> parent<% } %>)
		{
			
			// Nothing to do if not dirty.
			if ( !this.IsDirty)
				return;

			//Save data to DB
			<%if(Info.TransactionType != TransactionType.ADO) {%>
			SqlConnection cn = new SqlConnection(DB("<%= Info.DbName %>"));
			cn.Open();
			<% }%>
			SqlCommand cmd = new SqlCommand();
			
			try
			{
				<%if(Info.TransactionType == TransactionType.ADO) {%>
				cmd.Connection = tr.Connection;
				cmd.Transaction = tr;
				<% } else {%>
				cmd.Connection = cn;
				<% }%>
				
				cmd.CommandType = CommandType.StoredProcedure;
				
				if(this.IsDeleted)
				{
					if(!this.IsNew)
					{
						cmd.CommandText = "<%= Info.DeleteProcedureName %>";
						<%foreach(Parameter p in Info.DeleteObjectParameters) {%>
						cmd.Parameters.Add("@<%= p.Property.Name %>", <%= FormatFieldName(p.Property.Name) %>);
						<%}%>
						<% if (parentType.Length > 0) { 
							foreach (Property prop in Info.ParentProperties) { 
								if (prop.Name.Length != 0) {%>
						cmd.Parameters.Add("@<%=prop.Name%>", parent.<%=prop.Name%>);
						<% } } } %>
						ExtraCommandProcessing(cmd, null, Command.Delete);
						cmd.ExecuteNonQuery();
					}   
				}
				else
				{
					<% bool bNeedOutput2; bNeedOutput2=false; string sValue2; %>
					if(this.IsNew)
					{
						Command action = Command.Insert;
						//Perform an insert, object has not yet been persisted
						cmd.CommandText = "<%= Info.InsertProcedureName %>";
						<% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
							if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None && prop.DbBindColumn.IsPrimaryKey() && prop.DefaultValue.Length <= 0) {
								if (GetLanguageVariableType(prop.DbBindColumn.DataType) == "Guid")
									sValue2 = FormatFieldName(prop.Name) + " == Guid.Empty ? (object) DBNull.Value : " + FormatFieldName(prop.Name);
								else
									sValue2 = FormatFieldName(prop.Name);
								
								bNeedOutput2 = true; %>
						cmd.Parameters.Add("@<%=prop.Name%>", <%=sValue2%>).Direction = ParameterDirection.Output;
						<%	} } %>
						action = Command.Insert;
					}
					else
					{
						cmd.CommandText = "<%= Info.UpdateProcedureName %>";
						<% foreach (ValueProperty prop in Info.GetAllValueProperties()) {
							if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None && prop.DbBindColumn.IsPrimaryKey() && prop.DefaultValue.Length <= 0) {
								if (GetLanguageVariableType(prop.DbBindColumn.DataType) == "Guid")
									sValue2 = FormatFieldName(prop.Name) + " == Guid.Empty ? (object) DBNull.Value : " + FormatFieldName(prop.Name);
								else
									sValue2 = FormatFieldName(prop.Name);
								
								bNeedOutput2 = true; %>
						cmd.Parameters.Add("@<%=prop.Name%>", <%=sValue2%>);
						<%	} } %>
						action = Command.Update;
					}
					
					<% foreach(ValueProperty prop in Info.GetAllValueProperties())
					{
						if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None && !(prop.DbBindColumn.IsPrimaryKey() && prop.DefaultValue.Length <= 0)) {
							if (GetLanguageVariableType(prop.DbBindColumn.DataType) == "SmartDate")
								sValue2 = FormatFieldName(prop.Name) + ".DBValue";
							else if (GetLanguageVariableType(prop.DbBindColumn.DataType) == "Guid")
								sValue2 = FormatFieldName(prop.Name) + " == Guid.Empty ? (object) DBNull.Value : " + FormatFieldName(prop.Name);
							else
								sValue2 = FormatFieldName(prop.Name);
							
							if (prop.DbBindColumn.NativeType == "timestamp")						
							{
								bNeedOutput2 = true; %>
					cmd.Parameters.Add("@New<%=prop.Name%>", null).Direction = ParameterDirection.Output;
							<% } %>
					cmd.Parameters.Add("@<%= prop.Name %>", <%=sValue2%>);
						<% } %>
					<% } %>
					<% if (parentType.Length > 0) { 
						foreach (Property prop in Info.ParentProperties) { 
								if (prop.Name.Length != 0) {%>
					cmd.Parameters.Add("@<%=prop.Name%>", parent.<%=prop.Name%>.ToString());
					<% } } } %>
					ExtraCommandProcessing(cmd, null, action);
					cmd.ExecuteNonQuery();
					<% if (bNeedOutput2) { %>
					
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
				<% foreach(ChildProperty child in Info.GetMyChildProperties()) { %>
				if (<%=FormatFieldName(child.Name)%> != null) { <%=FormatFieldName(child.Name)%>.Update(<% 
						if (Info.TransactionType == TransactionType.ADO) {%>tr,<% } %>(<%=Info.ObjectName%>)this); }
				<% } %>

			}
			finally
			{
				<% if (Info.TransactionType != TransactionType.ADO) { %>
				cn.Close();
				<% } %>
			}
		}
