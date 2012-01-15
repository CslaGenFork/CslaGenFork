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

bool needsBusiness = itemInfo.RemoveItem &&
    (Info.ObjectType == CslaObjectType.EditableRootCollection ||
    Info.ObjectType == CslaObjectType.EditableChildCollection);
if (!needsBusiness)
{
    foreach (Criteria c in itemInfo.CriteriaObjects)
    {
        if (c.CreateOptions.AddRemove || (c.DeleteOptions.AddRemove && c.Properties.Count > 0))
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

    //if ((useAuthz && needsBusiness) || (UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous))
        //Response.Write(Environment.NewLine);

    bool removeItemUnhandled = itemInfo.RemoveItem;
    foreach (Criteria c in itemInfo.CriteriaObjects)
    {
        if (c.CreateOptions.AddRemove)
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

        if (Info.ObjectType == CslaObjectType.EditableRootCollection ||
            Info.ObjectType == CslaObjectType.EditableChildCollection)
        {
            if (removeItemUnhandled)
            {
                removeItemUnhandled = false;
                List<Property> propertyList = new List<Property>();

                foreach (ValueProperty prop in itemInfo.ValueProperties)
                {
                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                    {
                        propertyList.Add(prop);
                    }
                }
                %>

        /// <summary>
        /// Removes a <see cref="<%= Info.ItemType %>"/> item from the collection.
        /// </summary>
        <%
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
            for (int i = 0; i < propertyList.Count; i++)
            {
                %>
        /// <param name="<%= FormatCamel(propertyList[i].Name) %>">The <%= FormatProperty(propertyList[i].Name) %> of the item to be removed.</param>
        <%
            }
            if (useAuthz)
            {
                %>/// <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        <%
            }
            %>public void Remove(<%= prms %>)
        {
            foreach (<%= Info.ItemType %> <%= FormatCamel(Info.ItemType) %> in this)
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
        }
        else if (c.DeleteOptions.AddRemove && c.Properties.Count > 0)
        {
            %>

        /// <summary>
        /// Removes a <see cref="<%= Info.ItemType %>"/> item from the collection.
        /// </summary>
        <%
            string prms = string.Empty;
            string factoryParams = string.Empty;
            string paramName = string.Empty;
            string[] factoryParamsArray = new string[c.Properties.Count];
            string[] paramNameArray = new string[c.Properties.Count];
            for (int i = 0; i < c.Properties.Count; i++)
            {
                Property param = c.Properties[i];
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
            for (int i = 0; i < c.Properties.Count; i++)
            {
                %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the item to be removed.</param>
        <%
            }
            if (useAuthz)
            {
                %>/// <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        <%
            }
            %>public void Remove(<%= prms %>)
        {
            foreach (<%= Info.ItemType %> <%= FormatCamel(Info.ItemType) %> in this)
            {
                if (<%
            for (int i = 0; i < c.Properties.Count; i++)
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
%>

        #endregion
<%
}
Response.Write(Environment.NewLine);
%>
