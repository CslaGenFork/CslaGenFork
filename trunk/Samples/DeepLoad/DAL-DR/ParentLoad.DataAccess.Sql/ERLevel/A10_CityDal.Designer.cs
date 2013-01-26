using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IA10_CityDal"/>
    /// </summary>
    public partial class A10_CityDal : IA10_CityDal
    {
        /// <summary>
        /// Inserts a new A10_City object in the database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="city_ID">The City ID.</param>
        /// <param name="city_Name">The City Name.</param>
        public void Insert(int region_ID, out int city_ID, string city_Name)
        {
            city_ID = -1;
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", city_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    city_ID = (int)cmd.Parameters["@City_ID"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the A10_City object.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        /// <param name="city_Name">The City Name.</param>
        public void Update(int city_ID, string city_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", city_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A10_City");
                }
            }
        }

        /// <summary>
        /// Deletes the A10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteA10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
