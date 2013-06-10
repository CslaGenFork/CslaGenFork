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
    /// DAL SQL Server implementation of <see cref="IA07_Country_ReChildDal"/>
    /// </summary>
    public partial class A07_Country_ReChildDal : IA07_Country_ReChildDal
    {
        /// <summary>
        /// Inserts a new A07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="a07_Country_ReChild">The A07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="A07_Country_ReChildDto"/>.</returns>
        public A07_Country_ReChildDto Insert(A07_Country_ReChildDto a07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", a07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", a07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return a07_Country_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the A07_Country_ReChild object.
        /// </summary>
        /// <param name="a07_Country_ReChild">The A07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="A07_Country_ReChildDto"/>.</returns>
        public A07_Country_ReChildDto Update(A07_Country_ReChildDto a07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", a07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", a07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A07_Country_ReChild");
                }
            }
            return a07_Country_ReChild;
        }

        /// <summary>
        /// Deletes the A07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        public void Delete(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteA07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
