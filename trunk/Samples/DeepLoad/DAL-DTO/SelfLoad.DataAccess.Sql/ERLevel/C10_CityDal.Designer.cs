using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC10_CityDal"/>
    /// </summary>
    public partial class C10_CityDal : IC10_CityDal
    {
        /// <summary>
        /// Inserts a new C10_City object in the database.
        /// </summary>
        /// <param name="c10_City">The C10 City DTO.</param>
        /// <returns>The new <see cref="C10_CityDto"/>.</returns>
        public C10_CityDto Insert(C10_CityDto c10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Region_ID", c10_City.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", c10_City.City_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", c10_City.City_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    c10_City.City_ID = (int)cmd.Parameters["@City_ID"].Value;
                }
            }
            return c10_City;
        }

        /// <summary>
        /// Updates in the database all changes made to the C10_City object.
        /// </summary>
        /// <param name="c10_City">The C10 City DTO.</param>
        /// <returns>The updated <see cref="C10_CityDto"/>.</returns>
        public C10_CityDto Update(C10_CityDto c10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", c10_City.City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", c10_City.City_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C10_City");
                }
            }
            return c10_City;
        }

        /// <summary>
        /// Deletes the C10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
