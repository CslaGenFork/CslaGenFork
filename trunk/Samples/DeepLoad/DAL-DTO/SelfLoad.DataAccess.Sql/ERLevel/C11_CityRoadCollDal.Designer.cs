using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC11_CityRoadCollDal"/>
    /// </summary>
    public partial class C11_CityRoadCollDal : IC11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a C11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C12_CityRoadDto"/>.</returns>
        public List<C12_CityRoadDto> Fetch(int parent_City_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC11_CityRoadColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", parent_City_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<C12_CityRoadDto> LoadCollection(IDataReader data)
        {
            var c11_CityRoadColl = new List<C12_CityRoadDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    c11_CityRoadColl.Add(Fetch(dr));
                }
            }
            return c11_CityRoadColl;
        }

        private C12_CityRoadDto Fetch(SafeDataReader dr)
        {
            var c12_CityRoad = new C12_CityRoadDto();
            // Value properties
            c12_CityRoad.CityRoad_ID = dr.GetInt32("CityRoad_ID");
            c12_CityRoad.CityRoad_Name = dr.GetString("CityRoad_Name");

            return c12_CityRoad;
        }
    }
}
