<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    string parentType = Info.ParentType;
    if (parentInfo == null)
        parentType = "";
    else if (parentInfo.ObjectType == CslaObjectType.EditableChildCollection)
        parentType = parentInfo.ParentType;
    else if (parentInfo.ObjectType == CslaObjectType.EditableRootCollection)
        parentType = "";
    else if (parentInfo.ObjectType == CslaObjectType.DynamicEditableRootCollection)
        parentType = "";

    if (Info.GenerateDataPortalInsert)
    {
        MethodList.Add("partial void Service_Insert(" + (parentType.Length > 0 ? (parentType + " parent)") : ")"));
        %>

        /// <summary>
        /// Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        /// </summary>
        <%
        if (parentType.Length > 0)
        {
            %>/// <param name="parent">The parent object.</param>
        <%
        }
        %>/// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Insert(<% if (parentType.Length > 0) { %><%= parentType %> parent, <% } %>Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
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
        /// Implements <%= isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0)
        {
            %>/// <param name="parent">The parent object.</param>
        <%
        }
        %>partial void Service_Insert(<% if (parentType.Length > 0) { %><%= parentType %> parent<% } %>);
<%
    }

    if (Info.GenerateDataPortalUpdate)
    {
        MethodList.Add("partial void Service_Update(" + (parentType.Length > 0 && !Info.ParentInsertOnly ? (parentType + " parent)") : ")"));
        %>

        /// <summary>
        /// Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>/// <param name="parent">The parent object.</param>
        <%
        }
        %>/// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent, <% } %>Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
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
        /// Implements <%= isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>/// <param name="parent">The parent object.</param>
        <%
        }
        %>partial void Service_Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>);
    <%
    }

    if (Info.GenerateDataPortalDelete)
    {
        MethodList.Add("partial void Service_DeleteSelf(" + (parentType.Length > 0 && !Info.ParentInsertOnly ? (parentType + " parent)") : ")"));
        %>

        /// <summary>
        /// Self deletes the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>/// <param name="parent">The parent object.</param>
        <%
        }
        %>/// <param name="handler">The asynchronous handler.</param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void <%= isChildNotLazyLoaded ? "Child_" : "DataPortal_" %>DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent, <% } %>Csla.DataPortalClient.LocalProxy<<%= Info.ObjectName %>>.CompletedHandler handler)
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
        /// Implements <%= isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>/// <param name="parent">The parent object.</param>
        <%
        }
        %>partial void Service_DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>);
<%
    }
}
%>
