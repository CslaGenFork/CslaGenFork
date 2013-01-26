using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG06_CountryDal"/>
    /// </summary>
    public partial class G06_CountryDal : IG06_CountryDal
    {
        /// <summary>
        /// Inserts a new G06_Country object in the database.
        /// </summary>
        /// <param name="g06_Country">The G06 Country DTO.</param>
        /// <returns>The new <see cref="G06_CountryDto"/>.</returns>
        public G06_CountryDto Insert(G06_CountryDto g06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubContinent_ID", g06_Country.Parent_SubContinent_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_ID", g06_Country.Country_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Country_Name", g06_Country.Country_Name).DbType = DbType.String;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    g06_Country.Country_ID = (int)cmd.Parameters["@Country_ID"].Value;
                    g06_Country.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return g06_Country;
        }

        /// <summary>
        /// Updates in the database all changes made to the G06_Country object.
        /// </summary>
        /// <param name="g06_Country">The G06 Country DTO.</param>
        /// <returns>The updated <see cref="G06_CountryDto"/>.</returns>
        public G06_CountryDto Update(G06_CountryDto g06_Country)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", g06_Country.Country_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Name", g06_Country.Country_Name).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@Parent_SubContinent_ID", g06_Country.ParentSubContinentID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", g06_Country.RowVersion).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G06_Country");

                    g06_Country.RowVersion = (byte[])cmd.Parameters["@NewRowVersion"].Value;
                }
            }
            return g06_Country;
        }

        /// <summary>
        /// Deletes the G06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        public void Delete(int country_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG06_Country", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID", country_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
