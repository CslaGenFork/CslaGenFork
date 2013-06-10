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
    /// DAL SQL Server implementation of <see cref="ID07_Country_ChildDal"/>
    /// </summary>
    public partial class D07_Country_ChildDal : ID07_Country_ChildDal
    {
        /// <summary>
        /// Loads a D07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A D07_Country_ChildDto object.</returns>
        public D07_Country_ChildDto Fetch(int country_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", country_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private D07_Country_ChildDto Fetch(IDataReader data)
        {
            var d07_Country_Child = new D07_Country_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    d07_Country_Child.Country_Child_Name = dr.GetString("Country_Child_Name");
                }
            }
            return d07_Country_Child;
        }

        /// <summary>
        /// Inserts a new D07_Country_Child object in the database.
        /// </summary>
        /// <param name="d07_Country_Child">The D07 Country Child DTO.</param>
        /// <returns>The new <see cref="D07_Country_ChildDto"/>.</returns>
        public D07_Country_ChildDto Insert(D07_Country_ChildDto d07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", d07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", d07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return d07_Country_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the D07_Country_Child object.
        /// </summary>
        /// <param name="d07_Country_Child">The D07 Country Child DTO.</param>
        /// <returns>The updated <see cref="D07_Country_ChildDto"/>.</returns>
        public D07_Country_ChildDto Update(D07_Country_ChildDto d07_Country_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", d07_Country_Child.Parent_Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", d07_Country_Child.Country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D07_Country_Child");
                }
            }
            return d07_Country_Child;
        }

        /// <summary>
        /// Deletes the D07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        public void Delete(int country_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD07_Country_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID1", country_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
