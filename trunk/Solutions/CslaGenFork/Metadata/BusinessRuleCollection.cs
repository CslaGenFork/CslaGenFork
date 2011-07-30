using System.Collections.Generic;

namespace CslaGenerator.Metadata
{
    public class BusinessRuleCollection : List<BusinessRule>
    {
        public BusinessRule Find(string name)
        {
            foreach (BusinessRule p in this)
            {
                if (p.Name.Equals(name))
                    return p;
            }
            return null;
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }
    }
}
