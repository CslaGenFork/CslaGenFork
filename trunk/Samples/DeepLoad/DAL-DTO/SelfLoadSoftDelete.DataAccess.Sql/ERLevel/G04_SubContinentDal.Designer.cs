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
    /// DAL SQL Server implementation of <see cref="IG04_SubContinentDal"/>
    /// </summary>
    public partial class G04_SubContinentDal : IG04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new G04_SubContinent object in the database.
        /// </summary>
        /// <param name="g04_SubContinent">The G04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="G04_SubContinentDto"/>.</returns>
        public G04_SubContinentDto Insert(G04_SubContinentDto g04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", g04_SubContinent.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", g04_SubContinent.SubContinent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", g04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    g04_SubContinent.SubContinent_ID = (int)cmd.Parameters["@SubContinent_ID"].Value;
                }
            }
            return g04_SubContinent;
        }

        /// <summary>
        /// Updates in the database all changes made to the G04_SubContinent object.
        /// </summary>
        /// <param name="g04_SubContinent">The G04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="G04_SubContinentDto"/>.</returns>
        public G04_SubContinentDto Update(G04_SubContinentDto g04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", g04_SubContinent.SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", g04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G04_SubContinent");
                }
            }
            return g04_SubContinent;
        }

        /// <summary>
        /// Deletes the G04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
