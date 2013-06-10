using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class H05_SubContinent_ReChildDal : IH05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a H05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        /// <returns>A data reader to the H05_SubContinent_ReChild.</returns>
        public IDataReader Fetch(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new H05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        public void Insert(int subContinent_ID2, string subContinent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", subContinent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the H05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        public void Update(int subContinent_ID2, string subContinent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", subContinent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H05_SubContinent_ReChild");
                }
            }
        }

        /// <summary>
        /// Deletes the H05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        public void Delete(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
