using System;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeInfo (read only object).<br/>
    /// This is a generated <see cref="ProductTypeInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="ProductTypeList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class ProductTypeInfo : ReadOnlyBase<ProductTypeInfo>
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
        /// Initializes a new instance of the <see cref="ProductTypeInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Update properties on saved object event

        /// <summary>
        /// Existing <see cref="ProductTypeInfo"/> object is updated by <see cref="ProductTypeDynaItem"/> Saved event.
        /// </summary>
        internal static ProductTypeInfo LoadInfo(ProductTypeDynaItem productTypeDynaItem)
        {
            var info = new ProductTypeInfo();
            info.UpdatePropertiesOnSaved(productTypeDynaItem);
            return info;
        }

        /// <summary>
        /// Properties on <see cref="ProductTypeInfo"/> object are updated by <see cref="ProductTypeDynaItem"/> Saved event.
        /// </summary>
        internal void UpdatePropertiesOnSaved(ProductTypeDynaItem productTypeDynaItem)
        {
            LoadProperty(ProductTypeIdProperty, productTypeDynaItem.ProductTypeId);
            LoadProperty(NameProperty, productTypeDynaItem.Name);
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductTypeInfo"/> object from the given <see cref="ProductTypeInfoDto"/>.
        /// </summary>
        /// <param name="data">The ProductTypeInfoDto to use.</param>
        private void Child_Fetch(ProductTypeInfoDto data)
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
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
