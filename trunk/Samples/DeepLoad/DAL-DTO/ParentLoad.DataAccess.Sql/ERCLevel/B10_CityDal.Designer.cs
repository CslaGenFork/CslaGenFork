using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IB10_CityDal"/>
    /// </summary>
    public partial class B10_CityDal : IB10_CityDal
    {
        /// <summary>
        /// Inserts a new B10_City object in the database.
        /// </summary>
        /// <param name="b10_City">The B10 City DTO.</param>
        /// <returns>The new <see cref="B10_CityDto"/>.</returns>
        public B10_CityDto Insert(B10_CityDto b10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", b10_City.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", b10_City.City_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", b10_City.City_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    b10_City.City_ID = (int)cmd.Parameters["@City_ID"].Value;
                }
            }
            return b10_City;
        }

        /// <summary>
        /// Updates in the database all changes made to the B10_City object.
        /// </summary>
        /// <param name="b10_City">The B10 City DTO.</param>
        /// <returns>The updated <see cref="B10_CityDto"/>.</returns>
        public B10_CityDto Update(B10_CityDto b10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", b10_City.City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", b10_City.City_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B10_City");
                }
            }
            return b10_City;
        }

        /// <summary>
        /// Deletes the B10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
