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
    /// DAL SQL Server implementation of <see cref="ID05_CountryCollDal"/>
    /// </summary>
    public partial class D05_CountryCollDal : ID05_CountryCollDal
    {
        /// <summary>
        /// Loads a D05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D06_CountryDto"/>.</returns>
        public List<D06_CountryDto> Fetch(int parent_SubContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD05_CountryColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", parent_SubContinent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<D06_CountryDto> LoadCollection(IDataReader data)
        {
            var d05_CountryColl = new List<D06_CountryDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    d05_CountryColl.Add(Fetch(dr));
                }
            }
            return d05_CountryColl;
        }

        private D06_CountryDto Fetch(SafeDataReader dr)
        {
            var d06_Country = new D06_CountryDto();
            // Value properties
            d06_Country.Country_ID = dr.GetInt32("Country_ID");
            d06_Country.Country_Name = dr.GetString("Country_Name");

            return d06_Country;
        }
    }
}
