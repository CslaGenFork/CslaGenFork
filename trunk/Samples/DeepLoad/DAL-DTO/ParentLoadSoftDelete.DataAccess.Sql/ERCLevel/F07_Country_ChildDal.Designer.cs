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
    /// DAL SQL Server implementation of <see cref="IF07_Country_ChildDal"/>
    /// </summary>
    public partial class F07_Country_ChildDal : IF07_Country_ChildDal
    {
        /// <summary>
        /// Inserts a new F07_Country_Child object in the database.
        /// </summary>
        /// <param name="f07_Country_Child">The F07 Country Child DTO.</param>
        /// <returns>The new <see cref="F07_Country_ChildDto"/>.</returns>
        public F07_Country_ChildDto Insert(F07_Country_ChildDto f07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", f07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", f07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return f07_Country_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the F07_Country_Child object.
        /// </summary>
        /// <param name="f07_Country_Child">The F07 Country Child DTO.</param>
        /// <returns>The updated <see cref="F07_Country_ChildDto"/>.</returns>
        public F07_Country_ChildDto Update(F07_Country_ChildDto f07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", f07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", f07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F07_Country_Child");
                }
            }
            return f07_Country_Child;
        }

        /// <summary>
        /// Deletes the F07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        public void Delete(int country_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", country_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
