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
    /// DAL SQL Server implementation of <see cref="IF11_City_ReChildDal"/>
    /// </summary>
    public partial class F11_City_ReChildDal : IF11_City_ReChildDal
    {
        /// <summary>
        /// Inserts a new F11_City_ReChild object in the database.
        /// </summary>
        /// <param name="f11_City_ReChild">The F11 City Re Child DTO.</param>
        /// <returns>The new <see cref="F11_City_ReChildDto"/>.</returns>
        public F11_City_ReChildDto Insert(F11_City_ReChildDto f11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", f11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", f11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return f11_City_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the F11_City_ReChild object.
        /// </summary>
        /// <param name="f11_City_ReChild">The F11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="F11_City_ReChildDto"/>.</returns>
        public F11_City_ReChildDto Update(F11_City_ReChildDto f11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", f11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", f11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F11_City_ReChild");
                }
            }
            return f11_City_ReChild;
        }

        /// <summary>
        /// Deletes the F11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
