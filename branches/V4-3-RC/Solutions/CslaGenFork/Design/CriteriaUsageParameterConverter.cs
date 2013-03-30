using System;
using System.ComponentModel;
using System.Globalization;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
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
                var source = (CriteriaUsageParameter)value;
                var result = string.Empty;
                result += source.Factory ? "Factory" : "";
                result += source.Factory && source.DataPortal ? ", " : "";
                result += source.DataPortal ? "DataPortal" : "";
                return result;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
