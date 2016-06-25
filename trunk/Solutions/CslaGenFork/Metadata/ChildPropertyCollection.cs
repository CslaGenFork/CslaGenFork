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

            return this.FirstOrDefault(property => property.Name.Equals(name));
        }

        public ChildProperty FindType(string typeName)
        {
            if (typeName == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.TypeName.Equals(typeName));
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }

        internal void MarkAllAsCollection()
        {
            foreach (var item in this)
            {
                item.IsCollection = true;
            }
        }
    }
}