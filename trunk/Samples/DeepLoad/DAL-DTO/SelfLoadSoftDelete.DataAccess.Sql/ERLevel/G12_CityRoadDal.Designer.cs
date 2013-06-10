using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG12_CityRoadDal"/>
    /// </summary>
    public partial class G12_CityRoadDal : IG12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new G12_CityRoad object in the database.
        /// </summary>
        /// <param name="g12_CityRoad">The G12 City Road DTO.</param>
        /// <returns>The new <see cref="G12_CityRoadDto"/>.</returns>
        public G12_CityRoadDto Insert(G12_CityRoadDto g12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", g12_CityRoad.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", g12_CityRoad.CityRoad_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", g12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    g12_CityRoad.CityRoad_ID = (int)cmd.Parameters["@CityRoad_ID"].Value;
                }
            }
            return g12_CityRoad;
        }

        /// <summary>
        /// Updates in the database all changes made to the G12_CityRoad object.
        /// </summary>
        /// <param name="g12_CityRoad">The G12 City Road DTO.</param>
        /// <returns>The updated <see cref="G12_CityRoadDto"/>.</returns>
        public G12_CityRoadDto Update(G12_CityRoadDto g12_CityRoad)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", g12_CityRoad.CityRoad_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", g12_CityRoad.CityRoad_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G12_CityRoad");
                }
            }
            return g12_CityRoad;
        }

        /// <summary>
        /// Deletes the G12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        public void Delete(int cityRoad_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
