		
		/// <summary>
		/// Marks the <see cref="<%=Info.ObjectName%>" /> object for deletion. The object will be deleted as part of the next save operation.
		/// </summary>
		public static void Delete<%=Info.ObjectName%>(<%
		first = true;
		foreach (Parameter param in Info.DeleteObjectParameters) 
		{
			if (!first) { writer.Write(", "); }
			else { first = false; }
		%><%=param.Property.PropertyType.ToString()%> <%=FormatCamel(param.Property.Name)%><%}%>)
		{
			<% if (Info.DeleteRoles != String.Empty) {
				string[] deleteRoles = System.Text.RegularExpressions.Regex.Split(Info.DeleteRoles, ";");
				first = true; %>
			if (<% foreach (string role in deleteRoles) {
					if (!first) { %> &&
			    <% } else {
						first = false;
					} %>!System.Threading.Thread.CurrentPrincipal.IsInRole("<%=role%>")<%
				   } %>) {
					throw new System.Security.SecurityException("User not authorized to remove a <%=Info.ObjectName%>");
			}
			<% } %>
			<% if (Info.DeleteObjectParameters.Count > 0) {
				Criteria crit = Info.DeleteObjectParameters[0].Criteria;
				string critVar = FormatCamel(crit.Name);
			%>
			<%=crit.Name%> <%=critVar%> = new <%=crit.Name%>(<% if (Info.ObjectType == CslaObjectType.EditableSwitchable) { %>false<%}%>);
			<% foreach (Parameter param in Info.DeleteObjectParameters) {%>
			<%=critVar%>.<%=param.Property.Name%> = <%=FormatCamel(param.Property.Name)%>;
			<%}%>
			DataPortal.Delete(<%=critVar%>);
			<%}%>
		}
