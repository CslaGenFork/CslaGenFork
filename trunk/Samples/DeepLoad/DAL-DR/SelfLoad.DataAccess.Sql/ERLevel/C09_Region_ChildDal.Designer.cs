using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC09_Region_ChildDal"/>
    /// </summary>
    public partial class C09_Region_ChildDal : IC09_Region_ChildDal
    {
        /// <summary>
        /// Loads a C09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The Region ID1.</param>
        /// <returns>A data reader to the C09_Region_Child.</returns>
        public IDataReader Fetch(int region_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new C09_Region_Child object in the database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        public void Insert(int region_ID1, string region_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the C09_Region_Child object.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        public void Update(int region_ID1, string region_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C09_Region_Child");
                }
            }
        }

        /// <summary>
        /// Deletes the C09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        public void Delete(int region_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
