using CslaGenerator.Metadata;
using NUnit.Framework;

namespace UnitTests.RelationRulesEngineTests
{
    [TestFixture]
    public class ParentType1
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

        #region ParentType1 - IsNoParentAllowed

        [Test]
        public void ParentType1_Object_EditableRoot()
        {
            Assert.True(RelationRulesEngine.IsNoParentAllowed(CslaObjectType.EditableRoot));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType1_Object_ReadOnlyObject()
        {
            Assert.True(RelationRulesEngine.IsNoParentAllowed(CslaObjectType.ReadOnlyObject));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType1_Object_EditableChild()
        {
            Assert.False(RelationRulesEngine.IsNoParentAllowed(CslaObjectType.EditableChild));
            Assert.AreEqual("EditableChild must have a ParentType.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType1_Object_EditableSwitchable()
        {
            Assert.False(RelationRulesEngine.IsNoParentAllowed(CslaObjectType.EditableSwitchable));
            Assert.AreEqual("EditableSwitchable must have a ParentType.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType1_Object_DynamicEditableRoot()
        {
            Assert.False(RelationRulesEngine.IsNoParentAllowed(CslaObjectType.DynamicEditableRoot));
            Assert.AreEqual("DynamicEditableRoot must have a ParentType.", RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType1_Collection_EditableRootCollection()
        {
            Assert.True(RelationRulesEngine.IsNoParentAllowed(CslaObjectType.EditableRootCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType1_Collection_DynamicEditableRootCollection()
        {
            Assert.True(RelationRulesEngine.IsNoParentAllowed(CslaObjectType.DynamicEditableRootCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType1_Collection_ReadOnlyCollection()
        {
            Assert.True(RelationRulesEngine.IsNoParentAllowed(CslaObjectType.ReadOnlyCollection));
            Assert.AreEqual(string.Empty, RelationRulesEngine.BrokenRuleMsg);
        }

        [Test]
        public void ParentType1_Collection_EditableChildCollection()
        {
            Assert.False(RelationRulesEngine.IsNoParentAllowed(CslaObjectType.EditableChildCollection));
            Assert.AreEqual("EditableChildCollection must have a ParentType.", RelationRulesEngine.BrokenRuleMsg);
        }

        #endregion
    }
}