using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ParentType6
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

        #region ParentType6 - parent of dynamic objects - DynamicEditableRoot

        [Test]
        public void ParentType6_Object_EditableRoot_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRoot, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe ParentType is 'EditableRoot' but should be 'DynamicEditableRootCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType6_Object_EditableChild_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChild, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe ParentType is 'EditableChild' but should be 'DynamicEditableRootCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType6_Object_EditableSwitchable_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe ParentType is 'EditableSwitchable' but should be 'DynamicEditableRootCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType6_Object_DynamicEditableRoot_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe ParentType is 'DynamicEditableRoot' but should be 'DynamicEditableRootCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType6_Object_ReadOnlyObject_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe ParentType is 'ReadOnlyObject' but should be 'DynamicEditableRootCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType6_Collection_DynamicEditableRootCollection_DynamicEditableRoot()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.DynamicEditableRoot));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType6_Collection_EditableRootCollection_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe ParentType is 'EditableRootCollection' but should be 'DynamicEditableRootCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType6_Collection_EditableChildCollection_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.DynamicEditableRoot));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe ParentType is 'EditableChildCollection' but should be 'DynamicEditableRootCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType6_Collection_DynamicEditableRoot()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.DynamicEditableRoot));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("\r\nRelation rule: Specific rule; see below * * *\r\nThe ParentType is 'ReadOnlyCollection' but should be 'DynamicEditableRootCollection' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}