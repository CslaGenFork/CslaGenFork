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
    /// DAL SQL Server implementation of <see cref="IH06_CountryDal"/>
    /// </summary>
    public partial class H06_CountryDal : IH06_CountryDal
    {
        /// <summary>
        /// Inserts a new H06_Country object in the database.
        /// </summary>
        /// <param name="h06_Country">The H06 Country DTO.</param>
        /// <returns>The new <see cref="H06_CountryDto"/>.</returns>
        public H06_CountryDto Insert(H06_CountryDto h06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", h06_Country.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", h06_Country.Country_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", h06_Country.Country_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    h06_Country.Country_ID = (int)cmd.Parameters["@Country_ID"].Value;
                }
            }
            return h06_Country;
        }

        /// <summary>
        /// Updates in the database all changes made to the H06_Country object.
        /// </summary>
        /// <param name="h06_Country">The H06 Country DTO.</param>
        /// <returns>The updated <see cref="H06_CountryDto"/>.</returns>
        public H06_CountryDto Update(H06_CountryDto h06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", h06_Country.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", h06_Country.Country_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H06_Country");
                }
            }
            return h06_Country;
        }

        /// <summary>
        /// Deletes the H06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
