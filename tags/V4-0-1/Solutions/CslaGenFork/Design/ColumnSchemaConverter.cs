using System;
using System.ComponentModel;
using System.Globalization;
using SchemaExplorer;


namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for ColumnSchemaConverter.
    /// </summary>
    public class ColumnSchemaConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(ColumnSchema))
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
                if (value is ColumnSchema)
                {
                    return ((ColumnSchema)value).Name;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
