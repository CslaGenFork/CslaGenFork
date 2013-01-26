using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IF05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class F05_SubContinent_ReChildDal : IF05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Inserts a new F05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="f05_SubContinent_ReChild">The F05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="F05_SubContinent_ReChildDto"/>.</returns>
        public F05_SubContinent_ReChildDto Insert(F05_SubContinent_ReChildDto f05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", f05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", f05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return f05_SubContinent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the F05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="f05_SubContinent_ReChild">The F05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="F05_SubContinent_ReChildDto"/>.</returns>
        public F05_SubContinent_ReChildDto Update(F05_SubContinent_ReChildDto f05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", f05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", f05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F05_SubContinent_ReChild");
                }
            }
            return f05_SubContinent_ReChild;
        }

        /// <summary>
        /// Deletes the F05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}