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
    /// DAL SQL Server implementation of <see cref="IInvoiceViewDal"/>
    /// </summary>
    public partial class InvoiceViewDal : IInvoiceViewDal
    {

        #region DAL methods

        private List<InvoiceLineInfoDto> _invoiceLineList = new List<InvoiceLineInfoDto>();

        /// <summary>
        /// Gets the Invoice Lines.
        /// </summary>
        /// <value>A list of <see cref="InvoiceLineInfoDto"/>.</value>
        public List<InvoiceLineInfoDto> InvoiceLineList
        {
            get { return _invoiceLineList; }
        }

        /// <summary>
        /// Loads a InvoiceView object from the database.
        /// </summary>
        /// <param name="invoiceId">The fetch criteria.</param>
        /// <returns>A InvoiceViewDto object.</returns>
        public InvoiceViewDto Fetch(Guid invoiceId)
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.GetInvoiceView", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceId", invoiceId).DbType = DbType.Guid;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private InvoiceViewDto Fetch(IDataReader data)
        {
            var invoiceView = new InvoiceViewDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    invoiceView.InvoiceId = dr.GetGuid("InvoiceId");
                    invoiceView.InvoiceNumber = dr.GetString("InvoiceNumber");
                    invoiceView.CustomerId = dr.GetString("CustomerId");
                    invoiceView.InvoiceDate = dr.GetSmartDate("InvoiceDate", true);
                    invoiceView.IsActive = dr.GetBoolean("IsActive");
                    invoiceView.CreateDate = dr.GetSmartDate("CreateDate", true);
                    invoiceView.CreateUser = dr.GetInt32("CreateUser");
                    invoiceView.ChangeDate = dr.GetSmartDate("ChangeDate", true);
                    invoiceView.ChangeUser = dr.GetInt32("ChangeUser");
                    invoiceView.RowVersion = dr.GetValue("RowVersion") as byte[];
                }
                FetchChildren(dr);
            }
            return invoiceView;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            while (dr.Read())
            {
                _invoiceLineList.Add(FetchInvoiceLineInfo(dr));
            }
        }

        private InvoiceLineInfoDto FetchInvoiceLineInfo(SafeDataReader dr)
        {
            var invoiceLineInfo = new InvoiceLineInfoDto();
            // Value properties
            invoiceLineInfo.InvoiceLineId = dr.GetGuid("InvoiceLineId");
            invoiceLineInfo.ProductId = dr.GetGuid("ProductId");
            invoiceLineInfo.Quantity = dr.GetInt32("Quantity");
            invoiceLineInfo.UnitCost = dr.GetDecimal("UnitCost");
            invoiceLineInfo.Cost = dr.GetDecimal("Cost");
            invoiceLineInfo.PercentDiscount = dr.GetByte("PercentDiscount");

            return invoiceLineInfo;
        }

        #endregion

    }
}
