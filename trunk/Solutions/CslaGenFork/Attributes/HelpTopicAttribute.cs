using System;

namespace CslaGenerator.Attributes
{
	/// <summary>
	/// This attribute is only valid on a field.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class HelpTopicAttribute : Attribute
	{
		private string name;
		public  HelpTopicAttribute(string name)
		{
			this.name = name;
		}

		//Define Name property.
		//This is a read-only attribute.        
		public virtual string HelpTopic
		{
			get {return name;}        
		}
	}
}
