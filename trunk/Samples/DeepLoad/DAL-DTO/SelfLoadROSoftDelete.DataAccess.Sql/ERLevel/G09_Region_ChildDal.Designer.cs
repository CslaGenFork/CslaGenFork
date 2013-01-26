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
    /// DAL SQL Server implementation of <see cref="IG09_Region_ChildDal"/>
    /// </summary>
    public partial class G09_Region_ChildDal : IG09_Region_ChildDal
    {
        /// <summary>
        /// Loads a G09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A G09_Region_ChildDto object.</returns>
        public G09_Region_ChildDto Fetch(int region_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG09_Region_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID1", region_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G09_Region_ChildDto Fetch(IDataReader data)
        {
            var g09_Region_Child = new G09_Region_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g09_Region_Child.Region_Child_Name = dr.GetString("Region_Child_Name");
                }
            }
            return g09_Region_Child;
        }
    }
}
