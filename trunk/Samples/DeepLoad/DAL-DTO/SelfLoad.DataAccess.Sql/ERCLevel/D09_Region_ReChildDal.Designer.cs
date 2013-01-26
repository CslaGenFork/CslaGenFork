using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID09_Region_ReChildDal"/>
    /// </summary>
    public partial class D09_Region_ReChildDal : ID09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a D09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A D09_Region_ReChildDto object.</returns>
        public D09_Region_ReChildDto Fetch(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private D09_Region_ReChildDto Fetch(IDataReader data)
        {
            var d09_Region_ReChild = new D09_Region_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    d09_Region_ReChild.Region_Child_Name = dr.GetString("Region_Child_Name");
                }
            }
            return d09_Region_ReChild;
        }

        /// <summary>
        /// Inserts a new D09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="d09_Region_ReChild">The D09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="D09_Region_ReChildDto"/>.</returns>
        public D09_Region_ReChildDto Insert(D09_Region_ReChildDto d09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", d09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", d09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return d09_Region_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the D09_Region_ReChild object.
        /// </summary>
        /// <param name="d09_Region_ReChild">The D09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="D09_Region_ReChildDto"/>.</returns>
        public D09_Region_ReChildDto Update(D09_Region_ReChildDto d09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", d09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", d09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D09_Region_ReChild");
                }
            }
            return d09_Region_ReChild;
        }

        /// <summary>
        /// Deletes the D09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        public void Delete(int region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", region_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
