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
    /// DAL SQL Server implementation of <see cref="IF05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class F05_SubContinent_ChildDal : IF05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new F05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        public void Insert(int subContinent_ID, string subContinent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", subContinent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the F05_SubContinent_Child object.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        public void Update(int subContinent_ID, string subContinent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", subContinent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F05_SubContinent_Child");
                }
            }
        }

        /// <summary>
        /// Deletes the F05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
