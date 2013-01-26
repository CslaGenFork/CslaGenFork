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
    /// DAL SQL Server implementation of <see cref="IC11_City_ReChildDal"/>
    /// </summary>
    public partial class C11_City_ReChildDal : IC11_City_ReChildDal
    {
        /// <summary>
        /// Loads a C11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The City ID2.</param>
        /// <returns>A data reader to the C11_City_ReChild.</returns>
        public IDataReader Fetch(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
