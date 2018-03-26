using System;
using Csla;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// DTO for DeliveryInfo type
    /// </summary>
    public partial class DeliveryInfoDto
    {
        /// <summary>
        /// Gets or sets the Register Id.
        /// </summary>
        /// <value>The Register Id.</value>
        public int RegisterId { get; set; }

        /// <summary>
        /// Gets or sets the Register Date.
        /// </summary>
        /// <value>The Register Date.</value>
        public SmartDate RegisterDate { get; set; }

        /// <summary>
        /// Gets or sets the Document Type.
        /// </summary>
        /// <value>The Document Type.</value>
        public string DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the Document Reference.
        /// </summary>
        /// <value>The Document Reference.</value>
        public string DocumentReference { get; set; }

        /// <summary>
        /// Gets or sets the Document Entity.
        /// </summary>
        /// <value>The Document Entity.</value>
        public string DocumentEntity { get; set; }

        /// <summary>
        /// Gets or sets the Document Dept.
        /// </summary>
        /// <value>The Document Dept.</value>
        public string DocumentDept { get; set; }

        /// <summary>
        /// Gets or sets the Document Class.
        /// </summary>
        /// <value>The Document Class.</value>
        public string DocumentClass { get; set; }

        /// <summary>
        /// Gets or sets the Document Date.
        /// </summary>
        /// <value>The Document Date.</value>
        public SmartDate DocumentDate { get; set; }

        /// <summary>
        /// Gets or sets the Recipient Name.
        /// </summary>
        /// <value>The Recipient Name.</value>
        public string RecipientName { get; set; }

        /// <summary>
        /// Gets or sets the Expeditor Name.
        /// </summary>
        /// <value>The Expeditor Name.</value>
        public string ExpeditorName { get; set; }

        /// <summary>
        /// Gets or sets the Reception Name.
        /// </summary>
        /// <value>The Reception Name.</value>
        public string ReceptionName { get; set; }

        /// <summary>
        /// Gets or sets the Reception Date.
        /// </summary>
        /// <value>The Reception Date.</value>
        public SmartDate ReceptionDate { get; set; }
    }
}
