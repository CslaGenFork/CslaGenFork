using System;
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
        /// <param name="parent_City_ID">The parent Parent City ID.</param>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        /// <param name="cityRoad_Name">The City Road Name.</param>
        public void Insert(int parent_City_ID, out int cityRoad_ID, string cityRoad_Name)
        {
            cityRoad_ID = -1;
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", cityRoad_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    cityRoad_ID = (int)cmd.Parameters["@CityRoad_ID"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the G12_CityRoad object.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        /// <param name="cityRoad_Name">The City Road Name.</param>
        public void Update(int cityRoad_ID, string cityRoad_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", cityRoad_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G12_CityRoad");
                }
            }
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
