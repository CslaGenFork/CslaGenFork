using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH09_Region_ReChildDal"/>
    /// </summary>
    public partial class H09_Region_ReChildDal : IH09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a H09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The Region ID2.</param>
        /// <returns>A data reader to the H09_Region_ReChild.</returns>
        public IDataReader Fetch(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new H09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        public void Insert(int region_ID, string region_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the H09_Region_ReChild object.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        public void Update(int region_ID, string region_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H09_Region_ReChild");
                }
            }
        }

        /// <summary>
        /// Deletes the H09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
