using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

namespace CslaGenerator.Metadata
{
    [XmlInclude(typeof(Property))]
    public class CriteriaPropertyCollection : List<CriteriaProperty>
    {
        public CriteriaProperty Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.Name.Equals(name));
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }

        public void Add(Property property)
        {
            base.Add(ConvertType(property));
        }

        CriteriaProperty ConvertType(Object property)
        {
            return ConvertType((Property) property);
        }

        private static CriteriaProperty ConvertType(Property property)
        {
            if (property is CriteriaProperty)
                return (CriteriaProperty) property;

            var newProperty = new CriteriaProperty(property);
            newProperty.Name = property.Name;
            newProperty.ParameterName = property.ParameterName;
            newProperty.PropertyType = property.PropertyType;
            newProperty.ReadOnly = property.ReadOnly;
            newProperty.Nullable = property.Nullable;
            newProperty.Remarks = property.Remarks;
            newProperty.Summary = property.Summary;

            return newProperty;
        }

        internal static CriteriaPropertyCollection Clone(CriteriaPropertyCollection masterCritProps)
        {
            var newCritProps = new CriteriaPropertyCollection();
            foreach (var critProp in masterCritProps)
            {
                var newCritProp = new CriteriaProperty();
                newCritProp.DbBindColumn = (DbBindColumn) critProp.DbBindColumn.Clone();
                ((Property) newCritProp).Clone(critProp);
                newCritProp.ParameterValue = critProp.ParameterValue;
                newCritProp.InlineQueryParameter = critProp.InlineQueryParameter;
                newCritProp.UnitOfWorkFactoryParameter = critProp.UnitOfWorkFactoryParameter;

                newCritProps.Add(newCritProp);
            }

            return newCritProps;
        }
    }
}