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
    /// DAL SQL Server implementation of <see cref="ID09_CityCollDal"/>
    /// </summary>
    public partial class D09_CityCollDal : ID09_CityCollDal
    {
        /// <summary>
        /// Loads a D09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="D10_CityDto"/>.</returns>
        public List<D10_CityDto> Fetch(int parent_Region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetD09_CityColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Region_ID", parent_Region_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<D10_CityDto> LoadCollection(IDataReader data)
        {
            var d09_CityColl = new List<D10_CityDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    d09_CityColl.Add(Fetch(dr));
                }
            }
            return d09_CityColl;
        }

        private D10_CityDto Fetch(SafeDataReader dr)
        {
            var d10_City = new D10_CityDto();
            // Value properties
            d10_City.City_ID = dr.GetInt32("City_ID");
            d10_City.City_Name = dr.GetString("City_Name");

            return d10_City;
        }
    }
}
