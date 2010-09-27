using System;
using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ParentType3
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

        #region ParentType3 - parent of editable lists - EditableChildCollection

        [Test]
        public void ParentType3_Object_EditableRoot_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRoot, CslaObjectType.EditableChildCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType3_Object_EditableChild_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChild, CslaObjectType.EditableChildCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType3_Object_EditableSwitchable_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableSwitchable, CslaObjectType.EditableChildCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType3_Object_DynamicEditableRoot_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRoot, CslaObjectType.EditableChildCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType3_Object_ReadOnlyObject_EditableChildCollection()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyObject, CslaObjectType.EditableChildCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of an Editable collection must be an Editable object. * * *\r\nThe ParentType is 'ReadOnlyObject' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType3_Collection_EditableRootCollection_EditableChildCollection()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableRootCollection, CslaObjectType.EditableChildCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of an Editable collection must be an Editable object. * * *\r\nThe ParentType is 'EditableRootCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType3_Collection_EditableChildCollection_EditableChildCollection()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.EditableChildCollection, CslaObjectType.EditableChildCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of an Editable collection must be an Editable object. * * *\r\nThe ParentType is 'EditableChildCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType3_Collection_DynamicEditableRootCollection_EditableChildCollection()
        {
            Assert.False(RelationRulesEngine.IsParentAllowed(CslaObjectType.DynamicEditableRootCollection, CslaObjectType.EditableChildCollection));
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            Assert.AreEqual("\r\nRelation rule: The parent of an Editable collection must be an Editable object. * * *\r\nThe ParentType is 'DynamicEditableRootCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType3_Collection_ReadOnlyCollection_EditableChildCollection()
        {
            Assert.True(RelationRulesEngine.IsParentAllowed(CslaObjectType.ReadOnlyCollection, CslaObjectType.EditableChildCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
            //Console.WriteLine(RelationRulesEngine.BrokenRuleMsg);
            //Assert.AreEqual("\r\nRelation rule: The parent of an Editable collection must be an Editable object. * * *\r\nThe ParentType is 'ReadOnlyCollection' but should be 'EditableRoot' or 'EditableChild' or 'EditableSwitchable' or 'DynamicEditableRoot' or 'ReadOnlyCollection'.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}