using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERLevel;

namespace SelfLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC11_City_ReChildDal"/>
    /// </summary>
    public partial class C11_City_ReChildDal : IC11_City_ReChildDal
    {
        /// <summary>
        /// Loads a C11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A C11_City_ReChildDto object.</returns>
        public C11_City_ReChildDto Fetch(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C11_City_ReChildDto Fetch(IDataReader data)
        {
            var c11_City_ReChild = new C11_City_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c11_City_ReChild.City_Child_Name = dr.GetString("City_Child_Name");
                }
            }
            return c11_City_ReChild;
        }

        /// <summary>
        /// Inserts a new C11_City_ReChild object in the database.
        /// </summary>
        /// <param name="c11_City_ReChild">The C11 City Re Child DTO.</param>
        /// <returns>The new <see cref="C11_City_ReChildDto"/>.</returns>
        public C11_City_ReChildDto Insert(C11_City_ReChildDto c11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", c11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", c11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return c11_City_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the C11_City_ReChild object.
        /// </summary>
        /// <param name="c11_City_ReChild">The C11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="C11_City_ReChildDto"/>.</returns>
        public C11_City_ReChildDto Update(C11_City_ReChildDto c11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", c11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", c11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C11_City_ReChild");
                }
            }
            return c11_City_ReChild;
        }

        /// <summary>
        /// Deletes the C11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        public void Delete(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
