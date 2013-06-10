using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC06_CountryDal"/>
    /// </summary>
    public partial class C06_CountryDal : IC06_CountryDal
    {
        /// <summary>
        /// Inserts a new C06_Country object in the database.
        /// </summary>
        /// <param name="c06_Country">The C06 Country DTO.</param>
        /// <returns>The new <see cref="C06_CountryDto"/>.</returns>
        public C06_CountryDto Insert(C06_CountryDto c06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", c06_Country.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", c06_Country.Country_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", c06_Country.Country_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    c06_Country.Country_ID = (int)cmd.Parameters["@Country_ID"].Value;
                    c06_Country.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return c06_Country;
        }

        /// <summary>
        /// Updates in the database all changes made to the C06_Country object.
        /// </summary>
        /// <param name="c06_Country">The C06 Country DTO.</param>
        /// <returns>The updated <see cref="C06_CountryDto"/>.</returns>
        public C06_CountryDto Update(C06_CountryDto c06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", c06_Country.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", c06_Country.Country_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", c06_Country.ParentSubContinentID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", c06_Country.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C06_Country");

                    c06_Country.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return c06_Country;
        }

        /// <summary>
        /// Deletes the C06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
