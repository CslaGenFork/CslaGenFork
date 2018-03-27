using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeColl (editable root list).<br/>
    /// This is a generated <see cref="ProductTypeColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="ProductTypeItem"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class ProductTypeColl : BusinessBindingListBase<ProductTypeColl, ProductTypeItem>
#else
    public partial class ProductTypeColl : BusinessListBase<ProductTypeColl, ProductTypeItem>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="ProductTypeItem"/> item from the collection.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the item to be removed.</param>
        public void Remove(int productTypeId)
        {
            foreach (var productTypeItem in this)
            {
                if (productTypeItem.ProductTypeId == productTypeId)
                {
                    Remove(productTypeItem);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="ProductTypeItem"/> item is in the collection.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductTypeItem is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int productTypeId)
        {
            foreach (var productTypeItem in this)
            {
                if (productTypeItem.ProductTypeId == productTypeId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="ProductTypeItem"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductTypeItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int productTypeId)
        {
            foreach (var productTypeItem in DeletedList)
            {
                if (productTypeItem.ProductTypeId == productTypeId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="ProductTypeColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="ProductTypeColl"/> collection.</returns>
        public static ProductTypeColl NewProductTypeColl()
        {
            return DataPortal.Create<ProductTypeColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="ProductTypeColl"/> collection.</returns>
        public static ProductTypeColl GetProductTypeColl()
        {
            return DataPortal.Fetch<ProductTypeColl>();
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="ProductTypeColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewProductTypeColl(EventHandler<DataPortalResult<ProductTypeColl>> callback)
        {
            DataPortal.BeginCreate<ProductTypeColl>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeColl(EventHandler<DataPortalResult<ProductTypeColl>> callback)
        {
            DataPortal.BeginFetch<ProductTypeColl>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeColl()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnProductTypeCollSaved;

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Cache Invalidation

        // TODO: edit "ProductTypeColl.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     Saved += OnProductTypeCollSaved;

        private void OnProductTypeCollSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            // this runs on the client
            ProductTypeCachedList.InvalidateCache();
            ProductTypeCachedNVL.InvalidateCache();
        }

        /// <summary>
        /// Called by the server-side DataPortal after calling the requested DataPortal_XYZ method.
        /// </summary>
        /// <param name="e">The DataPortalContext object passed to the DataPortal.</param>
        protected override void DataPortal_OnDataPortalInvokeComplete(Csla.DataPortalEventArgs e)
        {
            if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Server &&
                e.Operation == DataPortalOperations.Update)
            {
                // this runs on the server
                ProductTypeCachedNVL.InvalidateCache();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductTypeColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeColl", ctx.Connection))
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
        /// Loads all <see cref="ProductTypeColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<ProductTypeItem>(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="ProductTypeColl"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                base.Child_Update();
            }
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

    }
}
