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
    /// DAL SQL Server implementation of <see cref="IInvoiceListDal"/>
    /// </summary>
    public partial class InvoiceListDal : IInvoiceListDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a InvoiceList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="InvoiceInfoDto"/>.</returns>
        public List<InvoiceInfoDto> Fetch()
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.GetInvoiceList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<InvoiceInfoDto> LoadCollection(IDataReader data)
        {
            var invoiceList = new List<InvoiceInfoDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    invoiceList.Add(Fetch(dr));
                }
            }
            return invoiceList;
        }

        private InvoiceInfoDto Fetch(SafeDataReader dr)
        {
            var invoiceInfo = new InvoiceInfoDto();
            // Value properties
            invoiceInfo.InvoiceId = dr.GetGuid("InvoiceId");
            invoiceInfo.InvoiceNumber = dr.GetString("InvoiceNumber");
            invoiceInfo.CustomerId = dr.GetString("CustomerId");
            invoiceInfo.InvoiceDate = dr.GetSmartDate("InvoiceDate", true);
            invoiceInfo.IsActive = dr.GetBoolean("IsActive");
            invoiceInfo.CreateDate = dr.GetSmartDate("CreateDate", true);
            invoiceInfo.CreateUser = dr.GetInt32("CreateUser");
            invoiceInfo.ChangeDate = dr.GetSmartDate("ChangeDate", true);
            invoiceInfo.ChangeUser = dr.GetInt32("ChangeUser");

            return invoiceInfo;
        }

        #endregion

    }
}
