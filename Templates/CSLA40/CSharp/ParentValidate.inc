<%
// Check the object has a ParentType
if (Info.ParentType.Equals(String.Empty)) {
    // Check it's ok to have no Parent
    if (!RelationRulesEngine.IsNoParentAllowed(Info.ObjectType)) {
        Errors.Append(Info.ObjectName + ": " + RelationRulesEngine.BrokenRuleMsg + Environment.NewLine);
    }
} else {
    CslaObjectInfo validateParentInfo = FindChildInfo(Info, Info.ParentType);
    // Check the ParentType exists
    if (validateParentInfo == null) {
        Errors.Append("ParentType " + Info.ParentType + " doesn't exist." + Environment.NewLine);
    } else {
        // Check the ItemType is specified in the parent
        if (validateParentInfo.ItemType.Equals(String.Empty)) {
            // Collections must have an ItemType
            if (validateParentInfo.ObjectType == CslaObjectType.ReadOnlyCollection ||
                validateParentInfo.ObjectType == CslaObjectType.EditableChildCollection ||
                validateParentInfo.ObjectType == CslaObjectType.DynamicEditableRootCollection ||
                validateParentInfo.ObjectType == CslaObjectType.EditableRootCollection) {
                Errors.Append("ItemType property is missing on parent " + validateParentInfo.ObjectName + "." + Environment.NewLine);
            }
        } else {
            // Check the ItemType of the collection's ItemType is the collection itself
            if (validateParentInfo.ItemType != Info.ObjectName) {
                Errors.Append("The item name (ItemType) of " + validateParentInfo.ObjectName + " doesn't match: is '" + validateParentInfo.ItemType + "' but should be '" + Info.ObjectName + "'." + Environment.NewLine);
            }
            // Check the ParentType is valid for this kind of collection
            if (!RelationRulesEngine.IsParentAllowed(validateParentInfo.ObjectType, Info.ObjectType)) {
                Errors.Append("Parent " + validateParentInfo.ObjectName + ": " + RelationRulesEngine.BrokenRuleMsg + Environment.NewLine);
            }
        }
    }
}
%>