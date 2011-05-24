using System;

namespace CslaGenerator.Attributes
{
	/// <summary>
	/// This attribute is only valid on a field.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class HelpTopicAttribute : Attribute
	{
		private readonly string _name;

		public  HelpTopicAttribute(string name)
		{
			_name = name;
		}

		//Define Name property.
		//This is a read-only attribute.        
		public virtual string HelpTopic
		{
			get {return _name;}        
		}
	}
}
