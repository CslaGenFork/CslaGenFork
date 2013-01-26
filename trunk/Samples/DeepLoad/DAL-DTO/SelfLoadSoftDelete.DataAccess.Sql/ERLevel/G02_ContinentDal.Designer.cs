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
    /// DAL SQL Server implementation of <see cref="IG02_ContinentDal"/>
    /// </summary>
    public partial class G02_ContinentDal : IG02_ContinentDal
    {
        /// <summary>
        /// Loads a G02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A G02_ContinentDto object.</returns>
        public G02_ContinentDto Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G02_ContinentDto Fetch(IDataReader data)
        {
            var g02_Continent = new G02_ContinentDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g02_Continent.Continent_ID = dr.GetInt32("Continent_ID");
                    g02_Continent.Continent_Name = dr.GetString("Continent_Name");
                }
            }
            return g02_Continent;
        }

        /// <summary>
        /// Inserts a new G02_Continent object in the database.
        /// </summary>
        /// <param name="g02_Continent">The G02 Continent DTO.</param>
        /// <returns>The new <see cref="G02_ContinentDto"/>.</returns>
        public G02_ContinentDto Insert(G02_ContinentDto g02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", g02_Continent.Continent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Continent_Name", g02_Continent.Continent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    g02_Continent.Continent_ID = (int)cmd.Parameters["@Continent_ID"].Value;
                }
            }
            return g02_Continent;
        }

        /// <summary>
        /// Updates in the database all changes made to the G02_Continent object.
        /// </summary>
        /// <param name="g02_Continent">The G02 Continent DTO.</param>
        /// <returns>The updated <see cref="G02_ContinentDto"/>.</returns>
        public G02_ContinentDto Update(G02_ContinentDto g02_Continent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", g02_Continent.Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Name", g02_Continent.Continent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G02_Continent");
                }
            }
            return g02_Continent;
        }

        /// <summary>
        /// Deletes the G02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The delete criteria.</param>
        public void Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G02_Continent");
                }
            }
        }
    }
}
