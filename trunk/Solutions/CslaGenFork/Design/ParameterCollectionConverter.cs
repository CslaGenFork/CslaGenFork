using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for ParameterCollectionConverter.
    /// </summary>
    public class ParameterCollectionConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(ParameterCollection))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(String))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String))
            {
                if (value is ParameterCollection)
                {
                    StringBuilder sb = new StringBuilder();
                    bool first = true;
                    foreach (Parameter param in (ParameterCollection)value)
                    {
                        if (!first) { sb.Append(", "); }
                        else { first = false; }
                        sb.Append(param.CriteriaName + "." + param.PropertyName);
                    }
                    return sb.ToString();
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
