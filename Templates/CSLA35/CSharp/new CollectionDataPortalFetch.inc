<% if (!Info.UseCustomLoading) {
	foreach (Criteria c in Info.CriteriaObjects) {
		if (c.GetOptions.DataPortal) { %>
		
		/// <summary>
		/// Load <see cref="<%=Info.ObjectName%>" /> collection from the database, based on given parameters.
		/// </summary>
		protected void DataPortal_Fetch(<%=c.Name%> crit)
		{
			using (SqlConnection cn = new SqlConnection(DataBase.<%= Info.DbName %>Connection))
			{
				using (SqlCommand cmd = cn.CreateCommand())
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "<%= c.GetOptions.ProcedureName %>";
					<% foreach (CslaGenerator.Metadata.Property p in c.Properties) { %>
					cmd.Parameters.AddWithValue("@<%= p.ParameterName %>", <%=GetParameterSet(p,true)%>);
					<% } %>
					cn.Open();
					ApplicationContext.LocalContext["dpCriteria"] = crit;
					LoadCollection(cmd);
					<% if (Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>IsReadOnly = true;<% } %>
				}
			}
		}
		<% }
	} %>

	<% if (Info.HasGetCriteria) { %>
		<% if (!Info.DataSetLoadingScheme) { %>
		private void LoadCollection(SqlCommand cmd)
		{
			ApplicationContext.LocalContext["dpCommand"] = cmd;
			ApplicationContext.LocalContext["dpConnection"] = cmd.Connection;
			onFetchPre(this, EventArgs.Empty);
			using (SafeDataReader dr = new SafeDataReader(cmd.ExecuteReader()))
			{
				Fetch(dr);
			}
			ApplicationContext.LocalContext["dpCommand"] = cmd;
			ApplicationContext.LocalContext["dpConnection"] = cmd.Connection;
			onFetchPost(this, EventArgs.Empty);
		}
		
		<% } else { %>
		private void LoadCollection(SqlCommand cmd)
		{
			ApplicationContext.LocalContext["dpCommand"] = cmd;
			ApplicationContext.LocalContext["dpConnection"] = cmd.Connection;
			onFetchPre(this, EventArgs.Empty);
			DataSet ds = new DataSet();
			ApplicationContext.LocalContext["dpDataSet"] = ds;
			using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
				da.Fill(ds);
			}
			CreateRelations(ds);
			Fetch(ds.Tables[0].Rows);
			ApplicationContext.LocalContext["dpCommand"] = cmd;
			ApplicationContext.LocalContext["dpConnection"] = cmd.Connection;
			onFetchPost(this, EventArgs.Empty);
		}
		
<!-- #include file="CreateRelations.inc" -->
		<% } %>
	<% }
 	bool isSwitchable = false;
	CslaObjectInfo childInfo = FindChildInfo(Info, Info.ItemType);
	if (childInfo.ObjectType == CslaObjectType.EditableSwitchable) {
		isSwitchable = true;
	} %>
	<% if (!Info.DataSetLoadingScheme) { %>
		/// <summary>
		/// Load all <see cref="<%=Info.ObjectName%>" /> collection items from given SafeDataReader.
		/// </summary>
		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;<% if (Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>
			IsReadOnly = false;<% } %>
			while (dr.Read()) 
			{
				<%= Info.ItemType %> obj = <%= Info.ItemType %>.Get<%= Info.ItemType %>(dr);
				Add(obj);
			}<% if (Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>
			IsReadOnly = true;<% } %>
			RaiseListChangedEvents = true;
		}
	<% } else { %>
		/// <summary>
		/// Load all <see cref="<%=Info.ObjectName%>" /> collection items from given DataRow array.
		/// </summary>
		private void Fetch(DataRow[] rows)
		{
			RaiseListChangedEvents = false;<% if (Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>
			IsReadOnly = false;<% } %>
			foreach (DataRow row in rows) {
				<%= Info.ItemType %> obj = <%= Info.ItemType %>.Get<%= Info.ItemType %>(row);
				Add(obj);
			}<% if (Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>
			IsReadOnly = true;<% } %>
			RaiseListChangedEvents = true;
		}
		<% if (Info.HasGetCriteria) { %>
		/// <summary>
		/// Load all <see cref="<%=Info.ObjectName%>" /> collection items from given DataTable.
		/// </summary>
		private void Fetch(DataRowCollection rows)
		{
			RaiseListChangedEvents = false;<% if (Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>
			IsReadOnly = false;<% } %>
			foreach (DataRow row in rows) {
				<%= Info.ItemType %> obj = <%= Info.ItemType %>.Get<%= Info.ItemType %>(row);
				Add(obj);
			}<% if (Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>
			IsReadOnly = true;<% } %>
			RaiseListChangedEvents = true;
		}
		<% } %>
	<% } %>
	
<% } %>
