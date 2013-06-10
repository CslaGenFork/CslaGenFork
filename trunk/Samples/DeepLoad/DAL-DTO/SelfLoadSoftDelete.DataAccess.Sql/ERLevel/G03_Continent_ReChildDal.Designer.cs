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
    /// DAL SQL Server implementation of <see cref="IG03_Continent_ReChildDal"/>
    /// </summary>
    public partial class G03_Continent_ReChildDal : IG03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a G03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A G03_Continent_ReChildDto object.</returns>
        public G03_Continent_ReChildDto Fetch(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G03_Continent_ReChildDto Fetch(IDataReader data)
        {
            var g03_Continent_ReChild = new G03_Continent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g03_Continent_ReChild.Continent_Child_Name = dr.GetString("Continent_Child_Name");
                }
            }
            return g03_Continent_ReChild;
        }

        /// <summary>
        /// Inserts a new G03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="g03_Continent_ReChild">The G03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="G03_Continent_ReChildDto"/>.</returns>
        public G03_Continent_ReChildDto Insert(G03_Continent_ReChildDto g03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", g03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", g03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return g03_Continent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the G03_Continent_ReChild object.
        /// </summary>
        /// <param name="g03_Continent_ReChild">The G03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="G03_Continent_ReChildDto"/>.</returns>
        public G03_Continent_ReChildDto Update(G03_Continent_ReChildDto g03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", g03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", g03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G03_Continent_ReChild");
                }
            }
            return g03_Continent_ReChild;
        }

        /// <summary>
        /// Deletes the G03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID2">The parent Continent ID2.</param>
        public void Delete(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
