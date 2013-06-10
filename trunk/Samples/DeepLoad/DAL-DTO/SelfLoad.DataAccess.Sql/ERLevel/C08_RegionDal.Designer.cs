using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC08_RegionDal"/>
    /// </summary>
    public partial class C08_RegionDal : IC08_RegionDal
    {
        /// <summary>
        /// Inserts a new C08_Region object in the database.
        /// </summary>
        /// <param name="c08_Region">The C08 Region DTO.</param>
        /// <returns>The new <see cref="C08_RegionDto"/>.</returns>
        public C08_RegionDto Insert(C08_RegionDto c08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", c08_Region.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", c08_Region.Region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", c08_Region.Region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    c08_Region.Region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                }
            }
            return c08_Region;
        }

        /// <summary>
        /// Updates in the database all changes made to the C08_Region object.
        /// </summary>
        /// <param name="c08_Region">The C08 Region DTO.</param>
        /// <returns>The updated <see cref="C08_RegionDto"/>.</returns>
        public C08_RegionDto Update(C08_RegionDto c08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", c08_Region.Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", c08_Region.Region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C08_Region");
                }
            }
            return c08_Region;
        }

        /// <summary>
        /// Deletes the C08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
