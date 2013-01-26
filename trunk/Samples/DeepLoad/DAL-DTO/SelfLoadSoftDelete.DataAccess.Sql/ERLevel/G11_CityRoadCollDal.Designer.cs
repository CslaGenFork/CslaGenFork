using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG11_CityRoadCollDal"/>
    /// </summary>
    public partial class G11_CityRoadCollDal : IG11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a G11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G12_CityRoadDto"/>.</returns>
        public List<G12_CityRoadDto> Fetch(int parent_City_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG11_CityRoadColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", parent_City_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<G12_CityRoadDto> LoadCollection(IDataReader data)
        {
            var g11_CityRoadColl = new List<G12_CityRoadDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    g11_CityRoadColl.Add(Fetch(dr));
                }
            }
            return g11_CityRoadColl;
        }

        private G12_CityRoadDto Fetch(SafeDataReader dr)
        {
            var g12_CityRoad = new G12_CityRoadDto();
            // Value properties
            g12_CityRoad.CityRoad_ID = dr.GetInt32("CityRoad_ID");
            g12_CityRoad.CityRoad_Name = dr.GetString("CityRoad_Name");

            return g12_CityRoad;
        }
    }
}
