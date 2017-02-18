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
    /// DAL SQL Server implementation of <see cref="IProductTypeCollDal"/>
    /// </summary>
    public partial class ProductTypeCollDal : IProductTypeCollDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeItemDto"/>.</returns>
        public List<ProductTypeItemDto> Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<ProductTypeItemDto> LoadCollection(IDataReader data)
        {
            var productTypeColl = new List<ProductTypeItemDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    productTypeColl.Add(Fetch(dr));
                }
            }
            return productTypeColl;
        }

        private ProductTypeItemDto Fetch(SafeDataReader dr)
        {
            var productTypeItem = new ProductTypeItemDto();
            // Value properties
            productTypeItem.ProductTypeId = dr.GetInt32("ProductTypeId");
            productTypeItem.Name = dr.GetString("Name");

            return productTypeItem;
        }

        #endregion

    }
}
