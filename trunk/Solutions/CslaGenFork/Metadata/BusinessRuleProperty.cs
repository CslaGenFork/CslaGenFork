using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for BusinessRuleProperty for Rules 4
    /// </summary>
    [Serializable]
    public class BusinessRuleProperty : ICloneable
    {

        #region Private Fields

        private string _name = String.Empty;
        private string _type = String.Empty;
        private bool _isGenericType;
        private bool _isGenericParameter;
        private dynamic _value;

        #endregion

        [Description("The Property Name.")]
        [UserFriendlyName("Property Name")]
        [ReadOnly(true)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Description("The Property Type Name.")]
        [UserFriendlyName("Property Type Name")]
        [ReadOnly(true)]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [Description("Whether the Property is a generic Type.")]
        [UserFriendlyName("Is Generic Type")]
        [ReadOnly(true)]
        public bool IsGenericType
        {
            get { return _isGenericType; }
            set { _isGenericType = value; }
        }

        [Description("Whether the Property has a generic Type parameter.")]
        [UserFriendlyName("Has Generic Type parameter")]
        [ReadOnly(true)]
        public bool IsGenericParameter
        {
            get { return _isGenericParameter; }
            set { _isGenericParameter = value; }
        }

        [Description("The intended value for the Property.")]
        [UserFriendlyName("Property value")]
        public dynamic Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public object Clone()
        {
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof(BusinessRuleProperty));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            return ser.Deserialize(buffer);
        }
    }
}
