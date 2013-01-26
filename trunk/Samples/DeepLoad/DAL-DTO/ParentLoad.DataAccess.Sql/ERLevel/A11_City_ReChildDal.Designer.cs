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
    /// DAL SQL Server implementation of <see cref="IA11_City_ReChildDal"/>
    /// </summary>
    public partial class A11_City_ReChildDal : IA11_City_ReChildDal
    {
        /// <summary>
        /// Inserts a new A11_City_ReChild object in the database.
        /// </summary>
        /// <param name="a11_City_ReChild">The A11 City Re Child DTO.</param>
        /// <returns>The new <see cref="A11_City_ReChildDto"/>.</returns>
        public A11_City_ReChildDto Insert(A11_City_ReChildDto a11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", a11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", a11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return a11_City_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the A11_City_ReChild object.
        /// </summary>
        /// <param name="a11_City_ReChild">The A11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="A11_City_ReChildDto"/>.</returns>
        public A11_City_ReChildDto Update(A11_City_ReChildDto a11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", a11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", a11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A11_City_ReChild");
                }
            }
            return a11_City_ReChild;
        }

        /// <summary>
        /// Deletes the A11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteA11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
