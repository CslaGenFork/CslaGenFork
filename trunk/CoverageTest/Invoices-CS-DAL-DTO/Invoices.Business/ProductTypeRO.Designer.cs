using System;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeRO (read only object).<br/>
    /// This is a generated <see cref="ProductTypeRO"/> business object.
    /// This class is a root object.
    /// </summary>
    [Serializable]
    public partial class ProductTypeRO : ReadOnlyBase<ProductTypeRO>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="ProductTypeId"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ProductTypeIdProperty = RegisterProperty<int>(p => p.ProductTypeId, "Product Type Id");
        /// <summary>
        /// Gets the Product Type Id.
        /// </summary>
        /// <value>The Product Type Id.</value>
        public int ProductTypeId
        {
            get { return GetProperty(ProductTypeIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(p => p.Name, "Name");
        /// <summary>
        /// Gets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name
        {
            get { return GetProperty(NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="ProductTypeRO"/> object, based on given parameters.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId parameter of the ProductTypeRO to fetch.</param>
        /// <returns>A reference to the fetched <see cref="ProductTypeRO"/> object.</returns>
        public static ProductTypeRO GetProductTypeRO(int productTypeId)
        {
            return DataPortal.Fetch<ProductTypeRO>(productTypeId);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductTypeRO"/> object, based on given parameters.
        /// </summary>
        /// <param name="productTypeId">The ProductTypeId parameter of the ProductTypeRO to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductTypeRO(int productTypeId, EventHandler<DataPortalResult<ProductTypeRO>> callback)
        {
            DataPortal.BeginFetch<ProductTypeRO>(productTypeId, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeRO"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeRO()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductTypeRO"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="productTypeId">The Product Type Id.</param>
        protected void DataPortal_Fetch(int productTypeId)
        {
            var args = new DataPortalHookArgs(productTypeId);
            OnFetchPre(args);
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var dal = dalManager.GetProvider<IProductTypeRODal>();
                var data = dal.Fetch(productTypeId);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        /// <summary>
        /// Loads a <see cref="ProductTypeRO"/> object from the given <see cref="ProductTypeRODto"/>.
        /// </summary>
        /// <param name="data">The ProductTypeRODto to use.</param>
        private void Fetch(ProductTypeRODto data)
        {
            // Value properties
            LoadProperty(ProductTypeIdProperty, data.ProductTypeId);
            LoadProperty(NameProperty, data.Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
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

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
