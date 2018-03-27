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
    /// ProductTypeList (read only list).<br/>
    /// This is a generated <see cref="ProductTypeList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="ProductTypeInfo"/> objects.
    /// No cache. Updated by ProductTypeDynaItem
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class ProductTypeList : ReadOnlyBindingListBase<ProductTypeList, ProductTypeInfo>
#else
    public partial class ProductTypeList : ReadOnlyListBase<ProductTypeList, ProductTypeInfo>
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
        /// Determines whether a <see cref="ProductTypeInfo"/> item is in the collection.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductTypeInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int productTypeId)
        {
            foreach (var productTypeInfo in this)
            {
                if (productTypeInfo.ProductTypeId == productTypeId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="ProductTypeList"/> collection.</returns>
        public static ProductTypeList GetProductTypeList()
        {
            return DataPortal.Fetch<ProductTypeList>();
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeList"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeList(EventHandler<DataPortalResult<ProductTypeList>> callback)
        {
            DataPortal.BeginFetch<ProductTypeList>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeList()
        {
            // Use factory methods and do not use direct creation.
            ProductTypeDynaItemSaved.Register(this);

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
        /// Handle Saved events of <see cref="ProductTypeDynaItem"/> to update the list of <see cref="ProductTypeInfo"/> objects.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        internal void ProductTypeDynaItemSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            var obj = (ProductTypeDynaItem)e.NewObject;
            if (((ProductTypeDynaItem)sender).IsNew)
            {
                IsReadOnly = false;
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = true;
                Add(ProductTypeInfo.LoadInfo(obj));
                RaiseListChangedEvents = rlce;
                IsReadOnly = true;
            }
            else if (((ProductTypeDynaItem)sender).IsDeleted)
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
        /// Loads a <see cref="ProductTypeList"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.InvoicesConnection, false))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
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
        /// Loads all <see cref="ProductTypeList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<ProductTypeInfo>(dr));
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

        #region ProductTypeDynaItemSaved nested class

        // TODO: edit "ProductTypeList.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     ProductTypeDynaItemSaved.Register(this);

        /// <summary>
        /// Nested class to manage the Saved events of <see cref="ProductTypeDynaItem"/>
        /// to update the list of <see cref="ProductTypeInfo"/> objects.
        /// </summary>
        private static class ProductTypeDynaItemSaved
        {
            private static List<WeakReference> _references;

            private static bool Found(object obj)
            {
                return _references.Any(reference => Equals(reference.Target, obj));
            }

            /// <summary>
            /// Registers a ProductTypeList instance to handle Saved events.
            /// to update the list of <see cref="ProductTypeInfo"/> objects.
            /// </summary>
            /// <param name="obj">The ProductTypeList instance.</param>
            public static void Register(ProductTypeList obj)
            {
                var mustRegister = _references == null;

                if (mustRegister)
                    _references = new List<WeakReference>();

                if (ProductTypeList.SingleInstanceSavedHandler)
                    _references.Clear();

                if (!Found(obj))
                    _references.Add(new WeakReference(obj));

                if (mustRegister)
                    ProductTypeDynaItem.ProductTypeDynaItemSaved += ProductTypeDynaItemSavedHandler;
            }

            /// <summary>
            /// Handles Saved events of <see cref="ProductTypeDynaItem"/>.
            /// </summary>
            /// <param name="sender">The sender of the event.</param>
            /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            public static void ProductTypeDynaItemSavedHandler(object sender, Csla.Core.SavedEventArgs e)
            {
                foreach (var reference in _references)
                {
                    if (reference.IsAlive)
                        ((ProductTypeList) reference.Target).ProductTypeDynaItemSavedHandler(sender, e);
                }
            }

            /// <summary>
            /// Removes event handling and clears all registered ProductTypeList instances.
            /// </summary>
            public static void Unregister()
            {
                ProductTypeDynaItem.ProductTypeDynaItemSaved -= ProductTypeDynaItemSavedHandler;
                _references = null;
            }
        }

        #endregion

    }
}
