using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Oracle
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
        /// <returns>A data reader to the ProductTypeCachedNVL.</returns>
        public IDataReader Fetch()
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.GetProductTypeCachedNVL", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteReader();
                }
            }
        }

        #endregion

    }
}
