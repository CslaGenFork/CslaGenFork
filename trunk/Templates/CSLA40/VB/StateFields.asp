<%
bool stateFieldsForAllValueProperties = StateFieldsForAllValueProperties(Info);
bool stateFieldsForAllChildProperties = StateFieldsForAllChildProperties(Info);
bool useFieldForParentLoading = (((ancestorLoaderLevel > 2 && !ancestorIsCollection) || (ancestorLoaderLevel > 1 && ancestorIsCollection)) && Info.ParentProperties.Count > 0);
if (stateFieldsForAllValueProperties || stateFieldsForAllChildProperties || useFieldForParentLoading)
{
    %>

        #Region " State Fields "
<%
    // if the object has child properties, then add a new line
    if (stateFieldsForAllValueProperties)
    {
        Response.Write(Environment.NewLine);
    }

    // Value Properties
    foreach (ValueProperty prop in Info.AllValueProperties)
    {
        string statement = FieldDeclare(Info, prop);
        if (!string.IsNullOrEmpty(statement))
        {
            %>
        <%= statement %>
<%
        }
    }

    // if the object has child properties, then add a new line
    if (stateFieldsForAllChildProperties)
    {
        Response.Write(Environment.NewLine);
    }

    // Child Properties
    foreach (ChildProperty prop in Info.AllChildProperties)
    {
        if (prop.DeclarationMode == PropertyDeclaration.AutoProperty)
            continue;
        if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
            prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
            prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
        {
            Errors.Append("TypeName '" + prop.TypeName + "' can't be declared as '" + prop.DeclarationMode + "'." + Environment.NewLine);
        }
        if (prop.DeclarationMode == PropertyDeclaration.Unmanaged ||
            prop.DeclarationMode == PropertyDeclaration.ClassicProperty)
        {
            CslaObjectInfo _child = FindChildInfo(Info, prop.TypeName);
            if (_child == null)
            {
                Warnings.Append("TypeName '" + prop.TypeName + "' doesn't exist in this project." + Environment.NewLine);
            }
            if (!prop.Undoable)
            {
                %>
        <NotUndoable()>
        <%
            }
            %>
        Private <%= FormatFieldName(prop.Name) %> As <%= prop.TypeName %><%
        if (_child.IsNotReadOnlyObject() && _child.IsNotReadOnlyCollection())
        {
            %> = <%= prop.TypeName %>.New<%= prop.TypeName %>()<%
        } %>
        <%
            if (prop.LazyLoad)
            {
                %>
        Private <%= FormatFieldName(prop.Name + "Loaded") %> As Boolean = False<%= "\r\n" %><%
            }
        }
    }

    // parent loading field
    if (useFieldForParentLoading)
    {
        foreach (Property prop in Info.ParentProperties)
        {
            %>
        <NotUndoable()>
        < NonSerialized()>
        Friend <%= FormatCamel(GetFKColumn(Info, (isItem ? grandParentInfo : parentInfo), prop)) %> As <%= GetDataTypeGeneric(prop, prop.PropertyType) %> = <%= GetInitValue(prop.PropertyType) %>
        <%
        }
    }

    // if any code was generated, then add a new line
    if (stateFieldsForAllValueProperties || stateFieldsForAllChildProperties || useFieldForParentLoading)
    {
        Response.Write(Environment.NewLine);
    }
    %>
        #End Region
<%
}
%>