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
        /// <returns>A list of <see cref="SupplierProductItnfoDto"/>.</returns>
        public List<SupplierProductItnfoDto> Fetch(int supplierId)
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

        private List<SupplierProductItnfoDto> LoadCollection(IDataReader data)
        {
            var supplierProductList = new List<SupplierProductItnfoDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    supplierProductList.Add(Fetch(dr));
                }
            }
            return supplierProductList;
        }

        private SupplierProductItnfoDto Fetch(SafeDataReader dr)
        {
            var supplierProductItnfo = new SupplierProductItnfoDto();
            // Value properties
            supplierProductItnfo.ProductSupplierId = dr.GetInt32("ProductSupplierId");
            supplierProductItnfo.ProductId = dr.GetGuid("ProductId");

            return supplierProductItnfo;
        }

        #endregion

    }
}
