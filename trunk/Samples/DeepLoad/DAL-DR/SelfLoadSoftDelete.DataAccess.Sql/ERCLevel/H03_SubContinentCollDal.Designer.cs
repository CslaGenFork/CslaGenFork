using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess.ERCLevel;
using SelfLoadSoftDelete.DataAccess;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH03_SubContinentCollDal"/>
    /// </summary>
    public partial class H03_SubContinentCollDal : IH03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a H03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The Parent Continent ID.</param>
        /// <returns>A data reader to the H03_SubContinentColl.</returns>
        public IDataReader Fetch(int parent_Continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH03_SubContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", parent_Continent_ID).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
