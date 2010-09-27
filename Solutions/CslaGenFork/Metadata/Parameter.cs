using System;

namespace CslaGenerator.Metadata
{
	/// <summary>
	/// Summary description for Parameter.
	/// </summary>
	[Serializable]
	public class Parameter
	{
		private Criteria _criteria;
		private Property _property;

		public Parameter(Criteria crit, Property prop)
		{
			_criteria = crit;
			_property = prop;
		}

		public Parameter()
		{
		}

		public Criteria Criteria
		{
			get { return _criteria; }
			set { _criteria = value; }
		}

		public Property Property
		{
			get { return _property; }
			set { _property = value; }
		}
	}
}
