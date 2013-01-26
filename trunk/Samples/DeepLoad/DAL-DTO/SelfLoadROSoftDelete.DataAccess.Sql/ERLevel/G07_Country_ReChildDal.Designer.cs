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
    /// DAL SQL Server implementation of <see cref="IG07_Country_ReChildDal"/>
    /// </summary>
    public partial class G07_Country_ReChildDal : IG07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a G07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A G07_Country_ReChildDto object.</returns>
        public G07_Country_ReChildDto Fetch(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G07_Country_ReChildDto Fetch(IDataReader data)
        {
            var g07_Country_ReChild = new G07_Country_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g07_Country_ReChild.Country_Child_Name = dr.GetString("Country_Child_Name");
                }
            }
            return g07_Country_ReChild;
        }
    }
}
