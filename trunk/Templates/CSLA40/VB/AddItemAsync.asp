<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

        ''' <summary>
        ''' Asynchronously adds a new <see cref="<%= Info.ItemType %>"/> item to the collection.
        ''' </summary>
<%
        string prmsAsync = string.Empty;
        string factoryParamsAsync = string.Empty;
        foreach (Property param in crit.Properties)
        {
            prmsAsync += string.Concat(", ", FormatCamel(param.Name), "As ",  GetDataTypeGeneric(param, param.PropertyType));
            factoryParamsAsync += string.Concat(", ", FormatCamel(param.Name));
        }
        if (factoryParamsAsync.Length > 1)
        {
            factoryParamsAsync = factoryParamsAsync.Substring(2);
            prmsAsync = prmsAsync.Substring(2);
        }
        for (int i = 0; i < crit.Properties.Count; i++)
        {
            %>
        ''' <param name="<%= FormatCamel(crit.Properties[i].Name) %>">The <%= FormatProperty(crit.Properties[i].Name) %> of the object to be added.</param>
<%
        }
        %>
        Public Sub BeginAdd(<%= prmsAsync %>)
        <%
        string newMethodNameAsync = "New" + Info.ItemType;
        if (itemInfo.ObjectType == CslaObjectType.EditableSwitchable)
        {
            newMethodNameAsync += "Child";
        }
        %>
            Dim <%= FormatCamel(Info.ItemType) %> As <%= Info.ItemType %> = Nothing
            <%
        if (UseChildFactoryHelper)
        {
            %>
            <%= Info.ItemType %>.<%= newMethodNameAsync %><%= crit.CreateOptions.FactorySuffix %>(<%= factoryParamsAsync %><%= factoryParamsAsync.Length > 1 ? ", " : "" %>Function(o, e)
            <%
        }
        else
        {
            %>
            DataPortal.BeginCreate(Of <%= Info.ItemType %>)(<%= factoryParamsAsync %><%= factoryParamsAsync.Length > 1 ? ", " : "" %>Function(o, e)
            <%
        }
        %>
                    If e.Error IsNot Nothing Then
                        Throw e.Error
                    Else
                        <%= FormatCamel(Info.ItemType) %> = e.Object
                    End If
                End Function)
            Add(<%= FormatCamel(Info.ItemType) %>)
        End Sub
        <%
}
%>
