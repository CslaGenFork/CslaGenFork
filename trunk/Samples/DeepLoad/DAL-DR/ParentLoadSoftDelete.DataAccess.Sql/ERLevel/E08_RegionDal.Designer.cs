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
    /// DAL SQL Server implementation of <see cref="IE08_RegionDal"/>
    /// </summary>
    public partial class E08_RegionDal : IE08_RegionDal
    {
        /// <summary>
        /// Inserts a new E08_Region object in the database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        
        public void Insert(int country_ID, out int region_ID, string region_Name)
        {
            region_ID = -1;
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                                    }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the E08_Region object.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        
        public void Update(int region_ID, string region_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E08_Region");

                                    }
            }
        }

        /// <summary>
        /// Deletes the E08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
