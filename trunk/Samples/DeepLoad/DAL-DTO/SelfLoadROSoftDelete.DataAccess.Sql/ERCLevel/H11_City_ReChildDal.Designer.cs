using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH11_City_ReChildDal"/>
    /// </summary>
    public partial class H11_City_ReChildDal : IH11_City_ReChildDal
    {
        /// <summary>
        /// Loads a H11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A H11_City_ReChildDto object.</returns>
        public H11_City_ReChildDto Fetch(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H11_City_ReChildDto Fetch(IDataReader data)
        {
            var h11_City_ReChild = new H11_City_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h11_City_ReChild.City_Child_Name = dr.GetString("City_Child_Name");
                }
            }
            return h11_City_ReChild;
        }
    }
}
