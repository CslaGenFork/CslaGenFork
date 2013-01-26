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
    /// DAL SQL Server implementation of <see cref="IH03_SubContinentCollDal"/>
    /// </summary>
    public partial class H03_SubContinentCollDal : IH03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a H03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H04_SubContinentDto"/>.</returns>
        public List<H04_SubContinentDto> Fetch(int parent_Continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH03_SubContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", parent_Continent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<H04_SubContinentDto> LoadCollection(IDataReader data)
        {
            var h03_SubContinentColl = new List<H04_SubContinentDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    h03_SubContinentColl.Add(Fetch(dr));
                }
            }
            return h03_SubContinentColl;
        }

        private H04_SubContinentDto Fetch(SafeDataReader dr)
        {
            var h04_SubContinent = new H04_SubContinentDto();
            // Value properties
            h04_SubContinent.SubContinent_ID = dr.GetInt32("SubContinent_ID");
            h04_SubContinent.SubContinent_Name = dr.GetString("SubContinent_Name");

            return h04_SubContinent;
        }
    }
}
