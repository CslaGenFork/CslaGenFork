using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG09_Region_ReChildDal"/>
    /// </summary>
    public partial class G09_Region_ReChildDal : IG09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a G09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The Region ID2.</param>
        /// <returns>A data reader to the G09_Region_ReChild.</returns>
        public IDataReader Fetch(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
