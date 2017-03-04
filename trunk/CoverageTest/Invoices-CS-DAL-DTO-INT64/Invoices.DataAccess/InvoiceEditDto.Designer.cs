using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for InvoiceEdit type
    /// </summary>
    public partial class InvoiceEditDto
    {
        /// <summary>
        /// Gets or sets the Invoice Id.
        /// </summary>
        /// <value>The Invoice Id.</value>
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the Invoice Number.
        /// </summary>
        /// <value>The Invoice Number.</value>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the Customer Id.
        /// </summary>
        /// <value>The Customer Id.</value>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the Invoice Date.
        /// </summary>
        /// <value>The Invoice Date.</value>
        public SmartDate InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets the Create Date.
        /// </summary>
        /// <value>The Create Date.</value>
        public SmartDate CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the Create User.
        /// </summary>
        /// <value>The Create User.</value>
        public int CreateUser { get; set; }

        /// <summary>
        /// Gets or sets the Change Date.
        /// </summary>
        /// <value>The Change Date.</value>
        public SmartDate ChangeDate { get; set; }

        /// <summary>
        /// Gets or sets the Change User.
        /// </summary>
        /// <value>The Change User.</value>
        public int ChangeUser { get; set; }

        /// <summary>
        /// Gets or sets the Row Version.
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion { get; set; }
    }
}
