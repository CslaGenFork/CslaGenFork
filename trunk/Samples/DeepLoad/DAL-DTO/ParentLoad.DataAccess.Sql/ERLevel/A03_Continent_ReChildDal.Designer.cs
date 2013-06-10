using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IA03_Continent_ReChildDal"/>
    /// </summary>
    public partial class A03_Continent_ReChildDal : IA03_Continent_ReChildDal
    {
        /// <summary>
        /// Inserts a new A03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="a03_Continent_ReChild">The A03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="A03_Continent_ReChildDto"/>.</returns>
        public A03_Continent_ReChildDto Insert(A03_Continent_ReChildDto a03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", a03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", a03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return a03_Continent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the A03_Continent_ReChild object.
        /// </summary>
        /// <param name="a03_Continent_ReChild">The A03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="A03_Continent_ReChildDto"/>.</returns>
        public A03_Continent_ReChildDto Update(A03_Continent_ReChildDto a03_Continent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", a03_Continent_ReChild.Parent_Continent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", a03_Continent_ReChild.Continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A03_Continent_ReChild");
                }
            }
            return a03_Continent_ReChild;
        }

        /// <summary>
        /// Deletes the A03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID2">The parent Continent ID2.</param>
        public void Delete(int continent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteA03_Continent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID2", continent_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
