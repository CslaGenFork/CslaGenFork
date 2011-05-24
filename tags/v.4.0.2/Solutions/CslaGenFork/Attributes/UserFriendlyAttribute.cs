using System;

namespace CslaGenerator.Attributes
{
	/// <summary>
	/// This attribute is only valid on a field.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class UserFriendlyNameAttribute : Attribute
	{
		private string name;
		public  UserFriendlyNameAttribute(string name)
		{
			this.name = name;
		}

		//Define Name property.
		//This is a read-only attribute.        
		public virtual string UserFriendlyName
		{
			get {return name;}        
		}
	}
}
