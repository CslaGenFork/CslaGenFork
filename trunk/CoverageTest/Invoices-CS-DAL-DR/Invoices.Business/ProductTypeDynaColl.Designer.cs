using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeDynaColl (dynamic root list).<br/>
    /// This is a generated base class of <see cref="ProductTypeDynaColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="ProductTypeDynaItem"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class ProductTypeDynaColl : DynamicBindingListBase<ProductTypeDynaItem>
#else
    public partial class ProductTypeDynaColl : DynamicListBase<ProductTypeDynaItem>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="ProductTypeDynaItem"/> item is in the collection.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId of the item to search for.</param>
        /// <returns><c>true</c> if the ProductTypeDynaItem is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int productTypeId)
        {
            foreach (var productTypeDynaItem in this)
            {
                if (productTypeDynaItem.ProductTypeId == productTypeId)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="ProductTypeDynaColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="ProductTypeDynaColl"/> collection.</returns>
        public static ProductTypeDynaColl NewProductTypeDynaColl()
        {
            return DataPortal.Create<ProductTypeDynaColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeDynaColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="ProductTypeDynaColl"/> collection.</returns>
        public static ProductTypeDynaColl GetProductTypeDynaColl()
        {
            return DataPortal.Fetch<ProductTypeDynaColl>();
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="ProductTypeDynaColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewProductTypeDynaColl(EventHandler<DataPortalResult<ProductTypeDynaColl>> callback)
        {
            DataPortal.BeginCreate<ProductTypeDynaColl>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeDynaColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeDynaColl(EventHandler<DataPortalResult<ProductTypeDynaColl>> callback)
        {
            DataPortal.BeginFetch<ProductTypeDynaColl>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeDynaColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeDynaColl()
        {
            // Use factory methods and do not use direct creation.

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
        /// Loads a <see cref="ProductTypeDynaColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            var args = new DataPortalHookArgs();
            OnFetchPre(args);
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var dal = dalManager.GetProvider<IProductTypeDynaCollDal>();
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
        /// Loads all <see cref="ProductTypeDynaColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(DataPortal.Fetch<ProductTypeDynaItem>(dr));
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
