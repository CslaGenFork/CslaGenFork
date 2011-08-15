using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    public class PropertyNameChangedEventArgs : EventArgs
    {
        public string OldName;
        public string NewName;

        public PropertyNameChangedEventArgs(string oName, string nName)
        {
            OldName = oName;
            NewName = nName;
        }
    }

    public delegate void PropertyNameChanged(ValueProperty sender, PropertyNameChangedEventArgs e);

    /// <summary>
    /// Summary description for ValueProperty.
    /// </summary>
    [Serializable]
    public class ValueProperty : Property, IBoundProperty, IHaveBusinessRules
    {
        public enum DataAccessBehaviour
        {
            ReadWrite,
            ReadOnly,
            WriteOnly,
            UpdateOnly,
            CreateOnly
        }

        public enum UserDefinedKeyBehaviour
        {
            Default,
            UserProvidedPK,
            DBProvidedPK
        }

        internal static AuthorizationActions Convert(string actionProperty)
        {
            AuthorizationActions result;
            switch (actionProperty)
            {
                case "Read Autorization Type":
                    result = AuthorizationActions.ReadProperty;
                    break;
                case "Write Autorization Type":
                    result = AuthorizationActions.WriteProperty;
                    break;
                case "Create Autorization Type":
                    result = AuthorizationActions.CreateObject;
                    break;
                case "Get Autorization Type":
                    result = AuthorizationActions.GetObject;
                    break;
                case "Update Autorization Type":
                    result = AuthorizationActions.EditObject;
                    break;
                //case "Delete Autorization Type":
                default:
                    result = AuthorizationActions.DeleteObject;
                    break;
            }
            return result;
        }

        #region Private Fields

        private DbBindColumn _dbBindColumn = new DbBindColumn();
        private string _fkConstraint = String.Empty;
        private bool _markDirtyOnChange = true;
        private bool _undoable = true;
        private string _defaultValue = string.Empty;
        private string _friendlyName = string.Empty;
        private PropertyDeclaration _declarationMode;
        private RuleCollection _rules = new RuleCollection();
        private BusinessRuleCollection _businessRules = new BusinessRuleCollection();
        private string _implements = string.Empty;
        private string[] _attributes = new string[] { };
        private AuthorizationProvider _authzProvider;
        private AuthorizationRule _readAuthzRuleType = new AuthorizationRule();
        private AuthorizationRule _writeAuthzRuleType = new AuthorizationRule();
        private string _readRoles = string.Empty;
        private string _writeRoles = string.Empty;
        private PropertyAccess _access = PropertyAccess.IsPublic;
        private DataAccessBehaviour _dataAccess = DataAccessBehaviour.ReadWrite;
        private UserDefinedKeyBehaviour _primaryKey = UserDefinedKeyBehaviour.Default;
        private AccessorVisibility _propSetAccessibility = AccessorVisibility.Default;
        private TypeCodeEx _backingFieldType = TypeCodeEx.Empty;

        #endregion

        #region Properties

        #region 00. Database

        [Category("00. Database")]
        [Editor(typeof(DbBindColumnEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(DbBindColumnConverter))]
        [Description("The database column this property is bound to.")]
        [UserFriendlyName("DB Bind Column")]
        public virtual DbBindColumn DbBindColumn
        {
            get { return _dbBindColumn; }
            set
            {
                _dbBindColumn = value;
                ResetProperties(value);
            }
        }

        [Category("00. Database")]
        [Description("When \"PrimaryKey\" is set to \"Default\", this controls the data flow of the property. Using the legend \"C=Create\", \"R=Read\", \"U=Update\" and \"x=no op\", the rules are as follows:" +
            "\r\n\tReadWrite=CRU (full access)" +
            "\r\n\tReadOnly=xRx (can't write)" +
            "\r\n\tWriteOnly=CxU (can't read)" +
            "\r\n\tUpdateOnly=xRU (can't create)" +
            "\r\n\tCreateOnly=CRx (can't update)" +
            "")]
        [UserFriendlyName("Data Access Behaviour")]
        public virtual DataAccessBehaviour DataAccess
        {
            get { return _dataAccess; }
            set { _dataAccess = value; }
        }

        [Category("00. Database")]
        [Description("The type of primary key or \"Default\" to none.")]
        [UserFriendlyName("Primary Key")]
        public virtual UserDefinedKeyBehaviour PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }

        [Category("00. Database")]
        [Description("Use this foreign key constraint to find the property value.")]
        [Editor(typeof(FKConstraintEditor), typeof(UITypeEditor))]
        [UserFriendlyName("FK Constraint")]
        public virtual string FKConstraint
        {
            get { return _fkConstraint; }
            set { _fkConstraint = value; }
        }

        [Category("00. Database")]
        [Description("The stored procedure parameter name.")]
        [UserFriendlyName("Parameter Name")]
        public override string ParameterName
        {
            get
            {
                if (_parameterName.Equals(String.Empty))
                {
                    if (!string.IsNullOrEmpty(DbBindColumn.ColumnName))
                        return DbBindColumn.ColumnName;

                    return Name;
                }
                return _parameterName;
            }
            set { _parameterName = PropertyHelper.Tidy(value); }
        }

        #endregion

        #region 01. Definition

        [Category("01. Definition")]
        [Description("The property name.")]
        public override string Name
        {
            get { return base.Name; }
            set
            {
                value = PropertyHelper.Tidy(value);
                var e = new PropertyNameChangedEventArgs(base.Name, value);
                base.Name = value;
                if (NameChanged != null)
                    NameChanged(this, e);
            }
        }

        [Category("01. Definition")]
        [Description("Human readable friendly display name of the property.")]
        [UserFriendlyName("Property Friendly Name")]
        public string FriendlyName
        {
            get
            {
                if (string.IsNullOrEmpty(_friendlyName))
                    return PropertyHelper.SplitOnCaps(base.Name);
                return _friendlyName;
            }
            set
            {
                if (value != null && !value.Equals(PropertyHelper.SplitOnCaps(base.Name)))
                    _friendlyName = value;
                else
                    _friendlyName = string.Empty;
            }
        }

        [Category("01. Definition")]
        [Description("The property data Type.")]
        [UserFriendlyName("Property Type")]
        public override TypeCodeEx PropertyType
        {
            get { return base.PropertyType; }
            set { base.PropertyType = value; }
        }

        [Category("01. Definition")]
        [Description("Property Declaration Mode.")]
        [UserFriendlyName("Declaration Mode")]
        public PropertyDeclaration DeclarationMode
        {
            get { return _declarationMode; }
            set { _declarationMode = value; }
        }

        [Category("01. Definition")]
        [Description("Type of Backing Field of the Property. Leave as \"Empty\" for no backing field.")]
        [UserFriendlyName("Backing Field Type")]
        public TypeCodeEx BackingFieldType
        {
            get { return _backingFieldType; }
            set { _backingFieldType = value; }
        }

        [Category("01. Definition")]
        [Description("Whether this property can be changed by other classes.")]
        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set { base.ReadOnly = value; }
        }

        [Category("01. Definition")]
        [Description("Whether this property can have a null value. The following types aren't nullable: \"ByteArray \", \"SmartDate \", \"DBNull \", \"Object\" and \"Empty\".")]
        public override bool Nullable
        {
            get { return base.Nullable; }
            set { base.Nullable = value; }
        }

        [Category("01. Definition")]
        [Description("Value that is set when the object is created..")]
        [UserFriendlyName("Default Value")]
        public virtual string DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = PropertyHelper.TidyAllowSpaces(value); }
        }

        #endregion

        #region 02. Advanced

        [Category("02. Advanced")]
        [Description("Collection of business rules.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Rule Collection")]
        public virtual RuleCollection Rules
        {
            get { return _rules; }
        }

        [Category("02. Advanced")]
        [Description("Collection of business rules (transformation, validation, etc).")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Business Rules Collection")]
        public virtual BusinessRuleCollection BusinessRules
        {
            get { return _businessRules; }
        }

        [Category("02. Advanced")]
        [Description("The attributes you want to add to this property.")]
        public virtual string[] Attributes
        {
            get { return _attributes; }
            set { _attributes = PropertyHelper.TidyAllowSpaces(value); }
        }

        [Category("02. Advanced")]
        [Description("This is a description.")]
        public virtual string Implements
        {
            get { return _implements; }
            set { _implements = PropertyHelper.Tidy(value); }
        }

        #endregion

        #region 03. Authorization

        [Category("03. Authorization")]
        [Description("The Autorization Provider for this property.")]
        [UserFriendlyName("Autorization Provider")]
        public virtual AuthorizationProvider AuthzProvider
        {
            get { return _authzProvider; }
            set { _authzProvider = value; }
        }

        [Category("03. Authorization")]
        [Description("Roles allowed to read the property. Multiple roles must be separated with ;")]
        [UserFriendlyName("Read Roles")]
        public virtual string ReadRoles
        {
            get { return _readRoles; }
            set { _readRoles = PropertyHelper.TidyAllowSpaces(value); }
        }

        [Category("03. Authorization")]
        [Description("Roles allowed to write to the property. Multiple roles must be separated with ;")]
        [UserFriendlyName("Write Roles")]
        public virtual string WriteRoles
        {
            get { return _writeRoles; }
            set { _writeRoles = PropertyHelper.TidyAllowSpaces(value); }
        }

        [Category("03. Authorization")]
        [Description("The Autorization Type that controls read action. You can either select an object defined in the current project or an object defined in another assembly.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(AuthorizationRuleTypeConverter))]
        [UserFriendlyName("Read Autorization Type")]
        public virtual AuthorizationRule ReadAuthzRuleType
        {
            get { return _readAuthzRuleType; }
            set
            {
                if (!ReferenceEquals(value, _readAuthzRuleType))
                {
                    if (_readAuthzRuleType != null)
                    {
                        _readAuthzRuleType = value;
                    }
                }
            }
        }

        [Category("03. Authorization")]
        [Description("The Autorization Type that controls write action. You can either select an object defined in the current project or an object defined in another assembly.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(AuthorizationRuleTypeConverter))]
        [UserFriendlyName("Write Autorization Type")]
        public virtual AuthorizationRule WriteAuthzRuleType
        {
            get { return _writeAuthzRuleType; }
            set
            {
                if (!ReferenceEquals(value, _writeAuthzRuleType))
                {
                    if (_writeAuthzRuleType != null)
                    {
                        _writeAuthzRuleType = value;
                    }
                }
            }
        }

        #endregion

        #region 05. Options

        [Category("05. Options")]
        [Description("Accessibility for the property as a whole.\r\nDefaults to IsPublic.")]
        [UserFriendlyName("Property Accessibility")]
        public PropertyAccess Access
        {
            get { return _access; }
            set { _access = value; }
        }

        [Category("05. Options")]
        [Description("Accessibility for property setter.\r\n" +
            "If \"ReadOnly\" is true, this settings is ignored.\r\n  - Auto properties have a private setter\r\n  - Classic, managed and unmanaged properties have no setter.\r\n" +
            "If \"ReadOnly\" is false, this setting applies. By default the setter has the same accessibility of the property.\r\n" +
            "Note -  \"NoSetter\" is deprecated and is converted to \"Default\".")]
        [UserFriendlyName("Setter Accessibility")]
        public AccessorVisibility PropSetAccessibility
        {
            get { return _propSetAccessibility; }
            set
            {
                if (value == AccessorVisibility.NoSetter)
                    value = AccessorVisibility.Default;
                _propSetAccessibility = value;
            }
        }

        [Category("05. Options")]
        [Description("Setting to false will cause the n-level undo process to ignore that property's value.")]
        public bool Undoable
        {
            get { return _undoable; }
            set { _undoable = value; }
        }

        [Category("05. Options")]
        [Description("This is a description.")]
        [UserFriendlyName("Mark Dirty On Change")]
        public bool MarkDirtyOnChange
        {
            get { return _markDirtyOnChange; }
            set { _markDirtyOnChange = value; }
        }

        #endregion

        #endregion

        [field: NonSerialized]
        public event PropertyNameChanged NameChanged;

        public override object Clone()
        {
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof(ValueProperty));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            return ser.Deserialize(buffer);
        }

        internal void RetrieveSummaryFromColumnDefinition()
        {
            if (DbBindColumn.Column != null)
            {
                var prop = DbBindColumn.Column.ColumnDescription;
                if (prop != null)
                    base.Summary = prop;
                else
                    base.Summary = string.Empty;
            }
        }

    }
}