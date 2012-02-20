using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ChildType3
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

        #region ChildType3 - child of readonly objects - ReadOnlyObject

        [Test]
        public void ChildType3_Object_ReadOnlyObject_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType3_Object_ReadOnlyObject_EditableChild()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.EditableChild));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of a ReadOnly object must be ReadOnly (object or collection). * * *\r\nThe child or ItemType is 'EditableChild' but should be 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType3_Object_ReadOnlyObject_EditableSwitchable()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.EditableSwitchable));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of a ReadOnly object must be ReadOnly (object or collection). * * *\r\nThe child or ItemType is 'EditableSwitchable' but should be 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType3_Object_ReadOnlyObject_EditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.EditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of a ReadOnly object must be ReadOnly (object or collection). * * *\r\nThe child or ItemType is 'EditableRoot' but should be 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType3_Object_ReadOnlyObject_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of a ReadOnly object must be ReadOnly (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRoot' but should be 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType3_Collection_ReadOnlyObject_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType3_Collection_ReadOnlyObject_EditableChildCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.EditableChildCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of a ReadOnly object must be ReadOnly (object or collection). * * *\r\nThe child or ItemType is 'EditableChildCollection' but should be 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType3_Collection_ReadOnlyObject_EditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.EditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of a ReadOnly object must be ReadOnly (object or collection). * * *\r\nThe child or ItemType is 'EditableRootCollection' but should be 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType3_Collection_ReadOnlyObject_DynamicEditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.DynamicEditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The child of a ReadOnly object must be ReadOnly (object or collection). * * *\r\nThe child or ItemType is 'DynamicEditableRootCollection' but should be 'ReadOnlyObject' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}