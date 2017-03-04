using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Oracle
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IProductTypeNVLDal"/>
    /// </summary>
    public partial class ProductTypeNVLDal : IProductTypeNVLDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a ProductTypeNVL list from the database.
        /// </summary>
        /// <returns>A data reader to the ProductTypeNVL.</returns>
        public IDataReader Fetch()
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.GetProductTypeNVL", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteReader();
                }
            }
        }

        #endregion

    }
}
