		
		/// <summary>
		/// Retrieve an existing <see cref="<%=Info.ObjectName%>" /> object based on data in the database. 
		/// </summary>
		protected override void DataPortal_Fetch(object criteria)
		{
			<%=Info.GetObjectCriteriaType.Name%> crit = (<%=Info.GetObjectCriteriaType.Name%>) criteria;
			<% if (Info.ObjectType == CslaObjectType.EditableSwitchable) { %>
			if (crit.IsChild) { MarkAsChild(); }
			
			<% } %>
			SqlConnection cn = new SqlConnection(DB("<%= Info.DbName %>"));
			SqlCommand cmd = new SqlCommand();
			cn.Open();
			bool found = false;
			
			try
			{
					cmd.Connection  = cn;
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "<%= Info.SelectProcedureName %>";
					<%foreach(Parameter p in Info.GetObjectParameters) {%>
					cmd.Parameters.Add("@<%=p.Property.Name%>", crit.<%=p.Property.Name%>.ToString());
					<%}%>
					ExtraCommandProcessing(cmd, crit, Command.Fetch);
					
					SafeDataReader dr = new SafeDataReader(cmd.ExecuteReader());					
					
					try	
					{
						if (dr.Read())
						{
							found = true;
							<% foreach(ValueProperty prop in Info.ValueProperties) 
							{
								if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None) { %>
							<%=GetReaderAssignmentStatement(prop)%>
							<%	} } %>
							<% foreach(ValueProperty prop in Info.InheritedValueProperties) 
							{
								if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None) { %>
							<%=GetReaderAssignmentStatement(prop)%>
							<%	} } %>	

							// Load Children here, if there are any
							<% if (LoadsChildren(Info)) { %>
							<% foreach (ChildProperty childProp in Info.ChildProperties) { if (!childProp.LazyLoad) { %>
							dr.NextResult();
							<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(dr);
							<% } }

							   foreach (ChildProperty childProp in Info.InheritedChildProperties) { if (!childProp.LazyLoad) { %>
							dr.NextResult();
							<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(dr);
							<% } }

							   foreach (ChildProperty childProp in Info.ChildCollectionProperties) { if (!childProp.LazyLoad) { %>
							dr.NextResult();
							<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(dr);
							<% } }

							   foreach (ChildProperty childProp in Info.InheritedChildCollectionProperties) { if (!childProp.LazyLoad) { %>
							dr.NextResult();
							<%=FormatFieldName(childProp.Name)%> = <%=childProp.TypeName%>.Get<%=childProp.TypeName%>(dr);
							<% } }%>
							<% }%>
							ExtraFetchProcessing(dr);
							<% if (Info.ObjectType != CslaObjectType.ReadOnlyObject) { %>
							this.CheckRules();
							<%}%>
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
				<% if (Info.ObjectType != CslaObjectType.ReadOnlyObject) {
				%> if (found)
				{
					MarkOld();
				}<% } %>					
			}
		}
		
