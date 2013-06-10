using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IF04_SubContinentDal"/>
    /// </summary>
    public partial class F04_SubContinentDal : IF04_SubContinentDal
    {
        /// <summary>
        /// Inserts a new F04_SubContinent object in the database.
        /// </summary>
        /// <param name="parent_Continent_ID">The parent Parent Continent ID.</param>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        /// <param name="subContinent_Name">The Sub Continent Name.</param>
        public void Insert(int parent_Continent_ID, out int subContinent_ID, string subContinent_Name)
        {
            subContinent_ID = -1;
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Continent_ID", parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", subContinent_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    subContinent_ID = (int)cmd.Parameters["@SubContinent_ID"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the F04_SubContinent object.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        /// <param name="subContinent_Name">The Sub Continent Name.</param>
        public void Update(int subContinent_ID, string subContinent_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Name", subContinent_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F04_SubContinent");
                }
            }
        }

        /// <summary>
        /// Deletes the F04_SubContinent object from database.
        /// </summary>
        /// <param name="subContinent_ID">The Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF04_SubContinent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
