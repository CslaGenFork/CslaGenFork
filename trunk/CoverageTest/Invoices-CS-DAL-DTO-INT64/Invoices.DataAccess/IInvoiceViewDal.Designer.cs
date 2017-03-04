using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for InvoiceView type
    /// </summary>
    public partial interface IInvoiceViewDal
    {
        /// <summary>
        /// Gets the Invoice Lines.
        /// </summary>
        /// <value>A list of <see cref="InvoiceLineInfoDto"/>.</value>
        List<InvoiceLineInfoDto> InvoiceLineList { get; }

        /// <summary>
        /// Loads a InvoiceView object from the database.
        /// </summary>
        /// <param name="invoiceId">The fetch criteria.</param>
        /// <returns>A <see cref="InvoiceViewDto"/> object.</returns>
        InvoiceViewDto Fetch(Guid invoiceId);
    }
}
