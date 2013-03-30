<%
foreach (ChildProperty childProperty in Info.AllChildProperties)
{
    if (childProperty.DeclarationMode != PropertyDeclaration.ClassicProperty &&
        childProperty.DeclarationMode != PropertyDeclaration.Managed)
    {
        CslaObjectInfo childInfo = FindChildInfo(Info, childProperty.TypeName);
        if (IsCollectionType(childInfo.ObjectType))
        {
            Errors.Append(Info.ObjectName + "." + childProperty.Name + " Declaration Mode must be \"ClassicProperty\" or \"Managed\"." + Environment.NewLine);
        }
    }
    else if(childProperty.DeclarationMode == PropertyDeclaration.Managed)
    {
        bool createOptionsDataPortal2 = false;
        foreach (Criteria crit in Info.CriteriaObjects)
        {
            createOptionsDataPortal2 = createOptionsDataPortal2 | crit.CreateOptions.DataPortal;
        }
        if (!createOptionsDataPortal2)
        {
            Warnings.Append(Info.ObjectName + "." + childProperty.Name + " Declaration Mode is \"Managed\"; there must be a criteria with CreateOptions.DataPortal set to True or child " + childProperty.Name + " won't load." + Environment.NewLine);
        }
    }

    if (childProperty.LoadingScheme == LoadingScheme.None)
    {
        Errors.Append(Info.ObjectName + "." + childProperty.Name + " Loading Scheme is \"None\"; this isn't supported for CSLA40 targets." + Environment.NewLine);
    }
    else if (childProperty.LoadingScheme == LoadingScheme.ParentLoad &&
             childProperty.LazyLoad)
    {
        Warnings.Append(Info.ObjectName + "." + childProperty.Name + " Loading Scheme is \"Parent Load\"; \"Lazy Load\" should be set to False." + Environment.NewLine);
    }

    if (childProperty.LoadingScheme == LoadingScheme.ParentLoad)
    {
        if (Info.ParentType != string.Empty)
        {
            Warnings.Append(Info.ObjectName + " isn't root and has children; "+
                Info.ObjectName + "." + childProperty.Name + " Loading Scheme should be \"Self Load\"." + Environment.NewLine);
        }
    }
}
%>