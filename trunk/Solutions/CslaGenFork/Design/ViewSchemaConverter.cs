using System;
using System.ComponentModel;
using System.Globalization;
using SchemaExplorer;
using CslaGenerator.Metadata;

namespace CslaGenerator.Design
{
	/// <summary>
	/// Summary description for ViewSchemaConverter.
	/// </summary>
	public class ViewSchemaConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) 
		{
			if (sourceType == typeof(ViewSchema)) 
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
				if (value is ViewSchema)
				{
					return ((ViewSchema)value).Name;
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
