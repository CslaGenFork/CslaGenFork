using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERLevel
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

        /// <summary>
        /// Inserts a new G07_Country_Child object in the database.
        /// </summary>
        /// <param name="g07_Country_Child">The G07 Country Child DTO.</param>
        /// <returns>The new <see cref="G07_Country_ChildDto"/>.</returns>
        public G07_Country_ChildDto Insert(G07_Country_ChildDto g07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", g07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", g07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return g07_Country_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the G07_Country_Child object.
        /// </summary>
        /// <param name="g07_Country_Child">The G07 Country Child DTO.</param>
        /// <returns>The updated <see cref="G07_Country_ChildDto"/>.</returns>
        public G07_Country_ChildDto Update(G07_Country_ChildDto g07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", g07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", g07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G07_Country_Child");
                }
            }
            return g07_Country_Child;
        }

        /// <summary>
        /// Deletes the G07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
