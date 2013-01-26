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
    /// DAL SQL Server implementation of <see cref="IB02_ContinentDal"/>
    /// </summary>
    public partial class B02_ContinentDal : IB02_ContinentDal
    {
        /// <summary>
        /// Inserts a new B02_Continent object in the database.
        /// </summary>
        /// <param name="b02_Continent">The B02 Continent DTO.</param>
        /// <returns>The new <see cref="B02_ContinentDto"/>.</returns>
        public B02_ContinentDto Insert(B02_ContinentDto b02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", b02_Continent.Continent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", b02_Continent.Continent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    b02_Continent.Continent_ID = (int)cmd.Parameters["@Continent_ID"].Value;
                }
            }
            return b02_Continent;
        }

        /// <summary>
        /// Updates in the database all changes made to the B02_Continent object.
        /// </summary>
        /// <param name="b02_Continent">The B02 Continent DTO.</param>
        /// <returns>The updated <see cref="B02_ContinentDto"/>.</returns>
        public B02_ContinentDto Update(B02_ContinentDto b02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", b02_Continent.Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", b02_Continent.Continent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B02_Continent");
                }
            }
            return b02_Continent;
        }

        /// <summary>
        /// Deletes the B02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        public void Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
