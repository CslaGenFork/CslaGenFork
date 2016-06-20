using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    public delegate void ChildPropertyNameChanged(ChildProperty sender, PropertyNameChangedEventArgs e);

    /// <summary>
    /// Summary description for ChildProperty.
    /// </summary>
    [Serializable]
    public class ChildProperty : Property, IHaveBusinessRules, IComparable
    {

        #region Private Fields

        private string _friendlyName = String.Empty;
        private LoadingScheme _loadingScheme = LoadingScheme.ParentLoad;
        private PropertyDeclaration _declarationMode;
        private string _interfaces = string.Empty;
        private BusinessRuleCollection _businessRules;
        private string[] _attributes = new string[] { };
        private AuthorizationProvider _authzProvider;
        private AuthorizationRuleCollection _authzRules;
        private string _readRoles = string.Empty;
        private string _writeRoles = string.Empty;
        private bool _lazyLoad;
        private string _typeName = String.Empty;
        private bool _undoable = true;
        private PropertyCollection _parentLoadProperties = new PropertyCollection();
        private ParameterCollection _loadParameters = new ParameterCollection();
        private PropertyAccess _access = PropertyAccess.IsPublic;
        private int _childUpdateOrder = 0;

        #endregion

        public ChildProperty()
        {
            _businessRules = new BusinessRuleCollection(); 
            NameChanged += _businessRules.OnParentChanged;
            _authzRules = new AuthorizationRuleCollection();
            _authzRules.Add(new AuthorizationRule());
            _authzRules.Add(new AuthorizationRule());
            NameChanged += _authzRules.OnParentChanged;
        }

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
        [UserFriendlyName("Friendly Name")]
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
        [Description("This is a description.")]
        [Editor(typeof(ChildTypeEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Type Name")]
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        [Category("01. Definition")]
        [Description("Property Declaration Mode. For child collections this must be \"ClassicProperty\", \"AutoProperty\" or \"Managed\".\r\n"+
            "For lazy loaded child collections this must be \"ClassicProperty\" or \"Managed\".")]
        [UserFriendlyName("Declaration Mode")]
        public PropertyDeclaration DeclarationMode
        {
            get { return _declarationMode; }
            set
            {
                if (LoadingScheme == LoadingScheme.SelfLoad && LazyLoad)
                {
                    if (value == PropertyDeclaration.ClassicProperty ||
                        value == PropertyDeclaration.Managed)
                        _declarationMode = value;
                }
                else if (value == PropertyDeclaration.ClassicProperty ||
                         value == PropertyDeclaration.AutoProperty ||
                         value == PropertyDeclaration.Managed)
                    _declarationMode = value;
            }
        }

        [Category("01. Definition")]
        [Description("Whether this property can be changed by other classes.")]
        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set { base.ReadOnly = value; }
        }

        [Browsable(false)]
        [Category("01. Definition")]
        [Description("Whether this property can have a null value. This is ignored for child collections.\r\n" +
            "The following types can't be null: \"ByteArray \", \"DBNull \", \"Object\" and \"Empty\".")]
        public override bool Nullable
        {
            get { return base.Nullable; }
            set { base.Nullable = value; }
        }

        [Category("01. Definition")]
        [Description("Specify the order in which the child updates occur. Set to 0 on all chilren to ignore it.")]
        [UserFriendlyName("Child Update Order")]
        public int ChildUpdateOrder
        {
            get { return _childUpdateOrder; }
            set { _childUpdateOrder = value; }
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
            set { _writeRoles = PropertyHelper.TidyAllowSpaces(value).Replace(';', ',').Trim(new[] {','}); }
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
        [Description("The Loading Scheme for the child." +
        "If set to ParentLoad, data for both the parent and the child will be fetched at the same time. " +
        "If set to SelfLoad, the child will fetch its own data. " +
        "If set to None, the child will not be populated with data at all (unsupported for CSLA40 targets).")]
        [UserFriendlyName("Loading Scheme")]
        public LoadingScheme LoadingScheme
        {
            get { return _loadingScheme; }
            set { _loadingScheme = value; }
        }

        [Category("05. Options")]
        [Description("Whether or not this object should be lazy loaded.\r\n" +
            "If Loading Scheme is set to ParentLoad, Lazy Load is forced to False.\r\n" +
            "If set to True, loading of child data is defered until the child object is referenced.\r\n" +
            "If set to False, the child data is loaded when the parent is instantiated.")]
        [UserFriendlyName("Lazy Load")]
        public bool LazyLoad
        {
            get
            {
                if (_loadingScheme == LoadingScheme.SelfLoad)
                    return _lazyLoad;

                return false;
            }
            set { _lazyLoad = value; }
        }

        [Category("05. Options")]
        [Description("The parent properties that are used to load the child object.")]
        [Editor(typeof(PropertyCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(PropertyCollectionConverter))]
        [UserFriendlyName("Parent Properties")]
        public PropertyCollection ParentLoadProperties
        {
            get { return _parentLoadProperties; }
            set { _parentLoadProperties = value; }
        }

        [Category("05. Options")]
        [Editor(typeof(ParameterCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ParameterCollectionConverter))]
        [Description("The parent get criteria parameters that are used to load the child object.")]
        [UserFriendlyName("Parent Criteria Parameters")]
        public ParameterCollection LoadParameters
        {
            get { return _loadParameters; }
            set { _loadParameters = value; }
        }

        [Category("05. Options")]
        [Description("Accessibility for the property as a whole.\r\nDefaults to IsPublic.")]
        [UserFriendlyName("Property Accessibility")]
        public PropertyAccess Access
        {
            get { return _access; }
            set { _access = value; }
        }

        [Category("05. Options")]
        [Description("Setting to false will cause the n-level undo process to ignore that property's value.")]
        public bool Undoable
        {
            get { return _undoable; }
            set { _undoable = value; }
        }

        #endregion

        // Hide PropertyType
        [Browsable(false)]
        public override TypeCodeEx PropertyType
        {
            get { return TypeCodeEx.Empty; }
        }

        [field: NonSerialized]
        public event ChildPropertyNameChanged NameChanged;

        public override object Clone()
        {
            using (var buffer = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(ChildProperty));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                return ser.Deserialize(buffer);
            }
        }

        public int CompareTo(object other)
        {
            return ChildUpdateOrder.CompareTo(((ChildProperty) other).ChildUpdateOrder);
        }
    }
}
