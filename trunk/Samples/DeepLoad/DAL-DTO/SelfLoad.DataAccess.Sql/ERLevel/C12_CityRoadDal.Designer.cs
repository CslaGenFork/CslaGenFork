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
    /// DAL SQL Server implementation of <see cref="IC12_CityRoadDal"/>
    /// </summary>
    public partial class C12_CityRoadDal : IC12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new C12_CityRoad object in the database.
        /// </summary>
        /// <param name="c12_CityRoad">The C12 City Road DTO.</param>
        /// <returns>The new <see cref="C12_CityRoadDto"/>.</returns>
        public C12_CityRoadDto Insert(C12_CityRoadDto c12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", c12_CityRoad.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", c12_CityRoad.CityRoad_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", c12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    c12_CityRoad.CityRoad_ID = (int)cmd.Parameters["@CityRoad_ID"].Value;
                }
            }
            return c12_CityRoad;
        }

        /// <summary>
        /// Updates in the database all changes made to the C12_CityRoad object.
        /// </summary>
        /// <param name="c12_CityRoad">The C12 City Road DTO.</param>
        /// <returns>The updated <see cref="C12_CityRoadDto"/>.</returns>
        public C12_CityRoadDto Update(C12_CityRoadDto c12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", c12_CityRoad.CityRoad_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", c12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C12_CityRoad");
                }
            }
            return c12_CityRoad;
        }

        /// <summary>
        /// Deletes the C12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        public void Delete(int cityRoad_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
