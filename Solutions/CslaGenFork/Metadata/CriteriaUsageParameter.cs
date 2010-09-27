using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{
    [TypeConverterAttribute(typeof(CriteriaUsageParameterConverter))]
    public class CriteriaUsageParameter
    {
        private bool _Procedure;
        private bool _Factory;
        private bool _DataPortal;
        private bool _RunLocal;
        private string _ProcedureName = String.Empty;
        private string _FactorySuffix = String.Empty;

        public event EventHandler SuffixChanged;

        public void Enable()
        {
            _Factory = true;
            _Procedure = true;
            _DataPortal = true;
        }

        [Description("Defines whether you want to generate the stored procedure or not.")]
        public bool Procedure
        {
            get
            {
                return _Procedure;
            }
            set
            {
                if (_Procedure == value)
                    return;
                _Procedure = value;
                if (value)
                    OnSuffixChanged();
            }
        }
        [Description("Defines whether you want to generate the factory method or not.")]
        public bool Factory
        {
            get
            {
                return _Factory;
            }
            set
            {
                if (_Factory == value)
                    return;
                _Factory = value;
            }
        }
        [Description("Defines whether you want to generate the dataportal method or not.")]
        public bool DataPortal
        {
            get
            {
                return _DataPortal;
            }
            set
            {
                _DataPortal = value;
            }
        }
        [Description("Defines whether you want to generate the add a RunLocal() attribute to the dataportal method or not.")]
        public bool RunLocal
        {
            get
            {
                return _RunLocal;
            }
            set
            {
                _RunLocal = value;
            }
        }
        [Description("Defines the name of the stored procedure.")]
        public string ProcedureName
        {
            get
            {
                return _ProcedureName;
            }
            set
            {
                if (_ProcedureName == value)
                    return;
                _ProcedureName = value;
            }
        }
        [Description("When generating factory methods, they will be named [Get/Delete/Create] + ObjectName + Suffix. For instance for an object named Project and empty suffix: GetProject(). Sample with 'ByName': GetProjectByName().")]
        public string FactorySuffix
        {
            get
            {
                return _FactorySuffix;
            }
            set
            {
                if (!_FactorySuffix.Equals(value))
                {
                    _FactorySuffix = value;
                    OnSuffixChanged();
                }
            }
        }

        void OnSuffixChanged()
        {
            if (SuffixChanged != null)
                SuffixChanged(this, EventArgs.Empty);
        }
    }


    public class CriteriaUsageParameterConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context,
                                      System.Type destinationType)
        {
            if (destinationType == typeof(CriteriaUsageParameter))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                               CultureInfo culture,
                               object value,
                               System.Type destinationType)
        {
            if (destinationType == typeof(System.String) &&
                 value is CriteriaUsageParameter)
            {

                CriteriaUsageParameter so = (CriteriaUsageParameter)value;

                return "Factory: " + so.Factory;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
