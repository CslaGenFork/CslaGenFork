
		/// <summary>
		/// Load a <see cref="<%=Info.ObjectName%>" /> object from given SafeDataReader.
		/// </summary>
		internal void Fetch(SafeDataReader dr)
		{
			// Retrieve the data from the passed in data reader, which may or may not have
			// a transaction associated with it
			<% if (Info.ObjectType == CslaObjectType.EditableSwitchable) { %>MarkAsChild();<% } %>
			
			// Value properties 
			<% foreach(ValueProperty prop in Info.GetAllValueProperties()) 
			{ 
				if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None) { %>
			<%= GetReaderAssignmentStatement(prop) %>
			<% 	} } %>
			
			// Child business object properties 
			<% foreach (ChildProperty childProp in Info.GetAllChildProperties()) { if (!childProp.LazyLoad) { %>
			<%=FormatFieldName(childProp.Name)%> = <%=childProp.Name%>.Get<%=childProp.Name%>(dr);
			<% } }%>
			
			ExtraFetchProcessing(dr);
			MarkOld();
			<% if (Info.ObjectType != CslaObjectType.ReadOnlyObject) { %> this.CheckRules(); <% } %>
			
		}
