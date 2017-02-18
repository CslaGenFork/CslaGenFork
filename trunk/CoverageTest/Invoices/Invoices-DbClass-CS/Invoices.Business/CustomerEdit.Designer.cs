using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// CustomerEdit (editable root object).<br/>
    /// This is a generated base class of <see cref="CustomerEdit"/> business object.
    /// </summary>
    [Serializable]
    public partial class CustomerEdit : BusinessBase<CustomerEdit>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="CustomerId"/> property.
        /// </summary>
        [NotUndoable]
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
        /// Maintains metadata about <see cref="FiscalNumber"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> FiscalNumberProperty = RegisterProperty<string>(p => p.FiscalNumber, "Fiscal Number");
        /// <summary>
        /// Gets or sets the Fiscal Number.
        /// </summary>
        /// <value>The Fiscal Number.</value>
        public string FiscalNumber
        {
            get { return GetProperty(FiscalNumberProperty); }
            set { SetProperty(FiscalNumberProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="AddressLine1"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> AddressLine1Property = RegisterProperty<string>(p => p.AddressLine1, "Address Line1");
        /// <summary>
        /// Gets or sets the Address Line1.
        /// </summary>
        /// <value>The Address Line1.</value>
        public string AddressLine1
        {
            get { return GetProperty(AddressLine1Property); }
            set { SetProperty(AddressLine1Property, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="AddressLine2"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> AddressLine2Property = RegisterProperty<string>(p => p.AddressLine2, "Address Line2");
        /// <summary>
        /// Gets or sets the Address Line2.
        /// </summary>
        /// <value>The Address Line2.</value>
        public string AddressLine2
        {
            get { return GetProperty(AddressLine2Property); }
            set { SetProperty(AddressLine2Property, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ZipCode"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> ZipCodeProperty = RegisterProperty<string>(p => p.ZipCode, "Zip Code");
        /// <summary>
        /// Gets or sets the Zip Code.
        /// </summary>
        /// <value>The Zip Code.</value>
        public string ZipCode
        {
            get { return GetProperty(ZipCodeProperty); }
            set { SetProperty(ZipCodeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="State"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> StateProperty = RegisterProperty<string>(p => p.State, "State");
        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        /// <value>The State.</value>
        public string State
        {
            get { return GetProperty(StateProperty); }
            set { SetProperty(StateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Country"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte?> CountryProperty = RegisterProperty<byte?>(p => p.Country, "Country");
        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>The Country.</value>
        public byte? Country
        {
            get { return GetProperty(CountryProperty); }
            set { SetProperty(CountryProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="CustomerEdit"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="CustomerEdit"/> object.</returns>
        public static CustomerEdit NewCustomerEdit()
        {
            return DataPortal.Create<CustomerEdit>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="CustomerEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="customerId">The CustomerId parameter of the CustomerEdit to fetch.</param>
        /// <returns>A reference to the fetched <see cref="CustomerEdit"/> object.</returns>
        public static CustomerEdit GetCustomerEdit(string customerId)
        {
            return DataPortal.Fetch<CustomerEdit>(customerId);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="CustomerEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="customerId">The CustomerId of the CustomerEdit to delete.</param>
        public static void DeleteCustomerEdit(string customerId)
        {
            DataPortal.Delete<CustomerEdit>(customerId);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="CustomerEdit"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewCustomerEdit(EventHandler<DataPortalResult<CustomerEdit>> callback)
        {
            DataPortal.BeginCreate<CustomerEdit>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="CustomerEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="customerId">The CustomerId parameter of the CustomerEdit to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetCustomerEdit(string customerId, EventHandler<DataPortalResult<CustomerEdit>> callback)
        {
            DataPortal.BeginFetch<CustomerEdit>(customerId, callback);
        }

        /// <summary>
        /// Factory method. Asynchronously deletes a <see cref="CustomerEdit"/> object, based on given parameters.
        /// </summary>
        /// <param name="customerId">The CustomerId of the CustomerEdit to delete.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void DeleteCustomerEdit(string customerId, EventHandler<DataPortalResult<CustomerEdit>> callback)
        {
            DataPortal.BeginDelete<CustomerEdit>(customerId, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerEdit"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CustomerEdit()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnCustomerEditSaved;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="CustomerEdit"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(FiscalNumberProperty, null);
            LoadProperty(AddressLine1Property, null);
            LoadProperty(AddressLine2Property, null);
            LoadProperty(ZipCodeProperty, null);
            LoadProperty(StateProperty, null);
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="CustomerEdit"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="customerId">The Customer Id.</param>
        protected void DataPortal_Fetch(string customerId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.InvoicesConnection, false))
            {
                GetQueryGetCustomerEdit(customerId);
                using (var cmd = new SqlCommand(getCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId).DbType = DbType.StringFixedLength;
                    var args = new DataPortalHookArgs(cmd, customerId);
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
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="CustomerEdit"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(CustomerIdProperty, dr.GetString("CustomerId"));
            LoadProperty(NameProperty, dr.GetString("Name"));
            LoadProperty(FiscalNumberProperty, dr.IsDBNull("FiscalNumber") ? null : dr.GetString("FiscalNumber"));
            LoadProperty(AddressLine1Property, dr.IsDBNull("AddressLine1") ? null : dr.GetString("AddressLine1"));
            LoadProperty(AddressLine2Property, dr.IsDBNull("AddressLine2") ? null : dr.GetString("AddressLine2"));
            LoadProperty(ZipCodeProperty, dr.IsDBNull("ZipCode") ? null : dr.GetString("ZipCode"));
            LoadProperty(StateProperty, dr.IsDBNull("State") ? null : dr.GetString("State"));
            LoadProperty(CountryProperty, (byte?)dr.GetValue("Country"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="CustomerEdit"/> object in the database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.InvoicesConnection, false))
            {
                GetQueryAddCustomerEdit();
                using (var cmd = new SqlCommand(addCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerId", ReadProperty(CustomerIdProperty)).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@FiscalNumber", ReadProperty(FiscalNumberProperty) == null ? (object)DBNull.Value : ReadProperty(FiscalNumberProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine1", ReadProperty(AddressLine1Property) == null ? (object)DBNull.Value : ReadProperty(AddressLine1Property)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine2", ReadProperty(AddressLine2Property) == null ? (object)DBNull.Value : ReadProperty(AddressLine2Property)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ZipCode", ReadProperty(ZipCodeProperty) == null ? (object)DBNull.Value : ReadProperty(ZipCodeProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@State", ReadProperty(StateProperty) == null ? (object)DBNull.Value : ReadProperty(StateProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Country", ReadProperty(CountryProperty) == null ? (object)DBNull.Value : ReadProperty(CountryProperty).Value).DbType = DbType.Byte;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="CustomerEdit"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.InvoicesConnection, false))
            {
                GetQueryUpdateCustomerEdit();
                using (var cmd = new SqlCommand(updateCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerId", ReadProperty(CustomerIdProperty)).DbType = DbType.StringFixedLength;
                    cmd.Parameters.AddWithValue("@Name", ReadProperty(NameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@FiscalNumber", ReadProperty(FiscalNumberProperty) == null ? (object)DBNull.Value : ReadProperty(FiscalNumberProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine1", ReadProperty(AddressLine1Property) == null ? (object)DBNull.Value : ReadProperty(AddressLine1Property)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@AddressLine2", ReadProperty(AddressLine2Property) == null ? (object)DBNull.Value : ReadProperty(AddressLine2Property)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ZipCode", ReadProperty(ZipCodeProperty) == null ? (object)DBNull.Value : ReadProperty(ZipCodeProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@State", ReadProperty(StateProperty) == null ? (object)DBNull.Value : ReadProperty(StateProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Country", ReadProperty(CountryProperty) == null ? (object)DBNull.Value : ReadProperty(CountryProperty).Value).DbType = DbType.Byte;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                }
            }
        }

        /// <summary>
        /// Self deletes the <see cref="CustomerEdit"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(CustomerId);
        }

        /// <summary>
        /// Deletes the <see cref="CustomerEdit"/> object from database.
        /// </summary>
        /// <param name="customerId">The delete criteria.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(string customerId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.InvoicesConnection, false))
            {
                GetQueryDeleteCustomerEdit(customerId);
                using (var cmd = new SqlCommand(deleteCustomerEditInlineQuery, ctx.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId).DbType = DbType.StringFixedLength;
                    var args = new DataPortalHookArgs(cmd, customerId);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
        }

        #endregion

        #region Inline queries fields and partial methods

        [NotUndoable, NonSerialized]
        private string getCustomerEditInlineQuery;

        [NotUndoable, NonSerialized]
        private string addCustomerEditInlineQuery;

        [NotUndoable, NonSerialized]
        private string updateCustomerEditInlineQuery;

        [NotUndoable, NonSerialized]
        private string deleteCustomerEditInlineQuery;

        partial void GetQueryGetCustomerEdit(string customerId);

        partial void GetQueryAddCustomerEdit();

        partial void GetQueryUpdateCustomerEdit();

        partial void GetQueryDeleteCustomerEdit(string customerId);

        #endregion

        #region Saved Event

        // TODO: edit "CustomerEdit.cs", uncomment the "OnDeserialized" method and add the following line:
        // TODO:     Saved += OnCustomerEditSaved;

        private void OnCustomerEditSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (CustomerEditSaved != null)
                CustomerEditSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="CustomerEdit"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> CustomerEditSaved;

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
