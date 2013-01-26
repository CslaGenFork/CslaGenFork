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
    /// DAL SQL Server implementation of <see cref="IH10_CityDal"/>
    /// </summary>
    public partial class H10_CityDal : IH10_CityDal
    {
        /// <summary>
        /// Inserts a new H10_City object in the database.
        /// </summary>
        /// <param name="h10_City">The H10 City DTO.</param>
        /// <returns>The new <see cref="H10_CityDto"/>.</returns>
        public H10_CityDto Insert(H10_CityDto h10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", h10_City.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", h10_City.City_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", h10_City.City_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    h10_City.City_ID = (int)cmd.Parameters["@City_ID"].Value;
                }
            }
            return h10_City;
        }

        /// <summary>
        /// Updates in the database all changes made to the H10_City object.
        /// </summary>
        /// <param name="h10_City">The H10 City DTO.</param>
        /// <returns>The updated <see cref="H10_CityDto"/>.</returns>
        public H10_CityDto Update(H10_CityDto h10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", h10_City.City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", h10_City.City_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H10_City");
                }
            }
            return h10_City;
        }

        /// <summary>
        /// Deletes the H10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
