using System;
using System.Collections.Generic;

namespace CslaGenerator.Metadata
{
    public class ValuePropertyCollection : List<ValueProperty>
    {
        public ValueProperty Find(string name)
        {
            foreach (ValueProperty p in this)
            {
                if (p.Name.Equals(name))
                    return p;
            }
            return null;
        }

        public bool Contains(string name)
        {
            return (Find(name) != null);
        }

        public new void Add(ValueProperty item)
        {
            AddHandlers(item);
            base.Add(item);
        }

        void AddHandlers(ValueProperty item)
        {
            item.Changed += item_Changed;
        }

        void RemoveHandlers(ValueProperty item)
        {
            item.Changed -= item_Changed;
        }

        private void item_Changed(ValueProperty sender, PropertyNameChangedEventArgs e)
        {
            if (ItemChanged != null)
                ItemChanged(sender, e);
        }

        [field: NonSerialized()]
        public event PropertyNameChanged ItemChanged;

    }
}
