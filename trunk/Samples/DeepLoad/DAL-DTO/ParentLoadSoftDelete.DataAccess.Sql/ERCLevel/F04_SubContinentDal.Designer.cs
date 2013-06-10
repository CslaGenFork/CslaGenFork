using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IF04_SubContinentDal"/>
    /// </summary>
    public partial class F04_SubContinentDal : IF04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new F04_SubContinent object in the database.
        /// </summary>
        /// <param name="f04_SubContinent">The F04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="F04_SubContinentDto"/>.</returns>
        public F04_SubContinentDto Insert(F04_SubContinentDto f04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", f04_SubContinent.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", f04_SubContinent.SubContinent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", f04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    f04_SubContinent.SubContinent_ID = (int)cmd.Parameters["@SubContinent_ID"].Value;
                }
            }
            return f04_SubContinent;
        }

        /// <summary>
        /// Updates in the database all changes made to the F04_SubContinent object.
        /// </summary>
        /// <param name="f04_SubContinent">The F04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="F04_SubContinentDto"/>.</returns>
        public F04_SubContinentDto Update(F04_SubContinentDto f04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", f04_SubContinent.SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", f04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F04_SubContinent");
                }
            }
            return f04_SubContinent;
        }

        /// <summary>
        /// Deletes the F04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
