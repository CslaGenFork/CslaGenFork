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
    /// DAL SQL Server implementation of <see cref="IH05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class H05_SubContinent_ReChildDal : IH05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a H05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A H05_SubContinent_ReChildDto object.</returns>
        public H05_SubContinent_ReChildDto Fetch(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H05_SubContinent_ReChildDto Fetch(IDataReader data)
        {
            var h05_SubContinent_ReChild = new H05_SubContinent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                }
            }
            return h05_SubContinent_ReChild;
        }

        /// <summary>
        /// Inserts a new H05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="h05_SubContinent_ReChild">The H05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="H05_SubContinent_ReChildDto"/>.</returns>
        public H05_SubContinent_ReChildDto Insert(H05_SubContinent_ReChildDto h05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", h05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", h05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return h05_SubContinent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the H05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="h05_SubContinent_ReChild">The H05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="H05_SubContinent_ReChildDto"/>.</returns>
        public H05_SubContinent_ReChildDto Update(H05_SubContinent_ReChildDto h05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", h05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", h05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H05_SubContinent_ReChild");
                }
            }
            return h05_SubContinent_ReChild;
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
