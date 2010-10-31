namespace CslaGenerator.Metadata
{
    public class UpdateValuePropertyCollection : System.Collections.Generic.List<UpdateValueProperty>
    {
        public UpdateValueProperty Find(string name)
        {
            foreach (UpdateValueProperty c in this)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        public UpdateValueProperty FindType(string typeName)
        {
            foreach (UpdateValueProperty c in this)
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