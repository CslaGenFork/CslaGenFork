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
    /// DAL SQL Server implementation of <see cref="ISupplierProductListDal"/>
    /// </summary>
    public partial class SupplierProductListDal : ISupplierProductListDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a SupplierProductList collection from the database.
        /// </summary>
        /// <param name="supplierId">The fetch criteria.</param>
        /// <returns>A list of <see cref="SupplierProductInfoDto"/>.</returns>
        public List<SupplierProductInfoDto> Fetch(int supplierId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetSupplierProductList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<SupplierProductInfoDto> LoadCollection(IDataReader data)
        {
            var supplierProductList = new List<SupplierProductInfoDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    supplierProductList.Add(Fetch(dr));
                }
            }
            return supplierProductList;
        }

        private SupplierProductInfoDto Fetch(SafeDataReader dr)
        {
            var SupplierProductInfo = new SupplierProductInfoDto();
            // Value properties
            SupplierProductInfo.ProductSupplierId = dr.GetInt32("ProductSupplierId");
            SupplierProductInfo.ProductId = dr.GetGuid("ProductId");

            return SupplierProductInfo;
        }

        #endregion

    }
}
