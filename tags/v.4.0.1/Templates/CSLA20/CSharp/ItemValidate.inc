<%
// Check the collection has an ItemType
if (Info.ItemType.Equals(String.Empty)) {
    Errors.Append("Collection ItemType property can't be empty." + Environment.NewLine);
} else {
    CslaObjectInfo validateChildInfo = FindChildInfo(Info, Info.ItemType);
    // Check the ItemType exists
    if (validateChildInfo == null) {
        Errors.Append("ItemType " + Info.ItemType + " doesn't exist." + Environment.NewLine);
    } else {
        // Check the ParentType is specified in the item
        if (validateChildInfo.ParentType.Equals(String.Empty)) {
            Errors.Append("ParentType property is missing on item " + validateChildInfo.ObjectName + "." + Environment.NewLine);
        } else {
            // Check the ParentType of the item is the collection itself
            if (validateChildInfo.ParentType != Info.ObjectName) {
                Errors.Append("The parent name (ParentType) of " + validateChildInfo.ObjectName + " doesn't match: is '" + validateChildInfo.ParentType + "' but should be '" + Info.ObjectName + "'." + Environment.NewLine);
            }
        }
        // Check the ItemType is valid for this kind of collection
        if (!RelationRulesEngine.IsChildAllowed(Info.ObjectType, validateChildInfo.ObjectType)) {
            Errors.Append("Item " + validateChildInfo.ObjectName + ": " + RelationRulesEngine.BrokenRuleMsg + Environment.NewLine);
        }
    }
}       
%>