using System;
using System.Collections.Generic;
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
    }
}
