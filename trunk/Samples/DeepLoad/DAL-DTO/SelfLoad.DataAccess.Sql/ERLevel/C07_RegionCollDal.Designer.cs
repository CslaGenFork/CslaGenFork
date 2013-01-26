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
    /// DAL SQL Server implementation of <see cref="IC07_RegionCollDal"/>
    /// </summary>
    public partial class C07_RegionCollDal : IC07_RegionCollDal
    {
        /// <summary>
        /// Loads a C07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C08_RegionDto"/>.</returns>
        public List<C08_RegionDto> Fetch(int parent_Country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC07_RegionColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", parent_Country_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<C08_RegionDto> LoadCollection(IDataReader data)
        {
            var c07_RegionColl = new List<C08_RegionDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    c07_RegionColl.Add(Fetch(dr));
                }
            }
            return c07_RegionColl;
        }

        private C08_RegionDto Fetch(SafeDataReader dr)
        {
            var c08_Region = new C08_RegionDto();
            // Value properties
            c08_Region.Region_ID = dr.GetInt32("Region_ID");
            c08_Region.Region_Name = dr.GetString("Region_Name");

            return c08_Region;
        }
    }
}
