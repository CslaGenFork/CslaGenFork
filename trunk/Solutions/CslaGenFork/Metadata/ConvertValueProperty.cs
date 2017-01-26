using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Design;
using CslaGenerator.Util;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for ConvertValueProperty.
    /// </summary>
    [Serializable]
    public class ConvertValueProperty : ValueProperty
    {
        private string _baseName = string.Empty;
        private string _sourcePropertyName = string.Empty;
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

        // Hide IsDatabaseBound
        [Browsable(false)]
        public override bool IsDatabaseBound
        {
            get { return false; }
        }

        // Hide DeclarationMode
        [Browsable(false)]
        public override PropertyDeclaration DeclarationMode
        {
            get { return PropertyDeclaration.AutoProperty; }
        }

        // Hide BackingFieldType
        [Browsable(false)]
        public override TypeCodeEx BackingFieldType
        {
            get { return TypeCodeEx.Empty; }
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
        [Description("The property Base Name used by automatic filling for Name, Source Property Type and NVL Converter Class")]
        [UserFriendlyName("Base Name")]
        public string BaseName
        {
            get { return _baseName; }
            set
            {
                value = PropertyHelper.Tidy(value);
                _baseName = value;
                AutomaticFill(_baseName);
            }
        }

        [Category("01. Definition")]
        [Description("The property that results from a conversion.\r\n" +
                     "Automatic filling uses the Base Name and a Name suffix.")]
        public override string Name
        {
            get { return base.Name; }
            set
            {
                value = PropertyHelper.Tidy(value);
                base.Name = value;
            }
        }

        // Hide ParameterName
        [Browsable(false)]
        public override string ParameterName
        {
            get { return string.Empty; }
        }

        // Hide Interfaces
        [Browsable(false)]
        public override string Interfaces
        {
            get { return string.Empty; }
        }

        // Hide DefaultValue
        [Browsable(false)]
        public override string DefaultValue
        {
            get { return string.Empty; }
        }

        // Hide BusinessRules
        [Browsable(false)]
        public override BusinessRuleCollection BusinessRules
        {
            get { return new BusinessRuleCollection(); }
        }

        // Hide AuthzProvider
        [Browsable(false)]
        public override AuthorizationProvider AuthzProvider
        {
            get { return AuthorizationProvider.IsInRole; }
        }

        // Hide ReadRoles
        [Browsable(false)]
        public override string ReadRoles
        {
            get { return string.Empty; }
        }

        // Hide WriteRoles
        [Browsable(false)]
        public override string WriteRoles
        {
            get { return string.Empty; }
        }

        // Hide ReadAuthzRuleType
        [Browsable(false)]
        public override AuthorizationRule ReadAuthzRuleType
        {
            get { return null; }
        }

        // Hide WriteAuthzRuleType
        [Browsable(false)]
        public override AuthorizationRule WriteAuthzRuleType
        {
            get { return null; }
        }

        // Hide Undoable
        [Browsable(false)]
        public override bool Undoable
        {
            get { return base.Undoable; }
        }

        [Category("05. Options")]
        [Description("Accessibility for property setter.\r\n" +
                     "If \"ReadOnly\" is true, this settings is ignored.\r\n" +
                     "If \"ReadOnly\" is false, this setting applies. By default the setter has the same accessibility of the property.\r\n" +
                     "Note -  \"NoSetter\" is deprecated and is converted to \"Default\".")]
        [UserFriendlyName("Setter Accessibility")]
        public override AccessorVisibility PropSetAccessibility
        {
            get
            {
                if (ReadOnly)
                    return AccessorVisibility.Default;

                return base.PropSetAccessibility;
            }
            set { base.PropSetAccessibility = value; }
        }

        [Category("06. Conversion")]
        [Editor(typeof(SourcePropertyTypeEditor), typeof(UITypeEditor))]
        [Description("The property that feeds the conversion (convert from).\r\n" +
                     "Automatic match is case insensitive and uses the Base Name with ID suffix.")]
        [UserFriendlyName("Source Property Type")]
        public string SourcePropertyName
        {
            get { return _sourcePropertyName; }
            set { _sourcePropertyName = value; }
        }

        [Category("06. Conversion")]
        [Editor(typeof(NVLTypeEditor), typeof(UITypeEditor))]
        [Description(
            "The NVL class that takes care of the conversion.\r\n" +
            "Automatic match is case insensitive and uses the Base Name and one of {List, NameValueListNVL, NVL} as suffix.")]
        [UserFriendlyName("NVL Converter Class")]
        public string NVLConverter
        {
            get { return _nvlConverter; }
            set { _nvlConverter = value; }
        }

        private void AutomaticFill(string value)
        {
            if (value == null)
                return;

            // Name
            if ((base.Name.Equals(_baseName + "Name") ||
                 string.IsNullOrEmpty(base.Name) ||
                 base.Name == "Unnamed Property"))
                base.Name = value + "Name";

            if (GeneratorController.Current.CurrentCslaObject == null)
                return;

            // SourcePropertyName
            if (string.IsNullOrEmpty(_sourcePropertyName))
                _sourcePropertyName = CheckSourceProperty(_baseName + "ID");

            // NVLConverter
            if (string.IsNullOrEmpty(_nvlConverter))
                _nvlConverter = CheckNVLConverter(_baseName + "List.Get" + _baseName + "List");

            if (string.IsNullOrEmpty(_nvlConverter))
                _nvlConverter = CheckNVLConverter(_baseName + "NameValueList.Get" + _baseName + "NameValueList");

            if (string.IsNullOrEmpty(_nvlConverter))
                _nvlConverter = CheckNVLConverter(_baseName + "NVL.Get" + _baseName + "NVL");
        }

        private string CheckSourceProperty(string candidate)
        {
            var empty = string.Empty;

            var propertyCollection = GeneratorController.Current.CurrentCslaObject.GetAllValueProperties();
            foreach (var property in propertyCollection)
            {
                if (property.PropertyType == TypeCodeEx.Int16 ||
                    property.PropertyType == TypeCodeEx.Int32 ||
                    property.PropertyType == TypeCodeEx.Int64 ||
                    property.PropertyType == TypeCodeEx.UInt16 ||
                    property.PropertyType == TypeCodeEx.UInt32 ||
                    property.PropertyType == TypeCodeEx.UInt64 ||
                    property.PropertyType == TypeCodeEx.SByte)
                {
                    if (property.Name.ToUpper() == candidate.ToUpper())
                    {
                        PropertyType = TypeCodeEx.String;
                        ReadOnly = property.ReadOnly;
                        return property.Name;
                    }
                }
            }
            return empty;
        }

        private string CheckNVLConverter(string candidate)
        {
            var empty = string.Empty;
            foreach (var cslaObjectInfo in GeneratorController.Current.CurrentUnit.CslaObjects)
            {
                if (cslaObjectInfo.IsNameValueList())
                {
                    var prefix = string.Empty;
                    var objectNamespace =
                        ((CslaObjectInfo) GeneratorController.Current.GetSelectedItem()).ObjectNamespace;
                    if (objectNamespace != cslaObjectInfo.ObjectNamespace)
                    {
                        var idx = objectNamespace.IndexOf(cslaObjectInfo.ObjectNamespace,
                            StringComparison.InvariantCulture);
                        if (idx == 0)
                        {
                            prefix = objectNamespace.Substring(cslaObjectInfo.ObjectNamespace.Length + 1) + ".";
                        }
                        else if (idx == -1)
                        {
                            idx = cslaObjectInfo.ObjectNamespace.IndexOf(objectNamespace,
                                StringComparison.InvariantCulture);
                            if (idx == 0)
                                prefix = cslaObjectInfo.ObjectNamespace.Substring(objectNamespace.Length + 1) + ".";
                        }
                        else
                        {
                            prefix = cslaObjectInfo.ObjectNamespace + ".";
                        }
                    }
                    var composedName = prefix + cslaObjectInfo.ObjectName + ".Get" + cslaObjectInfo.ObjectName;
                    if (composedName.ToUpper() == candidate.ToUpper())
                        return composedName;
                }
            }
            return empty;
        }

        public override object Clone()
        {
            using (var buffer = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(ConvertValueProperty));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                return ser.Deserialize(buffer);
            }
        }
    }
}