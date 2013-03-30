		<% if (Info.DeleteRoles != String.Empty || Info.UpdateRoles != String.Empty) { 
			string[] deleteRoles = System.Text.RegularExpressions.Regex.Split(Info.DeleteRoles, ";");
			string[] updateRoles = System.Text.RegularExpressions.Regex.Split(Info.UpdateRoles, ";");
		%>
		
		/// <summary>
		/// Saves the <%=Info.ObjectName%> to the database.
		/// <summary>
		public override BusinessBase Save()
		{
			if (IsDeleted)
			{
				<% if (Info.DeleteRoles != String.Empty) {
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
			}
			else
			{
				// No deletion - we're adding or updating
				<% if (Info.UpdateRoles != String.Empty) { 
					first = true; %>
				if (<% foreach (string role in updateRoles) {
						if (!first) { %> &&
				    <% 	} else {
							first = false;
						} %>!System.Threading.Thread.CurrentPrincipal.IsInRole("<%=role%>")<%
					   } %>) {
						throw new System.Security.SecurityException("User not authorized to update a <%=Info.ObjectName%>");
				}
				<% } %>
			}
			
			return (base.Save);
		}
		<% } %>