using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

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
        /// <param name="e08_Region">The E08 Region DTO.</param>
        /// <returns>The new <see cref="E08_RegionDto"/>.</returns>
        public E08_RegionDto Insert(E08_RegionDto e08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", e08_Region.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", e08_Region.Region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", e08_Region.Region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    e08_Region.Region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                }
            }
            return e08_Region;
        }

        /// <summary>
        /// Updates in the database all changes made to the E08_Region object.
        /// </summary>
        /// <param name="e08_Region">The E08 Region DTO.</param>
        /// <returns>The updated <see cref="E08_RegionDto"/>.</returns>
        public E08_RegionDto Update(E08_RegionDto e08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", e08_Region.Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", e08_Region.Region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E08_Region");
                }
            }
            return e08_Region;
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
