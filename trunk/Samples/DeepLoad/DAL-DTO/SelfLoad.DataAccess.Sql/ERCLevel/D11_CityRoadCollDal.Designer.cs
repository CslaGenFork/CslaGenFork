using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID11_CityRoadCollDal"/>
    /// </summary>
    public partial class D11_CityRoadCollDal : ID11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a D11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D12_CityRoadDto"/>.</returns>
        public List<D12_CityRoadDto> Fetch(int parent_City_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD11_CityRoadColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", parent_City_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<D12_CityRoadDto> LoadCollection(IDataReader data)
        {
            var d11_CityRoadColl = new List<D12_CityRoadDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    d11_CityRoadColl.Add(Fetch(dr));
                }
            }
            return d11_CityRoadColl;
        }

        private D12_CityRoadDto Fetch(SafeDataReader dr)
        {
            var d12_CityRoad = new D12_CityRoadDto();
            // Value properties
            d12_CityRoad.CityRoad_ID = dr.GetInt32("CityRoad_ID");
            d12_CityRoad.CityRoad_Name = dr.GetString("CityRoad_Name");

            return d12_CityRoad;
        }
    }
}
