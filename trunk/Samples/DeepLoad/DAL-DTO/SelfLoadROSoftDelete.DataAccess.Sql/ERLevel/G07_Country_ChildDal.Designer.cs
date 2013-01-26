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
    /// DAL SQL Server implementation of <see cref="IG07_Country_ChildDal"/>
    /// </summary>
    public partial class G07_Country_ChildDal : IG07_Country_ChildDal
    {
        /// <summary>
        /// Loads a G07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A G07_Country_ChildDto object.</returns>
        public G07_Country_ChildDto Fetch(int country_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", country_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G07_Country_ChildDto Fetch(IDataReader data)
        {
            var g07_Country_Child = new G07_Country_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g07_Country_Child.Country_Child_Name = dr.GetString("Country_Child_Name");
                }
            }
            return g07_Country_Child;
        }
    }
}
