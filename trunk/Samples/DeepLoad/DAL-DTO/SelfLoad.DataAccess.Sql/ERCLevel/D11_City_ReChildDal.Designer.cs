using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID11_City_ReChildDal"/>
    /// </summary>
    public partial class D11_City_ReChildDal : ID11_City_ReChildDal
    {
        /// <summary>
        /// Loads a D11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The fetch criteria.</param>
        /// <returns>A D11_City_ReChildDto object.</returns>
        public D11_City_ReChildDto Fetch(int city_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID2", city_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private D11_City_ReChildDto Fetch(IDataReader data)
        {
            var d11_City_ReChild = new D11_City_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    d11_City_ReChild.City_Child_Name = dr.GetString("City_Child_Name");
                }
            }
            return d11_City_ReChild;
        }

        /// <summary>
        /// Inserts a new D11_City_ReChild object in the database.
        /// </summary>
        /// <param name="d11_City_ReChild">The D11 City Re Child DTO.</param>
        /// <returns>The new <see cref="D11_City_ReChildDto"/>.</returns>
        public D11_City_ReChildDto Insert(D11_City_ReChildDto d11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", d11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", d11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return d11_City_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the D11_City_ReChild object.
        /// </summary>
        /// <param name="d11_City_ReChild">The D11 City Re Child DTO.</param>
        /// <returns>The updated <see cref="D11_City_ReChildDto"/>.</returns>
        public D11_City_ReChildDto Update(D11_City_ReChildDto d11_City_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", d11_City_ReChild.Parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Child_Name", d11_City_ReChild.City_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D11_City_ReChild");
                }
            }
            return d11_City_ReChild;
        }

        /// <summary>
        /// Deletes the D11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD11_City_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
