<%
if (!Info.UseCustomLoading)
{
    if (!Info.DataSetLoadingScheme)
    {
        %>

        /// <summary>
        /// Factory method. New <see cref="<%=Info.ObjectName%>"/> object is created and loaded from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader.</param>
        /// <returns>A reference to the created <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(SafeDataReader dr)
        {
            <%
        if (CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel &&
            Info.GetRoles.Trim() != String.Empty)
        {
            %>if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
        }
        %><%= Info.ObjectName %> obj = new <%= Info.ObjectName %>();
            <%
        // DataPortal_CreateChild already takes care of marking childs
        // CurrentUnit.GenerationParams.UseChildDataPortal is enought to say when this happens
        // except Get-(SafeDataReader dr) that bypass Child DataPortal methods
        if (Info.ObjectType == CslaObjectType.EditableSwitchable ||
            (CurrentUnit.GenerationParams.UseChildDataPortal &&
            (Info.ObjectType == CslaObjectType.EditableChild ||
            Info.ObjectType == CslaObjectType.EditableChildCollection)))
        {
            %>// show the framework that this is a child object
            obj.MarkAsChild();
            <%
        }
        %>obj.Fetch(dr);
            <%
        if (LoadsChildren(Info))
        {
            %>obj.FetchChildren(dr);
            <%
        }
        if (Info.ObjectType != CslaObjectType.ReadOnlyObject && !IsCollectionType(Info.ObjectType))
        {
            %>obj.MarkOld();
            <%
            if (Info.CheckRulesOnFetch)
            {
                %>obj.BusinessRules.CheckRules();
            <%
            }
        }
        if (ActiveObjects)
        {
            %>obj.RegisterAndSubscribe();
            <%
        }
        %>

            return obj;
        }
    <%
    }
    else
    {
        %>

        /// <summary>
        /// Factory method. New <see cref="<%=Info.ObjectName%>"/> object is created and loaded from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The DataRow.</param>
        /// <returns>A reference to the created <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(DataRow<% if (IsCollectionType(Info.ObjectType)) { %>[]<% } %> dr)
        {
            <%
        if (CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel &&
            Info.GetRoles.Trim() != String.Empty)
        {
            %>if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
        }
        %><%= Info.ObjectName %> obj = new <%= Info.ObjectName %>();
            <%
        // DataPortal_CreateChild already takes care of marking childs
        // CurrentUnit.GenerationParams.UseChildDataPortal is enought to say when this happens
        // except Get-(SafeDataReader dr) that bypass Child DataPortal methods
        if (Info.ObjectType == CslaObjectType.EditableSwitchable ||
            (CurrentUnit.GenerationParams.UseChildDataPortal &&
            (Info.ObjectType == CslaObjectType.EditableChild ||
            Info.ObjectType == CslaObjectType.EditableChildCollection)))
        {
            %>// show the framework that this is a child object
            %>obj.MarkAsChild();
            <%
        }
        %>obj.Fetch(dr);
            <%
        if (LoadsChildren(Info) && !IsCollectionType(Info.ObjectType))
        {
            %>obj.FetchChildren(dr);
            <%
        }
        if (Info.ObjectType != CslaObjectType.ReadOnlyObject && !IsCollectionType(Info.ObjectType))
        {
            %>obj.MarkOld();
            <%
            if (Info.CheckRulesOnFetch)
            {
                %>obj.BusinessRules.CheckRules();
            <%
            }
        }
        if (ActiveObjects)
        {
            %>obj.RegisterAndSubscribe();
            <%
        }
        %>

            return obj;
        }
    <%
    }
}
%>
