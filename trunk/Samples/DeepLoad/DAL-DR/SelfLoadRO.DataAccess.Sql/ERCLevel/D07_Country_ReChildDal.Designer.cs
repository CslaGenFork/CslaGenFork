using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERCLevel;

namespace SelfLoadRO.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID07_Country_ReChildDal"/>
    /// </summary>
    public partial class D07_Country_ReChildDal : ID07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a D07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The Country ID2.</param>
        /// <returns>A data reader to the D07_Country_ReChild.</returns>
        public IDataReader Fetch(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
