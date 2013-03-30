using System;
using System.ComponentModel;
using System.Globalization;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for AuthzTypeConverter.
    /// </summary>
    public class AuthorizationRuleTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof (AuthorizationRule))
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

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof (String))
            {
                if (value is AuthorizationRule)
                {
                    var info = (AuthorizationRule) value;
                    if (info.Name != String.Empty)
                        return info.Name;

                    return String.Empty;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}