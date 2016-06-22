using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class BusinessRuleConstructorParameterCollection : List<BusinessRuleConstructorParameter>
    {
        public BusinessRuleConstructorParameter Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.Name.Equals(name));
        }

        public BusinessRuleConstructorParameter FindType(string typeName)
        {
            if (typeName == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.Type.Equals(typeName));
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }
    }
}