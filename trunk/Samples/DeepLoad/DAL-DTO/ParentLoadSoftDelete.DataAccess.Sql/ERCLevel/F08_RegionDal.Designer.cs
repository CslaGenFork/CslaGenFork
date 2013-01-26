using System;
using System.Collections.Generic;
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
        /// <param name="f08_Region">The F08 Region DTO.</param>
        /// <returns>The new <see cref="F08_RegionDto"/>.</returns>
        public F08_RegionDto Insert(F08_RegionDto f08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", f08_Region.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", f08_Region.Region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", f08_Region.Region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    f08_Region.Region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                }
            }
            return f08_Region;
        }

        /// <summary>
        /// Updates in the database all changes made to the F08_Region object.
        /// </summary>
        /// <param name="f08_Region">The F08 Region DTO.</param>
        /// <returns>The updated <see cref="F08_RegionDto"/>.</returns>
        public F08_RegionDto Update(F08_RegionDto f08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", f08_Region.Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", f08_Region.Region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F08_Region");
                }
            }
            return f08_Region;
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
