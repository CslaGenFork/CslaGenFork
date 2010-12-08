using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ChildType5
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

        #region ChildType5 - child of dynamic lists - DynamicEditableRootCollection

        [Test]
        public void ChildType5_Object_DynamicEditableRootCollection_DynamicEditableRoot()
        {
            Assert.True(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.DynamicEditableRoot));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType5_Object_DynamicEditableRootCollection_EditableRoot()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.EditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'EditableRoot' but should be 'DynamicEditableRoot'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType5_Object_DynamicEditableRootCollection_EditableChild()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.EditableChild));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'EditableChild' but should be 'DynamicEditableRoot'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType5_Object_DynamicEditableRootCollection_EditableSwitchable()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.EditableSwitchable));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'EditableSwitchable' but should be 'DynamicEditableRoot'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType5_Object_DynamicEditableRootCollection_ReadOnlyObject()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.ReadOnlyObject));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'ReadOnlyObject' but should be 'DynamicEditableRoot'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType5_Collection_DynamicEditableRootCollection_EditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.EditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'EditableRootCollection' but should be 'DynamicEditableRoot'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType5_Collection_DynamicEditableRootCollection_EditableChildCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.EditableChildCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'EditableChildCollection' but should be 'DynamicEditableRoot'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType5_Collection_DynamicEditableRootCollection_DynamicEditableRootCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.DynamicEditableRootCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'DynamicEditableRootCollection' but should be 'DynamicEditableRoot'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ChildType5_Collection_DynamicEditableRootCollection_ReadOnlyCollection()
        {
            Assert.False(RelationRulesEngine.IsChildAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.ReadOnlyCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe child or ItemType is 'ReadOnlyCollection' but should be 'DynamicEditableRoot'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}