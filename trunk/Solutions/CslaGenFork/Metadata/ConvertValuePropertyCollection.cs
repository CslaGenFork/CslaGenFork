using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class ConvertValuePropertyCollection : List<ConvertValueProperty>
    {
        public ConvertValueProperty Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.Name.Equals(name));
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }
    }
}