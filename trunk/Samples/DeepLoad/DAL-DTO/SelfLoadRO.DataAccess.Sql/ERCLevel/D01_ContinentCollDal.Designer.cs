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
    /// DAL SQL Server implementation of <see cref="ID01_ContinentCollDal"/>
    /// </summary>
    public partial class D01_ContinentCollDal : ID01_ContinentCollDal
    {
        /// <summary>
        /// Loads a D01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="D02_ContinentDto"/>.</returns>
        public List<D02_ContinentDto> Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<D02_ContinentDto> LoadCollection(IDataReader data)
        {
            var d01_ContinentColl = new List<D02_ContinentDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    d01_ContinentColl.Add(Fetch(dr));
                }
            }
            return d01_ContinentColl;
        }

        private D02_ContinentDto Fetch(SafeDataReader dr)
        {
            var d02_Continent = new D02_ContinentDto();
            // Value properties
            d02_Continent.Continent_ID = dr.GetInt32("Continent_ID");
            d02_Continent.Continent_Name = dr.GetString("Continent_Name");

            return d02_Continent;
        }
    }
}
