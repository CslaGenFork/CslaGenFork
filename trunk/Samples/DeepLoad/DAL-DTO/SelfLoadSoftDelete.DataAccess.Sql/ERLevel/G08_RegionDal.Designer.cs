using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG08_RegionDal"/>
    /// </summary>
    public partial class G08_RegionDal : IG08_RegionDal
    {
        /// <summary>
        /// Inserts a new G08_Region object in the database.
        /// </summary>
        /// <param name="g08_Region">The G08 Region DTO.</param>
        /// <returns>The new <see cref="G08_RegionDto"/>.</returns>
        public G08_RegionDto Insert(G08_RegionDto g08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", g08_Region.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", g08_Region.Region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", g08_Region.Region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    g08_Region.Region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                }
            }
            return g08_Region;
        }

        /// <summary>
        /// Updates in the database all changes made to the G08_Region object.
        /// </summary>
        /// <param name="g08_Region">The G08 Region DTO.</param>
        /// <returns>The updated <see cref="G08_RegionDto"/>.</returns>
        public G08_RegionDto Update(G08_RegionDto g08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", g08_Region.Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", g08_Region.Region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G08_Region");
                }
            }
            return g08_Region;
        }

        /// <summary>
        /// Deletes the G08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
