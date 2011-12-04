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
    bool lazyLoad4 = GetLazyLoad(Info);
    bool selfLoad4 = GetSelfLoad(Info);
    if (!Info.DataSetLoadingScheme)
    {
        if (!IsReadOnlyType(Info.ObjectType) ||
            (Info.ParentType != string.Empty &&
            (Info.ObjectType == CslaObjectType.ReadOnlyObject || (!lazyLoad4 && !selfLoad4))))
        {
            %>

        /// <summary>
        /// Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(SafeDataReader dr)
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
            if (selfLoad4 && !IsCollectionType(Info.ObjectType))
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
            %>return obj;
        }
    <%
        }
    }
    else
    {
        %>

        /// <summary>
        /// Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> object from the given DataRow.
        /// </summary>
        /// <param name="dr">The DataRow to use.</param>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(DataRow<% if (IsCollectionType(Info.ObjectType)) { %>[]<% } %> dr)
        {
            <%
        if (IsCollectionType(Info.ObjectType) &&
            CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
            authzInfo.GetRoles.Trim() != String.Empty)
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
        if (selfLoad4 && !IsCollectionType(Info.ObjectType))
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
        %>

            return obj;
        }
    <%
    }
}
%>
