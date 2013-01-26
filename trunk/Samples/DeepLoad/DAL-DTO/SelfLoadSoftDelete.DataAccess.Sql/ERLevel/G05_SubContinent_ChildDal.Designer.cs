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
    /// DAL SQL Server implementation of <see cref="IG05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class G05_SubContinent_ChildDal : IG05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a G05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A G05_SubContinent_ChildDto object.</returns>
        public G05_SubContinent_ChildDto Fetch(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G05_SubContinent_ChildDto Fetch(IDataReader data)
        {
            var g05_SubContinent_Child = new G05_SubContinent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                    g05_SubContinent_Child.SubContinent_ID1 = dr.GetInt32("SubContinent_ID1");
                    g05_SubContinent_Child.RowVersion = dr.GetValue("RowVersion") as byte[];
                }
            }
            return g05_SubContinent_Child;
        }

        /// <summary>
        /// Inserts a new G05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="g05_SubContinent_Child">The G05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="G05_SubContinent_ChildDto"/>.</returns>
        public G05_SubContinent_ChildDto Insert(G05_SubContinent_ChildDto g05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", g05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", g05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    g05_SubContinent_Child.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return g05_SubContinent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the G05_SubContinent_Child object.
        /// </summary>
        /// <param name="g05_SubContinent_Child">The G05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="G05_SubContinent_ChildDto"/>.</returns>
        public G05_SubContinent_ChildDto Update(G05_SubContinent_ChildDto g05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", g05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", g05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", g05_SubContinent_Child.SubContinent_ID1).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", g05_SubContinent_Child.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G05_SubContinent_Child");

                    g05_SubContinent_Child.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return g05_SubContinent_Child;
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
