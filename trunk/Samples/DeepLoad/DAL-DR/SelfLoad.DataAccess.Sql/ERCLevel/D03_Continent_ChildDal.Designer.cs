using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID03_Continent_ChildDal"/>
    /// </summary>
    public partial class D03_Continent_ChildDal : ID03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a D03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The Continent ID1.</param>
        /// <returns>A data reader to the D03_Continent_Child.</returns>
        public IDataReader Fetch(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new D03_Continent_Child object in the database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        public void Insert(int continent_ID, string continent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the D03_Continent_Child object.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        public void Update(int continent_ID, string continent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D03_Continent_Child");
                }
            }
        }

        /// <summary>
        /// Deletes the D03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        public void Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
