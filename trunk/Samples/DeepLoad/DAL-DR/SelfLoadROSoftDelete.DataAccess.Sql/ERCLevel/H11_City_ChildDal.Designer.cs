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
    /// DAL SQL Server implementation of <see cref="IH11_City_ChildDal"/>
    /// </summary>
    public partial class H11_City_ChildDal : IH11_City_ChildDal
    {
        /// <summary>
        /// Loads a H11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        /// <returns>A data reader to the H11_City_Child.</returns>
        public IDataReader Fetch(int city_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", city_ID1).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
