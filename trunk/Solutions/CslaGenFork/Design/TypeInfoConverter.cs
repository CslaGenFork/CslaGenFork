using System;
using System.ComponentModel;
using System.Globalization;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for TypeInfoConverter.
    /// </summary>
    public class TypeInfoConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(TypeInfo))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        /*public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof (String))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }*/

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destinationType)
        {
            if (destinationType == typeof(String))
            {
                if (value is TypeInfo)
                {
                    TypeInfo info = (TypeInfo) value;
                    if (info.Type != String.Empty)
                    {
                        return info.Type;
                    }

                    if (info.ObjectMetadata != null)
                    {
                        return info.ObjectMetadata.GenericName;
                    }

                    return String.Empty;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}