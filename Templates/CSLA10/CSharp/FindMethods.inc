		<% if (Info.FindMethodsParameters.Count > 0) {%>

		#region Find Methods
		<% foreach (Property prop in Info.FindMethodsParameters) { %>
		
		/// <summary>
		/// Find a <see cref="<%=Info.ItemType%>" /> object in the <see cref="<%=Info.ObjectName%>" /> collection, based on given <%=prop.Name%>.
		/// </summary>
		public <%=Info.ItemType%> Find<%=Info.ItemType%>By<%=prop.Name%>(<%=prop.PropertyType.ToString()%> <%=FormatCamel(prop.Name)%>)
		{
			foreach(<%=Info.ItemType%> obj in base.List)
			{
				if (obj.<%=prop.Name%> == <%=FormatCamel(prop.Name)%>)
				{
					return obj;
				}
			}
			return null;
		}
		<% } %>
		
		#endregion
		
		<% } %>