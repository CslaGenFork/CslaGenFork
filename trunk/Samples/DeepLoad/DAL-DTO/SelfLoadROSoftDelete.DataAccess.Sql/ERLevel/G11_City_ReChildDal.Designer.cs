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
    /// DAL SQL Server implementation of <see cref="IG11_City_ReChildDal"/>
    /// </summary>
    public partial class G11_City_ReChildDal : IG11_City_ReChildDal
    {
        /// <summary>
        /// Loads a G11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A G11_City_ReChildDto object.</returns>
        public G11_City_ReChildDto Fetch(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G11_City_ReChildDto Fetch(IDataReader data)
        {
            var g11_City_ReChild = new G11_City_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g11_City_ReChild.City_Child_Name = dr.GetString("City_Child_Name");
                }
            }
            return g11_City_ReChild;
        }
    }
}
