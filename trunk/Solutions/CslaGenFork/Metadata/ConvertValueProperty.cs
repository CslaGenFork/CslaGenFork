using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for ConvertValueProperty.
    /// </summary>
    [Serializable]
    public class ConvertValueProperty : ValueProperty
    {
        private string _baseName = String.Empty;
        private string _sourcePropertyName = String.Empty;
        private string _nvlConverter = string.Empty;
        private DataAccessBehaviour _dataAccess = DataAccessBehaviour.ReadWrite;
        private UserDefinedKeyBehaviour _primaryKey = UserDefinedKeyBehaviour.Default;

        // Hide DataAccess
        [Browsable(false)]
        public override DataAccessBehaviour DataAccess
        {
            get { return _dataAccess; }
            set { _dataAccess = value; }
        }

        // Hide PrimaryKey
        [Browsable(false)]
        public override UserDefinedKeyBehaviour PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }

        // Hide Rules
        [Browsable(false)]
        public override RuleCollection Rules
        {
            get { return null; }
        }

        // Hide DbBindColumn
        [Browsable(false)]
        public override DbBindColumn DbBindColumn
        {
            get { return null; }
        }

        // Hide FKConstraint
        [Browsable(false)]
        public override string FKConstraint
        {
            get { return string.Empty; }
        }

        [Category("00. Auto Fill Helper")]
        [Description("The property Base Name used by automatic filling.")]
        [UserFriendlyName("Base Name")]
        public string BaseName
        {
            get { return _baseName; }
            set
            {
                value = PropertyHelper.Tidy(value);
                _baseName = value;

                if (value != null && (base.Name.Equals(_baseName + "Name") || string.IsNullOrEmpty(base.Name)))
                    base.Name = value + "Name";
                if (value != null && GeneratorController.Current.CurrentUnit != null && string.IsNullOrEmpty(_sourcePropertyName))
                    _sourcePropertyName = CheckSourceProperty(_baseName + "ID");
                if (value != null && GeneratorController.Current.CurrentUnit != null && string.IsNullOrEmpty(_nvlConverter))
                    _nvlConverter = CheckNVLConverter(_baseName + "NVL.Get" + _baseName + "NVL");
            }

        }

        [Category("01. Definition")]
        [Description("The property that results from a conversion.\r\nAutomatic filling uses the Base Name.")]
        public override string Name
        {
            get { return base.Name; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (value != base.Name)
                    base.Name = value; 
            }
        }

        // Hide ParameterName
        [Browsable(false)]
        public override string ParameterName
        {
            get { return string.Empty; }
        }

        // Hide Implements
        [Browsable(false)]
        public override string Implements
        {
            get { return string.Empty; }
        }

        // Hide DefaultValue
        [Browsable(false)]
        public override string DefaultValue
        {
            get { return string.Empty; }
        }

        // Hide AllowReadRoles
        [Browsable(false)]
        public override string AllowReadRoles
        {
            get { return string.Empty; }
        }

        // Hide AllowWriteRoles
        [Browsable(false)]
        public override string AllowWriteRoles
        {
            get { return string.Empty; }
        }

        // Hide DenyReadRoles
        [Browsable(false)]
        public override string DenyReadRoles
        {
            get { return string.Empty; }
        }

        // Hide DenyWriteRoles
        [Browsable(false)]
        public override string DenyWriteRoles
        {
            get { return string.Empty; }
        }

        [Category("06. Conversion")]
        [Editor(typeof(SourcePropertyTypeEditor), typeof(UITypeEditor))]
        [Description("The property that feeds the conversion (convert from).\r\nAutomatic filling uses the Base Name.")]
        [UserFriendlyName("Source Property Type")]
        public string SourcePropertyName
        {
            get { return _sourcePropertyName; }
            set
            {
                _sourcePropertyName = value;
            }
        }

        [Category("06. Conversion")]
        [Editor(typeof(NVLTypeEditor), typeof(UITypeEditor))]
        [Description("The NVL class that takes care of the conversion.\r\nAutomatic filling uses the Base Name.")]
        [UserFriendlyName("NVL Converter Class")]
        public string NVLConverter
        {
            get { return _nvlConverter; }
            set { _nvlConverter = value; }
        }

        private string CheckSourceProperty(string candidate)
        {
            var empty = string.Empty;
            var props = ((CslaObjectInfo)GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem).GetAllValueProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType == TypeCodeEx.Int16 || prop.PropertyType == TypeCodeEx.Int32 || prop.PropertyType == TypeCodeEx.Int64 ||
                    prop.PropertyType == TypeCodeEx.UInt16 || prop.PropertyType == TypeCodeEx.UInt32 || prop.PropertyType == TypeCodeEx.UInt64 ||
                    prop.PropertyType == TypeCodeEx.SByte)
                {
                    if (prop.Name == candidate)
                    {
                        base.PropertyType =TypeCodeEx.String;
                        base.ReadOnly = prop.ReadOnly;
                        return candidate;
                    }
                }
            }
            return empty;
        }

        private string CheckNVLConverter(string candidate)
        {
            var empty = string.Empty;
            foreach (var o in GeneratorController.Current.CurrentUnit.CslaObjects)
            {
                if (o.ObjectType == CslaObjectType.NameValueList)
                {
                    var prefix = string.Empty;
                    var objectNamespace = ((CslaObjectInfo)GeneratorController.Current.MainForm.ProjectPanel.ListObjects.SelectedItem).ObjectNamespace;
                    if (objectNamespace != o.ObjectNamespace)
                    {
                        var idx = objectNamespace.IndexOf(o.ObjectNamespace);
                        if (idx == 0)
                        {
                            prefix = objectNamespace.Substring(o.ObjectNamespace.Length + 1) + ".";
                        }
                        else if (idx == -1)
                        {
                            idx = o.ObjectNamespace.IndexOf(objectNamespace);
                            if (idx == 0)
                                prefix = o.ObjectNamespace.Substring(objectNamespace.Length + 1) + ".";
                        }
                        else
                        {
                            prefix = o.ObjectNamespace + ".";
                        }
                    }
                    if (prefix + o.ObjectName + ".Get" + o.ObjectName == candidate)
                        return candidate;
                }
            }
            return empty;
        }

        public override object Clone()
        {
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof(ConvertValueProperty));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            return ser.Deserialize(buffer);
        }

    }
}
