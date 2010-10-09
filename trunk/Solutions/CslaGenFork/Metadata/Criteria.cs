using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for Criteria.
    /// </summary>
    [Serializable]
    public class Criteria
    {
        private string _name = String.Empty;
        private CriteriaPropertyCollection _properties = new CriteriaPropertyCollection();
        private CriteriaUsageParameter _CreateOptions = new CriteriaUsageParameter();
        private CriteriaUsageParameter _GetOptions = new CriteriaUsageParameter();
        private CriteriaUsageParameter _DeleteOptions = new CriteriaUsageParameter();

        private CslaObjectInfo _Parent;
        public Criteria()
        {
            SetHandlers(_GetOptions);
            SetHandlers(_DeleteOptions);
        }

        void SetHandlers(CriteriaUsageParameter p)
        {
            if (p == null)
                return;
            p.SuffixChanged += new EventHandler(SuffixChanged);
        }
        void UnSetHandlers(CriteriaUsageParameter p)
        {
            if (p == null)
                return;
            p.SuffixChanged -= new EventHandler(SuffixChanged);
        }

        void SuffixChanged(object sender, EventArgs e)
        {
            if (_Parent == null ||
                GeneratorController.Current == null ||
                GeneratorController.Current.CurrentUnit == null)
            {
                return;
            }
            ProjectParameters p = GeneratorController.Current.CurrentUnit.Params;
            if (ReferenceEquals(sender,_GetOptions))
                _GetOptions.ProcedureName = p.GetGetProcName(_Parent.ObjectName + _GetOptions.FactorySuffix);
            else if (ReferenceEquals(sender,_DeleteOptions))
                _DeleteOptions.ProcedureName = p.GetDeleteProcName(_Parent.ObjectName + _DeleteOptions.FactorySuffix);
        }

        public Criteria(CslaObjectInfo obj) : this()
        {
            _Parent = obj;
        }

        internal void SetParent(CslaObjectInfo obj)
        {
            _Parent = obj;
        }

        public void SetSprocNames()
        {
            if (_Parent == null) { return; }
            ProjectParameters p = GeneratorController.Current.CurrentUnit.Params;
            _GetOptions.ProcedureName = p.GetGetProcName(_Parent.ObjectName);
            _DeleteOptions.ProcedureName = p.GetDeleteProcName(_Parent.ObjectName);
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Category("02. Criteria Options")]
        [UserFriendlyName("Create Options")]
        public CriteriaUsageParameter CreateOptions
        {
            get
            {
                return _CreateOptions;
            }
            set
            {
                _CreateOptions = value;
            }
        }

        [Category("02. Criteria Options")]
        [UserFriendlyName("Get Options")]
        public CriteriaUsageParameter GetOptions
        {
            get
            {
                return _GetOptions;
            }
            set
            {
                UnSetHandlers(_GetOptions);
                _GetOptions = value;
                SetHandlers(_GetOptions);
            }
        }

        [Category("02. Criteria Options")]
        [UserFriendlyName("Delete Options")]
        public CriteriaUsageParameter DeleteOptions
        {
            get
            {
                return _DeleteOptions;
            }
            set
            {
                UnSetHandlers(_DeleteOptions);
                _DeleteOptions = value;
                SetHandlers(_DeleteOptions);
            }
        }

        [Category("03. Criteria Properties")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [XmlArrayItem(
          ElementName = "Property",
          Type = typeof(CriteriaProperty))]
        [Description("This is a description.")]
        public CriteriaPropertyCollection Properties
        {
            get { return _properties; }
        }

    }
}
