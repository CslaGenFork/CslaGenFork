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
    /// DAL SQL Server implementation of <see cref="IC09_CityCollDal"/>
    /// </summary>
    public partial class C09_CityCollDal : IC09_CityCollDal
    {
        /// <summary>
        /// Loads a C09_CityColl collection from the database.
        /// </summary>
        /// <param name="parent_Region_ID">The fetch criteria.</param>
        /// <returns>A list of <see cref="C10_CityDto"/>.</returns>
        public List<C10_CityDto> Fetch(int parent_Region_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC09_CityColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_Region_ID", parent_Region_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<C10_CityDto> LoadCollection(IDataReader data)
        {
            var c09_CityColl = new List<C10_CityDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    c09_CityColl.Add(Fetch(dr));
                }
            }
            return c09_CityColl;
        }

        private C10_CityDto Fetch(SafeDataReader dr)
        {
            var c10_City = new C10_CityDto();
            // Value properties
            c10_City.City_ID = dr.GetInt32("City_ID");
            c10_City.City_Name = dr.GetString("City_Name");

            return c10_City;
        }
    }
}
