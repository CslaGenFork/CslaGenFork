using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.CodeGen;
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
        private CslaObjectInfo _info;

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
        [Description("The type (class) for this property.")]
        [Editor(typeof (UnitOfWorkTypeEditor), typeof (UITypeEditor))]
        [UserFriendlyName("Type Name")]
        public string TypeName
        {
            get
            {
                _info = GeneratorController.Current.CurrentUnit.CslaObjects.Find(_typeName);
                return _typeName;
            }
            set { _typeName = PropertyHelper.Tidy(value); }
        }

        [Category("01. Definition")]
        [Description("The Property Declaration Mode must be \"AutoProperty\" or \"Managed\".")]
        [TypeConverter(typeof(EnumDescriptionOrCaseConverter))]
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
        [Description("Whether this type can can create objects. The value isfalse for ReadOnly and NameValueList types; otherwise is true.")]
        [UserFriendlyName("Creates Objects")]
        [ReadOnly(true)]
        public bool CreatesObject
        {
            get
            {
                if (_info != null && !CslaTemplateHelperCS.IsEditableType(_info.ObjectType))
                    return false;

                return true;
            }
        }

        [Category("01. Definition")]
        [Description("Whether this property is read only.")]
        [ReadOnly(true)]
        public override bool ReadOnly
        {
            get { return true; }
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
            using (var buffer = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof (UnitOfWorkProperty));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                return ser.Deserialize(buffer);
            }
        }
    }
}
