using System;
using System.Data;
using MySql.Data.MySqlClient;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.DataAccess.MySql
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ISupplierProductCollDal"/>
    /// </summary>
    public partial class SupplierProductCollDal : ISupplierProductCollDal
    {

        #region DAL methods

        /// <summary>
        /// Loads a SupplierProductColl collection from the database.
        /// </summary>
        /// <param name="supplierId">The Supplier Id.</param>
        /// <returns>A data reader to the SupplierProductColl.</returns>
        public IDataReader Fetch(int supplierId)
        {
            using (var ctx = ConnectionManager<MySqlConnection>.GetManager("Invoices"))
            {
                using (var cmd = new MySqlCommand("dbo.GetSupplierProductColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        #endregion

    }
}
