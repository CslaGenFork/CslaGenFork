using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{
	/// <summary>
	/// Summary description for CslaGeneratorComponent.
	/// </summary>
	[Serializable]
	public class CslaGeneratorComponent
	{
		private string _componentName = String.Empty;
		[XmlIgnore]
		private CslaGeneratorUnit _parent = null;

		public CslaGeneratorComponent()
		{
		}

		public CslaGeneratorComponent(CslaGeneratorUnit parent)
		{
			_parent = parent;
		}

		[Browsable(false)]
		public string ComponentName
		{
			get { return _componentName; }
			set { _componentName = value; }
		}

		[Browsable(false)]
		[XmlIgnore]
		public CslaGeneratorUnit Parent
		{
			get { return _parent; }
			set { _parent = value; }
		}
	}
}
