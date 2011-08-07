using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for BusinessRuleConstructor for Rules 4
    /// </summary>
    [Serializable]
    public class BusinessRuleConstructor : ICloneable
    {
        #region Private Fields

        private string _name = String.Empty;
        private bool _isActive;
        private BusinessRuleConstructorParameterCollection _constructorParameters = new BusinessRuleConstructorParameterCollection();

        #endregion

        #region 01. Definition

        [Category("01. Definition")]
        [Description("The Constructor Name.")]
        [UserFriendlyName("Constructor Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Category("01. Definition")]
        [Description("There can only be one active constructor for each rule.")]
        [UserFriendlyName("Constructor Is Active")]
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        #endregion

        #region 02. Generic Parameters Type

        [XmlIgnore]
        public TypeCodeEx GenericType0 { get; set; }

        [XmlIgnore]
        public TypeCodeEx GenericType1 { get; set; }

        [XmlIgnore]
        public TypeCodeEx GenericType2 { get; set; }

        [XmlIgnore]
        public TypeCodeEx GenericType3 { get; set; }

        [XmlIgnore]
        public TypeCodeEx GenericType4 { get; set; }

        [XmlIgnore]
        public TypeCodeEx GenericType5 { get; set; }

        [XmlIgnore]
        public TypeCodeEx GenericType6 { get; set; }

        [XmlIgnore]
        public TypeCodeEx GenericType7 { get; set; }

        [XmlIgnore]
        public TypeCodeEx GenericType8 { get; set; }

        [XmlIgnore]
        public TypeCodeEx GenericType9 { get; set; }

        #endregion

        #region 03. Parameters Value

        public BusinessRuleConstructorParameterCollection ConstructorParameters
        {
            get { return _constructorParameters; }
            set { _constructorParameters = value; }
        }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter0 { get; set; }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter1 { get; set; }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter2 { get; set; }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter3 { get; set; }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter4 { get; set; }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter5 { get; set; }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter6 { get; set; }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter7 { get; set; }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter8 { get; set; }

        [XmlIgnore]
        public BusinessRuleConstructorParameter ConstructorParameter9 { get; set; }

        #endregion

        public object Clone()
        {
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof (BusinessRuleConstructor));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            return ser.Deserialize(buffer);
        }

    }
}