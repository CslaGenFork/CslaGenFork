using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess.ERCLevel;
using SelfLoadRO.DataAccess;

namespace SelfLoadRO.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID07_Country_ChildDal"/>
    /// </summary>
    public partial class D07_Country_ChildDal : ID07_Country_ChildDal
    {

        /// <summary>
        /// Loads a D07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The Country ID1.</param>
        /// <returns>A data reader to the D07_Country_Child.</returns>
        public IDataReader Fetch(int country_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", country_ID1).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
