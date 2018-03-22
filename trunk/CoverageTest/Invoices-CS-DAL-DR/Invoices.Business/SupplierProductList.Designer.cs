using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// SupplierProductList (read only list).<br/>
    /// This is a generated base class of <see cref="SupplierProductList"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="SupplierInfoDetail"/> read only object.<br/>
    /// The items of the collection are <see cref="SupplierProductInfo"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class SupplierProductList : ReadOnlyBindingListBase<SupplierProductList, SupplierProductInfo>
#else
    public partial class SupplierProductList : ReadOnlyListBase<SupplierProductList, SupplierProductInfo>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="SupplierProductInfo"/> item is in the collection.
        /// </summary>
        /// <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        /// <returns><c>true</c> if the SupplierProductInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int productSupplierId)
        {
            foreach (var supplierProductInfo in this)
            {
                if (supplierProductInfo.ProductSupplierId == productSupplierId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierProductList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SupplierProductList()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="SupplierProductList"/> collection from the database, based on given criteria.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        protected void DataPortal_Fetch(int supplierId)
        {
            var args = new DataPortalHookArgs(supplierId);
            OnFetchPre(args);
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var dal = dalManager.GetProvider<ISupplierProductListDal>();
                var data = dal.Fetch(supplierId);
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
        /// Loads all <see cref="SupplierProductList"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<SupplierProductInfo>(dr));
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

    }
}
