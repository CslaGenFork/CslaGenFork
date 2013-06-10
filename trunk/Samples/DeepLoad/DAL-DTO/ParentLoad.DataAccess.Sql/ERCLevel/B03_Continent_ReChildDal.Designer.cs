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
    /// DAL SQL Server implementation of <see cref="IB03_Continent_ReChildDal"/>
    /// </summary>
    public partial class B03_Continent_ReChildDal : IB03_Continent_ReChildDal
    {
        /// <summary>
        /// Inserts a new B03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="b03_Continent_ReChild">The B03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="B03_Continent_ReChildDto"/>.</returns>
        public B03_Continent_ReChildDto Insert(B03_Continent_ReChildDto b03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", b03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", b03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return b03_Continent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the B03_Continent_ReChild object.
        /// </summary>
        /// <param name="b03_Continent_ReChild">The B03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="B03_Continent_ReChildDto"/>.</returns>
        public B03_Continent_ReChildDto Update(B03_Continent_ReChildDto b03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", b03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", b03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B03_Continent_ReChild");
                }
            }
            return b03_Continent_ReChild;
        }

        /// <summary>
        /// Deletes the B03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID2">The parent Continent ID2.</param>
        public void Delete(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
