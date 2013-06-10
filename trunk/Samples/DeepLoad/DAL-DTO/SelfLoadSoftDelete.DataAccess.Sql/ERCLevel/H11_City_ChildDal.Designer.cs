using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH11_City_ChildDal"/>
    /// </summary>
    public partial class H11_City_ChildDal : IH11_City_ChildDal
    {
        /// <summary>
        /// Loads a H11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The fetch criteria.</param>
        /// <returns>A H11_City_ChildDto object.</returns>
        public H11_City_ChildDto Fetch(int city_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", city_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H11_City_ChildDto Fetch(IDataReader data)
        {
            var h11_City_Child = new H11_City_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h11_City_Child.City_Child_Name = dr.GetString("City_Child_Name");
                }
            }
            return h11_City_Child;
        }

        /// <summary>
        /// Inserts a new H11_City_Child object in the database.
        /// </summary>
        /// <param name="h11_City_Child">The H11 City Child DTO.</param>
        /// <returns>The new <see cref="H11_City_ChildDto"/>.</returns>
        public H11_City_ChildDto Insert(H11_City_ChildDto h11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", h11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", h11_City_Child.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return h11_City_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the H11_City_Child object.
        /// </summary>
        /// <param name="h11_City_Child">The H11 City Child DTO.</param>
        /// <returns>The updated <see cref="H11_City_ChildDto"/>.</returns>
        public H11_City_ChildDto Update(H11_City_ChildDto h11_City_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", h11_City_Child.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", h11_City_Child.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H11_City_Child");
                }
            }
            return h11_City_Child;
        }

        /// <summary>
        /// Deletes the H11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        public void Delete(int city_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH11_City_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID1", city_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
