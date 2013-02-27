<%
bool useParentReference = (Info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
    (Info.ObjectType == CslaObjectType.ReadOnlyCollection && Info.ItemType != string.Empty)) && itemInfo.AddParentReference;
bool isRODeepLoadCollection =
    Info.ObjectType == CslaObjectType.ReadOnlyCollection &&
    Info.ItemType != string.Empty &&
    IsReadOnlyType(itemInfo.ObjectType) &&
    ancestorLoaderLevel == 0 &&
    ParentLoadsROChildren(Info);

bool useAuthz = false;
if (!IsReadOnlyType(itemInfo.ObjectType))
{
    if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
        CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
    {
        if (CurrentUnit.GenerationParams.UsesCslaAuthorizationProvider ||
            itemInfo.AuthzProvider != AuthorizationProvider.Custom)
        {
            if (!String.IsNullOrWhiteSpace(itemInfo.NewRoles) ||
                !String.IsNullOrWhiteSpace(itemInfo.DeleteRoles))
            {
                useAuthz = true;
            }
        }
        else if (itemInfo.NewAuthzRuleType.Constructors.Count > 0 ||
                 itemInfo.DeleteAuthzRuleType.Constructors.Count > 0)
        {
            useAuthz = true;
        }
    }
}
bool needsBusiness =
    (itemInfo.RemoveItem && itemInfo.ObjectType == CslaObjectType.EditableChild) ||
    Info.ContainsItem;

if (!needsBusiness)
{
    foreach (Criteria crit in itemInfo.CriteriaObjects)
    {
        if (crit.CreateOptions.AddRemove ||
            (crit.DeleteOptions.AddRemove && crit.Properties.Count > 0 && itemInfo.ObjectType != CslaObjectType.EditableChild))
        {
            needsBusiness = true;
            break;
        }
    }
}

