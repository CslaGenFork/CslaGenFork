using System;
using Csla;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// DTO for DeliveryRegister type
    /// </summary>
    public partial class DeliveryRegisterDto
    {
        /// <summary>
        /// Gets or sets the Register Id.
        /// </summary>
        /// <value>The Register Id.</value>
        public int RegisterId { get; set; }

        /// <summary>
        /// Gets or sets the Data de registo.
        /// </summary>
        /// <value>The Register Date.</value>
        public SmartDate RegisterDate { get; set; }

        /// <summary>
        /// Gets or sets the Tipo.
        /// </summary>
        /// <value>The Document Type.</value>
        public string DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the Número.
        /// </summary>
        /// <value>The Document Reference.</value>
        public string DocumentReference { get; set; }

        /// <summary>
        /// Gets or sets the Entidade.
        /// </summary>
        /// <value>The Document Entity.</value>
        public string DocumentEntity { get; set; }

        /// <summary>
        /// Gets or sets the Departamento.
        /// </summary>
        /// <value>The Document Dept.</value>
        public string DocumentDept { get; set; }

        /// <summary>
        /// Gets or sets the Classificação.
        /// </summary>
        /// <value>The Document Class.</value>
        public string DocumentClass { get; set; }

        /// <summary>
        /// Gets or sets the Data do documento.
        /// </summary>
        /// <value>The Document Date.</value>
        public SmartDate DocumentDate { get; set; }

        /// <summary>
        /// Gets or sets the Destinatário.
        /// </summary>
        /// <value>The Recipient Name.</value>
        public string RecipientName { get; set; }

        /// <summary>
        /// Gets or sets the Nome de quem expediu.
        /// </summary>
        /// <value>The Expeditor Name.</value>
        public string ExpeditorName { get; set; }

        /// <summary>
        /// Gets or sets the Nome de quem recebeu.
        /// </summary>
        /// <value>The Reception Name.</value>
        public string ReceptionName { get; set; }

        /// <summary>
        /// Gets or sets the Data de recepção.
        /// </summary>
        /// <value>The Reception Date.</value>
        public SmartDate ReceptionDate { get; set; }

        /// <summary>
        /// Gets or sets the Create Date.
        /// </summary>
        /// <value>The Create Date.</value>
        public SmartDate CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the Change Date.
        /// </summary>
        /// <value>The Change Date.</value>
        public SmartDate ChangeDate { get; set; }
    }
}
