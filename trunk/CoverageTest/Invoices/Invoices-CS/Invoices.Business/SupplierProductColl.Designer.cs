using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// SupplierProductColl (editable child list).<br/>
    /// This is a generated <see cref="SupplierProductColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="SupplierEdit"/> editable root object.<br/>
    /// The items of the collection are <see cref="SupplierProductItem"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class SupplierProductColl : BusinessBindingListBase<SupplierProductColl, SupplierProductItem>
#else
    public partial class SupplierProductColl : BusinessListBase<SupplierProductColl, SupplierProductItem>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="SupplierProductItem"/> item from the collection.
        /// </summary>
        /// <param name="productSupplierId">The ProductSupplierId of the item to be removed.</param>
        public void Remove(int productSupplierId)
        {
            foreach (var supplierProductItem in this)
            {
                if (supplierProductItem.ProductSupplierId == productSupplierId)
                {
                    Remove(supplierProductItem);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="SupplierProductItem"/> item is in the collection.
        /// </summary>
        /// <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        /// <returns><c>true</c> if the SupplierProductItem is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int productSupplierId)
        {
            foreach (var supplierProductItem in this)
            {
                if (supplierProductItem.ProductSupplierId == productSupplierId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="SupplierProductItem"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        /// <returns><c>true</c> if the SupplierProductItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int productSupplierId)
        {
            foreach (var supplierProductItem in DeletedList)
            {
                if (supplierProductItem.ProductSupplierId == productSupplierId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierProductColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SupplierProductColl()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="SupplierProductColl"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        protected void DataPortal_Fetch(int supplierId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetSupplierProductColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, supplierId);
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
        /// Loads all <see cref="SupplierProductColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<SupplierProductItem>(dr));
            }
            RaiseListChangedEvents = rlce;
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
