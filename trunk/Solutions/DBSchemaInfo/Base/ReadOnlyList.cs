using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DBSchemaInfo.Base
{
    public class ReadOnlyList<T> : BindingList<T>
    {
        private bool _isReadOnly = true;

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

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            protected internal set { _isReadOnly = value; }
        }

        protected override void InsertItem(int index, T item)
        {
            if (_isReadOnly)
                throw new NotSupportedException();
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            if (_isReadOnly)
                throw new NotSupportedException();
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, T item)
        {
            if (_isReadOnly)
                throw new NotSupportedException();
            base.SetItem(index, item);
        }
    }
}