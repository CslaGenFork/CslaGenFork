using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Sql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ISupplierInfoDetailDal"/>
    /// </summary>
    public partial class SupplierInfoDetailDal : ISupplierInfoDetailDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a SupplierInfoDetail object from the database.
        /// </summary>
        /// <param name="supplierId">The fetch criteria.</param>
        /// <returns>A SupplierInfoDetailDto object.</returns>
        public SupplierInfoDetailDto Fetch(int supplierId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetSupplierInfoDetal", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private SupplierInfoDetailDto Fetch(IDataReader data)
        {
            var supplierInfoDetail = new SupplierInfoDetailDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    supplierInfoDetail.SupplierId = dr.GetInt32("SupplierId");
                    supplierInfoDetail.Name = dr.GetString("Name");
                    supplierInfoDetail.AddressLine1 = dr.IsDBNull("AddressLine1") ? null : dr.GetString("AddressLine1");
                    supplierInfoDetail.AddressLine2 = dr.IsDBNull("AddressLine2") ? null : dr.GetString("AddressLine2");
                    supplierInfoDetail.ZipCode = dr.IsDBNull("ZipCode") ? null : dr.GetString("ZipCode");
                    supplierInfoDetail.State = dr.IsDBNull("State") ? null : dr.GetString("State");
                    supplierInfoDetail.Country = (byte?)dr.GetValue("Country");
                }
            }
            return supplierInfoDetail;
        }

        #endregion

    }
}
