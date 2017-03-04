using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Npgsql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IProductTypeRODal"/>
    /// </summary>
    public partial class ProductTypeRODal : IProductTypeRODal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeRO object from the database.
        /// </summary>
        /// <param name="productTypeId">The fetch criteria.</param>
        /// <returns>A ProductTypeRODto object.</returns>
        public ProductTypeRODto Fetch(int productTypeId)
        {
            using (var ctx = ConnectionManager<NpgsqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new NpgsqlCommand("dbo.GetProductTypeRO", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private ProductTypeRODto Fetch(IDataReader data)
        {
            var productTypeRO = new ProductTypeRODto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    productTypeRO.ProductTypeId = dr.GetInt32("ProductTypeId");
                    productTypeRO.Name = dr.GetString("Name");
                }
            }
            return productTypeRO;
        }

        #endregion

    }
}
