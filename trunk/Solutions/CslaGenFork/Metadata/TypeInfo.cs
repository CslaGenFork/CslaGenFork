using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using CslaGenerator.Design;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{
	/// <summary>
	/// Summary description for TypeInfo.
	/// </summary>
	[Serializable]
	public class TypeInfo : ICloneable
	{
		private string _assemblyFile = String.Empty;
		private string _type = String.Empty;
		private string _objectName = String.Empty;
		private CslaObjectInfo _parent = null;

		public TypeInfo()
		{
		}

		public TypeInfo(CslaObjectInfo parent)
		{
			_parent = parent;
		}

		[Browsable(false)]
		[XmlIgnore]
		public CslaObjectInfo Parent
		{
			get { return _parent; }
			set { _parent = value; }
		}

		[Category("Inherit from Type in Assembly")]
		[Editor(typeof(AssemblyFileNameEditor),typeof(UITypeEditor))]
		public string AssemblyFile
		{
			get { return _assemblyFile; }
			set { _assemblyFile = value; }
		}

		[Category("Inherit from Type in Assembly")]
		[Editor(typeof(RefTypeEditor),typeof(UITypeEditor))]
		public string Type
		{
			get { return _type; }
			set 
			{
				if (_type != value)
				{
					_type = value; 
					if (_type != String.Empty) { _objectName = String.Empty; }
					OnTypeChanged(EventArgs.Empty);
				}
			}
		}

		[Category("Inherit from Type Defined in Project")]
		// TODO: Make this editor work ...
		[Editor(typeof(CslaObjectInfoEditor),typeof(UITypeEditor))]
		public string ObjectName
		{
			get { return _objectName; }
			set 
			{ 
				_objectName = value; 
				if (value != String.Empty) { _type = String.Empty; }
				OnTypeChanged(EventArgs.Empty);
			}
		}
		
		[Browsable(false)]
		[XmlIgnore]
		public CslaObjectInfo ObjectMetadata
		{
			get 
			{ 
				if (_objectName == String.Empty) { return null; }
				return _parent.Parent.CslaObjects.Find(_objectName);
			}
		}


		public Type GetInheritedType()
		{
			if (_assemblyFile != null && _assemblyFile != String.Empty)
			{
				Assembly assembly = Assembly.LoadFrom(_assemblyFile);
				Type t = assembly.GetType(_type);
				if (t == null) { throw new Exception("Type does not exist in Assembly"); }
				else { return t; }
			}
			return null;
		}

		public event EventHandler TypeChanged;

		protected void OnTypeChanged(EventArgs e)
		{
			if (TypeChanged != null)
			{
				TypeChanged(this, e);
			}
		}

		public object Clone()
		{
			MemoryStream buffer = new MemoryStream();
			XmlSerializer ser = new XmlSerializer (typeof(TypeInfo));
			ser.Serialize(buffer, this);
			buffer.Position = 0;
			TypeInfo result = (TypeInfo)ser.Deserialize(buffer);
			result._parent = _parent;
			return result;
		}
	}
}
