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
    /// DAL SQL Server implementation of <see cref="ID05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class D05_SubContinent_ChildDal : ID05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a D05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="subContinent_ID1">The fetch criteria.</param>
        /// <returns>A D05_SubContinent_ChildDto object.</returns>
        public D05_SubContinent_ChildDto Fetch(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private D05_SubContinent_ChildDto Fetch(IDataReader data)
        {
            var d05_SubContinent_Child = new D05_SubContinent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    d05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                }
            }
            return d05_SubContinent_Child;
        }

        /// <summary>
        /// Inserts a new D05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="d05_SubContinent_Child">The D05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="D05_SubContinent_ChildDto"/>.</returns>
        public D05_SubContinent_ChildDto Insert(D05_SubContinent_ChildDto d05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", d05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", d05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
            return d05_SubContinent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the D05_SubContinent_Child object.
        /// </summary>
        /// <param name="d05_SubContinent_Child">The D05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="D05_SubContinent_ChildDto"/>.</returns>
        public D05_SubContinent_ChildDto Update(D05_SubContinent_ChildDto d05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", d05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", d05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D05_SubContinent_Child");
                }
            }
            return d05_SubContinent_Child;
        }

        /// <summary>
        /// Deletes the D05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
