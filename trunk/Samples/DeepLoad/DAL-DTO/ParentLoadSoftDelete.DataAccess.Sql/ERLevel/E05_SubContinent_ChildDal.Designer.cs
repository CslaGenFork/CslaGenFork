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
    /// DAL SQL Server implementation of <see cref="IE05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class E05_SubContinent_ChildDal : IE05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new E05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="e05_SubContinent_Child">The E05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="E05_SubContinent_ChildDto"/>.</returns>
        public E05_SubContinent_ChildDto Insert(E05_SubContinent_ChildDto e05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", e05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", e05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    e05_SubContinent_Child.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return e05_SubContinent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the E05_SubContinent_Child object.
        /// </summary>
        /// <param name="e05_SubContinent_Child">The E05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="E05_SubContinent_ChildDto"/>.</returns>
        public E05_SubContinent_ChildDto Update(E05_SubContinent_ChildDto e05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", e05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", e05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@RowVersion", e05_SubContinent_Child.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E05_SubContinent_Child");

                    e05_SubContinent_Child.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return e05_SubContinent_Child;
        }

        /// <summary>
        /// Deletes the E05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        public void Delete(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
