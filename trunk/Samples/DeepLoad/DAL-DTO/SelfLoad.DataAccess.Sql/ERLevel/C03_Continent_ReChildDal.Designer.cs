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
    /// DAL SQL Server implementation of <see cref="IC03_Continent_ReChildDal"/>
    /// </summary>
    public partial class C03_Continent_ReChildDal : IC03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a C03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A C03_Continent_ReChildDto object.</returns>
        public C03_Continent_ReChildDto Fetch(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C03_Continent_ReChildDto Fetch(IDataReader data)
        {
            var c03_Continent_ReChild = new C03_Continent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c03_Continent_ReChild.Continent_Child_Name = dr.GetString("Continent_Child_Name");
                }
            }
            return c03_Continent_ReChild;
        }

        /// <summary>
        /// Inserts a new C03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="c03_Continent_ReChild">The C03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="C03_Continent_ReChildDto"/>.</returns>
        public C03_Continent_ReChildDto Insert(C03_Continent_ReChildDto c03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", c03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", c03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return c03_Continent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the C03_Continent_ReChild object.
        /// </summary>
        /// <param name="c03_Continent_ReChild">The C03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="C03_Continent_ReChildDto"/>.</returns>
        public C03_Continent_ReChildDto Update(C03_Continent_ReChildDto c03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", c03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", c03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C03_Continent_ReChild");
                }
            }
            return c03_Continent_ReChild;
        }

        /// <summary>
        /// Deletes the C03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        public void Delete(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
