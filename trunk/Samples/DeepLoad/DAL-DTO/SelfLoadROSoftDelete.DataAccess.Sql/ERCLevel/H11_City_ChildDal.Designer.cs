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
    /// DAL SQL Server implementation of <see cref="IH11_City_ChildDal"/>
    /// </summary>
    public partial class H11_City_ChildDal : IH11_City_ChildDal
    {
        /// <summary>
        /// Loads a H11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A H11_City_ChildDto object.</returns>
        public H11_City_ChildDto Fetch(int city_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", city_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H11_City_ChildDto Fetch(IDataReader data)
        {
            var h11_City_Child = new H11_City_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h11_City_Child.City_Child_Name = dr.GetString("City_Child_Name");
                }
            }
            return h11_City_Child;
        }
    }
}
