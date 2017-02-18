using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// Item DTO for ProductTypeNVL type
    /// </summary>
    public partial class ProductTypeNVLItemDto
    {
        /// <summary>
        /// Gets or sets the Product Type Id.
        /// </summary>
        /// <value>The Product Type Id.</value>
        public int ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name { get; set; }
    }
}
