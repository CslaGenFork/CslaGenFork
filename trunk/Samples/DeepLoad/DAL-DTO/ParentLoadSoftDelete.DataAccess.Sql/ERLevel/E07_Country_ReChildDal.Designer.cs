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
    /// DAL SQL Server implementation of <see cref="IE07_Country_ReChildDal"/>
    /// </summary>
    public partial class E07_Country_ReChildDal : IE07_Country_ReChildDal
    {
        /// <summary>
        /// Inserts a new E07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="e07_Country_ReChild">The E07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="E07_Country_ReChildDto"/>.</returns>
        public E07_Country_ReChildDto Insert(E07_Country_ReChildDto e07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", e07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", e07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return e07_Country_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the E07_Country_ReChild object.
        /// </summary>
        /// <param name="e07_Country_ReChild">The E07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="E07_Country_ReChildDto"/>.</returns>
        public E07_Country_ReChildDto Update(E07_Country_ReChildDto e07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", e07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", e07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E07_Country_ReChild");
                }
            }
            return e07_Country_ReChild;
        }

        /// <summary>
        /// Deletes the E07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
