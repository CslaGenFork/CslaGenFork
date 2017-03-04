using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.SQLite
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IProductTypeListDal"/>
    /// </summary>
    public partial class ProductTypeListDal : IProductTypeListDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeInfoDto"/>.</returns>
        public List<ProductTypeInfoDto> Fetch()
        {
            using (var ctx = ConnectionManager<SQLiteConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SQLiteCommand("dbo.GetProductTypeList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<ProductTypeInfoDto> LoadCollection(IDataReader data)
        {
            var productTypeList = new List<ProductTypeInfoDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    productTypeList.Add(Fetch(dr));
                }
            }
            return productTypeList;
        }

        private ProductTypeInfoDto Fetch(SafeDataReader dr)
        {
            var productTypeInfo = new ProductTypeInfoDto();
            // Value properties
            productTypeInfo.ProductTypeId = dr.GetInt32("ProductTypeId");
            productTypeInfo.Name = dr.GetString("Name");

            return productTypeInfo;
        }

        #endregion

    }
}
