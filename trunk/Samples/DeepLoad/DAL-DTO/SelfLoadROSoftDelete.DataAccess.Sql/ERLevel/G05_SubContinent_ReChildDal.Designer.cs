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
    /// DAL SQL Server implementation of <see cref="IG05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class G05_SubContinent_ReChildDal : IG05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a G05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A G05_SubContinent_ReChildDto object.</returns>
        public G05_SubContinent_ReChildDto Fetch(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G05_SubContinent_ReChildDto Fetch(IDataReader data)
        {
            var g05_SubContinent_ReChild = new G05_SubContinent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                    g05_SubContinent_ReChild.RowVersion = dr.GetValue("RowVersion") as byte[];
                }
            }
            return g05_SubContinent_ReChild;
        }
    }
}
