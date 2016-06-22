using System;
using System.Collections;
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
    public class UpdateValueProperty : ICloneable
    {
        private string _name = string.Empty;
        private string _sourcePropertyName = string.Empty;
        private bool _isIdentity;

        #region Constructors

        public UpdateValueProperty()
        {
        }

        public UpdateValueProperty(UpdateValueProperty prop)
        {
            Clone(prop);
        }

        #endregion

        #region UI Properties

        [Category("01. Definition")]
        [Description("The property to be updated.")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Category("01. Definition")]
        [Description("The updater property. This must be combined with the \"Updater Type\" of the parent collection.")]
        [UserFriendlyName("Source Property Name")]
        public string SourcePropertyName
        {
            get
            {
                if (string.IsNullOrEmpty(_sourcePropertyName))
                    return _name;

                return _sourcePropertyName;
            }
            set { _sourcePropertyName = value; }
        }

        [Category("01. Definition")]
        [Description("Whether this property is an object identity. If set to \"true\" the property is used to check for object identity and will not be updated.")]
        [UserFriendlyName("Is Identity")]
        public bool IsIdentity
        {
            get { return _isIdentity; }
            set { _isIdentity = value; }
        }

        #endregion

        #region Overrides

        public override bool Equals(object item)
        {
            if (!item.GetType().Equals(GetType()))
                return false;

            if (CaseInsensitiveComparer.Default.Compare(_name, ((Property) item).Name) == 0)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        #endregion

        #region Implements ICloneable

        public object Clone()
        {
            using (var buffer = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(UpdateValueProperty));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                return ser.Deserialize(buffer);
            }
        }

        public void Clone(UpdateValueProperty prop)
        {
            Name = prop.Name;
            SourcePropertyName = prop.SourcePropertyName;
            IsIdentity = prop.IsIdentity;
        }

        #endregion
    }
}