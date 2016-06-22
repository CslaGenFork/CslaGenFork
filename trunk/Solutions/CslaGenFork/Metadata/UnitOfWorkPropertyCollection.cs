using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class UnitOfWorkPropertyCollection : List<UnitOfWorkProperty>
    {
        public UnitOfWorkProperty Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.Name.Equals(name));
        }

        public UnitOfWorkProperty FindType(string typeName)
        {
            if (typeName == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.TypeName.Equals(typeName));
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }
    }
}