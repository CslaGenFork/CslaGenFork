using System;
using System.Collections.Generic;
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
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A H09_Region_ReChildDto object.</returns>
        public H09_Region_ReChildDto Fetch(int region_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH09_Region_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID2", region_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H09_Region_ReChildDto Fetch(IDataReader data)
        {
            var h09_Region_ReChild = new H09_Region_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h09_Region_ReChild.Region_Child_Name = dr.GetString("Region_Child_Name");
                }
            }
            return h09_Region_ReChild;
        }
    }
}
