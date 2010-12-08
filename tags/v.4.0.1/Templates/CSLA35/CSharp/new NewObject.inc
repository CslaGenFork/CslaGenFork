<% 
foreach (Criteria c in Info.CriteriaObjects) {
	if (c.CreateOptions.Factory) {
		string strNewParams = string.Empty;
		string strNewCritParams = string.Empty;
		for (int i = 0; i<c.Properties.Count; i++) {
			if (i > 0) {
				strNewParams += ", ";
				strNewCritParams += ", ";
			}
			strNewParams += string.Concat(GetDataType(c.Properties[i]), " ", FormatCamel(c.Properties[i].Name));
			strNewCritParams += FormatCamel(c.Properties[i].Name);
		} %>
		
		/// <summary>
		/// Factory method. New <see cref="<%=Info.ObjectName%>" /> Object is created, based on given parameters.
		/// </summary>
		<% if (Info.ObjectType == CslaObjectType.EditableChild) { 
		%>internal<% } else { %>public<% } %> static <%=Info.ObjectName%> New<%=Info.ObjectName%><%=c.CreateOptions.FactorySuffix.Trim()%>(<%= strNewParams %>)
		{	
			<% if (Info.NewRoles != String.Empty) { %>
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to create a <%= Info.ObjectName %>");
			<% } %>
			<% if (Info.ObjectType == CslaObjectType.EditableSwitchable)
				if (strNewCritParams.Length > 0) {
					strNewCritParams = "false, " + strNewCritParams; 
				} else {
					strNewCritParams = "false" ;
				}
			%>
			return <% if (ActiveObjects) { %>ActiveObjects.<% } %>DataPortal.Create<<%= Info.ObjectName %>>(new <%= c.Name %>(<%= strNewCritParams %>));
		}
<% } 
} %>
