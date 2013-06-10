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
    /// DAL SQL Server implementation of <see cref="ID03_Continent_ChildDal"/>
    /// </summary>
    public partial class D03_Continent_ChildDal : ID03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a D03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A D03_Continent_ChildDto object.</returns>
        public D03_Continent_ChildDto Fetch(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private D03_Continent_ChildDto Fetch(IDataReader data)
        {
            var d03_Continent_Child = new D03_Continent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    d03_Continent_Child.Continent_Child_Name = dr.GetString("Continent_Child_Name");
                }
            }
            return d03_Continent_Child;
        }

        /// <summary>
        /// Inserts a new D03_Continent_Child object in the database.
        /// </summary>
        /// <param name="d03_Continent_Child">The D03 Continent Child DTO.</param>
        /// <returns>The new <see cref="D03_Continent_ChildDto"/>.</returns>
        public D03_Continent_ChildDto Insert(D03_Continent_ChildDto d03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", d03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", d03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return d03_Continent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the D03_Continent_Child object.
        /// </summary>
        /// <param name="d03_Continent_Child">The D03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="D03_Continent_ChildDto"/>.</returns>
        public D03_Continent_ChildDto Update(D03_Continent_ChildDto d03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", d03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", d03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D03_Continent_Child");
                }
            }
            return d03_Continent_Child;
        }

        /// <summary>
        /// Deletes the D03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        public void Delete(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
