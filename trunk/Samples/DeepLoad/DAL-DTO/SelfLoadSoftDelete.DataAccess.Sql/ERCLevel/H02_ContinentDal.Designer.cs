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
    /// DAL SQL Server implementation of <see cref="IH02_ContinentDal"/>
    /// </summary>
    public partial class H02_ContinentDal : IH02_ContinentDal
    {
        /// <summary>
        /// Inserts a new H02_Continent object in the database.
        /// </summary>
        /// <param name="h02_Continent">The H02 Continent DTO.</param>
        /// <returns>The new <see cref="H02_ContinentDto"/>.</returns>
        public H02_ContinentDto Insert(H02_ContinentDto h02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", h02_Continent.Continent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", h02_Continent.Continent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    h02_Continent.Continent_ID = (int)cmd.Parameters["@Continent_ID"].Value;
                }
            }
            return h02_Continent;
        }

        /// <summary>
        /// Updates in the database all changes made to the H02_Continent object.
        /// </summary>
        /// <param name="h02_Continent">The H02 Continent DTO.</param>
        /// <returns>The updated <see cref="H02_ContinentDto"/>.</returns>
        public H02_ContinentDto Update(H02_ContinentDto h02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", h02_Continent.Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", h02_Continent.Continent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H02_Continent");
                }
            }
            return h02_Continent;
        }

        /// <summary>
        /// Deletes the H02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        public void Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
