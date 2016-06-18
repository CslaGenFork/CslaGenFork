using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for CslaGeneratorComponent.
    /// </summary>
    [Serializable]
    public class CslaGeneratorComponent
    {
        [XmlIgnore]
        private CslaGeneratorUnit _parent;

        public CslaGeneratorComponent()
        {
        }

        public CslaGeneratorComponent(CslaGeneratorUnit parent)
        {
            _parent = parent;
        }

        [Browsable(false)]
        [XmlIgnore]
        public CslaGeneratorUnit Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
    }
}