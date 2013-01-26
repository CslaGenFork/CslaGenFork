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
    /// DAL SQL Server implementation of <see cref="IF02_ContinentDal"/>
    /// </summary>
    public partial class F02_ContinentDal : IF02_ContinentDal
    {
        /// <summary>
        /// Inserts a new F02_Continent object in the database.
        /// </summary>
        /// <param name="f02_Continent">The F02 Continent DTO.</param>
        /// <returns>The new <see cref="F02_ContinentDto"/>.</returns>
        public F02_ContinentDto Insert(F02_ContinentDto f02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", f02_Continent.Continent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", f02_Continent.Continent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    f02_Continent.Continent_ID = (int)cmd.Parameters["@Continent_ID"].Value;
                }
            }
            return f02_Continent;
        }

        /// <summary>
        /// Updates in the database all changes made to the F02_Continent object.
        /// </summary>
        /// <param name="f02_Continent">The F02 Continent DTO.</param>
        /// <returns>The updated <see cref="F02_ContinentDto"/>.</returns>
        public F02_ContinentDto Update(F02_ContinentDto f02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", f02_Continent.Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", f02_Continent.Continent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F02_Continent");
                }
            }
            return f02_Continent;
        }

        /// <summary>
        /// Deletes the F02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        public void Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
