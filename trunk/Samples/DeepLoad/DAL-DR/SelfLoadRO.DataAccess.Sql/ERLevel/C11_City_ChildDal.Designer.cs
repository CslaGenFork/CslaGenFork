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
    /// DAL SQL Server implementation of <see cref="IC11_City_ChildDal"/>
    /// </summary>
    public partial class C11_City_ChildDal : IC11_City_ChildDal
    {
        /// <summary>
        /// Loads a C11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        /// <returns>A data reader to the C11_City_Child.</returns>
        public IDataReader Fetch(int city_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", city_ID1).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
