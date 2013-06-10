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
    /// DAL SQL Server implementation of <see cref="IE03_Continent_ReChildDal"/>
    /// </summary>
    public partial class E03_Continent_ReChildDal : IE03_Continent_ReChildDal
    {
        /// <summary>
        /// Inserts a new E03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="e03_Continent_ReChild">The E03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="E03_Continent_ReChildDto"/>.</returns>
        public E03_Continent_ReChildDto Insert(E03_Continent_ReChildDto e03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", e03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", e03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return e03_Continent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the E03_Continent_ReChild object.
        /// </summary>
        /// <param name="e03_Continent_ReChild">The E03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="E03_Continent_ReChildDto"/>.</returns>
        public E03_Continent_ReChildDto Update(E03_Continent_ReChildDto e03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", e03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", e03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E03_Continent_ReChild");
                }
            }
            return e03_Continent_ReChild;
        }

        /// <summary>
        /// Deletes the E03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID2">The parent Continent ID2.</param>
        public void Delete(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
