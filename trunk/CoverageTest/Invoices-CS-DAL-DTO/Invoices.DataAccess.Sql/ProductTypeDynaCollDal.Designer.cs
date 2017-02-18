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
    /// DAL SQL Server implementation of <see cref="IProductTypeDynaCollDal"/>
    /// </summary>
    public partial class ProductTypeDynaCollDal : IProductTypeDynaCollDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeDynaColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeDynaItemDto"/>.</returns>
        public List<ProductTypeDynaItemDto> Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeDynaColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<ProductTypeDynaItemDto> LoadCollection(IDataReader data)
        {
            var productTypeDynaColl = new List<ProductTypeDynaItemDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    productTypeDynaColl.Add(Fetch(dr));
                }
            }
            return productTypeDynaColl;
        }

        private ProductTypeDynaItemDto Fetch(SafeDataReader dr)
        {
            var productTypeDynaItem = new ProductTypeDynaItemDto();
            // Value properties
            productTypeDynaItem.ProductTypeId = dr.GetInt32("ProductTypeId");
            productTypeDynaItem.Name = dr.GetString("Name");

            return productTypeDynaItem;
        }

        #endregion

    }
}
