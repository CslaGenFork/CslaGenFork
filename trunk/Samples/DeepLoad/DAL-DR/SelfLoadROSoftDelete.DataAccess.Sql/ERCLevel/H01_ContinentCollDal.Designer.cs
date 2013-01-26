using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH01_ContinentCollDal"/>
    /// </summary>
    public partial class H01_ContinentCollDal : IH01_ContinentCollDal
    {
        /// <summary>
        /// Loads a H01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A data reader to the H01_ContinentColl.</returns>
        public IDataReader Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
