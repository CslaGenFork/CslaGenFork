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
    /// DAL SQL Server implementation of <see cref="IProductListDal"/>
    /// </summary>
    public partial class ProductListDal : IProductListDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductInfoDto"/>.</returns>
        public List<ProductInfoDto> Fetch()
        {
            using (var ctx = ConnectionManager<MySqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new MySqlCommand("dbo.GetProductList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<ProductInfoDto> LoadCollection(IDataReader data)
        {
            var productList = new List<ProductInfoDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    productList.Add(Fetch(dr));
                }
            }
            return productList;
        }

        private ProductInfoDto Fetch(SafeDataReader dr)
        {
            var productInfo = new ProductInfoDto();
            // Value properties
            productInfo.ProductId = dr.GetGuid("ProductId");
            productInfo.ProductCode = dr.IsDBNull("ProductCode") ? null : dr.GetString("ProductCode");
            productInfo.Name = dr.GetString("Name");
            productInfo.ProductTypeId = dr.GetInt32("ProductTypeId");
            productInfo.UnitCost = dr.GetString("UnitCost");
            productInfo.StockByteNull = (byte?)dr.GetValue("StockByteNull");
            productInfo.StockByte = dr.GetByte("StockByte");
            productInfo.StockShortNull = (short?)dr.GetValue("StockShortNull");
            productInfo.StockShort = dr.GetInt16("StockShort");
            productInfo.StockIntNull = (int?)dr.GetValue("StockIntNull");
            productInfo.StockInt = dr.GetInt32("StockInt");
            productInfo.StockLongNull = (long?)dr.GetValue("StockLongNull");
            productInfo.StockLong = dr.GetInt64("StockLong");

            return productInfo;
        }

        #endregion

    }
}
