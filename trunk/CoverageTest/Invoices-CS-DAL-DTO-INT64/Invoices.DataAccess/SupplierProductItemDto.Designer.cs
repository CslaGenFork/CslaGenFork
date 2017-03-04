using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for SupplierProductItem type
    /// </summary>
    public partial class SupplierProductItemDto
    {
        /// <summary>
        /// Gets or sets the parent Supplier Id.
        /// </summary>
        /// <value>The Supplier Id.</value>
        public int Parent_SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Product Supplier Id.
        /// </summary>
        /// <value>The Product Supplier Id.</value>
        public int ProductSupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Product Id.
        /// </summary>
        /// <value>The Product Id.</value>
        public Guid ProductId { get; set; }
    }
}
