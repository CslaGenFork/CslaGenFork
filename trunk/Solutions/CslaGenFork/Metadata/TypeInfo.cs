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
    /// Summary description for TypeInfo.
    /// </summary>
    [Serializable]
    public class TypeInfo : ICloneable
    {
        private string _assemblyFile = String.Empty;
        private string _type = String.Empty;
        private string _objectName = String.Empty;

        [Category("01. Inherit from Type Defined in Project")]
        [Editor(typeof(CslaObjectInfoEditor), typeof(UITypeEditor))]
        [Description("Inherited Type Name.")]
        [UserFriendlyName("Base Type Name")]
        public string ObjectName
        {
            get { return _objectName; }
            set
            {
                _objectName = value;
                if (value != String.Empty)
                {
                    _type = String.Empty;
                }
                OnTypeChanged(EventArgs.Empty);
            }
        }

        [Category("02. Inherit from Type in Assembly")]
        [Description("The assembly file full path")]
        [Editor(typeof(AssemblyObjectFileNameEditor), typeof(UITypeEditor))]
//        [TypeConverter(typeof(AssemblyFileConverter))]
        [UserFriendlyName("Assembly File Name")]
        public string AssemblyFile
        {
            get { return _assemblyFile; }
            set
            {
                _assemblyFile = value;
                if (string.IsNullOrEmpty(_assemblyFile))
                    Type = String.Empty;
            }
        }

        [Category("02. Inherit from Type in Assembly")]
        [Editor(typeof(RefTypeEditor), typeof(UITypeEditor))]
        [Description("Inherited Type Name. Interface classes are excluded from the list.")]
        [UserFriendlyName("Base Type Name")]
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

        [ReadOnly(true)]
        [Description("Whether this Type is generic.")]
        [UserFriendlyName("Generic Type")]
        public bool IsGenericType { get; set; }

        #region Non UI properties

        [XmlIgnore]
        [Browsable(false)]
        public CslaObjectInfo ObjectMetadata
        {
            get
            {
                if (_objectName == String.Empty)
                {
                    return null;
                }
                return GeneratorController.Current.CurrentUnit.CslaObjects.FindByGenericName(_objectName);
            }
        }

        #endregion

        // Not used. keep as it might be useful some day
        public Type GetInheritedType()
        {
            if (_assemblyFile != null && _assemblyFile != String.Empty)
            {
                var assembly = Assembly.LoadFrom(_assemblyFile);
                var t = assembly.GetType(_type);
                if (t == null)
                {
                    throw new ArgumentException("Type does not exist in Assembly.");
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
            TypeInfo result;
            using (var buffer = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(TypeInfo));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                result = (TypeInfo) ser.Deserialize(buffer);
            }

            return result;
        }
    }
}