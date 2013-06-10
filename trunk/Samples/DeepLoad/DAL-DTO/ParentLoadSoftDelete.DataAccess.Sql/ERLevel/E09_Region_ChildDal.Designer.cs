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
    /// DAL SQL Server implementation of <see cref="IE09_Region_ChildDal"/>
    /// </summary>
    public partial class E09_Region_ChildDal : IE09_Region_ChildDal
    {
        /// <summary>
        /// Inserts a new E09_Region_Child object in the database.
        /// </summary>
        /// <param name="e09_Region_Child">The E09 Region Child DTO.</param>
        /// <returns>The new <see cref="E09_Region_ChildDto"/>.</returns>
        public E09_Region_ChildDto Insert(E09_Region_ChildDto e09_Region_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", e09_Region_Child.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", e09_Region_Child.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return e09_Region_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the E09_Region_Child object.
        /// </summary>
        /// <param name="e09_Region_Child">The E09 Region Child DTO.</param>
        /// <returns>The updated <see cref="E09_Region_ChildDto"/>.</returns>
        public E09_Region_ChildDto Update(E09_Region_ChildDto e09_Region_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", e09_Region_Child.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", e09_Region_Child.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E09_Region_Child");
                }
            }
            return e09_Region_Child;
        }

        /// <summary>
        /// Deletes the E09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        public void Delete(int region_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
