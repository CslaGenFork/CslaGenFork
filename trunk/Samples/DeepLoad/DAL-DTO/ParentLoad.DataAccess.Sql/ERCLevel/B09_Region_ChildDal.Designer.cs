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
    /// DAL SQL Server implementation of <see cref="IB09_Region_ChildDal"/>
    /// </summary>
    public partial class B09_Region_ChildDal : IB09_Region_ChildDal
    {
        /// <summary>
        /// Inserts a new B09_Region_Child object in the database.
        /// </summary>
        /// <param name="b09_Region_Child">The B09 Region Child DTO.</param>
        /// <returns>The new <see cref="B09_Region_ChildDto"/>.</returns>
        public B09_Region_ChildDto Insert(B09_Region_ChildDto b09_Region_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", b09_Region_Child.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", b09_Region_Child.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return b09_Region_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the B09_Region_Child object.
        /// </summary>
        /// <param name="b09_Region_Child">The B09 Region Child DTO.</param>
        /// <returns>The updated <see cref="B09_Region_ChildDto"/>.</returns>
        public B09_Region_ChildDto Update(B09_Region_ChildDto b09_Region_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", b09_Region_Child.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", b09_Region_Child.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B09_Region_Child");
                }
            }
            return b09_Region_Child;
        }

        /// <summary>
        /// Deletes the B09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        public void Delete(int region_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
