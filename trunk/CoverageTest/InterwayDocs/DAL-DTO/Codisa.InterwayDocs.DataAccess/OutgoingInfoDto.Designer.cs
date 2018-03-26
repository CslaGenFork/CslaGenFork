using System;
using Csla;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// DTO for OutgoingInfo type
    /// </summary>
    public partial class OutgoingInfoDto
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
        /// Gets or sets the Subject.
        /// </summary>
        /// <value>The Subject.</value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the Send Date.
        /// </summary>
        /// <value>The Send Date.</value>
        public SmartDate SendDate { get; set; }

        /// <summary>
        /// Gets or sets the Recipient Name.
        /// </summary>
        /// <value>The Recipient Name.</value>
        public string RecipientName { get; set; }

        /// <summary>
        /// Gets or sets the Recipient Town.
        /// </summary>
        /// <value>The Recipient Town.</value>
        public string RecipientTown { get; set; }

        /// <summary>
        /// Gets or sets the Notes.
        /// </summary>
        /// <value>The Notes.</value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the Archive Location.
        /// </summary>
        /// <value>The Archive Location.</value>
        public string ArchiveLocation { get; set; }
    }
}
