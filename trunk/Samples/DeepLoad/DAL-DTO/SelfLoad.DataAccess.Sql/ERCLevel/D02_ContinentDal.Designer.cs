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
    /// DAL SQL Server implementation of <see cref="ID02_ContinentDal"/>
    /// </summary>
    public partial class D02_ContinentDal : ID02_ContinentDal
    {
        /// <summary>
        /// Inserts a new D02_Continent object in the database.
        /// </summary>
        /// <param name="d02_Continent">The D02 Continent DTO.</param>
        /// <returns>The new <see cref="D02_ContinentDto"/>.</returns>
        public D02_ContinentDto Insert(D02_ContinentDto d02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", d02_Continent.Continent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", d02_Continent.Continent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    d02_Continent.Continent_ID = (int)cmd.Parameters["@Continent_ID"].Value;
                }
            }
            return d02_Continent;
        }

        /// <summary>
        /// Updates in the database all changes made to the D02_Continent object.
        /// </summary>
        /// <param name="d02_Continent">The D02 Continent DTO.</param>
        /// <returns>The updated <see cref="D02_ContinentDto"/>.</returns>
        public D02_ContinentDto Update(D02_ContinentDto d02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", d02_Continent.Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", d02_Continent.Continent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D02_Continent");
                }
            }
            return d02_Continent;
        }

        /// <summary>
        /// Deletes the D02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        public void Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
