		
		<% bool isSwitchable = false;
		   CslaObjectInfo childInfo = FindChildInfo(Info, Info.ItemType);
		   if (childInfo.ObjectType == CslaObjectType.EditableSwitchable) { isSwitchable = true; } %>
		/// <summary>
		/// Load <see cref="<%=Info.ObjectName%>" /> collection from the database, based on given parameters.
		/// </summary>
		protected override void DataPortal_Fetch(object criteria)
		{
			<% if (Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>locked = false;
			<% } %><%=Info.GetObjectCriteriaType.Name%> crit = (<%=Info.GetObjectCriteriaType.Name%>) criteria;
			//Retrieve all child data objects via the safe data reader
			SqlConnection cn = new SqlConnection(DB("<%= Info.DbName %>"));
			SqlCommand cmd = new SqlCommand();
			cn.Open();

			try
			{
				cmd.Connection = cn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "<%= Info.SelectProcedureName %>";
				<%foreach(Parameter p in Info.GetObjectParameters) {%>
				cmd.Parameters.Add("@<%= p.Property.Name %>", crit.<%= p.Property.Name %>.ToString());
				<%}%>
				EditFetchCommand(cmd, criteria);
				SafeDataReader dr = new SafeDataReader(cmd.ExecuteReader());
				try
				{
					while(dr.Read())
					{
						<% if (isSwitchable) { %>
						List.Add(<%=Info.ItemType%>.Get<%=Info.ItemType%>Child(dr));
						<% }
						else { %>						
						<% if ((Info.ObjectType == CslaObjectType.ReadOnlyCollection || Info.ObjectType == CslaObjectType.EditableChildCollection) && !LoadsChildren(Info)) { %>
						List.Add(<%=Info.ItemType%>.Get<%=Info.ItemType%>(dr));
						<% } else { %>
						<%=Info.ItemType%> <%=FormatCamel(Info.ItemType)%> = <%=Info.ItemType%>.New<%=Info.ItemType%><% if (isSwitchable) {%>Child<%}%>();
						<%=FormatCamel(Info.ItemType)%>.Fetch(dr);
						List.Add(<%=FormatCamel(Info.ItemType)%>);
						<% } }%>
					}
				}
				finally
				{
					dr.Close();
				}
			}
			finally
			{
				cn.Close();
				<% if (Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>locked = true;<% } %>
			}
		}
		
		
		/// <summary>
		/// Add extra parameters to the current command
		/// </summary>
		/// <param name="cmd">command to add parameters to</param>
		/// <param name="criteria">criteria object to use</param>
		protected virtual void EditFetchCommand(SqlCommand cmd, object criteria)
		{
					
		}
		
		
		
		