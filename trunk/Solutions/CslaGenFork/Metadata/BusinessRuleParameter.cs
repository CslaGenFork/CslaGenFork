using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using CslaGenerator.Attributes;
using CslaGenerator.Design;
using System.Xml.Serialization;


namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for BusinessRuleConstructor for Rules 4
    /// </summary>
    [Serializable]
    [DefaultProperty("ParameterValue")]
    public class BusinessRuleParameter : ICloneable
    {

        #region Private Fields

        private string _objectName = String.Empty;
        private string _name = String.Empty;
        private string _type = String.Empty;
        private bool _isGenericType;
        private bool _isGenericParameter;
        private dynamic _value;

        #endregion

        [UserFriendlyName("Friendly Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Description("The constructor's Parameter Name.")]
        [UserFriendlyName("Parameter Name")]
        [ReadOnly(true)]
        public string ObjectName
        {
            get { return _objectName; }
            set { _objectName = value; }
        }

        [Description("The constructor's Type Name.")]
        [UserFriendlyName("Parameter Type Name")]
        [ReadOnly(true)]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [Description("Whether constructor's Parameter is a generic Type.")]
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
            var ser = new XmlSerializer(typeof(BusinessRuleParameter));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            return ser.Deserialize(buffer);
        }
    }
}
