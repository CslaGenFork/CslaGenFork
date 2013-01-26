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
    /// DAL SQL Server implementation of <see cref="ID07_RegionCollDal"/>
    /// </summary>
    public partial class D07_RegionCollDal : ID07_RegionCollDal
    {
        /// <summary>
        /// Loads a D07_RegionColl collection from the database.
        /// </summary>
        /// <param name="parent_Country_ID">The Parent Country ID.</param>
        /// <returns>A data reader to the D07_RegionColl.</returns>
        public IDataReader Fetch(int parent_Country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD07_RegionColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Country_ID", parent_Country_ID).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
