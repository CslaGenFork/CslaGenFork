using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Design;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for UnitOfWorkProperty.
    /// </summary>
    [Serializable]
    public class UnitOfWorkProperty : Property
    {

        #region Private Fields

        private PropertyDeclaration _declarationMode = PropertyDeclaration.Managed;
        private string _typeName = String.Empty;
        private string _targetCriteria = String.Empty;

        #endregion

        #region 01. Definition

        [Category("01. Definition")]
        [Description("The property name.")]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        [Category("01. Definition")]
        [Description("This is a description.")]
        [Editor(typeof(UnitOfWorkTypeEditor), typeof(UITypeEditor))]
        [UserFriendlyName("Type Name")]
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        [Category("01. Definition")]
        [Description("Property Declaration Mode. For Unit of Work this must be \"AutoProperty\" or \"Managed\".")]
        [UserFriendlyName("Declaration Mode")]
        public PropertyDeclaration DeclarationMode
        {
            get { return _declarationMode; }
            set
            {
                if (value == PropertyDeclaration.AutoProperty ||
                    value == PropertyDeclaration.Managed)
                _declarationMode = value;
            }
        }

        [Category("01. Definition")]
        [Description("Whether this property can be changed by other classes.")]
        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set { base.ReadOnly = value; }
        }

        #endregion

        #region 05. Options

        [Category("05. Options")]
        [Editor(typeof(UnitOfWorkTargetCriteriaEditor), typeof(UITypeEditor))]
        [Description("The criteria name of target object, that is used to load the object.")]
        [UserFriendlyName("Target Criteria")]
        public string TargetCriteria
        {
            get { return _targetCriteria; }
            set { _targetCriteria = value; }
        }

        #endregion

        // Hide ParameterName
        [Browsable(false)]
        public override string ParameterName
        {
            get { return string.Empty; }
        }

        // Hide PropertyType
        [Browsable(false)]
        public override TypeCodeEx PropertyType
        {
            get { return TypeCodeEx.Empty; }
        }

        // Hide Nullable
        [Browsable(false)]
        public override bool Nullable
        {
            get { return false; }
        }

        public override object Clone()
        {
            var buffer = new MemoryStream();
            var ser = new XmlSerializer(typeof(UnitOfWorkProperty));
            ser.Serialize(buffer, this);
            buffer.Position = 0;
            return ser.Deserialize(buffer);
        }

    }
}
