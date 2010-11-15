<%
foreach (ChildProperty childProperty in Info.AllChildProperties)
{
    if (childProperty.DeclarationMode != PropertyDeclaration.ClassicProperty &&
        childProperty.DeclarationMode != PropertyDeclaration.Managed)
    {
        CslaObjectInfo childInfo = FindChildInfo(Info, childProperty.TypeName);
        if (IsCollectionType(childInfo.ObjectType))
        {
            Errors.Append(childProperty.Name + " Declaration Mode must be \"ClassicProperty\" or \"Managed\"." + Environment.NewLine);
        }
    }

    if (childProperty.LoadingScheme == LoadingScheme.None)
    {
        Errors.Append(childProperty.Name + " Loading Scheme is \"None\"; This isn't supported for CSLA40 targets." + Environment.NewLine);
    }
    else if (childProperty.LoadingScheme == LoadingScheme.ParentLoad &&
             childProperty.LazyLoad)
    {
        Warnings.Append(childProperty.Name + " Loading Scheme is \"Parent Load\"; \"Lazy Load\" should be set to False." + Environment.NewLine);
    }
}
%>