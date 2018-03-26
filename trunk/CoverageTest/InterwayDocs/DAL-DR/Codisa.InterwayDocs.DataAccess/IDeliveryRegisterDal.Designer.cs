using System;
using System.Data;
using Csla;

namespace Codisa.InterwayDocs.DataAccess
{
    /// <summary>
    /// DAL Interface for DeliveryRegister type
    /// </summary>
    public partial interface IDeliveryRegisterDal
    {
        /// <summary>
        /// Loads a DeliveryRegister object from the database.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        /// <returns>A data reader to the DeliveryRegister.</returns>
        IDataReader Fetch(int registerId);

        /// <summary>
        /// Inserts a new DeliveryRegister object in the database.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        /// <param name="registerDate">The Register Date.</param>
        /// <param name="documentType">The Document Type.</param>
        /// <param name="documentReference">The Document Reference.</param>
        /// <param name="documentEntity">The Document Entity.</param>
        /// <param name="documentDept">The Document Dept.</param>
        /// <param name="documentClass">The Document Class.</param>
        /// <param name="documentDate">The Document Date.</param>
        /// <param name="recipientName">The Recipient Name.</param>
        /// <param name="expeditorName">The Expeditor Name.</param>
        /// <param name="receptionName">The Reception Name.</param>
        /// <param name="receptionDate">The Reception Date.</param>
        /// <param name="createDate">The Create Date.</param>
        /// <param name="changeDate">The Change Date.</param>
        void Insert(out int registerId, SmartDate registerDate, string documentType, string documentReference, string documentEntity, string documentDept, string documentClass, SmartDate documentDate, string recipientName, string expeditorName, string receptionName, SmartDate receptionDate, SmartDate createDate, SmartDate changeDate);

        /// <summary>
        /// Updates in the database all changes made to the DeliveryRegister object.
        /// </summary>
        /// <param name="registerId">The Register Id.</param>
        /// <param name="registerDate">The Register Date.</param>
        /// <param name="documentType">The Document Type.</param>
        /// <param name="documentReference">The Document Reference.</param>
        /// <param name="documentEntity">The Document Entity.</param>
        /// <param name="documentDept">The Document Dept.</param>
        /// <param name="documentClass">The Document Class.</param>
        /// <param name="documentDate">The Document Date.</param>
        /// <param name="recipientName">The Recipient Name.</param>
        /// <param name="expeditorName">The Expeditor Name.</param>
        /// <param name="receptionName">The Reception Name.</param>
        /// <param name="receptionDate">The Reception Date.</param>
        /// <param name="changeDate">The Change Date.</param>
        void Update(int registerId, SmartDate registerDate, string documentType, string documentReference, string documentEntity, string documentDept, string documentClass, SmartDate documentDate, string recipientName, string expeditorName, string receptionName, SmartDate receptionDate, SmartDate changeDate);
    }
}
