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
    /// DAL SQL Server implementation of <see cref="IE07_Country_ChildDal"/>
    /// </summary>
    public partial class E07_Country_ChildDal : IE07_Country_ChildDal
    {
        /// <summary>
        /// Inserts a new E07_Country_Child object in the database.
        /// </summary>
        /// <param name="e07_Country_Child">The E07 Country Child DTO.</param>
        /// <returns>The new <see cref="E07_Country_ChildDto"/>.</returns>
        public E07_Country_ChildDto Insert(E07_Country_ChildDto e07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", e07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", e07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return e07_Country_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the E07_Country_Child object.
        /// </summary>
        /// <param name="e07_Country_Child">The E07 Country Child DTO.</param>
        /// <returns>The updated <see cref="E07_Country_ChildDto"/>.</returns>
        public E07_Country_ChildDto Update(E07_Country_ChildDto e07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", e07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", e07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E07_Country_Child");
                }
            }
            return e07_Country_Child;
        }

        /// <summary>
        /// Deletes the E07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        public void Delete(int country_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", country_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
