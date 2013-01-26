using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH09_Region_ReChildDal"/>
    /// </summary>
    public partial class H09_Region_ReChildDal : IH09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a H09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The Region ID2.</param>
        /// <returns>A data reader to the H09_Region_ReChild.</returns>
        public IDataReader Fetch(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
