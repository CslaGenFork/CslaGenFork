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
    /// DAL SQL Server implementation of <see cref="ID03_SubContinentCollDal"/>
    /// </summary>
    public partial class D03_SubContinentCollDal : ID03_SubContinentCollDal
    {
        /// <summary>
        /// Loads a D03_SubContinentColl collection from the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D04_SubContinentDto"/>.</returns>
        public List<D04_SubContinentDto> Fetch(int parent_Continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD03_SubContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", parent_Continent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<D04_SubContinentDto> LoadCollection(IDataReader data)
        {
            var d03_SubContinentColl = new List<D04_SubContinentDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    d03_SubContinentColl.Add(Fetch(dr));
                }
            }
            return d03_SubContinentColl;
        }

        private D04_SubContinentDto Fetch(SafeDataReader dr)
        {
            var d04_SubContinent = new D04_SubContinentDto();
            // Value properties
            d04_SubContinent.SubContinent_ID = dr.GetInt32("SubContinent_ID");
            d04_SubContinent.SubContinent_Name = dr.GetString("SubContinent_Name");

            return d04_SubContinent;
        }
    }
}
