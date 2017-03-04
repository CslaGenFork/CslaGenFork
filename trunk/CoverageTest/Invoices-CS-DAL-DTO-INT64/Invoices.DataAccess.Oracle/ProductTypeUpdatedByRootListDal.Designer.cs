using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Oracle
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IProductTypeUpdatedByRootListDal"/>
    /// </summary>
    public partial class ProductTypeUpdatedByRootListDal : IProductTypeUpdatedByRootListDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeUpdatedByRootList collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="ProductTypeUpdatedByRootInfoDto"/>.</returns>
        public List<ProductTypeUpdatedByRootInfoDto> Fetch()
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.GetProductTypeUpdatedByRootList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<ProductTypeUpdatedByRootInfoDto> LoadCollection(IDataReader data)
        {
            var productTypeUpdatedByRootList = new List<ProductTypeUpdatedByRootInfoDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    productTypeUpdatedByRootList.Add(Fetch(dr));
                }
            }
            return productTypeUpdatedByRootList;
        }

        private ProductTypeUpdatedByRootInfoDto Fetch(SafeDataReader dr)
        {
            var productTypeUpdatedByRootInfo = new ProductTypeUpdatedByRootInfoDto();
            // Value properties
            productTypeUpdatedByRootInfo.ProductTypeId = dr.GetInt32("ProductTypeId");
            productTypeUpdatedByRootInfo.Name = dr.GetString("Name");

            return productTypeUpdatedByRootInfo;
        }

        #endregion

    }
}
