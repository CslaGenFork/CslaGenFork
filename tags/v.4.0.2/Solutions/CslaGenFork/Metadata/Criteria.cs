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
        #region Private Fields

        private string _name = String.Empty;
        private string _summary = String.Empty;
        private string _remarks = String.Empty;
        private readonly CriteriaPropertyCollection _properties = new CriteriaPropertyCollection();
        private CriteriaMode _criteriaClassMode = CriteriaMode.Simple;
        private bool _nestedClass = true;
        private CriteriaUsageParameter _createOptions = new CriteriaUsageParameter();
        private CriteriaUsageParameter _getOptions = new CriteriaUsageParameter();
        private CriteriaUsageParameter _deleteOptions = new CriteriaUsageParameter();
        private CslaObjectInfo _parent;

        #endregion

        #region Constructors

        public Criteria()
        {
            SetHandlers(_getOptions);
            SetHandlers(_deleteOptions);
        }

        public Criteria(CslaObjectInfo obj)
            : this()
        {
            _parent = obj;
        }

        #endregion

        #region Public Properties

        #region 01. Definition

        [Category("01. Definition")]
        [Description("The criteria class name. This will be generated when there is the need to pass more than one parameter to the DataPortal method.")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Category("01. Definition")]
        [Description("Criteria class mode. Whether to use simple criteria, CriteriaBase or BusinessBase for the criteria class.")]
        [UserFriendlyName("Criteria Class Mode")]
        public CriteriaMode CriteriaClassMode
        {
            get { return _criteriaClassMode; }
            set { _criteriaClassMode = value; }
        }

        [Category("01. Definition")]
        [Description("Whether the criteria class should be nested and protected or not nested and public." +
            "\r\nNote - BusinessBase criteria class is always not nested and public.")]
        [UserFriendlyName("Nesteded Class")]
        public bool NestedClass
        {
            get { return _nestedClass; }
            set { _nestedClass = value; }
        }

        [Category("01. Definition")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [XmlArrayItem(ElementName = "Property", Type = typeof(CriteriaProperty))]
        [Description("Properties used by the criteria. These will be the parameters to be passed to the generated methods.")]
        [UserFriendlyName("Criteria Properties")]
        public CriteriaPropertyCollection Properties
        {
            get { return _properties; }
        }

        #endregion

        #region 02. Generation Options

        [Category("02. Generation Options")]
        [UserFriendlyName("Create Options")]
        [Description("Specifies what methods will be generated for new object creation.")]
        public CriteriaUsageParameter CreateOptions
        {
            get { return _createOptions; }
            set { _createOptions = value; }
        }

        [Category("02. Generation Options")]
        [UserFriendlyName("Get Options")]
        [Description("Specifies what methods will be generated for fetching an existing object.")]
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

        [Category("02. Generation Options")]
        [UserFriendlyName("Delete Options")]
        [Description("Specifies what methods will be generated for deleting an object.")]
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

        #endregion

        #region 04. Documentation

        [Category("04. Documentation")]
        [Editor(typeof(XmlCommentEditor), typeof(UITypeEditor))]
        [Description("Summary of the criteria. This will be used to document the nested criteria class.")]
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }

        [Category("04. Documentation")]
        [Editor(typeof(XmlCommentEditor), typeof(UITypeEditor))]
        [Description("Remarks of the criteria. This will be used to document the nested criteria class.")]
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        #endregion

        [Browsable(false)]
        public bool IsCreator
        {
            get
            {
                //if (CreateOptions.DataPortal || CreateOptions.Factory)
                if (CreateOptions.DataPortal)
                    return true;

                return false;
            }
        }

        [Browsable(false)]
        public bool IsGetter
        {
            get
            {
                //if (GetOptions.DataPortal || GetOptions.Factory)
                if (GetOptions.DataPortal)
                    return true;

                return false;
            }
        }

        [Browsable(false)]
        public bool IsDeleter
        {
            get
            {
                //if (DeleteOptions.DataPortal || DeleteOptions.Factory)
                if (DeleteOptions.DataPortal)
                    return true;

                return false;
            }
        }

        #endregion

        #region Event Handlers

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

        #endregion

        #region Private and Internal Methods

        private void SetHandlers(CriteriaUsageParameter p)
        {
            if (p == null)
                return;
            p.SuffixChanged += SuffixChanged;
        }

        private void UnSetHandlers(CriteriaUsageParameter p)
        {
            if (p == null)
                return;
            p.SuffixChanged -= SuffixChanged;
        }

        internal void SetParent(CslaObjectInfo obj)
        {
            _parent = obj;
        }

        #endregion

        #region Public Methods

        public void SetSprocNames()
        {
            if (_parent == null) { return; }
            ProjectParameters p = GeneratorController.Current.CurrentUnit.Params;
            _getOptions.ProcedureName = p.GetGetProcName(_parent.ObjectName);
            _deleteOptions.ProcedureName = p.GetDeleteProcName(_parent.ObjectName);
        }

        internal static Criteria Clone(Criteria masterCrit)
        {
            var newCrit = new Criteria();
            newCrit.Name = masterCrit.Name;
            newCrit.CriteriaClassMode = masterCrit.CriteriaClassMode;
            newCrit.NestedClass = masterCrit.NestedClass;
            newCrit.Summary = masterCrit.Summary;
            newCrit.Remarks = masterCrit.Remarks;

            newCrit.CreateOptions = CriteriaUsageParameter.Clone(masterCrit.CreateOptions);
            newCrit.GetOptions = CriteriaUsageParameter.Clone(masterCrit.GetOptions);
            newCrit.DeleteOptions = CriteriaUsageParameter.Clone(masterCrit.DeleteOptions);
            newCrit.Properties.AddRange(CriteriaPropertyCollection.Clone(masterCrit.Properties));

            return newCrit;
        }

        internal static Criteria MergeUnitOfWorkCriteria(Criteria masterCrit, Criteria newCrit)
        {
            var mergedCrit = new Criteria();
            if (mergedCrit.Name == string.Empty)
            {
                mergedCrit.CriteriaClassMode = newCrit.CriteriaClassMode;
                mergedCrit.NestedClass = newCrit.NestedClass;
                mergedCrit.Name = "UnitOfWorkCriteria";
            }
            mergedCrit.Summary = masterCrit.Summary + newCrit.Summary;
            mergedCrit.Remarks = masterCrit.Remarks + newCrit.Remarks;

            mergedCrit.Properties.AddRange(CriteriaPropertyCollection.Clone(masterCrit.Properties));
            mergedCrit.Properties.AddRange(CriteriaPropertyCollection.Clone(newCrit.Properties));

            return mergedCrit;
        }

        #endregion
    }
}