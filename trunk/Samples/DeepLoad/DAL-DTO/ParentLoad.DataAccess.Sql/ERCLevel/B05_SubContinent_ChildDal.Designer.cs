using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IB05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class B05_SubContinent_ChildDal : IB05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new B05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="b05_SubContinent_Child">The B05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="B05_SubContinent_ChildDto"/>.</returns>
        public B05_SubContinent_ChildDto Insert(B05_SubContinent_ChildDto b05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", b05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", b05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return b05_SubContinent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the B05_SubContinent_Child object.
        /// </summary>
        /// <param name="b05_SubContinent_Child">The B05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="B05_SubContinent_ChildDto"/>.</returns>
        public B05_SubContinent_ChildDto Update(B05_SubContinent_ChildDto b05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", b05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", b05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B05_SubContinent_Child");
                }
            }
            return b05_SubContinent_Child;
        }

        /// <summary>
        /// Deletes the B05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        public void Delete(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
