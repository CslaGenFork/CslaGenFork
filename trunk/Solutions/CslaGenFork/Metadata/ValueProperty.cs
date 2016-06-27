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
    public class PropertyNameChangedEventArgs : EventArgs
    {
        public string OldName;
        public string NewName;

        public PropertyNameChangedEventArgs(string oldName, string newName)
        {
            OldName = oldName;
            NewName = newName;
        }
    }

    public delegate void PropertyNameChanged(ValueProperty sender, PropertyNameChangedEventArgs e);

    /// <summary>
    /// Summary description for ValueProperty.
    /// </summary>
    [Serializable]
    public class ValueProperty : Property, IBoundProperty, IHaveBusinessRules
    {
        [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
        public enum DataAccessBehaviour
        {
            ReadWrite,
            ReadOnly,
            WriteOnly,
            UpdateOnly,
            CreateOnly
        }

        [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
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
                case "Read Authorization Type":
                    result = AuthorizationActions.ReadProperty;
                    break;
                case "Write Authorization Type":
                    result = AuthorizationActions.WriteProperty;
                    break;
                case "Create Authorization Type":
                    result = AuthorizationActions.CreateObject;
                    break;
                case "Get Authorization Type":
                    result = AuthorizationActions.GetObject;
                    break;
                case "Update Authorization Type":
                    result = AuthorizationActions.EditObject;
                    break;
                //case "Delete Authorization Type":
                default:
                    result = AuthorizationActions.DeleteObject;
                    break;
            }
            return result;
        }

        #region Private Fields

        private DbBindColumn _dbBindColumn = new DbBindColumn();
        private string _fkConstraint = String.Empty;
        private bool _undoable = true;
        private string _defaultValue = string.Empty;
        private string _friendlyName = string.Empty;
        private PropertyDeclaration _declarationMode;
        private BusinessRuleCollection _businessRules;
        private string _interfaces = string.Empty;
        private string[] _attributes = new string[] { };
        private AuthorizationProvider _authzProvider;
        private AuthorizationRuleCollection _authzRules;
        private string _readRoles = string.Empty;
        private string _writeRoles = string.Empty;
        private PropertyAccess _access = PropertyAccess.IsPublic;
        private DataAccessBehaviour _dataAccess = DataAccessBehaviour.ReadWrite;
        private UserDefinedKeyBehaviour _primaryKey = UserDefinedKeyBehaviour.Default;
        private AccessorVisibility _propSetAccessibility = AccessorVisibility.Default;
        private TypeCodeEx _backingFieldType = TypeCodeEx.Empty;
        private bool _nullable;

        #endregion

        public ValueProperty()
        {
            var selectedItem = GeneratorController.Current.GetSelectedItem();
            if (selectedItem != null)
            {
                if (((CslaObjectInfo) selectedItem).IsReadOnlyObject())
                {
                    ReadOnly = true;
                }
            }

            _businessRules = new BusinessRuleCollection();
            NameChanged += _businessRules.OnParentChanged;
            _authzRules = new AuthorizationRuleCollection();
            _authzRules.Add(new AuthorizationRule());
            _authzRules.Add(new AuthorizationRule());
            NameChanged += _authzRules.OnParentChanged;
        }

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
            "\r\n\tCreateOnly=CRx (can't update)")]
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
        [Description("Explicitly add the foreign key constraint for this column (shows on INNER JOIN declarations).")]
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
            set { _parameterName = value; }
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
        [Description("The property data Type. Select \"CustomType\" to disable database interaction.")]
        [UserFriendlyName("Property Type")]
        public override TypeCodeEx PropertyType
        {
            get { return base.PropertyType; }
            set { base.PropertyType = value; }
        }

        /*[Category("01. Definition")]
        [Description("Use a standard Type or a Type that is neither native nor defined on CSLA.NET.")]
        [UserFriendlyName("Custom Property Type")]
        public override string CustomPropertyType
        {
            get { return base.CustomPropertyType; }
            set { base.CustomPropertyType = value; }
        }*/

        [Category("01. Definition")]
        [Description("Property Declaration Mode.")]
        [UserFriendlyName("Declaration Mode")]
        public virtual PropertyDeclaration DeclarationMode
        {
            get { return _declarationMode; }
            set { _declarationMode = value; }
        }

        [Category("01. Definition")]
        [Description("Type of Backing Field of the Property. Set to \"Empty\" for no backing field.")]
        [UserFriendlyName("Backing Field Type")]
        public virtual TypeCodeEx BackingFieldType
        {
            get
            {
                if (DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion ||
                    DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                    DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion)
                    return _backingFieldType;

                return TypeCodeEx.Empty;
            }
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
        [Description("Whether this property can have a null value. The following types can't be null: \"ByteArray \", \"DBNull \", \"Object\" and \"Empty\".")]
        public override bool Nullable
        {
            get
            {
                if (BackingFieldType == TypeCodeEx.Empty &&
                    base.PropertyType.IsNullAllowedOnType())
                    return _nullable;

                if (_backingFieldType.IsNullAllowedOnType())
                    return _nullable;

                return false;
            }
            set { _nullable = value; }
        }

        [Category("01. Definition")]
        [Description("Value that is set when the object is created.")]
        [UserFriendlyName("Default Value")]
        public virtual string DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = PropertyHelper.TidyAllowSpaces(value); }
        }

        #endregion

        #region 02. Advanced

        [Category("02. Advanced")]
        [Description("The attributes you want to add to this property.")]
        public virtual string[] Attributes
        {
            get { return _attributes; }
            set { _attributes = PropertyHelper.TidyAllowSpaces(value); }
        }

        [Category("02. Advanced")]
        [Description("The interface this property explicitly implements.")]
        public virtual string Interfaces
        {
            get { return _interfaces; }
            set
            {
                value = PropertyHelper.Tidy(value);
                if (!string.IsNullOrEmpty(value))
                {
                    var namePostfix = '.' + Name;
                    if (value.LastIndexOf(namePostfix) != value.Length - namePostfix.Length)
                    {
                        if (GeneratorController.Current.CurrentUnit != null)
                        {
                            if (GeneratorController.Current.CurrentUnit.GenerationParams.OutputLanguage ==
                                CodeLanguage.CSharp ||
                                _interfaces == string.Empty)
                                value = value + namePostfix;
                        }
                    }
                }
                _interfaces = value;
            }
        }

        #endregion

        #region 03. Business Rules & Authorization

        [Category("03. Business Rules & Authorization")]
        [Description("Collection of business rules (transformation, validation, etc).")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Business Rules Collection")]
        public virtual BusinessRuleCollection BusinessRules
        {
            get { return _businessRules; }
        }

        [Category("03. Business Rules & Authorization")]
        [Description("The Authorization Provider for this property.")]
        [UserFriendlyName("Authorization Provider")]
        public virtual AuthorizationProvider AuthzProvider
        {
            get { return _authzProvider; }
            set { _authzProvider = value; }
        }

        [Category("03. Business Rules & Authorization")]
        [Description("Roles allowed to read the property. Use a comma to separate multiple roles.")]
        [UserFriendlyName("Read Roles")]
        public virtual string ReadRoles
        {
            get { return _readRoles; }
            set { _readRoles = PropertyHelper.TidyAllowSpaces(value).Replace(';', ',').Trim(new[] { ',' }); }
        }

        [Category("03. Business Rules & Authorization")]
        [Description("Roles allowed to write to the property. Use a comma to separate multiple roles.")]
        [UserFriendlyName("Write Roles")]
        public virtual string WriteRoles
        {
            get { return _writeRoles; }
            set { _writeRoles = PropertyHelper.TidyAllowSpaces(value).Replace(';', ',').Trim(new[] { ',' }); }
        }

        [Category("03. Business Rules & Authorization")]
        [Description("The Authorization Type that controls read action. You can either select an object defined in the current project or an object defined in another assembly.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(AuthorizationRuleTypeConverter))]
        [UserFriendlyName("Read Authorization Type")]
        public virtual AuthorizationRule ReadAuthzRuleType
        {
            get { return _authzRules[0]; }
            set
            {
                if (!ReferenceEquals(value, _authzRules[0]))
                {
                    if (_authzRules[0] != null)
                    {
                        _authzRules[0] = value;
                        _authzRules[0].Parent = Name;
                    }
                }
            }
        }

        [Category("03. Business Rules & Authorization")]
        [Description("The Authorization Type that controls write action. You can either select an object defined in the current project or an object defined in another assembly.")]
        [Editor(typeof(ObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(AuthorizationRuleTypeConverter))]
        [UserFriendlyName("Write Authorization Type")]
        public virtual AuthorizationRule WriteAuthzRuleType
        {
            get { return _authzRules[1]; }
            set
            {
                if (!ReferenceEquals(value, _authzRules[1]))
                {
                    if (_authzRules[1] != null)
                    {
                        _authzRules[1] = value;
                        _authzRules[1].Parent = Name;
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

        #endregion

        #endregion

        [field: NonSerialized]
        public event PropertyNameChanged NameChanged;

        public override object Clone()
        {
            using (var buffer = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(ValueProperty));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                return ser.Deserialize(buffer);
            }
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