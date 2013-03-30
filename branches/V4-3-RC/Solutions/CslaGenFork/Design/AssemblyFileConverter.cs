using System;
using System.ComponentModel;
using System.Globalization;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
    public class AssemblyFileConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String) && value is string)
            {
                var source = (string)value;
                if (string.IsNullOrEmpty(source))
                    return source;

                var result = "...";
                result += source.Substring(source.LastIndexOf('\\'));
                return result;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
