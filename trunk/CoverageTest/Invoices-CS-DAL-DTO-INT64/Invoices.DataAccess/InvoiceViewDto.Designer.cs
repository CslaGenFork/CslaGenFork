using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for InvoiceView type
    /// </summary>
    public partial class InvoiceViewDto
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
        /// Gets or sets the Is Active.
        /// </summary>
        /// <value><c>true</c> if Is Active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

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
