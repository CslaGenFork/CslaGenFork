using System.Collections.Generic;
using System.ComponentModel;
using CslaGenerator.Attributes;

namespace CslaGenerator.Metadata
{
    public class BusinessRuleParameterCollection : List<BusinessRuleParameter>
    {
        public BusinessRuleParameter Find(string name)
        {
            foreach (var c in this)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        public BusinessRuleParameter FindType(string type)
        {
            foreach (var c in this)
            {
                if (c.Type.Equals(type))
                    return c;
            }
            return null;
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }
    }
}