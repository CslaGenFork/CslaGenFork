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
    /// DAL SQL Server implementation of <see cref="IE12_CityRoadDal"/>
    /// </summary>
    public partial class E12_CityRoadDal : IE12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new E12_CityRoad object in the database.
        /// </summary>
        /// <param name="e12_CityRoad">The E12 City Road DTO.</param>
        /// <returns>The new <see cref="E12_CityRoadDto"/>.</returns>
        public E12_CityRoadDto Insert(E12_CityRoadDto e12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", e12_CityRoad.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", e12_CityRoad.CityRoad_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", e12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    e12_CityRoad.CityRoad_ID = (int)cmd.Parameters["@CityRoad_ID"].Value;
                }
            }
            return e12_CityRoad;
        }

        /// <summary>
        /// Updates in the database all changes made to the E12_CityRoad object.
        /// </summary>
        /// <param name="e12_CityRoad">The E12 City Road DTO.</param>
        /// <returns>The updated <see cref="E12_CityRoadDto"/>.</returns>
        public E12_CityRoadDto Update(E12_CityRoadDto e12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", e12_CityRoad.CityRoad_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", e12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E12_CityRoad");
                }
            }
            return e12_CityRoad;
        }

        /// <summary>
        /// Deletes the E12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        public void Delete(int cityRoad_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
