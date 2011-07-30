using System;
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
    [DefaultProperty("Name")]
    public class BusinessRule : ICloneable
    {

        #region Private Fields

        private string _name = String.Empty;
        private string _assemblyFile = String.Empty;
        private string _type = String.Empty;
        private string _objectName = String.Empty;
        private BusinessRuleParameterCollection _constructorParameters = new BusinessRuleParameterCollection();
        private BusinessRulePropertyCollection _ruleProperties = new BusinessRulePropertyCollection();
        private PropertyCollection _inputProperties;
        private bool _isAsync;
        private int _priority;
        private bool _provideTargetWhenAsync;
        private string _ruleUri;
        private BusinessRuleRunModes _runModes;
        private string _parent;

        #endregion

        [Browsable(false)]
        [XmlIgnore]
        public string Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        #region 01. Definition

        [Category("01. Definition")]
        [Description("The business rule name is used for usability purposes only.")]
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

        [Category("01. Definition")]
        [Description("Business Rule Type Defined in Project.")]
        [UserFriendlyName("Internal project Type Name")]
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
        [Editor(typeof(AssemblyFileNameEditor), typeof(UITypeEditor))]
        [Description("The assembly file full path.")]
        [UserFriendlyName("Assembly File Name")]
        public string AssemblyFile
        {
            get { return _assemblyFile; }
            set { _assemblyFile = value; }
        }

        [Category("01. Definition")]
        [Editor(typeof (BusinessRuleTypeEditor), typeof (UITypeEditor))]
        [Description("Business Rule Type Defined in Assembly.")]
        [UserFriendlyName("Imported Rule Type Name")]
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

        #region 02. Business Rule Constructor Parameters

        [Category("02. Business Rule Constructor Parameters")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [Description("This Rule Constructor Parameters.")]
        [UserFriendlyName("Constructor Parameters")]
        public BusinessRuleParameterCollection ConstructorParameters
        {
            get { return _constructorParameters; }
            set { _constructorParameters = value; }
        }

        #endregion

        #region 03. Specific Business Rule Options

        [Category("03. Specific Business Rule Options")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [Description("The Specific Properties for this rule.")]
        public BusinessRulePropertyCollection RuleProperties
        {
            get { return _ruleProperties; }
            set { _ruleProperties = value; }
        }

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
                if(!string.IsNullOrEmpty(_parent))
                    return _parent;

                return string.Empty;
            }
        }
        
        [Category("04. Base Business Rule Options")]
        [Editor(typeof(InputPropertyCollectionEditor), typeof(UITypeEditor))]
        [Description("List of secondary property values to be supplied to the rule when it is executed.")]
        [TypeConverter(typeof(PropertyCollectionConverter))]
        [UserFriendlyName("Rule Input Properties Collection")]
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
        [Description("The rule priority (0 executes before 1, etc).")]
        [UserFriendlyName("Rule Priority")]
        public int Priority 
        {
            get { return _priority; }
            set { _priority = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("Whether the Target property should be set even for an async rule" +
                     "(note that using Target from a background thread will cause major problems).")]
        [UserFriendlyName("Provide Target When Async")]
        public bool ProvideTargetWhenAsync
        {
            get { return _provideTargetWhenAsync; }
            set { _provideTargetWhenAsync = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("The rule:// URI object for the rule.")]
        [UserFriendlyName("Rule URI")]
        public string RuleUri
        {
            get { return _ruleUri; }
            set { _ruleUri = value; }
        }

        [Category("04. Base Business Rule Options")]
        [Description("How rule will run in context")]
        [UserFriendlyName("Rule Run Mode")]
        public BusinessRuleRunModes RunMode 
        {
            get { return _runModes; }
            set { _runModes = value; }
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
            var ser = new XmlSerializer(typeof(ValueProperty));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            return ser.Deserialize(buffer);
        }
    }
}
