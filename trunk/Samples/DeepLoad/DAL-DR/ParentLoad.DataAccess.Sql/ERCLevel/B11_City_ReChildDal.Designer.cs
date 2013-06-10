using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IB11_City_ReChildDal"/>
    /// </summary>
    public partial class B11_City_ReChildDal : IB11_City_ReChildDal
    {
        /// <summary>
        /// Inserts a new B11_City_ReChild object in the database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        public void Insert(int city_ID2, string city_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", city_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the B11_City_ReChild object.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        public void Update(int city_ID2, string city_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", city_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B11_City_ReChild");
                }
            }
        }

        /// <summary>
        /// Deletes the B11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        public void Delete(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
