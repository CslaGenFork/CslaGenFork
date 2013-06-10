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
    /// DAL SQL Server implementation of <see cref="IC04_SubContinentDal"/>
    /// </summary>
    public partial class C04_SubContinentDal : IC04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new C04_SubContinent object in the database.
        /// </summary>
        /// <param name="c04_SubContinent">The C04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="C04_SubContinentDto"/>.</returns>
        public C04_SubContinentDto Insert(C04_SubContinentDto c04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", c04_SubContinent.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", c04_SubContinent.SubContinent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", c04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    c04_SubContinent.SubContinent_ID = (int)cmd.Parameters["@SubContinent_ID"].Value;
                }
            }
            return c04_SubContinent;
        }

        /// <summary>
        /// Updates in the database all changes made to the C04_SubContinent object.
        /// </summary>
        /// <param name="c04_SubContinent">The C04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="C04_SubContinentDto"/>.</returns>
        public C04_SubContinentDto Update(C04_SubContinentDto c04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", c04_SubContinent.SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", c04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C04_SubContinent");
                }
            }
            return c04_SubContinent;
        }

        /// <summary>
        /// Deletes the C04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
