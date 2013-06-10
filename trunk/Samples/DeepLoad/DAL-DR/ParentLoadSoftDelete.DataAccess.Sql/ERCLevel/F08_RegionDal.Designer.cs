using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IF08_RegionDal"/>
    /// </summary>
    public partial class F08_RegionDal : IF08_RegionDal
    {
        /// <summary>
        /// Inserts a new F08_Region object in the database.
        /// </summary>
        /// <param name="parent_Country_ID">The parent Parent Country ID.</param>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        public void Insert(int parent_Country_ID, out int region_ID, string region_Name)
        {
            region_ID = -1;
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the F08_Region object.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        public void Update(int region_ID, string region_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F08_Region");
                }
            }
        }

        /// <summary>
        /// Deletes the F08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
