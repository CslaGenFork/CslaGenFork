<% if (Info.DeleteRoles != String.Empty || 
		Info.UpdateRoles != String.Empty || 
		Info.NewRoles != string.Empty) { %>
		
		/// <summary>
		/// Saves the <%=Info.ObjectName%> to the database.
		/// <summary>
		public override <%=Info.ObjectName%> Save()
		{	
			<% if (Info.ObjectType != CslaObjectType.EditableRootCollection) { %>
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a <%= Info.ObjectName %>");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a <%=Info.ObjectName%>");
			else <% } %>if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a <%=Info.ObjectName%>");
			return base.Save();
		}
<% } %>
