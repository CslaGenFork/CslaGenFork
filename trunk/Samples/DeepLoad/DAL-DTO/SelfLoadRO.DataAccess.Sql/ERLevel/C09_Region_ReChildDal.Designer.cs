using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERLevel;

namespace SelfLoadRO.DataAccess.Sql.ERLevel
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
    }
}
