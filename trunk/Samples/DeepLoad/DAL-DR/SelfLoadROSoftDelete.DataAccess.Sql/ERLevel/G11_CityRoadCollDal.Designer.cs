using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess.ERLevel;
using SelfLoadROSoftDelete.DataAccess;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG11_CityRoadCollDal"/>
    /// </summary>
    public partial class G11_CityRoadCollDal : IG11_CityRoadCollDal
    {

        /// <summary>
        /// Loads a G11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The Parent City ID.</param>
        /// <returns>A data reader to the G11_CityRoadColl.</returns>
        public IDataReader Fetch(int parent_City_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG11_CityRoadColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", parent_City_ID).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
