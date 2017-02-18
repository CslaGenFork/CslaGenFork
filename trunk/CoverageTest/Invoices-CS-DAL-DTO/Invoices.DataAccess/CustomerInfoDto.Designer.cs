using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for CustomerInfo type
    /// </summary>
    public partial class CustomerInfoDto
    {
        /// <summary>
        /// Gets or sets the Customer Id.
        /// </summary>
        /// <value>The Customer Id.</value>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Fiscal Number.
        /// </summary>
        /// <value>The Fiscal Number.</value>
        public string FiscalNumber { get; set; }
    }
}
