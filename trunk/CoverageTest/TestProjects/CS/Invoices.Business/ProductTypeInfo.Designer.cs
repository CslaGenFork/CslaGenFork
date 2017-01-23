using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeInfo (read only object).<br/>
    /// This is a generated base class of <see cref="ProductTypeInfo"/> business object.
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
        /// Maintains metadata about <see cref="Description"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(p => p.Description, "Description");
        /// <summary>
        /// Gets the Description.
        /// </summary>
        /// <value>The Description.</value>
        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
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

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductTypeInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"));
            LoadProperty(DescriptionProperty, dr.GetString("Description"));
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
