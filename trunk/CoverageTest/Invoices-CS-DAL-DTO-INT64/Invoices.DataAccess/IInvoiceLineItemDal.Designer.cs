using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for InvoiceLineItem type
    /// </summary>
    public partial interface IInvoiceLineItemDal
    {
        /// <summary>
        /// Inserts a new InvoiceLineItem object in the database.
        /// </summary>
        /// <param name="invoiceLineItem">The Invoice Line Item DTO.</param>
        /// <returns>The new <see cref="InvoiceLineItemDto"/>.</returns>
        InvoiceLineItemDto Insert(InvoiceLineItemDto invoiceLineItem);

        /// <summary>
        /// Updates in the database all changes made to the InvoiceLineItem object.
        /// </summary>
        /// <param name="invoiceLineItem">The Invoice Line Item DTO.</param>
        /// <returns>The updated <see cref="InvoiceLineItemDto"/>.</returns>
        InvoiceLineItemDto Update(InvoiceLineItemDto invoiceLineItem);

        /// <summary>
        /// Deletes the InvoiceLineItem object from database.
        /// </summary>
        /// <param name="invoiceLineId">The Invoice Line Id.</param>
        void Delete(Guid invoiceLineId);
    }
}
