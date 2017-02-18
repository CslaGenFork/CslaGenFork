using System;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// InvoiceLineInfo (read only object).<br/>
    /// This is a generated base class of <see cref="InvoiceLineInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="InvoiceLineList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class InvoiceLineInfo : ReadOnlyBase<InvoiceLineInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="InvoiceLineId"/> property.
        /// </summary>
        public static readonly PropertyInfo<Guid> InvoiceLineIdProperty = RegisterProperty<Guid>(p => p.InvoiceLineId, "Invoice Line Id", Guid.NewGuid());
        /// <summary>
        /// Gets the Invoice Line Id.
        /// </summary>
        /// <value>The Invoice Line Id.</value>
        public Guid InvoiceLineId
        {
            get { return GetProperty(InvoiceLineIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ProductId"/> property.
        /// </summary>
        public static readonly PropertyInfo<Guid> ProductIdProperty = RegisterProperty<Guid>(p => p.ProductId, "Product Id");
        /// <summary>
        /// Gets the Product Id.
        /// </summary>
        /// <value>The Product Id.</value>
        public Guid ProductId
        {
            get { return GetProperty(ProductIdProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Quantity"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> QuantityProperty = RegisterProperty<int>(p => p.Quantity, "Quantity");
        /// <summary>
        /// Gets the Quantity.
        /// </summary>
        /// <value>The Quantity.</value>
        public int Quantity
        {
            get { return GetProperty(QuantityProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="UnitCost"/> property.
        /// </summary>
        public static readonly PropertyInfo<decimal> UnitCostProperty = RegisterProperty<decimal>(p => p.UnitCost, "Unit Cost");
        /// <summary>
        /// Gets the Unit Cost.
        /// </summary>
        /// <value>The Unit Cost.</value>
        public decimal UnitCost
        {
            get { return GetProperty(UnitCostProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Cost"/> property.
        /// </summary>
        public static readonly PropertyInfo<decimal> CostProperty = RegisterProperty<decimal>(p => p.Cost, "Cost");
        /// <summary>
        /// Gets the Cost.
        /// </summary>
        /// <value>The Cost.</value>
        public decimal Cost
        {
            get { return GetProperty(CostProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="PercentDiscount"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> PercentDiscountProperty = RegisterProperty<byte>(p => p.PercentDiscount, "Percent Discount");
        /// <summary>
        /// Gets the Percent Discount.
        /// </summary>
        /// <value>The Percent Discount.</value>
        public byte PercentDiscount
        {
            get { return GetProperty(PercentDiscountProperty); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceLineInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public InvoiceLineInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="InvoiceLineInfo"/> object from the given <see cref="InvoiceLineInfoDto"/>.
        /// </summary>
        /// <param name="data">The InvoiceLineInfoDto to use.</param>
        private void Child_Fetch(InvoiceLineInfoDto data)
        {
            // Value properties
            LoadProperty(InvoiceLineIdProperty, data.InvoiceLineId);
            LoadProperty(ProductIdProperty, data.ProductId);
            LoadProperty(QuantityProperty, data.Quantity);
            LoadProperty(UnitCostProperty, data.UnitCost);
            LoadProperty(CostProperty, data.Cost);
            LoadProperty(PercentDiscountProperty, data.PercentDiscount);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
