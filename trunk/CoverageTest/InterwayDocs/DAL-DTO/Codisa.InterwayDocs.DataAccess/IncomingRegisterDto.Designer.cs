using System;
using Csla;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// DTO for IncomingRegister type
    /// </summary>
    public partial class IncomingRegisterDto
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
        /// Gets or sets the Assunto.
        /// </summary>
        /// <value>The Subject.</value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the Proveniência.
        /// </summary>
        /// <value>The Sender Name.</value>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the Data de recepção.
        /// </summary>
        /// <value>The Reception Date.</value>
        public SmartDate ReceptionDate { get; set; }

        /// <summary>
        /// Gets or sets the Encaminhamento.
        /// </summary>
        /// <value>The Routed To.</value>
        public string RoutedTo { get; set; }

        /// <summary>
        /// Gets or sets the Observações.
        /// </summary>
        /// <value>The Notes.</value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the Localização.
        /// </summary>
        /// <value>The Archive Location.</value>
        public string ArchiveLocation { get; set; }

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
