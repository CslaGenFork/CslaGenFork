using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for UpdateValueProperty.
    /// </summary>
    [Serializable]
    public class UpdateValueProperty : Property
    {
        private string _sourcePropertyName = String.Empty;
        private bool _isIdentity = false;

        [Category("01. Definition")]
        [Description("The property to be updated.")]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        [Category("01. Definition")]
        [Description("The updater property. This must be combined with the \"Updater Type\" of the parent collection.")]
        [UserFriendlyName("Source Property Name")]
        public string SourcePropertyName
        {
            get
            {
                if (string.IsNullOrEmpty(_sourcePropertyName))
                    return base.Name;

                return _sourcePropertyName;
            }
            set { _sourcePropertyName = value; }
        }

        [Category("01. Definition")]
        [Description("Whether this property is an object identity..")]
        [UserFriendlyName("Is Identity")]
        public bool IsIdentity
        {
            get { return _isIdentity; }
            set { _isIdentity = value; }
        }

        // Hide ReadOnly
        [Browsable(false)]
        public override bool ReadOnly
        {
            get { return false; }
        }

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

        // Hide Summary
        [Browsable(false)]
        public override string Summary
        {
            get { return string.Empty; }
        }

        // Hide Remarks
        [Browsable(false)]
        public override string Remarks
        {
            get { return string.Empty; }
        }

        public override object Clone()
        {
            using (var buffer = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(UpdateValueProperty));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                return ser.Deserialize(buffer);
            }
        }

    }
}
