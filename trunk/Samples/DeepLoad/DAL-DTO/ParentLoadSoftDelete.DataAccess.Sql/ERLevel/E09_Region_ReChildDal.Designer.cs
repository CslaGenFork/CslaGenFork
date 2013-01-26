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
    /// DAL SQL Server implementation of <see cref="IE09_Region_ReChildDal"/>
    /// </summary>
    public partial class E09_Region_ReChildDal : IE09_Region_ReChildDal
    {
        /// <summary>
        /// Inserts a new E09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="e09_Region_ReChild">The E09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="E09_Region_ReChildDto"/>.</returns>
        public E09_Region_ReChildDto Insert(E09_Region_ReChildDto e09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", e09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", e09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return e09_Region_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the E09_Region_ReChild object.
        /// </summary>
        /// <param name="e09_Region_ReChild">The E09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="E09_Region_ReChildDto"/>.</returns>
        public E09_Region_ReChildDto Update(E09_Region_ReChildDto e09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", e09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", e09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E09_Region_ReChild");
                }
            }
            return e09_Region_ReChild;
        }

        /// <summary>
        /// Deletes the E09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
