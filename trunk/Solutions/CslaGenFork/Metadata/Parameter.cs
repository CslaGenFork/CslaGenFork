using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for Parameter.
    /// </summary>
    [Serializable]
    public class Parameter
    {
        private string _criteriaName;
        //private Criteria _criteria;
        private string _propertyName;
        //private Property _property;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="criteriaName">Name of the criteria.</param>
        /// <param name="propertyName">Name of the property.</param>
        public Parameter(string criteriaName, string propertyName)
        {
            _criteriaName = criteriaName;
            _propertyName = propertyName;
        }

        public Parameter()
        {
        }

        public string CriteriaName
        {
            get { return _criteriaName; }
            set { _criteriaName = value; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        //[XmlIgnore]
        [Browsable(false)]
        public Criteria Criteria
        {
            //get { return GetCriteria(); }
            set { _criteriaName = value.Name; }
        }

        //[XmlIgnore]
        [Browsable(false)]
        public Property Property
        {
            //get { return GetProperty(); }
            set { _propertyName = value.Name; }
        }

        /*private CslaObjectInfo GetCslaObjectInfo()
        {
            if (_cslaObject == null)
                _cslaObject = GeneratorController.Current.CurrentUnit.CslaObjects.FindByGenericName(_cslaObjectName);

            return _cslaObject;
        }

        private Criteria GetCriteria()
        {
            if (_criteria == null)
            {
                foreach (var criteria in GetCslaObjectInfo().CriteriaObjects)
                {
                    if (criteria.Name == _criteriaName)
                    {
                        _criteria = criteria;
                        break;
                    }
                }
            }

            return _criteria;
        }

        private Property GetProperty()
        {
            if (_property == null)
            {
                foreach (var property in GetCriteria().Properties)
                {
                    if (property.Name == _propertyName)
                    {
                        _property = property;
                        break;
                    }
                }
            }

            return _property;
        }*/
    }
}