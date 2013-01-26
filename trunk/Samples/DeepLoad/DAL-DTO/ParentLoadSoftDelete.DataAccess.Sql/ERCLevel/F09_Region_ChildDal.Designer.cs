using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IF09_Region_ChildDal"/>
    /// </summary>
    public partial class F09_Region_ChildDal : IF09_Region_ChildDal
    {
        /// <summary>
        /// Inserts a new F09_Region_Child object in the database.
        /// </summary>
        /// <param name="f09_Region_Child">The F09 Region Child DTO.</param>
        /// <returns>The new <see cref="F09_Region_ChildDto"/>.</returns>
        public F09_Region_ChildDto Insert(F09_Region_ChildDto f09_Region_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", f09_Region_Child.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", f09_Region_Child.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return f09_Region_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the F09_Region_Child object.
        /// </summary>
        /// <param name="f09_Region_Child">The F09 Region Child DTO.</param>
        /// <returns>The updated <see cref="F09_Region_ChildDto"/>.</returns>
        public F09_Region_ChildDto Update(F09_Region_ChildDto f09_Region_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", f09_Region_Child.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", f09_Region_Child.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F09_Region_Child");
                }
            }
            return f09_Region_Child;
        }

        /// <summary>
        /// Deletes the F09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
