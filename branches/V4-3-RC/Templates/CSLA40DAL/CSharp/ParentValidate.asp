<%
// Check the object has a ParentType
if (Info.ParentType.Equals(String.Empty))
{
    // Check it's ok to have no Parent
    if (!RelationRulesEngine.IsNoParentAllowed(Info.ObjectType))
    {
        Errors.Append(Info.ObjectName + ": " + RelationRulesEngine.BrokenRuleMsg + Environment.NewLine);
        return;
    }
    if (IsObjectType(Info.ObjectType))
    {
        foreach (Criteria crit in Info.CriteriaObjects)
        {
            if (crit.IsGetter && crit.Properties.Count == 0)
            {
                Warnings.Append(Info.ObjectName + ": is a non-collection root object and Fetch criteria needs at least one Criteria Property." + Environment.NewLine);
            }
        }
    }
}
else
{
    CslaObjectInfo validateParentInfo = FindChildInfo(Info, Info.ParentType);
    CslaObjectInfo validateInfo = Info;
    // Check the ParentType exists
    if (validateParentInfo == null)
    {
        Errors.Append("ParentType " + Info.ParentType + " doesn't exist." + Environment.NewLine);
        return;
    }
    else
    {
        // Check the ItemType is specified in the parent
        if (validateParentInfo.ItemType.Equals(String.Empty))
        {
            // Collections must have an ItemType
            if (validateParentInfo.ObjectType == CslaObjectType.ReadOnlyCollection ||
                validateParentInfo.ObjectType == CslaObjectType.EditableChildCollection ||
                validateParentInfo.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
                validateParentInfo.ObjectType == CslaObjectType.EditableRootCollection)
            {
                Errors.Append("ItemType property is missing on parent " + validateParentInfo.ObjectName + "." + Environment.NewLine);
                return;
            }
            if (validateParentInfo.ObjectType == CslaObjectType.ReadOnlyObject ||
                validateParentInfo.ObjectType == CslaObjectType.EditableChild ||
                validateParentInfo.ObjectType == CslaObjectType.EditableRoot)
            {
                // The parent of Child collections must know they exist (i.e. the GRAND parent must know the parent exists)
                if (Info.ObjectType == CslaObjectType.ReadOnlyCollection ||
                    Info.ObjectType == CslaObjectType.EditableChildCollection)
                {
                    bool found = false;
                    foreach (ChildProperty child in validateParentInfo.GetCollectionChildProperties())
                    {
                        if (child.TypeName == Info.ObjectName)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Errors.Append("ParentType " + Info.ParentType + " has no child collection " + Info.ObjectName + Environment.NewLine);
                        return;
                    }
                }

                // The parent of Child objects must know they exist
                if (Info.ObjectType == CslaObjectType.ReadOnlyObject ||
                    Info.ObjectType == CslaObjectType.EditableChild)
                {
                    bool found = false;
                    foreach (ChildProperty child in validateParentInfo.GetNonCollectionChildProperties())
                    {
                        if (child.TypeName == Info.ObjectName)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Errors.Append("ParentType " + Info.ParentType + " has no child " + Info.ObjectName + Environment.NewLine);
                        return;
                    }
                }
            }
        }
        else
        {
            // Check the ItemType of the collection's ItemType is the collection itself
            if (validateParentInfo.ItemType != Info.ObjectName)
            {
                Errors.Append("The item name (ItemType) of " + validateParentInfo.ObjectName + " doesn't match: is '" + validateParentInfo.ItemType + "' but should be '" + Info.ObjectName + "'." + Environment.NewLine);
                return;
            }
            // Check the ParentType is valid for this kind of collection
            if (!RelationRulesEngine.IsParentAllowed(validateParentInfo.ObjectType, Info.ObjectType))
            {
                Errors.Append("Parent " + validateParentInfo.ObjectName + ": " + RelationRulesEngine.BrokenRuleMsg + Environment.NewLine);
                return;
            }
        }

        // if there should be a GRAND parent, do further validations
        if ((validateParentInfo.ObjectType == CslaObjectType.ReadOnlyCollection &&
            validateParentInfo.ParentType != string.Empty) ||
            validateParentInfo.ObjectType == CslaObjectType.EditableChildCollection)
        {
            // Find the GRAND parent
            if (validateParentInfo.ObjectType == CslaObjectType.ReadOnlyCollection ||
                validateParentInfo.ObjectType == CslaObjectType.EditableChildCollection)
            {
                // Check the object has a GRAND ParentType
                if (validateParentInfo.ParentType.Equals(String.Empty))
                {
                    // Check it's ok to have no GRAND Parent
                    if (!RelationRulesEngine.IsNoParentAllowed(validateParentInfo.ObjectType))
                    {
                        Errors.Append(validateParentInfo.ObjectName + ": " + RelationRulesEngine.BrokenRuleMsg + Environment.NewLine);
                        return;
                    }
                }
                else
                {
                    validateInfo = validateParentInfo;
                    validateParentInfo = FindChildInfo(validateParentInfo, validateParentInfo.ParentType);
                    // Check the GRAND ParentType exists
                    if (validateParentInfo == null)
                    {
                        Errors.Append("Grand ParentType " + validateParentInfo.ParentType + " doesn't exist." + Environment.NewLine);
                        return;
                    }
                }
            }

            // The parent of Child collections must know they exist (i.e. the GRAND parent must know the parent exists)
            if (validateInfo.ObjectType == CslaObjectType.ReadOnlyCollection ||
                validateInfo.ObjectType == CslaObjectType.EditableChildCollection)
            {
                bool found = false;
                foreach (ChildProperty child in validateParentInfo.GetCollectionChildProperties())
                {
                    if (child.TypeName == validateInfo.ObjectName)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Errors.Append("Grand ParentType " + validateParentInfo.ParentType + " has no child collection " + validateInfo.ObjectName + Environment.NewLine);
                    return;
                }
            }

            // The parent of Child objects must know they exist
            if (validateInfo.ObjectType == CslaObjectType.ReadOnlyObject ||
                validateInfo.ObjectType == CslaObjectType.EditableChild)
            {
                bool found = false;
                foreach (ChildProperty child in validateParentInfo.GetNonCollectionChildProperties())
                {
                    if (child.TypeName == validateInfo.ObjectName)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Errors.Append("ParentType " + validateParentInfo.ParentType + " has no child " + validateInfo.ObjectName + Environment.NewLine);
                    return;
                }
            }
        }
    }
}
%>
