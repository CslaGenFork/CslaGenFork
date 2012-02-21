using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;
using SelfLoadROSoftDelete.DataAccess;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH11_City_ReChildDal"/>
    /// </summary>
    public partial class H11_City_ReChildDal : IH11_City_ReChildDal
    {

        /// <summary>
        /// Loads a H11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The City ID2.</param>
        /// <returns>A data reader to the H11_City_ReChild.</returns>
        public IDataReader Fetch(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
