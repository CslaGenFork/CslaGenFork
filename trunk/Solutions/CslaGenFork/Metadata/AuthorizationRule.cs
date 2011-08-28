using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for AuthorizationRule for Rules 4
    /// </summary>
    [Serializable]
    [DefaultProperty("AssemblyFile")]
    public class AuthorizationRule : ICloneable, IBusinessRule
    {
        #region Private Fields

        private string _name = String.Empty;
        private string _objectName = String.Empty;
        private string _assemblyFile = String.Empty;
        private string _type = String.Empty;
        private string _parent;
        private List<string> _baseRuleProperties = new List<string>();
        private BusinessRuleConstructorCollection _constructors = new BusinessRuleConstructorCollection();
        private BusinessRulePropertyCollection _ruleProperties = new BusinessRulePropertyCollection();
        private AuthorizationActions _actionProperty;
        private bool _cacheResult;

        #endregion

        [Browsable(false)]
        [XmlIgnore]
        public string Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        [Browsable(false)]
        [XmlIgnore]
        public AuthorizationActions ActionProperty
        {
            get { return _actionProperty; }
            set { _actionProperty = value; }
        }

        [Browsable(false)]
        public List<string> BaseRuleProperties
        {
            get { return _baseRuleProperties; }
            set { _baseRuleProperties = value; }
        }

        #region 01. Definition

        [Category("01. Definition")]
        [Description("This is used for usability purposes only.")]
        [UserFriendlyName("Authorization Rule Name")]
        public string Name
        {
            get
            {
                if (_name == string.Empty)
                {
                    if (_type != string.Empty)
                        _name = _type.Substring(_type.LastIndexOf('.') + 1);
                    if (_objectName != string.Empty)
                    {
                        var _full = _objectName.LastIndexOf('.') > -1;
                        if (_full)
                            _name = _objectName.Substring(_objectName.LastIndexOf('.') + 1);
                        else
                            _name = _objectName;
                    }
                }
                return _name;
            }
            set { _name = PropertyHelper.TidyAllowSpaces(value); }
        }

        [Category("01. Definition")]
        [Description("Authorization Rule Type defined in this CslaGenFork project. Unsupported at this time.")]
        [UserFriendlyName("Internal project Type Name")]
        [Browsable(true)]
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
                if (_name == String.Empty)
                {
                    var _full = _objectName.LastIndexOf('.') > -1;
                    if (_full)
                        _name = _objectName.Substring(_objectName.LastIndexOf('.') + 1);
                    else
                        _name = _objectName;
                }
                OnTypeChanged(EventArgs.Empty);
            }
        }

        [Category("01. Definition")]
        [Description("The assembly file full path.")]
        [Editor(typeof (AssemblyFileNameEditor), typeof (UITypeEditor))]
        [UserFriendlyName("Assembly File Name")]
        public string AssemblyFile
        {
            get { return _assemblyFile; }
            set
            {
                _assemblyFile = value;
                if (string.IsNullOrEmpty(_assemblyFile))
                {
                    Type = String.Empty;
                    BaseRuleProperties = new List<string>();
                    RuleProperties = new BusinessRulePropertyCollection();
                    Constructors = new BusinessRuleConstructorCollection();
                }
            }
        }

        [Category("01. Definition")]
        [Editor(typeof(AuthorizationRuleTypeEditor), typeof(UITypeEditor))]
        [Description("Authorization Rule Type defined in Assembly. Abstract classes are excluded from the list.")]
        [UserFriendlyName("Rule Type Name")]
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
                    if (_name == String.Empty)
                    {
                        _name = _type.Substring(_type.LastIndexOf('.') + 1);
                    }
                    OnTypeChanged(EventArgs.Empty);
                }
            }
        }

        #endregion

        #region 02. Authorization Rule Constructors

        [Category("02. Authorization Rule Constructors")]
        [Description("The constructors for the Authorization Rule.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Authorization Rule Constructors")]
        public BusinessRuleConstructorCollection Constructors
        {
            get { return _constructors; }
            set { _constructors = value; }
        }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public BusinessRuleConstructor Constructor0 { get; set; }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public BusinessRuleConstructor Constructor1 { get; set; }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public BusinessRuleConstructor Constructor2 { get; set; }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public BusinessRuleConstructor Constructor3 { get; set; }

        [XmlIgnore]
        [ReadOnly(true)]
        [Browsable(false)]
        public BusinessRuleConstructor Constructor4 { get; set; }

        #endregion

        #region 03. Authorization Rule Options

        public BusinessRulePropertyCollection RuleProperties
        {
            get { return _ruleProperties; }
            set { _ruleProperties = value; }
        }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty0 { get; set; }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty1 { get; set; }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty2 { get; set; }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty3 { get; set; }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty4 { get; set; }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty5 { get; set; }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty6 { get; set; }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty7 { get; set; }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty8 { get; set; }

        [XmlIgnore]
        public BusinessRuleProperty RuleProperty9 { get; set; }

        #endregion

        #region 04. Base Authorization Rule Options

        [Category("04. Base Authorization Rule Options")]
        [Description("The element (property or object Type) affected by this rule.")]
        [UserFriendlyName("Element Name")]
        [ReadOnly(true)]
        public string Element
        {
            get
            {
                if (!string.IsNullOrEmpty(_parent))
                    return _parent;

                return string.Empty;
            }
        }

        [Category("04. Base Authorization Rule Options")]
        [Description("Whether the results of this rule can be cached at the business object level.")]
        [UserFriendlyName("Cache Result")]
        [ReadOnly(true)]
        public bool CacheResult
        {
            get { return _cacheResult; }
            set { _cacheResult = value; }
        }

        [Category("04. Base Authorization Rule Options")]
        [Description("The authorization action this rule will enforce.")]
        [UserFriendlyName("Action")]
        [ReadOnly(true)]
        public string Action
        {
            get
            {
                if (!string.IsNullOrEmpty(_actionProperty.ToString()))
                    return _actionProperty.ToString();

                return string.Empty;
            }
        }

        #endregion

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

        [field: NonSerialized]
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
            var ser = new XmlSerializer(typeof(AuthorizationRule));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            var result = (AuthorizationRule)ser.Deserialize(buffer);
            return result;
        }
    }
}
