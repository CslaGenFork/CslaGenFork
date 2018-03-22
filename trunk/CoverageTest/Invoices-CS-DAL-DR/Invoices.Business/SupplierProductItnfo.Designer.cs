using System;
using System.Data;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// SupplierProductItnfo (read only object).<br/>
    /// This is a generated base class of <see cref="SupplierProductItnfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="SupplierProductList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class SupplierProductItnfo : ReadOnlyBase<SupplierProductItnfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="ProductSupplierId"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ProductSupplierIdProperty = RegisterProperty<int>(p => p.ProductSupplierId, "Product Supplier Id");
        /// <summary>
        /// Gets the Product Supplier Id.
        /// </summary>
        /// <value>The Product Supplier Id.</value>
        public int ProductSupplierId
        {
            get { return GetProperty(ProductSupplierIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ProductId"/> property.
        /// </summary>
        public static readonly PropertyInfo<Guid> ProductIdProperty = RegisterProperty<Guid>(p => p.ProductId, "Product Id");
        /// <summary>
        /// Gets the Product Id.
        /// </summary>
        /// <value>The Product Id.</value>
        public Guid ProductId
        {
            get { return GetProperty(ProductIdProperty); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierProductItnfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SupplierProductItnfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="SupplierProductItnfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(ProductSupplierIdProperty, dr.GetInt32("ProductSupplierId"));
            LoadProperty(ProductIdProperty, dr.GetGuid("ProductId"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
