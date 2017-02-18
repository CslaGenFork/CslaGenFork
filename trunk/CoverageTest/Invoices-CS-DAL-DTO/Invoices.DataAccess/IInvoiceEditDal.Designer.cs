using System;
using System.Collections.Generic;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DAL Interface for InvoiceEdit type
    /// </summary>
    public partial interface IInvoiceEditDal
    {
        /// <summary>
        /// Gets the Invoice Lines.
        /// </summary>
        /// <value>A list of <see cref="InvoiceLineItemDto"/>.</value>
        List<InvoiceLineItemDto> InvoiceLineCollection { get; }

        /// <summary>
        /// Loads a InvoiceEdit object from the database.
        /// </summary>
        /// <param name="invoiceId">The fetch criteria.</param>
        /// <returns>A <see cref="InvoiceEditDto"/> object.</returns>
        InvoiceEditDto Fetch(Guid invoiceId);

        /// <summary>
        /// Inserts a new InvoiceEdit object in the database.
        /// </summary>
        /// <param name="invoiceEdit">The Invoice Edit DTO.</param>
        /// <returns>The new <see cref="InvoiceEditDto"/>.</returns>
        InvoiceEditDto Insert(InvoiceEditDto invoiceEdit);

        /// <summary>
        /// Updates in the database all changes made to the InvoiceEdit object.
        /// </summary>
        /// <param name="invoiceEdit">The Invoice Edit DTO.</param>
        /// <returns>The updated <see cref="InvoiceEditDto"/>.</returns>
        InvoiceEditDto Update(InvoiceEditDto invoiceEdit);

        /// <summary>
        /// Deletes the InvoiceEdit object from database.
        /// </summary>
        /// <param name="invoiceId">The delete criteria.</param>
        void Delete(Guid invoiceId);
    }
}
