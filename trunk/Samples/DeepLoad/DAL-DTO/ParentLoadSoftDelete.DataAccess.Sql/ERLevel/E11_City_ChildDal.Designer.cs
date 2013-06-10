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
    /// DAL SQL Server implementation of <see cref="IE11_City_ChildDal"/>
    /// </summary>
    public partial class E11_City_ChildDal : IE11_City_ChildDal
    {
        /// <summary>
        /// Inserts a new E11_City_Child object in the database.
        /// </summary>
        /// <param name="e11_City_Child">The E11 City Child DTO.</param>
        /// <returns>The new <see cref="E11_City_ChildDto"/>.</returns>
        public E11_City_ChildDto Insert(E11_City_ChildDto e11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", e11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", e11_City_Child.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return e11_City_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the E11_City_Child object.
        /// </summary>
        /// <param name="e11_City_Child">The E11 City Child DTO.</param>
        /// <returns>The updated <see cref="E11_City_ChildDto"/>.</returns>
        public E11_City_ChildDto Update(E11_City_ChildDto e11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", e11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", e11_City_Child.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E11_City_Child");
                }
            }
            return e11_City_Child;
        }

        /// <summary>
        /// Deletes the E11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        public void Delete(int city_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", city_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
