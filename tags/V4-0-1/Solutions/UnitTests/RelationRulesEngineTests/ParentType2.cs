using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ParentType2
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

        #region ParentType2 - parent of editable objects - EditableChild

        [Test]
        public void ParentType2_Object_EditableRoot_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRoot, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Object_EditableChild_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChild, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Object_EditableSwitchable_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Object_DynamicEditableRoot_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Object_ReadOnlyObject_EditableChild()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.EditableChild));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of an Editable object must be Editable (object or collection). * * *\r\nThe ParentType is 'ReadOnlyObject' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'EditableRootCollection' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Collection_EditableRootCollection_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Collection_EditableChildCollection_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Collection_DynamicEditableRootCollection_EditableChild()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.EditableChild));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of an Editable object must be Editable (object or collection). * * *\r\nThe ParentType is 'DynamicEditableRootCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'EditableRootCollection' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Collection_ReadOnlyCollection_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("\r\nRelation rule: The parent of an Editable object must be Editable (object or collection). * * *\r\nThe ParentType is 'ReadOnlyCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'EditableRootCollection' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion

        #region ParentType2 - parent of editable objects - EditableSwitchable

        [Test]
        public void ParentType2_Object_EditableRoot_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRoot, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Object_EditableChild_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChild, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Object_EditableSwitchable_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Object_DynamicEditableRoot_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Object_ReadOnlyObject_EditableSwitchable()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.EditableSwitchable));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of an Editable object must be Editable (object or collection). * * *\r\nThe ParentType is 'ReadOnlyObject' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'EditableRootCollection' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Collection_EditableRootCollection_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Collection_EditableChildCollection_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Collection_DynamicEditableRootCollection_EditableSwitchable()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.EditableSwitchable));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of an Editable object must be Editable (object or collection). * * *\r\nThe ParentType is 'DynamicEditableRootCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'EditableRootCollection' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType2_Collection_ReadOnlyCollection_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("\r\nRelation rule: The parent of an Editable object must be Editable (object or collection). * * *\r\nThe ParentType is 'ReadOnlyCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'EditableRootCollection' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}