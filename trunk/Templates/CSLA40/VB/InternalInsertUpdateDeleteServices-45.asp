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
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert", "Partial Sub Service_Insert(" + (parentType.Length > 0 ? ("parent As " + parentType + ")") : ")")));
        %>

        ''' <summary>
        ''' Inserts a new <see cref="<%= Info.ObjectName %>"/> object in the database.
        ''' </summary>
        <%
        if (parentType.Length > 0)
        {
            %>
        ''' <param name="parent">The parent object.</param>
        <%
        }
        %>
        <Csla.RunLocal()>
        Protected <%= ((!isChild && parentType.Length > 0) ? "Overrides " : "") %>Sub <%= isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert" %>(<%= (parentType.Length > 0 ? "parent As " + parentType : "") %>)
            Service_Insert(<% if (parentType.Length > 0) { %>parent<% } %>)
        End Sub

        ''' <summary>
        ''' Implements <%= isChildNotLazyLoaded ? "Child_Insert" : "DataPortal_Insert" %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
        if (parentType.Length > 0)
        {
            %>
        ''' <param name="parent">The parent object.</param>
        <%
        }
        %>Partial Sub Service_Insert(<% if (parentType.Length > 0) { %>parent As <%= parentType %><% } %>)
        End Sub
<%
    }

    if (Info.GenerateDataPortalUpdate)
    {
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update", "Partial Sub Service_Update(" + (parentType.Length > 0 && !Info.ParentInsertOnly ? ("parent As " + parentType + ")") : ")")));
        %>

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>
        ''' <param name="parent">The parent object.</param>
        <%
        }
        %>
        <Csla.RunLocal()>
        Protected <%= ((!isChild && parentType.Length > 0) ? "Overrides " : "") %>Sub <%= isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update" %>(<%= ((parentType.Length > 0 && !Info.ParentInsertOnly) ? "parent As " + parentType : "") %>)
            Service_Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %>parent<% } %>)
        End Sub

        ''' <summary>
        ''' Implements <%= isChildNotLazyLoaded ? "Child_Update" : "DataPortal_Update" %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>
        ''' <param name="parent">The parent object.</param>
        <%
        }
        %>Partial Sub Service_Update(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %>parent As <%= parentType %><% } %>)
        End Sub
    <%
    }

    if (Info.GenerateDataPortalDelete)
    {
        MethodList.Add(new AdvancedGenerator.ServiceMethod(isChildNotLazyLoaded ? "Child_DeleteSelf" : "DataPortal_DeleteSelf", "Partial Sub Service_DeleteSelf(" + (parentType.Length > 0 && !Info.ParentInsertOnly ? ("parent As " + parentType + ")") : ")")));
        %>

        ''' <summary>
        ''' Self deletes the <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>
        ''' <param name="parent">The parent object.</param>
        <%
        }
        %>
        <Csla.RunLocal()>
        Protected <%= ((!isChild && parentType.Length > 0) ? "Overrides " : "") %>Sub <%= isChildNotLazyLoaded ? "Child_DeleteSelf" : "DataPortal_DeleteSelf" %>(<%= ((parentType.Length > 0 && !Info.ParentInsertOnly) ? "parent As " + parentType : "") %>)
            Service_DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %>parent<% } %>)
        End Sub

        ''' <summary>
        ''' Implements <%= isChildNotLazyLoaded ? "Child_DeleteSelf" : "DataPortal_DeleteSelf" %> for <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            %>
        ''' <param name="parent">The parent object.</param>
        <%
        }
        %>Partial Sub Service_DeleteSelf(<% if (parentType.Length > 0 && !Info.ParentInsertOnly) { %>parent As <%= parentType %><% } %>)
        End Sub
<%
    }
}
%>
