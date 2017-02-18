using System;
using Csla;

namespace Invoices.Business
{

    /// <summary>
    /// InvoiceCreator (creator unit of work pattern).<br/>
    /// This is a generated base class of <see cref="InvoiceCreator"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Serializable]
    public partial class InvoiceCreator : ReadOnlyBase<InvoiceCreator>
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
        /// Factory method. Creates a new <see cref="InvoiceCreator"/> unit of objects.
        /// </summary>
        /// <returns>A reference to the created <see cref="InvoiceCreator"/> unit of objects.</returns>
        public static InvoiceCreator NewInvoiceCreator()
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            return DataPortal.Fetch<InvoiceCreator>();
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="InvoiceCreator"/> unit of objects.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewInvoiceCreator(EventHandler<DataPortalResult<InvoiceCreator>> callback)
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch<InvoiceCreator>((o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                callback(o, e);
            });
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceCreator"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public InvoiceCreator()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Creates a new <see cref="InvoiceCreator"/> unit of objects.
        /// </summary>
        /// <remarks>
        /// ReadOnlyBase&lt;T&gt; doesn't allow the use of DataPortal_Create and thus DataPortal_Fetch is used.
        /// </remarks>
        protected void DataPortal_Fetch()
        {
            LoadProperty(InvoiceProperty, InvoiceEdit.NewInvoiceEdit());
            LoadProperty(ProductTypesProperty, ProductTypeNVL.GetProductTypeNVL());
        }

        #endregion

    }
}
