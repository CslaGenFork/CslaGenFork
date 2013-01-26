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
    /// DAL SQL Server implementation of <see cref="ID05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class D05_SubContinent_ReChildDal : ID05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a D05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A D05_SubContinent_ReChildDto object.</returns>
        public D05_SubContinent_ReChildDto Fetch(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private D05_SubContinent_ReChildDto Fetch(IDataReader data)
        {
            var d05_SubContinent_ReChild = new D05_SubContinent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    d05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                }
            }
            return d05_SubContinent_ReChild;
        }

        /// <summary>
        /// Inserts a new D05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="d05_SubContinent_ReChild">The D05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="D05_SubContinent_ReChildDto"/>.</returns>
        public D05_SubContinent_ReChildDto Insert(D05_SubContinent_ReChildDto d05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", d05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", d05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return d05_SubContinent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the D05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="d05_SubContinent_ReChild">The D05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="D05_SubContinent_ReChildDto"/>.</returns>
        public D05_SubContinent_ReChildDto Update(D05_SubContinent_ReChildDto d05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", d05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", d05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D05_SubContinent_ReChild");
                }
            }
            return d05_SubContinent_ReChild;
        }

        /// <summary>
        /// Deletes the D05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
