using System;

namespace CslaGenerator.Attributes
{
	/// <summary>
	/// Summary description for RequiredAttribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class RequiredAttribute : Attribute
	{
		private readonly bool _isrequired;

		public RequiredAttribute(bool required)
		{
			_isrequired = required;
		}

		//Define IsRequired property.
		//This is a read-only attribute.        
		public virtual bool IsRequired
		{
			get {return _isrequired;}        
		}
	}
}
