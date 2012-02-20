using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ParentType4
    {
        // EditableRoot
        // EditableChild
        // EditableSwitchable
        // DynamicEditableRoot
        // ReadOnlyObject

        // EditableRootCollection
        // EditableChildCollection
        // DynamicEditableRootCollection
        // ReadOnlyCollection

        #region ParentType4 - parent of readonly objects - ReadOnlyObject

        [Test]
        public void ParentType4_Object_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRoot, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType4_Object_EditableChild_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChild, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType4_Object_EditableSwitchable_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType4_Object_DynamicEditableRoot_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType4_Object_ReadOnlyObject_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType4_Collection_ReadOnlyCollection_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType4_Collection_EditableRootCollection_ReadOnlyObject()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.ReadOnlyObject));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of a ReadOnly object cannot be an Editable collection. * * *\r\nThe ParentType is 'EditableRootCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType4_Collection_EditableChildCollection_ReadOnlyObject()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.ReadOnlyObject));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of a ReadOnly object cannot be an Editable collection. * * *\r\nThe ParentType is 'EditableChildCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType4_Collection_DynamicEditableRootCollection_ReadOnlyObject()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.ReadOnlyObject));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of a ReadOnly object cannot be an Editable collection. * * *\r\nThe ParentType is 'DynamicEditableRootCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}