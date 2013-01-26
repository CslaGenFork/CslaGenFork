using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG07_Country_ChildDal"/>
    /// </summary>
    public partial class G07_Country_ChildDal : IG07_Country_ChildDal
    {
        /// <summary>
        /// Loads a G07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The Country ID1.</param>
        /// <returns>A data reader to the G07_Country_Child.</returns>
        public IDataReader Fetch(int country_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", country_ID1).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
