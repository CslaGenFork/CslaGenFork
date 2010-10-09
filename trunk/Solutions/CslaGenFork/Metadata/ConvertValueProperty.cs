using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

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
        [Description("This is a description.")]
        public string BaseName
        {
            get { return _baseName; }
            set
            {
                if (value != null && (base.Name.Equals(_baseName + "Name") || string.IsNullOrEmpty(base.Name)))
                    base.Name = value + "Name";

                _baseName = value;
            }

        }

        [Category("06. Conversion")]
        [Description("This is a description.")]
        public string SourcePropertyName
        {
            get
            {
                if (string.IsNullOrEmpty(_sourcePropertyName) && !string.IsNullOrEmpty(_baseName))
                    return _baseName + "ID";
                return _sourcePropertyName;
            }
            set
            {
                if (value != null && !value.Equals(_baseName + "ID"))
                    _sourcePropertyName = value;
                else
                    _sourcePropertyName = string.Empty;
            }
        }

        [Category("06. Conversion")]
        [Description("This is a description.")]
        public string NVLConverter
        {
            get
            {
                if (string.IsNullOrEmpty(_nvlConverter) && !string.IsNullOrEmpty(_baseName))
                    return _baseName + "NVL.Get"+_baseName+"NVL()";
                return _nvlConverter;
            }
            set
            {
                if (value != null && !value.Equals(_baseName + "NVL.Get" + _baseName + "NVL()"))
                    _nvlConverter = value;
                else
                    _nvlConverter = string.Empty;
            }
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
