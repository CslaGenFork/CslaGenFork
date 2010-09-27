		
		#region State Fields
		<% 
			// Value Properties
			foreach (ValueProperty prop in Info.ValueProperties) { %><% if (!prop.Undoable) { %>
		[NotUndoable]<% } %>
		protected <%=prop.PropertyType.ToString()%> <%=FormatFieldName(prop.Name)%> = <%=GetInitValue(prop.PropertyType)%>;<%
			} 
			// If object has Child properties, then add new line
			if (Info.ChildProperties.Count > 0 || Info.ChildCollectionProperties.Count > 0) { %><%= "\n" %><% }
			
			// Child Properties
			foreach (ChildProperty prop in Info.GetMyChildProperties()) {%>
		protected <%=prop.TypeName%> <%=FormatFieldName(prop.Name)%> = new <%=prop.TypeName%>();<% 
				if (prop.LazyLoad) { %>
		private bool <%=FormatFieldName(prop.Name + "Loaded")%> = false;<% } 
			} %>
			
		#endregion
