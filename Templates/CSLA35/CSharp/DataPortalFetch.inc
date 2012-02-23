<% if (!Info.UseCustomLoading) {
	foreach (Criteria c in Info.CriteriaObjects) {
		if (c.GetOptions.DataPortal) { %>
		
		/// <summary>
		/// Retrieve an existing <see cref="<%=Info.ObjectName%>" /> Object based on data in the database. 
		/// </summary>
		<% if (c.GetOptions.RunLocal) { %>[Csla.RunLocal()]
		<% } %>protected void DataPortal_Fetch(<%=c.Name%> crit)
		{
			<% if (Info.ObjectType == CslaObjectType.EditableSwitchable ) { %>
			if (crit.IsChild)  
				MarkAsChild();
			<% } %>
			using (SqlConnection cn = new SqlConnection(DataBase.<%= Info.DbName %>Connection))
			{
				<% if (string.IsNullOrEmpty(c.GetOptions.ProcedureName)) {
					Errors.AppendFormat("Criteria '{0}' missing get procedure name", c.Name);
					Errors.AppendLine();
				} %>
				using (SqlCommand cmd = new SqlCommand("<%=c.GetOptions.ProcedureName%>", cn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					<% foreach (CslaGenerator.Metadata.Property p in c.Properties) { %>
					cmd.Parameters.AddWithValue("@<%=p.ParameterName%>", <%=GetParameterSet(p,true)%>);
					<% } %>
					cn.Open();
					ApplicationContext.LocalContext["dpCriteria"] = crit;
					ApplicationContext.LocalContext["dpConnection"] = cn;
					ApplicationContext.LocalContext["dpCommand"] = cmd;
					Fetch(cmd);
				}
			}
		}
		
		<% } 
	} %>
<% if (Info.HasGetCriteria) { %>
	<% if (!Info.DataSetLoadingScheme) { %>
		private void Fetch(SqlCommand cmd)
		{
			onFetchPre(this, EventArgs.Empty);
			using (SafeDataReader dr = new SafeDataReader(cmd.ExecuteReader()))
			{
				ApplicationContext.LocalContext["dpDataReader"] = dr;
				dr.Read();
				Fetch(dr);
				<% if (LoadsChildren(Info)) { %>		
				FetchChildren(dr);
				<% }
				if (Info.ObjectType != CslaObjectType.ReadOnlyObject) { %>
				MarkOld();
				ValidationRules.CheckRules();
				<% } %>
			}
			onFetchPost(this, EventArgs.Empty);
		}
		<% } else { %>
		private void Fetch(SqlCommand cmd)
		{
			onFetchPre(this, EventArgs.Empty);
			DataSet ds = new DataSet();
			ApplicationContext.LocalContext["dpDataSet"] = ds;
			using (SqlDataAdapter da = new SqlDataAdapter(cmd))
			{
				da.Fill(ds);
			}
			CreateRelations(ds);
			Fetch(ds.Tables[0].Rows[0]);
			<% if (LoadsChildren(Info)) { %>
			FetchChildren(ds.Tables[0].Rows[0]);
			<% }
			if (Info.ObjectType != CslaObjectType.ReadOnlyObject) { %>
			MarkOld();
			ValidationRules.CheckRules();
			<% 	if (ActiveObjects) { %>
			this.RegisterAndSubscribe();
			<% 	}
			} %>	
			onFetchPost(this, EventArgs.Empty);
		}
<!-- #include file="CreateRelations.inc" -->
		<% } %>
	<% } %>

		<!-- #include file="InternalFetch.inc" -->
<% } %>
