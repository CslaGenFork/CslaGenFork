using System;
using Csla;

namespace Invoices.Business
{

    /// <summary>
    /// InvoiceCreatorGetter (creator and getter unit of work pattern).<br/>
    /// This is a generated <see cref="InvoiceCreatorGetter"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Serializable]
    public partial class InvoiceCreatorGetter : ReadOnlyBase<InvoiceCreatorGetter>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="Invoice"/> property.
        /// </summary>
        public static readonly PropertyInfo<InvoiceEdit> InvoiceProperty = RegisterProperty<InvoiceEdit>(p => p.Invoice, "Invoice");
        /// <summary>
        /// Gets the Invoice object (unit of work child property).
        /// </summary>
        /// <value>The Invoice.</value>
        public InvoiceEdit Invoice
        {
            get { return GetProperty(InvoiceProperty); }
            private set { LoadProperty(InvoiceProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="ProductTypes"/> property.
        /// </summary>
        public static readonly PropertyInfo<ProductTypeNVL> ProductTypesProperty = RegisterProperty<ProductTypeNVL>(p => p.ProductTypes, "Product Types");
        /// <summary>
        /// Gets the Product Types object (unit of work child property).
        /// </summary>
        /// <value>The Product Types.</value>
        public ProductTypeNVL ProductTypes
        {
            get { return GetProperty(ProductTypesProperty); }
            private set { LoadProperty(ProductTypesProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="InvoiceCreatorGetter"/> unit of objects.
        /// </summary>
        /// <returns>A reference to the created <see cref="InvoiceCreatorGetter"/> unit of objects.</returns>
        public static InvoiceCreatorGetter NewInvoiceCreatorGetter()
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            return DataPortal.Fetch<InvoiceCreatorGetter>(new Criteria1(true, new Guid()));
        }

        /// <summary>
        /// Factory method. Loads a <see cref="InvoiceCreatorGetter"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId parameter of the InvoiceCreatorGetter to fetch.</param>
        /// <returns>A reference to the fetched <see cref="InvoiceCreatorGetter"/> unit of objects.</returns>
        public static InvoiceCreatorGetter GetInvoiceCreatorGetter(Guid invoiceId)
        {
            return DataPortal.Fetch<InvoiceCreatorGetter>(new Criteria1(false, invoiceId));
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="InvoiceCreatorGetter"/> unit of objects.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewInvoiceCreatorGetter(EventHandler<DataPortalResult<InvoiceCreatorGetter>> callback)
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch<InvoiceCreatorGetter>(new Criteria1(true, new Guid()), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                callback(o, e);
            });
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="InvoiceCreatorGetter"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId parameter of the InvoiceCreatorGetter to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetInvoiceCreatorGetter(Guid invoiceId, EventHandler<DataPortalResult<InvoiceCreatorGetter>> callback)
        {
            DataPortal.BeginFetch<InvoiceCreatorGetter>(new Criteria1(false, invoiceId), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                callback(o, e);
            });
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceCreatorGetter"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public InvoiceCreatorGetter()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Criteria

        /// <summary>
        /// Criteria1 criteria.
        /// </summary>
        [Serializable]
        protected class Criteria1 : CriteriaBase<Criteria1>
        {

            /// <summary>
            /// Maintains metadata about <see cref="CreateInvoiceEdit"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool> CreateInvoiceEditProperty = RegisterProperty<bool>(p => p.CreateInvoiceEdit, "Create Invoice Edit");
            /// <summary>
            /// Gets or sets the Create Invoice Edit.
            /// </summary>
            /// <value><c>true</c> if Create Invoice Edit; otherwise, <c>false</c>.</value>
            public bool CreateInvoiceEdit
            {
                get { return ReadProperty(CreateInvoiceEditProperty); }
                set { LoadProperty(CreateInvoiceEditProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="InvoiceId"/> property.
            /// </summary>
            public static readonly PropertyInfo<Guid> InvoiceIdProperty = RegisterProperty<Guid>(p => p.InvoiceId, "Invoice Id");
            /// <summary>
            /// Gets or sets the Invoice Id.
            /// </summary>
            /// <value>The Invoice Id.</value>
            public Guid InvoiceId
            {
                get { return ReadProperty(InvoiceIdProperty); }
                set { LoadProperty(InvoiceIdProperty, value); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public Criteria1()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <param name="createInvoiceEdit">The CreateInvoiceEdit.</param>
            /// <param name="invoiceId">The InvoiceId.</param>
            public Criteria1(bool createInvoiceEdit, Guid invoiceId)
            {
                CreateInvoiceEdit = createInvoiceEdit;
                InvoiceId = invoiceId;
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is Criteria1)
                {
                    var c = (Criteria1) obj;
                    if (!CreateInvoiceEdit.Equals(c.CreateInvoiceEdit))
                        return false;
                    if (!InvoiceId.Equals(c.InvoiceId))
                        return false;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return string.Concat("Criteria1", CreateInvoiceEdit.ToString(), InvoiceId.ToString()).GetHashCode();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Creates or loads a <see cref="InvoiceCreatorGetter"/> unit of objects, based on given criteria.
        /// </summary>
        /// <param name="crit">The create/fetch criteria.</param>
        protected void DataPortal_Fetch(Criteria1 crit)
        {
            if (crit.CreateInvoiceEdit)
                LoadProperty(InvoiceProperty, InvoiceEdit.NewInvoiceEdit());
            else
                LoadProperty(InvoiceProperty, InvoiceEdit.GetInvoiceEdit(crit.InvoiceId));
            LoadProperty(ProductTypesProperty, ProductTypeNVL.GetProductTypeNVL());
        }

        #endregion

    }
}
