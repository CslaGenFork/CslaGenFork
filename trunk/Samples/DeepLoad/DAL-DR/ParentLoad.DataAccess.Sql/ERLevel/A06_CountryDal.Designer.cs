using System;
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
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        /// <returns>The Row Version of the new A06_Country.</returns>
        public byte[] Insert(int subContinent_ID, out int country_ID, string country_Name)
        {
            country_ID = -1;
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", country_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    country_ID = (int)cmd.Parameters["@Country_ID"].Value;
                    return (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the A06_Country object.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        /// <param name="parentSubContinentID">The Parent Sub Continent ID.</param>
        /// <param name="rowVersion">The Row Version.</param>
        /// <returns>The updated Row Version.</returns>
        public byte[] Update(int country_ID, string country_Name, int parentSubContinentID, byte[] rowVersion)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", country_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", parentSubContinentID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", rowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A06_Country");

                    return (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
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
