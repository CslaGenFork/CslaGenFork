using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// InvoiceView (read only object).<br/>
    /// This is a generated base class of <see cref="InvoiceView"/> business object.
    /// This class is a root object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="InvoiceLines"/> of type <see cref="InvoiceLineList"/> (1:M relation to <see cref="InvoiceLineInfo"/>)
    /// </remarks>
    [Serializable]
    public partial class InvoiceView : ReadOnlyBase<InvoiceView>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="InvoiceId"/> property.
        /// </summary>
        public static readonly PropertyInfo<Guid> InvoiceIdProperty = RegisterProperty<Guid>(p => p.InvoiceId, "Invoice Id", Guid.NewGuid());
        /// <summary>
        /// The invoice internal identification
        /// </summary>
        /// <value>The Invoice Id.</value>
        public Guid InvoiceId
        {
            get { return GetProperty(InvoiceIdProperty); }
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
        }

        /// <summary>
        /// Maintains metadata about <see cref="CustomerId"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CustomerIdProperty = RegisterProperty<string>(p => p.CustomerId, "Customer Id");
        /// <summary>
        /// Gets the Customer Id.
        /// </summary>
        /// <value>The Customer Id.</value>
        public string CustomerId
        {
            get { return GetProperty(CustomerIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="InvoiceDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> InvoiceDateProperty = RegisterProperty<SmartDate>(p => p.InvoiceDate, "Invoice Date");
        /// <summary>
        /// Gets the Invoice Date.
        /// </summary>
        /// <value>The Invoice Date.</value>
        public string InvoiceDate
        {
            get { return GetPropertyConvert<SmartDate, string>(InvoiceDateProperty); }
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
        }

        /// <summary>
        /// Maintains metadata about <see cref="IsActive"/> property.
        /// </summary>
        public static readonly PropertyInfo<bool> IsActiveProperty = RegisterProperty<bool>(p => p.IsActive, "Is Active");
        /// <summary>
        /// Gets the Is Active.
        /// </summary>
        /// <value><c>true</c> if Is Active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return GetProperty(IsActiveProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(p => p.CreateDate, "Create Date", new SmartDate(DateTime.Now));
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
        public static readonly PropertyInfo<int> CreateUserProperty = RegisterProperty<int>(p => p.CreateUser, "Create User", Security.UserInformation.UserId);
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
        public static readonly PropertyInfo<InvoiceLineList> InvoiceLinesProperty = RegisterProperty<InvoiceLineList>(p => p.InvoiceLines, "Invoice Lines");
        /// <summary>
        /// Gets the Invoice Lines ("parent load" child property).
        /// </summary>
        /// <value>The Invoice Lines.</value>
        public InvoiceLineList InvoiceLines
        {
            get { return GetProperty(InvoiceLinesProperty); }
            private set { LoadProperty(InvoiceLinesProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="InvoiceView"/> object, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId parameter of the InvoiceView to fetch.</param>
        /// <returns>A reference to the fetched <see cref="InvoiceView"/> object.</returns>
        public static InvoiceView GetInvoiceView(Guid invoiceId)
        {
            return DataPortal.Fetch<InvoiceView>(invoiceId);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="InvoiceView"/> object, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId parameter of the InvoiceView to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetInvoiceView(Guid invoiceId, EventHandler<DataPortalResult<InvoiceView>> callback)
        {
            DataPortal.BeginFetch<InvoiceView>(invoiceId, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceView"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public InvoiceView()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="InvoiceView"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        protected void DataPortal_Fetch(Guid invoiceId)
        {
            var args = new DataPortalHookArgs(invoiceId);
            OnFetchPre(args);
            using (var dalManager = DalFactoryInvoices.GetManager())
            {
                var dal = dalManager.GetProvider<IInvoiceViewDal>();
                var data = dal.Fetch(invoiceId);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        private void Fetch(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    FetchChildren(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="InvoiceView"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(InvoiceIdProperty, dr.GetGuid("InvoiceId"));
            LoadProperty(InvoiceNumberProperty, dr.GetString("InvoiceNumber"));
            LoadProperty(CustomerIdProperty, dr.GetString("CustomerId"));
            LoadProperty(InvoiceDateProperty, dr.GetSmartDate("InvoiceDate", true));
            LoadProperty(IsActiveProperty, dr.GetBoolean("IsActive"));
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
            LoadProperty(InvoiceLinesProperty, DataPortal.FetchChild<InvoiceLineList>(dr));
        }

        #endregion

        #region DataPortal Hooks

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

        #endregion

    }
}
