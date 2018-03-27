using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// SupplierList (read only list).<br/>
    /// This is a generated <see cref="SupplierList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="SupplierInfo"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class SupplierList : ReadOnlyBindingListBase<SupplierList, SupplierInfo>
#else
    public partial class SupplierList : ReadOnlyListBase<SupplierList, SupplierInfo>
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
        /// Determines whether a <see cref="SupplierInfo"/> item is in the collection.
        /// </summary>
        /// <param name="supplierId">The SupplierId of the item to search for.</param>
        /// <returns><c>true</c> if the SupplierInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int supplierId)
        {
            foreach (var supplierInfo in this)
            {
                if (supplierInfo.SupplierId == supplierId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Private Fields

        private static SupplierList _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory SupplierList cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(SupplierList list)
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
        /// Factory method. Loads a <see cref="SupplierList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="SupplierList"/> collection.</returns>
        public static SupplierList GetSupplierList()
        {
            if (_list == null)
                _list = DataPortal.Fetch<SupplierList>();

            return _list;
        }

        /// <summary>
        /// Factory method. Loads a <see cref="SupplierList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="name">The Name parameter of the SupplierList to fetch.</param>
        /// <returns>A reference to the fetched <see cref="SupplierList"/> collection.</returns>
        public static SupplierList GetSupplierList(string name)
        {
            return DataPortal.Fetch<SupplierList>(name);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="SupplierList"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetSupplierList(EventHandler<DataPortalResult<SupplierList>> callback)
        {
            if (_list == null)
                DataPortal.BeginFetch<SupplierList>((o, e) =>
                    {
                        _list = e.Object;
                        callback(o, e);
                    });
            else
                callback(null, new DataPortalResult<SupplierList>(_list, null, null));
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="SupplierList"/> collection, based on given parameters.
        /// </summary>
        /// <param name="name">The Name parameter of the SupplierList to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetSupplierList(string name, EventHandler<DataPortalResult<SupplierList>> callback)
        {
            DataPortal.BeginFetch<SupplierList>(name, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SupplierList()
        {
            // Use factory methods and do not use direct creation.
            SupplierEditSaved.Register(this);

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
        /// Handle Saved events of <see cref="SupplierEdit"/> to update the list of <see cref="SupplierInfo"/> objects.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        internal void SupplierEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            var obj = (SupplierEdit)e.NewObject;
            if (((SupplierEdit)sender).IsNew)
            {
                IsReadOnly = false;
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = true;
                Add(SupplierInfo.LoadInfo(obj));
                RaiseListChangedEvents = rlce;
                IsReadOnly = true;
            }
            else if (((SupplierEdit)sender).IsDeleted)
            {
                for (int index = 0; index < this.Count; index++)
                {
                    var child = this[index];
                    if (child.SupplierId == obj.SupplierId)
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
                    if (child.SupplierId == obj.SupplierId)
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
        /// Loads a <see cref="SupplierList"/> collection from the database or from the cache.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                GetQueryGetSupplierList();
                using (var cmd = new SqlCommand(getSupplierListInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            _list = this;
        }

        private void LoadCachedList()
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AddRange(_list);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads a <see cref="SupplierList"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="name">The Name.</param>
        protected void DataPortal_Fetch(string name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                GetQueryGetSupplierListByName(name);
                using (var cmd = new SqlCommand(getSupplierListByNameInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", name).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd, name);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="SupplierList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<SupplierInfo>(dr));
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion

        #region Inline queries fields and partial methods

        [NotUndoable, NonSerialized]
        private string getSupplierListInlineQuery;

        [NotUndoable, NonSerialized]
        private string getSupplierListByNameInlineQuery;

        partial void GetQueryGetSupplierList();

        partial void GetQueryGetSupplierListByName(string name);

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

        #region SupplierEditSaved nested class

        // TODO: edit "SupplierList.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     SupplierEditSaved.Register(this);

        /// <summary>
        /// Nested class to manage the Saved events of <see cref="SupplierEdit"/>
        /// to update the list of <see cref="SupplierInfo"/> objects.
        /// </summary>
        private static class SupplierEditSaved
        {
            private static List<WeakReference> _references;

            private static bool Found(object obj)
            {
                return _references.Any(reference => Equals(reference.Target, obj));
            }

            /// <summary>
            /// Registers a SupplierList instance to handle Saved events.
            /// to update the list of <see cref="SupplierInfo"/> objects.
            /// </summary>
            /// <param name="obj">The SupplierList instance.</param>
            public static void Register(SupplierList obj)
            {
                var mustRegister = _references == null;

                if (mustRegister)
                    _references = new List<WeakReference>();

                if (SupplierList.SingleInstanceSavedHandler)
                    _references.Clear();

                if (!Found(obj))
                    _references.Add(new WeakReference(obj));

                if (mustRegister)
                    SupplierEdit.SupplierEditSaved += SupplierEditSavedHandler;
            }

            /// <summary>
            /// Handles Saved events of <see cref="SupplierEdit"/>.
            /// </summary>
            /// <param name="sender">The sender of the event.</param>
            /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            public static void SupplierEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
            {
                foreach (var reference in _references)
                {
                    if (reference.IsAlive)
                        ((SupplierList) reference.Target).SupplierEditSavedHandler(sender, e);
                }
            }

            /// <summary>
            /// Removes event handling and clears all registered SupplierList instances.
            /// </summary>
            public static void Unregister()
            {
                SupplierEdit.SupplierEditSaved -= SupplierEditSavedHandler;
                _references = null;
            }
        }

        #endregion

    }
}
