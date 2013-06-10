using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH08_RegionDal"/>
    /// </summary>
    public partial class H08_RegionDal : IH08_RegionDal
    {
        /// <summary>
        /// Inserts a new H08_Region object in the database.
        /// </summary>
        /// <param name="h08_Region">The H08 Region DTO.</param>
        /// <returns>The new <see cref="H08_RegionDto"/>.</returns>
        public H08_RegionDto Insert(H08_RegionDto h08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", h08_Region.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", h08_Region.Region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", h08_Region.Region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    h08_Region.Region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                }
            }
            return h08_Region;
        }

        /// <summary>
        /// Updates in the database all changes made to the H08_Region object.
        /// </summary>
        /// <param name="h08_Region">The H08 Region DTO.</param>
        /// <returns>The updated <see cref="H08_RegionDto"/>.</returns>
        public H08_RegionDto Update(H08_RegionDto h08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", h08_Region.Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", h08_Region.Region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H08_Region");
                }
            }
            return h08_Region;
        }

        /// <summary>
        /// Deletes the H08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
