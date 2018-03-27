using System;
using System.Collections.Generic;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// ProductList (read only list).<br/>
    /// This is a generated <see cref="ProductList"/> business object.
    /// This class is a root collection.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="ProductInfo"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class ProductList : ReadOnlyBindingListBase<ProductList, ProductInfo>
#else
    public partial class ProductList : ReadOnlyListBase<ProductList, ProductInfo>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="ProductInfo"/> item is in the collection.
        /// </summary>
        /// <param name="productId">The ProductId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductInfo is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(Guid productId)
        {
            foreach (var productInfo in this)
            {
                if (productInfo.ProductId == productId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="ProductList"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="ProductList"/> collection.</returns>
        public static ProductList GetProductList()
        {
            return DataPortal.Fetch<ProductList>();
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductList"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductList(EventHandler<DataPortalResult<ProductList>> callback)
        {
            DataPortal.BeginFetch<ProductList>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductList"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductList()
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
        /// Loads a <see cref="ProductList"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            var args = new DataPortalHookArgs();
            OnFetchPre(args);
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var dal = dalManager.GetProvider<IProductListDal>();
                var data = dal.Fetch();
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads all <see cref="ProductList"/> collection items from the given list of ProductInfoDto.
        /// </summary>
        /// <param name="data">The list of <see cref="ProductInfoDto"/>.</param>
        private void Fetch(List<ProductInfoDto> data)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            foreach (var dto in data)
            {
                Add(DataPortal.FetchChild<ProductInfo>(dto));
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
