<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    %>

        /// <summary>
        /// Adds a new <see cref="<%= Info.ItemType %>"/> item to the collection.
        /// </summary>
        <%
    string prms = string.Empty;
    string factoryParams = string.Empty;
    foreach (Property param in crit.Properties)
    {
        prms += string.Concat(", ", GetDataTypeGeneric(param, param.PropertyType), " ", FormatCamel(param.Name));
        factoryParams += string.Concat(", ", FormatCamel(param.Name));
    }
    if (factoryParams.Length > 1)
    {
        factoryParams = factoryParams.Substring(2);
        prms = prms.Substring(2);
    }
    for (int i = 0; i < crit.Properties.Count; i++)
    {
        %>
        /// <param name="<%= FormatCamel(crit.Properties[i].Name) %>">The <%= FormatProperty(crit.Properties[i].Name) %> of the object to be added.</param>
<%
    }
    %>
        /// <returns>The new <%= Info.ItemType %> item added to the collection.</returns>
        public <%= Info.ItemType %> Add(<%= prms %>)
        {
        <%
    string newMethodName = "New" + Info.ItemType;
    if (itemInfo.IsEditableSwitchable())
    {
        newMethodName += "Child";
    }
    if (UseChildFactoryHelper)
    {
        %>
            var item = <%= Info.ItemType %>.<%= newMethodName %><%= crit.CreateOptions.FactorySuffix %>(<%= factoryParams %>);
            <%
    }
    else
    {
        %>
            var item = DataPortal.Create<%= crit.CreateOptions.RunLocal ? "Child" : "" %><<%= Info.ItemType %>>(<%= factoryParams %>);
            <%
    }
    %>
            Add(item);
            return item;
        }
        <%
}
%>
