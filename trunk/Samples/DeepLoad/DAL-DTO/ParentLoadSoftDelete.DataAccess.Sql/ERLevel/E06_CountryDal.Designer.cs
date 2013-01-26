using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IE06_CountryDal"/>
    /// </summary>
    public partial class E06_CountryDal : IE06_CountryDal
    {
        /// <summary>
        /// Inserts a new E06_Country object in the database.
        /// </summary>
        /// <param name="e06_Country">The E06 Country DTO.</param>
        /// <returns>The new <see cref="E06_CountryDto"/>.</returns>
        public E06_CountryDto Insert(E06_CountryDto e06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", e06_Country.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", e06_Country.Country_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", e06_Country.Country_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    e06_Country.Country_ID = (int)cmd.Parameters["@Country_ID"].Value;
                    e06_Country.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return e06_Country;
        }

        /// <summary>
        /// Updates in the database all changes made to the E06_Country object.
        /// </summary>
        /// <param name="e06_Country">The E06 Country DTO.</param>
        /// <returns>The updated <see cref="E06_CountryDto"/>.</returns>
        public E06_CountryDto Update(E06_CountryDto e06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", e06_Country.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", e06_Country.Country_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", e06_Country.ParentSubContinentID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", e06_Country.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E06_Country");

                    e06_Country.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return e06_Country;
        }

        /// <summary>
        /// Deletes the E06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
