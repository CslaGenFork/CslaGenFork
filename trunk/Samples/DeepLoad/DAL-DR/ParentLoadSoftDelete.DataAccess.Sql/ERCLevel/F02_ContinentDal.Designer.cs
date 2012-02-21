using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess.ERCLevel;
using ParentLoadSoftDelete.DataAccess;

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
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        
        public void Insert(out int continent_ID, string continent_Name)
        {
            continent_ID = -1;
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", continent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    continent_ID = (int)cmd.Parameters["@Continent_ID"].Value;
                                    }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the F02_Continent object.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        
        public void Update(int continent_ID, string continent_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", continent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F02_Continent");

                                    }
            }
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
