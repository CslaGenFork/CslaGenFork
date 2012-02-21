using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess.ERLevel;
using ParentLoadSoftDelete.DataAccess;

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
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        
        public void Insert(int country_ID, string country_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                                    }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the E07_Country_ReChild object.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        
        public void Update(int country_ID, string country_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E07_Country_ReChild");

                                    }
            }
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
