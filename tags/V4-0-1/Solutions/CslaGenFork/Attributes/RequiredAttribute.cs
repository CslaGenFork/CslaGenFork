using System;

namespace CslaGenerator.Attributes
{
	/// <summary>
	/// Summary description for RequiredAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class RequiredAttribute : Attribute
	{
		private bool isrequired;
		public RequiredAttribute(bool required)
		{
			isrequired = required;
		}
		//Define IsRequired property.
		//This is a read-only attribute.        
		public virtual bool IsRequired
		{
			get {return isrequired;}        
		}
	}
}
