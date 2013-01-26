using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH07_RegionCollDal"/>
    /// </summary>
    public partial class H07_RegionCollDal : IH07_RegionCollDal
    {
        /// <summary>
        /// Loads a H07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H08_RegionDto"/>.</returns>
        public List<H08_RegionDto> Fetch(int parent_Country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH07_RegionColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", parent_Country_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<H08_RegionDto> LoadCollection(IDataReader data)
        {
            var h07_RegionColl = new List<H08_RegionDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    h07_RegionColl.Add(Fetch(dr));
                }
            }
            return h07_RegionColl;
        }

        private H08_RegionDto Fetch(SafeDataReader dr)
        {
            var h08_Region = new H08_RegionDto();
            // Value properties
            h08_Region.Region_ID = dr.GetInt32("Region_ID");
            h08_Region.Region_Name = dr.GetString("Region_Name");

            return h08_Region;
        }
    }
}
