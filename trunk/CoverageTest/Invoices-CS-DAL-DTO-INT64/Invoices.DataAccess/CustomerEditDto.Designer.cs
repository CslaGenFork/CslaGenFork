using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for CustomerEdit type
    /// </summary>
    public partial class CustomerEditDto
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
