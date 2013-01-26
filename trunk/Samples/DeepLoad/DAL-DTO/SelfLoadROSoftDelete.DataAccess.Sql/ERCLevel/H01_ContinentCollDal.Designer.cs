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
    /// DAL SQL Server implementation of <see cref="IH01_ContinentCollDal"/>
    /// </summary>
    public partial class H01_ContinentCollDal : IH01_ContinentCollDal
    {
        /// <summary>
        /// Loads a H01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="H02_ContinentDto"/>.</returns>
        public List<H02_ContinentDto> Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<H02_ContinentDto> LoadCollection(IDataReader data)
        {
            var h01_ContinentColl = new List<H02_ContinentDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    h01_ContinentColl.Add(Fetch(dr));
                }
            }
            return h01_ContinentColl;
        }

        private H02_ContinentDto Fetch(SafeDataReader dr)
        {
            var h02_Continent = new H02_ContinentDto();
            // Value properties
            h02_Continent.Continent_ID = dr.GetInt32("Continent_ID");
            h02_Continent.Continent_Name = dr.GetString("Continent_Name");

            return h02_Continent;
        }
    }
}
