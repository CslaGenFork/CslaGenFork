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
    /// DAL SQL Server implementation of <see cref="IB09_Region_ReChildDal"/>
    /// </summary>
    public partial class B09_Region_ReChildDal : IB09_Region_ReChildDal
    {
        /// <summary>
        /// Inserts a new B09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="b09_Region_ReChild">The B09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="B09_Region_ReChildDto"/>.</returns>
        public B09_Region_ReChildDto Insert(B09_Region_ReChildDto b09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", b09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", b09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return b09_Region_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the B09_Region_ReChild object.
        /// </summary>
        /// <param name="b09_Region_ReChild">The B09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="B09_Region_ReChildDto"/>.</returns>
        public B09_Region_ReChildDto Update(B09_Region_ReChildDto b09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", b09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", b09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B09_Region_ReChild");
                }
            }
            return b09_Region_ReChild;
        }

        /// <summary>
        /// Deletes the B09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        public void Delete(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
