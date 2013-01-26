using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadROSoftDelete.DataAccess;
using ParentLoadROSoftDelete.DataAccess.ERLevel;

namespace ParentLoadROSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IE02_ContinentDal"/>
    /// </summary>
    public partial class E02_ContinentDal : IE02_ContinentDal
    {
        private E03_Continent_ChildDto _e03_Continent_Child = new E03_Continent_ChildDto();
        private E03_Continent_ReChildDto _e03_Continent_ReChild = new E03_Continent_ReChildDto();
        private List<E04_SubContinentDto> _e03_SubContinentColl = new List<E04_SubContinentDto>();
        private List<E05_SubContinent_ChildDto> _e05_SubContinent_Child = new List<E05_SubContinent_ChildDto>();
        private List<E05_SubContinent_ReChildDto> _e05_SubContinent_ReChild = new List<E05_SubContinent_ReChildDto>();
        private List<E06_CountryDto> _e05_CountryColl = new List<E06_CountryDto>();
        private List<E07_Country_ChildDto> _e07_Country_Child = new List<E07_Country_ChildDto>();
        private List<E07_Country_ReChildDto> _e07_Country_ReChild = new List<E07_Country_ReChildDto>();
        private List<E08_RegionDto> _e07_RegionColl = new List<E08_RegionDto>();
        private List<E09_Region_ChildDto> _e09_Region_Child = new List<E09_Region_ChildDto>();
        private List<E09_Region_ReChildDto> _e09_Region_ReChild = new List<E09_Region_ReChildDto>();
        private List<E10_CityDto> _e09_CityColl = new List<E10_CityDto>();
        private List<E11_City_ChildDto> _e11_City_Child = new List<E11_City_ChildDto>();
        private List<E11_City_ReChildDto> _e11_City_ReChild = new List<E11_City_ReChildDto>();
        private List<E12_CityRoadDto> _e11_CityRoadColl = new List<E12_CityRoadDto>();

        /// <summary>
        /// Gets the E03 Continent Single Object.
        /// </summary>
        /// <value>A <see cref="E03_Continent_ChildDto"/> object.</value>
        public E03_Continent_ChildDto E03_Continent_Child
        {
            get { return _e03_Continent_Child; }
        }

        /// <summary>
        /// Gets the E03 Continent ASingle Object.
        /// </summary>
        /// <value>A <see cref="E03_Continent_ReChildDto"/> object.</value>
        public E03_Continent_ReChildDto E03_Continent_ReChild
        {
            get { return _e03_Continent_ReChild; }
        }

        /// <summary>
        /// Gets the E03 SubContinent Objects.
        /// </summary>
        /// <value>A list of <see cref="E04_SubContinentDto"/>.</value>
        public List<E04_SubContinentDto> E03_SubContinentColl
        {
            get { return _e03_SubContinentColl; }
        }

        /// <summary>
        /// Gets the E05 SubContinent Single Object.
        /// </summary>
        /// <value>A list of <see cref="E05_SubContinent_ChildDto"/>.</value>
        public List<E05_SubContinent_ChildDto> E05_SubContinent_Child
        {
            get { return _e05_SubContinent_Child; }
        }

        /// <summary>
        /// Gets the E05 SubContinent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="E05_SubContinent_ReChildDto"/>.</value>
        public List<E05_SubContinent_ReChildDto> E05_SubContinent_ReChild
        {
            get { return _e05_SubContinent_ReChild; }
        }

        /// <summary>
        /// Gets the E05 Country Objects.
        /// </summary>
        /// <value>A list of <see cref="E06_CountryDto"/>.</value>
        public List<E06_CountryDto> E05_CountryColl
        {
            get { return _e05_CountryColl; }
        }

        /// <summary>
        /// Gets the E07 Country Single Object.
        /// </summary>
        /// <value>A list of <see cref="E07_Country_ChildDto"/>.</value>
        public List<E07_Country_ChildDto> E07_Country_Child
        {
            get { return _e07_Country_Child; }
        }

        /// <summary>
        /// Gets the E07 Country ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="E07_Country_ReChildDto"/>.</value>
        public List<E07_Country_ReChildDto> E07_Country_ReChild
        {
            get { return _e07_Country_ReChild; }
        }

        /// <summary>
        /// Gets the E07 Region Objects.
        /// </summary>
        /// <value>A list of <see cref="E08_RegionDto"/>.</value>
        public List<E08_RegionDto> E07_RegionColl
        {
            get { return _e07_RegionColl; }
        }

        /// <summary>
        /// Gets the E09 Region Single Object.
        /// </summary>
        /// <value>A list of <see cref="E09_Region_ChildDto"/>.</value>
        public List<E09_Region_ChildDto> E09_Region_Child
        {
            get { return _e09_Region_Child; }
        }

        /// <summary>
        /// Gets the E09 Region ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="E09_Region_ReChildDto"/>.</value>
        public List<E09_Region_ReChildDto> E09_Region_ReChild
        {
            get { return _e09_Region_ReChild; }
        }

        /// <summary>
        /// Gets the E09 City Objects.
        /// </summary>
        /// <value>A list of <see cref="E10_CityDto"/>.</value>
        public List<E10_CityDto> E09_CityColl
        {
            get { return _e09_CityColl; }
        }

        /// <summary>
        /// Gets the E11 City Single Object.
        /// </summary>
        /// <value>A list of <see cref="E11_City_ChildDto"/>.</value>
        public List<E11_City_ChildDto> E11_City_Child
        {
            get { return _e11_City_Child; }
        }

        /// <summary>
        /// Gets the E11 City ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="E11_City_ReChildDto"/>.</value>
        public List<E11_City_ReChildDto> E11_City_ReChild
        {
            get { return _e11_City_ReChild; }
        }

        /// <summary>
        /// Gets the E11 CityRoad Objects.
        /// </summary>
        /// <value>A list of <see cref="E12_CityRoadDto"/>.</value>
        public List<E12_CityRoadDto> E11_CityRoadColl
        {
            get { return _e11_CityRoadColl; }
        }

        /// <summary>
        /// Loads a E02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A E02_ContinentDto object.</returns>
        public E02_ContinentDto Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetE02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private E02_ContinentDto Fetch(IDataReader data)
        {
            var e02_Continent = new E02_ContinentDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    e02_Continent.Continent_ID = dr.GetInt32("Continent_ID");
                    e02_Continent.Continent_Name = dr.GetString("Continent_Name");
                }
                FetchChildren(dr);
            }
            return e02_Continent;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            if (dr.Read())
                FetchE03_Continent_Child(dr);
            dr.NextResult();
            if (dr.Read())
                FetchE03_Continent_ReChild(dr);
            dr.NextResult();
            while (dr.Read())
            {
                _e03_SubContinentColl.Add(FetchE04_SubContinent(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e05_SubContinent_Child.Add(FetchE05_SubContinent_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e05_SubContinent_ReChild.Add(FetchE05_SubContinent_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e05_CountryColl.Add(FetchE06_Country(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e07_Country_Child.Add(FetchE07_Country_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e07_Country_ReChild.Add(FetchE07_Country_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e07_RegionColl.Add(FetchE08_Region(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e09_Region_Child.Add(FetchE09_Region_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e09_Region_ReChild.Add(FetchE09_Region_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e09_CityColl.Add(FetchE10_City(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e11_City_Child.Add(FetchE11_City_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e11_City_ReChild.Add(FetchE11_City_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _e11_CityRoadColl.Add(FetchE12_CityRoad(dr));
            }
        }

        private void FetchE03_Continent_Child(SafeDataReader dr)
        {
            // Value properties
            _e03_Continent_Child.Continent_Child_Name = dr.GetString("Continent_Child_Name");
        }

        private void FetchE03_Continent_ReChild(SafeDataReader dr)
        {
            // Value properties
            _e03_Continent_ReChild.Continent_Child_Name = dr.GetString("Continent_Child_Name");
        }

        private E04_SubContinentDto FetchE04_SubContinent(SafeDataReader dr)
        {
            var e04_SubContinent = new E04_SubContinentDto();
            // Value properties
            e04_SubContinent.SubContinent_ID = dr.GetInt32("SubContinent_ID");
            e04_SubContinent.SubContinent_Name = dr.GetString("SubContinent_Name");

            return e04_SubContinent;
        }

        private E05_SubContinent_ChildDto FetchE05_SubContinent_Child(SafeDataReader dr)
        {
            var e05_SubContinent_Child = new E05_SubContinent_ChildDto();
            // Value properties
            e05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
            e05_SubContinent_Child.SubContinent_ID1 = dr.GetInt32("SubContinent_ID1");
            e05_SubContinent_Child.RowVersion = dr.GetValue("RowVersion") as byte[];
            // parent properties
            e05_SubContinent_Child.Parent_SubContinent_ID = dr.GetInt32("SubContinent_ID1");

            return e05_SubContinent_Child;
        }

        private E05_SubContinent_ReChildDto FetchE05_SubContinent_ReChild(SafeDataReader dr)
        {
            var e05_SubContinent_ReChild = new E05_SubContinent_ReChildDto();
            // Value properties
            e05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
            e05_SubContinent_ReChild.RowVersion = dr.GetValue("RowVersion") as byte[];
            // parent properties
            e05_SubContinent_ReChild.Parent_SubContinent_ID = dr.GetInt32("SubContinent_ID2");

            return e05_SubContinent_ReChild;
        }

        private E06_CountryDto FetchE06_Country(SafeDataReader dr)
        {
            var e06_Country = new E06_CountryDto();
            // Value properties
            e06_Country.Country_ID = dr.GetInt32("Country_ID");
            e06_Country.Country_Name = dr.GetString("Country_Name");
            e06_Country.ParentSubContinentID = dr.GetInt32("Parent_SubContinent_ID");
            e06_Country.RowVersion = dr.GetValue("RowVersion") as byte[];
            // parent properties
            e06_Country.Parent_SubContinent_ID = dr.GetInt32("Parent_SubContinent_ID");

            return e06_Country;
        }

        private E07_Country_ChildDto FetchE07_Country_Child(SafeDataReader dr)
        {
            var e07_Country_Child = new E07_Country_ChildDto();
            // Value properties
            e07_Country_Child.Country_Child_Name = dr.GetString("Country_Child_Name");
            // parent properties
            e07_Country_Child.Parent_Country_ID = dr.GetInt32("Country_ID1");

            return e07_Country_Child;
        }

        private E07_Country_ReChildDto FetchE07_Country_ReChild(SafeDataReader dr)
        {
            var e07_Country_ReChild = new E07_Country_ReChildDto();
            // Value properties
            e07_Country_ReChild.Country_Child_Name = dr.GetString("Country_Child_Name");
            // parent properties
            e07_Country_ReChild.Parent_Country_ID = dr.GetInt32("Country_ID2");

            return e07_Country_ReChild;
        }

        private E08_RegionDto FetchE08_Region(SafeDataReader dr)
        {
            var e08_Region = new E08_RegionDto();
            // Value properties
            e08_Region.Region_ID = dr.GetInt32("Region_ID");
            e08_Region.Region_Name = dr.GetString("Region_Name");
            // parent properties
            e08_Region.Parent_Country_ID = dr.GetInt32("Parent_Country_ID");

            return e08_Region;
        }

        private E09_Region_ChildDto FetchE09_Region_Child(SafeDataReader dr)
        {
            var e09_Region_Child = new E09_Region_ChildDto();
            // Value properties
            e09_Region_Child.Region_Child_Name = dr.GetString("Region_Child_Name");
            // parent properties
            e09_Region_Child.Parent_Region_ID = dr.GetInt32("Region_ID1");

            return e09_Region_Child;
        }

        private E09_Region_ReChildDto FetchE09_Region_ReChild(SafeDataReader dr)
        {
            var e09_Region_ReChild = new E09_Region_ReChildDto();
            // Value properties
            e09_Region_ReChild.Region_Child_Name = dr.GetString("Region_Child_Name");
            // parent properties
            e09_Region_ReChild.Parent_Region_ID = dr.GetInt32("Region_ID2");

            return e09_Region_ReChild;
        }

        private E10_CityDto FetchE10_City(SafeDataReader dr)
        {
            var e10_City = new E10_CityDto();
            // Value properties
            e10_City.City_ID = dr.GetInt32("City_ID");
            e10_City.City_Name = dr.GetString("City_Name");
            // parent properties
            e10_City.Parent_Region_ID = dr.GetInt32("Parent_Region_ID");

            return e10_City;
        }

        private E11_City_ChildDto FetchE11_City_Child(SafeDataReader dr)
        {
            var e11_City_Child = new E11_City_ChildDto();
            // Value properties
            e11_City_Child.City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            e11_City_Child.Parent_City_ID = dr.GetInt32("City_ID1");

            return e11_City_Child;
        }

        private E11_City_ReChildDto FetchE11_City_ReChild(SafeDataReader dr)
        {
            var e11_City_ReChild = new E11_City_ReChildDto();
            // Value properties
            e11_City_ReChild.City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            e11_City_ReChild.Parent_City_ID = dr.GetInt32("City_ID2");

            return e11_City_ReChild;
        }

        private E12_CityRoadDto FetchE12_CityRoad(SafeDataReader dr)
        {
            var e12_CityRoad = new E12_CityRoadDto();
            // Value properties
            e12_CityRoad.CityRoad_ID = dr.GetInt32("CityRoad_ID");
            e12_CityRoad.CityRoad_Name = dr.GetString("CityRoad_Name");
            // parent properties
            e12_CityRoad.Parent_City_ID = dr.GetInt32("Parent_City_ID");

            return e12_CityRoad;
        }
    }
}
