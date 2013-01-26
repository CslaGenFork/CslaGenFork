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
    /// DAL SQL Server implementation of <see cref="IC02_ContinentDal"/>
    /// </summary>
    public partial class C02_ContinentDal : IC02_ContinentDal
    {
        /// <summary>
        /// Loads a C02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A C02_ContinentDto object.</returns>
        public C02_ContinentDto Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C02_ContinentDto Fetch(IDataReader data)
        {
            var c02_Continent = new C02_ContinentDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c02_Continent.Continent_ID = dr.GetInt32("Continent_ID");
                    c02_Continent.Continent_Name = dr.GetString("Continent_Name");
                }
            }
            return c02_Continent;
        }

        /// <summary>
        /// Inserts a new C02_Continent object in the database.
        /// </summary>
        /// <param name="c02_Continent">The C02 Continent DTO.</param>
        /// <returns>The new <see cref="C02_ContinentDto"/>.</returns>
        public C02_ContinentDto Insert(C02_ContinentDto c02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", c02_Continent.Continent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", c02_Continent.Continent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    c02_Continent.Continent_ID = (int)cmd.Parameters["@Continent_ID"].Value;
                }
            }
            return c02_Continent;
        }

        /// <summary>
        /// Updates in the database all changes made to the C02_Continent object.
        /// </summary>
        /// <param name="c02_Continent">The C02 Continent DTO.</param>
        /// <returns>The updated <see cref="C02_ContinentDto"/>.</returns>
        public C02_ContinentDto Update(C02_ContinentDto c02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", c02_Continent.Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", c02_Continent.Continent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C02_Continent");
                }
            }
            return c02_Continent;
        }

        /// <summary>
        /// Deletes the C02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The delete criteria.</param>
        public void Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C02_Continent");
                }
            }
        }
    }
}
