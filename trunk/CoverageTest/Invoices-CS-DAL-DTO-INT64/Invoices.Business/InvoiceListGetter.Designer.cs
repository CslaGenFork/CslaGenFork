using System;
using Csla;

namespace Invoices.Business
{

    /// <summary>
    /// InvoiceListGetter (getter unit of work pattern).<br/>
    /// This is a generated base class of <see cref="InvoiceListGetter"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Serializable]
    public partial class InvoiceListGetter : ReadOnlyBase<InvoiceListGetter>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="Invoices"/> property.
        /// </summary>
        public static readonly PropertyInfo<InvoiceList> InvoicesProperty = RegisterProperty<InvoiceList>(p => p.Invoices, "Invoices");
        /// <summary>
        /// Gets the Invoices object (unit of work child property).
        /// </summary>
        /// <value>The Invoices.</value>
        public InvoiceList Invoices
        {
            get { return GetProperty(InvoicesProperty); }
            private set { LoadProperty(InvoicesProperty, value); }
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
        /// Factory method. Loads a <see cref="InvoiceListGetter"/> unit of objects.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="InvoiceListGetter"/> unit of objects.</returns>
        public static InvoiceListGetter GetInvoiceListGetter()
        {
            return DataPortal.Fetch<InvoiceListGetter>();
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="InvoiceListGetter"/> unit of objects.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetInvoiceListGetter(EventHandler<DataPortalResult<InvoiceListGetter>> callback)
        {
            DataPortal.BeginFetch<InvoiceListGetter>((o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                callback(o, e);
            });
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceListGetter"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public InvoiceListGetter()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="InvoiceListGetter"/> unit of objects.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            LoadProperty(InvoicesProperty, InvoiceList.GetInvoiceList());
            LoadProperty(ProductTypesProperty, ProductTypeNVL.GetProductTypeNVL());
        }

        #endregion

    }
}
