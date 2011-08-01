using System.Collections.Generic;

namespace CslaGenerator.Metadata
{
    public class BusinessRuleConstructorParameterCollection : List<BusinessRuleConstructorParameter>
    {
        public BusinessRuleConstructorParameter Find(string name)
        {
            foreach (var c in this)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        public BusinessRuleConstructorParameter FindType(string type)
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