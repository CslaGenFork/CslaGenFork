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
    /// DAL SQL Server implementation of <see cref="IH03_Continent_ChildDal"/>
    /// </summary>
    public partial class H03_Continent_ChildDal : IH03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A H03_Continent_ChildDto object.</returns>
        public H03_Continent_ChildDto Fetch(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H03_Continent_ChildDto Fetch(IDataReader data)
        {
            var h03_Continent_Child = new H03_Continent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h03_Continent_Child.Continent_Child_Name = dr.GetString("Continent_Child_Name");
                }
            }
            return h03_Continent_Child;
        }
    }
}
