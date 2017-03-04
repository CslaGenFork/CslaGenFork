using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Oracle
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
        /// <param name="invoiceId">The parent Invoice Id.</param>
        /// <param name="invoiceLineId">The Invoice Line Id.</param>
        /// <param name="productId">The Product Id.</param>
        /// <param name="cost">The Cost.</param>
        /// <param name="percentDiscount">The Percent Discount.</param>
        public void Insert(Guid invoiceId, Guid invoiceLineId, Guid productId, decimal cost, byte percentDiscount)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.AddInvoiceLineItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    cmd.Parameters.Add("@InvoiceLineId", invoiceLineId).DbType = DbType.Guid;
                    cmd.Parameters.Add("@ProductId", productId).DbType = DbType.Guid;
                    cmd.Parameters.Add("@Cost", cost).DbType = DbType.Decimal;
                    cmd.Parameters.Add("@PercentDiscount", percentDiscount).DbType = DbType.Byte;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the InvoiceLineItem object.
        /// </summary>
        /// <param name="invoiceLineId">The Invoice Line Id.</param>
        /// <param name="productId">The Product Id.</param>
        /// <param name="cost">The Cost.</param>
        /// <param name="percentDiscount">The Percent Discount.</param>
        public void Update(Guid invoiceLineId, Guid productId, decimal cost, byte percentDiscount)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.UpdateInvoiceLineItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@InvoiceLineId", invoiceLineId).DbType = DbType.Guid;
                    cmd.Parameters.Add("@ProductId", productId).DbType = DbType.Guid;
                    cmd.Parameters.Add("@Cost", cost).DbType = DbType.Decimal;
                    cmd.Parameters.Add("@PercentDiscount", percentDiscount).DbType = DbType.Byte;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("InvoiceLineItem");
                }
            }
        }

        /// <summary>
        /// Deletes the InvoiceLineItem object from database.
        /// </summary>
        /// <param name="invoiceLineId">The Invoice Line Id.</param>
        public void Delete(Guid invoiceLineId)
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.DeleteInvoiceLineItem", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@InvoiceLineId", invoiceLineId).DbType = DbType.Guid;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

    }
}
