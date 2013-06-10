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
    /// DAL SQL Server implementation of <see cref="IH11_City_ReChildDal"/>
    /// </summary>
    public partial class H11_City_ReChildDal : IH11_City_ReChildDal
    {
        /// <summary>
        /// Loads a H11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A H11_City_ReChildDto object.</returns>
        public H11_City_ReChildDto Fetch(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private H11_City_ReChildDto Fetch(IDataReader data)
        {
            var h11_City_ReChild = new H11_City_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    h11_City_ReChild.City_Child_Name = dr.GetString("City_Child_Name");
                }
            }
            return h11_City_ReChild;
        }

        /// <summary>
        /// Inserts a new H11_City_ReChild object in the database.
        /// </summary>
        /// <param name="h11_City_ReChild">The H11 City Re Child DTO.</param>
        /// <returns>The new <see cref="H11_City_ReChildDto"/>.</returns>
        public H11_City_ReChildDto Insert(H11_City_ReChildDto h11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", h11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", h11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return h11_City_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the H11_City_ReChild object.
        /// </summary>
        /// <param name="h11_City_ReChild">The H11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="H11_City_ReChildDto"/>.</returns>
        public H11_City_ReChildDto Update(H11_City_ReChildDto h11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", h11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", h11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H11_City_ReChild");
                }
            }
            return h11_City_ReChild;
        }

        /// <summary>
        /// Deletes the H11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        public void Delete(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
