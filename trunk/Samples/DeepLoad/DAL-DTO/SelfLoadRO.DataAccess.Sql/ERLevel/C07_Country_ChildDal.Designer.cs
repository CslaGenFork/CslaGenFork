using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERLevel;

namespace SelfLoadRO.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC07_Country_ChildDal"/>
    /// </summary>
    public partial class C07_Country_ChildDal : IC07_Country_ChildDal
    {
        /// <summary>
        /// Loads a C07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A C07_Country_ChildDto object.</returns>
        public C07_Country_ChildDto Fetch(int country_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", country_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C07_Country_ChildDto Fetch(IDataReader data)
        {
            var c07_Country_Child = new C07_Country_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c07_Country_Child.Country_Child_Name = dr.GetString("Country_Child_Name");
                }
            }
            return c07_Country_Child;
        }
    }
}
