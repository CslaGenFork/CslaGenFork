using System;
using System.Collections.Generic;
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
        /// <param name="a10_City">The A10 City DTO.</param>
        /// <returns>The new <see cref="A10_CityDto"/>.</returns>
        public A10_CityDto Insert(A10_CityDto a10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", a10_City.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", a10_City.City_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", a10_City.City_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    a10_City.City_ID = (int)cmd.Parameters["@City_ID"].Value;
                }
            }
            return a10_City;
        }

        /// <summary>
        /// Updates in the database all changes made to the A10_City object.
        /// </summary>
        /// <param name="a10_City">The A10 City DTO.</param>
        /// <returns>The updated <see cref="A10_CityDto"/>.</returns>
        public A10_CityDto Update(A10_CityDto a10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", a10_City.City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", a10_City.City_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A10_City");
                }
            }
            return a10_City;
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
