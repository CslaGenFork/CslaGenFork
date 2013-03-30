		
		#region Business Object Rules and Validation
		<% bool hasParentObject = (Info.InheritedType.Type != String.Empty || Info.InheritedType.ObjectName != String.Empty); 
		if (hasParentObject == false) { %>
		
		/// <summary>
		/// Check rules for all properties of a <see cref="<%=Info.ObjectName%>" />
		/// </summary>
		protected void CheckRules()
		{
			CheckRules("");
		}
		<% } %>
		
		/// <summary>
		/// Check rules for the given property of a <see cref="<%=Info.ObjectName%>" />
		/// </summary>
		/// <remarks>
		/// When this method is overriden in a inherited class, base class method should be called.
		/// </remarks>
		protected <% if (hasParentObject) { %>override<% } else { %>virtual<% } %> void CheckRules(string propertyName)
		{
			<% if (hasParentObject) { %>
			
			base.CheckRules(propertyName);
			<% } %>
			<% foreach (ValueProperty prop in Info.ValueProperties) {
				if (prop.Rules.Count > 0) { %>
			
			if (propertyName == "" || propertyName == "<%=prop.Name%>") {
			<% foreach (CslaGenerator.Metadata.Rule rule in prop.Rules) { %>
				BrokenRules.Assert("<%=rule.Name %>", "<%=rule.Description %>", 
								   "<%=prop.Name %>", <%=rule.AssertExpression%>);
			<% } %>
			}
			<% } } %>
		}
		
		#endregion
		