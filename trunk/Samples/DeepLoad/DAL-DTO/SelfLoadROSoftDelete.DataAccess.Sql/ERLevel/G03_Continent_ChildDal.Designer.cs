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
    /// DAL SQL Server implementation of <see cref="IG03_Continent_ChildDal"/>
    /// </summary>
    public partial class G03_Continent_ChildDal : IG03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a G03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A G03_Continent_ChildDto object.</returns>
        public G03_Continent_ChildDto Fetch(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private G03_Continent_ChildDto Fetch(IDataReader data)
        {
            var g03_Continent_Child = new G03_Continent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    g03_Continent_Child.Continent_Child_Name = dr.GetString("Continent_Child_Name");
                }
            }
            return g03_Continent_Child;
        }
    }
}
