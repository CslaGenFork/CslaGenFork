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
    /// DAL SQL Server implementation of <see cref="IA05_SubContinent_ChildDal"/>
    /// </summary>
    public partial class A05_SubContinent_ChildDal : IA05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new A05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="a05_SubContinent_Child">The A05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="A05_SubContinent_ChildDto"/>.</returns>
        public A05_SubContinent_ChildDto Insert(A05_SubContinent_ChildDto a05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddA05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", a05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", a05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    a05_SubContinent_Child.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return a05_SubContinent_Child;
        }

        /// <summary>
        /// Updates in the database all changes made to the A05_SubContinent_Child object.
        /// </summary>
        /// <param name="a05_SubContinent_Child">The A05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="A05_SubContinent_ChildDto"/>.</returns>
        public A05_SubContinent_ChildDto Update(A05_SubContinent_ChildDto a05_SubContinent_Child)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateA05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", a05_SubContinent_Child.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SubContinent_Child_Name", a05_SubContinent_Child.SubContinent_Child_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@SubContinent_ID1", a05_SubContinent_Child.SubContinent_ID1).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", a05_SubContinent_Child.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("A05_SubContinent_Child");

                    a05_SubContinent_Child.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return a05_SubContinent_Child;
        }

        /// <summary>
        /// Deletes the A05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        public void Delete(int subContinent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteA05_SubContinent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", subContinent_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
