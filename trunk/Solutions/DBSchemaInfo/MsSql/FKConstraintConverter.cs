using System;
using System.ComponentModel;
using System.Globalization;
using DBSchemaInfo.Base;

namespace DBSchemaInfo.MsSql
{
    public class FKConstraintConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var fkConstraint = ((SqlColumnInfo)context.Instance).FKConstraint;
                if(fkConstraint != null)
                    return fkConstraint.ConstraintName + " to " +
                        fkConstraint.PKTable.ObjectSchema + "." +
                        fkConstraint.PKTable.ObjectName;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
