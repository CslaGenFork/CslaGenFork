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
    /// DAL SQL Server implementation of <see cref="IH07_Country_ReChildDal"/>
    /// </summary>
    public partial class H07_Country_ReChildDal : IH07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a H07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A H07_Country_ReChildDto object.</returns>
        public H07_Country_ReChildDto Fetch(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H07_Country_ReChildDto Fetch(IDataReader data)
        {
            var h07_Country_ReChild = new H07_Country_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h07_Country_ReChild.Country_Child_Name = dr.GetString("Country_Child_Name");
                }
            }
            return h07_Country_ReChild;
        }
    }
}
