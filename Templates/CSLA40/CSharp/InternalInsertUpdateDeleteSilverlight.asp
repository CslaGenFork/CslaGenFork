<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    string parentType = Info.ParentType;
    CslaObjectInfo parentInfoSl = FindChildInfo(Info, parentType);
    if (parentInfoSl == null)
        parentType = "";
    else if (parentInfoSl.ObjectType == CslaObjectType.EditableChildCollection)
        parentType = parentInfoSl.ParentType;
    else if (parentInfoSl.ObjectType == CslaObjectType.EditableRootCollection)
        parentType = "";
    else if (parentInfoSl.ObjectType == CslaObjectType.DynamicEditableRootCollection)
        parentType = "";

    if (Info.GenerateDataPortalInsert)
    {
        %>

        /// <summary>
        /// Insert the new <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        /// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void <%= isChild ? "Child_" : "DataPortal_" %>Insert(<% if (parentType.Length > 0) { %><%= parentType %> parent, <% } %>Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        {
            try
            {
                Service_Insert(<% if (parentType.Length > 0) { %>parent<% } %>);
                handler(this, null);
            }
            catch (Exception ex)
            {
                handler(null, ex);
            }
        }

        /// <summary>
        /// Implements <%= isChild ? "Child_Insert" : "DataPortal_Insert" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        partial void Service_Insert(<% if (parentType.Length > 0) { %><%= parentType %> parent<% } %>);
<%
    }

    if (Info.GenerateDataPortalUpdate)
    {
        %>

        /// <summary>
        /// Update all changes made on <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        /// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void <%= isChild ? "Child_" : "DataPortal_" %>Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent, <% } %>Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        {
            try
            {
                Service_Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %>parent<% } %>);
                handler(this, null);
            }
            catch (Exception ex)
            {
                handler(null, ex);
            }
        }

        /// <summary>
        /// Implements <%= isChild ? "Child_Update" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        partial void Service_Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>);
    <%
    }

    if (Info.GenerateDataPortalDelete)
    {
        %>

        /// <summary>
        /// Delete <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        public void <%= isChild ? "Child_" : "DataPortal_" %>DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent, <% } %>Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
        {
            try
            {
                Service_DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %>parent<% } %>);
                handler(this, null);
            }
            catch (Exception ex)
            {
                handler(null, ex);
            }
        }

        /// <summary>
        /// Implements <%= isChild ? "Child_Update" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        partial void Service_DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>);
<%
    }
}
%>
