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
    /// DAL SQL Server implementation of <see cref="ID09_Region_ChildDal"/>
    /// </summary>
    public partial class D09_Region_ChildDal : ID09_Region_ChildDal
    {
        /// <summary>
        /// Loads a D09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A D09_Region_ChildDto object.</returns>
        public D09_Region_ChildDto Fetch(int region_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private D09_Region_ChildDto Fetch(IDataReader data)
        {
            var d09_Region_Child = new D09_Region_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    d09_Region_Child.Region_Child_Name = dr.GetString("Region_Child_Name");
                }
            }
            return d09_Region_Child;
        }

        /// <summary>
        /// Inserts a new D09_Region_Child object in the database.
        /// </summary>
        /// <param name="d09_Region_Child">The D09 Region Child DTO.</param>
        /// <returns>The new <see cref="D09_Region_ChildDto"/>.</returns>
        public D09_Region_ChildDto Insert(D09_Region_ChildDto d09_Region_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", d09_Region_Child.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", d09_Region_Child.Region_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return d09_Region_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the D09_Region_Child object.
        /// </summary>
        /// <param name="d09_Region_Child">The D09 Region Child DTO.</param>
        /// <returns>The updated <see cref="D09_Region_ChildDto"/>.</returns>
        public D09_Region_ChildDto Update(D09_Region_ChildDto d09_Region_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", d09_Region_Child.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Region_Child_Name", d09_Region_Child.Region_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D09_Region_Child");
                }
            }
            return d09_Region_Child;
        }

        /// <summary>
        /// Deletes the D09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        public void Delete(int region_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
