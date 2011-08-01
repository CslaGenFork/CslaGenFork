using System.Collections.Generic;

namespace CslaGenerator.Metadata
{
    public class BusinessRuleConstructorCollection : List<BusinessRuleConstructor>
    {
        public BusinessRuleConstructor Find(string name)
        {
            foreach (var c in this)
            {
                if (c.Name.Equals(name))
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