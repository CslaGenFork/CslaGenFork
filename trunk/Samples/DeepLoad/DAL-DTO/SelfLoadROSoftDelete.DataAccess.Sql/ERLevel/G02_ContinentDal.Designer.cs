using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG02_ContinentDal"/>
    /// </summary>
    public partial class G02_ContinentDal : IG02_ContinentDal
    {
        /// <summary>
        /// Loads a G02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A G02_ContinentDto object.</returns>
        public G02_ContinentDto Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G02_ContinentDto Fetch(IDataReader data)
        {
            var g02_Continent = new G02_ContinentDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g02_Continent.Continent_ID = dr.GetInt32("Continent_ID");
                    g02_Continent.Continent_Name = dr.GetString("Continent_Name");
                }
            }
            return g02_Continent;
        }
    }
}
