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
    /// DAL SQL Server implementation of <see cref="IProductTypeNVLDal"/>
    /// </summary>
    public partial class ProductTypeNVLDal : IProductTypeNVLDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeNVL list from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeNVLItemDto"/>.</returns>
        public List<ProductTypeNVLItemDto> Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeNVL", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<ProductTypeNVLItemDto> LoadCollection(IDataReader data)
        {
            var productTypeNVL = new List<ProductTypeNVLItemDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    productTypeNVL.Add(Fetch(dr));
                }
            }
            return productTypeNVL;
        }

        private ProductTypeNVLItemDto Fetch(SafeDataReader dr)
        {
            var productTypeNVLItem = new ProductTypeNVLItemDto();
            productTypeNVLItem.ProductTypeId = dr.GetInt32("ProductTypeId");
            productTypeNVLItem.Name = dr.GetString("Name");

            return productTypeNVLItem;
        }

        #endregion

    }
}
