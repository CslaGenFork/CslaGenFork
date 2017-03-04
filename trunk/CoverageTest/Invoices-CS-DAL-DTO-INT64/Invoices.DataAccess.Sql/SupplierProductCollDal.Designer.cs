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
    /// DAL SQL Server implementation of <see cref="ISupplierProductCollDal"/>
    /// </summary>
    public partial class SupplierProductCollDal : ISupplierProductCollDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a SupplierProductColl collection from the database.
        /// </summary>
        /// <param name="supplierId">The fetch criteria.</param>
        /// <returns>A list of <see cref="SupplierProductItemDto"/>.</returns>
        public List<SupplierProductItemDto> Fetch(int supplierId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetSupplierProductColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<SupplierProductItemDto> LoadCollection(IDataReader data)
        {
            var supplierProductColl = new List<SupplierProductItemDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    supplierProductColl.Add(Fetch(dr));
                }
            }
            return supplierProductColl;
        }

        private SupplierProductItemDto Fetch(SafeDataReader dr)
        {
            var supplierProductItem = new SupplierProductItemDto();
            // Value properties
            supplierProductItem.ProductSupplierId = dr.GetInt32("ProductSupplierId");
            supplierProductItem.ProductId = dr.GetGuid("ProductId");

            return supplierProductItem;
        }

        #endregion

    }
}
