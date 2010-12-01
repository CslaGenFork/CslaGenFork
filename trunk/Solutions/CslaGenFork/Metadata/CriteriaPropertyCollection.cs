using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{
    [XmlInclude(typeof(Property))]
    public class CriteriaPropertyCollection : List<CriteriaProperty>
    {
        public bool Contains(string name)
        {
            foreach (Property p in this)
            {
                if (p.Name.Equals(name))
                    return true;
            }
            return false;
        }

        public void Add(Property p)
        {
            base.Add(ConvertType(p));
        }

        CriteriaProperty ConvertType(Object p)
        {
            return ConvertType((Property)p);
        }

        private static CriteriaProperty ConvertType(Property p)
        {
            if (p is CriteriaProperty)
                return (CriteriaProperty)p;
            CriteriaProperty newP = new CriteriaProperty(p);
            newP.Name = p.Name;
            newP.ParameterName = p.ParameterName;
            newP.PropertyType = p.PropertyType;
            newP.ReadOnly = p.ReadOnly;
            newP.Nullable = p.Nullable;
            newP.Remarks = p.Remarks;
            newP.Summary = p.Summary;
            return newP;
        }

        internal static CriteriaPropertyCollection Clone(CriteriaPropertyCollection masterCritProps)
        {
            var newCritProps = new CriteriaPropertyCollection();
            foreach (var critProp in masterCritProps)
            {
                var newCritProp = new CriteriaProperty();
                newCritProp.DbBindColumn = (DbBindColumn)critProp.DbBindColumn.Clone();
                ((Property)newCritProp).Clone(critProp);
                newCritProp.ParameterValue = critProp.ParameterValue;

                newCritProps.Add(newCritProp);
            }

            return newCritProps;
        }
    }
}