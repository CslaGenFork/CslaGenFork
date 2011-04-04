<%
bool useAuthz;
CslaObjectInfo itemInfo = FindChildInfo(Info, Info.ItemType);
useAuthz = !IsReadOnlyType(itemInfo.ObjectType) &&
    ((itemInfo.DeleteRoles.Trim() != String.Empty) ||
    (itemInfo.NewRoles.Trim() != String.Empty));

bool needsBusiness = false; 
foreach (Criteria c in itemInfo.CriteriaObjects)
{
    if (c.CreateOptions.AddRemove || (c.DeleteOptions.AddRemove && c.Properties.Count > 0))
    {
        needsBusiness = true;
        break;
    }
}

if (useAuthz || needsBusiness)
{
    %>

        #region Business Methods
        <%
if (useAuthz)
{
    if (itemInfo.NewRoles.Trim() != String.Empty)
    {
        %>

        /// <summary>
        /// Add new <see cref="<%= itemInfo.ObjectName %>"/> object to the <%= Info.ObjectName %> collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to add items to the collection.</exception>
        public new void Add(<%= itemInfo.ObjectName %> item)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to create a <%= itemInfo.ObjectName %>.");

            base.Add(item);
        }

        <%
    }
    if (itemInfo.DeleteRoles.Trim() != String.Empty)
    {
        %>
        /// <summary>
        /// Remove <see cref="<%= itemInfo.ObjectName %>"/> object from the <%= Info.ObjectName %> collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns><c>true</c> if the item was removed from the collection, otherwise <c>false</c>.</returns>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        public new bool Remove(<%= itemInfo.ObjectName %> item)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a <%= itemInfo.ObjectName %>.");

            return base.Remove(item);
        }<%
    }
}

if (useAuthz && needsBusiness)
    Response.Write("\r\n");

foreach (Criteria c in itemInfo.CriteriaObjects)
{
    if (c.CreateOptions.AddRemove)
    {
        %>
        /// <summary>
        /// Add new <see cref="<%= Info.ItemType %>"/> object to the <%=Info.ObjectName%> collection.
        /// </summary>
        <%
        string prms = string.Empty;
        string factoryParams = string.Empty;
        foreach (Property param in c.Properties)
        {
            prms += string.Concat(", ", GetDataTypeGeneric(param, param.PropertyType), " ", FormatCamel(param.Name));
            factoryParams += string.Concat(", ", FormatCamel(param.Name));
        }
        if (factoryParams.Length > 1)
        {
            factoryParams = factoryParams.Substring(2);
            prms = prms.Substring(2);
        }
        for (int i = 0; i < c.Properties.Count; i++)
        {
            %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the object to be added.</param>
        <%
        }
        %>
        /// <returns>The new <%= Info.ItemType %> object added to the collection.</returns>
        <%
        if (useAuthz)
        {
            %>/// <exception cref="System.Security.SecurityException">if the user isn't authorized to add items from the collection.</exception>
        <%
        }
        %>public <%= Info.ItemType %> Add(<%=prms%>)
        {
        <%
        string newMethodName = "New" + Info.ItemType;
        if (itemInfo.ObjectType == CslaObjectType.EditableSwitchable)
        {
            newMethodName += "Child";
        }
        %>
            var <%=FormatCamel(Info.ItemType)%> = <%= Info.ItemType %>.<%=newMethodName%><%=c.CreateOptions.FactorySuffix%>(<%=factoryParams%>);
            Add(<%=FormatCamel(Info.ItemType)%>);
            return <%=FormatCamel(Info.ItemType)%>;
        }
        <%
    }

    if (c.DeleteOptions.AddRemove && c.Properties.Count > 0)
    {
        %>

        /// <summary>
        /// Remove <see cref="<%= Info.ItemType %>"/> object from the <%=Info.ObjectName%> collection.
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
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the object to be removed.</param>
        <%
        }
        if (useAuthz)
        {
            %>/// <exception cref="System.Security.SecurityException">if the user isn't authorized to add items from the collection.</exception>
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
%>