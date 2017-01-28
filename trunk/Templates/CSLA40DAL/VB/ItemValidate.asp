<%
// Check the collection has an ItemType
if (Info.ItemType.Equals(String.Empty))
{
    Errors.Append("Collection ItemType property can't be empty." + Environment.NewLine);
}
else
{
    CslaObjectInfo validateChildInfo = FindChildInfo(Info, Info.ItemType);
    // Check the ItemType exists
    if (validateChildInfo == null)
    {
        Errors.Append("ItemType " + Info.ItemType + " doesn't exist." + Environment.NewLine);
    }
    else
    {
        // Check the ParentType is specified in the item
        if (validateChildInfo.ParentType.Equals(String.Empty))
        {
            Errors.Append("ParentType property is missing on item " + validateChildInfo.ObjectName + "." + Environment.NewLine);
        }
        else
        {
            // Check the ParentType of the item is the collection itself
            if (validateChildInfo.ParentType != Info.ObjectName)
            {
                Errors.Append("The parent name (ParentType) of " + validateChildInfo.ObjectName + " doesn't match: is '" + validateChildInfo.ParentType + "' but should be '" + Info.ObjectName + "'." + Environment.NewLine);
            }
        }
        // Check the ItemType is valid for this kind of collection
        if (!RelationRulesEngine.IsChildAllowed(Info.ObjectType, validateChildInfo.ObjectType))
        {
            Errors.Append("Item " + validateChildInfo.ObjectName + ": " + RelationRulesEngine.BrokenRuleMsg + Environment.NewLine);
        }

        // collection object use "Contains" but is missing item PK property
        if (Info.IsDynamicEditableRootCollection())
        {
            bool hasCritProperty = false;
            string deleterName = string.Empty;
            bool hasAddRemove = false;
            foreach (Criteria crit in itemInfo.CriteriaObjects)
            {
                if (crit.IsDeleter)
                {
                    hasAddRemove = crit.DeleteOptions.AddRemove;
                    deleterName = crit.Name;
                    if (crit.Properties.Count > 0)
                    {
                        hasCritProperty = true;
                        break;
                    }
                }
            }
            if (!hasCritProperty && Info.ContainsItem)
            {
                Warnings.Append(Info.ObjectName + " collection uses \"Contains\"; item " + itemInfo.ObjectName + ", criteria " + deleterName + " should have a Criteria Property." + Environment.NewLine);
            }
            if (!hasCritProperty && hasAddRemove)
            {
                Warnings.Append(Info.ObjectName + ", item " + itemInfo.ObjectName + ", criteria " + deleterName + " uses \"AddRemove\": should have a Criteria Property." + Environment.NewLine);
            }
        }
        else if (Info.IsEditableRootCollection() ||
            Info.IsEditableChildCollection() ||
            Info.IsReadOnlyCollection())
        {
            if (Info.ContainsItem || (Info.IsEditableChildCollection() && itemInfo.RemoveItem))
            {
                bool hasPkProperty = false;
                foreach (ValueProperty prop in itemInfo.ValueProperties)
                {
                    if (!prop.IsDatabaseBound)
                        continue;

                    if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
                    {
                        hasPkProperty = true;
                        break;
                    }
                }
                if (!hasPkProperty && Info.ContainsItem)
                {
                    Warnings.Append(Info.ObjectName + " collection uses \"Contains\"; item " + itemInfo.ObjectName + " should have a Primary Key property." + Environment.NewLine);
                }
                if (!hasPkProperty && Info.IsEditableChildCollection() && itemInfo.RemoveItem)
                {
                    Warnings.Append(Info.ObjectName + ", item " + itemInfo.ObjectName + " uses \"Use Remove Method\"; item should have a Primary Key property." + Environment.NewLine);
                }
            }
        }
    }
}
%>