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
    /// Summary description for BusinessRule for Rules 4
    /// </summary>
    [Serializable]
    [DefaultProperty("AssemblyFile")]
    public class BusinessRule : ICloneable, IBusinessRule
    {
        #region Private Fields

        private bool _isPropertyRule;
        private string _name = String.Empty;
        private int _numberGenericParameters = 0;
        private string _originalGenericParameter1 = String.Empty;
        private string _originalGenericParameter2 = String.Empty;
        private string _genericParameter1 = String.Empty;
        private string _genericParameter2 = String.Empty;
        private string _objectName = String.Empty;
        private string _assemblyFile = String.Empty;
        private string _type = String.Empty;
        private string _parent;
        private List<string> _baseRuleProperties = new List<string>();
        private BusinessRuleConstructorCollection _constructors = new BusinessRuleConstructorCollection();
        private BusinessRulePropertyCollection _ruleProperties = new BusinessRulePropertyCollection();
        private PropertyCollection _affectedProperties;
        private PropertyCollection _inputProperties;
        private bool _isAsync;
        private bool _provideTargetWhenAsync;
        private int _priority;
        private BusinessRuleRunModes _runModes = BusinessRuleRunModes.Default;
        private RuleSeverity _severity = RuleSeverity.Error;
        private bool _canRunAsAffectedProperty = true;
        private bool _canRunInCheckRules = true;
        private bool _canRunOnServer = true;
        private string _messageDelegate;
        private string _messageText;

        #endregion

        [Browsable(false)]
        [XmlIgnore]
        public string Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        [Browsable(false)]
        public List<string> BaseRuleProperties
        {
            get { return _baseRuleProperties; }
            set { _baseRuleProperties = value; }
        }

        [Browsable(false)]
        [XmlIgnore]
        public bool IsPropertyRule
        {
            get { return _isPropertyRule; }
            set { _isPropertyRule = value; }
        }

        #region 01. Definition

        [Category("01. Definition")]
        [Description("Business Rule Type defined in this CslaGenFork project. Unsupported at this time.")]
        [UserFriendlyName("Internal project Type Name")]
        [Browsable(false)]
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
        [Editor(typeof (AssemblyRulesFileNameEditor), typeof (UITypeEditor))]
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
        [Editor(typeof(BusinessRuleTypeEditor), typeof(UITypeEditor))]
        [Description("Business Rule Type defined in Assembly. Abstract classes are excluded from the list.")]
        [UserFriendlyName("Rule Type")]
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

        [Category("01. Definition")]
        [Description("This is used for usability purposes only.")]
        [UserFriendlyName("Business Rule Name")]
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

        [Browsable(false)]
        public int NumberGenericParameters
        {
            get { return _numberGenericParameters; }
            set { _numberGenericParameters = value; }
        }

        [Browsable(false)]
        public string OriginalGenericParameter1
        {
            get { return _originalGenericParameter1; }
            set { _originalGenericParameter1 = value; }
        }

        [Browsable(false)]
        public string OriginalGenericParameter2
        {
            get { return _originalGenericParameter2; }
            set { _originalGenericParameter2 = value; }
        }

        [Category("01. Definition")]
        [Description("First generic type parameter.")]
        [UserFriendlyName("Generic Type Parameter 1")]
        public string GenericParameter1
        {
            get { return _genericParameter1; }
            set { _genericParameter1 = value; }
        }

        [Category("01. Definition")]
        [Description("Second generic type parameter.")]
        [UserFriendlyName("Generic Type Parameter 2")]
        public string GenericParameter2
        {
            get { return _genericParameter2; }
            set { _genericParameter2 = value; }
        }

        #endregion

        #region 02. Business Rule Constructors

        [Category("02. Business Rule Constructors")]
        [Description("The constructors for the Business Rule.")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [UserFriendlyName("Business Rule Constructors")]
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

        #region 03. Business Rule Options

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

        #region 04. Base Business Rule Options

        [Category("04. Base Business Rule Options")]
        [Description("The primary property affected by this rule.")]
        [UserFriendlyName("Primary Property of the Rule")]
        [ReadOnly(true)]
        public string PrimaryProperty
        {
            get
            {
                if (!string.IsNullOrEmpty(_parent))
                    return _parent;

                return string.Empty;
            }
        }
        
        [Category("04. Base Business Rule Options")]
        [Description("The severity for this rule: Information, Warning or Error.")]
        [UserFriendlyName("Rule Severity")]
        public RuleSeverity Severity
        {
            get { return _severity; }
            set { _severity = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("The error message constant as a string.")]
        [UserFriendlyName("Message Text")]
        public string MessageText
        {
            get { return _messageText; }
            set { _messageText = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("The error message constant as a Func<string> type. Use this for localizable messages from a resource file.")]
        [UserFriendlyName("Message Delegate")]
        public string MessageDelegate
        {
            get { return _messageDelegate; }
            set { _messageDelegate = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("Whether this instance can run as affected property.")]
        [UserFriendlyName("Can Run as Affected Property")]
        public bool CanRunAsAffectedProperty
        {
            get { return _canRunAsAffectedProperty; }
            set { _canRunAsAffectedProperty = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("Whether this instance can run in logical Server side Data Portal.")]
        [UserFriendlyName("Can Run on Server")]
        public bool CanRunOnServer
        {
            get { return _canRunOnServer; }
            set { _canRunOnServer = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("Whether this instance can run when CheckRules is called on BO.")]
        [UserFriendlyName("Can Run in CheckRules")]
        public bool CanRunInCheckRules
        {
            get { return _canRunInCheckRules; }
            set { _canRunInCheckRules = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("The rule priority (0 executes before 1, etc).")]
        [UserFriendlyName("Rule Priority")]
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("How rule will run in context.")]
        [UserFriendlyName("Run Mode")]
        public BusinessRuleRunModes RunMode
        {
            get { return _runModes; }
            set { _runModes = value; }
        }

        #region Unknown status

        [Category("04. Base Business Rule Options")]
        [Editor(typeof(InputPropertyCollectionEditor), typeof(UITypeEditor))]
        [Description("List of properties affected by this rule."+
            " Rules for these properties are executed after rules for the primaryproperty.")]
        [TypeConverter(typeof(PropertyCollectionConverter))]
        [UserFriendlyName("Affected Properties Collection")]
        public PropertyCollection AffectedProperties 
        {
            get { return _affectedProperties; }
            set { _affectedProperties = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Editor(typeof(InputPropertyCollectionEditor), typeof(UITypeEditor))]
        [Description("List of secondary property values to be supplied to the rule when it is executed.")]
        [TypeConverter(typeof(PropertyCollectionConverter))]
        [UserFriendlyName("Input Properties Collection")]
        public PropertyCollection InputProperties
        {
            get { return _inputProperties; }
            set { _inputProperties = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("Whether the rule will run on a background thread.")]
        [UserFriendlyName("Is Business Rule Async")]
        public bool IsAsync 
        {
            get { return _isAsync; }
            set { _isAsync = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("Whether the Target property should be set even for an async rule" +
                     " (note that using Target from a background thread will cause major problems).")]
        [UserFriendlyName("Provide Target When Async")]
        public bool ProvideTargetWhenAsync
        {
            get { return _provideTargetWhenAsync; }
            set { _provideTargetWhenAsync = value; }
        }
        
        #endregion

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
            BusinessRule result;
            using (var buffer = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(BusinessRule));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                result = (BusinessRule) ser.Deserialize(buffer);
            }
            return result;
        }
    }
}
