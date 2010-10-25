<%
CslaObjectInfo itemInfo = FindChildInfo(Info, Info.ItemType);
if (!IsReadOnlyType(itemInfo.ObjectType) &&
    ((itemInfo.DeleteRoles.Trim() != String.Empty) ||
    (itemInfo.NewRoles.Trim() != String.Empty)))
{
    %>

        #region Collection Add and Remove

        <%
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
            if (!CanGetObject())
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
        }

        <%
    }
    %>
        #endregion
<%
}
%>

        #region Business Properties and Methods
<%
foreach (Criteria c in itemInfo.CriteriaObjects)
{
    if (c.CreateOptions.Factory)
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
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to add items from the collection.</exception>
        public <%= Info.ItemType %> Add(<%=prms%>)
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
}
%>

        #endregion
