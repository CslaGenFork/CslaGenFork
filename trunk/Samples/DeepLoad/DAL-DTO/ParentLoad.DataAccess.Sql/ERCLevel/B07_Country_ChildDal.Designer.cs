using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IB07_Country_ChildDal"/>
    /// </summary>
    public partial class B07_Country_ChildDal : IB07_Country_ChildDal
    {
        /// <summary>
        /// Inserts a new B07_Country_Child object in the database.
        /// </summary>
        /// <param name="b07_Country_Child">The B07 Country Child DTO.</param>
        /// <returns>The new <see cref="B07_Country_ChildDto"/>.</returns>
        public B07_Country_ChildDto Insert(B07_Country_ChildDto b07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", b07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", b07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return b07_Country_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the B07_Country_Child object.
        /// </summary>
        /// <param name="b07_Country_Child">The B07 Country Child DTO.</param>
        /// <returns>The updated <see cref="B07_Country_ChildDto"/>.</returns>
        public B07_Country_ChildDto Update(B07_Country_ChildDto b07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", b07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", b07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B07_Country_Child");
                }
            }
            return b07_Country_Child;
        }

        /// <summary>
        /// Deletes the B07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
