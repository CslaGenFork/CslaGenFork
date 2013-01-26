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
    /// DAL SQL Server implementation of <see cref="IF12_CityRoadDal"/>
    /// </summary>
    public partial class F12_CityRoadDal : IF12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new F12_CityRoad object in the database.
        /// </summary>
        /// <param name="f12_CityRoad">The F12 City Road DTO.</param>
        /// <returns>The new <see cref="F12_CityRoadDto"/>.</returns>
        public F12_CityRoadDto Insert(F12_CityRoadDto f12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", f12_CityRoad.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", f12_CityRoad.CityRoad_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", f12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    f12_CityRoad.CityRoad_ID = (int)cmd.Parameters["@CityRoad_ID"].Value;
                }
            }
            return f12_CityRoad;
        }

        /// <summary>
        /// Updates in the database all changes made to the F12_CityRoad object.
        /// </summary>
        /// <param name="f12_CityRoad">The F12 City Road DTO.</param>
        /// <returns>The updated <see cref="F12_CityRoadDto"/>.</returns>
        public F12_CityRoadDto Update(F12_CityRoadDto f12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", f12_CityRoad.CityRoad_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", f12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F12_CityRoad");
                }
            }
            return f12_CityRoad;
        }

        /// <summary>
        /// Deletes the F12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        public void Delete(int cityRoad_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
