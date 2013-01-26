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
    /// DAL SQL Server implementation of <see cref="IG03_SubContinentCollDal"/>
    /// </summary>
    public partial class G03_SubContinentCollDal : IG03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a G03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G04_SubContinentDto"/>.</returns>
        public List<G04_SubContinentDto> Fetch(int parent_Continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG03_SubContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", parent_Continent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<G04_SubContinentDto> LoadCollection(IDataReader data)
        {
            var g03_SubContinentColl = new List<G04_SubContinentDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    g03_SubContinentColl.Add(Fetch(dr));
                }
            }
            return g03_SubContinentColl;
        }

        private G04_SubContinentDto Fetch(SafeDataReader dr)
        {
            var g04_SubContinent = new G04_SubContinentDto();
            // Value properties
            g04_SubContinent.SubContinent_ID = dr.GetInt32("SubContinent_ID");
            g04_SubContinent.SubContinent_Name = dr.GetString("SubContinent_Name");

            return g04_SubContinent;
        }
    }
}
