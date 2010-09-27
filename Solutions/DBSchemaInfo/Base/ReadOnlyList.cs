using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace DBSchemaInfo.Base
{
    public class ReadOnlyList<T> : BindingList<T>
    {
        public ReadOnlyList(IEnumerable<T> items)
        {
            IsReadOnly = false;
            foreach (T item in items)
                Add(item);
            IsReadOnly = true;
        }
        public ReadOnlyList()
        {
        }
        private bool _IsReadOnly = true;
        public bool IsReadOnly
        {
            get
            {
                return _IsReadOnly;
            }
            protected internal set
            {
                _IsReadOnly = value;
            }
        }



        protected override void InsertItem(int index, T item)
        {
            if (_IsReadOnly)
                throw new NotSupportedException();
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            if (_IsReadOnly)
                throw new NotSupportedException();
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, T item)
        {
            if (_IsReadOnly)
                throw new NotSupportedException();
            base.SetItem(index, item);
        }
    }
}
