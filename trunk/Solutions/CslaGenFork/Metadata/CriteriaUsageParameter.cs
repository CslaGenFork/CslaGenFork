using System;
using System.ComponentModel;
using System.Globalization;

namespace CslaGenerator.Metadata
{
    [TypeConverterAttribute(typeof(CriteriaUsageParameterConverter))]
    public class CriteriaUsageParameter
    {
        private bool _factory;
        private bool _addRemove;
        private bool _dataPortal;
        private bool _runLocal;
        private bool _procedure;
        private string _procedureName = String.Empty;
        private string _factorySuffix = String.Empty;

        public event EventHandler SuffixChanged;

        public void Enable()
        {
            _factory = true;
            _procedure = true;
            _dataPortal = true;
        }

        [Description("Defines whether you want to generate the factory method or not.")]
        public bool Factory
        {
            get { return _factory; }
            set
            {
                if (_factory == value)
                    return;
                _factory = value;
            }
        }

        [Description("Defines whether you want to generate the collection Add/Remove method or not. This property is set on the collection item although the method is generated in the collection class.")]
        public bool AddRemove
        {
            get { return _addRemove; }
            set
            {
                if (_addRemove == value)
                    return;
                _addRemove = value;
            }
        }

        [Description("Defines whether you want to generate the DataPortal method or not. If set to false, the criteria nested class won't be generated.")]
        public bool DataPortal
        {
            get { return _dataPortal; }
            set { _dataPortal = value; }
        }

        [Description("Defines whether you want to add a RunLocal attribute to the DataPortal method or not.")]
        public bool RunLocal
        {
            get { return _runLocal; }
            set { _runLocal = value; }
        }

        [Description("Defines whether you want to generate the stored procedure or not.")]
        public bool Procedure
        {
            get { return _procedure; }
            set
            {
                if (_procedure == value)
                    return;
                _procedure = value;
                if (value)
                    OnSuffixChanged();
            }
        }

        [Description("Defines the name of the stored procedure. This will be used for generating the DataPortal method and the stored procedure itself.")]
        public string ProcedureName
        {
            get { return _procedureName; }
            set
            {
                if (_procedureName == value)
                    return;
                _procedureName = value;
            }
        }

        [Description("When generating factory methods, they will be named [Get/Delete/Create] + ObjectName + Suffix. For instance for an object named Project and empty suffix: GetProject(). Sample with 'ByName': GetProjectByName().")]
        public string FactorySuffix
        {
            get { return _factorySuffix; }
            set
            {
                if (!_factorySuffix.Equals(value))
                {
                    _factorySuffix = value;
                    OnSuffixChanged();
                }
            }
        }

        void OnSuffixChanged()
        {
            if (SuffixChanged != null)
                SuffixChanged(this, EventArgs.Empty);
        }

        internal static CriteriaUsageParameter Clone(CriteriaUsageParameter masterUsageParam)
        {
            var newUsageParam = new CriteriaUsageParameter();

            newUsageParam.Factory = masterUsageParam.Factory;
            newUsageParam.AddRemove = masterUsageParam.AddRemove;
            newUsageParam.DataPortal = masterUsageParam.DataPortal;
            newUsageParam.RunLocal = masterUsageParam.RunLocal;
            newUsageParam.Procedure = masterUsageParam.Procedure;
            newUsageParam.ProcedureName = masterUsageParam.ProcedureName;
            newUsageParam.FactorySuffix = masterUsageParam.FactorySuffix;

            return newUsageParam;
        }

    }

    public class CriteriaUsageParameterConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(CriteriaUsageParameter))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is CriteriaUsageParameter)
            {
                CriteriaUsageParameter so = (CriteriaUsageParameter)value;
                return "Factory: " + so.Factory;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}