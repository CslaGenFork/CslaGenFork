<%
if (CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    string parentType = Info.ParentType;
    if (parentInfo == null)
        parentType = "";
    else if (parentInfo.IsEditableChildCollection())
        parentType = parentInfo.ParentType;
    else if (parentInfo.IsEditableRootCollection())
        parentType = "";
    else if (parentInfo.IsDynamicEditableRootCollection())
        parentType = "";

    if (Info.GenerateDataPortalInsert)
    {
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert", "partial void Service_Insert(" + (parentType.Length > 0 ? (parentType + " parent)") : ")")));
        %>

        /// <summary>
        /// Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        /// </summary>
        <%
        if (parentType.Length > 0)
        {
            %>
        /// <param name="parent">The parent object.</param>
        <%
        }
        %>
        [RunLocal]
        protected <%= ((!isChild && parentType.Length > 0) ? "override " : "") %>void <%= isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert" %>(<%= (parentType.Length > 0 ? parentType + " parent" : "") %>)
        {
            Service_Insert(<% if (parentType.Length > 0) { %>parent<% } %>);
        }

        /// <summary>
        /// Implements <%= isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0)
        {
            %>
        /// <param name="parent">The parent object.</param>
        <%
        }
        %>partial void Service_Insert(<% if (parentType.Length > 0) { %><%= parentType %> parent<% } %>);
<%
    }

    if (Info.GenerateDataPortalUpdate)
    {
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update", "partial void Service_Update(" + (parentType.Length > 0 && !Info.ParentInsertOnly ? (parentType + " parent)") : ")")));
        %>

        /// <summary>
        /// Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>
        /// <param name="parent">The parent object.</param>
        <%
        }
        %>
        [RunLocal]
        protected <%= ((!isChild && parentType.Length > 0) ? "override " : "") %>void <%= isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update" %>(<%= ((parentType.Length > 0 && !Info.ParentInsertOnly) ? parentType + " parent" : "") %>)
        {
            Service_Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %>parent<% } %>);
        }

        /// <summary>
        /// Implements <%= isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>
        /// <param name="parent">The parent object.</param>
        <%
        }
        %>partial void Service_Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>);
    <%
    }

    if (Info.GenerateDataPortalDelete)
    {
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_DeleteSelf" : "DataPortal_DeleteSelf", "partial void Service_DeleteSelf(" + (parentType.Length > 0 && !Info.ParentInsertOnly ? (parentType + " parent)") : ")")));
        %>

        /// <summary>
        /// Self deletes the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>
        /// <param name="parent">The parent object.</param>
        <%
        }
        %>
        [RunLocal]
        protected <%= ((!isChild && parentType.Length > 0) ? "override " : "") %>void <%= isChildNotLazyLoaded ? "Child_DeleteSelf" : "DataPortal_DeleteSelf" %>(<%= ((parentType.Length > 0 && !Info.ParentInsertOnly) ? parentType + " parent" : "") %>)
        {
            Service_DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %>parent<% } %>);
        }

        /// <summary>
        /// Implements <%= isChildNotLazyLoaded ? "Child_DeleteSelf" : "DataPortal_DeleteSelf" %> for <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>
        /// <param name="parent">The parent object.</param>
        <%
        }
        %>partial void Service_DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %><%= parentType %> parent<% } %>);
<%
    }
}
%>
