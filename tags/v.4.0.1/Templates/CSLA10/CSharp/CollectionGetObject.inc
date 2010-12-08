		
		/// <summary>
		/// Factory method. New <see cref="<%=Info.ObjectName%>" /> collection is loaded from the database, based on given parameters.
		/// </summary>
		<% if(Info.ObjectType == CslaObjectType.EditableChildCollection) { %>internal<% } else { %>public<% } %> static <%=Info.ObjectName%> Get<%=Info.ObjectName%>(<%
		first = true;
		foreach (Parameter param in Info.GetObjectParameters) 
		{
			if (!first) { writer.Write(", "); }
			else { first = false; }
		%>	<%if (param.Property.PropertyType == TypeCodeEx.SmartDate) {%>string<%}else{%><%=param.Property.PropertyType.ToString()%><%}%> <%=FormatCamel(param.Property.Name)%>
		<%}%>)
		{
			<% if (Info.GetRoles != String.Empty) {
				string[] getRoles = System.Text.RegularExpressions.Regex.Split(Info.GetRoles, ";");
				first = true; %>
			if (<% foreach (string role in getRoles) {
					if (!first) { %> &&
			    <% } else {
						first = false;
					} %>!System.Threading.Thread.CurrentPrincipal.IsInRole("<%=role%>")<%
				   } %>) {
					throw new System.Security.SecurityException("User not authorized to remove a <%=Info.ObjectName%>");
			}
			<% } %>
			<% if (Info.GetObjectParameters.Count > 0) {
				Criteria crit = Info.GetObjectParameters[0].Criteria;
				string critVar = FormatCamel(crit.Name);
			%>
			<%=crit.Name%> <%=critVar%> = new <%=crit.Name%>();
			<% foreach (Parameter param in Info.GetObjectParameters) {%>
			<%=critVar%>.<%=param.Property.Name%> = <% 
				if (param.Property.PropertyType == TypeCodeEx.SmartDate) { 
					%>new SmartDate(<%=FormatCamel(param.Property.Name)%>);<%
				} else {
					%><%=FormatCamel(param.Property.Name)%>;
				<% } %>
			<%}%>
			return (<%=Info.ObjectName%>)DataPortal.Fetch(<%=critVar%>);
			<%} else if (Info.GetObjectCriteriaType != null) {%>
			return (<%=Info.ObjectName%>)DataPortal.Fetch(new <%=Info.GetObjectCriteriaType.Name%>(<% if (Info.ObjectType == CslaObjectType.EditableSwitchable) { %>false<%}%>));
			<%} else {%>
			return DataPortal.Fetch();
			<% } %>
		}
