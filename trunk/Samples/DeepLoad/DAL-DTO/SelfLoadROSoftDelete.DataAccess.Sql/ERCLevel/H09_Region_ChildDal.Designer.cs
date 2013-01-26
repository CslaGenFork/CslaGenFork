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
    /// DAL SQL Server implementation of <see cref="IH09_Region_ChildDal"/>
    /// </summary>
    public partial class H09_Region_ChildDal : IH09_Region_ChildDal
    {
        /// <summary>
        /// Loads a H09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A H09_Region_ChildDto object.</returns>
        public H09_Region_ChildDto Fetch(int region_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H09_Region_ChildDto Fetch(IDataReader data)
        {
            var h09_Region_Child = new H09_Region_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h09_Region_Child.Region_Child_Name = dr.GetString("Region_Child_Name");
                }
            }
            return h09_Region_Child;
        }
    }
}
