using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadRO.DataAccess;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IB01_ContinentCollDal"/>
    /// </summary>
    public partial class B01_ContinentCollDal : IB01_ContinentCollDal
    {
        private List<B03_Continent_ChildDto> _b03_Continent_Child = new List<B03_Continent_ChildDto>();
        private List<B03_Continent_ReChildDto> _b03_Continent_ReChild = new List<B03_Continent_ReChildDto>();
        private List<B04_SubContinentDto> _b03_SubContinentColl = new List<B04_SubContinentDto>();
        private List<B05_SubContinent_ChildDto> _b05_SubContinent_Child = new List<B05_SubContinent_ChildDto>();
        private List<B05_SubContinent_ReChildDto> _b05_SubContinent_ReChild = new List<B05_SubContinent_ReChildDto>();
        private List<B06_CountryDto> _b05_CountryColl = new List<B06_CountryDto>();
        private List<B07_Country_ChildDto> _b07_Country_Child = new List<B07_Country_ChildDto>();
        private List<B07_Country_ReChildDto> _b07_Country_ReChild = new List<B07_Country_ReChildDto>();
        private List<B08_RegionDto> _b07_RegionColl = new List<B08_RegionDto>();
        private List<B09_Region_ChildDto> _b09_Region_Child = new List<B09_Region_ChildDto>();
        private List<B09_Region_ReChildDto> _b09_Region_ReChild = new List<B09_Region_ReChildDto>();
        private List<B10_CityDto> _b09_CityColl = new List<B10_CityDto>();
        private List<B11_City_ChildDto> _b11_City_Child = new List<B11_City_ChildDto>();
        private List<B11_City_ReChildDto> _b11_City_ReChild = new List<B11_City_ReChildDto>();
        private List<B12_CityRoadDto> _b11_CityRoadColl = new List<B12_CityRoadDto>();

        /// <summary>
        /// Gets the B03 Continent Single Object.
        /// </summary>
        /// <value>A list of <see cref="B03_Continent_ChildDto"/>.</value>
        public List<B03_Continent_ChildDto> B03_Continent_Child
        {
            get { return _b03_Continent_Child; }
        }

        /// <summary>
        /// Gets the B03 Continent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B03_Continent_ReChildDto"/>.</value>
        public List<B03_Continent_ReChildDto> B03_Continent_ReChild
        {
            get { return _b03_Continent_ReChild; }
        }

        /// <summary>
        /// Gets the B03 SubContinent Objects.
        /// </summary>
        /// <value>A list of <see cref="B04_SubContinentDto"/>.</value>
        public List<B04_SubContinentDto> B03_SubContinentColl
        {
            get { return _b03_SubContinentColl; }
        }

        /// <summary>
        /// Gets the B05 SubContinent Single Object.
        /// </summary>
        /// <value>A list of <see cref="B05_SubContinent_ChildDto"/>.</value>
        public List<B05_SubContinent_ChildDto> B05_SubContinent_Child
        {
            get { return _b05_SubContinent_Child; }
        }

        /// <summary>
        /// Gets the B05 SubContinent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B05_SubContinent_ReChildDto"/>.</value>
        public List<B05_SubContinent_ReChildDto> B05_SubContinent_ReChild
        {
            get { return _b05_SubContinent_ReChild; }
        }

        /// <summary>
        /// Gets the B05 Country Objects.
        /// </summary>
        /// <value>A list of <see cref="B06_CountryDto"/>.</value>
        public List<B06_CountryDto> B05_CountryColl
        {
            get { return _b05_CountryColl; }
        }

        /// <summary>
        /// Gets the B07 Country Single Object.
        /// </summary>
        /// <value>A list of <see cref="B07_Country_ChildDto"/>.</value>
        public List<B07_Country_ChildDto> B07_Country_Child
        {
            get { return _b07_Country_Child; }
        }

        /// <summary>
        /// Gets the B07 Country ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B07_Country_ReChildDto"/>.</value>
        public List<B07_Country_ReChildDto> B07_Country_ReChild
        {
            get { return _b07_Country_ReChild; }
        }

        /// <summary>
        /// Gets the B07 Region Objects.
        /// </summary>
        /// <value>A list of <see cref="B08_RegionDto"/>.</value>
        public List<B08_RegionDto> B07_RegionColl
        {
            get { return _b07_RegionColl; }
        }

        /// <summary>
        /// Gets the B09 Region Single Object.
        /// </summary>
        /// <value>A list of <see cref="B09_Region_ChildDto"/>.</value>
        public List<B09_Region_ChildDto> B09_Region_Child
        {
            get { return _b09_Region_Child; }
        }

        /// <summary>
        /// Gets the B09 Region ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B09_Region_ReChildDto"/>.</value>
        public List<B09_Region_ReChildDto> B09_Region_ReChild
        {
            get { return _b09_Region_ReChild; }
        }

        /// <summary>
        /// Gets the B09 City Objects.
        /// </summary>
        /// <value>A list of <see cref="B10_CityDto"/>.</value>
        public List<B10_CityDto> B09_CityColl
        {
            get { return _b09_CityColl; }
        }

        /// <summary>
        /// Gets the B11 City Single Object.
        /// </summary>
        /// <value>A list of <see cref="B11_City_ChildDto"/>.</value>
        public List<B11_City_ChildDto> B11_City_Child
        {
            get { return _b11_City_Child; }
        }

        /// <summary>
        /// Gets the B11 City ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="B11_City_ReChildDto"/>.</value>
        public List<B11_City_ReChildDto> B11_City_ReChild
        {
            get { return _b11_City_ReChild; }
        }

        /// <summary>
        /// Gets the B11 CityRoad Objects.
        /// </summary>
        /// <value>A list of <see cref="B12_CityRoadDto"/>.</value>
        public List<B12_CityRoadDto> B11_CityRoadColl
        {
            get { return _b11_CityRoadColl; }
        }

        /// <summary>
        /// Loads a B01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="B02_ContinentDto"/>.</returns>
        public List<B02_ContinentDto> Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetB01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<B02_ContinentDto> LoadCollection(IDataReader data)
        {
            var b01_ContinentColl = new List<B02_ContinentDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    b01_ContinentColl.Add(Fetch(dr));
                }
                if (b01_ContinentColl.Count > 0)
                    FetchChildren(dr);
            }
            return b01_ContinentColl;
        }

        private B02_ContinentDto Fetch(SafeDataReader dr)
        {
            var b02_Continent = new B02_ContinentDto();
            // Value properties
            b02_Continent.Continent_ID = dr.GetInt32("Continent_ID");
            b02_Continent.Continent_Name = dr.GetString("Continent_Name");

            return b02_Continent;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            while (dr.Read())
            {
                _b03_Continent_Child.Add(FetchB03_Continent_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b03_Continent_ReChild.Add(FetchB03_Continent_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b03_SubContinentColl.Add(FetchB04_SubContinent(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b05_SubContinent_Child.Add(FetchB05_SubContinent_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b05_SubContinent_ReChild.Add(FetchB05_SubContinent_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b05_CountryColl.Add(FetchB06_Country(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b07_Country_Child.Add(FetchB07_Country_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b07_Country_ReChild.Add(FetchB07_Country_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b07_RegionColl.Add(FetchB08_Region(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b09_Region_Child.Add(FetchB09_Region_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b09_Region_ReChild.Add(FetchB09_Region_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b09_CityColl.Add(FetchB10_City(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b11_City_Child.Add(FetchB11_City_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b11_City_ReChild.Add(FetchB11_City_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _b11_CityRoadColl.Add(FetchB12_CityRoad(dr));
            }
        }

        private B03_Continent_ChildDto FetchB03_Continent_Child(SafeDataReader dr)
        {
            var b03_Continent_Child = new B03_Continent_ChildDto();
            // Value properties
            b03_Continent_Child.Continent_Child_Name = dr.GetString("Continent_Child_Name");
            // parent properties
            b03_Continent_Child.Parent_Continent_ID = dr.GetInt32("Continent_ID1");

            return b03_Continent_Child;
        }

        private B03_Continent_ReChildDto FetchB03_Continent_ReChild(SafeDataReader dr)
        {
            var b03_Continent_ReChild = new B03_Continent_ReChildDto();
            // Value properties
            b03_Continent_ReChild.Continent_Child_Name = dr.GetString("Continent_Child_Name");
            // parent properties
            b03_Continent_ReChild.Parent_Continent_ID = dr.GetInt32("Continent_ID2");

            return b03_Continent_ReChild;
        }

        private B04_SubContinentDto FetchB04_SubContinent(SafeDataReader dr)
        {
            var b04_SubContinent = new B04_SubContinentDto();
            // Value properties
            b04_SubContinent.SubContinent_ID = dr.GetInt32("SubContinent_ID");
            b04_SubContinent.SubContinent_Name = dr.GetString("SubContinent_Name");
            // parent properties
            b04_SubContinent.Parent_Continent_ID = dr.GetInt32("Parent_Continent_ID");

            return b04_SubContinent;
        }

        private B05_SubContinent_ChildDto FetchB05_SubContinent_Child(SafeDataReader dr)
        {
            var b05_SubContinent_Child = new B05_SubContinent_ChildDto();
            // Value properties
            b05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
            // parent properties
            b05_SubContinent_Child.Parent_SubContinent_ID = dr.GetInt32("SubContinent_ID1");

            return b05_SubContinent_Child;
        }

        private B05_SubContinent_ReChildDto FetchB05_SubContinent_ReChild(SafeDataReader dr)
        {
            var b05_SubContinent_ReChild = new B05_SubContinent_ReChildDto();
            // Value properties
            b05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
            // parent properties
            b05_SubContinent_ReChild.Parent_SubContinent_ID = dr.GetInt32("SubContinent_ID2");

            return b05_SubContinent_ReChild;
        }

        private B06_CountryDto FetchB06_Country(SafeDataReader dr)
        {
            var b06_Country = new B06_CountryDto();
            // Value properties
            b06_Country.Country_ID = dr.GetInt32("Country_ID");
            b06_Country.Country_Name = dr.GetString("Country_Name");
            // parent properties
            b06_Country.Parent_SubContinent_ID = dr.GetInt32("Parent_SubContinent_ID");

            return b06_Country;
        }

        private B07_Country_ChildDto FetchB07_Country_Child(SafeDataReader dr)
        {
            var b07_Country_Child = new B07_Country_ChildDto();
            // Value properties
            b07_Country_Child.Country_Child_Name = dr.GetString("Country_Child_Name");
            // parent properties
            b07_Country_Child.Parent_Country_ID = dr.GetInt32("Country_ID1");

            return b07_Country_Child;
        }

        private B07_Country_ReChildDto FetchB07_Country_ReChild(SafeDataReader dr)
        {
            var b07_Country_ReChild = new B07_Country_ReChildDto();
            // Value properties
            b07_Country_ReChild.Country_Child_Name = dr.GetString("Country_Child_Name");
            // parent properties
            b07_Country_ReChild.Parent_Country_ID = dr.GetInt32("Country_ID2");

            return b07_Country_ReChild;
        }

        private B08_RegionDto FetchB08_Region(SafeDataReader dr)
        {
            var b08_Region = new B08_RegionDto();
            // Value properties
            b08_Region.Region_ID = dr.GetInt32("Region_ID");
            b08_Region.Region_Name = dr.GetString("Region_Name");
            // parent properties
            b08_Region.Parent_Country_ID = dr.GetInt32("Parent_Country_ID");

            return b08_Region;
        }

        private B09_Region_ChildDto FetchB09_Region_Child(SafeDataReader dr)
        {
            var b09_Region_Child = new B09_Region_ChildDto();
            // Value properties
            b09_Region_Child.Region_Child_Name = dr.GetString("Region_Child_Name");
            // parent properties
            b09_Region_Child.Parent_Region_ID = dr.GetInt32("Region_ID1");

            return b09_Region_Child;
        }

        private B09_Region_ReChildDto FetchB09_Region_ReChild(SafeDataReader dr)
        {
            var b09_Region_ReChild = new B09_Region_ReChildDto();
            // Value properties
            b09_Region_ReChild.Region_Child_Name = dr.GetString("Region_Child_Name");
            // parent properties
            b09_Region_ReChild.Parent_Region_ID = dr.GetInt32("Region_ID2");

            return b09_Region_ReChild;
        }

        private B10_CityDto FetchB10_City(SafeDataReader dr)
        {
            var b10_City = new B10_CityDto();
            // Value properties
            b10_City.City_ID = dr.GetInt32("City_ID");
            b10_City.City_Name = dr.GetString("City_Name");
            // parent properties
            b10_City.Parent_Region_ID = dr.GetInt32("Parent_Region_ID");

            return b10_City;
        }

        private B11_City_ChildDto FetchB11_City_Child(SafeDataReader dr)
        {
            var b11_City_Child = new B11_City_ChildDto();
            // Value properties
            b11_City_Child.City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            b11_City_Child.Parent_City_ID = dr.GetInt32("City_ID1");

            return b11_City_Child;
        }

        private B11_City_ReChildDto FetchB11_City_ReChild(SafeDataReader dr)
        {
            var b11_City_ReChild = new B11_City_ReChildDto();
            // Value properties
            b11_City_ReChild.City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            b11_City_ReChild.Parent_City_ID = dr.GetInt32("City_ID2");

            return b11_City_ReChild;
        }

        private B12_CityRoadDto FetchB12_CityRoad(SafeDataReader dr)
        {
            var b12_CityRoad = new B12_CityRoadDto();
            // Value properties
            b12_CityRoad.CityRoad_ID = dr.GetInt32("CityRoad_ID");
            b12_CityRoad.CityRoad_Name = dr.GetString("CityRoad_Name");
            // parent properties
            b12_CityRoad.Parent_City_ID = dr.GetInt32("Parent_City_ID");

            return b12_CityRoad;
        }
    }
}
