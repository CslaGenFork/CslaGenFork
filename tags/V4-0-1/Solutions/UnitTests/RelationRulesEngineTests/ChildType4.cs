using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ChildType4
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

        #region ChildType4 - child of readonly lists - ReadOnlyCollection

        [Test]
        public void ChildType4_Object_ReadOnlyCollection_EditableChild()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.EditableChild));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("The child or ItemType is 'EditableChild' but should be 'ReadOnlyObject'.", RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType4_Object_ReadOnlyCollection_EditableSwitchable()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.EditableSwitchable));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("The child or ItemType is 'EditableSwitchable' but should be 'ReadOnlyObject'.", RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType4_Object_ReadOnlyCollection_DynamicEditableRoot()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("The child or ItemType is 'DynamicEditableRoot' but should be 'ReadOnlyObject'.", RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType4_Object_ReadOnlyCollection_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType4_Object_ReadOnlyCollection_EditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.EditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'EditableRoot' but should be 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType4_Collection_ReadOnlyCollection_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.EditableChildCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("The child or ItemType is 'EditableChildCollection' but should be 'ReadOnlyObject'.", RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType4_Collection_ReadOnlyCollection_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.ReadOnlyCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("The child or ItemType is 'ReadOnlyCollection' but should be 'ReadOnlyObject'.", RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType4_Collection_ReadOnlyCollection_EditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.EditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'EditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType4_Collection_ReadOnlyCollection_DynamicEditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.DynamicEditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'DynamicEditableRootCollection' but should be 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyObject' or 'EditableChildCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}