<%
foreach (ChildProperty childProperty in Info.AllChildProperties)
{
    bool isItem = false;
    bool isParentRootCollection = false;
    bool useIsLoadedProperty = false;
    if (parentInfo != null)
    {
        isItem = TypeHelper.IsCollectionType(parentInfo.ObjectType);
        if (!isItem)
            useIsLoadedProperty = CurrentUnit.GenerationParams.ReportObjectNotFound == ReportObjectNotFound.IsLoadedProperty;
        isParentRootCollection = (parentInfo.ObjectType == CslaObjectType.EditableRootCollection) ||
            (parentInfo.ObjectType == CslaObjectType.ReadOnlyCollection && parentInfo.ParentType == String.Empty);
    }

    if (childProperty.DeclarationMode == PropertyDeclaration.AutoProperty)
    {
        if (childProperty.LoadingScheme == LoadingScheme.SelfLoad &&
            childProperty.LazyLoad)
        {
            CslaObjectInfo childInfo = FindChildInfo(Info, childProperty.TypeName);
            if (TypeHelper.IsCollectionType(childInfo.ObjectType))
            {
                Errors.Append(Info.ObjectName + " child property " + childProperty.Name + " is LazyLoad; Declaration Mode must be \"ClassicProperty\" or \"Managed\"." + Environment.NewLine);
            }
        }
    }

    if (childProperty.DeclarationMode != PropertyDeclaration.ClassicProperty &&
        childProperty.DeclarationMode != PropertyDeclaration.AutoProperty &&
        childProperty.DeclarationMode != PropertyDeclaration.Managed)
    {
        CslaObjectInfo childInfo = FindChildInfo(Info, childProperty.TypeName);
        if (TypeHelper.IsCollectionType(childInfo.ObjectType))
        {
            Errors.Append(Info.ObjectName + " child property " + childProperty.Name + " Declaration Mode must be \"ClassicProperty\", \"AutoProperty\" or \"Managed\"." + Environment.NewLine);
        }
    }

    // is it non-root?
    if (TypeHelper.IsNotRootType(Info))
    {
        /*if (childProperty.LoadingScheme != LoadingScheme.SelfLoad)
        {
            Warnings.Append(Info.ObjectName + " isn't a root object; "+
                Info.ObjectName + " child property " + childProperty.Name + " Loading Scheme should be \"SelfLoad\"." + Environment.NewLine);
        }*/
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
                Warnings.Append(Info.ObjectName + " child property " + childProperty.Name + " Declaration Mode is \"Managed\"; there must be a criteria with GetOptions.DataPortal set to True or child " + childProperty.Name + " won't load." + Environment.NewLine);
            }
        }
    }

    if (childProperty.LoadingScheme == LoadingScheme.None)
    {
        Errors.Append(Info.ObjectName + " child property " + childProperty.Name + " Loading Scheme is \"None\"; this isn't supported for CSLA40 targets." + Environment.NewLine);
    }
    else if (childProperty.LoadingScheme == LoadingScheme.ParentLoad)
    {
        if (childProperty.LazyLoad)
        {
            Warnings.Append(Info.ObjectName + " child property " + childProperty.Name + " Loading Scheme is \"Parent Load\"; \"Lazy Load\" should be set to False." + Environment.NewLine);
        }
    }
    else
    {
        //if (isParentRootCollection)
        if (isItem)
        {
            if (childProperty.ParentLoadProperties.Count == 0)
            {
                Warnings.Append(Info.ObjectName + " child property " + childProperty.Name + " \"Parent Load Properties\" cannot be empty." + Environment.NewLine);
            }
        }
        else
        {
            if (childProperty.LoadParameters.Count == 0)
            {
                Warnings.Append(Info.ObjectName + " child property " + childProperty.Name + " \"Parent Load Criteria Parameters\" cannot be empty." + Environment.NewLine);
            }
        }
    }
}
%>