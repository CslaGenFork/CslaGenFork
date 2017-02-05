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
        #region Private Fields

        private string _assemblyFile = string.Empty;
        private string _type = string.Empty;
        private string _objectName = string.Empty;
        private bool _isInheritedType;
        private bool _isInheritedTypeWinForms;

        #endregion

        #region UI Properties

        [Category("01. Type Defined in Project")]
        [Editor(typeof(CslaObjectInfoEditor), typeof(UITypeEditor))]
        [Description("Selected Type Name. Interface classes are excluded from the list.\r\n" +
                     "Shows only generic classes with a matching number of generic arguments.")]
        [UserFriendlyName("Project Type Name")]
        public string ObjectName
        {
            get { return _objectName; }
            set
            {
                _objectName = value;
                if (value != string.Empty)
                {
                    _type = string.Empty;
                }
                OnTypeChanged(EventArgs.Empty);
            }
        }

        [Category("02. Type Defined in Assembly")]
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
                    Type = string.Empty;
            }
        }

        [Category("02. Type Defined in Assembly")]
        [Editor(typeof(RefTypeEditor), typeof(UITypeEditor))]
        [Description("Selected Type Name. Interface classes are excluded from the list.\r\n" +
                     "Shows only generic classes with a matching number of generic arguments.")]
        [UserFriendlyName("Assembly Type Name")]
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    if (_type != string.Empty)
                    {
                        _objectName = string.Empty;
                    }
                    OnTypeChanged(EventArgs.Empty);
                }
            }
        }

        [ReadOnly(true)]
        [Description("Whether this Type is generic.")]
        [UserFriendlyName("Generic Type")]
        public bool IsGenericType { get; set; }

        #endregion

        #region Hidden properties

        [Browsable(false)]
        internal bool IsInheritedType
        {
            get { return _isInheritedType; }
            set { _isInheritedType = value; }
        }

        [Browsable(false)]
        internal bool IsInheritedTypeWinForms
        {
            get { return _isInheritedTypeWinForms; }
            set { _isInheritedTypeWinForms = value; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public CslaObjectInfo ObjectMetadata
        {
            get
            {
                if (_objectName == string.Empty)
                {
                    return null;
                }
                return GeneratorController.Current.CurrentUnit.CslaObjects.FindByGenericName(_objectName);
            }
        }

        [XmlIgnore]
        [Browsable(false)]
        public string FinalName
        {
            get
            {
                if (_objectName == string.Empty)
                    return _type;

                return _objectName;
            }
        }

        [XmlIgnore]
        [Browsable(false)]
        public string FirstParameter
        {
            get
            {
                var parameters = GetParameters();
                return parameters.Length > 0 ? parameters[0].Trim() : string.Empty;
            }
        }

        [XmlIgnore]
        [Browsable(false)]
        public string SecondParameter
        {
            get
            {
                var parameters = GetParameters();
                return parameters.Length > 1 ? parameters[1].Trim() : string.Empty;
            }
        }

        public string[] GetParameters()
        {
            var result = string.Empty;

            if (IsGenericType)
            {
                var finalName = FinalName;
                var start = finalName.IndexOf("<", StringComparison.InvariantCulture);
                var end = finalName.IndexOf(">", StringComparison.InvariantCulture);
                if (start > -1 && end > -1)
                    result = finalName.Substring(start + 1, end - start - 1);
            }

            if (result == string.Empty)
                return new string[0];

            return result.Split(',');
        }

        #endregion

        // Not used. Keep as it might be useful
        public Type GetInheritedType()
        {
            if (!string.IsNullOrEmpty(_assemblyFile))
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
            result.IsInheritedType = IsInheritedType;
            result.IsInheritedTypeWinForms = IsInheritedTypeWinForms;

            return result;
        }
    }
}