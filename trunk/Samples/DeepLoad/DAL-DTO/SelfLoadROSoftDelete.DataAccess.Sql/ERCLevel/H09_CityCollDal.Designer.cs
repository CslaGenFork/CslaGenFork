using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH09_CityCollDal"/>
    /// </summary>
    public partial class H09_CityCollDal : IH09_CityCollDal
    {
        /// <summary>
        /// Loads a H09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="H10_CityDto"/>.</returns>
        public List<H10_CityDto> Fetch(int parent_Region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH09_CityColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Region_ID", parent_Region_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<H10_CityDto> LoadCollection(IDataReader data)
        {
            var h09_CityColl = new List<H10_CityDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    h09_CityColl.Add(Fetch(dr));
                }
            }
            return h09_CityColl;
        }

        private H10_CityDto Fetch(SafeDataReader dr)
        {
            var h10_City = new H10_CityDto();
            // Value properties
            h10_City.City_ID = dr.GetInt32("City_ID");
            h10_City.City_Name = dr.GetString("City_Name");

            return h10_City;
        }
    }
}
