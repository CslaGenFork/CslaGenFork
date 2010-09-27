using System;
using System.Collections;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{

    public class ConvertValuePropertyCollection : System.Collections.Generic.List<ConvertValueProperty>
    {
        public ConvertValueProperty Find(string name)
        {
            foreach (ConvertValueProperty c in this)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        public ConvertValueProperty FindType(string typeName)
        {
            foreach (ConvertValueProperty c in this)
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
