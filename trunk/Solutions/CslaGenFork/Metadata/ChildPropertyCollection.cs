using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class ChildPropertyCollection : List<ChildProperty>
    {
        public ChildProperty Find(string name)
        {
            if (name == string.Empty)
                return null;

            /*foreach (var c in this)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;*/

            return this.FirstOrDefault(c => c.Name.Equals(name));
        }

        public ChildProperty FindType(string typeName)
        {
            if (typeName == string.Empty)
                return null;

            /*foreach (var c in this)
            {
                if (c.TypeName.Equals(typeName))
                    return c;
            }
            return null;*/

            return this.FirstOrDefault(c => c.TypeName.Equals(typeName));
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }
    }
}