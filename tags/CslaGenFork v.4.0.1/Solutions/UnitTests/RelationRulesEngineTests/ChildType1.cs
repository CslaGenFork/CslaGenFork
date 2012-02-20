using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ChildType1
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

        #region ChildType1 - child of editable objects - EditableRoot

        [Test]
        public void ChildType1_Object_EditableRoot_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRoot, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableRoot_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRoot, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableRoot_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRoot, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableRoot_EditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRoot, CslaObjectType.EditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'EditableRoot' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableRoot_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRoot, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRoot' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableRoot_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRoot, CslaObjectType.EditableChildCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableRoot_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRoot, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableRoot_EditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRoot, CslaObjectType.EditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'EditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableRoot_DynamicEditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableRoot, CslaObjectType.DynamicEditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion

        #region ChildType1 - child of editable objects - EditableChild

        [Test]
        public void ChildType1_Object_EditableChild_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChild, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableChild_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChild, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableChild_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChild, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableChild_EditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChild, CslaObjectType.EditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'EditableRoot' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableChild_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChild, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRoot' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableChild_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChild, CslaObjectType.EditableChildCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableChild_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChild, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableChild_EditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChild, CslaObjectType.EditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'EditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableChild_DynamicEditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableChild, CslaObjectType.DynamicEditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion

        #region ChildType1 - child of editable objects - EditableSwitchable

        [Test]
        public void ChildType1_Object_EditableSwitchable_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableSwitchable_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableSwitchable_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableSwitchable_EditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.EditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'EditableRoot' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_EditableSwitchable_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRoot' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableSwitchable_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.EditableChildCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableSwitchable_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableSwitchable_EditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.EditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'EditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_EditableSwitchable_DynamicEditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.DynamicEditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion

        #region ChildType1 - child of editable objects - DynamicEditableRoot

        [Test]
        public void ChildType1_Object_DynamicEditableRoot_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.EditableChild));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_DynamicEditableRoot_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.EditableSwitchable));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_DynamicEditableRoot_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_DynamicEditableRoot_EditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.EditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'EditableRoot' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Object_DynamicEditableRoot_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRoot' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_DynamicEditableRoot_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.EditableChildCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_DynamicEditableRoot_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_DynamicEditableRoot_EditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.EditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'EditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType1_Collection_DynamicEditableRoot_DynamicEditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.DynamicEditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of an Editable object must be Editable (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion

    }
}