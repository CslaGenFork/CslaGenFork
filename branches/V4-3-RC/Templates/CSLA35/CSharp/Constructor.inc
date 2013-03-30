
		#region Constructors
		
		protected <% if (Info.ObjectType != CslaObjectType.ReadOnlyCollection) { %>internal<% } %> <%=Info.ObjectName%>()
		{	
			// Prevent direct creation
			<% if (ActiveObjects) { 
				if (Info.ObjectType != CslaObjectType.EditableChildCollection) { %>
			RegisterAndSubscribe();
				<% } 
			} %>
			<%	if (Info.ObjectType == CslaObjectType.EditableChild || Info.ObjectType == CslaObjectType.EditableChildCollection) { %>
			
			// Show the framework that this is a Child Object
			MarkAsChild();
			<%	} %>
	    <% if (Info.ObjectType == CslaObjectType.EditableChildCollection || Info.ObjectType == CslaObjectType.EditableRootCollection) { %>
	    
			RaiseListChangedEvents = false;
		    AllowNew = <%=Info.AllowNew.ToString().ToLower()%>;
		    AllowEdit = <%=Info.AllowEdit.ToString().ToLower()%>;
		    AllowRemove = <%=Info.AllowRemove.ToString().ToLower()%>;
		    RaiseListChangedEvents = true;
	    <%	} %>

<% // set parent references
	foreach (ChildProperty prop in Info.GetMyChildProperties()) {
		CslaObjectInfo _child = FindChildInfo(Info, prop.TypeName);
		bool _fieldParentReference = false;
		if (_child == null) {
			Errors.Append("	Warning: TypeName '" + prop.TypeName + "' doesn't exist in this project");
			Errors.Append("\r\n");
		} else {
			_fieldParentReference = _child.AddParentReference;
		}
		if (_fieldParentReference) { %>
			<%=FormatFieldName(prop.Name)%>.SetParent(this);
		<% }
	} %>
		}
		
		#endregion
