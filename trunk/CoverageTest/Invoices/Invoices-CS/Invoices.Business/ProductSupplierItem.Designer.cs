using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductSupplierItem (editable child object).<br/>
    /// This is a generated <see cref="ProductSupplierItem"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="ProductSupplierColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class ProductSupplierItem : BusinessBase<ProductSupplierItem>
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="ProductSupplierId"/> property.
        /// </summary>
        [NotUndoable]
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
        /// Maintains metadata about <see cref="SupplierId"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SupplierIdProperty = RegisterProperty<int>(p => p.SupplierId, "Supplier Id");
        /// <summary>
        /// Gets or sets the Supplier Id.
        /// </summary>
        /// <value>The Supplier Id.</value>
        public int SupplierId
        {
            get { return GetProperty(SupplierIdProperty); }
            set { SetProperty(SupplierIdProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSupplierItem"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductSupplierItem()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="ProductSupplierItem"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(ProductSupplierIdProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="ProductSupplierItem"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(ProductSupplierIdProperty, dr.GetInt32("ProductSupplierId"));
            LoadProperty(SupplierIdProperty, dr.GetInt32("SupplierId"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Inserts a new <see cref="ProductSupplierItem"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(ProductEdit parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.AddProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", parent.ProductId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", ReadProperty(ProductSupplierIdProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SupplierId", ReadProperty(SupplierIdProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(ProductSupplierIdProperty, (int) cmd.Parameters["@ProductSupplierId"].Value);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="ProductSupplierItem"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", ReadProperty(ProductSupplierIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SupplierId", ReadProperty(SupplierIdProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
            }
        }

        /// <summary>
        /// Self deletes the <see cref="ProductSupplierItem"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.DeleteProductSupplierItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductSupplierId", ReadProperty(ProductSupplierIdProperty)).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
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