if (useParentReference || isRODeepLoadCollection || useAuthz || needsBusiness)
{
    %>

        #region Collection Business Methods
        <%
    if ((useParentReference || isRODeepLoadCollection) && !useAuthz)
    {
        %>

        /// <summary>
        /// Adds a new <see cref="<%= Info.ItemType %>"/> item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>
        /// There is no valid Parent property (inexistant or null).
        /// The Add method is redefined so it takes care of filling the ParentList property.
        /// </remarks>
        public new void Add(<%= Info.ItemType %> item)
        {
            item.ParentList = this;
            base.Add(item);
        }
        <%
    }
    else if (useAuthz)
    {
        if (itemInfo.NewRoles.Trim() != String.Empty)
        {
            %>

        /// <summary>
        /// Adds a new <see cref="<%= Info.ItemType %>"/> item to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        <%
        if (useParentReference || isRODeepLoadCollection)
        {
            %>
        /// <remarks>
        /// There is no valid Parent property (inexistant or null).
        /// The Add method is redefined so it takes care of filling the ParentList property.
        /// </remarks>
        <%
        }
        %>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to add items to the collection.</exception>
        public new void Add(<%= Info.ItemType %> item)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to create a <%= Info.ItemType %>.");

        <%
        if (useParentReference || isRODeepLoadCollection)
        {
            %>
            item.ParentList = this;
        <%
        }
        %>
            base.Add(item);
        }
        <%
        }
        if (itemInfo.DeleteRoles.Trim() != String.Empty)
        {
            %>

        /// <summary>
        /// Removes a <see cref="<%= Info.ItemType %>"/> item from the collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns><c>true</c> if the item was removed from the collection, otherwise <c>false</c>.</returns>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        public new bool Remove(<%= Info.ItemType %> item)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a <%= Info.ItemType %>.");

            return base.Remove(item);
        }
        <%
        }
    }

    foreach (Criteria crit in itemInfo.CriteriaObjects)
    {
        if (crit.CreateOptions.AddRemove)
        {
            if (UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                %>

#if !SILVERLIGHT
<%
            }
            if (CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                %>
<!-- #include file="AddItem.asp" -->
<%
            }
            if (!UseSilverlight() && CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                %>
<!-- #include file="AddItemAsync.asp" -->
<%
            }
            if (UseBoth() && !CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                %>

#else
<%
            }
            if (UseSilverlight() && !CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                %>
<!-- #include file="AddItemAsync.asp" -->
<%
            }
            if (UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous)
            {
                %>

#endif
<%
            }
            if (UseSilverlight() && CurrentUnit.GenerationParams.GenerateAsynchronous)
            {
                %>
<!-- #include file="AddItemAsync.asp" -->
<%
            }
        }

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

        if (Info.ObjectType == CslaObjectType.DynamicEditableRootCollection &&
            crit.DeleteOptions.AddRemove &&
            crit.Properties.Count > 0)
        {
            string prms = string.Empty;
            string factoryParams = string.Empty;
            string paramName = string.Empty;
            string[] factoryParamsArray = new string[crit.Properties.Count];
            string[] paramNameArray = new string[crit.Properties.Count];
            for (int i = 0; i < crit.Properties.Count; i++)
            {
                Property param = crit.Properties[i];
                prms += string.Concat(", ", GetDataTypeGeneric(param, param.PropertyType), " ", FormatCamel(param.Name));
                factoryParams += string.Concat(", ", FormatCamel(param.Name));
                factoryParamsArray[i] = FormatCamel(param.Name);
                paramName += string.Concat(", ", param.Name);
                paramNameArray[i] = param.Name;
            }
            if (factoryParams.Length > 1)
            {
                factoryParams = factoryParams.Substring(2);
                prms = prms.Substring(2);
                paramName = paramName.Substring(2);
            }
            %>

        /// <summary>
        /// Removes a <see cref="<%= Info.ItemType %>"/> item from the collection.
        /// </summary>
        <%
            for (int i = 0; i < crit.Properties.Count; i++)
            {
                %>
        /// <param name="<%= FormatCamel(crit.Properties[i].Name) %>">The <%= FormatProperty(crit.Properties[i].Name) %> of the item to be removed.</param>
        <%
            }
            if (useAuthz)
            {
                %>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        <%
            }
            %>
        public void Remove(<%= prms %>)
        {
            foreach (var <%= FormatCamel(Info.ItemType) %> in this)
            {
                if (<%
            for (int i = 0; i < crit.Properties.Count; i++)
            {
                %><%= (i == 0) ? "" : " && " %><%= FormatCamel(Info.ItemType) %>.<%= paramNameArray[i] %> == <%= factoryParamsArray[i] %><%
            }
                        %>)
                {
                    Remove(<%= FormatCamel(Info.ItemType) %>);
                    break;
                }
            }
        }
        <%
        }
    }

    if (Info.ObjectType == CslaObjectType.EditableRootCollection ||
        Info.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
        Info.ObjectType == CslaObjectType.EditableChildCollection ||
        Info.ObjectType == CslaObjectType.ReadOnlyCollection)
    {
        List<Property> propertyList = new List<Property>();
        foreach (ValueProperty prop in itemInfo.ValueProperties)
        {
            if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
            {
                propertyList.Add(prop);
            }
        }
        string prms = string.Empty;
        string factoryParams = string.Empty;
        string paramName = string.Empty;
        string[] factoryParamsArray = new string[propertyList.Count];
        string[] paramNameArray = new string[propertyList.Count];
        for (int i = 0; i < propertyList.Count; i++)
        {
            Property param = propertyList[i];
            prms += string.Concat(", ", GetDataTypeGeneric(param, param.PropertyType), " ", FormatCamel(param.Name));
            factoryParams += string.Concat(", ", FormatCamel(param.Name));
            factoryParamsArray[i] = FormatCamel(param.Name);
            paramName += string.Concat(", ", param.Name);
            paramNameArray[i] = param.Name;
        }
        if (factoryParams.Length > 1)
        {
            factoryParams = factoryParams.Substring(2);
            prms = prms.Substring(2);
            paramName = paramName.Substring(2);
        }
        bool removeFlag = false;
        if (itemInfo.ObjectType == CslaObjectType.EditableChild)
            removeFlag = itemInfo.RemoveItem;
        if (removeFlag)
        {
            %>

        /// <summary>
        /// Removes a <see cref="<%= Info.ItemType %>"/> item from the collection.
        /// </summary>
        <%
            for (int i = 0; i < propertyList.Count; i++)
            {
                %>
        /// <param name="<%= FormatCamel(propertyList[i].Name) %>">The <%= FormatProperty(propertyList[i].Name) %> of the item to be removed.</param>
        <%
            }
            if (useAuthz)
            {
                %>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        <%
            }
            %>
        public void Remove(<%= prms %>)
        {
            foreach (var <%= FormatCamel(Info.ItemType) %> in this)
            {
                if (<%
            for (int i = 0; i < propertyList.Count; i++)
            {
                %><%= (i == 0) ? "" : " && " %><%= FormatCamel(Info.ItemType) %>.<%= paramNameArray[i] %> == <%= factoryParamsArray[i] %><%
            }
                            %>)
                {
                    Remove(<%= FormatCamel(Info.ItemType) %>);
                    break;
                }
            }
        }
        <%
        }
        if (Info.ContainsItem)
        {
            %>

        /// <summary>
        /// Determines whether a <see cref="<%= Info.ItemType %>"/> item is in the collection.
        /// </summary>
        <%
            for (int i = 0; i < propertyList.Count; i++)
            {
                %>
        /// <param name="<%= FormatCamel(propertyList[i].Name) %>">The <%= FormatProperty(propertyList[i].Name) %> of the item to search for.</param>
        <%
            }
        %>
        /// <returns><c>true</c> if the <%= Info.ItemType %> is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(<%= prms %>)
        {
            foreach (var <%= FormatCamel(Info.ItemType) %> in this)
            {
                if (<%
            for (int i = 0; i < propertyList.Count; i++)
            {
                %><%= (i == 0) ? "" : " && " %><%= FormatCamel(Info.ItemType) %>.<%= paramNameArray[i] %> == <%= factoryParamsArray[i] %><%
            }
                            %>)
                {
                    return true;
                }
            }
            return false;
        }
        <%
            if (Info.ObjectType != CslaObjectType.ReadOnlyCollection && Info.ObjectType != CslaObjectType.DynamicEditableRootCollection)
            {
                %>

        /// <summary>
        /// Determines whether a <see cref="<%= Info.ItemType %>"/> item is in the collection's DeletedList.
        /// </summary>
        <%
                for (int i = 0; i < propertyList.Count; i++)
                {
                    %>
        /// <param name="<%= FormatCamel(propertyList[i].Name) %>">The <%= FormatProperty(propertyList[i].Name) %> of the item to search for.</param>
        <%
                }
                %>
        /// <returns><c>true</c> if the <%= Info.ItemType %> is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(<%= prms %>)
        {
            foreach (var <%= FormatCamel(Info.ItemType) %> in this.DeletedList)
            {
                if (<%
                for (int i = 0; i < propertyList.Count; i++)
                {
                    %><%= (i == 0) ? "" : " && " %><%= FormatCamel(Info.ItemType) %>.<%= paramNameArray[i] %> == <%= factoryParamsArray[i] %><%
                }
                            %>)
                {
                    return true;
                }
            }
            return false;
        }
        <%
            }
        }
    }

%>

        #endregion
<%
}
Response.Write(Environment.NewLine);
%>
