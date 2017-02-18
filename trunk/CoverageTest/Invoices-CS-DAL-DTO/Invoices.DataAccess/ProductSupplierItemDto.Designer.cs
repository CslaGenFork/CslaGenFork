using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for ProductSupplierItem type
    /// </summary>
    public partial class ProductSupplierItemDto
    {
        /// <summary>
        /// Gets or sets the parent Product Id.
        /// </summary>
        /// <value>The Product Id.</value>
        public Guid Parent_ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Product Supplier Id.
        /// </summary>
        /// <value>The Product Supplier Id.</value>
        public int ProductSupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Id.
        /// </summary>
        /// <value>The Supplier Id.</value>
        public int SupplierId { get; set; }
    }
}
