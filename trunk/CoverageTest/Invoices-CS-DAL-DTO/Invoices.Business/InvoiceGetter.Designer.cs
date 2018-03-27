using System;
using Csla;

namespace Invoices.Business
{

    /// <summary>
    /// InvoiceGetter (getter unit of work pattern).<br/>
    /// This is a generated <see cref="InvoiceGetter"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Serializable]
    public partial class InvoiceGetter : ReadOnlyBase<InvoiceGetter>
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
        /// Factory method. Loads a <see cref="InvoiceGetter"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId parameter of the InvoiceGetter to fetch.</param>
        /// <returns>A reference to the fetched <see cref="InvoiceGetter"/> unit of objects.</returns>
        public static InvoiceGetter GetInvoiceGetter(Guid invoiceId)
        {
            return DataPortal.Fetch<InvoiceGetter>(invoiceId);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="InvoiceGetter"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="invoiceId">The InvoiceId parameter of the InvoiceGetter to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetInvoiceGetter(Guid invoiceId, EventHandler<DataPortalResult<InvoiceGetter>> callback)
        {
            DataPortal.BeginFetch<InvoiceGetter>(invoiceId, (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                callback(o, e);
            });
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceGetter"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public InvoiceGetter()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="InvoiceGetter"/> unit of objects, based on given criteria.
        /// </summary>
        /// <param name="invoiceId">The fetch criteria.</param>
        protected void DataPortal_Fetch(Guid invoiceId)
        {
            LoadProperty(InvoiceProperty, InvoiceEdit.GetInvoiceEdit(invoiceId));
            LoadProperty(ProductTypesProperty, ProductTypeNVL.GetProductTypeNVL());
        }

        #endregion

    }
}
