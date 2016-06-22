using System;
using System.Collections.Generic;
using System.Linq;

namespace CslaGenerator.Metadata
{
    public class ValuePropertyCollection : List<ValueProperty>
    {
        public ValueProperty Find(string name)
        {
            if (name == string.Empty)
                return null;

            return this.FirstOrDefault(property => property.Name.Equals(name));
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

        public new void Remove(ValueProperty item)
        {
            RemoveHandlers(item);
            base.Add(item);
        }

        private void AddHandlers(ValueProperty item)
        {
            item.NameChanged += Item_Changed;
        }

        private void RemoveHandlers(ValueProperty item)
        {
            item.NameChanged -= Item_Changed;
        }

        private void Item_Changed(ValueProperty sender, PropertyNameChangedEventArgs e)
        {
            if (ItemChanged != null)
                ItemChanged(sender, e);
        }

        [field: NonSerialized]
        public event PropertyNameChanged ItemChanged;
    }
}