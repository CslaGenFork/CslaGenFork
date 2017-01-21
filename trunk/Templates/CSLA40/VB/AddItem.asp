<%
if (CurrentUnit.GenerationParams.GenerateSynchronous)
{
    %>

        ''' <summary>
        ''' Adds a new <see cref="<%= Info.ItemType %>"/> item to the collection.
        ''' </summary>
        <%
    string prms = string.Empty;
    string factoryParams = string.Empty;
    foreach (Property param in crit.Properties)
    {
        prms += string.Concat(", ", FormatCamel(param.Name), " As ",  GetDataTypeGeneric(param, param.PropertyType));
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
        ''' <param name="<%= FormatCamel(crit.Properties[i].Name) %>">The <%= FormatProperty(crit.Properties[i].Name) %> of the object to be added.</param>
<%
        }
        %>
        ''' <returns>The new <%= Info.ItemType %> item added to the collection.</returns>
        Public Overloads Function Add(<%= prms %>) As <%= Info.ItemType %>
        <%
    string newMethodName = "New" + Info.ItemType;
    if (itemInfo.IsEditableSwitchable())
    {
        newMethodName += "Child";
    }
    if (UseChildFactoryHelper)
    {
        %>
            Dim item = <%= Info.ItemType %>.<%= newMethodName %><%= crit.CreateOptions.FactorySuffix %>(<%= factoryParams %>)
            <%
    }
    else
    {
        %>
            Dim item = DataPortal.Create<%= crit.CreateOptions.RunLocal ? "Child" : "" %>(Of <%= Info.ItemType %>)(<%= factoryParams %>)
            <%
    }
    %>
            Add(item)
            Return item
        End Function
        <%
}
%>
