using System;
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
        /// <param name="region_ID2">The Region ID2.</param>
        /// <returns>A data reader to the C09_Region_ReChild.</returns>
        public IDataReader Fetch(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
