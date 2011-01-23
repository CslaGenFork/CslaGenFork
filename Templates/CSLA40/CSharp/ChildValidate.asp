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
    
    // is it non-root?
    if (IsNotRootType(Info))
    {
        if (childProperty.LoadingScheme != LoadingScheme.SelfLoad)
        {
            Warnings.Append(Info.ObjectName + " isn't a root object; "+
                Info.ObjectName + "." + childProperty.Name + " Loading Scheme should be \"SelfLoad\"." + Environment.NewLine);
        }
    }
    else
    {
        if (childProperty.DeclarationMode == PropertyDeclaration.Managed)
        {
            bool getOptionsDataPortal2 = false;
            foreach (Criteria crit in Info.CriteriaObjects)
            {
                getOptionsDataPortal2 = getOptionsDataPortal2 | crit.GetOptions.DataPortal;
            }
            if (!getOptionsDataPortal2)
            {
                Warnings.Append(Info.ObjectName + "." + childProperty.Name + " Declaration Mode is \"Managed\"; there must be a criteria with GetOptions.DataPortal set to True or child " + childProperty.Name + " won't load." + Environment.NewLine);
            }
        }
    }

    if (childProperty.LoadingScheme == LoadingScheme.None)
    {
        Errors.Append(Info.ObjectName + "." + childProperty.Name + " Loading Scheme is \"None\"; this isn't supported for CSLA40 targets." + Environment.NewLine);
    }
    else if (childProperty.LoadingScheme == LoadingScheme.ParentLoad)
    {
        if (childProperty.LazyLoad)
        {
            Warnings.Append(Info.ObjectName + "." + childProperty.Name + " Loading Scheme is \"Parent Load\"; \"Lazy Load\" should be set to False." + Environment.NewLine);
        }
    }
    
    if (childProperty.LoadParameters.Count == 0)
    {
        Warnings.Append(Info.ObjectName + "." + childProperty.Name + " \"Load Parameters\" cannot be empty." + Environment.NewLine);
    }
}
%>