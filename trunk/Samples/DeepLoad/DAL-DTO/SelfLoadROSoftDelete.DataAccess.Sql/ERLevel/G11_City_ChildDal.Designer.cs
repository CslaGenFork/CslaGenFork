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
    /// DAL SQL Server implementation of <see cref="IG11_City_ChildDal"/>
    /// </summary>
    public partial class G11_City_ChildDal : IG11_City_ChildDal
    {
        /// <summary>
        /// Loads a G11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A G11_City_ChildDto object.</returns>
        public G11_City_ChildDto Fetch(int city_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", city_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G11_City_ChildDto Fetch(IDataReader data)
        {
            var g11_City_Child = new G11_City_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g11_City_Child.City_Child_Name = dr.GetString("City_Child_Name");
                }
            }
            return g11_City_Child;
        }
    }
}
