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
    /// DAL SQL Server implementation of <see cref="IE04_SubContinentDal"/>
    /// </summary>
    public partial class E04_SubContinentDal : IE04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new E04_SubContinent object in the database.
        /// </summary>
        /// <param name="e04_SubContinent">The E04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="E04_SubContinentDto"/>.</returns>
        public E04_SubContinentDto Insert(E04_SubContinentDto e04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", e04_SubContinent.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", e04_SubContinent.SubContinent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", e04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    e04_SubContinent.SubContinent_ID = (int)cmd.Parameters["@SubContinent_ID"].Value;
                }
            }
            return e04_SubContinent;
        }

        /// <summary>
        /// Updates in the database all changes made to the E04_SubContinent object.
        /// </summary>
        /// <param name="e04_SubContinent">The E04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="E04_SubContinentDto"/>.</returns>
        public E04_SubContinentDto Update(E04_SubContinentDto e04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", e04_SubContinent.SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", e04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E04_SubContinent");
                }
            }
            return e04_SubContinent;
        }

        /// <summary>
        /// Deletes the E04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
