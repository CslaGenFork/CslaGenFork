using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// ProductTypeDyna (dynamic root object).<br/>
    /// This is a generated base class of <see cref="ProductTypeDyna"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="ProductTypeDynaColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class ProductTypeDyna : BusinessBase<ProductTypeDyna>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="ProductTypeId"/> property.
        /// </summary>
        [NotUndoable]
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
        /// Maintains metadata about <see cref="Description"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(p => p.Description, "Description");
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>The Description.</value>
        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTypeDyna"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ProductTypeDyna()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="ProductTypeDyna"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="ProductTypeDyna"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void DataPortal_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(ProductTypeIdProperty, dr.GetInt32("ProductTypeId"));
            LoadProperty(DescriptionProperty, dr.GetString("Description"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Inserts a new <see cref="ProductTypeDyna"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InvoicesDatabase"))
            {
                using (var cmd = new SqlCommand("dbo.AddProductTypeDyna", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", ReadProperty(ProductTypeIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Description", ReadProperty(DescriptionProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="ProductTypeDyna"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InvoicesDatabase"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateProductTypeDyna", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", ReadProperty(ProductTypeIdProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Description", ReadProperty(DescriptionProperty)).DbType = DbType.String;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
            }
        }

        /// <summary>
        /// Self deletes the <see cref="ProductTypeDyna"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(ProductTypeId);
        }

        /// <summary>
        /// Deletes the <see cref="ProductTypeDyna"/> object from database.
        /// </summary>
        /// <param name="productTypeId">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(int productTypeId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("InvoicesDatabase"))
            {
                using (var cmd = new SqlCommand("dbo.DeleteProductTypeDyna", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, productTypeId);
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
