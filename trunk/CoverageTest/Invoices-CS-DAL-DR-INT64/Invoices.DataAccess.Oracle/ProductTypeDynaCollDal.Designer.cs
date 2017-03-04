using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.Oracle
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
        /// <returns>A data reader to the ProductTypeDynaColl.</returns>
        public IDataReader Fetch()
        {
            using (var ctx = ConnectionManager<OracleConnection>.GetManager("Invoices"))
            {
                using (var cmd = new OracleCommand("dbo.GetProductTypeDynaColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteReader();
                }
            }
        }

        #endregion

    }
}
