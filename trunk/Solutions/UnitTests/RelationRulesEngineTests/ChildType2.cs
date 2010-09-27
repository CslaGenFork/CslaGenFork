using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ChildType2
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

        #region ChildType2 - child of editable lists - EditableRootCollection

        [Test]
        public void ChildType2_Object_EditableRootCollection_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Object_EditableRootCollection_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Object_EditableRootCollection_ReadOnlyObject()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.ReadOnlyObject));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'ReadOnlyObject' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Object_EditableRootCollection_EditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.EditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'EditableRoot' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Object_EditableRootCollection_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'DynamicEditableRoot' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Collection_EditableRootCollection_EditableChildCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.EditableChildCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'EditableChildCollection' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Collection_EditableRootCollection_ReadOnlyCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.ReadOnlyCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'ReadOnlyCollection' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Collection_EditableRootCollection_EditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.EditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'EditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Collection_EditableRootCollection_DynamicEditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.DynamicEditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'DynamicEditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion

        #region ChildType2 - child of editable lists - EditableChildCollection

        [Test]
        public void ChildType2_Object_EditableChildCollection_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Object_EditableChildCollection_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Object_EditableChildCollection_ReadOnlyObject()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.ReadOnlyObject));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'ReadOnlyObject' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Object_EditableChildCollection_EditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.EditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'EditableRoot' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Object_EditableChildCollection_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'DynamicEditableRoot' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Collection_EditableChildCollection_EditableChildCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.EditableChildCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'EditableChildCollection' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Collection_EditableChildCollection_ReadOnlyCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.ReadOnlyCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'ReadOnlyCollection' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Collection_EditableChildCollection_EditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.EditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'EditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType2_Collection_EditableChildCollection_DynamicEditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.DynamicEditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The item of an Editable collection must be an Editable object. * * *\r\nThe child or ItemType is 'DynamicEditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}