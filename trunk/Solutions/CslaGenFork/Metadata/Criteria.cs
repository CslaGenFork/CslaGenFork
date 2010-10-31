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
        private string _summary = String.Empty;
        private string _remarks = String.Empty;
        private CriteriaPropertyCollection _properties = new CriteriaPropertyCollection();
        private CriteriaUsageParameter _createOptions = new CriteriaUsageParameter();
        private CriteriaUsageParameter _getOptions = new CriteriaUsageParameter();
        private CriteriaUsageParameter _deleteOptions = new CriteriaUsageParameter();
        private CslaObjectInfo _parent;

        public Criteria()
        {
            SetHandlers(_getOptions);
            SetHandlers(_deleteOptions);
        }

        void SetHandlers(CriteriaUsageParameter p)
        {
            if (p == null)
                return;
            p.SuffixChanged += SuffixChanged;
        }

        void UnSetHandlers(CriteriaUsageParameter p)
        {
            if (p == null)
                return;
            p.SuffixChanged -= SuffixChanged;
        }

        void SuffixChanged(object sender, EventArgs e)
        {
            if (_parent == null ||
                GeneratorController.Current == null ||
                GeneratorController.Current.CurrentUnit == null)
            {
                return;
            }
            ProjectParameters p = GeneratorController.Current.CurrentUnit.Params;
            if (ReferenceEquals(sender, _getOptions))
                _getOptions.ProcedureName = p.GetGetProcName(_parent.ObjectName + _getOptions.FactorySuffix);
            else if (ReferenceEquals(sender, _deleteOptions))
                _deleteOptions.ProcedureName = p.GetDeleteProcName(_parent.ObjectName + _deleteOptions.FactorySuffix);
        }

        public Criteria(CslaObjectInfo obj)
            : this()
        {
            _parent = obj;
        }

        internal void SetParent(CslaObjectInfo obj)
        {
            _parent = obj;
        }

        public void SetSprocNames()
        {
            if (_parent == null) { return; }
            ProjectParameters p = GeneratorController.Current.CurrentUnit.Params;
            _getOptions.ProcedureName = p.GetGetProcName(_parent.ObjectName);
            _deleteOptions.ProcedureName = p.GetDeleteProcName(_parent.ObjectName);
        }

        [Category("01. Definition")]
        [Description("The criteria name. This will be used as the nested class name.")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Category("02. Criteria Options")]
        [UserFriendlyName("Create Options")]
        public CriteriaUsageParameter CreateOptions
        {
            get { return _createOptions; }
            set { _createOptions = value; }
        }

        [Category("02. Criteria Options")]
        [UserFriendlyName("Get Options")]
        public CriteriaUsageParameter GetOptions
        {
            get { return _getOptions; }
            set
            {
                UnSetHandlers(_getOptions);
                _getOptions = value;
                SetHandlers(_getOptions);
            }
        }

        [Category("02. Criteria Options")]
        [UserFriendlyName("Delete Options")]
        public CriteriaUsageParameter DeleteOptions
        {
            get { return _deleteOptions; }
            set
            {
                UnSetHandlers(_deleteOptions);
                _deleteOptions = value;
                SetHandlers(_deleteOptions);
            }
        }

        [Category("03. Criteria Properties")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [XmlArrayItem(ElementName = "Property", Type = typeof(CriteriaProperty))]
        [Description("Properties used by the criteria.")]
        [UserFriendlyName("Criteria Properties")]
        public CriteriaPropertyCollection Properties
        {
            get { return _properties; }
        }

        [Category("04. Documentation")]
        [Editor(typeof(XmlCommentEditor), typeof(UITypeEditor))]
        [Description("Summary of the criteria.")]
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        [Category("04. Documentation")]
        [Editor(typeof(XmlCommentEditor), typeof(UITypeEditor))]
        [Description("Remarks of the criteria.")]
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
    }
}