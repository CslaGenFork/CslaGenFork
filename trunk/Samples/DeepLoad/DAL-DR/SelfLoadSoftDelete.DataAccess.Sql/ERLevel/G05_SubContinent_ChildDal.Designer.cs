using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess.ERLevel;
using SelfLoadSoftDelete.DataAccess;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class G05_SubContinent_ChildDal : IG05_SubContinent_ChildDal
    {

        /// <summary>
        /// Loads a G05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        /// <returns>A data reader to the G05_SubContinent_Child.</returns>
        public IDataReader Fetch(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new G05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        /// <returns>The Row Version of the new G05_SubContinent_Child.</returns>
        public byte[] Insert(int subContinent_ID, string subContinent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", subContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    return (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the G05_SubContinent_Child object.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        /// <param name="subContinent_ID1">The Sub Continent ID1.</param>
        /// <param name="rowVersion">The Row Version.</param>
        /// <returns>The updated Row Version.</returns>
        public byte[] Update(int subContinent_ID, string subContinent_Child_Name, int subContinent_ID1, byte[] rowVersion)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", subContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", rowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G05_SubContinent_Child");

                    return (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
        }

        /// <summary>
        /// Deletes the G05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
