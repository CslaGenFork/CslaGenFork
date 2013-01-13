using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess.ERLevel;
using SelfLoadRO.DataAccess;

namespace SelfLoadRO.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class C05_SubContinent_ReChildDal : IC05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The Sub Continent ID2.</param>
        /// <returns>A data reader to the C05_SubContinent_ReChild.</returns>
        public IDataReader Fetch(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
