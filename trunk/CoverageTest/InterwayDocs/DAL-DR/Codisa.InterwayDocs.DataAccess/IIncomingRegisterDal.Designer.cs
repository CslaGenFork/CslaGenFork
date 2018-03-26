using System;
using System.Data;
using Csla;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// DAL Interface for IncomingRegister type
    /// </summary>
    public partial interface IIncomingRegisterDal
    {
        /// <summary>
        /// Loads a IncomingRegister object from the database.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        /// <returns>A data reader to the IncomingRegister.</returns>
        IDataReader Fetch(int registerId);

        /// <summary>
        /// Inserts a new IncomingRegister object in the database.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        /// <param name="registerDate">The Register Date.</param>
        /// <param name="documentType">The Document Type.</param>
        /// <param name="documentReference">The Document Reference.</param>
        /// <param name="documentEntity">The Document Entity.</param>
        /// <param name="documentDept">The Document Dept.</param>
        /// <param name="documentClass">The Document Class.</param>
        /// <param name="documentDate">The Document Date.</param>
        /// <param name="subject">The Subject.</param>
        /// <param name="senderName">The Sender Name.</param>
        /// <param name="receptionDate">The Reception Date.</param>
        /// <param name="routedTo">The Routed To.</param>
        /// <param name="notes">The Notes.</param>
        /// <param name="archiveLocation">The Archive Location.</param>
        /// <param name="createDate">The Create Date.</param>
        /// <param name="changeDate">The Change Date.</param>
        void Insert(out int registerId, SmartDate registerDate, string documentType, string documentReference, string documentEntity, string documentDept, string documentClass, SmartDate documentDate, string subject, string senderName, SmartDate receptionDate, string routedTo, string notes, string archiveLocation, SmartDate createDate, SmartDate changeDate);

        /// <summary>
        /// Updates in the database all changes made to the IncomingRegister object.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        /// <param name="registerDate">The Register Date.</param>
        /// <param name="documentType">The Document Type.</param>
        /// <param name="documentReference">The Document Reference.</param>
        /// <param name="documentEntity">The Document Entity.</param>
        /// <param name="documentDept">The Document Dept.</param>
        /// <param name="documentClass">The Document Class.</param>
        /// <param name="documentDate">The Document Date.</param>
        /// <param name="subject">The Subject.</param>
        /// <param name="senderName">The Sender Name.</param>
        /// <param name="receptionDate">The Reception Date.</param>
        /// <param name="routedTo">The Routed To.</param>
        /// <param name="notes">The Notes.</param>
        /// <param name="archiveLocation">The Archive Location.</param>
        /// <param name="changeDate">The Change Date.</param>
        void Update(int registerId, SmartDate registerDate, string documentType, string documentReference, string documentEntity, string documentDept, string documentClass, SmartDate documentDate, string subject, string senderName, SmartDate receptionDate, string routedTo, string notes, string archiveLocation, SmartDate changeDate);
    }
}
