using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class UpdateValuePropertyCollection : List<UpdateValueProperty>
    {
        public UpdateValueProperty Find(string name)
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