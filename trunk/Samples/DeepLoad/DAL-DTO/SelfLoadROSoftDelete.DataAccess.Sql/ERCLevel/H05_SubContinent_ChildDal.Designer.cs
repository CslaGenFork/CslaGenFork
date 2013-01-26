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
    /// DAL SQL Server implementation of <see cref="IH05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class H05_SubContinent_ChildDal : IH05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a H05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A H05_SubContinent_ChildDto object.</returns>
        public H05_SubContinent_ChildDto Fetch(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H05_SubContinent_ChildDto Fetch(IDataReader data)
        {
            var h05_SubContinent_Child = new H05_SubContinent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                }
            }
            return h05_SubContinent_Child;
        }
    }
}
