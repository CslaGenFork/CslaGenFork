using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess.ERLevel;
using SelfLoadROSoftDelete.DataAccess;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG07_RegionCollDal"/>
    /// </summary>
    public partial class G07_RegionCollDal : IG07_RegionCollDal
    {

        /// <summary>
        /// Loads a G07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        /// <returns>A data reader to the G07_RegionColl.</returns>
        public IDataReader Fetch(int parent_Country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG07_RegionColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", parent_Country_ID).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
