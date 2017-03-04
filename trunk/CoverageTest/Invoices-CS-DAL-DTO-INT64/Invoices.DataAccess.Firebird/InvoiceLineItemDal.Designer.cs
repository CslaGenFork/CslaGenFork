using System;
using System.Collections.Generic;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Firebird
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IInvoiceLineItemDal"/>
    /// </summary>
    public partial class InvoiceLineItemDal : IInvoiceLineItemDal
    {

        #region DAL methods

        /// <summary>
        /// Inserts a new InvoiceLineItem object in the database.
        /// </summary>
        /// <param name="invoiceLineItem">The Invoice Line Item DTO.</param>
        /// <returns>The new <see cref="InvoiceLineItemDto"/>.</returns>
        public InvoiceLineItemDto Insert(InvoiceLineItemDto invoiceLineItem)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.AddInvoiceLineItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceLineItem.Parent_InvoiceId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@InvoiceLineId", invoiceLineItem.InvoiceLineId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductId", invoiceLineItem.ProductId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@Cost", invoiceLineItem.Cost).DbType = DbType.Decimal;
                    cmd.Parameters.AddWithValue("@PercentDiscount", invoiceLineItem.PercentDiscount).DbType = DbType.Byte;
                    cmd.ExecuteNonQuery();
                }
            }
            return invoiceLineItem;
        }

        /// <summary>
        /// Updates in the database all changes made to the InvoiceLineItem object.
        /// </summary>
        /// <param name="invoiceLineItem">The Invoice Line Item DTO.</param>
        /// <returns>The updated <see cref="InvoiceLineItemDto"/>.</returns>
        public InvoiceLineItemDto Update(InvoiceLineItemDto invoiceLineItem)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.UpdateInvoiceLineItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceLineId", invoiceLineItem.InvoiceLineId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@ProductId", invoiceLineItem.ProductId).DbType = DbType.Guid;
                    cmd.Parameters.AddWithValue("@Cost", invoiceLineItem.Cost).DbType = DbType.Decimal;
                    cmd.Parameters.AddWithValue("@PercentDiscount", invoiceLineItem.PercentDiscount).DbType = DbType.Byte;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("InvoiceLineItem");
                }
            }
            return invoiceLineItem;
        }

        /// <summary>
        /// Deletes the InvoiceLineItem object from database.
        /// </summary>
        /// <param name="invoiceLineId">The Invoice Line Id.</param>
        public void Delete(Guid invoiceLineId)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.DeleteInvoiceLineItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceLineId", invoiceLineId).DbType = DbType.Guid;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

    }
}
