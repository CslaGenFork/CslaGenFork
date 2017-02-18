using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// InvoiceLineItem (editable child object).<br/>
    /// This is a generated base class of <see cref="InvoiceLineItem"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="InvoiceLineCollection"/> collection.
    /// </remarks>
    [Serializable]
    public partial class InvoiceLineItem : BusinessBase<InvoiceLineItem>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="InvoiceLineId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<Guid> InvoiceLineIdProperty = RegisterProperty<Guid>(p => p.InvoiceLineId, "Invoice Line Id");
        /// <summary>
        /// Gets or sets the Invoice Line Id.
        /// </summary>
        /// <value>The Invoice Line Id.</value>
        public Guid InvoiceLineId
        {
            get { return GetProperty(InvoiceLineIdProperty); }
            set { SetProperty(InvoiceLineIdProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ProductId"/> property.
        /// </summary>
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
        /// Maintains metadata about <see cref="Cost"/> property.
        /// </summary>
        public static readonly PropertyInfo<decimal> CostProperty = RegisterProperty<decimal>(p => p.Cost, "Cost");
        /// <summary>
        /// Gets or sets the Cost.
        /// </summary>
        /// <value>The Cost.</value>
        public decimal Cost
        {
            get { return GetProperty(CostProperty); }
            set { SetProperty(CostProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="PercentDiscount"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> PercentDiscountProperty = RegisterProperty<byte>(p => p.PercentDiscount, "Percent Discount");
        /// <summary>
        /// Gets or sets the Percent Discount.
        /// </summary>
        /// <value>The Percent Discount.</value>
        public byte PercentDiscount
        {
            get { return GetProperty(PercentDiscountProperty); }
            set { SetProperty(PercentDiscountProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceLineItem"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public InvoiceLineItem()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="InvoiceLineItem"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(InvoiceLineIdProperty, Guid.NewGuid());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="InvoiceLineItem"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(InvoiceLineIdProperty, dr.GetGuid("InvoiceLineId"));
            LoadProperty(ProductIdProperty, dr.GetGuid("ProductId"));
            LoadProperty(CostProperty, dr.GetDecimal("Cost"));
            LoadProperty(PercentDiscountProperty, dr.GetByte("PercentDiscount"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Inserts a new <see cref="InvoiceLineItem"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(InvoiceEdit parent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.AddInvoiceLineItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", parent.InvoiceId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@InvoiceLineId", ReadProperty(InvoiceLineIdProperty)).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@Cost", ReadProperty(CostProperty)).DbType = DbType.Decimal;
                    cmd.Parameters.AddWithValue("@PercentDiscount", ReadProperty(PercentDiscountProperty)).DbType = DbType.Byte;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="InvoiceLineItem"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateInvoiceLineItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceLineId", ReadProperty(InvoiceLineIdProperty)).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductId", ReadProperty(ProductIdProperty)).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@Cost", ReadProperty(CostProperty)).DbType = DbType.Decimal;
                    cmd.Parameters.AddWithValue("@PercentDiscount", ReadProperty(PercentDiscountProperty)).DbType = DbType.Byte;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
            }
        }

        /// <summary>
        /// Self deletes the <see cref="InvoiceLineItem"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.DeleteInvoiceLineItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceLineId", ReadProperty(InvoiceLineIdProperty)).DbType = DbType.Guid;
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
