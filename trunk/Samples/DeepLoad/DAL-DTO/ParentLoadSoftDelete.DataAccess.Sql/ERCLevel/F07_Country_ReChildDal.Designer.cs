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
    /// DAL SQL Server implementation of <see cref="IF07_Country_ReChildDal"/>
    /// </summary>
    public partial class F07_Country_ReChildDal : IF07_Country_ReChildDal
    {
        /// <summary>
        /// Inserts a new F07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="f07_Country_ReChild">The F07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="F07_Country_ReChildDto"/>.</returns>
        public F07_Country_ReChildDto Insert(F07_Country_ReChildDto f07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", f07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", f07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return f07_Country_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the F07_Country_ReChild object.
        /// </summary>
        /// <param name="f07_Country_ReChild">The F07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="F07_Country_ReChildDto"/>.</returns>
        public F07_Country_ReChildDto Update(F07_Country_ReChildDto f07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", f07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", f07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F07_Country_ReChild");
                }
            }
            return f07_Country_ReChild;
        }

        /// <summary>
        /// Deletes the F07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        public void Delete(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
