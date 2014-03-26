using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for StringCollectionConverter.
    /// </summary>
    public class StringCollectionConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(List<string>))
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
                if (value is List<string>)
                {
                    var sb = new StringBuilder();
                    var first = true;
                    foreach (var item in (List<string>)value)
                    {
                        if (!first) { sb.Append(", "); }
                        else { first = false; }
                        sb.Append(item);
                    }
                    return sb.ToString();
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
