using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH11_CityRoadCollDal"/>
    /// </summary>
    public partial class H11_CityRoadCollDal : IH11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a H11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H12_CityRoadDto"/>.</returns>
        public List<H12_CityRoadDto> Fetch(int parent_City_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH11_CityRoadColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", parent_City_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<H12_CityRoadDto> LoadCollection(IDataReader data)
        {
            var h11_CityRoadColl = new List<H12_CityRoadDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    h11_CityRoadColl.Add(Fetch(dr));
                }
            }
            return h11_CityRoadColl;
        }

        private H12_CityRoadDto Fetch(SafeDataReader dr)
        {
            var h12_CityRoad = new H12_CityRoadDto();
            // Value properties
            h12_CityRoad.CityRoad_ID = dr.GetInt32("CityRoad_ID");
            h12_CityRoad.CityRoad_Name = dr.GetString("CityRoad_Name");

            return h12_CityRoad;
        }
    }
}
