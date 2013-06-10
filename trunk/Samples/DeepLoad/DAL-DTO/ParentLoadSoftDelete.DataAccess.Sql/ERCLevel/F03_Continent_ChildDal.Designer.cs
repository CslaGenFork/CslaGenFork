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
    /// DAL SQL Server implementation of <see cref="IF03_Continent_ChildDal"/>
    /// </summary>
    public partial class F03_Continent_ChildDal : IF03_Continent_ChildDal
    {
        /// <summary>
        /// Inserts a new F03_Continent_Child object in the database.
        /// </summary>
        /// <param name="f03_Continent_Child">The F03 Continent Child DTO.</param>
        /// <returns>The new <see cref="F03_Continent_ChildDto"/>.</returns>
        public F03_Continent_ChildDto Insert(F03_Continent_ChildDto f03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", f03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", f03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return f03_Continent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the F03_Continent_Child object.
        /// </summary>
        /// <param name="f03_Continent_Child">The F03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="F03_Continent_ChildDto"/>.</returns>
        public F03_Continent_ChildDto Update(F03_Continent_ChildDto f03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", f03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", f03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F03_Continent_Child");
                }
            }
            return f03_Continent_Child;
        }

        /// <summary>
        /// Deletes the F03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        public void Delete(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
