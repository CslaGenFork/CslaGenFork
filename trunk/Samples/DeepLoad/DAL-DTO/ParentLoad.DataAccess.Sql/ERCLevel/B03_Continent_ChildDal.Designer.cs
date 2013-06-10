using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IB03_Continent_ChildDal"/>
    /// </summary>
    public partial class B03_Continent_ChildDal : IB03_Continent_ChildDal
    {
        /// <summary>
        /// Inserts a new B03_Continent_Child object in the database.
        /// </summary>
        /// <param name="b03_Continent_Child">The B03 Continent Child DTO.</param>
        /// <returns>The new <see cref="B03_Continent_ChildDto"/>.</returns>
        public B03_Continent_ChildDto Insert(B03_Continent_ChildDto b03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddB03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", b03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", b03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return b03_Continent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the B03_Continent_Child object.
        /// </summary>
        /// <param name="b03_Continent_Child">The B03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="B03_Continent_ChildDto"/>.</returns>
        public B03_Continent_ChildDto Update(B03_Continent_ChildDto b03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateB03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", b03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", b03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("B03_Continent_Child");
                }
            }
            return b03_Continent_Child;
        }

        /// <summary>
        /// Deletes the B03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        public void Delete(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteB03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
