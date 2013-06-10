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
    /// DAL SQL Server implementation of <see cref="IH03_Continent_ChildDal"/>
    /// </summary>
    public partial class H03_Continent_ChildDal : IH03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A H03_Continent_ChildDto object.</returns>
        public H03_Continent_ChildDto Fetch(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H03_Continent_ChildDto Fetch(IDataReader data)
        {
            var h03_Continent_Child = new H03_Continent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h03_Continent_Child.Continent_Child_Name = dr.GetString("Continent_Child_Name");
                }
            }
            return h03_Continent_Child;
        }

        /// <summary>
        /// Inserts a new H03_Continent_Child object in the database.
        /// </summary>
        /// <param name="h03_Continent_Child">The H03 Continent Child DTO.</param>
        /// <returns>The new <see cref="H03_Continent_ChildDto"/>.</returns>
        public H03_Continent_ChildDto Insert(H03_Continent_ChildDto h03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", h03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", h03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return h03_Continent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the H03_Continent_Child object.
        /// </summary>
        /// <param name="h03_Continent_Child">The H03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="H03_Continent_ChildDto"/>.</returns>
        public H03_Continent_ChildDto Update(H03_Continent_ChildDto h03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", h03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", h03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H03_Continent_Child");
                }
            }
            return h03_Continent_Child;
        }

        /// <summary>
        /// Deletes the H03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        public void Delete(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
