using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess.ERCLevel;
using SelfLoadSoftDelete.DataAccess;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class H05_SubContinent_ChildDal : IH05_SubContinent_ChildDal
    {

        /// <summary>
        /// Loads a H05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        /// <returns>A data reader to the H05_SubContinent_Child.</returns>
        public IDataReader Fetch(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new H05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        
        public void Insert(int subContinent_ID, string subContinent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", subContinent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                                    }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the H05_SubContinent_Child object.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        
        public void Update(int subContinent_ID, string subContinent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", subContinent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H05_SubContinent_Child");

                                    }
            }
        }

        /// <summary>
        /// Deletes the H05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
