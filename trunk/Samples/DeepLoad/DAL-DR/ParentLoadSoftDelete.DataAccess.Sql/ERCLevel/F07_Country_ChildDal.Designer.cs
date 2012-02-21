using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess.ERCLevel;
using ParentLoadSoftDelete.DataAccess;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IF07_Country_ChildDal"/>
    /// </summary>
    public partial class F07_Country_ChildDal : IF07_Country_ChildDal
    {
        /// <summary>
        /// Inserts a new F07_Country_Child object in the database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        
        public void Insert(int country_ID, string country_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                                    }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the F07_Country_Child object.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        
        public void Update(int country_ID, string country_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F07_Country_Child");

                                    }
            }
        }

        /// <summary>
        /// Deletes the F07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
