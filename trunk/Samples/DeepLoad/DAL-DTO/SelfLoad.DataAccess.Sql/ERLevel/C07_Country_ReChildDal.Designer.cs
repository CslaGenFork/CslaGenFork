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
    /// DAL SQL Server implementation of <see cref="IC07_Country_ReChildDal"/>
    /// </summary>
    public partial class C07_Country_ReChildDal : IC07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a C07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A C07_Country_ReChildDto object.</returns>
        public C07_Country_ReChildDto Fetch(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C07_Country_ReChildDto Fetch(IDataReader data)
        {
            var c07_Country_ReChild = new C07_Country_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c07_Country_ReChild.Country_Child_Name = dr.GetString("Country_Child_Name");
                }
            }
            return c07_Country_ReChild;
        }

        /// <summary>
        /// Inserts a new C07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="c07_Country_ReChild">The C07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="C07_Country_ReChildDto"/>.</returns>
        public C07_Country_ReChildDto Insert(C07_Country_ReChildDto c07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", c07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", c07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return c07_Country_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the C07_Country_ReChild object.
        /// </summary>
        /// <param name="c07_Country_ReChild">The C07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="C07_Country_ReChildDto"/>.</returns>
        public C07_Country_ReChildDto Update(C07_Country_ReChildDto c07_Country_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", c07_Country_ReChild.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", c07_Country_ReChild.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C07_Country_ReChild");
                }
            }
            return c07_Country_ReChild;
        }

        /// <summary>
        /// Deletes the C07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        public void Delete(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
