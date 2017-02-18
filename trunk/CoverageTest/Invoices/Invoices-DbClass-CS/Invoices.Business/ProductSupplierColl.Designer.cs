using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductSupplierColl (editable child list).<br/>
    /// This is a generated base class of <see cref="ProductSupplierColl"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="ProductEdit"/> editable root object.<br/>
    /// The items of the collection are <see cref="ProductSupplierItem"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class ProductSupplierColl : BusinessBindingListBase<ProductSupplierColl, ProductSupplierItem>
#else
    public partial class ProductSupplierColl : BusinessListBase<ProductSupplierColl, ProductSupplierItem>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="ProductSupplierItem"/> item from the collection.
        /// </summary>
        /// <param name="productSupplierId">The ProductSupplierId of the item to be removed.</param>
        public void Remove(int productSupplierId)
        {
            foreach (var productSupplierItem in this)
            {
                if (productSupplierItem.ProductSupplierId == productSupplierId)
                {
                    Remove(productSupplierItem);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="ProductSupplierItem"/> item is in the collection.
        /// </summary>
        /// <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductSupplierItem is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int productSupplierId)
        {
            foreach (var productSupplierItem in this)
            {
                if (productSupplierItem.ProductSupplierId == productSupplierId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="ProductSupplierItem"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="productSupplierId">The ProductSupplierId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductSupplierItem is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int productSupplierId)
        {
            foreach (var productSupplierItem in DeletedList)
            {
                if (productSupplierItem.ProductSupplierId == productSupplierId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSupplierColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductSupplierColl()
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
        /// Loads all <see cref="ProductSupplierColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(DataPortal.FetchChild<ProductSupplierItem>(dr));
            }
            OnFetchPost(args);
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
