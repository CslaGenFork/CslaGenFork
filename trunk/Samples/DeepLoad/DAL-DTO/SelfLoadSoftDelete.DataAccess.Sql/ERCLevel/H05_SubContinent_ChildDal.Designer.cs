using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

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
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A H05_SubContinent_ChildDto object.</returns>
        public H05_SubContinent_ChildDto Fetch(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H05_SubContinent_ChildDto Fetch(IDataReader data)
        {
            var h05_SubContinent_Child = new H05_SubContinent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                }
            }
            return h05_SubContinent_Child;
        }

        /// <summary>
        /// Inserts a new H05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="h05_SubContinent_Child">The H05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="H05_SubContinent_ChildDto"/>.</returns>
        public H05_SubContinent_ChildDto Insert(H05_SubContinent_ChildDto h05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", h05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", h05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return h05_SubContinent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the H05_SubContinent_Child object.
        /// </summary>
        /// <param name="h05_SubContinent_Child">The H05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="H05_SubContinent_ChildDto"/>.</returns>
        public H05_SubContinent_ChildDto Update(H05_SubContinent_ChildDto h05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", h05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", h05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H05_SubContinent_Child");
                }
            }
            return h05_SubContinent_Child;
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
