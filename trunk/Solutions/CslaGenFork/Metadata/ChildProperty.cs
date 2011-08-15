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
    /// Summary description for ChildProperty.
    /// </summary>
    [Serializable]
    public class ChildProperty : Property, IHaveBusinessRules
    {

        #region Private Fields

        private string _friendlyName = String.Empty;
        private LoadingScheme _loadingScheme = LoadingScheme.ParentLoad;
        private PropertyDeclaration _declarationMode;
        private string _implements = string.Empty;
        private BusinessRuleCollection _businessRules = new BusinessRuleCollection(); 
        private string[] _attributes = new string[] { };
        private AuthorizationProvider _authzProvider;
        private AuthorizationRule _readAuthzRuleType = new AuthorizationRule();
        private AuthorizationRule _writeAuthzRuleType = new AuthorizationRule();
        private string _readRoles = string.Empty;
        private string _writeRoles = string.Empty;
        private bool _lazyLoad;
        private string _typeName = String.Empty;
        private bool _undoable = true;
        private ParameterCollection _loadParameters = new ParameterCollection();
        private PropertyAccess _access = PropertyAccess.IsPublic;

        #endregion

        #region 01. Definition

        [Category("01. Definition")]
        [Description("The property name.")]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = PropertyHelper.Tidy(value); }
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
                if(LoadingScheme == LoadingScheme.SelfLoad && LazyLoad)
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

        [Category("01. Definition")]
        [Description("Whether this property can have a null value. This is ignored for child collections.\r\n" +
            "The following types aren't nullable: \"ByteArray \", \"SmartDate \", \"DBNull \", \"Object\" and \"Empty\".")]
        public override bool Nullable
        {
            get { return base.Nullable; }
            set { base.Nullable = value; }
        }

        #endregion

        #region 02. Advanced

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
        [Description("The Loading Scheme for the child." +
        "If set to ParentLoad then the child will be populated by the parent class.\r\n" +
        "If set to SelfLoad the child will load its own data.\r\n" +
        "If set to None then the child will not be populated with data at all (unsupported for CSLA40 targets).")]
        [UserFriendlyName("Loading Scheme")]
        public LoadingScheme LoadingScheme
        {
            get { return _loadingScheme; }
            set { _loadingScheme = value; }
        }

        [Category("05. Options")]
        [Description("Whether or not this object should be lazy loaded.\r\n" +
            "If set to True, loading of child data is defered until the child object is referenced.\r\n" +
            "If set to False, the child data is loaded when the parent is instantiated.")]
        [UserFriendlyName("Lazy Load")]
        public bool LazyLoad
        {
            get { return _lazyLoad; }
            set { _lazyLoad = value; }
        }

        [Category("05. Options")]
        [Editor(typeof(ParameterCollectionEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ParameterCollectionConverter))]
        [Description("The parent get criteria parameters that are used to load the child object.")]
        [UserFriendlyName("Load Parameters")]
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

        public override object Clone()
        {
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof(ChildProperty));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            return ser.Deserialize(buffer);
        }

    }
}
