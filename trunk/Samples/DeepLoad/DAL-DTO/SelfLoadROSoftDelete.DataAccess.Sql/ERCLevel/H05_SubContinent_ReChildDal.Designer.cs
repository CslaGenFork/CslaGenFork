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
    /// DAL SQL Server implementation of <see cref="IH05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class H05_SubContinent_ReChildDal : IH05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a H05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A H05_SubContinent_ReChildDto object.</returns>
        public H05_SubContinent_ReChildDto Fetch(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H05_SubContinent_ReChildDto Fetch(IDataReader data)
        {
            var h05_SubContinent_ReChild = new H05_SubContinent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                }
            }
            return h05_SubContinent_ReChild;
        }
    }
}
