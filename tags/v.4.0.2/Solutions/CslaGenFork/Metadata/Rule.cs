using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using CslaGenerator.Attributes;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for Rule.
    /// </summary>
    [Serializable]
    public class Rule
    {
        private string _name = String.Empty;
        private string _description = String.Empty;
        private RuleDescriptionType _descriptionType = RuleDescriptionType.String;
        private string _assertExpression = String.Empty;
        private RuleSeverity _severity = RuleSeverity.Error;
        private int _priority = 0;
        private ArgumentType _argumentType = ArgumentType.RuleArgs;
        private RuleMode _mode = RuleMode.Generated;
        private DecoratorArgumentCollection _decoratorArgs = new DecoratorArgumentCollection();

        [Category("01. Definition")]
        [Description("This is a description.")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        [UserFriendlyName("Description Type")]
        public RuleDescriptionType DescriptionType
        {
            get
            {
                return _descriptionType;
            }
            set
            {
                _descriptionType = value;
            }
        }

        [Category("01. Definition")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [Description("This is a description.")]
        [UserFriendlyName("Assert Expression")]
        public string AssertExpression
        {
            get { return _assertExpression; }
            set { _assertExpression = value; }
        }

        [Category("01. Definition")]
        [DefaultValue(RuleSeverity.Error)]
        [Description("This is a description.")]
        public RuleSeverity Severity
        {
            get
            {
                return _severity;
            }
            set
            {
                _severity = value;
            }
        }

        [Category("01. Definition")]
        [DefaultValue(0)]
        [Description("This is a description.")]
        public int Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

        [Category("01. Definition")]
        [DefaultValue(ArgumentType.RuleArgs)]
        [Description("This is a description.")]
        [UserFriendlyName("Argument Type")]
        public ArgumentType ArgumentType
        {
            get { return _argumentType; }
            set
            {
                _argumentType = value;
            }
        }

        [Category("01. Definition")]
        [DefaultValue(RuleMode.Generated)]
        [Description("This is a description.")]
        public RuleMode Mode
        {
            get
            {
                return _mode;
            }
            set
            {
                _mode = value;
            }
        }

        [Category("01. Definition")]
        [Editor(typeof(PropertyCollectionForm), typeof(UITypeEditor))]
        [Description("This is a description.")]
        [UserFriendlyName("Decorator Args")]
        public DecoratorArgumentCollection DecoratorArgs
        {
            get
            {
                return _decoratorArgs;
            }
        }
    }
}
