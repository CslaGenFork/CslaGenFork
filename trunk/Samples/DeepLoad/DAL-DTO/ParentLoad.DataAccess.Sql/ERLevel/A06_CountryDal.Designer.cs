using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IA06_CountryDal"/>
    /// </summary>
    public partial class A06_CountryDal : IA06_CountryDal
    {
        /// <summary>
        /// Inserts a new A06_Country object in the database.
        /// </summary>
        /// <param name="a06_Country">The A06 Country DTO.</param>
        /// <returns>The new <see cref="A06_CountryDto"/>.</returns>
        public A06_CountryDto Insert(A06_CountryDto a06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", a06_Country.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", a06_Country.Country_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", a06_Country.Country_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    a06_Country.Country_ID = (int)cmd.Parameters["@Country_ID"].Value;
                    a06_Country.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return a06_Country;
        }

        /// <summary>
        /// Updates in the database all changes made to the A06_Country object.
        /// </summary>
        /// <param name="a06_Country">The A06 Country DTO.</param>
        /// <returns>The updated <see cref="A06_CountryDto"/>.</returns>
        public A06_CountryDto Update(A06_CountryDto a06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", a06_Country.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", a06_Country.Country_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", a06_Country.ParentSubContinentID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", a06_Country.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A06_Country");

                    a06_Country.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return a06_Country;
        }

        /// <summary>
        /// Deletes the A06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteA06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
