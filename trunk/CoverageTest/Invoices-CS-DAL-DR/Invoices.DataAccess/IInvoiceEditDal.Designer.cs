using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for InvoiceEdit type
    /// </summary>
    public partial interface IInvoiceEditDal
    {
        /// <summary>
        /// Loads a InvoiceEdit object from the database.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        /// <returns>A data reader to the InvoiceEdit.</returns>
        IDataReader Fetch(Guid invoiceId);

        /// <summary>
        /// Inserts a new InvoiceEdit object in the database.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        /// <param name="invoiceNumber">The Invoice Number.</param>
        /// <param name="customerId">The Customer Id.</param>
        /// <param name="invoiceDate">The Invoice Date.</param>
        /// <param name="createDate">The Create Date.</param>
        /// <param name="createUser">The Create User.</param>
        /// <param name="changeDate">The Change Date.</param>
        /// <param name="changeUser">The Change User.</param>
        /// <returns>The Row Version of the new InvoiceEdit.</returns>
        byte[] Insert(Guid invoiceId, string invoiceNumber, string customerId, SmartDate invoiceDate, SmartDate createDate, int createUser, SmartDate changeDate, int changeUser);

        /// <summary>
        /// Updates in the database all changes made to the InvoiceEdit object.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        /// <param name="invoiceNumber">The Invoice Number.</param>
        /// <param name="customerId">The Customer Id.</param>
        /// <param name="invoiceDate">The Invoice Date.</param>
        /// <param name="changeDate">The Change Date.</param>
        /// <param name="changeUser">The Change User.</param>
        /// <param name="rowVersion">The Row Version.</param>
        /// <returns>The updated Row Version.</returns>
        byte[] Update(Guid invoiceId, string invoiceNumber, string customerId, SmartDate invoiceDate, SmartDate changeDate, int changeUser, byte[] rowVersion);

        /// <summary>
        /// Deletes the InvoiceEdit object from database.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        void Delete(Guid invoiceId);
    }
}
