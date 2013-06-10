using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC09_Region_ReChildDal"/>
    /// </summary>
    public partial class C09_Region_ReChildDal : IC09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a C09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A C09_Region_ReChildDto object.</returns>
        public C09_Region_ReChildDto Fetch(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C09_Region_ReChildDto Fetch(IDataReader data)
        {
            var c09_Region_ReChild = new C09_Region_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c09_Region_ReChild.Region_Child_Name = dr.GetString("Region_Child_Name");
                }
            }
            return c09_Region_ReChild;
        }

        /// <summary>
        /// Inserts a new C09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="c09_Region_ReChild">The C09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="C09_Region_ReChildDto"/>.</returns>
        public C09_Region_ReChildDto Insert(C09_Region_ReChildDto c09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", c09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", c09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return c09_Region_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the C09_Region_ReChild object.
        /// </summary>
        /// <param name="c09_Region_ReChild">The C09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="C09_Region_ReChildDto"/>.</returns>
        public C09_Region_ReChildDto Update(C09_Region_ReChildDto c09_Region_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", c09_Region_ReChild.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", c09_Region_ReChild.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C09_Region_ReChild");
                }
            }
            return c09_Region_ReChild;
        }

        /// <summary>
        /// Deletes the C09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        public void Delete(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
