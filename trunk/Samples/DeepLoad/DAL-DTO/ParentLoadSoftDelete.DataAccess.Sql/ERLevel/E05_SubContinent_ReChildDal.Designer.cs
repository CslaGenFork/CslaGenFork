using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IE05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class E05_SubContinent_ReChildDal : IE05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Inserts a new E05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="e05_SubContinent_ReChild">The E05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="E05_SubContinent_ReChildDto"/>.</returns>
        public E05_SubContinent_ReChildDto Insert(E05_SubContinent_ReChildDto e05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", e05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", e05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    e05_SubContinent_ReChild.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return e05_SubContinent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the E05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="e05_SubContinent_ReChild">The E05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="E05_SubContinent_ReChildDto"/>.</returns>
        public E05_SubContinent_ReChildDto Update(E05_SubContinent_ReChildDto e05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", e05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", e05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@RowVersion", e05_SubContinent_ReChild.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E05_SubContinent_ReChild");

                    e05_SubContinent_ReChild.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return e05_SubContinent_ReChild;
        }

        /// <summary>
        /// Deletes the E05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        public void Delete(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
