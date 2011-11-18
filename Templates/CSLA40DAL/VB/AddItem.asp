<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    %>

        /// <summary>
        /// Adds a new <see cref="<%= Info.ItemType %>"/> object to the <%= Info.ObjectName %> collection.
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
            %>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to add items from the collection.</exception>
<%
        }
        %>
        public <%= Info.ItemType %> Add(<%= prms %>)
        {
        <%
        string newMethodName = "New" + Info.ItemType;
        if (itemInfo.ObjectType == CslaObjectType.EditableSwitchable)
        {
            newMethodName += "Child";
        }
        %>
            var <%= FormatCamel(Info.ItemType) %> = <%= Info.ItemType %>.<%= newMethodName %><%= c.CreateOptions.FactorySuffix %>(<%= factoryParams %>);
            Add(<%= FormatCamel(Info.ItemType) %>);
            return <%= FormatCamel(Info.ItemType) %>;
        }
        <%
}
%>
