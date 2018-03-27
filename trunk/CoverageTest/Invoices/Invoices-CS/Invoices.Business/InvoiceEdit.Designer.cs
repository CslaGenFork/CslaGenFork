using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// InvoiceEdit (editable root object).<br/>
    /// This is a generated <see cref="InvoiceEdit"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="InvoiceLines"/> of type <see cref="InvoiceLineCollection"/> (1:M relation to <see cref="InvoiceLineItem"/>)
    /// </remarks>
    [Serializable]
    public partial class InvoiceEdit : BusinessBase<InvoiceEdit>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="InvoiceId"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<Guid> InvoiceIdProperty = RegisterProperty<Guid>(p => p.InvoiceId, "Invoice Id");
        /// <summary>
        /// The invoice internal identification
        /// </summary>
        /// <value>The Invoice Id.</value>
        public Guid InvoiceId
        {
            get { return GetProperty(InvoiceIdProperty); }
            set { SetProperty(InvoiceIdProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="InvoiceNumber"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> InvoiceNumberProperty = RegisterProperty<string>(p => p.InvoiceNumber, "Invoice Number");
        /// <summary>
        /// The public invoice number
        /// </summary>
        /// <value>The Invoice Number.</value>
        public string InvoiceNumber
        {
            get { return GetProperty(InvoiceNumberProperty); }
            set { SetProperty(InvoiceNumberProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CustomerId"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CustomerIdProperty = RegisterProperty<string>(p => p.CustomerId, "Customer Id");
        /// <summary>
        /// Gets or sets the Customer Id.
        /// </summary>
        /// <value>The Customer Id.</value>
        public string CustomerId
        {
            get { return GetProperty(CustomerIdProperty); }
            set { SetProperty(CustomerIdProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="InvoiceDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> InvoiceDateProperty = RegisterProperty<SmartDate>(p => p.InvoiceDate, "Invoice Date");
        /// <summary>
        /// Gets or sets the Invoice Date.
        /// </summary>
        /// <value>The Invoice Date.</value>
        public string InvoiceDate
        {
            get { return GetPropertyConvert<SmartDate, string>(InvoiceDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(InvoiceDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="TotalAmount"/> property.
        /// </summary>
        public static readonly PropertyInfo<decimal> TotalAmountProperty = RegisterProperty<decimal>(p => p.TotalAmount, "Total Amount");
        /// <summary>
        /// Computed invoice total amount
        /// </summary>
        /// <value>The Total Amount.</value>
        public decimal TotalAmount
        {
            get { return GetProperty(TotalAmountProperty); }
            set { SetProperty(TotalAmountProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateDate"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(p => p.CreateDate, "Create Date");
        /// <summary>
        /// Gets the Create Date.
        /// </summary>
        /// <value>The Create Date.</value>
        public SmartDate CreateDate
        {
            get { return GetProperty(CreateDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateUser"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> CreateUserProperty = RegisterProperty<int>(p => p.CreateUser, "Create User");
        /// <summary>
        /// Gets the Create User.
        /// </summary>
        /// <value>The Create User.</value>
        public int CreateUser
        {
            get { return GetProperty(CreateUserProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeDate"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<SmartDate> ChangeDateProperty = RegisterProperty<SmartDate>(p => p.ChangeDate, "Change Date");
        /// <summary>
        /// Gets the Change Date.
        /// </summary>
        /// <value>The Change Date.</value>
        public SmartDate ChangeDate
        {
            get { return GetProperty(ChangeDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeUser"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> ChangeUserProperty = RegisterProperty<int>(p => p.ChangeUser, "Change User");
        /// <summary>
        /// Gets the Change User.
        /// </summary>
        /// <value>The Change User.</value>
        public int ChangeUser
        {
            get { return GetProperty(ChangeUserProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RowVersion"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<byte[]> RowVersionProperty = RegisterProperty<byte[]>(p => p.RowVersion, "Row Version");
        /// <summary>
        /// Gets the Row Version.
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion
        {
            get { return GetProperty(RowVersionProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="InvoiceLines"/> property.
        /// </summary>
        public static readonly PropertyInfo<InvoiceLineCollection> InvoiceLinesProperty = RegisterProperty<InvoiceLineCollection>(p => p.InvoiceLines, "Invoice Lines", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Invoice Lines ("parent load" child property).
        /// </summary>
        /// <value>The Invoice Lines.</value>
        public InvoiceLineCollection InvoiceLines
        {
            get { return GetProperty(InvoiceLinesProperty); }
            private set { LoadProperty(InvoiceLinesProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="InvoiceEdit"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="InvoiceEdit"/> object.</returns>
        public static InvoiceEdit NewInvoiceEdit()
        {
            return DataPortal.Create<InvoiceEdit>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="InvoiceEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId parameter of the InvoiceEdit to fetch.</param>
        /// <returns>A reference to the fetched <see cref="InvoiceEdit"/> object.</returns>
        public static InvoiceEdit GetInvoiceEdit(Guid invoiceId)
        {
            return DataPortal.Fetch<InvoiceEdit>(invoiceId);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="InvoiceEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId of the InvoiceEdit to delete.</param>
        public static void DeleteInvoiceEdit(Guid invoiceId)
        {
            DataPortal.Delete<InvoiceEdit>(invoiceId);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="InvoiceEdit"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewInvoiceEdit(EventHandler<DataPortalResult<InvoiceEdit>> callback)
        {
            DataPortal.BeginCreate<InvoiceEdit>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="InvoiceEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId parameter of the InvoiceEdit to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetInvoiceEdit(Guid invoiceId, EventHandler<DataPortalResult<InvoiceEdit>> callback)
        {
            DataPortal.BeginFetch<InvoiceEdit>(invoiceId, callback);
        }

        /// <summary>
        /// Factory method. Asynchronously deletes a <see cref="InvoiceEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId of the InvoiceEdit to delete.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void DeleteInvoiceEdit(Guid invoiceId, EventHandler<DataPortalResult<InvoiceEdit>> callback)
        {
            DataPortal.BeginDelete<InvoiceEdit>(invoiceId, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceEdit"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public InvoiceEdit()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="InvoiceEdit"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(InvoiceIdProperty, Guid.NewGuid());
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(CreateUserProperty, Security.UserInformation.UserId);
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            LoadProperty(ChangeUserProperty, ReadProperty(CreateUserProperty));
            LoadProperty(InvoiceLinesProperty, DataPortal.CreateChild<InvoiceLineCollection>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="InvoiceEdit"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        protected void DataPortal_Fetch(Guid invoiceId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    var args = new DataPortalHookArgs(cmd, invoiceId);
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
        /// Loads a <see cref="InvoiceEdit"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(InvoiceIdProperty, dr.GetGuid("InvoiceId"));
            LoadProperty(InvoiceNumberProperty, dr.GetString("InvoiceNumber"));
            LoadProperty(CustomerIdProperty, dr.GetString("CustomerId"));
            LoadProperty(InvoiceDateProperty, dr.GetSmartDate("InvoiceDate", true));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(CreateUserProperty, dr.GetInt32("CreateUser"));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            LoadProperty(ChangeUserProperty, dr.GetInt32("ChangeUser"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
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
            LoadProperty(InvoiceLinesProperty, DataPortal.FetchChild<InvoiceLineCollection>(dr));
        }

        /// <summary>
        /// Inserts a new <see cref="InvoiceEdit"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.AddInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", ReadProperty(InvoiceIdProperty)).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@InvoiceNumber", ReadProperty(InvoiceNumberProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CustomerId", ReadProperty(CustomerIdProperty)).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@InvoiceDate", ReadProperty(InvoiceDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUser", ReadProperty(CreateUserProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUser", ReadProperty(ChangeUserProperty)).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="InvoiceEdit"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.UpdateInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", ReadProperty(InvoiceIdProperty)).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@InvoiceNumber", ReadProperty(InvoiceNumberProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CustomerId", ReadProperty(CustomerIdProperty)).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@InvoiceDate", ReadProperty(InvoiceDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUser", ReadProperty(ChangeUserProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        private void SimpleAuditTrail()
        {
            LoadProperty(ChangeDateProperty, DateTime.Now);
            LoadProperty(ChangeUserProperty, Security.UserInformation.UserId);
            if (IsNew)
            {
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty));
                LoadProperty(CreateUserProperty, ReadProperty(ChangeUserProperty));
            }
        }

        /// <summary>
        /// Self deletes the <see cref="InvoiceEdit"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(InvoiceId);
        }

        /// <summary>
        /// Deletes the <see cref="InvoiceEdit"/> object from database.
        /// </summary>
        /// <param name="invoiceId">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(Guid invoiceId)
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                using (var cmd = new SqlCommand("dbo.DeleteInvoiceEdit", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    var args = new DataPortalHookArgs(cmd, invoiceId);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
            // removes all previous references to children
            LoadProperty(InvoiceLinesProperty, DataPortal.CreateChild<InvoiceLineCollection>());
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
