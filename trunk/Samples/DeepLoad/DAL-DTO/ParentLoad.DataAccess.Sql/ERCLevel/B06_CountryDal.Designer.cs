using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IB06_CountryDal"/>
    /// </summary>
    public partial class B06_CountryDal : IB06_CountryDal
    {
        /// <summary>
        /// Inserts a new B06_Country object in the database.
        /// </summary>
        /// <param name="b06_Country">The B06 Country DTO.</param>
        /// <returns>The new <see cref="B06_CountryDto"/>.</returns>
        public B06_CountryDto Insert(B06_CountryDto b06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", b06_Country.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", b06_Country.Country_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", b06_Country.Country_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    b06_Country.Country_ID = (int)cmd.Parameters["@Country_ID"].Value;
                }
            }
            return b06_Country;
        }

        /// <summary>
        /// Updates in the database all changes made to the B06_Country object.
        /// </summary>
        /// <param name="b06_Country">The B06 Country DTO.</param>
        /// <returns>The updated <see cref="B06_CountryDto"/>.</returns>
        public B06_CountryDto Update(B06_CountryDto b06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", b06_Country.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", b06_Country.Country_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B06_Country");
                }
            }
            return b06_Country;
        }

        /// <summary>
        /// Deletes the B06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
