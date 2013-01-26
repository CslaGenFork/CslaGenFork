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
    /// DAL SQL Server implementation of <see cref="IG10_CityDal"/>
    /// </summary>
    public partial class G10_CityDal : IG10_CityDal
    {
        /// <summary>
        /// Inserts a new G10_City object in the database.
        /// </summary>
        /// <param name="g10_City">The G10 City DTO.</param>
        /// <returns>The new <see cref="G10_CityDto"/>.</returns>
        public G10_CityDto Insert(G10_CityDto g10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", g10_City.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", g10_City.City_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", g10_City.City_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    g10_City.City_ID = (int)cmd.Parameters["@City_ID"].Value;
                }
            }
            return g10_City;
        }

        /// <summary>
        /// Updates in the database all changes made to the G10_City object.
        /// </summary>
        /// <param name="g10_City">The G10 City DTO.</param>
        /// <returns>The updated <see cref="G10_CityDto"/>.</returns>
        public G10_CityDto Update(G10_CityDto g10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", g10_City.City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", g10_City.City_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G10_City");
                }
            }
            return g10_City;
        }

        /// <summary>
        /// Deletes the G10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
