using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IA08_RegionDal"/>
    /// </summary>
    public partial class A08_RegionDal : IA08_RegionDal
    {
        /// <summary>
        /// Inserts a new A08_Region object in the database.
        /// </summary>
        /// <param name="a08_Region">The A08 Region DTO.</param>
        /// <returns>The new <see cref="A08_RegionDto"/>.</returns>
        public A08_RegionDto Insert(A08_RegionDto a08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", a08_Region.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_ID", a08_Region.Region_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Region_Name", a08_Region.Region_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    a08_Region.Region_ID = (int)cmd.Parameters["@Region_ID"].Value;
                }
            }
            return a08_Region;
        }

        /// <summary>
        /// Updates in the database all changes made to the A08_Region object.
        /// </summary>
        /// <param name="a08_Region">The A08 Region DTO.</param>
        /// <returns>The updated <see cref="A08_RegionDto"/>.</returns>
        public A08_RegionDto Update(A08_RegionDto a08_Region)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", a08_Region.Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Name", a08_Region.Region_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A08_Region");
                }
            }
            return a08_Region;
        }

        /// <summary>
        /// Deletes the A08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteA08_Region", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
