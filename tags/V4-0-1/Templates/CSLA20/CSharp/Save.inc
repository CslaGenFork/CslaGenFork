<% if (Info.DeleteRoles != String.Empty ||
        Info.UpdateRoles != String.Empty ||
        Info.NewRoles != string.Empty) { %>

        /// <summary>
        /// Saves the <%=Info.ObjectName%> to the database.
        /// </summary>
        public override <%=Info.ObjectName%> Save()
        {
            <% if (Info.ObjectType != CslaObjectType.EditableRootCollection) { %>
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a <%= Info.ObjectName %>");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a <%=Info.ObjectName%>");
            else <% } %>if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a <%=Info.ObjectName%>");
            <% if ((Info.ObjectType == CslaObjectType.EditableRoot || Info.ObjectType == CslaObjectType.DynamicEditableRoot || Info.ObjectType == CslaObjectType.EditableSwitchable) && Info.SupportUpdateProperties == true) { %>

            <%=Info.ObjectName%> result = base.Save();
            On<%=Info.ObjectName%>Saved(this, new Csla.Core.SavedEventArgs(result));
            return result;<%
            } else { %>
            return base.Save();<%
            } %>
        }
<% } %>
