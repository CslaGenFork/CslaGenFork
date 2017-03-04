using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeCachedList (read only list).<br/>
    /// This is a generated base class of <see cref="ProductTypeCachedList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="ProductTypeCachedInfo"/> objects.
    /// Cached. Updated by ProductTypeItem
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class ProductTypeCachedList : ReadOnlyBindingListBase<ProductTypeCachedList, ProductTypeCachedInfo>
#else
    public partial class ProductTypeCachedList : ReadOnlyListBase<ProductTypeCachedList, ProductTypeCachedInfo>
#endif
    {

        #region Event handler properties

        [NotUndoable]
        private static bool _singleInstanceSavedHandler = true;

        /// <summary>
        /// Gets or sets a value indicating whether only a single instance should handle the Saved event.
        /// </summary>
        /// <value>
        /// <c>true</c> if only a single instance should handle the Saved event; otherwise, <c>false</c>.
        /// </value>
        public static bool SingleInstanceSavedHandler
        {
            get { return _singleInstanceSavedHandler; }
            set { _singleInstanceSavedHandler = value; }
        }

        #endregion

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="ProductTypeCachedInfo"/> item is in the collection.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductTypeCachedInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int productTypeId)
        {
            foreach (var productTypeCachedInfo in this)
            {
                if (productTypeCachedInfo.ProductTypeId == productTypeId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Private Fields

        private static ProductTypeCachedList _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory ProductTypeCachedList cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(ProductTypeCachedList list)
        {
            _list = list;
        }

        internal static bool IsCached
        {
            get { return _list != null; }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeCachedList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="ProductTypeCachedList"/> collection.</returns>
        public static ProductTypeCachedList GetProductTypeCachedList()
        {
            if (_list == null)
                _list = DataPortal.Fetch<ProductTypeCachedList>();

            return _list;
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeCachedList"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeCachedList(EventHandler<DataPortalResult<ProductTypeCachedList>> callback)
        {
            if (_list == null)
                DataPortal.BeginFetch<ProductTypeCachedList>((o, e) =>
                    {
                        _list = e.Object;
                        callback(o, e);
                    });
            else
                callback(null, new DataPortalResult<ProductTypeCachedList>(_list, null, null));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeCachedList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeCachedList()
        {
            // Use factory methods and do not use direct creation.
            ProductTypeItemSaved.Register(this);

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Saved Event Handler

        /// <summary>
        /// Handle Saved events of <see cref="ProductTypeItem"/> to update the list of <see cref="ProductTypeCachedInfo"/> objects.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        internal void ProductTypeItemSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            var obj = (ProductTypeItem)e.NewObject;
            if (((ProductTypeItem)sender).IsNew)
            {
                IsReadOnly = false;
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = true;
                Add(ProductTypeCachedInfo.LoadInfo(obj));
                RaiseListChangedEvents = rlce;
                IsReadOnly = true;
            }
            else if (((ProductTypeItem)sender).IsDeleted)
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.ProductTypeId == obj.ProductTypeId)
                    {
                        IsReadOnly = false;
                        var rlce = RaiseListChangedEvents;
                        RaiseListChangedEvents = true;
                        this.RemoveItem(index);
                        RaiseListChangedEvents = rlce;
                        IsReadOnly = true;
                        break;
                    }
                }
            }
            else
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.ProductTypeId == obj.ProductTypeId)
                    {
                        child.UpdatePropertiesOnSaved(obj);
#if !WINFORMS
                        var notifyCollectionChangedEventArgs =
                            new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, child, child, index);
                        OnCollectionChanged(notifyCollectionChangedEventArgs);
#else
                        var listChangedEventArgs = new ListChangedEventArgs(ListChangedType.ItemChanged, index);
                        OnListChanged(listChangedEventArgs);
#endif
                        break;
                    }
                }
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductTypeCachedList"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            var args = new DataPortalHookArgs();
            OnFetchPre(args);
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var dal = dalManager.GetProvider<IProductTypeCachedListDal>();
                var data = dal.Fetch();
                LoadCollection(data);
            }
            OnFetchPost(args);
        }

        private void LoadCollection(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="ProductTypeCachedList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<ProductTypeCachedInfo>(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

        #region ProductTypeItemSaved nested class

        // TODO: edit "ProductTypeCachedList.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     ProductTypeItemSaved.Register(this);

        /// <summary>
        /// Nested class to manage the Saved events of <see cref="ProductTypeItem"/>
        /// to update the list of <see cref="ProductTypeCachedInfo"/> objects.
        /// </summary>
        private static class ProductTypeItemSaved
        {
            private static List<WeakReference> _references;

            private static bool Found(object obj)
            {
                return _references.Any(reference => Equals(reference.Target, obj));
            }

            /// <summary>
            /// Registers a ProductTypeCachedList instance to handle Saved events.
            /// to update the list of <see cref="ProductTypeCachedInfo"/> objects.
            /// </summary>
            /// <param name="obj">The ProductTypeCachedList instance.</param>
            public static void Register(ProductTypeCachedList obj)
            {
                var mustRegister = _references == null;

                if (mustRegister)
                    _references = new List<WeakReference>();

                if (ProductTypeCachedList.SingleInstanceSavedHandler)
                    _references.Clear();

                if (!Found(obj))
                    _references.Add(new WeakReference(obj));

                if (mustRegister)
                    ProductTypeItem.ProductTypeItemSaved += ProductTypeItemSavedHandler;
            }

            /// <summary>
            /// Handles Saved events of <see cref="ProductTypeItem"/>.
            /// </summary>
            /// <param name="sender">The sender of the event.</param>
            /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            public static void ProductTypeItemSavedHandler(object sender, Csla.Core.SavedEventArgs e)
            {
                foreach (var reference in _references)
                {
                    if (reference.IsAlive)
                        ((ProductTypeCachedList) reference.Target).ProductTypeItemSavedHandler(sender, e);
                }
            }

            /// <summary>
            /// Removes event handling and clears all registered ProductTypeCachedList instances.
            /// </summary>
            public static void Unregister()
            {
                ProductTypeItem.ProductTypeItemSaved -= ProductTypeItemSavedHandler;
                _references = null;
            }
        }

        #endregion

    }
}
