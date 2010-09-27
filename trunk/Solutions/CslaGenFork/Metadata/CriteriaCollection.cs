using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{

    public class CriteriaCollection : System.ComponentModel.BindingList<Criteria>
    {
        public Criteria Find(string name)
        {
            foreach (Criteria c in this)
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

        CslaObjectInfo _Parent;
        internal void SetParent(CslaObjectInfo obj)
        {
            _Parent = obj;
        }

        protected override void InsertItem(int index, Criteria item)
        {
            item.SetParent(_Parent);
            base.InsertItem(index, item);
        }


    }
     
}
