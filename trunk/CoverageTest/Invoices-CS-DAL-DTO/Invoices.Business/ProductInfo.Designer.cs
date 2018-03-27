using System;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// ProductInfo (read only object).<br/>
    /// This is a generated <see cref="ProductInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="ProductList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class ProductInfo : ReadOnlyBase<ProductInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="ProductId"/> property.
        /// </summary>
        public static readonly PropertyInfo<Guid> ProductIdProperty = RegisterProperty<Guid>(p => p.ProductId, "Product Id", Guid.NewGuid());
        /// <summary>
        /// Gets the Product Id.
        /// </summary>
        /// <value>The Product Id.</value>
        public Guid ProductId
        {
            get { return GetProperty(ProductIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ProductCode"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ProductCodeProperty = RegisterProperty<string>(p => p.ProductCode, "Product Code", null);
        /// <summary>
        /// Gets the Product Code.
        /// </summary>
        /// <value>The Product Code.</value>
        public string ProductCode
        {
            get { return GetProperty(ProductCodeProperty); }
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
        /// Maintains metadata about <see cref="UnitCost"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> UnitCostProperty = RegisterProperty<string>(p => p.UnitCost, "Unit Cost");
        /// <summary>
        /// Gets the Unit Cost.
        /// </summary>
        /// <value>The Unit Cost.</value>
        public string UnitCost
        {
            get { return GetProperty(UnitCostProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockByteNull"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte?> StockByteNullProperty = RegisterProperty<byte?>(p => p.StockByteNull, "Stock Byte Null", null);
        /// <summary>
        /// Gets the Stock Byte Null.
        /// </summary>
        /// <value>The Stock Byte Null.</value>
        public byte? StockByteNull
        {
            get { return GetProperty(StockByteNullProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockByte"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> StockByteProperty = RegisterProperty<byte>(p => p.StockByte, "Stock Byte");
        /// <summary>
        /// Gets the Stock Byte.
        /// </summary>
        /// <value>The Stock Byte.</value>
        public byte StockByte
        {
            get { return GetProperty(StockByteProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockShortNull"/> property.
        /// </summary>
        public static readonly PropertyInfo<short?> StockShortNullProperty = RegisterProperty<short?>(p => p.StockShortNull, "Stock Short Null", null);
        /// <summary>
        /// Gets the Stock Short Null.
        /// </summary>
        /// <value>The Stock Short Null.</value>
        public short? StockShortNull
        {
            get { return GetProperty(StockShortNullProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockShort"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> StockShortProperty = RegisterProperty<short>(p => p.StockShort, "Stock Short");
        /// <summary>
        /// Gets the Stock Short.
        /// </summary>
        /// <value>The Stock Short.</value>
        public short StockShort
        {
            get { return GetProperty(StockShortProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockIntNull"/> property.
        /// </summary>
        public static readonly PropertyInfo<int?> StockIntNullProperty = RegisterProperty<int?>(p => p.StockIntNull, "Stock Int Null", null);
        /// <summary>
        /// Gets the Stock Int Null.
        /// </summary>
        /// <value>The Stock Int Null.</value>
        public int? StockIntNull
        {
            get { return GetProperty(StockIntNullProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockInt"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> StockIntProperty = RegisterProperty<int>(p => p.StockInt, "Stock Int");
        /// <summary>
        /// Gets the Stock Int.
        /// </summary>
        /// <value>The Stock Int.</value>
        public int StockInt
        {
            get { return GetProperty(StockIntProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockLongNull"/> property.
        /// </summary>
        public static readonly PropertyInfo<long?> StockLongNullProperty = RegisterProperty<long?>(p => p.StockLongNull, "Stock Long Null", null);
        /// <summary>
        /// Gets the Stock Long Null.
        /// </summary>
        /// <value>The Stock Long Null.</value>
        public long? StockLongNull
        {
            get { return GetProperty(StockLongNullProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockLong"/> property.
        /// </summary>
        public static readonly PropertyInfo<long> StockLongProperty = RegisterProperty<long>(p => p.StockLong, "Stock Long");
        /// <summary>
        /// Gets the Stock Long.
        /// </summary>
        /// <value>The Stock Long.</value>
        public long StockLong
        {
            get { return GetProperty(StockLongProperty); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="ProductInfo"/> object from the given <see cref="ProductInfoDto"/>.
        /// </summary>
        /// <param name="data">The ProductInfoDto to use.</param>
        private void Child_Fetch(ProductInfoDto data)
        {
            // Value properties
            LoadProperty(ProductIdProperty, data.ProductId);
            LoadProperty(ProductCodeProperty, data.ProductCode);
            LoadProperty(NameProperty, data.Name);
            LoadProperty(ProductTypeIdProperty, data.ProductTypeId);
            LoadProperty(UnitCostProperty, data.UnitCost);
            LoadProperty(StockByteNullProperty, data.StockByteNull);
            LoadProperty(StockByteProperty, data.StockByte);
            LoadProperty(StockShortNullProperty, data.StockShortNull);
            LoadProperty(StockShortProperty, data.StockShort);
            LoadProperty(StockIntNullProperty, data.StockIntNull);
            LoadProperty(StockIntProperty, data.StockInt);
            LoadProperty(StockLongNullProperty, data.StockLongNull);
            LoadProperty(StockLongProperty, data.StockLong);
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
