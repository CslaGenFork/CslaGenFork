using System;
using System.Data;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeCachedInfo (read only object).<br/>
    /// This is a generated base class of <see cref="ProductTypeCachedInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="ProductTypeCachedList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class ProductTypeCachedInfo : ReadOnlyBase<ProductTypeCachedInfo>
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

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeCachedInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeCachedInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Update properties on saved object event

        /// <summary>
        /// Existing <see cref="ProductTypeCachedInfo"/> object is updated by <see cref="ProductTypeItem"/> Saved event.
        /// </summary>
        internal static ProductTypeCachedInfo LoadInfo(ProductTypeItem productTypeItem)
        {
            var info = new ProductTypeCachedInfo();
            info.UpdatePropertiesOnSaved(productTypeItem);
            return info;
        }

        /// <summary>
        /// Properties on <see cref="ProductTypeCachedInfo"/> object are updated by <see cref="ProductTypeItem"/> Saved event.
        /// </summary>
        internal void UpdatePropertiesOnSaved(ProductTypeItem productTypeItem)
        {
            LoadProperty(ProductTypeIdProperty, productTypeItem.ProductTypeId);
            LoadProperty(NameProperty, productTypeItem.Name);
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductTypeCachedInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"));
            LoadProperty(NameProperty, dr.GetString("Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
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
