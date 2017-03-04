using System;
using System.Collections.Generic;
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
        /// <returns>A list of <see cref="InvoiceInfoDto"/>.</returns>
        List<InvoiceInfoDto> Fetch();
    }
}
