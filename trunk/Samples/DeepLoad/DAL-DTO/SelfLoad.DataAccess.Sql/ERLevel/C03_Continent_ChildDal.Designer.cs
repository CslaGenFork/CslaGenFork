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
    /// DAL SQL Server implementation of <see cref="IC03_Continent_ChildDal"/>
    /// </summary>
    public partial class C03_Continent_ChildDal : IC03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a C03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The fetch criteria.</param>
        /// <returns>A C03_Continent_ChildDto object.</returns>
        public C03_Continent_ChildDto Fetch(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C03_Continent_ChildDto Fetch(IDataReader data)
        {
            var c03_Continent_Child = new C03_Continent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c03_Continent_Child.Continent_Child_Name = dr.GetString("Continent_Child_Name");
                }
            }
            return c03_Continent_Child;
        }

        /// <summary>
        /// Inserts a new C03_Continent_Child object in the database.
        /// </summary>
        /// <param name="c03_Continent_Child">The C03 Continent Child DTO.</param>
        /// <returns>The new <see cref="C03_Continent_ChildDto"/>.</returns>
        public C03_Continent_ChildDto Insert(C03_Continent_ChildDto c03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", c03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", c03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return c03_Continent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the C03_Continent_Child object.
        /// </summary>
        /// <param name="c03_Continent_Child">The C03 Continent Child DTO.</param>
        /// <returns>The updated <see cref="C03_Continent_ChildDto"/>.</returns>
        public C03_Continent_ChildDto Update(C03_Continent_ChildDto c03_Continent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", c03_Continent_Child.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", c03_Continent_Child.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C03_Continent_Child");
                }
            }
            return c03_Continent_Child;
        }

        /// <summary>
        /// Deletes the C03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        public void Delete(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
