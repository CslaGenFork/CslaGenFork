		
		#region Criteria
		<% foreach (Criteria crit in Info.CriteriaObjects) { %>
		
		[Serializable]
		protected internal class <%=crit.Name%> : CSLA.CriteriaBase
		{
			<% foreach (Property prop in crit.Properties) {%>
			public <%=prop.PropertyType.ToString()%> <%=FormatPascal(prop.Name)%>;
			<% } %>
			
			public <%=crit.Name%>() : base(typeof(<%=Info.ObjectName%>))
			{
			}
		}
		<% } %>
		
		#endregion
