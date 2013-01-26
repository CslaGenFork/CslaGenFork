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
    /// DAL SQL Server implementation of <see cref="IG07_RegionCollDal"/>
    /// </summary>
    public partial class G07_RegionCollDal : IG07_RegionCollDal
    {
        /// <summary>
        /// Loads a G07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G08_RegionDto"/>.</returns>
        public List<G08_RegionDto> Fetch(int parent_Country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG07_RegionColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", parent_Country_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<G08_RegionDto> LoadCollection(IDataReader data)
        {
            var g07_RegionColl = new List<G08_RegionDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    g07_RegionColl.Add(Fetch(dr));
                }
            }
            return g07_RegionColl;
        }

        private G08_RegionDto Fetch(SafeDataReader dr)
        {
            var g08_Region = new G08_RegionDto();
            // Value properties
            g08_Region.Region_ID = dr.GetInt32("Region_ID");
            g08_Region.Region_Name = dr.GetString("Region_Name");

            return g08_Region;
        }
    }
}
