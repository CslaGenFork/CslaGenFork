using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ParentType5
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

        #region ParentType5 - parent of readonly lists - ReadOnlyCollection

        [Test]
        public void ParentType5_Object_EditableRoot_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRoot, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType5_Object_EditableChild_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChild, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType5_Object_EditableSwitchable_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType5_Object_DynamicEditableRoot_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType5_Object_ReadOnlyObject_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType5_Collection_EditableRootCollection_ReadOnlyCollection()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.ReadOnlyCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of a ReadOnly collection must be an object (Editable or ReadOnly). * * *\r\nThe ParentType is 'EditableRootCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType5_Collection_EditableChildCollection_ReadOnlyCollection()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.ReadOnlyCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of a ReadOnly collection must be an object (Editable or ReadOnly). * * *\r\nThe ParentType is 'EditableChildCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType5_Collection_DynamicEditableRootCollection_ReadOnlyCollection()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.ReadOnlyCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of a ReadOnly collection must be an object (Editable or ReadOnly). * * *\r\nThe ParentType is 'DynamicEditableRootCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType5_Collection_ReadOnlyCollection_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("\r\nRelation rule: The parent of a ReadOnly collection must be an object (Editable or ReadOnly). * * *\r\nThe ParentType is 'ReadOnlyCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}