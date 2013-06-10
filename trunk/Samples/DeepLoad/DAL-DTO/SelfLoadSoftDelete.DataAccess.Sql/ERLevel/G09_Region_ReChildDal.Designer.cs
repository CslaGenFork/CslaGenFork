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
    /// DAL SQL Server implementation of <see cref="IG09_Region_ReChildDal"/>
    /// </summary>
    public partial class G09_Region_ReChildDal : IG09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a G09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A G09_Region_ReChildDto object.</returns>
        public G09_Region_ReChildDto Fetch(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G09_Region_ReChildDto Fetch(IDataReader data)
        {
            var g09_Region_ReChild = new G09_Region_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g09_Region_ReChild.Region_Child_Name = dr.GetString("Region_Child_Name");
                }
            }
            return g09_Region_ReChild;
        }

        /// <summary>
        /// Inserts a new G09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="g09_Region_ReChild">The G09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="G09_Region_ReChildDto"/>.</returns>
        public G09_Region_ReChildDto Insert(G09_Region_ReChildDto g09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", g09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", g09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return g09_Region_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the G09_Region_ReChild object.
        /// </summary>
        /// <param name="g09_Region_ReChild">The G09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="G09_Region_ReChildDto"/>.</returns>
        public G09_Region_ReChildDto Update(G09_Region_ReChildDto g09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", g09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", g09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G09_Region_ReChild");
                }
            }
            return g09_Region_ReChild;
        }

        /// <summary>
        /// Deletes the G09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        public void Delete(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
