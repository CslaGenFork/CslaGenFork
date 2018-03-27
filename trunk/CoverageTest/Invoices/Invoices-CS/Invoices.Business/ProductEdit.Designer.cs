using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductEdit (editable root object).<br/>
    /// This is a generated <see cref="ProductEdit"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="Suppliers"/> of type <see cref="ProductSupplierColl"/> (1:M relation to <see cref="ProductSupplierItem"/>)
    /// </remarks>
    [Serializable]
    public partial class ProductEdit : BusinessBase<ProductEdit>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="ProductId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<Guid> ProductIdProperty = RegisterProperty<Guid>(p => p.ProductId, "Product Id");
        /// <summary>
        /// Gets or sets the Product Id.
        /// </summary>
        /// <value>The Product Id.</value>
        public Guid ProductId
        {
            get { return GetProperty(ProductIdProperty); }
            set { SetProperty(ProductIdProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ProductCode"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ProductCodeProperty = RegisterProperty<string>(p => p.ProductCode, "Product Code");
        /// <summary>
        /// Gets or sets the Product Code.
        /// </summary>
        /// <value>The Product Code.</value>
        public string ProductCode
        {
            get { return GetProperty(ProductCodeProperty); }
            set { SetProperty(ProductCodeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(p => p.Name, "Name");
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ProductTypeId"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ProductTypeIdProperty = RegisterProperty<int>(p => p.ProductTypeId, "Product Type Id");
        /// <summary>
        /// Gets or sets the Product Type Id.
        /// </summary>
        /// <value>The Product Type Id.</value>
        public int ProductTypeId
        {
            get { return GetProperty(ProductTypeIdProperty); }
            set { SetProperty(ProductTypeIdProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="UnitCost"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> UnitCostProperty = RegisterProperty<string>(p => p.UnitCost, "Unit Cost");
        /// <summary>
        /// Gets or sets the Unit Cost.
        /// </summary>
        /// <value>The Unit Cost.</value>
        public string UnitCost
        {
            get { return GetProperty(UnitCostProperty); }
            set { SetProperty(UnitCostProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockByteNull"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte?> StockByteNullProperty = RegisterProperty<byte?>(p => p.StockByteNull, "Stock Byte Null");
        /// <summary>
        /// Gets or sets the Stock Byte Null.
        /// </summary>
        /// <value>The Stock Byte Null.</value>
        public byte? StockByteNull
        {
            get { return GetProperty(StockByteNullProperty); }
            set { SetProperty(StockByteNullProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockByte"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> StockByteProperty = RegisterProperty<byte>(p => p.StockByte, "Stock Byte");
        /// <summary>
        /// Gets or sets the Stock Byte.
        /// </summary>
        /// <value>The Stock Byte.</value>
        public byte StockByte
        {
            get { return GetProperty(StockByteProperty); }
            set { SetProperty(StockByteProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockShortNull"/> property.
        /// </summary>
        public static readonly PropertyInfo<short?> StockShortNullProperty = RegisterProperty<short?>(p => p.StockShortNull, "Stock Short Null");
        /// <summary>
        /// Gets or sets the Stock Short Null.
        /// </summary>
        /// <value>The Stock Short Null.</value>
        public short? StockShortNull
        {
            get { return GetProperty(StockShortNullProperty); }
            set { SetProperty(StockShortNullProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockShort"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> StockShortProperty = RegisterProperty<short>(p => p.StockShort, "Stock Short");
        /// <summary>
        /// Gets or sets the Stock Short.
        /// </summary>
        /// <value>The Stock Short.</value>
        public short StockShort
        {
            get { return GetProperty(StockShortProperty); }
            set { SetProperty(StockShortProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockIntNull"/> property.
        /// </summary>
        public static readonly PropertyInfo<int?> StockIntNullProperty = RegisterProperty<int?>(p => p.StockIntNull, "Stock Int Null");
        /// <summary>
        /// Gets or sets the Stock Int Null.
        /// </summary>
        /// <value>The Stock Int Null.</value>
        public int? StockIntNull
        {
            get { return GetProperty(StockIntNullProperty); }
            set { SetProperty(StockIntNullProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockInt"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> StockIntProperty = RegisterProperty<int>(p => p.StockInt, "Stock Int");
        /// <summary>
        /// Gets or sets the Stock Int.
        /// </summary>
        /// <value>The Stock Int.</value>
        public int StockInt
        {
            get { return GetProperty(StockIntProperty); }
            set { SetProperty(StockIntProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockLongNull"/> property.
        /// </summary>
        public static readonly PropertyInfo<long?> StockLongNullProperty = RegisterProperty<long?>(p => p.StockLongNull, "Stock Long Null");
        /// <summary>
        /// Gets or sets the Stock Long Null.
        /// </summary>
        /// <value>The Stock Long Null.</value>
        public long? StockLongNull
        {
            get { return GetProperty(StockLongNullProperty); }
            set { SetProperty(StockLongNullProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="StockLong"/> property.
        /// </summary>
        public static readonly PropertyInfo<long> StockLongProperty = RegisterProperty<long>(p => p.StockLong, "Stock Long");
        /// <summary>
        /// Gets or sets the Stock Long.
        /// </summary>
        /// <value>The Stock Long.</value>
        public long StockLong
        {
            get { return GetProperty(StockLongProperty); }
            set { SetProperty(StockLongProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="Suppliers"/> property.
        /// </summary>
        public static readonly PropertyInfo<ProductSupplierColl> SuppliersProperty = RegisterProperty<ProductSupplierColl>(p => p.Suppliers, "Suppliers", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Suppliers ("parent load" child property).
        /// </summary>
        /// <value>The Suppliers.</value>
        public ProductSupplierColl Suppliers
        {
            get { return GetProperty(SuppliersProperty); }
            private set { LoadProperty(SuppliersProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="ProductEdit"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="ProductEdit"/> object.</returns>
        public static ProductEdit NewProductEdit()
        {
            return DataPortal.Create<ProductEdit>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="ProductEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="productId">The ProductId parameter of the ProductEdit to fetch.</param>
        /// <returns>A reference to the fetched <see cref="ProductEdit"/> object.</returns>
        public static ProductEdit GetProductEdit(Guid productId)
        {
            return DataPortal.Fetch<ProductEdit>(productId);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="ProductEdit"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewProductEdit(EventHandler<DataPortalResult<ProductEdit>> callback)
        {
            DataPortal.BeginCreate<ProductEdit>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="ProductEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="productId">The ProductId parameter of the ProductEdit to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetProductEdit(Guid productId, EventHandler<DataPortalResult<ProductEdit>> callback)
        {
            DataPortal.BeginFetch<ProductEdit>(productId, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductEdit"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductEdit()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="ProductEdit"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(ProductIdProperty, Guid.NewGuid());
            LoadProperty(ProductCodeProperty, null);
            LoadProperty(SuppliersProperty, DataPortal.CreateChild<ProductSupplierColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="ProductEdit"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="productId">The Product Id.</param>
        protected void DataPortal_Fetch(Guid productId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", productId).DbType = DbType.Guid;
                    var args = new DataPortalHookArgs(cmd, productId);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    FetchChildren(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="ProductEdit"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(ProductIdProperty, dr.GetGuid("ProductId"));
            LoadProperty(ProductCodeProperty, dr.IsDBNull("ProductCode") ? null : dr.GetString("ProductCode"));
            LoadProperty(NameProperty, dr.GetString("Name"));
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"));
            LoadProperty(UnitCostProperty, dr.GetString("UnitCost"));
            LoadProperty(StockByteNullProperty, (byte?)dr.GetValue("StockByteNull"));
            LoadProperty(StockByteProperty, dr.GetByte("StockByte"));
            LoadProperty(StockShortNullProperty, (short?)dr.GetValue("StockShortNull"));
            LoadProperty(StockShortProperty, dr.GetInt16("StockShort"));
            LoadProperty(StockIntNullProperty, (int?)dr.GetValue("StockIntNull"));
            LoadProperty(StockIntProperty, dr.GetInt32("StockInt"));
            LoadProperty(StockLongNullProperty, (long?)dr.GetValue("StockLongNull"));
            LoadProperty(StockLongProperty, dr.GetInt64("StockLong"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            LoadProperty(SuppliersProperty, DataPortal.FetchChild<ProductSupplierColl>(dr));
        }

        /// <summary>
        /// Inserts a new <see cref="ProductEdit"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.AddProductEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductCode", ReadProperty(ProductCodeProperty) == null ? (object)DBNull.Value : ReadProperty(ProductCodeProperty)).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ProductTypeId", ReadProperty(ProductTypeIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@UnitCost", ReadProperty(UnitCostProperty)).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@StockByteNull", ReadProperty(StockByteNullProperty) == null ? (object)DBNull.Value : ReadProperty(StockByteNullProperty).Value).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockByte", ReadProperty(StockByteProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockShortNull", ReadProperty(StockShortNullProperty) == null ? (object)DBNull.Value : ReadProperty(StockShortNullProperty).Value).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockShort", ReadProperty(StockShortProperty)).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockIntNull", ReadProperty(StockIntNullProperty) == null ? (object)DBNull.Value : ReadProperty(StockIntNullProperty).Value).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockInt", ReadProperty(StockIntProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockLongNull", ReadProperty(StockLongNullProperty) == null ? (object)DBNull.Value : ReadProperty(StockLongNullProperty).Value).DbType = DbType.Int64;
                    cmd.Parameters.AddWithValue("@StockLong", ReadProperty(StockLongProperty)).DbType = DbType.Int64;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="ProductEdit"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateProductEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductCode", ReadProperty(ProductCodeProperty) == null ? (object)DBNull.Value : ReadProperty(ProductCodeProperty)).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ProductTypeId", ReadProperty(ProductTypeIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@UnitCost", ReadProperty(UnitCostProperty)).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@StockByteNull", ReadProperty(StockByteNullProperty) == null ? (object)DBNull.Value : ReadProperty(StockByteNullProperty).Value).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockByte", ReadProperty(StockByteProperty)).DbType = DbType.Byte;
                    cmd.Parameters.AddWithValue("@StockShortNull", ReadProperty(StockShortNullProperty) == null ? (object)DBNull.Value : ReadProperty(StockShortNullProperty).Value).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockShort", ReadProperty(StockShortProperty)).DbType = DbType.Int16;
                    cmd.Parameters.AddWithValue("@StockIntNull", ReadProperty(StockIntNullProperty) == null ? (object)DBNull.Value : ReadProperty(StockIntNullProperty).Value).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockInt", ReadProperty(StockIntProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@StockLongNull", ReadProperty(StockLongNullProperty) == null ? (object)DBNull.Value : ReadProperty(StockLongNullProperty).Value).DbType = DbType.Int64;
                    cmd.Parameters.AddWithValue("@StockLong", ReadProperty(StockLongProperty)).DbType = DbType.Int64;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

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

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
