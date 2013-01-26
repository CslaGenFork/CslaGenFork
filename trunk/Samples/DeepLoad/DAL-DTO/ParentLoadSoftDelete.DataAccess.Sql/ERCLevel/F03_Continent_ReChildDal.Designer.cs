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
    /// DAL SQL Server implementation of <see cref="IF03_Continent_ReChildDal"/>
    /// </summary>
    public partial class F03_Continent_ReChildDal : IF03_Continent_ReChildDal
    {
        /// <summary>
        /// Inserts a new F03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="f03_Continent_ReChild">The F03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="F03_Continent_ReChildDto"/>.</returns>
        public F03_Continent_ReChildDto Insert(F03_Continent_ReChildDto f03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", f03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", f03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return f03_Continent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the F03_Continent_ReChild object.
        /// </summary>
        /// <param name="f03_Continent_ReChild">The F03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="F03_Continent_ReChildDto"/>.</returns>
        public F03_Continent_ReChildDto Update(F03_Continent_ReChildDto f03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", f03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", f03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F03_Continent_ReChild");
                }
            }
            return f03_Continent_ReChild;
        }

        /// <summary>
        /// Deletes the F03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        public void Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
