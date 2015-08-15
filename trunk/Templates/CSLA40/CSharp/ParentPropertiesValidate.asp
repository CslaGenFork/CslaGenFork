<%
// Check DeepLoad injected Parent properties don't match object's own properties

// Only check objects with a ParentType
if (!Info.ParentType.Equals(String.Empty))
{
    bool usesDTO = CurrentUnit.GenerationParams.GenerateDTO;
    bool isItem = false;
    bool isParentRootCollection = false;
    bool useIsLoadedProperty = false;
    List<string> propNames = new List<string>();
    bool ancestorIsCollection = false;
    int ancestorLoaderLevel = AncestorLoaderLevel(Info, out ancestorIsCollection);
    bool useFieldForParentLoading = (((ancestorLoaderLevel > 2 && !ancestorIsCollection) || (ancestorLoaderLevel > 1 && ancestorIsCollection)) && Info.ParentProperties.Count > 0);
    if (useFieldForParentLoading)
    {
        CslaObjectInfo grandParentInfo = null;
        if (parentInfo != null)
        {
            isItem = IsCollectionType(parentInfo.ObjectType);
            if (!isItem)
                useIsLoadedProperty = CurrentUnit.GenerationParams.ReportObjectNotFound == ReportObjectNotFound.IsLoadedProperty;
            grandParentInfo = Info.Parent.CslaObjects.Find(parentInfo.ParentType);
            isParentRootCollection = (parentInfo.ObjectType == CslaObjectType.EditableRootCollection) ||
                (parentInfo.ObjectType == CslaObjectType.ReadOnlyCollection && parentInfo.ParentType == String.Empty);
        }
        foreach(Property prop in Info.ParentProperties)
        {
            string parentPropertyName = FormatPascal(prop.Name);
            foreach (ValueProperty valProp in Info.ValueProperties)
            {
                if (valProp.Name == FormatCamel(parentPropertyName) &&
                    valProp.Access == PropertyAccess.IsInternal &&
                    (valProp.DeclarationMode == PropertyDeclaration.Unmanaged ||
                    valProp.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                    valProp.DeclarationMode == PropertyDeclaration.ClassicProperty ||
                    valProp.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                    valProp.DeclarationMode == PropertyDeclaration.NoProperty))
                {
                    propNames.Add(valProp.Name);
                    break;
                }
                if (valProp.Name == "Parent_" + parentPropertyName &&
                    CurrentUnit.GenerationParams.TargetIsCsla4DAL &&
                    usesDTO)
                {
                    propNames.Add(valProp.Name);
                    break;
                }
            }
        }
    }

    foreach(string prop in propNames)
    {
        Warnings.AppendFormat("{0}.{1} name matches a Parent Property and should be renamed.\r\n", Info.ObjectName, prop);
    }
}
%>