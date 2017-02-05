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
    /// ProductTypeUpdatedByRootList (read only list).<br/>
    /// This is a generated base class of <see cref="ProductTypeUpdatedByRootList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="ProductTypeUpdatedByRootInfo"/> objects.
    /// Updated by ProductTypeEdit
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class ProductTypeUpdatedByRootList : ReadOnlyBindingListBase<ProductTypeUpdatedByRootList, ProductTypeUpdatedByRootInfo>
#else
    public partial class ProductTypeUpdatedByRootList : ReadOnlyListBase<ProductTypeUpdatedByRootList, ProductTypeUpdatedByRootInfo>
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
        /// Determines whether a <see cref="ProductTypeUpdatedByRootInfo"/> item is in the collection.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductTypeUpdatedByRootInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int productTypeId)
        {
            foreach (var productTypeUpdatedByRootInfo in this)
            {
                if (productTypeUpdatedByRootInfo.ProductTypeId == productTypeId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeUpdatedByRootList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="ProductTypeUpdatedByRootList"/> collection.</returns>
        public static ProductTypeUpdatedByRootList GetProductTypeUpdatedByRootList()
        {
            return DataPortal.Fetch<ProductTypeUpdatedByRootList>();
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeUpdatedByRootList"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeUpdatedByRootList(EventHandler<DataPortalResult<ProductTypeUpdatedByRootList>> callback)
        {
            DataPortal.BeginFetch<ProductTypeUpdatedByRootList>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeUpdatedByRootList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeUpdatedByRootList()
        {
            // Use factory methods and do not use direct creation.
            ProductTypeEditSaved.Register(this);

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
        /// Handle Saved events of <see cref="ProductTypeEdit"/> to update the list of <see cref="ProductTypeUpdatedByRootInfo"/> objects.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
        internal void ProductTypeEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
        {
            var obj = (ProductTypeEdit)e.NewObject;
            if (((ProductTypeEdit)sender).IsNew)
            {
                IsReadOnly = false;
                var rlce = RaiseListChangedEvents;
                RaiseListChangedEvents = true;
                Add(ProductTypeUpdatedByRootInfo.LoadInfo(obj));
                RaiseListChangedEvents = rlce;
                IsReadOnly = true;
            }
            else if (((ProductTypeEdit)sender).IsDeleted)
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
        /// Loads a <see cref="ProductTypeUpdatedByRootList"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InvoicesDatabase"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeUpdatedByRootList", ctx.Connection))
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
        /// Loads all <see cref="ProductTypeUpdatedByRootList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<ProductTypeUpdatedByRootInfo>(dr));
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

        #region ProductTypeEditSaved nested class

        // TODO: edit "ProductTypeUpdatedByRootList.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     ProductTypeEditSaved.Register(this);

        /// <summary>
        /// Nested class to manage the Saved events of <see cref="ProductTypeEdit"/>
        /// to update the list of <see cref="ProductTypeUpdatedByRootInfo"/> objects.
        /// </summary>
        private static class ProductTypeEditSaved
        {
            private static List<WeakReference> _references;

            private static bool Found(object obj)
            {
                return _references.Any(reference => Equals(reference.Target, obj));
            }

            /// <summary>
            /// Registers a ProductTypeUpdatedByRootList instance to handle Saved events.
            /// to update the list of <see cref="ProductTypeUpdatedByRootInfo"/> objects.
            /// </summary>
            /// <param name="obj">The ProductTypeUpdatedByRootList instance.</param>
            public static void Register(ProductTypeUpdatedByRootList obj)
            {
                var mustRegister = _references == null;

                if (mustRegister)
                    _references = new List<WeakReference>();

                if (ProductTypeUpdatedByRootList.SingleInstanceSavedHandler)
                    _references.Clear();

                if (!Found(obj))
                    _references.Add(new WeakReference(obj));

                if (mustRegister)
                    ProductTypeEdit.ProductTypeEditSaved += ProductTypeEditSavedHandler;
            }

            /// <summary>
            /// Handles Saved events of <see cref="ProductTypeEdit"/>.
            /// </summary>
            /// <param name="sender">The sender of the event.</param>
            /// <param name="e">The <see cref="Csla.Core.SavedEventArgs"/> instance containing the event data.</param>
            public static void ProductTypeEditSavedHandler(object sender, Csla.Core.SavedEventArgs e)
            {
                foreach (var reference in _references)
                {
                    if (reference.IsAlive)
                        ((ProductTypeUpdatedByRootList) reference.Target).ProductTypeEditSavedHandler(sender, e);
                }
            }

            /// <summary>
            /// Removes event handling and clears all registered ProductTypeUpdatedByRootList instances.
            /// </summary>
            public static void Unregister()
            {
                ProductTypeEdit.ProductTypeEditSaved -= ProductTypeEditSavedHandler;
                _references = null;
            }
        }

        #endregion

    }
}
