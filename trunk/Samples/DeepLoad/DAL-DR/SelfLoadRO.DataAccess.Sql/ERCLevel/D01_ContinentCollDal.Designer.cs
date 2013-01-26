using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERCLevel;

namespace SelfLoadRO.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID01_ContinentCollDal"/>
    /// </summary>
    public partial class D01_ContinentCollDal : ID01_ContinentCollDal
    {
        /// <summary>
        /// Loads a D01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A data reader to the D01_ContinentColl.</returns>
        public IDataReader Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
