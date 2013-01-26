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
    /// DAL SQL Server implementation of <see cref="IC05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class C05_SubContinent_ChildDal : IC05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A C05_SubContinent_ChildDto object.</returns>
        public C05_SubContinent_ChildDto Fetch(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C05_SubContinent_ChildDto Fetch(IDataReader data)
        {
            var c05_SubContinent_Child = new C05_SubContinent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                    c05_SubContinent_Child.SubContinent_ID1 = dr.GetInt32("SubContinent_ID1");
                    c05_SubContinent_Child.RowVersion = dr.GetValue("RowVersion") as byte[];
                }
            }
            return c05_SubContinent_Child;
        }
    }
}
