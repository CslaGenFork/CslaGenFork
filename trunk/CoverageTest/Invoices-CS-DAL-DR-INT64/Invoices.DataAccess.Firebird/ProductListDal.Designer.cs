using System;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Firebird
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
        /// <returns>A data reader to the ProductList.</returns>
        public IDataReader Fetch()
        {
            using (var ctx = ConnectionManager<FbConnection>.GetManager("Invoices"))
            {
                using (var cmd = new FbCommand("dbo.GetProductList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteReader();
                }
            }
        }

        #endregion

    }
}
