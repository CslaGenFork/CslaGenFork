using System.Collections;

namespace CslaGenerator.Metadata
{
    //if (framework != CslaGenerator.Metadata.TargetFramework.CSLA40)
    //            return;

    /// <summary>
    /// Central point of enforcement for relation rules between object stereotypes.
    /// </summary>
    public static class RelationRulesEngine
    {
        private static ArrayList _baseStereotype = new ArrayList();
        private static ArrayList _dependentStereotype = new ArrayList();
        private static string _specificErrorMessage;

        #region Hardtofit stuff

        /// <summary>
        /// Gets the broken rule message.
        /// </summary>
        /// <value>The broken rule message.</value>
        public static string BrokenRuleMsg { get; private set; }

        private static void SetBrokenRuleMsg(string relationType, CslaObjectType dependent)
        {
            if (!string.IsNullOrEmpty(_specificErrorMessage))
                BrokenRuleMsg = "\r\nRelation rule: " + _specificErrorMessage + " * * *\r\n";

            BrokenRuleMsg += "The " + relationType + " is '" + dependent + "' but should be '";
            for (var pos = 0; pos < _dependentStereotype.Count; pos++)
            {
                BrokenRuleMsg += _dependentStereotype[pos].ToString();
                if (pos != _dependentStereotype.Count - 1)
                    BrokenRuleMsg += "' or '";
            }
            BrokenRuleMsg += "'.";
        }

        /// <summary>
        /// Determines whether the specified <paramref name="stereotype"/> is allowed to have no parent.
        /// </summary>
        /// <param name="stereotype">The candidate stereotype.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <paramref name="stereotype"/> is allowed to have no parent; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>This is "ParentType1" - root stereotypes don't have a parent.</remarks>
        public static bool IsNoParentAllowed(CslaObjectType stereotype)
        {
            _specificErrorMessage = string.Empty;
            BrokenRuleMsg = string.Empty;

            if (stereotype == CslaObjectType.EditableRoot ||
                stereotype == CslaObjectType.EditableRootCollection ||
                stereotype == CslaObjectType.DynamicEditableRootCollection ||
                stereotype == CslaObjectType.ReadOnlyObject ||
                stereotype == CslaObjectType.ReadOnlyCollection)
                return true;

            BrokenRuleMsg = stereotype + " must have a ParentType.";
            return false;
        }

        #endregion

        #region Child viewpoint - allowed parents

        /// <summary>
        /// Determines whether <paramref name="parent"/> is allowed on <paramref name="child"/> objects.
        /// </summary>
        /// <param name="parent">The parent candidate.</param>
        /// <param name="child">The child candidate.</param>
        /// <returns>
        /// 	<c>true</c> if <paramref name="parent"/> is allowed on <paramref name="child"/> objects; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsParentAllowed(CslaObjectType parent, CslaObjectType child)
        {
            BrokenRuleMsg = string.Empty;

            if (!CanHaveParent(child))
                return false;

            bool? result;

            ParentType2_LoadData();
            result = ParentType(parent, child);
            if (result != null)
                return result == true;

            ParentType3_LoadData();
            result = ParentType(parent, child);
            if (result != null)
                return result == true;

            ParentType4_LoadData();
            result = ParentType(parent, child);
            if (result != null)
                return result == true;

            ParentType5_LoadData();
            result = ParentType(parent, child);
            if (result != null)
                return result == true;

            ParentType6_LoadData();
            result = ParentType(parent, child);
            if (result != null)
                return result == true;

            return false;
        }

        // ParentType1 - root stereotypes can't have parent
        private static bool CanHaveParent(CslaObjectType child)
        {
            _specificErrorMessage = "A Root stereotype cannot have a parent.";

            if (child == CslaObjectType.EditableRoot ||
                child == CslaObjectType.EditableRootCollection ||
                child == CslaObjectType.DynamicEditableRootCollection)
            {
                BrokenRuleMsg = "\r\nRelation rule: " + _specificErrorMessage + " * * *\r\n";
                BrokenRuleMsg += child + " cannot have a ParentType.";
                return false;
            }

            return true;
        }

        private static bool? ParentType(CslaObjectType parent, CslaObjectType child)
        {
            bool? dependent = null;

            foreach (var baseStereotype in _baseStereotype)
            {
                if (child == (CslaObjectType) baseStereotype)
                {
                    dependent = IsAllowedParent(parent);
                    if (dependent == true)
                        return true;
                }
            }

            return dependent;
        }

