<%
CslaObjectInfo authzInfo = Info;
if (IsCollectionType(Info.ObjectType))
{
    authzInfo = FindChildInfo(Info, Info.ItemType);
    if (authzInfo == null)
    {
        Errors.Append("Collection " + Info.ObjectName + " missing Item Type." + Environment.NewLine);
        return;
    }
}

if (!Info.UseCustomLoading)
{
    if (!Info.DataSetLoadingScheme)
    {
    bool lazyLoad4 = GetLazyLoad(Info);
    bool selfLoad4 = GetSelfLoad(Info);
    if (!IsReadOnlyType(Info.ObjectType) ||
        (Info.ParentType != string.Empty &&
        (Info.ObjectType == CslaObjectType.ReadOnlyObject || (!lazyLoad4 && !selfLoad4))))
    {
        %>

        /// <summary>
        /// Factory method. New <see cref="<%=Info.ObjectName%>"/> object is loaded from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(SafeDataReader dr)
        {
            <%
        if (authzInfo.GetRoles.Trim() != String.Empty &&
            IsCollectionType(Info.ObjectType) &&
            CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel)
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
        %>return obj;
        }
    <%
    }
    }
    else
    {
        %>

        /// <summary>
        /// Factory method. New <see cref="<%=Info.ObjectName%>"/> object is loaded from the given DataRow.
        /// </summary>
        /// <param name="dr">The DataRow to use.</param>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(DataRow<% if (IsCollectionType(Info.ObjectType)) { %>[]<% } %> dr)
        {
            <%
        if (IsCollectionType(Info.ObjectType) &&
            CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != Authorization.PropertyLevel &&
            authzInfo.GetRoles.Trim() != String.Empty)
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
