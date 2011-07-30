using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using CslaGenerator.Attributes;
using CslaGenerator.Design;
using System.Xml.Serialization;


namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for AuthzTypeInfo for Rules 4
    /// </summary>
    [Serializable]
    public class AuthzTypeInfo : ICloneable
    {
        private string _assemblyFile = String.Empty;
        private string _type = String.Empty;
        private string _objectName = String.Empty;

        public AuthzTypeInfo()
        {
        }

        [Category("01. Authorization Rule Type Defined in Project")]
        [Description("Authorization Rule Type Name.")]
        [UserFriendlyName("Internal project Type Name")]
        public string ObjectName
        {
            get { return _objectName; }
            set
            {
                _objectName = value;
                if (value != String.Empty)
                {
                    _assemblyFile = string.Empty;
                    _type = String.Empty;
                }
                OnTypeChanged(EventArgs.Empty);
            }
        }

        [Category("02. Authorization Rule in Assembly")]
        [Editor(typeof(AssemblyFileNameEditor), typeof(UITypeEditor))]
        [Description("The assembly file full path.")]
        [UserFriendlyName("Assembly File Name")]
        public string AssemblyFile
        {
            get { return _assemblyFile; }
            set { _assemblyFile = value; }
        }

        [Category("02. Authorization Rule in Assembly")]
        [Editor(typeof(AuthzTypeEditor), typeof(UITypeEditor))]
        [Description("Authorization Rule Type Name.")]
        [UserFriendlyName("Imported Type Name")]
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    if (_type != String.Empty)
                    {
                        _objectName = String.Empty;
                    }
                    OnTypeChanged(EventArgs.Empty);
                }
            }
        }

        public Type GetInheritedType()
        {
            if (_assemblyFile != null && _assemblyFile != String.Empty)
            {
                Assembly assembly = Assembly.LoadFrom(_assemblyFile);
                Type t = assembly.GetType(_type);
                if (t == null)
                {
                    throw new Exception("Type does not exist in Assembly");
                }
                return t;
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
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof(AuthzTypeInfo));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            var result = (AuthzTypeInfo)ser.Deserialize(buffer);
            return result;
        }
    }
}
