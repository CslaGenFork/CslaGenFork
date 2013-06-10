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
    /// DAL SQL Server implementation of <see cref="IE03_Continent_ChildDal"/>
    /// </summary>
    public partial class E03_Continent_ChildDal : IE03_Continent_ChildDal
    {
        /// <summary>
        /// Inserts a new E03_Continent_Child object in the database.
        /// </summary>
        /// <param name="e03_Continent_Child">The E03 Continent Child DTO.</param>
        /// <returns>The new <see cref="E03_Continent_ChildDto"/>.</returns>
        public E03_Continent_ChildDto Insert(E03_Continent_ChildDto e03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", e03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", e03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return e03_Continent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the E03_Continent_Child object.
        /// </summary>
        /// <param name="e03_Continent_Child">The E03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="E03_Continent_ChildDto"/>.</returns>
        public E03_Continent_ChildDto Update(E03_Continent_ChildDto e03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", e03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", e03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E03_Continent_Child");
                }
            }
            return e03_Continent_Child;
        }

        /// <summary>
        /// Deletes the E03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        public void Delete(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
