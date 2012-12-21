
		#region Authorization

		public static bool CanGetObject()
		{
		<% if (Info.GetRoles.Trim() != String.Empty) { %>
			<% String[] getRoles = System.Text.RegularExpressions.Regex.Split(Info.GetRoles, ";");
			foreach(String role in getRoles) 
			{ %>
			if (Csla.ApplicationContext.User.IsInRole("<%=role.Trim()%>"))
				return true;
			<% } %>
			return false;
		<% } else { %>
			return true;
		<% } %>
		}
		
	<% if (Info.ObjectType != CslaObjectType.ReadOnlyCollection &&
			Info.ObjectType != CslaObjectType.ReadOnlyObject &&
			Info.ObjectType != CslaObjectType.NameValueList) { %>
		public static bool CanDeleteObject()
		{
		<% if (Info.DeleteRoles.Trim() != String.Empty) { %>
			<% String[] deleteRoles = System.Text.RegularExpressions.Regex.Split(Info.DeleteRoles, ";");
			foreach(String role in deleteRoles)
			{ %>
			if (Csla.ApplicationContext.User.IsInRole("<%=role.Trim()%>"))
				return true;
			<% } %>
			return false;
		<% } else { %>
			return true;
		<% } %>
		}

		public static bool CanAddObject()
		{
		<% if (Info.NewRoles.Trim() != String.Empty) { %>
			<% String[] newRoles = System.Text.RegularExpressions.Regex.Split(Info.NewRoles, ";");
			foreach(String role in newRoles)
			{ %>
			if (Csla.ApplicationContext.User.IsInRole("<%=role.Trim()%>"))
				return true;
			<% } %>
			return false;
		<% } else { %>
			return true;
		<% } %>
		}

		public static bool CanEditObject()
		{
		<% if (Info.UpdateRoles.Trim() != String.Empty) { %>
			<% String[] updateRoles = System.Text.RegularExpressions.Regex.Split(Info.UpdateRoles, ";");
			foreach(String role in updateRoles)
			{ %>
			if (Csla.ApplicationContext.User.IsInRole("<%=role.Trim()%>"))
				return true;
			<% } %>
			return false;
		<% } else { %>
			return true;
		<% } %>
		}
		
	<% } %>
		#endregion
