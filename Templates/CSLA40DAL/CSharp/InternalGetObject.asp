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

if (!Info.UseCustomLoading && !Info.DataSetLoadingScheme)
{
    bool lazyLoad4 = GetLazyLoad(Info);
    bool selfLoad4 = GetSelfLoad(Info);
    if (!IsReadOnlyType(Info.ObjectType) ||
        (Info.ParentType != string.Empty &&
        (Info.ObjectType == CslaObjectType.ReadOnlyObject || (!lazyLoad4 && !selfLoad4))))
    {
        %>

        /// <summary>
        /// Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        <%
        if (useParentReference)
        {
            %>
        /// <param name="parentList">The parent list reference.</param>
        <%
        }
        %>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(SafeDataReader dr<%= useParentReference ? (", " + Info.ParentType + " parentList") : "" %>)
        {
            <%
        if (authzInfo.GetRoles.Trim() != String.Empty &&
            IsCollectionType(Info.ObjectType) &&
            CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
        {
            %>if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
        }
        %><%= Info.ObjectName %> obj = new <%= Info.ObjectName %>();
            <%
        if (Info.ObjectType == CslaObjectType.EditableSwitchable ||
            (Info.ObjectType == CslaObjectType.EditableChild ||
            Info.ObjectType == CslaObjectType.EditableChildCollection))
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
        if (useParentReference)
        {
            %>obj.ParentList = parentList;
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
        %>return obj;
        }
    <%
    }
}
%>
