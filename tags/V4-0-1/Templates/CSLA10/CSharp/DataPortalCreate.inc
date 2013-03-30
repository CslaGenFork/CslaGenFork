		
		/// <summary>
		/// Set default values for the <see cref="<%=Info.ObjectName%>" /> object's properties.
		/// </summary>
		[RunLocal()]
		protected override void DataPortal_Create(Object criteria)
		{
			<%//if (Info.ObjectType != CslaObjectType.EditableRoot) {%>
			<%if (Info.NewObjectCriteriaType != null) { %>
			<%=Info.NewObjectCriteriaType.Name%> crit = (<%=Info.NewObjectCriteriaType.Name%>) criteria; <% } %>
			<% if (Info.ObjectType == CslaObjectType.EditableSwitchable) { %>if (crit.IsChild) { MarkAsChild(); }<% } %>
			<%//}%>
			<% if (Info.ObjectType != CslaObjectType.ReadOnlyObject) { %>
			<%}%>
			<%foreach (Parameter param in Info.NewObjectParameters) {%>
			this.<%=FormatFieldName(param.Property.Name) %> = crit.<%=param.Property.Name%>;
			<% } %>	
			this.CheckRules();
		}
   