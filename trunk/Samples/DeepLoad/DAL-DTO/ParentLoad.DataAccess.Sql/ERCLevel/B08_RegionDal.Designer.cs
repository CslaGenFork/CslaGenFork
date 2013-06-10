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
    /// DAL SQL Server implementation of <see cref="IB08_RegionDal"/>
    /// </summary>
    public partial class B08_RegionDal : IB08_RegionDal
    {
        /// <summary>
        /// Inserts a new B08_Region object in the database.
        /// </summary>
        /// <param name="b08_Region">The B08 Region DTO.</param>
        /// <returns>The new <see cref="B08_RegionDto"/>.</returns>
        public B08_RegionDto Insert(B08_RegionDto b08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", b08_Region.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", b08_Region.Region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", b08_Region.Region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    b08_Region.Region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                }
            }
            return b08_Region;
        }

        /// <summary>
        /// Updates in the database all changes made to the B08_Region object.
        /// </summary>
        /// <param name="b08_Region">The B08 Region DTO.</param>
        /// <returns>The updated <see cref="B08_RegionDto"/>.</returns>
        public B08_RegionDto Update(B08_RegionDto b08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", b08_Region.Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", b08_Region.Region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B08_Region");
                }
            }
            return b08_Region;
        }

        /// <summary>
        /// Deletes the B08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
