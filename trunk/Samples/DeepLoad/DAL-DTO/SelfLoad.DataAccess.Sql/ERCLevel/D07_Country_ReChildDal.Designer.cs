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
    /// DAL SQL Server implementation of <see cref="ID07_Country_ReChildDal"/>
    /// </summary>
    public partial class D07_Country_ReChildDal : ID07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a D07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A D07_Country_ReChildDto object.</returns>
        public D07_Country_ReChildDto Fetch(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private D07_Country_ReChildDto Fetch(IDataReader data)
        {
            var d07_Country_ReChild = new D07_Country_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    d07_Country_ReChild.Country_Child_Name = dr.GetString("Country_Child_Name");
                }
            }
            return d07_Country_ReChild;
        }

        /// <summary>
        /// Inserts a new D07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="d07_Country_ReChild">The D07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="D07_Country_ReChildDto"/>.</returns>
        public D07_Country_ReChildDto Insert(D07_Country_ReChildDto d07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", d07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", d07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return d07_Country_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the D07_Country_ReChild object.
        /// </summary>
        /// <param name="d07_Country_ReChild">The D07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="D07_Country_ReChildDto"/>.</returns>
        public D07_Country_ReChildDto Update(D07_Country_ReChildDto d07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", d07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", d07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D07_Country_ReChild");
                }
            }
            return d07_Country_ReChild;
        }

        /// <summary>
        /// Deletes the D07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
