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

        /// <summary>
        /// Inserts a new G11_City_Child object in the database.
        /// </summary>
        /// <param name="g11_City_Child">The G11 City Child DTO.</param>
        /// <returns>The new <see cref="G11_City_ChildDto"/>.</returns>
        public G11_City_ChildDto Insert(G11_City_ChildDto g11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", g11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", g11_City_Child.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return g11_City_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the G11_City_Child object.
        /// </summary>
        /// <param name="g11_City_Child">The G11 City Child DTO.</param>
        /// <returns>The updated <see cref="G11_City_ChildDto"/>.</returns>
        public G11_City_ChildDto Update(G11_City_ChildDto g11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", g11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", g11_City_Child.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G11_City_Child");
                }
            }
            return g11_City_Child;
        }

        /// <summary>
        /// Deletes the G11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        public void Delete(int city_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", city_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
