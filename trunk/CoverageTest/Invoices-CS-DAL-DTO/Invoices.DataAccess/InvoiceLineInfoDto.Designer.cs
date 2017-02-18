using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for InvoiceLineInfo type
    /// </summary>
    public partial class InvoiceLineInfoDto
    {
        /// <summary>
        /// Gets or sets the parent Invoice Id.
        /// </summary>
        /// <value>The Invoice Id.</value>
        public Guid Parent_InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the Invoice Line Id.
        /// </summary>
        /// <value>The Invoice Line Id.</value>
        public Guid InvoiceLineId { get; set; }

        /// <summary>
        /// Gets or sets the Product Id.
        /// </summary>
        /// <value>The Product Id.</value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Quantity.
        /// </summary>
        /// <value>The Quantity.</value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Unit Cost.
        /// </summary>
        /// <value>The Unit Cost.</value>
        public decimal UnitCost { get; set; }

        /// <summary>
        /// Gets or sets the Cost.
        /// </summary>
        /// <value>The Cost.</value>
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets the Percent Discount.
        /// </summary>
        /// <value>The Percent Discount.</value>
        public byte PercentDiscount { get; set; }
    }
}
