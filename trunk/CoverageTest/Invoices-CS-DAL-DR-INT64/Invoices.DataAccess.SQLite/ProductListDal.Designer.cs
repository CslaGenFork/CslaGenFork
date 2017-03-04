using System;
using System.Data;
using System.Data.SQLite;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.SQLite
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
            using (var ctx = ConnectionManager<SQLiteConnection>.GetManager("Invoices"))
            {
                using (var cmd = new SQLiteCommand("dbo.GetProductList", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteReader();
                }
            }
        }

        #endregion

    }
}
