using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Sql
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
        /// <param name="productTypeId">The Product Type Id.</param>
        /// <returns>A data reader to the ProductTypeRO.</returns>
        public IDataReader Fetch(int productTypeId)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SqlCommand("dbo.GetProductTypeRO", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductTypeId", productTypeId).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        #endregion

    }
}