        private static bool IsAllowedParent(CslaObjectType dependent)
        {
            foreach (var dependentStereotype in _dependentStereotype)
            {
                if (dependent == (CslaObjectType) dependentStereotype)
                    return true;
            }

            SetBrokenRuleMsg("ParentType", dependent);
            return false;
        }

        #region LoadData for ParentTypes

        private static void ParentType2_LoadData()
        {
            // parent of editable objects

            _specificErrorMessage = "The parent of an Editable object must be Editable (object or collection).";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.EditableChild);
            _baseStereotype.Add(CslaObjectType.EditableSwitchable);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.EditableRoot);
            _dependentStereotype.Add(CslaObjectType.EditableChild);
            _dependentStereotype.Add(CslaObjectType.EditableSwitchable);
            _dependentStereotype.Add(CslaObjectType.DynamicEditableRoot);
            _dependentStereotype.Add(CslaObjectType.EditableRootCollection);
            _dependentStereotype.Add(CslaObjectType.EditableChildCollection);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyCollection);//added 2009-11-29
        }

        private static void ParentType3_LoadData()
        {
            // parent of editable lists

            _specificErrorMessage = "The parent of an Editable collection must be an Editable object.";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.EditableChildCollection);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.EditableRoot);
            _dependentStereotype.Add(CslaObjectType.EditableChild);
            _dependentStereotype.Add(CslaObjectType.EditableSwitchable);
            _dependentStereotype.Add(CslaObjectType.DynamicEditableRoot);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyCollection);//added 2009-11-29
        }

        private static void ParentType4_LoadData()
        {
            // parent of readonly objects

            _specificErrorMessage = "The parent of a ReadOnly object cannot be an Editable collection.";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.ReadOnlyObject);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.EditableRoot);
            _dependentStereotype.Add(CslaObjectType.EditableChild);
            _dependentStereotype.Add(CslaObjectType.EditableSwitchable);
            _dependentStereotype.Add(CslaObjectType.DynamicEditableRoot);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyObject);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyCollection);
        }

        private static void ParentType5_LoadData()
        {
            // parent of readonly lists

            _specificErrorMessage = "The parent of a ReadOnly collection must be an object (Editable or ReadOnly).";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.ReadOnlyCollection);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.EditableRoot);
            _dependentStereotype.Add(CslaObjectType.EditableChild);
            _dependentStereotype.Add(CslaObjectType.EditableSwitchable);
            _dependentStereotype.Add(CslaObjectType.DynamicEditableRoot);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyObject);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyCollection);//added 2009-11-29
        }

        private static void ParentType6_LoadData()
        {
            // parent of dynamic objects

            _specificErrorMessage = "Specific rule; see below";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.DynamicEditableRoot);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.DynamicEditableRootCollection);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyCollection);//added 2009-11-29
        }

        #endregion

        #endregion

        #region Parent viewpoint - allowed children

        /// <summary>
        /// Determines whether <paramref name="parent"/> can have the specified <paramref name="child"/>.
        /// </summary>
        /// <param name="parent">The parent candidate.</param>
        /// <param name="child">The child candidate.</param>
        /// <returns>
        /// 	<c>true</c> if <paramref name="parent"/> can have the specified <paramref name="child"/>; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsChildAllowed(CslaObjectType parent, CslaObjectType child)
        {
            _specificErrorMessage = string.Empty;
            BrokenRuleMsg = string.Empty;

            bool? result;

            ChildType1_LoadData();
            result = ChildType(parent, child);
            if (result != null)
                return result == true;

            ChildType2_LoadData();
            result = ChildType(parent, child);
            if (result != null)
                return result == true;

            ChildType3_LoadData();
            result = ChildType(parent, child);
            if (result != null)
                return result == true;

            ChildType4_LoadData();
            result = ChildType(parent, child);
            if (result != null)
                return result == true;

            ChildType5_LoadData();
            result = ChildType(parent, child);
            if (result != null)
                return result == true;

            return false;
        }

        private static bool? ChildType(CslaObjectType parent, CslaObjectType child)
        {
            bool? dependent = null;

            foreach (var baseStereotype in _baseStereotype)
            {
                if (parent == (CslaObjectType)baseStereotype)
                {
                    dependent = IsAllowedChild(child);
                    if (dependent == true)
                        return true;
                }
            }

            return dependent;
        }

        private static bool IsAllowedChild(CslaObjectType dependent)
        {
            foreach (var dependentStereotype in _dependentStereotype)
            {
                if (dependent == (CslaObjectType)dependentStereotype)
                    return true;
            }

            SetBrokenRuleMsg("child or ItemType", dependent);
            return false;
        }

        #region LoadData for ChildTypes

        private static void ChildType1_LoadData()
        {
            // child of editable objects

            _specificErrorMessage = "The child of an Editable object must be Editable (object or collection).";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.EditableRoot);
            _baseStereotype.Add(CslaObjectType.EditableChild);
            _baseStereotype.Add(CslaObjectType.EditableSwitchable);
            _baseStereotype.Add(CslaObjectType.DynamicEditableRoot);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.EditableChild);
            _dependentStereotype.Add(CslaObjectType.EditableSwitchable);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyObject);
            _dependentStereotype.Add(CslaObjectType.EditableChildCollection);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyCollection);
        }

        private static void ChildType2_LoadData()
        {
            // child of editable lists

            _specificErrorMessage = "The item of an Editable collection must be an Editable object.";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.EditableRootCollection);
            _baseStereotype.Add(CslaObjectType.EditableChildCollection);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.EditableChild);
            _dependentStereotype.Add(CslaObjectType.EditableSwitchable);
        }

        private static void ChildType3_LoadData()
        {
            // child of readonly objects

            _specificErrorMessage = "The child of a ReadOnly object must be ReadOnly (object or collection).";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.ReadOnlyObject);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.ReadOnlyObject);
            _dependentStereotype.Add(CslaObjectType.ReadOnlyCollection);
        }

        private static void ChildType4_LoadData()
        {
            // child of readonly lists

            _specificErrorMessage = "Specific rule; see below";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.ReadOnlyCollection);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.EditableChild);//added 2009-11-29
            _dependentStereotype.Add(CslaObjectType.EditableSwitchable);//added 2009-11-29
            _dependentStereotype.Add(CslaObjectType.DynamicEditableRoot);//added 2009-11-29
            _dependentStereotype.Add(CslaObjectType.ReadOnlyObject);
            _dependentStereotype.Add(CslaObjectType.EditableChildCollection);//added 2009-11-29
            _dependentStereotype.Add(CslaObjectType.ReadOnlyCollection);//added 2009-11-29

        }

        private static void ChildType5_LoadData()
        {
            // child of dynamic lists

            _specificErrorMessage = "Specific rule; see below";

            _baseStereotype.Clear();
            _baseStereotype.Add(CslaObjectType.DynamicEditableRootCollection);

            _dependentStereotype.Clear();
            _dependentStereotype.Add(CslaObjectType.DynamicEditableRoot);
        }

        #endregion

        #endregion

        #region Associative entities

        public static bool IsAllowedEntityObject(CslaObjectInfo objectInfo)
        {
            if (objectInfo.ObjectType == CslaObjectType.EditableRoot ||
                objectInfo.ObjectType == CslaObjectType.EditableChild ||
                objectInfo.ObjectType == CslaObjectType.EditableSwitchable ||
                objectInfo.ObjectType == CslaObjectType.ReadOnlyObject)
                return true;

            return false;
        }

        public static bool IsAllowedEntityCollection(CslaObjectInfo objectInfo)
        {
            if (objectInfo.ObjectType == CslaObjectType.EditableChildCollection ||
                objectInfo.ObjectType == CslaObjectType.ReadOnlyCollection)
                return true;

            return false;
        }

        public static bool IsAllowedEntityCollectionItem(CslaObjectInfo objectInfo)
        {
            if (objectInfo.ObjectType == CslaObjectType.EditableChild ||
                objectInfo.ObjectType == CslaObjectType.ReadOnlyObject)
                return true;

            return false;
        }

        public static bool IsCompatibleEntityCollectionItemPair(CslaObjectInfo collectionObjectInfo, CslaObjectInfo itemObjectInfo)
        {
            if (collectionObjectInfo.ObjectType == CslaObjectType.EditableChildCollection && itemObjectInfo.ObjectType == CslaObjectType.EditableChild)
                return true;
            if (collectionObjectInfo.ObjectType == CslaObjectType.ReadOnlyCollection && itemObjectInfo.ObjectType == CslaObjectType.ReadOnlyObject)
                return true;

            return false;
        }

        #endregion

    }
}