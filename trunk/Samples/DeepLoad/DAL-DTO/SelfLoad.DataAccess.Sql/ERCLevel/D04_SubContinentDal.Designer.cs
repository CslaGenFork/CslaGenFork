using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID04_SubContinentDal"/>
    /// </summary>
    public partial class D04_SubContinentDal : ID04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new D04_SubContinent object in the database.
        /// </summary>
        /// <param name="d04_SubContinent">The D04 Sub Continent DTO.</param>
        /// <returns>The new <see cref="D04_SubContinentDto"/>.</returns>
        public D04_SubContinentDto Insert(D04_SubContinentDto d04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", d04_SubContinent.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", d04_SubContinent.SubContinent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", d04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    d04_SubContinent.SubContinent_ID = (int)cmd.Parameters["@SubContinent_ID"].Value;
                }
            }
            return d04_SubContinent;
        }

        /// <summary>
        /// Updates in the database all changes made to the D04_SubContinent object.
        /// </summary>
        /// <param name="d04_SubContinent">The D04 Sub Continent DTO.</param>
        /// <returns>The updated <see cref="D04_SubContinentDto"/>.</returns>
        public D04_SubContinentDto Update(D04_SubContinentDto d04_SubContinent)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", d04_SubContinent.SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", d04_SubContinent.SubContinent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D04_SubContinent");
                }
            }
            return d04_SubContinent;
        }

        /// <summary>
        /// Deletes the D04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
