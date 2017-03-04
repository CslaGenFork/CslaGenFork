using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.MySql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IProductTypeCachedNVLDal"/>
    /// </summary>
    public partial class ProductTypeCachedNVLDal : IProductTypeCachedNVLDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeCachedNVL list from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeCachedNVLItemDto"/>.</returns>
        public List<ProductTypeCachedNVLItemDto> Fetch()
        {
            using (var ctx = ConnectionManager<MySqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new MySqlCommand("dbo.GetProductTypeCachedNVL", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<ProductTypeCachedNVLItemDto> LoadCollection(IDataReader data)
        {
            var productTypeCachedNVL = new List<ProductTypeCachedNVLItemDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    productTypeCachedNVL.Add(Fetch(dr));
                }
            }
            return productTypeCachedNVL;
        }

        private ProductTypeCachedNVLItemDto Fetch(SafeDataReader dr)
        {
            var productTypeCachedNVLItem = new ProductTypeCachedNVLItemDto();
            productTypeCachedNVLItem.ProductTypeId = dr.GetInt32("ProductTypeId");
            productTypeCachedNVLItem.Name = dr.GetString("Name");

            return productTypeCachedNVLItem;
        }

        #endregion

    }
}
