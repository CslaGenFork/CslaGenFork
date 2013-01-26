using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG03_Continent_ReChildDal"/>
    /// </summary>
    public partial class G03_Continent_ReChildDal : IG03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a G03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A G03_Continent_ReChildDto object.</returns>
        public G03_Continent_ReChildDto Fetch(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G03_Continent_ReChildDto Fetch(IDataReader data)
        {
            var g03_Continent_ReChild = new G03_Continent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g03_Continent_ReChild.Continent_Child_Name = dr.GetString("Continent_Child_Name");
                }
            }
            return g03_Continent_ReChild;
        }
    }
}
