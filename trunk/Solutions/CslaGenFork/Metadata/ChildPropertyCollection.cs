namespace CslaGenerator.Metadata
{
    public class ChildPropertyCollection : System.Collections.Generic.List<ChildProperty>
    {
        public ChildProperty Find(string name)
        {
            foreach (ChildProperty c in this)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        public ChildProperty FindType(string typeName)
        {
            foreach (ChildProperty c in this)
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