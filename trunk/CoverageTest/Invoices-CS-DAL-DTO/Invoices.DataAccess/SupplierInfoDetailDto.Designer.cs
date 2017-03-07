using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for SupplierInfoDetail type
    /// </summary>
    public partial class SupplierInfoDetailDto
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

        /// <summary>
        /// Gets or sets the Address Line1.
        /// </summary>
        /// <value>The Address Line1.</value>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the Address Line2.
        /// </summary>
        /// <value>The Address Line2.</value>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the Zip Code.
        /// </summary>
        /// <value>The Zip Code.</value>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        /// <value>The State.</value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>The Country.</value>
        public byte? Country { get; set; }
    }
}
