using System;
using System.ComponentModel;
using System.Globalization;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for AuthzTypeConverter.
    /// </summary>
    public class AuthzTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof (AuthzTypeInfo))
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
                if (value is AuthzTypeInfo)
                {
                    var info = (AuthzTypeInfo) value;
                    if (info.Type != String.Empty)
                        return info.Type;

                    if (info.ObjectName != string.Empty)
                        return info.ObjectName;

                    if (GeneratorController.Current.CurrentUnit.GenerationParams.DefaultCslaAuthorizationProvider)
                        return "Csla.Rules.CommonRules.IsInRole";

                    return String.Empty;
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
