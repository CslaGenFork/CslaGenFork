using System;
using System.Collections;
using System.Xml.Serialization;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// A strongly-typed collection of <see cref="Property"/> objects.
    /// </summary>
    [Serializable]
    public class PropertyCollection : IList, ICloneable
    {
        #region Interfaces

        /// <summary>
        ///        Supports type-safe iteration over a <see cref="PropertyCollection"/>.
        /// </summary>
        public interface IPropertyCollectionEnumerator
        {
            /// <summary>
            ///        Gets the current element in the collection.
            /// </summary>
            Property Current { get; }

            /// <summary>
            ///        Advances the enumerator to the next element in the collection.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            ///        The collection was modified after the enumerator was created.
            /// </exception>
            /// <returns>
            ///        <c>true</c> if the enumerator was successfully advanced to the next element;
            ///        <c>false</c> if the enumerator has passed the end of the collection.
            /// </returns>
            bool MoveNext();

            /// <summary>
            ///        Sets the enumerator to its initial position, before the first element in the collection.
            /// </summary>
            void Reset();
        }

        #endregion

        private const int DefaultCapacity = 16;

        #region Implementation (data)

        private Property[] _array;
        private int _count;
        [XmlIgnore] private int _version;

        #endregion

        #region Static Wrappers

        /// <summary>
        ///        Creates a synchronized (thread-safe) wrapper for a
        ///     <c>PropertyCollection</c> instance.
        /// </summary>
        /// <returns>
        ///     An <c>PropertyCollection</c> wrapper that is synchronized (thread-safe).
        /// </returns>
        public static PropertyCollection Synchronized(PropertyCollection list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            return new SyncPropertyCollection(list);
        }

        /// <summary>
        ///        Creates a read-only wrapper for a
        ///     <c>PropertyCollection</c> instance.
        /// </summary>
        /// <returns>
        ///     An <c>PropertyCollection</c> wrapper that is read-only.
        /// </returns>
        public static PropertyCollection ReadOnly(PropertyCollection list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            return new ReadOnlyPropertyCollection(list);
        }

        #endregion

        #region Construction

        /// <summary>
        ///        Initializes a new instance of the <c>PropertyCollection</c> class
        ///        that is empty and has the default initial capacity.
        /// </summary>
        public PropertyCollection()
        {
            _array = new Property[DefaultCapacity];
        }

        /// <summary>
        ///        Initializes a new instance of the <c>PropertyCollection</c> class
        ///        that has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">
        ///        The number of elements that the new <c>PropertyCollection</c> is initially capable of storing.
        ///    </param>
        public PropertyCollection(int capacity)
        {
            _array = new Property[capacity];
        }

        /// <summary>
        ///        Initializes a new instance of the <c>PropertyCollection</c> class
        ///        that contains elements copied from the specified <c>PropertyCollection</c>.
        /// </summary>
        /// <param name="property">The <c>PropertyCollection</c> whose elements are copied to the new collection.</param>
        public PropertyCollection(PropertyCollection property)
        {
            _array = new Property[property.Count];
            AddRange(property);
        }

        /// <summary>
        ///        Initializes a new instance of the <c>PropertyCollection</c> class
        ///        that contains elements copied from the specified <see cref="Property"/> array.
        /// </summary>
        /// <param name="a">The <see cref="Property"/> array whose elements are copied to the new list.</param>
        public PropertyCollection(Property[] a)
        {
            _array = new Property[a.Length];
            AddRange(a);
        }

        protected enum Tag
        {
            Default
        }

        protected PropertyCollection(Tag t)
        {
            _array = null;
        }

        #endregion

        #region Operations (type-safe ICollection)

        /// <summary>
        ///        Gets the number of elements actually contained in the <c>PropertyCollection</c>.
        /// </summary>
        public virtual int Count
        {
            get { return _count; }
        }

        /// <summary>
        ///        Copies the entire <c>PropertyCollection</c> to a one-dimensional
        ///        <see cref="Property"/> array.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Property"/> array to copy to.</param>
        public virtual void CopyTo(Property[] array)
        {
            CopyTo(array, 0);
        }

        /// <summary>
        ///        Copies the entire <c>PropertyCollection</c> to a one-dimensional
        ///        <see cref="Property"/> array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Property"/> array to copy to.</param>
        /// <param name="start">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public virtual void CopyTo(Property[] array, int start)
        {
            if (_count > array.GetUpperBound(0) + 1 - start)
                throw new ArgumentException("Destination array was not long enough.");

            Array.Copy(_array, 0, array, start, _count);
        }

        /// <summary>
        ///        Gets a value indicating whether access to the collection is synchronized (thread-safe).
        /// </summary>
        /// <returns>true if access to the ICollection is synchronized (thread-safe); otherwise, false.</returns>
        public virtual bool IsSynchronized
        {
            get { return _array.IsSynchronized; }
        }

        /// <summary>
        ///        Gets an object that can be used to synchronize access to the collection.
        /// </summary>
        public virtual object SyncRoot
        {
            get { return _array.SyncRoot; }
        }

        #endregion

        #region Operations (type-safe IList)

        /// <summary>
        /// Gets or sets the <see cref="Property"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="index"/> is less than zero</para>
        /// <para>-or-</para>
        /// <para><paramref name="index"/> is equal to or greater than <see cref="PropertyCollection.Count"/>.</para>
        /// </exception>
        public virtual Property this[int index]
        {
            get
            {
                ValidateIndex(index); // throws
                return _array[index];
            }
            set
            {
                ValidateIndex(index); // throws
                ++_version;
                _array[index] = value;
            }
        }

        /// <summary>
        /// Adds a <see cref="Property"/> to the end of the <c>PropertyCollection</c>.
        /// </summary>
        /// <param name="item">The <see cref="Property"/> to be added to the end of the <c>PropertyCollection</c>.</param>
        /// <returns>The index at which the value has been added.</returns>
        public virtual int Add(Property item)
        {
            //This is done so that the collection stores Property Objects ONLY
            //and avoid saving a ValueProperty to the xml when there's no need.

            if (_count == _array.Length)
                EnsureCapacity(_count + 1);

            _array[_count] = item;
            _version++;

            return _count++;
        }

        /// <summary>
        /// Removes all elements from the <c>PropertyCollection</c>.
        /// </summary>
        public virtual void Clear()
        {
            ++_version;
            _array = new Property[DefaultCapacity];
            _count = 0;
        }

        /// <summary>
        /// Creates a shallow copy of the <see cref="PropertyCollection"/>.
        /// </summary>
        public virtual object Clone()
        {
            var newColl = new PropertyCollection(_count);
            Array.Copy(_array, 0, newColl._array, 0, _count);
            newColl._count = _count;
            newColl._version = _version;

            return newColl;
        }

        /// <summary>
        /// Determines whether a given <see cref="Property"/> is in the <c>PropertyCollection</c>.
        /// </summary>
        /// <param name="item">The <see cref="Property"/> to check for.</param>
        /// <returns><c>true</c> if <paramref name="item"/> is found in the <c>PropertyCollection</c>; otherwise, <c>false</c>.</returns>
        public virtual bool Contains(Property item)
        {
            for (var i = 0; i != _count; ++i)
                if (_array[i].Equals(item))
                    return true;
            return false;
        }

        /// <summary>
        /// Determines whether a given <see cref="Property"/> is in the <c>PropertyCollection</c>.
        /// </summary>
        /// <param name="name">The property name to check for.</param>
        /// <returns><c>true</c> if <paramref name="name"/> is found in the <c>PropertyCollection</c>; otherwise, <c>false</c>.</returns>
        public virtual bool Contains(string name)
        {
            for (var i = 0; i != _count; ++i)
                if (CaseInsensitiveComparer.Default.Compare(_array[i].Name, name) == 0)
                    return true;
            return false;
        }

        /// <summary>
        /// Returns the zero-based index of the first occurrence of a <see cref="Property"/>
        /// in the <c>PropertyCollection</c>.
        /// </summary>
        /// <param name="item">The <see cref="Property"/> to locate in the <c>PropertyCollection</c>.</param>
        /// <returns>
        /// The zero-based index of the first occurrence of <paramref name="item"/>
        /// in the entire <c>PropertyCollection</c>, if found; otherwise, -1.
        /// </returns>
        public virtual int IndexOf(Property item)
        {
            for (var i = 0; i != _count; ++i)
                if (_array[i].Equals(item))
                    return i;
            return -1;
        }

        /// <summary>
        /// Inserts an element into the <c>PropertyCollection</c> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The <see cref="Property"/> to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="index"/> is less than zero</para>
        /// <para>-or-</para>
        /// <para><paramref name="index"/> is equal to or greater than <see cref="PropertyCollection.Count"/>.</para>
        /// </exception>
        public virtual void Insert(int index, Property item)
        {
            ValidateIndex(index, true); // throws

            if (_count == _array.Length)
                EnsureCapacity(_count + 1);

            if (index < _count)
            {
                Array.Copy(_array, index, _array, index + 1, _count - index);
            }
            item = new Property(item);
            _array[index] = item;
            _count++;
            _version++;
        }

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="Property"/> from the <c>PropertyCollection</c>.
        /// </summary>
        /// <param name="item">The <see cref="Property"/> to remove from the <c>PropertyCollection</c>.</param>
        /// <exception cref="ArgumentException">
        /// The specified <see cref="Property"/> was not found in the <c>PropertyCollection</c>.
        /// </exception>
        public virtual void Remove(Property item)
        {
            int i = IndexOf(item);
            if (i < 0)
                throw new ArgumentException(
                    "Cannot remove the specified item because it was not found in the specified Collection.");

            ++_version;
            RemoveAt(i);
        }

        /// <summary>
        /// Removes the element at the specified index of the <c>PropertyCollection</c>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="index"/> is less than zero</para>
        /// <para>-or-</para>
        /// <para><paramref name="index"/> is equal to or greater than <see cref="PropertyCollection.Count"/>.</para>
        /// </exception>
        public virtual void RemoveAt(int index)
        {
            ValidateIndex(index); // throws

            _count--;

            if (index < _count)
            {
                Array.Copy(_array, index + 1, _array, index, _count - index);
            }

            // We can't set the deleted entry equal to null, because it might be a value type.
            // Instead, we'll create an empty single-element array of the right type and copy it
            // over the entry we want to erase.
            var temp = new Property[1];
            Array.Copy(temp, 0, _array, _count, 1);
            _version++;
        }

        /// <summary>
        /// Gets a value indicating whether the collection has a fixed size.
        /// </summary>
        /// <value>true if the collection has a fixed size; otherwise, false. The default is false</value>
        public virtual bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the <B>IList</B> is read-only.
        /// </summary>
        /// <value>true if the collection is read-only; otherwise, false. The default is false</value>
        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region Operations (type-safe IEnumerable)

        /// <summary>
        ///        Returns an enumerator that can iterate through the <c>PropertyCollection</c>.
        /// </summary>
        /// <returns>An <see cref="Enumerator"/> for the entire <c>PropertyCollection</c>.</returns>
        public virtual IPropertyCollectionEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        #endregion

        #region Public helpers (just to mimic some nice features of ArrayList)

        /// <summary>
        ///        Gets or sets the number of elements the <c>PropertyCollection</c> can contain.
        /// </summary>
        public virtual int Capacity
        {
            get { return _array.Length; }

            set
            {
                if (value < _count)
                    value = _count;

                if (value != _array.Length)
                {
                    if (value > 0)
                    {
                        Property[] temp = new Property[value];
                        Array.Copy(_array, temp, _count);
                        _array = temp;
                    }
                    else
                    {
                        _array = new Property[DefaultCapacity];
                    }
                }
            }
        }

        /// <summary>
        ///        Adds the elements of another <c>PropertyCollection</c> to the current <c>PropertyCollection</c>.
        /// </summary>
        /// <param name="x">The <c>PropertyCollection</c> whose elements should be added to the end of the current <c>PropertyCollection</c>.</param>
        /// <returns>The new <see cref="PropertyCollection.Count"/> of the <c>PropertyCollection</c>.</returns>
        public virtual int AddRange(PropertyCollection x)
        {
            if (_count + x.Count >= _array.Length)
                EnsureCapacity(_count + x.Count);

            Array.Copy(x._array, 0, _array, _count, x.Count);
            _count += x.Count;
            _version++;

            return _count;
        }

        /// <summary>
        ///        Adds the elements of a <see cref="Property"/> array to the current <c>PropertyCollection</c>.
        /// </summary>
        /// <param name="x">The <see cref="Property"/> array whose elements should be added to the end of the <c>PropertyCollection</c>.</param>
        /// <returns>The new <see cref="PropertyCollection.Count"/> of the <c>PropertyCollection</c>.</returns>
        public virtual int AddRange(Property[] x)
        {
            if (_count + x.Length >= _array.Length)
                EnsureCapacity(_count + x.Length);

            Array.Copy(x, 0, _array, _count, x.Length);
            _count += x.Length;
            _version++;

            return _count;
        }

        /// <summary>
        ///        Sets the capacity to the actual number of elements.
        /// </summary>
        public virtual void TrimToSize()
        {
            Capacity = _count;
        }

        #endregion

        #region Implementation (helpers)

        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="index"/> is less than zero</para>
        /// <para>-or-</para>
        /// <para><paramref name="index"/> is equal to or greater than <see cref="PropertyCollection.Count"/>.</para>
        /// </exception>
        private void ValidateIndex(int index)
        {
            ValidateIndex(index, false);
        }

        /// <summary>
        /// Validates the index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="allowEqualEnd">if set to <c>true</c> [allow equal end].</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateIndex(int index, bool allowEqualEnd)
        {
            int max = (allowEqualEnd) ? (_count) : (_count - 1);
            if (index < 0 || index > max)
                throw new ArgumentOutOfRangeException("index", index,
                    @"Index was out of range.  Must be non-negative and less than the size of the collection.");
        }

        private void EnsureCapacity(int min)
        {
            int newCapacity = ((_array.Length == 0) ? DefaultCapacity : _array.Length*2);
            if (newCapacity < min)
                newCapacity = min;

            Capacity = newCapacity;
        }

        #endregion

        #region Implementation (ICollection)

        void ICollection.CopyTo(Array array, int start)
        {
            CopyTo((Property[]) array, start);
        }

        #endregion

        #region Implementation (IList)

        object IList.this[int i]
        {
            get { return this[i]; }
            set { this[i] = (Property) value; }
        }

        int IList.Add(object x)
        {
            return Add((Property) x);
        }

        bool IList.Contains(object x)
        {
            return Contains((Property) x);
        }

        int IList.IndexOf(object x)
        {
            return IndexOf((Property) x);
        }

        void IList.Insert(int pos, object x)
        {
            Insert(pos, (Property) x);
        }

        void IList.Remove(object x)
        {
            Remove((Property) x);
        }

        void IList.RemoveAt(int pos)
        {
            RemoveAt(pos);
        }

        #endregion

        #region Implementation (IEnumerable)

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) (GetEnumerator());
        }

        #endregion

        #region Nested enumerator class

        /// <summary>
        ///        Supports simple iteration over a <see cref="PropertyCollection"/>.
        /// </summary>
        private class Enumerator : IEnumerator, IPropertyCollectionEnumerator
        {
            #region Implementation (data)

            private PropertyCollection _collection;
            private int _index;
            private int _version;

            #endregion

            #region Construction

            /// <summary>
            ///        Initializes a new instance of the <c>Enumerator</c> class.
            /// </summary>
            /// <param name="tc"></param>
            internal Enumerator(PropertyCollection tc)
            {
                _collection = tc;
                _index = -1;
                _version = tc._version;
            }

            #endregion

            #region Operations (type-safe IEnumerator)

            /// <summary>
            ///        Gets the current element in the collection.
            /// </summary>
            public Property Current
            {
                get { return _collection[_index]; }
            }

            /// <summary>
            ///        Advances the enumerator to the next element in the collection.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            ///        The collection was modified after the enumerator was created.
            /// </exception>
            /// <returns>
            ///        <c>true</c> if the enumerator was successfully advanced to the next element;
            ///        <c>false</c> if the enumerator has passed the end of the collection.
            /// </returns>
            public bool MoveNext()
            {
                if (_version != _collection._version)
                    throw new InvalidOperationException(
                        "Collection was modified; enumeration operation may not execute.");

                ++_index;
                return (_index < _collection.Count);
            }

            /// <summary>
            ///        Sets the enumerator to its initial position, before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                _index = -1;
            }

            #endregion

            #region Implementation (IEnumerator)

            object IEnumerator.Current
            {
                get { return Current; }
            }

            #endregion
        }

        #endregion

        #region Nested Syncronized Wrapper class

        [Serializable]
        private class SyncPropertyCollection : PropertyCollection, System.Runtime.Serialization.IDeserializationCallback
        {
            #region Implementation (data)

            private const int Timeout = 0; // infinite
            private PropertyCollection _collection;
            [XmlIgnore]
            private System.Threading.ReaderWriterLock _rwLock;

            #endregion

            #region Construction

            internal SyncPropertyCollection(PropertyCollection list)
                : base(Tag.Default)
            {
                _rwLock = new System.Threading.ReaderWriterLock();
                _collection = list;
            }

            #endregion

            #region IDeserializationCallback Members

            void System.Runtime.Serialization.IDeserializationCallback.OnDeserialization(object sender)
            {
                _rwLock = new System.Threading.ReaderWriterLock();
            }

            #endregion

            #region Type-safe ICollection

            public override void CopyTo(Property[] array)
            {
                _rwLock.AcquireReaderLock(Timeout);

                try
                {
                    _collection.CopyTo(array);
                }
                finally
                {
                    _rwLock.ReleaseReaderLock();
                }
            }

            public override void CopyTo(Property[] array, int start)
            {
                _rwLock.AcquireReaderLock(Timeout);

                try
                {
                    _collection.CopyTo(array, start);
                }
                finally
                {
                    _rwLock.ReleaseReaderLock();
                }
            }

            public override int Count
            {
                get
                {
                    int count;
                    _rwLock.AcquireReaderLock(Timeout);

                    try
                    {
                        count = _collection.Count;
                    }
                    finally
                    {
                        _rwLock.ReleaseReaderLock();
                    }

                    return count;
                }
            }

            public override bool IsSynchronized
            {
                get { return true; }
            }

            public override object SyncRoot
            {
                get { return _collection.SyncRoot; }
            }

            #endregion

            #region Type-safe IList

            public override Property this[int i]
            {
                get
                {
                    Property thisItem;
                    _rwLock.AcquireReaderLock(Timeout);

                    try
                    {
                        thisItem = _collection[i];
                    }
                    finally
                    {
                        _rwLock.ReleaseReaderLock();
                    }

                    return thisItem;
                }

                set
                {
                    _rwLock.AcquireWriterLock(Timeout);

                    try
                    {
                        _collection[i] = value;
                    }
                    finally
                    {
                        _rwLock.ReleaseWriterLock();
                    }
                }
            }

            public override int Add(Property x)
            {
                int result;
                _rwLock.AcquireWriterLock(Timeout);

                try
                {
                    result = _collection.Add(x);
                }
                finally
                {
                    _rwLock.ReleaseWriterLock();
                }

                return result;
            }

            public override void Clear()
            {
                _rwLock.AcquireWriterLock(Timeout);

                try
                {
                    _collection.Clear();
                }
                finally
                {
                    _rwLock.ReleaseWriterLock();
                }
            }

            public override bool Contains(Property x)
            {
                bool result;
                _rwLock.AcquireReaderLock(Timeout);

                try
                {
                    result = _collection.Contains(x);
                }
                finally
                {
                    _rwLock.ReleaseReaderLock();
                }

                return result;
            }

            public override int IndexOf(Property x)
            {
                int result;
                _rwLock.AcquireReaderLock(Timeout);

                try
                {
                    result = _collection.IndexOf(x);
                }
                finally
                {
                    _rwLock.ReleaseReaderLock();
                }

                return result;
            }

            public override void Insert(int pos, Property x)
            {
                _rwLock.AcquireWriterLock(Timeout);

                try
                {
                    _collection.Insert(pos, x);
                }
                finally
                {
                    _rwLock.ReleaseWriterLock();
                }
            }

            public override void Remove(Property x)
            {
                _rwLock.AcquireWriterLock(Timeout);

                try
                {
                    _collection.Remove(x);
                }
                finally
                {
                    _rwLock.ReleaseWriterLock();
                }
            }

            public override void RemoveAt(int pos)
            {
                _rwLock.AcquireWriterLock(Timeout);

                try
                {
                    _collection.RemoveAt(pos);
                }
                finally
                {
                    _rwLock.ReleaseWriterLock();
                }
            }

            public override bool IsFixedSize
            {
                get { return _collection.IsFixedSize; }
            }

            public override bool IsReadOnly
            {
                get { return _collection.IsReadOnly; }
            }

            #endregion

            #region Type-safe IEnumerable

            public override IPropertyCollectionEnumerator GetEnumerator()
            {
                IPropertyCollectionEnumerator enumerator;
                _rwLock.AcquireReaderLock(Timeout);

                try
                {
                    enumerator = _collection.GetEnumerator();
                }
                finally
                {
                    _rwLock.ReleaseReaderLock();
                }

                return enumerator;
            }

            #endregion

            #region Public Helpers

            // (just to mimic some nice features of ArrayList)
            public override int Capacity
            {
                get
                {
                    int result;
                    _rwLock.AcquireReaderLock(Timeout);

                    try
                    {
                        result = _collection.Capacity;
                    }
                    finally
                    {
                        _rwLock.ReleaseReaderLock();
                    }

                    return result;
                }

                set
                {
                    _rwLock.AcquireWriterLock(Timeout);

                    try
                    {
                        _collection.Capacity = value;
                    }
                    finally
                    {
                        _rwLock.ReleaseWriterLock();
                    }
                }
            }

            public override int AddRange(PropertyCollection x)
            {
                int result;
                _rwLock.AcquireWriterLock(Timeout);

                try
                {
                    result = _collection.AddRange(x);
                }
                finally
                {
                    _rwLock.ReleaseWriterLock();
                }

                return result;
            }

            public override int AddRange(Property[] x)
            {
                int result;
                _rwLock.AcquireWriterLock(Timeout);

                try
                {
                    result = _collection.AddRange(x);
                }
                finally
                {
                    _rwLock.ReleaseWriterLock();
                }

                return result;
            }

            #endregion
        }

        #endregion

        #region Nested Read Only Wrapper class

        [Serializable]
        private class ReadOnlyPropertyCollection : PropertyCollection
        {
            #region Implementation (data)

            private PropertyCollection _collection;

            #endregion

            #region Construction

            internal ReadOnlyPropertyCollection(PropertyCollection list)
                : base(Tag.Default)
            {
                _collection = list;
            }

            #endregion

            #region Type-safe ICollection

            public override void CopyTo(Property[] array)
            {
                _collection.CopyTo(array);
            }

            public override void CopyTo(Property[] array, int start)
            {
                _collection.CopyTo(array, start);
            }

            public override int Count
            {
                get { return _collection.Count; }
            }

            public override bool IsSynchronized
            {
                get { return _collection.IsSynchronized; }
            }

            public override object SyncRoot
            {
                get { return _collection.SyncRoot; }
            }

            #endregion

            #region Type-safe IList

            public override Property this[int i]
            {
                get { return _collection[i]; }
                set { throw new NotSupportedException("This is a Read Only Collection and can not be modified"); }
            }

            public override int Add(Property x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override void Clear()
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override bool Contains(Property x)
            {
                return _collection.Contains(x);
            }

            public override int IndexOf(Property x)
            {
                return _collection.IndexOf(x);
            }

            public override void Insert(int pos, Property x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override void Remove(Property x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override void RemoveAt(int pos)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override bool IsFixedSize
            {
                get { return true; }
            }

            public override bool IsReadOnly
            {
                get { return true; }
            }

            #endregion

            #region Type-safe IEnumerable

            public override IPropertyCollectionEnumerator GetEnumerator()
            {
                return _collection.GetEnumerator();
            }

            #endregion

            #region Public Helpers

            // (just to mimic some nice features of ArrayList)
            public override int Capacity
            {
                get { return _collection.Capacity; }

                set { throw new NotSupportedException("This is a Read Only Collection and can not be modified"); }
            }

            public override int AddRange(PropertyCollection x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override int AddRange(Property[] x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            #endregion
        }

        #endregion
    }
}