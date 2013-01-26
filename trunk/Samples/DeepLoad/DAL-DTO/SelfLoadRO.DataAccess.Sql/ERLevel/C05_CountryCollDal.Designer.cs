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
    /// DAL SQL Server implementation of <see cref="IC05_CountryCollDal"/>
    /// </summary>
    public partial class C05_CountryCollDal : IC05_CountryCollDal
    {
        /// <summary>
        /// Loads a C05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C06_CountryDto"/>.</returns>
        public List<C06_CountryDto> Fetch(int parent_SubContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC05_CountryColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", parent_SubContinent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<C06_CountryDto> LoadCollection(IDataReader data)
        {
            var c05_CountryColl = new List<C06_CountryDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    c05_CountryColl.Add(Fetch(dr));
                }
            }
            return c05_CountryColl;
        }

        private C06_CountryDto Fetch(SafeDataReader dr)
        {
            var c06_Country = new C06_CountryDto();
            // Value properties
            c06_Country.Country_ID = dr.GetInt32("Country_ID");
            c06_Country.Country_Name = dr.GetString("Country_Name");
            c06_Country.ParentSubContinentID = dr.GetInt32("Parent_SubContinent_ID");
            c06_Country.RowVersion = dr.GetValue("RowVersion") as byte[];

            return c06_Country;
        }
    }
}
