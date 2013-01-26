using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadROSoftDelete.DataAccess;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG09_CityCollDal"/>
    /// </summary>
    public partial class G09_CityCollDal : IG09_CityCollDal
    {
        /// <summary>
        /// Loads a G09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="G10_CityDto"/>.</returns>
        public List<G10_CityDto> Fetch(int parent_Region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG09_CityColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Region_ID", parent_Region_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<G10_CityDto> LoadCollection(IDataReader data)
        {
            var g09_CityColl = new List<G10_CityDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    g09_CityColl.Add(Fetch(dr));
                }
            }
            return g09_CityColl;
        }

        private G10_CityDto Fetch(SafeDataReader dr)
        {
            var g10_City = new G10_CityDto();
            // Value properties
            g10_City.City_ID = dr.GetInt32("City_ID");
            g10_City.City_Name = dr.GetString("City_Name");

            return g10_City;
        }
    }
}
