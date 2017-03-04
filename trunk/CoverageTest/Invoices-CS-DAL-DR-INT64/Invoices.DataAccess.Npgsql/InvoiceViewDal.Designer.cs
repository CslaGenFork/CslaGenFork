using System;
using System.Data;
using Npgsql;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Npgsql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IInvoiceViewDal"/>
    /// </summary>
    public partial class InvoiceViewDal : IInvoiceViewDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a InvoiceView object from the database.
        /// </summary>
        /// <param name="invoiceId">The Invoice Id.</param>
        /// <returns>A data reader to the InvoiceView.</returns>
        public IDataReader Fetch(Guid invoiceId)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.GetInvoiceView", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    return cmd.ExecuteReader();
                }
            }
        }

        #endregion

    }
}
