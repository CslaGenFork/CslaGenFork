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
    /// DAL SQL Server implementation of <see cref="IE10_CityDal"/>
    /// </summary>
    public partial class E10_CityDal : IE10_CityDal
    {
        /// <summary>
        /// Inserts a new E10_City object in the database.
        /// </summary>
        /// <param name="e10_City">The E10 City DTO.</param>
        /// <returns>The new <see cref="E10_CityDto"/>.</returns>
        public E10_CityDto Insert(E10_CityDto e10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Region_ID", e10_City.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", e10_City.City_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", e10_City.City_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    e10_City.City_ID = (int)cmd.Parameters["@City_ID"].Value;
                }
            }
            return e10_City;
        }

        /// <summary>
        /// Updates in the database all changes made to the E10_City object.
        /// </summary>
        /// <param name="e10_City">The E10 City DTO.</param>
        /// <returns>The updated <see cref="E10_CityDto"/>.</returns>
        public E10_CityDto Update(E10_CityDto e10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", e10_City.City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", e10_City.City_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E10_City");
                }
            }
            return e10_City;
        }

        /// <summary>
        /// Deletes the E10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
