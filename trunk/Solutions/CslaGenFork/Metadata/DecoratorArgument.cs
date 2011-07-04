using System.ComponentModel;
using CslaGenerator.Attributes;

namespace CslaGenerator.Metadata
{
    public class DecoratorArgument
    {
        private string _name = string.Empty;
        private string _value = string.Empty;
        private TypeCodeEx _valueType = TypeCodeEx.String;

        #region Constructors

        public DecoratorArgument()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DecoratorArgument class.
        /// </summary>
        /// <param name="name">The name of the decorator property</param>
        /// <param name="value">The value of the decorator property</param>
        public DecoratorArgument(string name, string value)
        {
            _name = name;
            _value = value;
        }
        /// <summary>
        /// Initializes a new instance of the DecoratorArgument class.
        /// </summary>
        /// <param name="name">The name of the decorator property</param>
        /// <param name="value">The value of the decorator property</param>
        /// <param name="addQuotes">If True, wraps the value with quotes. Intended for string decorator values.</param>
        public DecoratorArgument(string name, string value, bool addQuotes)
        {
            _name = name;
            if (addQuotes)
                _value = "\"" + value + "\"";
            else
                _value = value;
        }
        #endregion

        #region Public properties

        [Category("01. Definition")]
        [Description("This is a description.")]
        public string Name
        {
            get { return _name; }
            set { _name = PropertyHelper.Tidy(value); }
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        public string Value
        {
            get { return _value; }
            set { _value = PropertyHelper.Tidy(value); }
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        [UserFriendlyName("Value Type")]
        public TypeCodeEx ValueType
        {
            get { return _valueType; }
            set { _valueType = value; }
        }

        #endregion

    }
}
