using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERCLevel;

namespace SelfLoadRO.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID07_RegionCollDal"/>
    /// </summary>
    public partial class D07_RegionCollDal : ID07_RegionCollDal
    {
        /// <summary>
        /// Loads a D07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D08_RegionDto"/>.</returns>
        public List<D08_RegionDto> Fetch(int parent_Country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD07_RegionColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", parent_Country_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<D08_RegionDto> LoadCollection(IDataReader data)
        {
            var d07_RegionColl = new List<D08_RegionDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    d07_RegionColl.Add(Fetch(dr));
                }
            }
            return d07_RegionColl;
        }

        private D08_RegionDto Fetch(SafeDataReader dr)
        {
            var d08_Region = new D08_RegionDto();
            // Value properties
            d08_Region.Region_ID = dr.GetInt32("Region_ID");
            d08_Region.Region_Name = dr.GetString("Region_Name");

            return d08_Region;
        }
    }
}
