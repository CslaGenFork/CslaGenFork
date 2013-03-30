using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CslaGenerator.Attributes;

namespace CslaGenerator.Metadata
{
    public class DecoratorArgument
    {
        private string _Name=string.Empty;
        private string _Value=string.Empty;
        private TypeCodeEx _ValueType = TypeCodeEx.String;

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
            _Name = name;
            _Value = value;
        }
        /// <summary>
        /// Initializes a new instance of the DecoratorArgument class.
        /// </summary>
        /// <param name="name">The name of the decorator property</param>
        /// <param name="value">The value of the decorator property</param>
        /// <param name="addQuotes">If True, wraps the value with quotes. Intended for string decorator values.</param>
        public DecoratorArgument(string name, string value, bool addQuotes)
        {
            _Name = name;
            if (addQuotes)
                _Value = "\"" + value + "\"";
            else
                _Value = value;
        }
        #endregion

        [Category("01. Definition")]
        [Description("This is a description.")]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        public string Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
            }
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        [UserFriendlyName("Value Type")]
        public TypeCodeEx ValueType
        {
            get
            {
                return _ValueType;
            }
            set
            {
                _ValueType = value;
            }
        }

    }
}
