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
    /// DAL SQL Server implementation of <see cref="IH03_Continent_ReChildDal"/>
    /// </summary>
    public partial class H03_Continent_ReChildDal : IH03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A H03_Continent_ReChildDto object.</returns>
        public H03_Continent_ReChildDto Fetch(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H03_Continent_ReChildDto Fetch(IDataReader data)
        {
            var h03_Continent_ReChild = new H03_Continent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h03_Continent_ReChild.Continent_Child_Name = dr.GetString("Continent_Child_Name");
                }
            }
            return h03_Continent_ReChild;
        }

        /// <summary>
        /// Inserts a new H03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="h03_Continent_ReChild">The H03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="H03_Continent_ReChildDto"/>.</returns>
        public H03_Continent_ReChildDto Insert(H03_Continent_ReChildDto h03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", h03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", h03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return h03_Continent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the H03_Continent_ReChild object.
        /// </summary>
        /// <param name="h03_Continent_ReChild">The H03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="H03_Continent_ReChildDto"/>.</returns>
        public H03_Continent_ReChildDto Update(H03_Continent_ReChildDto h03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", h03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", h03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H03_Continent_ReChild");
                }
            }
            return h03_Continent_ReChild;
        }

        /// <summary>
        /// Deletes the H03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID2">The parent Continent ID2.</param>
        public void Delete(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
