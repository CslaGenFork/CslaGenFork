using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for SupplierInfo type
    /// </summary>
    public partial class SupplierInfoDto
    {
        /// <summary>
        /// Gets or sets the Supplier Id.
        /// </summary>
        /// <value>The Supplier Id.</value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name { get; set; }
    }
}
