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
    /// DAL SQL Server implementation of <see cref="IC05_SubContinent_ReChildDal"/>
    /// </summary>
    public partial class C05_SubContinent_ReChildDal : IC05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_ReChild object from the database.
        /// </summary>
        /// <param name="subContinent_ID2">The fetch criteria.</param>
        /// <returns>A C05_SubContinent_ReChildDto object.</returns>
        public C05_SubContinent_ReChildDto Fetch(int subContinent_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID2", subContinent_ID2).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private C05_SubContinent_ReChildDto Fetch(IDataReader data)
        {
            var c05_SubContinent_ReChild = new C05_SubContinent_ReChildDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    c05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
                    c05_SubContinent_ReChild.RowVersion = dr.GetValue("RowVersion") as byte[];
                }
            }
            return c05_SubContinent_ReChild;
        }

        /// <summary>
        /// Inserts a new C05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="c05_SubContinent_ReChild">The C05 Sub Continent Re Child DTO.</param>
        /// <returns>The new <see cref="C05_SubContinent_ReChildDto"/>.</returns>
        public C05_SubContinent_ReChildDto Insert(C05_SubContinent_ReChildDto c05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddC05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", c05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", c05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    c05_SubContinent_ReChild.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return c05_SubContinent_ReChild;
        }

        /// <summary>
        /// Updates in the database all changes made to the C05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="c05_SubContinent_ReChild">The C05 Sub Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="C05_SubContinent_ReChildDto"/>.</returns>
        public C05_SubContinent_ReChildDto Update(C05_SubContinent_ReChildDto c05_SubContinent_ReChild)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateC05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", c05_SubContinent_ReChild.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", c05_SubContinent_ReChild.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@RowVersion", c05_SubContinent_ReChild.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("C05_SubContinent_ReChild");

                    c05_SubContinent_ReChild.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return c05_SubContinent_ReChild;
        }

        /// <summary>
        /// Deletes the C05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteC05_SubContinent_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
