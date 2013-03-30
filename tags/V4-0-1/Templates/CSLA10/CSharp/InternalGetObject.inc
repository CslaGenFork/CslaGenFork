
		/// <summary>
		/// Factory method. New <see cref="<%=Info.ObjectName%>" /> object is created and loaded from the given SafeDataReader.
		/// </summary>
		internal static <%=Info.ObjectName%> Get<%=Info.ObjectName%>(SafeDataReader dr)
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
			<%=Info.ObjectName%> <%=FormatCamel(Info.ObjectName)%> = new <%=Info.ObjectName%>();
			<%=FormatCamel(Info.ObjectName)%>.Fetch(dr);
			return(<%=FormatCamel(Info.ObjectName)%>);
		}
