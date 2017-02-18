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
    /// DAL SQL Server implementation of <see cref="IProductTypeCachedListDal"/>
    /// </summary>
    public partial class ProductTypeCachedListDal : IProductTypeCachedListDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeCachedList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeCachedInfoDto"/>.</returns>
        public List<ProductTypeCachedInfoDto> Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeCachedList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<ProductTypeCachedInfoDto> LoadCollection(IDataReader data)
        {
            var productTypeCachedList = new List<ProductTypeCachedInfoDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    productTypeCachedList.Add(Fetch(dr));
                }
            }
            return productTypeCachedList;
        }

        private ProductTypeCachedInfoDto Fetch(SafeDataReader dr)
        {
            var productTypeCachedInfo = new ProductTypeCachedInfoDto();
            // Value properties
            productTypeCachedInfo.ProductTypeId = dr.GetInt32("ProductTypeId");
            productTypeCachedInfo.Name = dr.GetString("Name");

            return productTypeCachedInfo;
        }

        #endregion

    }
}
