using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID08_RegionDal"/>
    /// </summary>
    public partial class D08_RegionDal : ID08_RegionDal
    {
        /// <summary>
        /// Inserts a new D08_Region object in the database.
        /// </summary>
        /// <param name="d08_Region">The D08 Region DTO.</param>
        /// <returns>The new <see cref="D08_RegionDto"/>.</returns>
        public D08_RegionDto Insert(D08_RegionDto d08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", d08_Region.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", d08_Region.Region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", d08_Region.Region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    d08_Region.Region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                }
            }
            return d08_Region;
        }

        /// <summary>
        /// Updates in the database all changes made to the D08_Region object.
        /// </summary>
        /// <param name="d08_Region">The D08 Region DTO.</param>
        /// <returns>The updated <see cref="D08_RegionDto"/>.</returns>
        public D08_RegionDto Update(D08_RegionDto d08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", d08_Region.Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", d08_Region.Region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D08_Region");
                }
            }
            return d08_Region;
        }

        /// <summary>
        /// Deletes the D08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
