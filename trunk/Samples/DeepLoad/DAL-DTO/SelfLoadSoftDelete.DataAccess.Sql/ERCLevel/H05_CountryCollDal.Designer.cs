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
    /// DAL SQL Server implementation of <see cref="IH05_CountryCollDal"/>
    /// </summary>
    public partial class H05_CountryCollDal : IH05_CountryCollDal
    {
        /// <summary>
        /// Loads a H05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H06_CountryDto"/>.</returns>
        public List<H06_CountryDto> Fetch(int parent_SubContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH05_CountryColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", parent_SubContinent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<H06_CountryDto> LoadCollection(IDataReader data)
        {
            var h05_CountryColl = new List<H06_CountryDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    h05_CountryColl.Add(Fetch(dr));
                }
            }
            return h05_CountryColl;
        }

        private H06_CountryDto Fetch(SafeDataReader dr)
        {
            var h06_Country = new H06_CountryDto();
            // Value properties
            h06_Country.Country_ID = dr.GetInt32("Country_ID");
            h06_Country.Country_Name = dr.GetString("Country_Name");

            return h06_Country;
        }
    }
}
