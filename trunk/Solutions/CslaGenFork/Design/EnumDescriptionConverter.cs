using System;
using System.ComponentModel;
using System.Globalization;
using CslaGenerator.CodeGen;

namespace CslaGenerator.Design
{
    public class EnumDescriptionConverter : EnumConverter
    {
        //http://www.codeproject.com/Articles/22717/Using-PropertyGrid

        private readonly Type _enumType;

        /// <summary>Initializing instance</summary>
        /// <param name="type">type Enum</param>
        /// <remarks>
        /// this is only one function, that you must  change. All another functions for enums  you can use by Ctrl+C/Ctrl+V
        /// </remarks>
        public EnumDescriptionConverter(Type type)
            : base(type)
        {
            _enumType = type;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context,
            Type destType)
        {
            return destType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destType)
        {
            var fi = _enumType.GetField(Enum.GetName(_enumType, value));
            var dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

            if (dna != null)
                return dna.Description;

            return value.ToString();
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context,
            Type srcType)
        {
            return srcType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            foreach (var fi in _enumType.GetFields())
            {
                var dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));

                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(_enumType, fi.Name);
            }
            return Enum.Parse(_enumType, (string)value);
        }
    }
}