using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for InvoiceView type
    /// </summary>
    public partial interface IInvoiceViewDal
    {
        /// <summary>
        /// Loads a InvoiceView object from the database.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        /// <returns>A data reader to the InvoiceView.</returns>
        IDataReader Fetch(Guid invoiceId);
    }
}
