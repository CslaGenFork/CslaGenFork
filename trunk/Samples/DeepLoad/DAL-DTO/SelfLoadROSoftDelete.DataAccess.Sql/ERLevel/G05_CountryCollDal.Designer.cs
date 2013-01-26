using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG05_CountryCollDal"/>
    /// </summary>
    public partial class G05_CountryCollDal : IG05_CountryCollDal
    {
        /// <summary>
        /// Loads a G05_CountryColl collection from the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G06_CountryDto"/>.</returns>
        public List<G06_CountryDto> Fetch(int parent_SubContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG05_CountryColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", parent_SubContinent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<G06_CountryDto> LoadCollection(IDataReader data)
        {
            var g05_CountryColl = new List<G06_CountryDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    g05_CountryColl.Add(Fetch(dr));
                }
            }
            return g05_CountryColl;
        }

        private G06_CountryDto Fetch(SafeDataReader dr)
        {
            var g06_Country = new G06_CountryDto();
            // Value properties
            g06_Country.Country_ID = dr.GetInt32("Country_ID");
            g06_Country.Country_Name = dr.GetString("Country_Name");
            g06_Country.ParentSubContinentID = dr.GetInt32("Parent_SubContinent_ID");
            g06_Country.RowVersion = dr.GetValue("RowVersion") as byte[];

            return g06_Country;
        }
    }
}
