using System.ComponentModel;

namespace CslaGenerator.Metadata
{
    public class CriteriaCollection : BindingList<Criteria>
    {
        CslaObjectInfo _parent;

        public Criteria Find(string name)
        {
            foreach (var c in this)
            {
                if (c.Name.Equals(name))
                    return c;
            }
            return null;
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }

        internal void SetParent(CslaObjectInfo obj)
        {
            _parent = obj;
        }

        protected override void InsertItem(int index, Criteria item)
        {
            item.SetParent(_parent);
            base.InsertItem(index, item);
        }
    }
}
