<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

        /// <summary>
        /// Asynchronously adds a new <see cref="<%= Info.ItemType %>"/> object to the <%= Info.ObjectName %> collection.
        /// </summary>
<%
        string prmsAsync = string.Empty;
        string factoryParamsAsync = string.Empty;
        foreach (Property param in c.Properties)
        {
            prmsAsync += string.Concat(", ", GetDataTypeGeneric(param, param.PropertyType), " ", FormatCamel(param.Name));
            factoryParamsAsync += string.Concat(", ", FormatCamel(param.Name));
        }
        if (factoryParamsAsync.Length > 1)
        {
            factoryParamsAsync = factoryParamsAsync.Substring(2);
            prmsAsync = prmsAsync.Substring(2);
        }
        for (int i = 0; i < c.Properties.Count; i++)
        {
            %>
        /// <param name="<%= FormatCamel(c.Properties[i].Name) %>">The <%= FormatProperty(c.Properties[i].Name) %> of the object to be added.</param>
<%
        }
        if (useAuthz)
        {
            %>
        /// <exception cref="System.Security.SecurityException">if the user isn't authorized to add items from the collection.</exception>
<%
        }
        %>
        public void BeginAdd(<%=prmsAsync%>)
        {
        <%
        string newMethodNameAsync = "New" + Info.ItemType;
        if (itemInfo.ObjectType == CslaObjectType.EditableSwitchable)
        {
            newMethodNameAsync += "Child";
        }
        %>
            <%= Info.ItemType %> <%=FormatCamel(Info.ItemType)%> = null;
            <%= Info.ItemType %>.<%=newMethodNameAsync%><%=c.CreateOptions.FactorySuffix%>(<%=factoryParamsAsync%><%= factoryParamsAsync.Length > 1 ? ", " : "" %>(o, e) =>
                {
                    if (e.Error != null)
                        throw e.Error;
                    else
                        <%=FormatCamel(Info.ItemType)%> = e.Object;
                });
            Add(<%=FormatCamel(Info.ItemType)%>);
        }
        <%
}
%>
