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
    /// DAL SQL Server implementation of <see cref="IG05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class G05_SubContinent_ReChildDal : IG05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a G05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A G05_SubContinent_ReChildDto object.</returns>
        public G05_SubContinent_ReChildDto Fetch(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G05_SubContinent_ReChildDto Fetch(IDataReader data)
        {
            var g05_SubContinent_ReChild = new G05_SubContinent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                    g05_SubContinent_ReChild.RowVersion = dr.GetValue("RowVersion") as byte[];
                }
            }
            return g05_SubContinent_ReChild;
        }

        /// <summary>
        /// Inserts a new G05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="g05_SubContinent_ReChild">The G05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="G05_SubContinent_ReChildDto"/>.</returns>
        public G05_SubContinent_ReChildDto Insert(G05_SubContinent_ReChildDto g05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", g05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", g05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    g05_SubContinent_ReChild.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return g05_SubContinent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the G05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="g05_SubContinent_ReChild">The G05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="G05_SubContinent_ReChildDto"/>.</returns>
        public G05_SubContinent_ReChildDto Update(G05_SubContinent_ReChildDto g05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", g05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", g05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@RowVersion", g05_SubContinent_ReChild.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G05_SubContinent_ReChild");

                    g05_SubContinent_ReChild.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return g05_SubContinent_ReChild;
        }

        /// <summary>
        /// Deletes the G05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        public void Delete(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
