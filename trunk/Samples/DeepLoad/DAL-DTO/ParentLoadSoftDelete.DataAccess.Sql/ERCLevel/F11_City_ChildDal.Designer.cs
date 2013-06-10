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
    /// DAL SQL Server implementation of <see cref="IF11_City_ChildDal"/>
    /// </summary>
    public partial class F11_City_ChildDal : IF11_City_ChildDal
    {
        /// <summary>
        /// Inserts a new F11_City_Child object in the database.
        /// </summary>
        /// <param name="f11_City_Child">The F11 City Child DTO.</param>
        /// <returns>The new <see cref="F11_City_ChildDto"/>.</returns>
        public F11_City_ChildDto Insert(F11_City_ChildDto f11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", f11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", f11_City_Child.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return f11_City_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the F11_City_Child object.
        /// </summary>
        /// <param name="f11_City_Child">The F11 City Child DTO.</param>
        /// <returns>The updated <see cref="F11_City_ChildDto"/>.</returns>
        public F11_City_ChildDto Update(F11_City_ChildDto f11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", f11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", f11_City_Child.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F11_City_Child");
                }
            }
            return f11_City_Child;
        }

        /// <summary>
        /// Deletes the F11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        public void Delete(int city_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", city_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
