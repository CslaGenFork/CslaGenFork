using System.ComponentModel;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class CriteriaCollection : BindingList<Criteria>
    {
        CslaObjectInfo _parent;

        public Criteria Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.Name.Equals(name));
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
            if (_parent != null)
                item.SetParent(_parent);
            base.InsertItem(index, item);
        }
    }
}