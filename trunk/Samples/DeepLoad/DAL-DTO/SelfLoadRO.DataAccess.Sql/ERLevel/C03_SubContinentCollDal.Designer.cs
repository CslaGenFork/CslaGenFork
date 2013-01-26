using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERLevel;

namespace SelfLoadRO.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC03_SubContinentCollDal"/>
    /// </summary>
    public partial class C03_SubContinentCollDal : IC03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a C03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C04_SubContinentDto"/>.</returns>
        public List<C04_SubContinentDto> Fetch(int parent_Continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC03_SubContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", parent_Continent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<C04_SubContinentDto> LoadCollection(IDataReader data)
        {
            var c03_SubContinentColl = new List<C04_SubContinentDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    c03_SubContinentColl.Add(Fetch(dr));
                }
            }
            return c03_SubContinentColl;
        }

        private C04_SubContinentDto Fetch(SafeDataReader dr)
        {
            var c04_SubContinent = new C04_SubContinentDto();
            // Value properties
            c04_SubContinent.SubContinent_ID = dr.GetInt32("SubContinent_ID");
            c04_SubContinent.SubContinent_Name = dr.GetString("SubContinent_Name");

            return c04_SubContinent;
        }
    }
}
