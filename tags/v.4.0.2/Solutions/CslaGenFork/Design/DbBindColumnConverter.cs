using System;
using System.ComponentModel;
using System.Globalization;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
    /// <summary>
    /// Summary description for DbBindColumnConverter.
    /// </summary>
    public class DbBindColumnConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(DbBindColumn))
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
                if (value is DbBindColumn)
                {
                    DbBindColumn col = (DbBindColumn)value;
                    if (col.ColumnOriginType == ColumnOriginType.StoredProcedure)
                        return String.Format("{0} ({1}:{2})", col.ColumnName, col.ObjectName, col.SpResultIndex);
                    else
                        return String.Format("{0} ({1})", col.ColumnName, col.ObjectName);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
