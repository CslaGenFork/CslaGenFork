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
    /// DAL SQL Server implementation of <see cref="IF10_CityDal"/>
    /// </summary>
    public partial class F10_CityDal : IF10_CityDal
    {
        /// <summary>
        /// Inserts a new F10_City object in the database.
        /// </summary>
        /// <param name="f10_City">The F10 City DTO.</param>
        /// <returns>The new <see cref="F10_CityDto"/>.</returns>
        public F10_CityDto Insert(F10_CityDto f10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", f10_City.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", f10_City.City_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", f10_City.City_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    f10_City.City_ID = (int)cmd.Parameters["@City_ID"].Value;
                }
            }
            return f10_City;
        }

        /// <summary>
        /// Updates in the database all changes made to the F10_City object.
        /// </summary>
        /// <param name="f10_City">The F10 City DTO.</param>
        /// <returns>The updated <see cref="F10_CityDto"/>.</returns>
        public F10_CityDto Update(F10_CityDto f10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", f10_City.City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", f10_City.City_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F10_City");
                }
            }
            return f10_City;
        }

        /// <summary>
        /// Deletes the F10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
