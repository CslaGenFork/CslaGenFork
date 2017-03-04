using System;
using System.Data;
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
        /// <param name="invoiceId">The parent Invoice Id.</param>
        /// <param name="invoiceLineId">The Invoice Line Id.</param>
        /// <param name="productId">The Product Id.</param>
        /// <param name="cost">The Cost.</param>
        /// <param name="percentDiscount">The Percent Discount.</param>
        void Insert(Guid invoiceId, Guid invoiceLineId, Guid productId, decimal cost, byte percentDiscount);

        /// <summary>
        /// Updates in the database all changes made to the InvoiceLineItem object.
        /// </summary>
        /// <param name="invoiceLineId">The Invoice Line Id.</param>
        /// <param name="productId">The Product Id.</param>
        /// <param name="cost">The Cost.</param>
        /// <param name="percentDiscount">The Percent Discount.</param>
        void Update(Guid invoiceLineId, Guid productId, decimal cost, byte percentDiscount);

        /// <summary>
        /// Deletes the InvoiceLineItem object from database.
        /// </summary>
        /// <param name="invoiceLineId">The Invoice Line Id.</param>
        void Delete(Guid invoiceLineId);
    }
}
