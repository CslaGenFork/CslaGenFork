using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IE09_Region_ReChildDal"/>
    /// </summary>
    public partial class E09_Region_ReChildDal : IE09_Region_ReChildDal
    {
        /// <summary>
        /// Inserts a new E09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        public void Insert(int region_ID2, string region_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the E09_Region_ReChild object.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        public void Update(int region_ID2, string region_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E09_Region_ReChild");
                }
            }
        }

        /// <summary>
        /// Deletes the E09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        public void Delete(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
