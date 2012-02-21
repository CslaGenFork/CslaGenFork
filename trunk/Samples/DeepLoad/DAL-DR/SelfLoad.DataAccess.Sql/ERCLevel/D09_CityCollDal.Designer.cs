using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess.ERCLevel;
using SelfLoad.DataAccess;

namespace SelfLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID09_CityCollDal"/>
    /// </summary>
    public partial class D09_CityCollDal : ID09_CityCollDal
    {

        /// <summary>
        /// Loads a D09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The Parent Region ID.</param>
        /// <returns>A data reader to the D09_CityColl.</returns>
        public IDataReader Fetch(int parent_Region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD09_CityColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Region_ID", parent_Region_ID).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
