		
		#region Constructors
		
		protected <%=Info.ObjectName%>Base()
		{
			// Prevent direct creation
			<%	if (Info.ValueProperties.Count > 0) {
				first = true;
				foreach (ValueProperty prop in Info.ValueProperties) {
					if (prop.DefaultValue.Length > 0) {
						if (first) { %>
			
			// Set defaults for properties
			<%				first = false;
						} %>
			<%=prop.Name%> = <%=prop.DefaultValue%>;
			<%		}
				}
				} %>
			<%	if (Info.ObjectType == CslaObjectType.EditableChild || Info.ObjectType == CslaObjectType.EditableChildCollection) { %>
			
			// Show the framework that this is a child object
			MarkAsChild();
			<% } %>
			<%	if (Info.ObjectType == CslaObjectType.EditableRootCollection || Info.ObjectType == CslaObjectType.EditableChildCollection || Info.ObjectType == CslaObjectType.ReadOnlyCollection) { %>
			
			// Allow this collection to be sorted
			AllowSort = true;
			<%	} %>
		}
		
		#endregion
