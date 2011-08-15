using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for BusinessRuleConstructorParameter for Rules 4
    /// </summary>
    public class BusinessRuleConstructorParameter : ICloneable
    {

        #region Private Fields

        private string _name = String.Empty;
        private string _type = String.Empty;
        private bool _isParams;
        private bool _isGenericType;
        private bool _isGenericParameter;
        private TypeCodeEx _genericType = TypeCodeEx.Object;
        private dynamic _value;

        #endregion

        [Description("The Parameter Name.")]
        [UserFriendlyName("Parameter Name")]
        [ReadOnly(true)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Description("The Parameter Type Name.")]
        [UserFriendlyName("Parameter Type Name")]
        [ReadOnly(true)]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [Description("Whether this parameter is a params Array.")]
        [UserFriendlyName("Is params Array")]
        [Browsable(false)]
        public bool IsParams
        {
            get { return _isParams; }
            set { _isParams = value; }
        }

        [Description("Whether the Parameter is a generic Type.")]
        [UserFriendlyName("Is Generic Type")]
        [ReadOnly(true)]
        public bool IsGenericType
        {
            get { return _isGenericType; }
            set { _isGenericType = value; }
        }

        [Description("Whether the Parameter has a generic Type parameter.")]
        [UserFriendlyName("Has Generic Type parameter")]
        [ReadOnly(true)]
        public bool IsGenericParameter
        {
            get { return _isGenericParameter; }
            set { _isGenericParameter = value; }
        }

        [Description("The Type of generic parameter.")]
        [UserFriendlyName("Generic parameter Type")]
        public TypeCodeEx GenericType
        {
            get { return _genericType; }
            set { _genericType = value; }
        }

        [Description("The intended value for the Parameter.")]
        [UserFriendlyName("Parameter value")]
        public dynamic Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public object Clone()
        {
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof(BusinessRuleConstructorParameter));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            return ser.Deserialize(buffer);
        }
    }
}
