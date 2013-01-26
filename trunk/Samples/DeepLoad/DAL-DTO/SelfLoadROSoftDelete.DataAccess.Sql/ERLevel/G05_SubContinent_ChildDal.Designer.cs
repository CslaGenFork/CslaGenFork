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
    /// DAL SQL Server implementation of <see cref="IG05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class G05_SubContinent_ChildDal : IG05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a G05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A G05_SubContinent_ChildDto object.</returns>
        public G05_SubContinent_ChildDto Fetch(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G05_SubContinent_ChildDto Fetch(IDataReader data)
        {
            var g05_SubContinent_Child = new G05_SubContinent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                    g05_SubContinent_Child.SubContinent_ID1 = dr.GetInt32("SubContinent_ID1");
                    g05_SubContinent_Child.RowVersion = dr.GetValue("RowVersion") as byte[];
                }
            }
            return g05_SubContinent_Child;
        }
    }
}
