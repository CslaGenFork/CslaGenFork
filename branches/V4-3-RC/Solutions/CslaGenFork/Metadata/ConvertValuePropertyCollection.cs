using System.Collections.Generic;

namespace CslaGenerator.Metadata
{

    public class ConvertValuePropertyCollection : List<ConvertValueProperty>
    {
        public ConvertValueProperty Find(string name)
        {
            foreach (var c in this)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        public ConvertValueProperty FindType(string typeName)
        {
            foreach (var c in this)
            {
                if (c.Name.Equals(typeName))
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
