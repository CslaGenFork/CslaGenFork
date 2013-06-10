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
    /// DAL SQL Server implementation of <see cref="IF06_CountryDal"/>
    /// </summary>
    public partial class F06_CountryDal : IF06_CountryDal
    {
        /// <summary>
        /// Inserts a new F06_Country object in the database.
        /// </summary>
        /// <param name="f06_Country">The F06 Country DTO.</param>
        /// <returns>The new <see cref="F06_CountryDto"/>.</returns>
        public F06_CountryDto Insert(F06_CountryDto f06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", f06_Country.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", f06_Country.Country_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", f06_Country.Country_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    f06_Country.Country_ID = (int)cmd.Parameters["@Country_ID"].Value;
                }
            }
            return f06_Country;
        }

        /// <summary>
        /// Updates in the database all changes made to the F06_Country object.
        /// </summary>
        /// <param name="f06_Country">The F06 Country DTO.</param>
        /// <returns>The updated <see cref="F06_CountryDto"/>.</returns>
        public F06_CountryDto Update(F06_CountryDto f06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", f06_Country.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", f06_Country.Country_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F06_Country");
                }
            }
            return f06_Country;
        }

        /// <summary>
        /// Deletes the F06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
