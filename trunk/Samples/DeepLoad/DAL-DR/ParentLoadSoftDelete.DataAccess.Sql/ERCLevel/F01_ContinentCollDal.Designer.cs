using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess.ERCLevel;
using ParentLoadSoftDelete.DataAccess;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IF01_ContinentCollDal"/>
    /// </summary>
    public partial class F01_ContinentCollDal : IF01_ContinentCollDal
    {
        /// <summary>
        /// Loads a F01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A data reader to the F01_ContinentColl.</returns>
        public IDataReader Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetF01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
