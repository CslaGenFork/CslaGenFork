using System;
using System.Data;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for InvoiceList type
    /// </summary>
    public partial interface IInvoiceListDal
    {
        /// <summary>
        /// Loads a InvoiceList collection from the database.
        /// </summary>
        /// <returns>A data reader to the InvoiceList.</returns>
        IDataReader Fetch();
    }
}
