using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadRO.DataAccess.ERLevel;
using ParentLoadRO.DataAccess;

namespace ParentLoadRO.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IA02_ContinentDal"/>
    /// </summary>
    public partial class A02_ContinentDal : IA02_ContinentDal
    {

        /// <summary>
        /// Loads a A02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <returns>A data reader to the A02_Continent.</returns>
        public IDataReader Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetA02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
