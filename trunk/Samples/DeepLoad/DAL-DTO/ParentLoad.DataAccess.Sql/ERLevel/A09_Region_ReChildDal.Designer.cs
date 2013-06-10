using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IA09_Region_ReChildDal"/>
    /// </summary>
    public partial class A09_Region_ReChildDal : IA09_Region_ReChildDal
    {
        /// <summary>
        /// Inserts a new A09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="a09_Region_ReChild">The A09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="A09_Region_ReChildDto"/>.</returns>
        public A09_Region_ReChildDto Insert(A09_Region_ReChildDto a09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", a09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", a09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return a09_Region_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the A09_Region_ReChild object.
        /// </summary>
        /// <param name="a09_Region_ReChild">The A09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="A09_Region_ReChildDto"/>.</returns>
        public A09_Region_ReChildDto Update(A09_Region_ReChildDto a09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", a09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", a09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A09_Region_ReChild");
                }
            }
            return a09_Region_ReChild;
        }

        /// <summary>
        /// Deletes the A09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        public void Delete(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteA09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
