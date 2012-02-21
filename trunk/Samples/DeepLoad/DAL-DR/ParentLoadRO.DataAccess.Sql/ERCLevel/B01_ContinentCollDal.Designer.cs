using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadRO.DataAccess.ERCLevel;
using ParentLoadRO.DataAccess;

namespace ParentLoadRO.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IB01_ContinentCollDal"/>
    /// </summary>
    public partial class B01_ContinentCollDal : IB01_ContinentCollDal
    {

        /// <summary>
        /// Loads a B01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A data reader to the B01_ContinentColl.</returns>
        public IDataReader Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetB01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
