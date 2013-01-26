using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IA11_City_ChildDal"/>
    /// </summary>
    public partial class A11_City_ChildDal : IA11_City_ChildDal
    {
        /// <summary>
        /// Inserts a new A11_City_Child object in the database.
        /// </summary>
        /// <param name="a11_City_Child">The A11 City Child DTO.</param>
        /// <returns>The new <see cref="A11_City_ChildDto"/>.</returns>
        public A11_City_ChildDto Insert(A11_City_ChildDto a11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", a11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", a11_City_Child.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return a11_City_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the A11_City_Child object.
        /// </summary>
        /// <param name="a11_City_Child">The A11 City Child DTO.</param>
        /// <returns>The updated <see cref="A11_City_ChildDto"/>.</returns>
        public A11_City_ChildDto Update(A11_City_ChildDto a11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", a11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", a11_City_Child.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A11_City_Child");
                }
            }
            return a11_City_Child;
        }

        /// <summary>
        /// Deletes the A11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteA11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
