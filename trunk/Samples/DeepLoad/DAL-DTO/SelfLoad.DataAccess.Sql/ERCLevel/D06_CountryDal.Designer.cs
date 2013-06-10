using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID06_CountryDal"/>
    /// </summary>
    public partial class D06_CountryDal : ID06_CountryDal
    {
        /// <summary>
        /// Inserts a new D06_Country object in the database.
        /// </summary>
        /// <param name="d06_Country">The D06 Country DTO.</param>
        /// <returns>The new <see cref="D06_CountryDto"/>.</returns>
        public D06_CountryDto Insert(D06_CountryDto d06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", d06_Country.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", d06_Country.Country_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", d06_Country.Country_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    d06_Country.Country_ID = (int)cmd.Parameters["@Country_ID"].Value;
                }
            }
            return d06_Country;
        }

        /// <summary>
        /// Updates in the database all changes made to the D06_Country object.
        /// </summary>
        /// <param name="d06_Country">The D06 Country DTO.</param>
        /// <returns>The updated <see cref="D06_CountryDto"/>.</returns>
        public D06_CountryDto Update(D06_CountryDto d06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", d06_Country.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", d06_Country.Country_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D06_Country");
                }
            }
            return d06_Country;
        }

        /// <summary>
        /// Deletes the D06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
