		
		/// <summary>
		/// Factory method. New <see cref="<%=Info.ObjectName%>" /> object is created, based on given parameters.
		/// </summary>
		<% if (Info.ObjectType == CslaObjectType.EditableChild) { %>internal<% } else { %>public<% } %> static <%=Info.ObjectName%> New<%=Info.ObjectName%>(<%
		first = true;
		foreach (Parameter param in Info.NewObjectParameters) 
		{
			if (!first) { writer.Write(", "); }
			else { first = false; }
		%><%=param.Property.PropertyType.ToString()%> <%=FormatCamel(param.Property.Name)%><%}%>)
		{
			<% if (Info.NewRoles != String.Empty) {
				string[] newRoles = System.Text.RegularExpressions.Regex.Split(Info.NewRoles, ";");
				first = true; %>
			if (<% foreach (string role in newRoles) {
					if (!first) { %> &&
			    <% } else {
						first = false;
					} %>!System.Threading.Thread.CurrentPrincipal.IsInRole("<%=role%>")<%
				   } %>) {
					throw new System.Security.SecurityException("User not authorized to remove a <%=Info.ObjectName%>");
			}
			<% } %>			
			<% if (Info.NewObjectParameters.Count > 0) {
				Criteria crit = Info.NewObjectParameters[0].Criteria;
				string critVar = FormatCamel(crit.Name);
			%>
			<%=crit.Name%> <%=critVar%> = new <%=crit.Name%>(<% if (Info.ObjectType == CslaObjectType.EditableSwitchable) { %>false<%}%>);
			<% foreach (Parameter param in Info.NewObjectParameters) {%>
			<%=critVar%>.<%=param.Property.Name%> = <% 
				if (param.Property.PropertyType == TypeCodeEx.SmartDate) { 
					%>new SmartDate(<%=FormatCamel(param.Property.Name)%>);<%
				} else {
					%><%=FormatCamel(param.Property.Name)%>;
				<% } %>
			<%}%>
			return (<%=Info.ObjectName%>)DataPortal.Create(<%=critVar%>);
			<%}%><%
			 else if (Info.NewObjectCriteriaType != null) {%>
			return (<%=Info.ObjectName%>)DataPortal.Create(new <%=Info.NewObjectCriteriaType.Name%>());
			<% } %><% 
			else {%>
			return DataPortal.Create();
			<% } %>			
			//return (new <%=Info.ObjectName%>(<%
			first = true;
			foreach (Parameter param in Info.NewObjectParameters) {
				if (!first) {
					%>, <%
				} 
				else
				{
					first = false;
				}
			%><%=FormatCamel(param.Property.Name)%><% } %>));			
		}