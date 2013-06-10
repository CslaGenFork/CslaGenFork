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
    /// DAL SQL Server implementation of <see cref="IC05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class C05_SubContinent_ChildDal : IC05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="parentSubContinent_ID1">The fetch criteria.</param>
        /// <returns>A C05_SubContinent_ChildDto object.</returns>
        public C05_SubContinent_ChildDto Fetch(int parentSubContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", parentSubContinent_ID1).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C05_SubContinent_ChildDto Fetch(IDataReader data)
        {
            var c05_SubContinent_Child = new C05_SubContinent_ChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                    c05_SubContinent_Child.RowVersion = dr.GetValue("RowVersion") as byte[];
                }
            }
            return c05_SubContinent_Child;
        }

        /// <summary>
        /// Inserts a new C05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="c05_SubContinent_Child">The C05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="C05_SubContinent_ChildDto"/>.</returns>
        public C05_SubContinent_ChildDto Insert(C05_SubContinent_ChildDto c05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", c05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", c05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    c05_SubContinent_Child.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return c05_SubContinent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the C05_SubContinent_Child object.
        /// </summary>
        /// <param name="c05_SubContinent_Child">The C05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="C05_SubContinent_ChildDto"/>.</returns>
        public C05_SubContinent_ChildDto Update(C05_SubContinent_ChildDto c05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", c05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", c05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@RowVersion", c05_SubContinent_Child.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C05_SubContinent_Child");

                    c05_SubContinent_Child.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return c05_SubContinent_Child;
        }

        /// <summary>
        /// Deletes the C05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        public void Delete(int subContinent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", subContinent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
