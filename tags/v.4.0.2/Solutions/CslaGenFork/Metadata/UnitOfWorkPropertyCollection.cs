using System.Collections.Generic;

namespace CslaGenerator.Metadata
{
    public class UnitOfWorkPropertyCollection : List<UnitOfWorkProperty>
    {
        public UnitOfWorkProperty Find(string name)
        {
            foreach (UnitOfWorkProperty c in this)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        public UnitOfWorkProperty FindType(string typeName)
        {
            foreach (UnitOfWorkProperty c in this)
            {
                if (c.TypeName.Equals(typeName))
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