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
    /// DAL SQL Server implementation of <see cref="IH03_Continent_ReChildDal"/>
    /// </summary>
    public partial class H03_Continent_ReChildDal : IH03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The Continent ID2.</param>
        /// <returns>A data reader to the H03_Continent_ReChild.</returns>
        public IDataReader Fetch(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
