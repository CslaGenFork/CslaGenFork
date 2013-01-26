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
    /// DAL SQL Server implementation of <see cref="IH12_CityRoadDal"/>
    /// </summary>
    public partial class H12_CityRoadDal : IH12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new H12_CityRoad object in the database.
        /// </summary>
        /// <param name="h12_CityRoad">The H12 City Road DTO.</param>
        /// <returns>The new <see cref="H12_CityRoadDto"/>.</returns>
        public H12_CityRoadDto Insert(H12_CityRoadDto h12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", h12_CityRoad.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", h12_CityRoad.CityRoad_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", h12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    h12_CityRoad.CityRoad_ID = (int)cmd.Parameters["@CityRoad_ID"].Value;
                }
            }
            return h12_CityRoad;
        }

        /// <summary>
        /// Updates in the database all changes made to the H12_CityRoad object.
        /// </summary>
        /// <param name="h12_CityRoad">The H12 City Road DTO.</param>
        /// <returns>The updated <see cref="H12_CityRoadDto"/>.</returns>
        public H12_CityRoadDto Update(H12_CityRoadDto h12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", h12_CityRoad.CityRoad_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", h12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H12_CityRoad");
                }
            }
            return h12_CityRoad;
        }

        /// <summary>
        /// Deletes the H12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        public void Delete(int cityRoad_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
