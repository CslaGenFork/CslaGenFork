<% if (Info.ToStringProperty != null && Info.ToStringProperty.Count > 0 &&
		Info.ObjectType != CslaObjectType.ReadOnlyObject) { %>
		
		#region System.Object Overrides

		/// <summary>
		/// Returns a string that represents a current <see cref="<%=Info.ObjectName%>" />
		/// </summary>
		public override String ToString()
		{
			// Return the Primary Key As a String
			return <% 
			bool firstLine = true;
			foreach (CslaGenerator.Metadata.Property prop in Info.ToStringProperty) {
				if (!firstLine) {
					%> + ", " + <%
				 } else { 
					firstLine = false;
				}
				%><%=prop.Name %>.ToString()<%
			 }%>;
		}
       
		#endregion
<% } %>
